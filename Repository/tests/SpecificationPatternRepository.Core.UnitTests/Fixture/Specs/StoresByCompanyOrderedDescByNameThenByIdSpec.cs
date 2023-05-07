using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresByCompanyOrderedDescByNameThenByIdSpec : BaseSpecification<Store>
    {
        public StoresByCompanyOrderedDescByNameThenByIdSpec(int companyId)
        {
            SpecificationBuilder.Where(store => store.CompanyId == companyId)
                .OrderByDescending(store => store.Name)
                .ThenBy(store => store.Id);
        }
    }
}
