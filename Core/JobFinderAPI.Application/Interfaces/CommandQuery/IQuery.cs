using JobFinderAPI.Domain.Shared;
using MediatR;

namespace JobFinderAPI.Application.Interfaces.CommandQuery
{
    public interface IQuery : IRequest<Result> { }

    public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
}
