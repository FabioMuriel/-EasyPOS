using Aplication.Data;
using Domain.Customers;
using Domain.Primitives;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddScoped<IAplicationDbContext>(sp =>
            sp.GetRequiredService<AplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<AplicationDbContext>());

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}