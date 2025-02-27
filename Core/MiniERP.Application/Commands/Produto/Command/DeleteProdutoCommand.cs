using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Produto.Command
{
    public class DeleteProdutoCommand : IDomainCommand<MediatR.Unit>
    {
        public Guid CodigoProduto { get; set; }
    }
}
