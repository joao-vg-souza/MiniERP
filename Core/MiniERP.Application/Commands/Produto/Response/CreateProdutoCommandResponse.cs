namespace MiniERP.Application.Commands.Produto.Response
{
    public class CreateProdutoCommandResponse
    {
        private CreateProdutoCommandResponse(Domain.Entities.Produto produto)
        {
            Id = produto.Id;
            Codigo = produto.Codigo;
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            CodigoCategoria = produto.CodigoCategoria;
            PrecoCusto = produto.PrecoCusto;
            PrecoVenda = produto.PrecoVenda;
            EstoqueAtual = produto.EstoqueAtual;
            Ativo = produto.Ativo;
            DtInclusao = produto.DtInclusao;
        }

        public int Id { get; set; }
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public Guid CodigoCategoria { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueAtual { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtInclusao { get; set; }

        public static CreateProdutoCommandResponse EntityToResponse(Domain.Entities.Produto produto) => new(produto);
    }
}
