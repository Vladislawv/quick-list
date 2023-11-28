using MediatR;

namespace QuickList.Application.CQRS.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}