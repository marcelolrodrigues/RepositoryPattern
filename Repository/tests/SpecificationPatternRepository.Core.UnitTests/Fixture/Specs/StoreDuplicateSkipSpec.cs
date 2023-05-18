using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreDuplicateSkipSpec : BaseSpecification<Store>
    {
        public StoreDuplicateSkipSpec()
        {
            SpecificationBuilder.Skip(1)
                .Skip(2);
        }
    }
}
