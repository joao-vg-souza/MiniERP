using MiniERP.Application.Commands.Contato.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Contato.Command
{
    public class CreateContatoCommand : IDomainCommand<CreateContatoCommandResponse>
    {
        public  Guid CodigoCliente { get; set; }
        public  string Email { get; set; }
        public string? TelefoneCelular { get; set; }
        public string? TelefoneFixo { get; set; }
    }
}
