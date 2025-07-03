using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.th.co.Dto;
using WebApplication1.th.co.Repository.Interfaces;

namespace WebApplication1.th.co.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository _regionRepo;

    public RegionsController(IRegionRepository regionRepo)
    {
        _regionRepo = regionRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegionDto dto)
    {
        var result = await _regionRepo.AddRegionAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regions = await _regionRepo.GetAllAsync();
        return Ok(regions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var region = await _regionRepo.GetByIdAsync(id);
        if (region == null) return NotFound();
        return Ok(region);
    }
}