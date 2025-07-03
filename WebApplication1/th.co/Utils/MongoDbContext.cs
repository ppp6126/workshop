using MongoDB.Driver;
using WebApplication1.th.co.Model;

namespace WebApplication1.th.co.utils;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Region> Regions => _database.GetCollection<Region>("Regions");
    public IMongoCollection<AlertSetting> AlertSettings => _database.GetCollection<AlertSetting>("AlertSettings");
    public IMongoCollection<DisasterRisk> DisasterRisks => _database.GetCollection<DisasterRisk>("DisasterRisks");
    public IMongoCollection<Alert> Alerts => _database.GetCollection<Alert>("Alerts");
    public IMongoCollection<DisasterType> DisasterTypes => _database.GetCollection<DisasterType>("DisasterTypes");
}