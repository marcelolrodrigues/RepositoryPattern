using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreByIdAndNameSpec : BaseSpecification<Store>
    {
        public StoreByIdAndNameSpec(int storeId, string name)
        {
            SpecificationBuilder.Where(store => store.Id == storeId)
                .Where(store => store.Name == name);
        }
    }
}
