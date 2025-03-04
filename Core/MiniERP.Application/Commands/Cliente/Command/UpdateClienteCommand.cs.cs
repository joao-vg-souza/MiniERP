using MiniERP.Application.DTOs.Contato;
using MiniERP.Application.DTOs.Endereco;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Cliente.Command
{
    public class UpdateClienteCommand : IDomainCommand<MediatR.Unit>
    {
        public Guid CodigoCliente { get; set; }
        public string Nome { get; set; }
        public int TipoCliente { get; set; }
        public string Documento { get; set; }
        public IEnumerable<ContatoDTO> Contatos { get; set; }
        public IEnumerable<EnderecoDTO> Enderecos { get; set; }
    }
}
