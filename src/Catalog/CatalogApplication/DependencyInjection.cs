using CatalogApplication.DTOs;
using Microsoft.Extensions.DependencyInjection;

using FluentValidation;
namespace CatalogApplication;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(opt => {
            opt.RegisterServicesFromAssembly(typeof(CatalogItemDTO).Assembly);
        });
        services.AddValidatorsFromAssembly(typeof(CatalogItemDTO).Assembly);
        services.AddAutoMapper(typeof(CatalogItemDTO).Assembly);
    }
}
