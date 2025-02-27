using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Categoria.Command
{
    public class UpdateCategoriaCommand : IDomainCommand<MediatR.Unit>
    {
        public  Guid CodigoCategoria { get; set; }
        public  string Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
