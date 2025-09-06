using Customer360.Data.Dto;

namespace Customer360.Data.Response
{
    public class UsageResponse
    {
        public string Status { get; set; } = "Success";
        public string Message { get; set; } = string.Empty;
        public List<UsageDto> Data { get; set; } = new List<UsageDto>();
        public bool IsSuspended { get; set; } = false;
    }
}