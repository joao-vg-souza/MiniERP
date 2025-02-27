using MiniERP.Application.Commands.Categoria.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Categoria.Command
{
    public class CreateCategoriaCommand : IDomainCommand<CreateCategoriaCommandResponse>
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
