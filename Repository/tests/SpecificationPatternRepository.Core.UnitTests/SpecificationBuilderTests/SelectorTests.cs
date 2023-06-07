using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class SelectorTests
    {
        [Fact]
        public void SetsNothing_GivenNoSelectExpression()
        {
            StoreNamesEmptySpec spec = new StoreNamesEmptySpec();

            spec.SelectorClause.Should().BeNull();
        }

        [Fact]
        public void SetsSelector_GivenSelectExpression()
        {
            var spec = new StoreNamesSpec();

            spec.SelectorClause.Should().NotBeNull();
        }
    }
}
