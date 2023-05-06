using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoresPaginatedSpec : BaseSpecification<Store>
    {
        public StoresPaginatedSpec(int skip, int take)
        {
            SpecificationBuilder.Skip(skip)
                .Take(take)
                .OrderBy(store => store.Id);
        }
    }
}
