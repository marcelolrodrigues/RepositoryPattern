using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreSearchByNameOrCitySpec : BaseSpecification<Store>
    {
        public StoreSearchByNameOrCitySpec(string searchTerm)
        {
            SpecificationBuilder.Like(x => x.Name!, "%" + searchTerm + "%")
                .Like(x => x.City!, "%" + searchTerm + "%");
        }
    }
}