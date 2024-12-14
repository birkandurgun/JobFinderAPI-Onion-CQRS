using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Employers.Queries.GetEmployerById
{
    public class GetEmployerByIdQuery: IQuery<GetEmployerByIdResponse>
    {
        public string Id { get; set; }
    }
}
