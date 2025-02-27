using Microsoft.Extensions.Configuration;
using MiniERP.Domain.Repositories;
using MiniERP.Infra.Persistence.Repositories.Base;

namespace MiniERP.Infra.Persistence.Repositories;

public class EnderecoRepository(IConfiguration configuration) : DapperBaseRepository(configuration.GetConnectionString("MiniERP")!), IEnderecoRepository
{
}
