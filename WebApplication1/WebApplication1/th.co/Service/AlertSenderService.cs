using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using WebApplication1.th.co.Model;
using WebApplication1.th.co.Repository.Interfaces;
using WebApplication1.th.co.utils;

namespace WebApplication1.th.co.Repository;

public class AlertSenderService: IAlertSenderService
{
    private readonly MongoDbContext _mongo;

    public AlertSenderService(MongoDbContext mongo)
    {
        _mongo = mongo;
    }

    public async Task<bool> SendAlertAsync(int regionId, string message)
    {
        // 1. ดึงข้อมูล Region เพื่อตรวจสอบว่าอยู่หรือไม่
        var region = await _mongo.Regions.Find(r => r.Id == regionId).FirstOrDefaultAsync();
        if (region == null) return false;

        // 2. สร้าง Alert ใหม่
        var alert = new Alert
        {
            RegionId = regionId,
            Message = message,
            SentAt = DateTime.UtcNow
        };

        // 3. ส่งแจ้งเตือน (แทนด้วย Console หรือจะใส่ Twilio/SendGrid ก็ได้)
        Console.WriteLine($"[ALERT] ({region.Name}) - {message}");

        // 4. บันทึกลงฐานข้อมูล
        await _mongo.Alerts.InsertOneAsync(alert);

        return true;
    }
}