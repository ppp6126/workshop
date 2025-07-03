using WebApplication1.th.co.Dto;
using WebApplication1.th.co.Model;

namespace WebApplication1.th.co.Repository.Interfaces;

public interface  IRegionRepository
{
    Task<Region> AddRegionAsync(RegionDto dto);
    Task<List<Region>> GetAllAsync();
    Task<Region?> GetByIdAsync(int id);
}