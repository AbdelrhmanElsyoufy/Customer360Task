namespace Customer360.Data.Entity
{
    public class FreeUnitUsage
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int InitialNumber { get; set; }
        public int UnusedAmount { get; set; }
        public int UsedAmount { get; set; }
        public string MeasurementName { get; set; } = string.Empty;
        public string UsageStartDate { get; set; } = string.Empty;
        public string UsageEndDate { get; set; } = string.Empty;
        public List<FreeUnitDetail> Details { get; set; } = new List<FreeUnitDetail>();
    }
}
