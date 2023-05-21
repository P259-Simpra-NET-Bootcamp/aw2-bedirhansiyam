using Aw2.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aw2.Service.RestExtensions;

public static class DbContextExtension
{
    public static void AddDbContextExtension(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfig = configuration.GetConnectionString("MsSqlConnection");
        services.AddDbContext<Aw2DbContext>(opts =>
        opts.UseSqlServer(dbConfig));
    }
}
