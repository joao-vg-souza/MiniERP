using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Contato.Command
{
    public class DeleteContatoCommand : IDomainCommand<MediatR.Unit>
    {
        public Guid CodigoContato { get; set; }
    }
}
