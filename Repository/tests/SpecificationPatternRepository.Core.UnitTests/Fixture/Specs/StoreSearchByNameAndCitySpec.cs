using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreSearchByNameAndCitySpec : BaseSpecification<Store>
    {
        public StoreSearchByNameAndCitySpec(string searchTerm)
        {
            SpecificationBuilder.Like(x => x.Name!, "%" + searchTerm + "%", 1)
                .Like(x => x.City!, "%" + searchTerm + "%", 2);
        }
    }
}