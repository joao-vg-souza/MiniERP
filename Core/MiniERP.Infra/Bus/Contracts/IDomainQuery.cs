using MediatR;
using MiniERP.Infra.Bus.Contracts.Infra;

namespace MiniERP.Infra.Bus.Contracts
{
    public interface IDomainQuery<T> : IRequest<CommandResponseBase<T>>, IValidateableCommand<T>
    {
    }
}
