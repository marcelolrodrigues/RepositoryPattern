using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresOrderedSpecByName : BaseSpecification<Store>
    {
        public StoresOrderedSpecByName()
        {
            SpecificationBuilder.OrderBy(store => store.Name);
        }
    }
}
