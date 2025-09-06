namespace Customer360.Data.Entity
{
    public class FreeUnitDetail
    {
        public string InstanceId { get; set; } = string.Empty;
        public int InitialAmount { get; set; }
        public int CurrentAmount { get; set; }
        public string EffectiveDate { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
        public string OriginType { get; set; } = string.Empty;
        public string OfferingId { get; set; } = string.Empty;
        public string PurchaseSeq { get; set; } = string.Empty;
        public string RollOverFlag { get; set; } = string.Empty;
        public string? RolloveredTime { get; set; }
    }


}



