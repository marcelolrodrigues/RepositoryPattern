using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreNamesPaginatedSpec : BaseSpecification<Store, string>
    {
        public StoreNamesPaginatedSpec(int skip, int take)
        {
            SpecificationBuilder.OrderBy(strore => strore.Id)
                .Skip(skip)
                .Take(take);

            SpecificationBuilder.Select(store => store.Name);
        }
    }
}
