namespace WhistleblowerA_N.Domain
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateReported { get; set; }
        
        public string TrackingToken { get; set; } = string.Empty;

        public ReportStatus Status { get; set; }
    }
}
