using BaseRepository.Infrastructure;
using SpecificationPatternRepository.Core.UnitTests.Fixture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPatternRepository.Infrastructure.IntegrationTests.Fixture
{
    public class IntegrationTestBase
    {
        public TestDbContext context { get; set; }
        protected BaseRepository<Store> StoreRepository;
        protected BaseRepository<Address> AddressRepository;

        public IntegrationTestBase(SharedDatabaseFixture fixture, ISpec)
        {

        }
    }
}
