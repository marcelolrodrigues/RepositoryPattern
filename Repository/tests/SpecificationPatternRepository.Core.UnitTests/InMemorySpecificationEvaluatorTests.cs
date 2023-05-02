using FluentAssertions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities.Seeds;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests
{
    public class InMemorySpecificationEvaluatorTests
    {
        [Fact]
        public void ReturnsStoreWithId10_GivenStoreByIdSpec()
        {
            // arrenge
            StoreByIdSpec spec = new StoreByIdSpec(10);
            List<Store> stores = StoreSeed.Get();
            
            // act
            Store? store = spec.Evaluate(stores).FirstOrDefault();
            
            // assert
            store?.Id.Should().Be(10);
        }

        [Fact]
        public void ReturnsStoresWithIdFrom15To30_GivenStoresByIdListSpec()
        {
            // arrange
            IEnumerable<int> ids = Enumerable.Range(15, 16);
            StoreByIdListSpec spec = new StoreByIdListSpec(ids);
            
            // act
            IEnumerable<Store> stores = spec.Evaluate(StoreSeed.Get());
            
            // assert
            stores.Count().Should().Be(16);
            stores.OrderBy(x => x.Id).First().Id.Equals(15);
            stores.OrderBy(x => x.Id).Last().Id.Should().Be(30);
        }

        [Fact]
        public void ReturnsSecondPageOfStoreNames_GivenStoreNamesPaginatedSpec()
        {
            // arrange
            int pageSize = 10;
            int pageNumber = 2;
            int skip = (pageNumber - 1) * pageSize;
            int take = pageSize;
            StoreNamesPaginatedSpec spec = new StoreNamesPaginatedSpec(skip, take);
            IEnumerable<Store> repo = StoreSeed.Get();

            // act
            IEnumerable<string> result = spec.Evaluate(repo);

            // assert
            result.Count().Should().Be(take);
            result.First().Should().Be("Store 11");
            result.Last().Should().Be("Store 20");
        }

        [Fact]
        public void ReturnsSecondPageOfStores_GivenStoresPaginatedSpec()
        {

        }
    }
}