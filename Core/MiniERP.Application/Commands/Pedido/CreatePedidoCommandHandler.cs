using MediatR;
using MiniERP.Application.Commands.Pedido.Command;
using MiniERP.Application.Commands.Pedido.Response;
using MiniERP.Domain.Enums;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Pedido
{
    public class CreatePedidoCommandHandler(IPedidoItemRepository pedidoItemRepository, IPedidoRepository pedidoRepository, IClienteRepository clienteRepository) : IRequestHandler<CreatePedidoCommand, CommandResponseBase<CreatePedidoCommandResponse>>
    {
        private readonly IPedidoItemRepository _pedidoItemRepository = pedidoItemRepository;
        private readonly IPedidoRepository _pedidoRepository = pedidoRepository;
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<CommandResponseBase<CreatePedidoCommandResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync<Domain.Entities.Cliente>(request.CodigoCliente);

            if (cliente == null)
                return CommandResponseBase<CreatePedidoCommandResponse>.Error<CreatePedidoCommandResponse>("Cliente não encontrado", System.Net.HttpStatusCode.BadRequest);

            var pedido = new Domain.Entities.Pedido
            {
                Codigo = Guid.NewGuid(),
                CodigoCliente = cliente.Codigo,
                DtSituacaoAguardandoPagamento = DateTime.Now,
                Situacao = (int)SituacaoPedidoEnum.AguardandoPagamento
            };

            List<Domain.Entities.PedidoItem> itens = [];

            foreach (var item in request.Itens)
            {
                itens.Add(new Domain.Entities.PedidoItem
                {
                    Codigo = Guid.NewGuid(),
                    CodigoPedido = pedido.Codigo,
                    PrecoUnitario = item.PrecoUnitario,
                    Quantidade = item.Quantidade,
                    CodigoProduto = item.CodigoProduto
                });
            }

            pedido.ValorTotal = itens.Sum(x => x.Subtotal);

            pedido.Id = await _pedidoRepository.InsertAsync(pedido);
            await _pedidoItemRepository.BulkInsertAsync(itens);

            var response = CreatePedidoCommandResponse.EntityToResponse(pedido);

            return CommandResponseBase<CreatePedidoCommandResponse>.Create(response);
        }
    }
}
