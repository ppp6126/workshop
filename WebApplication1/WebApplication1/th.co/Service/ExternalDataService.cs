using System.Text.Json;
using WebApplication1.th.co.Repository.Interfaces;

namespace WebApplication1.th.co.Repository;

public class ExternalDataService: IExternalDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _weatherApiKey;

        public ExternalDataService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _weatherApiKey = config["OpenWeather:ApiKey"] ?? "";
        }

        public async Task<double?> GetRainfallAsync(double lat, double lon)
        {
            var url = $"https://openweathermap.org/data/3.0/onecall/timemachine?lat={lat}&lon={lon}&dt=1643803200&appid={_weatherApiKey}";
            var res = await _httpClient.GetAsync(url);
            if (!res.IsSuccessStatusCode) return null;

            using var stream = await res.Content.ReadAsStreamAsync();
            var json = await JsonDocument.ParseAsync(stream);

            // ตัวอย่าง JSON: rain.1h หรือ rain.3h
            if (json.RootElement.TryGetProperty("rain", out var rainElement))
            {
                if (rainElement.TryGetProperty("1h", out var oneHourRain))
                {
                    return oneHourRain.GetDouble();
                }
            }

            return 0.0;
        }

        public async Task<double?> GetTemperatureAsync(double lat, double lon)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={_weatherApiKey}&units=metric";
            var res = await _httpClient.GetAsync(url);
            if (!res.IsSuccessStatusCode) return null;

            using var stream = await res.Content.ReadAsStreamAsync();
            var json = await JsonDocument.ParseAsync(stream);

            return json.RootElement.GetProperty("main").GetProperty("temp").GetDouble();
        }

        public async Task<double?> GetEarthquakeMagnitudeAsync(double lat, double lon)
        {
            var url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/significant_hour.geojson";
            var res = await _httpClient.GetAsync(url);
            if (!res.IsSuccessStatusCode) return null;

            using var stream = await res.Content.ReadAsStreamAsync();
            var json = await JsonDocument.ParseAsync(stream);

            foreach (var feature in json.RootElement.GetProperty("features").EnumerateArray())
            {
                var magnitude = feature.GetProperty("properties").GetProperty("mag").GetDouble();
                var coordinates = feature.GetProperty("geometry").GetProperty("coordinates").EnumerateArray().ToArray();
                var quakeLon = coordinates[0].GetDouble();
                var quakeLat = coordinates[1].GetDouble();

                var distance = Math.Sqrt(Math.Pow(lat - quakeLat, 2) + Math.Pow(lon - quakeLon, 2));
                if (distance < 2.0) // 2 degrees ~ 200km
                    return magnitude;
            }

            return null;
        }
    }