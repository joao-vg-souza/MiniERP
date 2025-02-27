using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Categoria.Command
{
    public class DeleteCategoriaCommand : IDomainCommand<MediatR.Unit>
    {
        public Guid CodigoCategoria { get; set; }
    }
}
