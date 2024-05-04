using CatalogApplication.Contracts;
using CatalogInfrastructure.Contracts;
using CatalogInfrastructure.Persistence;
using CatalogInfrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogInfrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config) 
    {
        services.AddDbContext<CatalogDbContext>(opt => 
        {
            opt.UseNpgsql(config.GetConnectionString("default"));
        });
        services.AddScoped<ICatalogRepository, CatalogRepository>();
        services.AddScoped<IFileUploader, FileUploader>();
        services.AddMassTransit(conf =>
        {
            conf.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("catalog"));
            conf.UsingRabbitMq((cnt, configurator) =>
            {
                configurator.Host("localhost", "/", c =>
                {
                    c.Username("guest");
                    c.Password("guest");
                });
                configurator.ConfigureEndpoints(cnt);
                
            });
            
        });
    }
}
