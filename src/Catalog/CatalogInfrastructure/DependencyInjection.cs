﻿using CatalogApplication.Contracts;
using CatalogInfrastructure.Persistence;
using CatalogInfrastructure.Repositories;
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
    }
}
