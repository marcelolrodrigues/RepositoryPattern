using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SampleContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Stores)
                .WithOne()
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
