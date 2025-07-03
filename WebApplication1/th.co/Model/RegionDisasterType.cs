namespace WebApplication1.th.co.Model;

public class RegionDisasterType
{
    public int RegionId { get; set; }
    public Region Region { get; set; } = null!;

    public int DisasterTypeId { get; set; }
    public DisasterType DisasterType { get; set; } = null!;
}