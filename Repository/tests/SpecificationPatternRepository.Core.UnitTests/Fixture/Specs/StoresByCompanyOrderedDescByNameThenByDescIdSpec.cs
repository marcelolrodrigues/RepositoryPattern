using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresByCompanyOrderedDescByNameThenByDescIdSpec : BaseSpecification<Store>
    {
        public StoresByCompanyOrderedDescByNameThenByDescIdSpec(int companyId)
        {
            SpecificationBuilder.Where(store => store.CompanyId == companyId)
                .OrderByDescending(store => store.Name)
                .ThenByDescending(store => store.Id);
        }
    }
}
