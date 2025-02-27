using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Endereco.Command
{
    public class DeleteEnderecoCommand : IDomainCommand<MediatR.Unit>
    {
        public Guid CodigoEndereco { get; set; }
    }
}
