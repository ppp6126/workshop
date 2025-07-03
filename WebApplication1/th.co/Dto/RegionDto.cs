namespace WebApplication1.th.co.Dto;

public class RegionDto
{
    public string Name { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<string> DisasterTypes { get; set; } = new(); // เช่น ["Flood", "Earthquake"]
}