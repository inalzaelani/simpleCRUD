using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MvcCoreTutorial.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {

        }
        public DbSet<Person> Person { get; set; }

        internal object Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}