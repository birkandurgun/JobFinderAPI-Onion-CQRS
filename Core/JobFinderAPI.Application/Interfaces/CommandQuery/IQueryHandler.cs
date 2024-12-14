using JobFinderAPI.Domain.Shared;
using MediatR;

namespace JobFinderAPI.Application.Interfaces.CommandQuery
{
    public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }
}
