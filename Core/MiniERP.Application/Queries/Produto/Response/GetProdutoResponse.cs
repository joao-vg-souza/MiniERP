using MiniERP.Application.Queries.Base;

namespace MiniERP.Application.Queries.Produto.Response
{
    public class GetProdutoResponse : BaseEntityResponse
    {
        private GetProdutoResponse(Domain.Entities.Produto produto) : base(produto)
        {
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            CodigoCategoria = produto.CodigoCategoria;
            PrecoCusto = produto.PrecoCusto;
            PrecoVenda = produto.PrecoVenda;
            EstoqueAtual = produto.EstoqueAtual;
            Ativo = produto.Ativo;
        }

        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public Guid CodigoCategoria { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueAtual { get; set; }
        public bool Ativo { get; set; }

        public static GetProdutoResponse EntityToResponse(Domain.Entities.Produto produto) => new(produto);
    }
}
