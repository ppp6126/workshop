using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.th.co.Dto;
using WebApplication1.th.co.Repository.Interfaces;

namespace WebApplication1.th.co.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AlertsController : ControllerBase
{
    private readonly IAlertSenderService _alertSender;

    public AlertsController(IAlertSenderService alertSender)
    {
        _alertSender = alertSender;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendAlert([FromBody] AlertSendRequestDto dto)
    {
        var success = await _alertSender.SendAlertAsync(dto.RegionId, dto.Message);
        if (!success) return BadRequest("Could not send alert.");
        return Ok("Alert sent.");
    }
}
