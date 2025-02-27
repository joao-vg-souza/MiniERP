using MiniERP.Application.Commands.Cliente.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Cliente.Command
{
    public class CreateClienteCommand : IDomainCommand<CreateClienteCommandResponse>
    {
        public string Nome { get; set; }
        public int TipoCliente { get; set; }
        public string Documento { get; set; }
    }
}
