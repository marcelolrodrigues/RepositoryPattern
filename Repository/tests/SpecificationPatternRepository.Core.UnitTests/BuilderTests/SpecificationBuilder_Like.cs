using FluentAssertions;
using SpecificationPatternRepository.Core.Clauses;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.BuilderTests
{
    public class SpecificationBuilder_Like
    {
        [Fact]
        public void AddsNothingToList_GivenNoWhereExpression()
        {
            // arrange
            var spec = new StoreEmptySpec();

            // assert
            spec.LikeClauses.Should().BeEmpty();
        }

        //[Fact]
        //public void AddsNothingToList_GivenSearchExpressionWithFalseCondition()
        //{
        //    var spec = new CompanyByIdWithFalseConditions(1);

        //    spec.SearchCriterias.Should().BeEmpty();
        //}

        [Fact]
        public void AddsOneCriteriaWithDefaultGroupToList_GivenOneSearchExpressionWithNoGroup()
        {
            // arrange
            StoreSearchByNameSpec spec = new StoreSearchByNameSpec("test");

            // assert
            spec.LikeClauses.Should().ContainSingle();
            spec.LikeClauses.Single().LikeTerm.Should().Be("%test%");
            spec.LikeClauses.Single().LikeGroup.Should().Be(1);
        }

        [Fact]
        public void AddsTwoCriteriaWithSameGroupToList_GivenTwoSearchExpressionWithNoGroup()
        {
            // arrange
            var spec = new StoreSearchByNameOrCitySpec("test");

            // assert
            List<LikeClause<Store>> criterias = spec.LikeClauses.ToList();
            criterias.Should().HaveCount(2);
            criterias.ForEach(x => x.LikeTerm.Should().Be("%test%"));
            criterias.ForEach(x => x.LikeGroup.Should().Be(1));
        }

        [Fact]
        public void AddsTwoCriteriaWithDifferentGroupToList_GivenTwoSearchExpressionWithDistinctGroup()
        {
            // arrange
            StoreSearchByNameAndCitySpec spec = new StoreSearchByNameAndCitySpec("test");

            // assert
            List<LikeClause<Store>> criterias = spec.LikeClauses.ToList();
            criterias.Should().HaveCount(2);
            criterias.ForEach(x => x.LikeTerm.Should().Be("%test%"));
            criterias[0].LikeGroup.Should().Be(1);
            criterias[1].LikeGroup.Should().Be(2);
        }
    }
}
