using Domain.Entities.Documents;
using Persistence.EntityFrameworkDataAccess;
using Persistence.EntityFrameworkDataAccess.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class NidDocRepositoryTests : BaseEfRepositoryTestFixture
    {
        private readonly MoisContext _moisContext;
        private readonly NidDocRepository _nidDocRepository;

        public NidDocRepositoryTests()
        {
            _moisContext = new MoisContext(CreateNewContextOptions());
            _nidDocRepository = new NidDocRepository(_moisContext);
        }

        [Fact]
        public async Task CreateAndGetDoc()
        {
            var doc = new NidDoc() { JobName = "Engineer" };
            await _nidDocRepository.CreateNidDoc(doc);
            await _nidDocRepository.UnitOfWork.CommitChangesAsync();

            Assert.True(doc.Id > 0);

            var docFromDB = _moisContext.NidDocs.FirstOrDefault(a => a.Id == doc.Id);
            Assert.Equal(doc.JobName, docFromDB.JobName);            
        }
    }
}
