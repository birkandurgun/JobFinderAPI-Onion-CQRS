using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Applicants.Queries.GetApplicantById
{
    public class GetApplicantByIdQuery : IQuery<GetApplicantByIdResponse>
    {
        public string Id { get; set; }
    }
}
