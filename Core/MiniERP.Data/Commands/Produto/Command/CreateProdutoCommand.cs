using MiniERP.Application.Commands.Produto.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Produto.Command
{
    public class CreateProdutoCommand : IDomainCommand<CreateProdutoCommandResponse>
    {
        public  string Nome { get; set; }
        public string? Descricao { get; set; }
        public  Guid CodigoCategoria { get; set; }
        public  decimal PrecoCusto { get; set; }
        public  decimal PrecoVenda { get; set; }
        public  int EstoqueAtual { get; set; }
        public  bool Ativo { get; set; }
    }
}
