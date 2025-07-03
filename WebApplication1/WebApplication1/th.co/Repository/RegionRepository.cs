using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using WebApplication1.th.co.Dto;
using WebApplication1.th.co.Model;
using WebApplication1.th.co.Repository.Interfaces;
using WebApplication1.th.co.utils;

namespace WebApplication1.th.co.Repository;

public class RegionRepository: IRegionRepository
{
    private readonly MongoDbContext _mongo;

    public RegionRepository(MongoDbContext mongo)
    {
        _mongo = mongo;
    }

    public async Task<Region> AddRegionAsync(RegionDto dto)
    {
        // 1. ค้นหา DisasterTypes ที่ชื่ออยู่ใน DTO
        var filter = Builders<DisasterType>.Filter.In(d => d.Name, dto.DisasterTypes);
        var disasterTypes = await _mongo.DisasterTypes.Find(filter).ToListAsync();

        // 2. สร้าง Region
        var region = new Region
        {
            Name = dto.Name,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            DisasterTypes = disasterTypes.Select(d => new RegionDisasterType
            {
                DisasterTypeId = d.Id
            }).ToList()
        };

        await _mongo.Regions.InsertOneAsync(region);
        return region;
    }

    public async Task<List<Region>> GetAllAsync()
    {
        return await _mongo.Regions.Find(_ => true).ToListAsync();
    }

    public async Task<Region?> GetByIdAsync(int id)
    {
        var filter = Builders<Region>.Filter.Eq(r => r.Id, id);
        return await _mongo.Regions.Find(filter).FirstOrDefaultAsync();
    }
}