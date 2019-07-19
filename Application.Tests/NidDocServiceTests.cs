using System.Linq;
using Xunit;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Domain.Exceptions;
using Application.Services.Communication;
using Domain;
using Application.Interfaces;
using Application.Services;
using Domain.Entities.Lookups;
using Domain.Entities.Documents;

namespace Application.Tests
{
    public class NidDocServiceTests
    {
        Mock<ILogger<NidDocService>> mockLogger;
        Mock<INidDocRepository> mockDocRepo;
        Mock<ICachedLookupsService> mockCachedLookupsService;

        private void CreateMockedObjects(out Mock<ILogger<NidDocService>> mockLogger, out Mock<INidDocRepository> mockDocRepo, out Mock<ICachedLookupsService> mockCachedLookupsService)
        {
            mockLogger = new Mock<ILogger<NidDocService>>();
            mockDocRepo = new Mock<INidDocRepository>();
            mockCachedLookupsService = new Mock<ICachedLookupsService>();
            mockCachedLookupsService.Setup(s => s.FindWhere<State>(a => a.Code == "NEW"))
               .ReturnsAsync(GetFakeNewState());
            mockCachedLookupsService.Setup(s => s.FindWhere<DocumentType>(a => a.Code == "MOICSO002"))
                .ReturnsAsync(GetFakeDocType());
        }

        [Fact]
        public async Task GetDocPrice_ReturnsDocPrice()
        {
            // Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new NidDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.GetDocPrice();

            //Assert
            Assert.Equal(defaultPrice, result);
        }

        [Fact]
        public async Task CreateNidDocsAsync_ShouldSetStateIdToNew()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new NidDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateNidDocAsync(GetFakeDoc());

            //Assert
            Assert.IsAssignableFrom<NidDocResponse>(result);
            Assert.Equal(1, result.NidDoc.StateId);
        }

        [Fact]
        public async Task CreateNidDocsAsync_ShouldSetPriceEquals100()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new NidDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateNidDocAsync(GetFakeDoc());

            //Assert
            Assert.IsAssignableFrom<NidDocResponse>(result);
            Assert.Equal(100, result.NidDoc.Price);
        }

        private State GetFakeNewState()
        {
            return new State { Id = 1, Code = "NEW" };
        }

        private NidDoc GetFakeDoc()
        {
            return new NidDoc();
        }

        private DocumentType GetFakeDocType()
        {
            return new DocumentType
            {        
                Id = 1,
                Code = "MOICSO002",
                Price = 100
            };
        }
    }
}
