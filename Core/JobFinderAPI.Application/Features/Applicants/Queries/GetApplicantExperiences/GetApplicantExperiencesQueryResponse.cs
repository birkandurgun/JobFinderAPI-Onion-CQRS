namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantExperiences
{
    public class GetApplicantExperiencesQueryResponse
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
