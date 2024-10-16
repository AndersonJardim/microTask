using Microsoft.Extensions.DependencyInjection;
using MicroTask.Application.Service;
using MicroTask.Domain.Interfaces;

namespace MicroTask.Application.DependencyInjection
{
    public static class ApplicationAdapterDependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection service)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));
            
            service.AddTransient<IProdutosGeral, ProdutosService>();

            return service;
        }
    }
}
