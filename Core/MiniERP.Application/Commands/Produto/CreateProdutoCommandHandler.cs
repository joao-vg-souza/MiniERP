using MediatR;
using MiniERP.Application.Commands.Produto.Command;
using MiniERP.Application.Commands.Produto.Response;
using MiniERP.Domain.Repositories;
using MiniERP.Infra;

namespace MiniERP.Application.Commands.Produto
{
    public class CreateProdutoCommandHandler(IProdutoRepository produtoRepository) : IRequestHandler<CreateProdutoCommand, CommandResponseBase<CreateProdutoCommandResponse>>
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;

        public async Task<CommandResponseBase<CreateProdutoCommandResponse>> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Domain.Entities.Produto
            {
                Codigo = Guid.NewGuid(),
                Descricao = request.Descricao,
                CodigoCategoria = request.CodigoCategoria,
                Ativo = request.Ativo,
                EstoqueAtual = request.EstoqueAtual,
                Nome = request.Nome,
                PrecoCusto = request.PrecoCusto,
                PrecoVenda = request.PrecoVenda
            };

            produto.Id = await _produtoRepository.InsertAsync(produto);

            var response = CreateProdutoCommandResponse.EntityToResponse(produto);

            return CommandResponseBase<CreateProdutoCommandResponse>.Create(response, true, [], System.Net.HttpStatusCode.OK);
        }
    }
}
