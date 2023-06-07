using FluentAssertions;
using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class OrderBy
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
        //    CompanyByIdWithFalseConditions spec = new CompanyByIdWithFalseConditions(1);

        //    spec.OrderExpressions.Should().BeEmpty();
        //}

        [Fact]
        public void AddsOrderExpressionToListWithOrderByType_GivenOrderByExpression()
        {
            // arrange
            StoresOrderedSpecByName spec = new StoresOrderedSpecByName();

            // assert
            spec.OrderByClauses.Should().ContainSingle();
            spec.OrderByClauses.Single().OrderType.Should().Be(OrderByType.OrderBy);
        }
    }
}
