using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace SpecificationPatternRepository.Infrastructure.IntegrationTests.Fixture
{
    public class SharedDatabaseFixture
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized = false;
        //private const string ConnectionStringDocker = "Server=(localdb)\\mssqllocaldb;Integrated Security=SSPI;Initial Catalog=SpecificationEFTestsDB;ConnectRetryCount=0";
        private const string ConnectionStringDocker = "Data Source=databaseEFCore;Initial Catalog=SpecificationEFCoreTestsDB;PersistSecurityInfo=True;User ID=sa;Password=P@ssW0rd!;Encrypt=False";
        private DbConnection Connection;

        public SharedDatabaseFixture()
        {
            Connection = new SqlConnection(ConnectionStringDocker);
            Seed();
            Connection.Open();
        }

        public TestDbContext CreateContext(DbTransaction? transaction = null)
        {
            TestDbContext context = new TestDbContext(
                new DbContextOptionsBuilder<TestDbContext>().UseSqlServer(Connection).Options
            );
            if(transaction != null)
                context.Database.UseTransaction(transaction);
            return context;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (TestDbContext context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }
                    _databaseInitialized = true;
                }
            }
        }
    }
}
