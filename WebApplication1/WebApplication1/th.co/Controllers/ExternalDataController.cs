
using Microsoft.AspNetCore.Mvc;
using WebApplication1.th.co.Repository.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ExternalDataController : ControllerBase
{
    private readonly IExternalDataService _externalDataService;

    public ExternalDataController(IExternalDataService externalDataService)
    {
        _externalDataService = externalDataService;
    }

    [HttpGet("rainfall")]
    public async Task<IActionResult> GetRainfall([FromQuery] double lat, [FromQuery] double lon)
    {
        var data = await _externalDataService.GetRainfallAsync(lat, lon);
        return data.HasValue ? Ok(data.Value) : NotFound("No rainfall data found");
    }

    [HttpGet("temperature")]
    public async Task<IActionResult> GetTemperature([FromQuery] double lat, [FromQuery] double lon)
    {
        var data = await _externalDataService.GetTemperatureAsync(lat, lon);
        return data.HasValue ? Ok(data.Value) : NotFound("No temperature data found");
    }

    [HttpGet("earthquake")]
    public async Task<IActionResult> GetEarthquake([FromQuery] double lat, [FromQuery] double lon)
    {
        var data = await _externalDataService.GetEarthquakeMagnitudeAsync(lat, lon);
        return data.HasValue ? Ok(data.Value) : NotFound("No earthquake data found");
    }
}