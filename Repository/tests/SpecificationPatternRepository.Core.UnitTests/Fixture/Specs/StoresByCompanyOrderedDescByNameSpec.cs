using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresByCompanyOrderedDescByNameSpec : BaseSpecification<Store>
    {
        public StoresByCompanyOrderedDescByNameSpec(int companyId)
        {
            SpecificationBuilder.Where(str => str.CompanyId == companyId)
                .OrderByDescending(str => str.Name);
        }
    }
}
