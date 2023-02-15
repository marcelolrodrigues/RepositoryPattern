using Core.Entities;
using Core.Interfaces.Repositories;
using SpecificationPatternRepository.Infrastructure;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : SpecificationRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SampleContext dbContext) : base(dbContext)
        {
        }
    }
}