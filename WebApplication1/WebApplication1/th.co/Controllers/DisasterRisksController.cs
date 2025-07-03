using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.th.co.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DisasterRisksController : ControllerBase
{
    private readonly IDisasterRiskRepository _riskRepo;

    public DisasterRisksController(IDisasterRiskRepository riskRepo)
    {
        _riskRepo = riskRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Assess()
    {
        var results = await _riskRepo.AssessAllRisksAsync();
        return Ok(results);
    }
}