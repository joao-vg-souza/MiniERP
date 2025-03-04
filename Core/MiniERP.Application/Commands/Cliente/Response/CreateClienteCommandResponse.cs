using MiniERP.Application.DTOs.Contato;
using MiniERP.Application.DTOs.Endereco;

namespace MiniERP.Application.Commands.Cliente.Response
{
    public class CreateClienteCommandResponse
    {
        private CreateClienteCommandResponse(Domain.Entities.Cliente cliente, IEnumerable<ContatoDTO> contatos, IEnumerable<EnderecoDTO> enderecos)
        {
            Codigo = cliente.Codigo;
            Nome = cliente.Nome;
            TipoCliente = cliente.TipoCliente;
            Documento = cliente.Documento;
            DtInclusao = cliente.DtInclusao;
            Contatos = contatos;
            Enderecos = enderecos;
        }

        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public int TipoCliente { get; set; }
        public string Documento { get; set; }
        public DateTime DtInclusao { get; set; }
        public IEnumerable<ContatoDTO> Contatos { get; set; }
        public IEnumerable<EnderecoDTO> Enderecos { get; set; }

        public static CreateClienteCommandResponse EntityToResponse(Domain.Entities.Cliente cliente, IEnumerable<ContatoDTO> contatos, IEnumerable<EnderecoDTO> enderecos) => new(cliente, contatos, enderecos);
    }
}
