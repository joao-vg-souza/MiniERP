using MiniERP.Infra.Bus.Contracts;

namespace MiniERP.Application.Commands.Endereco.Command
{
    public class UpdateEnderecoCommand : IDomainCommand<MediatR.Unit>
    {
        public  Guid CodigoEndereco { get; set; }
        public  string Logradouro { get; set; }
        public  string Numero { get; set; }
        public string? Complemento { get; set; }
        public  string Bairro { get; set; }
        public  string Cidade { get; set; }
        public  string Estado { get; set; }
        public  string CEP { get; set; }
    }
}
