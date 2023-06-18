using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class AsNoTrackingWithTrueCondition : BaseSpecification<Store>
    {
        public AsNoTrackingWithTrueCondition()
        {
            SpecificationBuilder.AsNoTracking(true);
        }
    }
}
