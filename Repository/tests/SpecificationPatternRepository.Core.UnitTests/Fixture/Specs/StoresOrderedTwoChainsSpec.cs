using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresOrderedTwoChainsSpec : BaseSpecification<Store>
    {
        public StoresOrderedTwoChainsSpec()
        {
            SpecificationBuilder.OrderBy(x => x.Name)
                .OrderBy(x => x.Id);
        }
    }
}
