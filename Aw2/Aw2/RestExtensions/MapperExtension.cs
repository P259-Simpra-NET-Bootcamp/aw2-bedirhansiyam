using AutoMapper;
using Aw2.Schema;

namespace Aw2.Service.RestExtensions;

public static class MapperExtension
{
    public static void AddMapperExtension(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperProfile());
        });
        services.AddSingleton(config.CreateMapper());
    }
}
