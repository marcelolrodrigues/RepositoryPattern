using Core.Entities;
using FluentAssertions;

namespace SpecificationPatternRepository.Core.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnsStoreWithId10_GivenStoreByIdSpec()
        {
            List<Customer> lista = new List<Customer>()
            {
                new Customer("marcelo1", "email", "address"),
                new Customer("marcelo2", "email", "address"),
                new Customer("marcelo3", "email", "address"),
                new Customer("marcelo4", "email", "address"),
            };
            var spec = new BaseSpecification<Customer>();
            spec.SpecificationBuilder.Where(x => x.Name == "marcelo3");
            var list = spec.InMemorySpecificationEvaluator
                .Evaluate(lista, spec);
            list.Count().Should().Be(1);
            list.First().Name.Should().Be("marcelo3");
        }
    }
}