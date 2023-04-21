using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreNamesPaginatedSpec : BaseSpecification<Store>
    {
        public StoreNamesPaginatedSpec(int skip, int take)
        {
            SpecificationBuilder.Skip(skip).Take(take);
        }
    }
}
