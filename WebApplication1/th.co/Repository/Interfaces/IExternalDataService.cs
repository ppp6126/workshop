namespace WebApplication1.th.co.Repository.Interfaces;

public interface IExternalDataService
{
    Task<double?> GetRainfallAsync(double lat, double lon);
    Task<double?> GetTemperatureAsync(double lat, double lon);
    Task<double?> GetEarthquakeMagnitudeAsync(double lat, double lon);
}