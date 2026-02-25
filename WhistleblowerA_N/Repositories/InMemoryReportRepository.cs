using System.Collections.Generic;
using WhistleblowerA_N.Domain;

namespace WhistleblowerA_N.Repositories
{
    public class InMemoryReportRepository : IReportRepository
    {
        private readonly Dictionary<string, Report> _reports = new();


        public Task<Report> CreateReportAsync(Report report)
        {
            // Using guid to generate a unique tracking token for each report, as its much safer 
            var token = Guid.NewGuid().ToString();

            report.TrackingToken = token;
            report.DateReported = DateTime.UtcNow;
            report.Status = ReportStatus.Submitted;

            _reports[token] = report;

            return Task.FromResult(report);
        }

        public Task<Report?> GetReportByTrackingTokenAsync(string trackingToken)
        {
            _reports.TryGetValue(trackingToken, out var report);
            return Task.FromResult(report);
        }

        public Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return Task.FromResult(_reports.Values.AsEnumerable());
        }

        public Task UpdateReportAsync(Report report)
        {
            if (_reports.ContainsKey(report.TrackingToken))
            {
                _reports[report.TrackingToken] = report;
            }
            return Task.CompletedTask;

        }
    }

}