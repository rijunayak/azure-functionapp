using Demo.FunctionApp.School.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.FunctionApp.EntityFrameworkContext
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
