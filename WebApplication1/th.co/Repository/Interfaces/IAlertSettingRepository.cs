using WebApplication1.th.co.Dto;
using WebApplication1.th.co.Model;

namespace WebApplication1.th.co.Repository.Interfaces;

public interface  IAlertSettingRepository
{
    Task<AlertSetting> SetAlertSettingAsync(AlertSettingDto dto);
    Task<AlertSetting?> GetByRegionIdAsync(int regionId);
}