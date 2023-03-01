using Microsoft.Extensions.DependencyInjection;
using RollCall.Core.Interfaces;

namespace CodigosPostales.Repositories
{
    public static class CodigosPostalesExtensor
    {
        public static void AddCodigosPostalesRepository(this IServiceCollection services)
        { 
            services.AddScoped<ICodigosPostalesRepository,CodigoPostalRepository>();
        }
    }
}