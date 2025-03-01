namespace MiniERP.Application.Commands.Pedido.Response
{
    public class CreatePedidoCommandResponse
    {
        public CreatePedidoCommandResponse(Domain.Entities.Pedido pedido)
        {
            Id = pedido.Id;
            Codigo = pedido.Codigo;
            DtInclusao = pedido.DtInclusao;
            Situacao = pedido.Situacao;
            ValorTotal = pedido.ValorTotal;
        }

        public int Id { get; set; }
        public Guid Codigo { get; set; }
        public DateTime DtInclusao { get; set; }
        public int Situacao { get; set; }
        public decimal ValorTotal { get; set; }

        public static CreatePedidoCommandResponse EntityToResponse(Domain.Entities.Pedido pedido) => new(pedido);
    }
}
