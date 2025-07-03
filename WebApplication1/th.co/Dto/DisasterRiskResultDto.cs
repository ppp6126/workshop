namespace WebApplication1.th.co.Dto;

public class DisasterRiskResultDto
{
    public int RegionId { get; set; }
    public string RegionName { get; set; } = string.Empty;
    public double RiskScore { get; set; }          // <-- ต้องมีอันนี้
    public bool ShouldAlert { get; set; }
    public double Rainfall { get; set; }
    public double Temperature { get; set; }
    public double EarthquakeMagnitude { get; set; }
}