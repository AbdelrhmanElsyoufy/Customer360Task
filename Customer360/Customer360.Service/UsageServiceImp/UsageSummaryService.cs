using Customer360.Data;
using Customer360.Data.Dto;
using Customer360.Data.Entity;
using Customer360.Data.Response;
using Customer360.Service.UsageService;

namespace Customer360.Service.UsageServiceImp
{
    public class UsageSummaryService : IUsageSummaryService
    {
        private readonly UsageRepository _repository;

        public UsageSummaryService(UsageRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public UsageResponse GetUsageSummary(string serviceType, string serviceNumber)
        {

            if (IsSuspended(serviceNumber))
            {
                return new UsageResponse
                {
                    Status = "Suspended",
                    Message = "The Package has been suspended due to non-payment",
                    Data = new List<UsageDto>(),
                    //{
                    //    new UsageDto( ){Unit=ConvertUnit(serviceType)}
                    //},
                    IsSuspended = true
                };
            }

            List<FreeUnitUsage> usages;
            bool isGroup = IsInWeGoldGroup(serviceNumber);

            if (serviceType == "FBB" || serviceType == "Mobile")
            {
                if (isGroup)
                {
                    string groupId = "WeGoldGroup1";
                    var groupUsages = _repository.GetUsageData(serviceType, serviceNumber, isGroup: true, groupId: groupId);
                    var individualUsages = _repository.GetUsageData(serviceType, serviceNumber, isGroup: false);
                    usages = MergeWeGoldUsages(groupUsages, individualUsages);
                }
                else
                {

                    usages = _repository.GetUsageData(serviceType, serviceNumber, isGroup: false);
                }
            }
            else if (serviceType == "Voice")
            {

                usages = _repository.GetUsageData(serviceType, serviceNumber, isGroup: false);

            }
            else
            {

                return new UsageResponse()
                {
                    Status = "Error",
                    Message = $"Usage data is not available for {serviceType} service type.",
                    Data = new List<UsageDto>(),
                    IsSuspended = false
                };
            }


            var response = ConvertToResponse(usages, serviceType);
            response.Status = "Success";
            response.Message = "Usage data retrieved successfully.";
            response.IsSuspended = false;

            return response;
        }

        private bool IsInWeGoldGroup(string serviceNumber)
        {
            return serviceNumber == "WeGoldFbb123" || serviceNumber == "WeGoldMobile123";
        }

        private bool IsSuspended(string serviceNumber)
        {
            return serviceNumber == "Suspended123" || serviceNumber == "SuspendedMobile123";
        }

        private List<FreeUnitUsage> MergeWeGoldUsages(List<FreeUnitUsage> groupUsages, List<FreeUnitUsage> individualUsages)
        {
            var merged = new List<FreeUnitUsage>(groupUsages);
            foreach (var individual in individualUsages)
            {
                var existing = merged.Find(u => u.Name == individual.Name && u.MeasurementName == individual.MeasurementName);
                if (existing == null)
                {
                    merged.Add(individual);
                }
                else
                {
                    existing.InitialNumber += individual.InitialNumber;
                    existing.UnusedAmount += individual.UnusedAmount;

                    existing.UsedAmount = existing.InitialNumber - existing.UnusedAmount;

                    existing.Details.AddRange(individual.Details);
                }
            }
            return merged;
        }

        private UsageResponse ConvertToResponse(List<FreeUnitUsage> usages, string serviceType)
        {

            var response = new UsageResponse();
            List<FreeUnitUsage> filteredUsages = usages;

            // Filter for FBB
            if (serviceType == "FBB")
            {
                filteredUsages = usages.Where(u => u.Name == "TotalBroadBandQuota").ToList();
            }

            foreach (var usage in filteredUsages)
            {
                var item = new UsageDto
                {
                    FreeUnitName = usage.Name,
                    UnitsInitialNumber = usage.InitialNumber,
                    UnitsUnUsedAmount = usage.UnusedAmount,
                    UnitsUsedAmount = usage.InitialNumber - usage.UnusedAmount,
                    Unit = ConvertUnit(usage.MeasurementName),
                    UsageStartDate = string.IsNullOrEmpty(usage.UsageStartDate) ? (usage.Details.Any() ? usage.Details.Min(d => d.EffectiveDate) : "") : usage.UsageStartDate,
                    UsageEndDate = string.IsNullOrEmpty(usage.UsageEndDate) ? (usage.Details.Any() ? usage.Details.Max(d => d.ExpiryDate) : "") : usage.UsageEndDate,
                    Details = usage.Details
                };
                item.Percentage = item.UnitsInitialNumber > 0 ? (double)item.UnitsUsedAmount / item.UnitsInitialNumber * 100 : 0;
                response.Data.Add(item);
            }

            if (serviceType == "Voice")
            {
                response.Data = response.Data.Where(i => i.Unit == "Min").ToList();
            }

            if (serviceType == "FBB")
            {

                foreach (var item in response.Data)
                {
                    if (item.Unit == "MB")
                    {
                        item.UnitsInitialNumber /= 1024;
                        item.UnitsUnUsedAmount /= 1024;
                        item.UnitsUsedAmount /= 1024;
                        item.Unit = "GB";
                    }
                }
            }

            return response;
        }

        private string ConvertUnit(string measurementName)
        {
            return measurementName switch
            {
                "MB" => "MB",
                "Minutes" => "Min",
                "Unit" => "Unit",
                _ => "GB"
            };
        }
    }
}