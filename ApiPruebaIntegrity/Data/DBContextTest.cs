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
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<PayForm> PayForms { get; set; }
        public DbSet<InvoicePayForm> InvoicePayForm { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<InvoiceSequence> InvoiceSequences { get; set; }
        public DbSet<Template> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(u => u.FullName)
                .HasDatabaseName("IX_User_FullName");

            modelBuilder.Entity<Product>()
               .HasIndex(u => u.Code)
               .HasDatabaseName("IX_Product_Code");

            modelBuilder.Entity<Product>()
               .HasIndex(u => u.Description)
               .HasDatabaseName("IX_Product_Description");


            modelBuilder.Entity<Invoice>()
               .HasIndex(u => u.InvoiceNumber)
               .HasDatabaseName("IX_Invoice_InvoiceNumber");

            modelBuilder.Entity<Invoice>()
               .HasIndex(u => u.FullNameCustomer)
               .HasDatabaseName("IX_Invoice_FullNameCustomer");


            modelBuilder.Entity<Invoice>()
               .HasIndex(u => u.Total)
               .HasDatabaseName("IX_Invoice_Total");

            modelBuilder.Entity<Invoice>()
               .HasIndex(u => u.CreateAt)
               .HasDatabaseName("IX_Invoice_CreateAt");

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Company)
                .WithMany()
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(c => c.Company)
                .WithMany()
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
