using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Demo.FunctionApp.EntityFrameworkContext
{
    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            const string connectionString =
                "Server=127.0.0.1;Port=5432;Database=school;User Id=school;Password=postgres;";
            var optionsBuilder =
                new DbContextOptionsBuilder<SchoolContext>()
                    .UseNpgsql(connectionString!);

            return new SchoolContext(optionsBuilder.Options);
        }
    }
}
