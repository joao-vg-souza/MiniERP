using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Cliente.Command
{
    public class DeleteClienteCommand : IDomainCommand<MediatR.Unit>
    {
        public Guid CodigoCliente { get; set; }
    }
}
