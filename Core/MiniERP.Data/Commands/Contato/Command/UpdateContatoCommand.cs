using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Contato.Command
{
    public class UpdateContatoCommand : IDomainCommand<MediatR.Unit>
    {
        public  Guid CodigoContato { get; set; }
        public  string Email { get; set; }
        public string? TelefoneCelular { get; set; }
        public string? TelefoneFixo { get; set; }
    }
}
