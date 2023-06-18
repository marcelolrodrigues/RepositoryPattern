using Core.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreIncludeAddressSpec : BaseSpecification<Store>
    {
        public StoreIncludeAddressSpec()
        {
            SpecificationBuilder.Include<Store, string>(store => store.Address);
        }
    }
}
