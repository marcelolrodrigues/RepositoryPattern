using FluentAssertions;
using SpecificationPatternRepository.Core.Types;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.BuilderTests
{
    public class SpecificationBuilder_OrderByDesc
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
