using FluentAssertions;
using SpecificationPatternRepository.Core.Types;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class SpecificationBuilder_OrderByDescThenByDesc
    {
        [Fact]
        public void AppendsOrderExpressionToListWithThenByDescendingType_GivenThenByDescendingExpression()
        {
            StoresByCompanyOrderedDescByNameThenByDescIdSpec spec = 
                new StoresByCompanyOrderedDescByNameThenByDescIdSpec(1);

            spec.OrderByClauses.Should().HaveCount(2);
            spec.OrderByClauses.First().OrderType.Should().Be(OrderByType.OrderByDescending);
            spec.OrderByClauses.Last().OrderType.Should().Be(OrderByType.ThenByDescending);
        }
    }
}
