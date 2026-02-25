using WhistleblowerA_N.Domain;
namespace WhistleblowerA_N.Repositories
{
    public interface IReportRepository
    {
        Task<Report> CreateReportAsync(Report report);

        // avoiding a getreportbyid because this is an anonymous whistleblower system
        Task<Report?> GetReportByTrackingTokenAsync(string trackingToken);
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task UpdateReportAsync(Report report);


    }
}

