using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Lab_11_AragonGustavo.Configuration;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), 
                typeof(Lab_11_AragonGustavo.Application.UseCases.Tickets.Commands.AddTicketCommand).Assembly));

        return services;
    }
}