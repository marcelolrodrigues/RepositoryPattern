using FluentAssertions;
using SpecificationPatternRepository.Core.Exceptions;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities.Seeds;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Specs;

namespace SpecificationPatternRepository.Core.UnitTests.EvaluatorsTests
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
            // arrange
            int page = 2;
            int pageSize = 10;
            int skip = pageSize * (page - 1);
            int take = pageSize;
            StoresPaginatedSpec spec = new StoresPaginatedSpec(skip, take);

            // act
            IEnumerable<Store> stores = spec.Evaluate(StoreSeed.Get());

            // assert
            stores.Count().Should().Be(take);
            stores.OrderBy(x => x.Id).First().Id.Should().Be(11);
            stores.OrderBy(x => x.Id).Last().Id.Should().Be(20);
        }

        [Fact]
        public void ReturnsOrderStoresByNameDescForCompanyWithId2_GivenStoresByCompanyOrderedDescByNameSpec()
        {
            // arrange
            StoresByCompanyOrderedDescByNameSpec spec = new StoresByCompanyOrderedDescByNameSpec(2);

            // act
            IEnumerable<Store> stores = spec.Evaluate(StoreSeed.Get());

            // assert
            stores.First().Id.Should().Be(StoreSeed.ORDERED_BY_NAME_DESC_FOR_COMPANY2_FIRST_ID);
            stores.Last().Id.Should().Be(StoreSeed.ORDERED_BY_NAME_DESC_FOR_COMPANY2_LAST_ID);
        }

        [Fact]
        public void ReturnsOrderStoresByNameDescThenByIdForCompanyWithId2_GivenStoresByCompanyOrderedDescByNameThenByIdSpec()
        {
            // arrange 
            StoresByCompanyOrderedDescByNameThenByIdSpec specification =
                new StoresByCompanyOrderedDescByNameThenByIdSpec(2);

            // act
            IEnumerable<Store> stores = specification.Evaluate(StoreSeed.Get());

            // assert
            stores.First().Id.Should().Be(99);
            stores.Last().Id.Should().Be(98);
        }

        [Fact]
        public void ReturnsSecondPageOfStoresForCompanyWithId2_GivenStoresByCompanyPaginatedOrderedDescByNameSpec()
        {
            // arrange
            int pageNumber = 2;
            int pageSize = 10;
            int skip = pageSize * (pageNumber - 1);
            int take = pageSize;
            StoresByCompanyPaginatedOrderedDescByNameSpec specification =
                new StoresByCompanyPaginatedOrderedDescByNameSpec(2, skip, take);

            // act
            IEnumerable<Store> stores = specification.Evaluate(StoreSeed.Get());

            // assert
            stores.Count().Should().Be(take);
            stores.First().Id.Should().Be(StoreSeed.ORDERED_BY_NAME_DESC_FOR_COMPANY2_PAGE2_FIRST_ID);
            stores.Last().Id.Should().Be(StoreSeed.ORDERED_BY_NAME_DESC_FOR_COMPANY2_PAGE2_LAST_ID);
        }

        [Fact]
        public void ReturnsSecondPageOfStoresForCompanyWithId2_GivenStoresByCompanyPaginatedSpec()
        {
            // arrange
            int pageNumber = 2;
            int pageSize = 10;
            int skip = pageSize * (pageNumber - 1);
            int take = pageSize;
            StoresByCompanyPaginatedSpec specification =
                new StoresByCompanyPaginatedSpec(2, skip, take);

            // act
            IEnumerable<Store> stores = specification.Evaluate(StoreSeed.Get());

            // assert
            stores.Count().Should().Be(take);
            stores.OrderBy(x => x.Id).First().Id.Should().Be(61);
            stores.OrderBy(x => x.Id).Last().Id.Should().Be(70);
        }

        [Fact]
        public void ReturnsOrderedStores_GivenStoresOrderedSpecByName()
        {
            // arrange
            StoresOrderedSpecByName specification =
                new StoresOrderedSpecByName();

            // act
            IEnumerable<Store> stores = specification.Evaluate(StoreSeed.Get());

            // assert
            stores.First().Id.Should().Be(StoreSeed.ORDERED_BY_NAME_FIRST_ID);
            stores.Last().Id.Should().Be(StoreSeed.ORDERED_BY_NAME_LAST_ID);
        }

        [Fact]
        public void ReturnsOrderedStores_GivenStoresOrderedDescendingByNameSpec()
        {
            // arrange
            StoresOrderedDescendingByNameSpec specification =
                new StoresOrderedDescendingByNameSpec();

            // act
            IEnumerable<Store> stores = specification.Evaluate(StoreSeed.Get());

            // assert
            stores.First().Id.Should().Be(StoreSeed.ORDERED_BY_NAME_DESC_FIRST_ID);
            stores.Last().Id.Should().Be(StoreSeed.ORDERED_BY_NAME_DESC_LAST_ID);
        }

        [Fact]
        public void ThrowsDuplicateOrderChainException_GivenSpecWithMultipleOrderChains()
        {
            // arrange
            StoresOrderedTwoChainsSpec spec = new StoresOrderedTwoChainsSpec();

            // act
            Action sutAction = () => spec.Evaluate(StoreSeed.Get());

            // assert
            sutAction.Should()
                .Throw<DuplicateOrderChainException>()
                .WithMessage("The specification contains more than one Order chain!");
        }
    }
}