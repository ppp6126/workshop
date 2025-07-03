using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using WebApplication1.th.co.Dto;
using WebApplication1.th.co.Repository.Interfaces;
using WebApplication1.th.co.utils;

namespace WebApplication1.th.co.Repository;

public class DisasterRiskRepository: IDisasterRiskRepository
{    
   private readonly MongoDbContext _mongo;
        private readonly IExternalDataService _externalDataService;

        public DisasterRiskRepository(MongoDbContext mongo, IExternalDataService externalDataService)
        {
            _mongo = mongo;
            _externalDataService = externalDataService;
        }

        public async Task<List<DisasterRiskResultDto>> AssessAllRisksAsync()
        {
            var results = new List<DisasterRiskResultDto>();
            var regions = await _mongo.Regions.Find(_ => true).ToListAsync();

            foreach (var region in regions)
            {
                // ดึงข้อมูลสภาพแวดล้อมจริง
                var rainfall = await _externalDataService.GetRainfallAsync(region.Latitude, region.Longitude) ?? 0;
                var temperature = await _externalDataService.GetTemperatureAsync(region.Latitude, region.Longitude) ?? 0;
                var earthquakeMag = await _externalDataService.GetEarthquakeMagnitudeAsync(region.Latitude, region.Longitude) ?? 0;

                // คำนวณความเสี่ยง (สมมติสูตรง่าย ๆ)
                double riskScore = (rainfall / 100.0) + (earthquakeMag / 10.0) + (temperature > 35 ? 0.2 : 0);

                // ตรวจหา Alert Setting
                var alertSetting = await _mongo.AlertSettings
                    .Find(a => a.RegionId == region.Id)
                    .FirstOrDefaultAsync();

                bool shouldAlert = false;

                if (alertSetting != null)
                {
                    if (rainfall >= alertSetting.RainfallThreshold ||
                        temperature >= alertSetting.TemperatureThreshold ||
                        earthquakeMag >= alertSetting.EarthquakeThreshold)
                    {
                        shouldAlert = true;
                    }
                }

                results.Add(new DisasterRiskResultDto
                {
                    RegionId = region.Id,
                    RegionName = region.Name,
                    RiskScore = riskScore,
                    ShouldAlert = shouldAlert,
                    Rainfall = rainfall,
                    Temperature = temperature,
                    EarthquakeMagnitude = earthquakeMag
                });
            }

            return results;
        }
}