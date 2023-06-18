using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class SpecificationBuilder_SelectManyTests
    {
        [Fact]
        public void SetsNothing_GivenNoSelectManyExpression()
        {
            // arrange
            StoreProductNamesEmptySpec spec = new StoreProductNamesEmptySpec();

            // assert 
            spec.SelectManyClause.Should().BeNull();
        }

        [Fact]
        public void SetsSelectorMany_GivenSelectManyExpression()
        {
            // arrange
            StoreProductNamesSpec spec = new StoreProductNamesSpec();

            // assert
            spec.SelectManyClause.Should().NotBeNull();
        }
    }
}
