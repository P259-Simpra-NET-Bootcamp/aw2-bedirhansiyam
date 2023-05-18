using Aw2.Data.Repository;

namespace Aw2.Service.RestExtensions;

public static class RepositoryExtension
{
    public static void AddRepositoryExtension(this IServiceCollection services)
    {
        services.AddScoped<IStaffRepository, StaffRepository>();
    }
}
