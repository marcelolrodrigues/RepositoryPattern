using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresOrderedDescendingByNameSpec : BaseSpecification<Store>
    {
        public StoresOrderedDescendingByNameSpec()
        {
            SpecificationBuilder.OrderByDescending(store => store.Name);
        }
    }
}
