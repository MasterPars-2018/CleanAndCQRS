using Microsoft.Extensions.DependencyInjection;

namespace CleanAndCQRS.Application;


public static class DependencyInjection
{

    public static IServiceCollection RegisterApplicationService(this IServiceCollection services)
    {

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);

        });

        return services;
    }

}