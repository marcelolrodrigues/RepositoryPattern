using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreNamesSpec : BaseSpecification<Store, string>
    {
        public StoreNamesSpec() 
        {
            SpecificationBuilder.Select(store => store.Name);
        }
    }
}
