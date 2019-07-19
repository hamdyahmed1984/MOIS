using Domain.Entities.Documents;
using Persistence.EntityFrameworkDataAccess;
using Persistence.EntityFrameworkDataAccess.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class MarriageDocRepositoryTests : BaseEfRepositoryTestFixture
    {
        private readonly MoisContext _moisContext;
        private readonly MarriageDocRepository _marriageDocRepository;

        public MarriageDocRepositoryTests()
        {
            _moisContext = new MoisContext(CreateNewContextOptions());
            _marriageDocRepository = new MarriageDocRepository(_moisContext);
        }

        [Fact]
        public async Task CreateAndGetDoc()
        {
            var doc = new MarriageDoc() { SpouseFullName = "Fatema" };
            await _marriageDocRepository.CreateMarriageDoc(doc);
            await _marriageDocRepository.UnitOfWork.CommitChangesAsync();

            Assert.True(doc.Id > 0);

            var docFromDB = _moisContext.MarriageDocs.FirstOrDefault(a => a.Id == doc.Id);
            Assert.Equal(doc.SpouseFullName, docFromDB.SpouseFullName);            
        }
    }
}
