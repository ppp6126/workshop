namespace WebApplication1.th.co.Repository.Interfaces;

public interface  IAlertSenderService
{
    Task<bool> SendAlertAsync(int regionId, string message);
}