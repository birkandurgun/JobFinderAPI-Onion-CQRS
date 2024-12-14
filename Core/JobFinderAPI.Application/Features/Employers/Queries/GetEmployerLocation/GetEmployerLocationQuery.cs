using JobFinderAPI.Application.Interfaces.CommandQuery;

namespace JobFinderAPI.Application.Features.Employers.Queries.GetEmployerLocation
{
    public class GetEmployerLocationQuery : IQuery<GetEmployerLocationQueryResponse>
    {
        public string EmployerId { get; set; }
    }
}
