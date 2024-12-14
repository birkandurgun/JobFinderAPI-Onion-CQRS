namespace JobFinderAPI.Application.Features.Employers.Queries.GetEmployerLocation
{
    public class GetEmployerLocationQueryResponse
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressLine { get; set; }
    }
}
