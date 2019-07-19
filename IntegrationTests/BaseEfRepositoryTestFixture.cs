using Microsoft.EntityFrameworkCore;
using Persistence.EntityFrameworkDataAccess;

namespace IntegrationTests
{
    public abstract class BaseEfRepositoryTestFixture
    {
        protected DbContextOptions<MoisContext> CreateNewContextOptions() => 
            new DbContextOptionsBuilder<MoisContext>().UseInMemoryDatabase(databaseName: "InMemoryDbForTesting").Options;
    }
}
