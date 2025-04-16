using ApiPruebaIntegrity.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaIntegrity.Data
{
    public class DBContextTest:DbContext
    {
        public DBContextTest(DbContextOptions<DBContextTest> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
