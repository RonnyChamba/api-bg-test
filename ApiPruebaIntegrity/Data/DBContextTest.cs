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
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(u => u.FullName)
                .HasDatabaseName("IX_User_FullName");

            base.OnModelCreating(modelBuilder);
        }
    }
}
