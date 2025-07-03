using WebApplication1.th.co.Dto;


public interface  IDisasterRiskRepository
{
    Task<List<DisasterRiskResultDto>> AssessAllRisksAsync();
}