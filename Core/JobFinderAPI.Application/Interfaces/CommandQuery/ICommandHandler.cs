using JobFinderAPI.Domain.Shared;
using MediatR;

namespace JobFinderAPI.Application.Interfaces.CommandQuery
{
    public interface ICommandHandler<TCommand>
    : IRequestHandler<TCommand, Result>
    where TCommand : ICommand { }

    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse> { }
}
