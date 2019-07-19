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
    public class DivorceDocServiceTests
    {
        Mock<ILogger<DivorceDocService>> mockLogger;
        Mock<IDivorceDocRepository> mockDocRepo;
        Mock<ICachedLookupsService> mockCachedLookupsService;

        private void CreateMockedObjects(out Mock<ILogger<DivorceDocService>> mockLogger, out Mock<IDivorceDocRepository> mockDocRepo, out Mock<ICachedLookupsService> mockCachedLookupsService)
        {
            mockLogger = new Mock<ILogger<DivorceDocService>>();
            mockDocRepo = new Mock<IDivorceDocRepository>();
            mockCachedLookupsService = new Mock<ICachedLookupsService>();
            mockCachedLookupsService.Setup(s => s.GetLookups<DocumentTypeRelation>())
               .ReturnsAsync(GetFakeDocumentTypeRelations());
            mockCachedLookupsService.Setup(s => s.FindWhere<State>(a => a.Code == "NEW"))
               .ReturnsAsync(GetFakeNewState());
            mockCachedLookupsService.Setup(s => s.FindWhere<DocumentType>(a => a.Code == "MOICSO004"))
                .ReturnsAsync(GetFakeDocType());
        }

        [Fact]
        public async Task GetDocPrice_ReturnsDocPrice()
        {
            // Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DivorceDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.GetDocPrice();

            //Assert
            Assert.Equal(defaultPrice, result);
        }

        [Fact]
        public async Task CreateDivorceDocsAsync_ShouldThrowDomainException_WhenRelationIsNotValid()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DivorceDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            //Action result = async () => await docService.CreateDivorceDocsAsync(GetTestDocs());

            //Assert
            await Assert.ThrowsAsync<DomainException>(async () => await docService.CreateDivorceDocsAsync(GetFakeInvalidDocs()));
        }

        [Fact]
        public async Task CreateDivorceDocsAsync_ShouldSetStateIdToNew()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DivorceDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateDivorceDocsAsync(GetFakeValidDocs());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<DivorceDocResponse>>(result);
            Assert.Equal(1, result.First().DivorceDoc.StateId);
        }

        [Fact]
        public async Task CreateDivorceDocsAsync_ShouldSetPriceEquals100()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DivorceDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateDivorceDocsAsync(GetFakeValidDocs());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<DivorceDocResponse>>(result);
            Assert.Equal(100, result.First().DivorceDoc.Price);
        }

        private State GetFakeNewState()
        {
            return new State { Id = 1, Code = "NEW" };
        }

        private IEnumerable<DocumentTypeRelation> GetFakeDocumentTypeRelations()
        {
            return new List<DocumentTypeRelation>
            {
                new DocumentTypeRelation{ DocumentTypeId=1, GenderId=1, RelationId=1 }
            };
        }

        private IEnumerable<DivorceDoc> GetFakeInvalidDocs()
        {
            return new List<DivorceDoc>
            {
                new DivorceDoc(),
                new DivorceDoc()
            };
        }

        private IEnumerable<DivorceDoc> GetFakeValidDocs()
        {
            return new List<DivorceDoc>
            {
                new DivorceDoc{ RelationId = 1 },
                new DivorceDoc{ RelationId = 1 }
            };
        }

        private DocumentType GetFakeDocType()
        {
            return new DocumentType
            {        
                Id = 1,
                Code = "MOICSO004",
                Price = 100
            };
        }
    }
}
