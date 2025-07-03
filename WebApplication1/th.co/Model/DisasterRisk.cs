namespace WebApplication1.th.co.Model;

public class DisasterRisk
{
    public int Id { get; set; }

    public int RegionId { get; set; }
    public Region Region { get; set; } = null!;

    public double Score { get; set; }
    public DateTime AssessedAt { get; set; } = DateTime.UtcNow;

    public string RiskLevel => Score >= 0.8 ? "High" : Score >= 0.5 ? "Moderate" : "Low";

}