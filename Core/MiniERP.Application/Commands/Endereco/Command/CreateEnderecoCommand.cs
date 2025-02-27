using MiniERP.Application.Commands.Endereco.Response;
using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Endereco.Command
{
    public class CreateEnderecoCommand : IDomainCommand<CreateEnderecoCommandResponse>
    {
        public  Guid CodigoCliente { get; set; }
        public  string Logradouro { get; set; }
        public  string Numero { get; set; }
        public string? Complemento { get; set; }
        public  string Bairro { get; set; }
        public  string Cidade { get; set; }
        public  string Estado { get; set; }
        public  string CEP { get; set; }
    }
}
