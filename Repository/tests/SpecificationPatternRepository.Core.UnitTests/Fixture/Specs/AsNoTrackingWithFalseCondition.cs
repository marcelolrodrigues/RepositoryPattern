using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class AsNoTrackingWithFalseCondition : BaseSpecification<Store>
    {
        public AsNoTrackingWithFalseCondition()
        {
            SpecificationBuilder.AsNoTracking(false);
        }
    }
}
