using MiniERP.Domain.Base;

namespace MiniERP.Domain.Entities
{
    public class Pedido : EntityBase
    {
        public Guid CodigoCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public int Situacao { get; set; }
        public DateTime? DtSituacaoEmProcessamento { get; set; }
        public DateTime? DtSituacaoProcessado { get; set; }
        public DateTime? DtSituacaoAguardandoPagamento { get; set; }
    }
}
