using Microsoft.OpenApi.Models;

namespace Aw2.Service.RestExtensions;

public static class CustomSwaggerExtension
{
    public static void AddCustomSwaggerExtension(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aw2 Api Management", Version = "v1.0" });
        });
    }
}
