namespace SpecificationPatternRepository.Core.UnitTests.Fixture.Entities.Seeds
{
    public class AddressSeed
    {
        public static List<Address> Get()
        {
            List<Address> addresses = new List<Address>();

            for (int i = 1; i <= 100; i++)
            {
                addresses.Add(new Address()
                {
                    Id = i,
                    Street = $"Street {i}",
                    StoreId = i
                });
            }

            return addresses;
        }
    }
}
