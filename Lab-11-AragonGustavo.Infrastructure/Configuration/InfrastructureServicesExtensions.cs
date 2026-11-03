using Lab_11_AragonGustavo.Application.Port.Services;
using Lab_11_AragonGustavo.Domain.Repositories;
using Lab_11_AragonGustavo.Infrastructure.Context;
using Lab_11_AragonGustavo.Infrastructure.Repositories;
using Lab_11_AragonGustavo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab_11_AragonGustavo.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DataBase Connection
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString);
        });

        // ServicesRegister
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}