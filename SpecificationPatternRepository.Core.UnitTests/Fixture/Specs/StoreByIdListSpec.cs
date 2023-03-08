using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreByIdListSpec : BaseSpecification<Store>
    {
        public StoreByIdListSpec(IEnumerable<int> ids)
        {
            SpecificationBuilder.Where(sto => ids.Contains(sto.Id));
        }
    }
}
