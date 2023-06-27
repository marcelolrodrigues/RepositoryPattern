using FluentAssertions;
using SpecificationPatternRepository.Core.Evaluator;

namespace SpecificationPatternRepository.Core.UnitTests.EvaluatorsTests
{
    public class InMemoryEvaluatorTests_Like
    {
        public static List<Person> Data = new List<Person>
        {
            new Person("James"),
            new Person("Robert"),
            new Person("Mary"),
            new Person("Linda"),
            new Person("Michael"),
            new Person("David"),
        };

        [Theory]
        [InlineData("%mes", 1)]
        [InlineData("%r%", 2)]
        [InlineData("_inda", 1)]
        [InlineData("M%", 2)]
        [InlineData("[RM]%", 3)]
        [InlineData("_[IA]%", 5)]
        public void ReturnsFilteredList_GivenSearchExpression(string likeTerm, int expectedCount)
        {
            IEnumerable<Person> result = LikeEvaluator.Instance.Evaluate(
                Data, new PersonSpecification(likeTerm)
            );

            result.Should().HaveCount(expectedCount);
        }
    }

    public class PersonSpecification : BaseSpecification<Person>
    {
        public PersonSpecification(string searchTerm)
        {
            SpecificationBuilder.Like(x => x.Name, searchTerm);
        }
    }

    public class Person
    {
        public string Name { get; }

        public Person(string name)
        {
            Name = name;
        }
    }
}
