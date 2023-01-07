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
    }
}
