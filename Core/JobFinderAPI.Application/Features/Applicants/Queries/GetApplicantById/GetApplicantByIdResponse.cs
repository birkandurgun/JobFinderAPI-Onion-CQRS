namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantById
{
    public class GetApplicantByIdResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}