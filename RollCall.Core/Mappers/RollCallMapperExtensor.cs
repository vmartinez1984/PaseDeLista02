using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace RollCall.Core.Mappers
{
    public static class RollCallMapperExtensor
    {
        public static void AddMappers(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<RollCallMapper>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
