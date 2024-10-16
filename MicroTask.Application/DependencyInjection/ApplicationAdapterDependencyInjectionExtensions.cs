using Microsoft.Extensions.DependencyInjection;
using MicroTask.Application.Service;

namespace MicroTask.Application.DependencyInjection
{
    public static class ApplicationAdapterDependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection service)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));
            
            service.AddTransient<ProdutosService>();

            return service;
        }
    }
}
