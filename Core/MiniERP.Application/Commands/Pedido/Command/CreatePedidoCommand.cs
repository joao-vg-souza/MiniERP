using MiniERP.Application.Commands.DTOs.PedidoItem;
using MiniERP.Application.Commands.Pedido.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Pedido.Command
{
    public class CreatePedidoCommand : IDomainCommand<CreatePedidoCommandResponse>
    {
        public Guid CodigoCliente { get; set; }
        public IEnumerable<PedidoItemDTO> Itens { get; set; }
    }
}
