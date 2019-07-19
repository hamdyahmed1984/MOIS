using Domain.Entities.Documents;
using Persistence.EntityFrameworkDataAccess;
using Persistence.EntityFrameworkDataAccess.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class DivorceDocRepositoryTests : BaseEfRepositoryTestFixture
    {
        private readonly MoisContext _moisContext;
        private readonly DivorceDocRepository _divorceDocRepository;

        public DivorceDocRepositoryTests()
        {
            _moisContext = new MoisContext(CreateNewContextOptions());
            _divorceDocRepository = new DivorceDocRepository(_moisContext);
        }

        [Fact]
        public async Task CreateAndGetDoc()
        {
            var doc = new DivorceDoc() { SpouseFullName = "Fatema" };
            await _divorceDocRepository.CreateDivorceDoc(doc);
            await _divorceDocRepository.UnitOfWork.CommitChangesAsync();

            Assert.True(doc.Id > 0);

            var docFromDB = _moisContext.DivorceDocs.FirstOrDefault(a => a.Id == doc.Id);
            Assert.Equal(doc.SpouseFullName, docFromDB.SpouseFullName);            
        }
    }
}
