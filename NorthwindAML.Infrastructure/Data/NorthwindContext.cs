using Microsoft.EntityFrameworkCore;
using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Infrastructure.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<TransactionFlag> TransactionFlags { get; set; }
        public DbSet<CustomerRiskScore> CustomerRiskScores { get; set; }
        public DbSet<SARRecord> SARRecords { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Watchlist>().ToTable("Watchlist");
            modelBuilder.Entity<TransactionFlag>().ToTable("TransactionFlags");
            modelBuilder.Entity<CustomerRiskScore>().ToTable("CustomerRiskScore");
            modelBuilder.Entity<SARRecord>().ToTable("SARRecords");
            modelBuilder.Entity<AppUser>().ToTable("AppUsers").HasKey(u => u.UserID);
        }
    }
}