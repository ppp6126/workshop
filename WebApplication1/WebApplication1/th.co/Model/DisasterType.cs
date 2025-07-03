namespace WebApplication1.th.co.Model;

public class DisasterType
{
    public int Id { get; set; }
    public string Name { get; set; } = ""; // เช่น "Flood", "Earthquake"

    public List<RegionDisasterType> Regions { get; set; } = new();
}