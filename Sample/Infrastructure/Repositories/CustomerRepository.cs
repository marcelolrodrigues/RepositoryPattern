using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.RepositoryPattern;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SampleContext dbContext) : base(dbContext)
        {
        }
    }
}