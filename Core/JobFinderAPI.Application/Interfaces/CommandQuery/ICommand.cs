using JobFinderAPI.Domain.Shared;
using MediatR;

namespace JobFinderAPI.Application.Interfaces.CommandQuery
{
    public interface ICommand: IRequest<Result> { }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
}
