using Microsoft.Extensions.DependencyInjection;
using MiniERP.Domain.Repositories;
using MiniERP.Infra.Persistence.Repositories;

namespace MiniERP.CrossCutting.DI
{
    public static class APIDI
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IContatoRepository, ContatoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
        }
    }
}
