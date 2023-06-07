using FluentAssertions;
using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class OrderByThenBy
    {
        [Fact]
        public void AppendOrderExpressionToListWithThenByType_GivenThenByExpression()
        {
            // arrange
            StoresByCompanyOrderedDescByNameThenByIdSpec spec = 
                new StoresByCompanyOrderedDescByNameThenByIdSpec(1);

            // assert
            spec.OrderByClauses.Should().HaveCount(2);
            spec.OrderByClauses.First().OrderType.Should().Be(OrderByType.OrderByDescending);
            spec.OrderByClauses.Last().OrderType.Should().Be(OrderByType.ThenBy);
        }
    }
}
