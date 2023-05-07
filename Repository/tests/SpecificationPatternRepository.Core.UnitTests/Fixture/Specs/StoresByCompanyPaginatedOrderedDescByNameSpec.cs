using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresByCompanyPaginatedOrderedDescByNameSpec : BaseSpecification<Store>
    {
        public StoresByCompanyPaginatedOrderedDescByNameSpec(int companyId, int skip, int take)
        {
            SpecificationBuilder.Where(store => store.CompanyId == companyId)
                .OrderByDescending(store => store.Name)
                .Skip(skip).Take(take);
        }
    }
}
