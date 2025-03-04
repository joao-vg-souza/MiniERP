using Azure;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Infra.Bus
{
    public interface IMediator
    {
        Task<CommandResponseBase<TResponse>> Send<TResponse>(IDomainCommand<TResponse> request, CancellationToken cancellationToken = default);
        Task<CommandResponseBase<TResponse>> Send<TResponse>(IDomainQuery<TResponse> request, CancellationToken cancellationToken = default);
    }
}
