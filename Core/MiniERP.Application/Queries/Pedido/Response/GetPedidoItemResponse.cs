using MiniERP.Application.Queries.Base;

namespace MiniERP.Application.Queries.Pedido.Response
{
    public class GetPedidoItemResponse : BaseEntityResponse
    {
        private GetPedidoItemResponse(Domain.Entities.PedidoItem item) : base(item)
        {
            CodigoPedido = item.CodigoPedido;
            CodigoProduto = item.CodigoProduto;
            Quantidade = item.Quantidade;
            PrecoUnitario = item.PrecoUnitario;
        }

        public Guid CodigoPedido { get; set; }
        public Guid CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal => Quantidade * PrecoUnitario;

        public static GetPedidoItemResponse EntityToResponse(Domain.Entities.PedidoItem item) => new(item);
    }
}
