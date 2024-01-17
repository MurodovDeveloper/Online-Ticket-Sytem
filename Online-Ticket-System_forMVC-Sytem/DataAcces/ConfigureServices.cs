using Microsoft.EntityFrameworkCore;

namespace Online_Ticket_System_forMVC_Sytem.DataAcces
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbConnect"));
                options.UseLazyLoadingProxies(); 
            });
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
       //  services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            return services;
        }
    }
}
