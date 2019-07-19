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
    public class DeathDocServiceTests
    {
        Mock<ILogger<DeathDocService>> mockLogger;
        Mock<IDeathDocRepository> mockDocRepo;
        Mock<ICachedLookupsService> mockCachedLookupsService;

        private void CreateMockedObjects(out Mock<ILogger<DeathDocService>> mockLogger, out Mock<IDeathDocRepository> mockDocRepo, out Mock<ICachedLookupsService> mockCachedLookupsService)
        {
            mockLogger = new Mock<ILogger<DeathDocService>>();
            mockDocRepo = new Mock<IDeathDocRepository>();
            mockCachedLookupsService = new Mock<ICachedLookupsService>();
            mockCachedLookupsService.Setup(s => s.GetLookups<DocumentTypeRelation>())
               .ReturnsAsync(GetFakeDocumentTypeRelations());
            mockCachedLookupsService.Setup(s => s.FindWhere<State>(a => a.Code == "NEW"))
               .ReturnsAsync(GetFakeNewState());
            mockCachedLookupsService.Setup(s => s.FindWhere<DocumentType>(a => a.Code == "MOICSO005"))
                .ReturnsAsync(GetFakeDocType());
        }

        [Fact]
        public async Task GetDocPrice_ReturnsDocPrice()
        {
            // Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DeathDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.GetDocPrice();

            //Assert
            Assert.Equal(defaultPrice, result);
        }

        [Fact]
        public async Task CreateDeathDocsAsync_ShouldThrowDomainException_WhenRelationIsNotValid()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DeathDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            //Action result = async () => await docService.CreateDeathDocsAsync(GetTestDocs());

            //Assert
            await Assert.ThrowsAsync<DomainException>(async () => await docService.CreateDeathDocsAsync(GetFakeInvalidDocs()));
        }

        [Fact]
        public async Task CreateDeathDocsAsync_ShouldSetStateIdToNew()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DeathDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateDeathDocsAsync(GetFakeValidDocs());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<DeathDocResponse>>(result);
            Assert.Equal(1, result.First().DeathDoc.StateId);
        }

        [Fact]
        public async Task CreateDeathDocsAsync_ShouldSetPriceEquals100()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DeathDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateDeathDocsAsync(GetFakeValidDocs());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<DeathDocResponse>>(result);
            Assert.Equal(100, result.First().DeathDoc.Price);
        }

        [Fact]
        public async Task CreateDeathDocsAsync_ShouldSetNidToDefaultValueWhenNidIsNull()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DeathDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateDeathDocsAsync(GetFakeValidDocsForFirstTime_NidIsNull());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<DeathDocResponse>>(result);
            Assert.Equal(Constants.DEFAULT_NID_NUMBER, result.First().DeathDoc.NID.NationalIdenNumber);
        }

        [Fact]
        public async Task CreateDeathDocsAsync_ShouldNotSetNidToDefaultValueWhenNidIsNotNull()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new DeathDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateDeathDocsAsync(GetFakeValidDocs_NidIsNotNull());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<DeathDocResponse>>(result);
            Assert.Equal(GetFakeValidDocs_NidIsNotNull().First().NID.NationalIdenNumber, result.First().DeathDoc.NID.NationalIdenNumber);
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

        private IEnumerable<DeathDoc> GetFakeInvalidDocs()
        {
            return new List<DeathDoc>
            {
                new DeathDoc(),
                new DeathDoc()
            };
        }

        private IEnumerable<DeathDoc> GetFakeValidDocs()
        {
            return new List<DeathDoc>
            {
                new DeathDoc{ GenderId = 1, RelationId = 1 },
                new DeathDoc{ GenderId = 1, RelationId = 1 }
            };
        }

        private IEnumerable<DeathDoc> GetFakeValidDocsForFirstTime_NidIsNull()
        {
            return new List<DeathDoc>
            {
                new DeathDoc{ GenderId = 1, RelationId = 1 }
            };
        }

        private IEnumerable<DeathDoc> GetFakeValidDocs_NidIsNotNull()
        {
            return new List<DeathDoc>
            {
                new DeathDoc{ GenderId = 1, RelationId = 1, NID = new Domain.ValueObjects.NID("28410071402991") }
            };
        }

        private DocumentType GetFakeDocType()
        {
            return new DocumentType
            {        
                Id = 1,
                Code = "MOICSO005",
                Price = 100
            };
        }
    }
}
