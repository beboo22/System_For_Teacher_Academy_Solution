using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ApplyInfrastructureService
    {

        public static void applayInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            //how call it in program.cs
            //services.applayInfrastructureService(configuration);

            //connect to the database
            services.AddDbContext<ReadSystemDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<WriteSystemDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Register other infrastructure services here
            // e.g., services.AddScoped<IRepository, Repository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            //services.AddScoped<IAuthentication, Authentication>();
            //services.AddScoped<IIdentityRepo, IdentityRepo>();
            //services.AddScoped<IEmailService, EmailService>();
        }

    }
}
