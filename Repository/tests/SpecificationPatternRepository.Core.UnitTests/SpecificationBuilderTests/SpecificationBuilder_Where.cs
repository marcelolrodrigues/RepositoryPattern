using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.SpecificationBuilderTests
{
    public class SpecificationBuilder_Where
    {
        [Fact]
        public void AddsNothingToList_GivenNoWhereExpression()
        {
            // arrange
            StoreEmptySpec spec = new StoreEmptySpec();

            // assert
            spec.WhereClauses.Should().BeEmpty();
        }

        // Não entendi o propósito deste teste
        //[Fact]
        //public void AddsNothingToList_GivenWhereExpressionWithFalseCondition()
        //{
        //    var spec = new CompanyByIdWithFalseConditions(1);

        //    spec.WhereExpressions.Should().BeEmpty();
        //}

        [Fact]
        public void AddsOneExpressionToList_GivenOneWhereExpression()
        {
            // arrange
            StoreByIdSpec spec = new StoreByIdSpec(1);

            // assert
            spec.WhereClauses.Should().ContainSingle();
        }

        [Fact]
        public void AddsTwoExpressionsToList_GivenTwoWhereExpressions()
        {
            // arrange
            StoreByIdAndNameSpec spec = new StoreByIdAndNameSpec(1, "name");

            // assert
            spec.WhereClauses.Should().HaveCount(2);
        }
    }
}