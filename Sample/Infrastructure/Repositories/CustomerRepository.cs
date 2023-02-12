using Core.Entities;
using Core.Interfaces.Repositories;
using SpecificationRepository.Infrastructure;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : SpecificationRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SampleContext dbContext) : base(dbContext)
        {
        }
    }
}