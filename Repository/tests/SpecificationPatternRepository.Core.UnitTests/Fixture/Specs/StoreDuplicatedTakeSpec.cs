using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreDuplicateTakeSpec : BaseSpecification<Store>
    {
        public StoreDuplicateTakeSpec()
        {
            SpecificationBuilder.Take(1).Take(2);
        }
    }
}
