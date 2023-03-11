namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Entities.Seeds
{
    public class StoreSeed
    {
        public static List<Store> Get()
        {
            var stores = new List<Store>();

            for (int i = 1; i <= 50; i++)
            {
                stores.Add(new Store()
                {
                    Id = i,
                    Name = $"Store {i}",
                    City = $"City {i}",
                    AddressId = i,
                    CompanyId = 1,
                });
            }
            for (int i = 51; i <= 100; i++)
            {
                stores.Add(new Store()
                {
                    Id = i,
                    Name = $"Store {i}",
                    City = $"City {i}",
                    AddressId = i,
                    CompanyId = 2,
                });
            }

            stores[49 - 1].Name = "ZZZ";
            stores[48 - 1].Name = "AAA";
            stores[99 - 1].Name = "YYY";
            stores[98 - 1].Name = "BBB";

            stores[100 - 1].Name = "Store 999";

            stores[50 - 1].City = "ABCDEFGH";
            stores[50 - 1].Name = "ABCEFGH";

            return stores;
        }
    }
}
