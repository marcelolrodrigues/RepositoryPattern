using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreSearchByNameSpec : BaseSpecification<Store>
    {
        public StoreSearchByNameSpec(string searchTerm)
        {
            SpecificationBuilder.Like(
                store => store.Name,
                searchTerm = '%' + searchTerm + '%'
            );
        }
    }
}