using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Infra.Bus
{
    public interface IMediator
    {
        Task<CommandResponseBase<TResponse>> Send<TResponse>(IDomainCommand<TResponse> request, CancellationToken cancellationToken = default);
    }
}
