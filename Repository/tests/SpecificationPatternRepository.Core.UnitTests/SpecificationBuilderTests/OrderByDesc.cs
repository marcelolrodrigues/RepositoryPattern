using FluentAssertions;
using SpecificationPatternRepository.Core.Expressions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class OrderByDesc
    {
        [Fact]
        public void AddsNothingToList_GivenNoOrderExpression()
        {
            // arrange
            StoreEmptySpec spec = new StoreEmptySpec();

            // assert
            spec.OrderByClauses.Should().BeEmpty();
        }

        //[Fact]
        //public void AddsNothingToList_GivenOrderExpressionWithFalseCondition()
        //{
        //    var spec = new CompanyByIdWithFalseConditions(1);

        //    spec.OrderExpressions.Should().BeEmpty();
        //}

        [Fact]
        public void AddsOrderExpressionToListWithOrderByDescendingType_GivenOrderByDescendingExpression()
        {
            // arrange
            StoresOrderedDescendingByNameSpec spec = new StoresOrderedDescendingByNameSpec();

            // assert
            spec.OrderByClauses.Should().ContainSingle();
            spec.OrderByClauses.Single().OrderType.Should().Be(OrderByType.OrderByDescending);
        }
    }
}
