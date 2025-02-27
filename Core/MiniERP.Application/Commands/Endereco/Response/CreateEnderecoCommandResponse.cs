namespace MiniERP.Application.Commands.Endereco.Response
{
    public class CreateEnderecoCommandResponse
    {
        private CreateEnderecoCommandResponse(Domain.Entities.Endereco endereco)
        {
            Id = endereco.Id;
            Codigo = endereco.Codigo;
            CodigoCliente = endereco.CodigoCliente;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Cidade = endereco.Cidade;
            Estado = endereco.Estado;
            CEP = endereco.CEP;
            DtInclusao = endereco.DtInclusao;
        }

        public int Id { get; set; }
        public Guid Codigo { get; set; }
        public Guid CodigoCliente { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public DateTime DtInclusao { get; set; }

        public static CreateEnderecoCommandResponse EntityToResponse(Domain.Entities.Endereco endereco) => new(endereco);
    }
}
