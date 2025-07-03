namespace WebApplication1.th.co.Dto;

public class AlertSettingDto
{
    public int RegionId { get; set; }
    public double RainfallThreshold { get; set; }
    public double TemperatureThreshold { get; set; }
    public double EarthquakeThreshold { get; set; }
    public List<string> AlertChannels { get; set; } = new();
}