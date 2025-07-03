namespace WebApplication1.th.co.Model;

public class Alert
{
    public int Id { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; } = null!;

    public string Message { get; set; } = "";
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public string SentVia { get; set; } = "email"; // หรือ "sms"
}