using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreByIdSpec : BaseSpecification<Store>
    {
        public StoreByIdSpec(int id)
        {
            SpecificationBuilder.Where(sto => sto.Id == id);
        }
    }
}
