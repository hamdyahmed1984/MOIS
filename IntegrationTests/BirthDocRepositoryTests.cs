using Domain.Entities.Documents;
using Persistence.EntityFrameworkDataAccess;
using Persistence.EntityFrameworkDataAccess.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class BirthDocRepositoryTests: BaseEfRepositoryTestFixture
    {
        private readonly MoisContext _moisContext;
        private readonly BirthDocRepository _birthDocRepository;

        public BirthDocRepositoryTests()
        {
            _moisContext = new MoisContext(CreateNewContextOptions());
            _birthDocRepository = new BirthDocRepository(_moisContext);
        }

        [Fact]
        public async Task CreateAndGetDoc()
        {
            var doc = new BirthDoc() { MotherFullName = "Fatema" };
            await _birthDocRepository.CreateBirthDoc(doc);
            await _birthDocRepository.UnitOfWork.CommitChangesAsync();

            Assert.True(doc.Id > 0);

            var docFromDB = _moisContext.BirthDocs.FirstOrDefault(a => a.Id == doc.Id);
            Assert.Equal(doc.MotherFullName, docFromDB.MotherFullName);            
        }
    }
}
