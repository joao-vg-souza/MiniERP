using MiniERP.Domain.Base;

namespace MiniERP.Domain.Entities
{
    public class Produto : EntityBase
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public Guid CodigoCategoria { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int EstoqueAtual { get; set; }
        public bool Ativo { get; set; }
    }
}
