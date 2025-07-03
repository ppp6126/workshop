using Microsoft.AspNetCore.Mvc;
using WebApplication1.th.co.Dto;
using WebApplication1.th.co.Repository.Interfaces;

namespace WebApplication1.th.co.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AlertSettingsController  : ControllerBase
{
    private readonly IAlertSettingRepository _alertSettingRepo;

    public AlertSettingsController(IAlertSettingRepository alertSettingRepo)
    {
        _alertSettingRepo = alertSettingRepo;
    }

    [HttpPost]
    public async Task<IActionResult> SetAlertSetting([FromBody] AlertSettingDto dto)
    {
        var result = await _alertSettingRepo.SetAlertSettingAsync(dto);
        return Ok(result);
    }
}