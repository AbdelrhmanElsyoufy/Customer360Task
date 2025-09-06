using Customer360.Data.Entity;

namespace Customer360.Data.Dto
{
    public class UsageDto
    {
        public string FreeUnitName { get; set; } = string.Empty;
        public int UnitsInitialNumber { get; set; }
        public int UnitsUnUsedAmount { get; set; }
        public int UnitsUsedAmount { get; set; }
        public string Unit { get; set; } = string.Empty;
        public double Percentage { get; set; }
        public string UsageStartDate { get; set; } = string.Empty;
        public string UsageEndDate { get; set; } = string.Empty;
        public List<FreeUnitDetail> Details { get; set; } = new List<FreeUnitDetail>();
    }
}