using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Aplication;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<AplicationAssemblyReference>();
        });

        services.AddValidatorsFromAssemblyContaining<AplicationAssemblyReference>();

        return services;
    }
}