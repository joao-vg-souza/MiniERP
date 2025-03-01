namespace MiniERP.Application.Commands.DTOs.PedidoItem
{
    public class PedidoItemDTO
    {
        public Guid CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
