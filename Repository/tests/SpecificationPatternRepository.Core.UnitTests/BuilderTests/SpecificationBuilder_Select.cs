using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.BuilderTests
{
    public class SpecificationBuilder_Select
    {
        [Fact]
        public void SetsNothing_GivenNoSelectExpression()
        {
            StoreNamesEmptySpec spec = new StoreNamesEmptySpec();

            spec.SelectManyClause.Should().BeNull();
        }

        [Fact]
        public void SetsSelector_GivenSelectExpression()
        {
            var spec = new StoreNamesSpec();

            spec.SelectManyClause.Should().NotBeNull();
        }
    }
}
