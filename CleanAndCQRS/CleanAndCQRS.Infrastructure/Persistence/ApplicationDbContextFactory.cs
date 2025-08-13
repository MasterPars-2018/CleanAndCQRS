using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace CleanAndCQRS.Infrastructure.Persistence;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=CleanDb;Integrated Security=True;Encrypt=False");

        return new ApplicationDbContext(optionBuilder.Options);
    }
}
