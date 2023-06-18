using FluentAssertions;
using SpecificationPatternRepository.Core.Types;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class SpecificationBuilder_Include
    {
        [Fact]
        public void AddsNothingToList_GivenNoIncludeExpression()
        {
            // arrange
            StoreEmptySpec spec = new StoreEmptySpec();

            // assert
            spec.IncludeClauses.Should().BeEmpty();
        }

        [Fact]
        public void AddsIncludeExpressionInfoToListWithTypeInclude_GivenIncludeExpression()
        {
            // arrange
            StoreIncludeAddressSpec spec = new StoreIncludeAddressSpec();

            // assert
            spec.IncludeClauses.Should().ContainSingle();
            spec.IncludeClauses.Single().Type.Should().Be(IncludeTypeEnum.Include);
        }
    }
}
