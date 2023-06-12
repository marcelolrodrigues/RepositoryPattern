using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities.Seeds;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.EvaluatorsTests
{
    public class InMemoryEvaluatorTests_Select
    {
        [Fact]
        public void ReturnsListOfNames_GivenStores()
        {
            // arrange
            IEnumerable<Store> repo = StoreSeed.Get();
            StoreNamesSpec spec = new StoreNamesSpec();

            // act
            IEnumerable<string> result = spec.EvaluateInMemory(repo);

            // assert
            result.First().Should().Be("Store 1");
            result.Last().Should().Be("Store 999");
        }
    }
}
