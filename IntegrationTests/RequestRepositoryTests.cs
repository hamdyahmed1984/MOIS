using Domain.Entities;
using Domain.Entities.Documents;
using Persistence.EntityFrameworkDataAccess;
using Persistence.EntityFrameworkDataAccess.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class RequestRepositoryTests : BaseEfRepositoryTestFixture
    {
        private readonly MoisContext _moisContext;
        private readonly RequestRepository _requestRepository;

        public RequestRepositoryTests()
        {
            _moisContext = new MoisContext(CreateNewContextOptions());
            _requestRepository = new RequestRepository(_moisContext);
        }

        [Fact]
        public async Task CreateAndGetRequest()
        {
            var request = new Request("CODE", null, "Fatema", null, null, null, null, null, null, null);
            await _requestRepository.CreateRequest(request);
            await _requestRepository.UnitOfWork.CommitChangesAsync();

            Assert.True(request.Id > 0);

            var requestFromDB = _moisContext.Requests.FirstOrDefault(a => a.Id == request.Id);
            Assert.Equal(request.MotherFullName, requestFromDB.MotherFullName);
            Assert.Equal(request.Code, requestFromDB.Code);
        }

        [Fact]
        public async Task GetRequest()
        {
            var request = new Request("CODE", null, "Fatema", null, null, null, null, null, null, null);
            request.AddBirthDoc(new BirthDoc());
            request.SetPrice(100);
            await _requestRepository.CreateRequest(request);
            await _requestRepository.UnitOfWork.CommitChangesAsync();

            Assert.True(request.Id > 0);

            var requestFromDB = _moisContext.Requests.FirstOrDefault(a => a.Id == request.Id);
            Assert.Equal(request.MotherFullName, requestFromDB.MotherFullName);
            Assert.Equal(request.Code, requestFromDB.Code);
            Assert.Equal(1, requestFromDB.BirthDocs.Count);
            Assert.Equal(100, requestFromDB.Price);
        }
    }
}
