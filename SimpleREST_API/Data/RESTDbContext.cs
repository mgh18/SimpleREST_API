using Microsoft.EntityFrameworkCore;

namespace SimpleREST_API.Data
{
    public class RESTDbContext:DbContext
    {
        public RESTDbContext(DbContextOptions<RESTDbContext> options):base(options)
        {

        }
        public DbSet<UsersTbl> UsersTbl { get; set; }
    }
}
