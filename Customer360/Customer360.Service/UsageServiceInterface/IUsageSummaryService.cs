using Customer360.Data.Response;

namespace Customer360.Service.UsageService
{
    public interface IUsageSummaryService
    {
        UsageResponse GetUsageSummary(string serviceType, string serviceNumber);
    }
}