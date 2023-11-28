using MediatR;

namespace QuickList.Application.CQRS.Abstractions;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> 
    where TCommand : ICommand
{
}