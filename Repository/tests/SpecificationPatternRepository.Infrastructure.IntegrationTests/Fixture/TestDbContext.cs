using Microsoft.EntityFrameworkCore;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities.Seeds;

namespace SpecificationPatternRepository.Infrastructure.IntegrationTests.Fixture
{
    public class TestDbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Store>()
                .HasOne(x => x.Address)
                .WithOne(x => x!.Store!)
                .HasForeignKey<Address>(x => x.StoreId);

            modelBuilder.Entity<Address>().HasData(AddressSeed.Get());
            modelBuilder.Entity<Store>().HasData(StoreSeed.Get());
        }
    }
}
