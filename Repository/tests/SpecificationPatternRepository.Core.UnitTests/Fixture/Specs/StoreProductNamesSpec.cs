using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;

namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Specs
{
    public class StoreProductNamesSpec : BaseSpecification<Store, string?>
    {
        public StoreProductNamesSpec()
        {
            SpecificationBuilder.SelectMany(
                store => store.Products.Select(product => product.Name)
            );
        }
    }
}
