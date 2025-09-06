using Customer360.Data.Dto;
using Customer360.Service.UsageService;
using Microsoft.AspNetCore.Mvc;

namespace Customer360.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsageSummaryController : ControllerBase
    {
        private readonly IUsageSummaryService _service;

        public UsageSummaryController(IUsageSummaryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetUsageSummary(string serviceType, string serviceNumber)
        {
            try
            {
                var response = _service.GetUsageSummary(serviceType, serviceNumber);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Status = "Error", Message = ex.Message, Data = new List<UsageDto>(), IsSuspended = false });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = "Error", Message = $"An error occurred: {ex.Message}", Data = new List<UsageDto>(), IsSuspended = false });
            }
        }
    }
}