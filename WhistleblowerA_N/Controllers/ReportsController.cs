using Microsoft.AspNetCore.Mvc;
using WhistleblowerA_N.Domain;
using WhistleblowerA_N.Repositories;

namespace WhistleblowerA_N.Controllers
{
    //Setting up the controller for the API, this will be used to handle incoming HTTP requests related to reports. It will use the IReportRepository to interact with the data layer.
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository _repository;

        public ReportsController(IReportRepository repository)
        {
            _repository = repository;
        }


        //We're returning only the tracking token
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title) ||
                string.IsNullOrWhiteSpace(request.Description))
            {
                return BadRequest("Title and Description are required.");
            }

            var report = new Report
            {
                Title = request.Title,
                Description = request.Description
            };

            var createdReport = await _repository.CreateReportAsync(report);

            return Ok(new
            {
                trackingToken = createdReport.TrackingToken
            });
        }

        [HttpGet("{trackingToken}")]
        public async Task<IActionResult> GetReportStatus(string trackingToken)
        {
            var report = await _repository.GetReportByTrackingTokenAsync(trackingToken);
            if (report == null)
            {
                return NotFound("Report not found.");
            }
            return Ok(new
            {
                status = report.Status.ToString(),
                dateReported = report.DateReported
            });


        }
    }
}

