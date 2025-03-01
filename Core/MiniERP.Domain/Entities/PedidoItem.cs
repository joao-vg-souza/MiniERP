using MiniERP.Domain.Base;

namespace MiniERP.Domain.Entities
{
    public class PedidoItem : EntityBase
    {
        public Guid CodigoPedido { get; set; }
        public Guid CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal => Quantidade * PrecoUnitario;
    }
}
