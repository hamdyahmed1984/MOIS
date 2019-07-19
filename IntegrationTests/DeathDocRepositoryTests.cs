using Domain.Entities.Documents;
using Persistence.EntityFrameworkDataAccess;
using Persistence.EntityFrameworkDataAccess.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class DeathDocRepositoryTests : BaseEfRepositoryTestFixture
    {
        private readonly MoisContext _moisContext;
        private readonly DeathDocRepository _deathDocRepository;

        public DeathDocRepositoryTests()
        {
            _moisContext = new MoisContext(CreateNewContextOptions());
            _deathDocRepository = new DeathDocRepository(_moisContext);
        }

        [Fact]
        public async Task CreateAndGetDoc()
        {
            var doc = new DeathDoc() { MotherFullName = "Fatema" };
            await _deathDocRepository.CreateDeathDoc(doc);
            await _deathDocRepository.UnitOfWork.CommitChangesAsync();

            Assert.True(doc.Id > 0);

            var docFromDB = _moisContext.DeathDocs.FirstOrDefault(a => a.Id == doc.Id);
            Assert.Equal(doc.MotherFullName, docFromDB.MotherFullName);            
        }
    }
}
