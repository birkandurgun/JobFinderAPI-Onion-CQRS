namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantEducations
{
    public class GetApplicantEducationsQueryResponse
    {
        public string Institution { get; set; }
        public string Field { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
