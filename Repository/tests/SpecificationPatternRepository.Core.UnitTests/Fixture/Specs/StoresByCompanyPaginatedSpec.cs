using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresByCompanyPaginatedSpec : BaseSpecification<Store>
    {
        public StoresByCompanyPaginatedSpec(int companyId, int skip, int take)
        {
            SpecificationBuilder.Where(store => store.CompanyId == companyId)
                .OrderBy(store => store.CompanyId)
                .Skip(skip).Take(take);
        }
    }
}
