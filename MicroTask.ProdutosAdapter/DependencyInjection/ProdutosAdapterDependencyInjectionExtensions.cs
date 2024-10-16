using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroTask.Domain.Adapters;
using MicroTask.ProdutosAdapter.Service;
using Refit;

namespace MicroTask.ProdutosAdapter.DependencyInjection
{
    public static class ProdutosAdapterDependencyInjectionExtensions
    {
        public static IServiceCollection AddProdutosAdapter(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));

            service.AddRefitClient<IProdutosAdapter>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(configuration.GetConnectionString("UrlProdutosAdapter"));
                });

            service.AddTransient<IProdutosAdapterCore, ProdutosAdapter>();

            return service;
        }
    }
}
