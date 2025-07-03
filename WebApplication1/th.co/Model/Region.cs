namespace WebApplication1.th.co.Model;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public List<RegionDisasterType> DisasterTypes { get; set; } = new();
    public AlertSetting? AlertSetting { get; set; }
    public List<DisasterRisk> RiskHistory { get; set; } = new();
}