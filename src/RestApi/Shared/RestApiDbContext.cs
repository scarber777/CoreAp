using Microsoft.EntityFrameworkCore;

namespace RestApi.Shared
{
    public class RestApiDbContext : DbContext
    {
        //TODO Add the entities that represent the data here!
        //public DbSet<Job> Jobs { get; set; }
        //public DbSet<Employee> Employees { get; set; }

        public RestApiDbContext(DbContextOptions<RestApiDbContext> options) 
            : base(options) {}
    }
}