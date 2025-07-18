using Microsoft.Extensions.DependencyInjection;

namespace DANIEL.Producto.Common
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
