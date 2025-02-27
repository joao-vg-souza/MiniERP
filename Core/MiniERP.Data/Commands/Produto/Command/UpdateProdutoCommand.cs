using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Produto.Command
{
    public class UpdateProdutoCommand : IDomainCommand<MediatR.Unit>
    {
        public Guid CodigoProduto { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueAtual { get; set; }
        public bool Ativo { get; set; }
    }
}
