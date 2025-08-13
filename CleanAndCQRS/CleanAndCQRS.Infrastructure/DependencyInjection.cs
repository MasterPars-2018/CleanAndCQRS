using CleanAndCQRS.Domain;
using CleanAndCQRS.Domain.Domains.Todos;
using CleanAndCQRS.Infrastructure.Domains.ToDo;
using CleanAndCQRS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanAndCQRS.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
   
        services.AddScoped<IToDoRepository, ToDoRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));

        });

        return services;
    }

}
