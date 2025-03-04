using MiniERP.Application.DTOs.PedidoItem;
using MiniERP.Application.Queries.Base;

namespace MiniERP.Application.Queries.Pedido.Response
{
    public class GetPedidoResponse : BaseEntityResponse
    {
        private GetPedidoResponse(Domain.Entities.Pedido pedido) : base(pedido)
        {
            CodigoCliente = pedido.CodigoCliente;
            ValorTotal = pedido.ValorTotal;
            Situacao = pedido.Situacao;
            DtSituacaoEmProcessamento = pedido.DtSituacaoEmProcessamento;
            DtSituacaoProcessado = pedido.DtSituacaoProcessado;
            DtSituacaoAguardandoPagamento = pedido.DtSituacaoAguardandoPagamento;
        }

        public Guid CodigoCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public int Situacao { get; set; }
        public DateTime? DtSituacaoEmProcessamento { get; set; }
        public DateTime? DtSituacaoProcessado { get; set; }
        public DateTime? DtSituacaoAguardandoPagamento { get; set; }

        public static GetPedidoResponse EntityToResponse(Domain.Entities.Pedido pedido) => new(pedido);
    }
}
