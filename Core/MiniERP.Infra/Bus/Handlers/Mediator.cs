using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Infra.Bus.Handlers
{
    public class Mediator(MediatR.IMediator mediator) : IMediator
    {
        private readonly MediatR.IMediator _mediator = mediator;

        public Task<CommandResponseBase<TResponse>> Send<TResponse>(IDomainCommand<TResponse> request, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(request, cancellationToken);
        }

        /*public Task<CommandResponseBase<TResponse>> Send<TResponse>(IDomainQuery<TResponse> request, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(request, cancellationToken);
        }*/
    }
}
