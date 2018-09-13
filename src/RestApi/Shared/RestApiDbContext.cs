using Microsoft.EntityFrameworkCore;
using RestApi.Features.Example;

namespace RestApi.Shared
{
    public class RestApiDbContext : DbContext
    {
        //TODO Add the entities that represent the data here!
        public DbSet<Employee> Employees { get; set; }

        public RestApiDbContext(DbContextOptions<RestApiDbContext> options) 
            : base(options) {}
    }
}