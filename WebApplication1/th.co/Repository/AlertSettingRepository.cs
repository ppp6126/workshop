using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using WebApplication1.th.co.Dto;
using WebApplication1.th.co.Model;
using WebApplication1.th.co.Repository.Interfaces;
using WebApplication1.th.co.utils;

namespace WebApplication1.th.co.Repository;

public class AlertSettingRepository: IAlertSettingRepository
{
    private readonly MongoDbContext _mongo;

    public AlertSettingRepository(MongoDbContext mongo)
    {
        _mongo = mongo;
    }

    public async Task<AlertSetting> SetAlertSettingAsync(AlertSettingDto dto)
    {
        var filter = Builders<AlertSetting>.Filter.Eq(a => a.RegionId, dto.RegionId);

        var update = Builders<AlertSetting>.Update
            .Set(a => a.RainfallThreshold, dto.RainfallThreshold)
            .Set(a => a.TemperatureThreshold, dto.TemperatureThreshold)
            .Set(a => a.EarthquakeThreshold, dto.EarthquakeThreshold)
            .Set(a => a.AlertChannels, dto.AlertChannels);

        var options = new FindOneAndUpdateOptions<AlertSetting>
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After
        };

        var updated = await _mongo.AlertSettings.FindOneAndUpdateAsync(filter, update, options);
        return updated;
    }

    public Task<AlertSetting?> GetByRegionIdAsync(int regionId)
    {
        throw new NotImplementedException();
    }
}