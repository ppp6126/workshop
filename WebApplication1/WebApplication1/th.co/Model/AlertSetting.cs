using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.th.co.Model;

public class AlertSetting
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = default!;

    public int RegionId { get; set; }

    public double RainfallThreshold { get; set; }
    public double TemperatureThreshold { get; set; }
    public double EarthquakeThreshold { get; set; }

    public List<string> AlertChannels { get; set; } = new();
}