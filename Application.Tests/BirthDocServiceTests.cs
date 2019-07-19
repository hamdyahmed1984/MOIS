using System.Linq;
using Xunit;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Application.Interfaces;
using Application.Services;
using Domain.Entities.Lookups;
using Domain.Entities.Documents;
using System.Collections.Generic;
using Domain.Exceptions;
using Application.Services.Communication;
using Domain;

namespace Application.Tests
{
    public class BirthDocServiceTests
    {
        Mock<ILogger<BirthDocService>> mockLogger;
        Mock<IBirthDocRepository> mockBirthDocRepo;
        Mock<ICachedLookupsService> mockCachedLookupsService;

        private void CreateMockedObjects(out Mock<ILogger<BirthDocService>> mockLogger, out Mock<IBirthDocRepository> mockBirthDocRepo, out Mock<ICachedLookupsService> mockCachedLookupsService)
        {
            mockLogger = new Mock<ILogger<BirthDocService>>();
            mockBirthDocRepo = new Mock<IBirthDocRepository>();
            mockCachedLookupsService = new Mock<ICachedLookupsService>();
            mockCachedLookupsService.Setup(s => s.GetLookups<DocumentTypeRelation>())
               .ReturnsAsync(GetFakeDocumentTypeRelations());
            mockCachedLookupsService.Setup(s => s.FindWhere<State>(a => a.Code == "NEW"))
               .ReturnsAsync(GetFakeNewState());
            mockCachedLookupsService.Setup(s => s.FindWhere<DocumentType>(a => a.Code == "MOICSO001"))
                .ReturnsAsync(GetFakeDocType());
        }

        [Fact]
        public async Task GetDocPrice_ReturnsDocPrice()
        {
            // Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects(out mockLogger, out mockBirthDocRepo, out mockCachedLookupsService);
            var docService = new BirthDocService(mockBirthDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.GetDocPrice();

            //Assert
            Assert.Equal(defaultPrice, result);
        }

        [Fact]
        public async Task CreateBirthDocsAsync_ShouldThrowDomainException_WhenRelationIsNotValid()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockBirthDocRepo, out mockCachedLookupsService);
            var docService = new BirthDocService(mockBirthDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            //Action result = async () => await docService.CreateBirthDocsAsync(GetTestDocs());

            //Assert
            await Assert.ThrowsAsync<DomainException>(async () => await docService.CreateBirthDocsAsync(GetFakeInvalidBirthDocs()));
        }

        [Fact]
        public async Task CreateBirthDocsAsync_ShouldSetStateIdToNew()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockBirthDocRepo, out mockCachedLookupsService);
            var docService = new BirthDocService(mockBirthDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateBirthDocsAsync(GetFakeValidBirthDocs());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<BirthDocResponse>>(result);
            Assert.Equal(1, result.First().BirthDoc.StateId);
        }

        [Fact]
        public async Task CreateBirthDocsAsync_ShouldSetPriceEquals100()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockBirthDocRepo, out mockCachedLookupsService);
            var docService = new BirthDocService(mockBirthDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateBirthDocsAsync(GetFakeValidBirthDocs());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<BirthDocResponse>>(result);
            Assert.Equal(100, result.First().BirthDoc.Price);
        }

        [Fact]
        public async Task CreateBirthDocsAsync_ShouldSetNidToDefaultValueWhenTheDocIsFirstTime()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockBirthDocRepo, out mockCachedLookupsService);
            var docService = new BirthDocService(mockBirthDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateBirthDocsAsync(GetFakeValidBirthDocsForFirstTime());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<BirthDocResponse>>(result);
            Assert.Equal(Constants.DEFAULT_NID_NUMBER, result.First().BirthDoc.NID.NationalIdenNumber);
        }

        [Fact]
        public async Task CreateBirthDocsAsync_ShouldNotSetNidToDefaultValueWhenTheDocIsNotFirstTime()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockBirthDocRepo, out mockCachedLookupsService);
            var docService = new BirthDocService(mockBirthDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateBirthDocsAsync(GetFakeValidBirthDocsNotForFirstTime());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<BirthDocResponse>>(result);
            Assert.Equal(GetFakeValidBirthDocsNotForFirstTime().First().NID.NationalIdenNumber, result.First().BirthDoc.NID.NationalIdenNumber);
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

        private IEnumerable<BirthDoc> GetFakeInvalidBirthDocs()
        {
            return new List<BirthDoc>
            {
                new BirthDoc(),
                new BirthDoc()
            };
        }

        private IEnumerable<BirthDoc> GetFakeValidBirthDocs()
        {
            return new List<BirthDoc>
            {
                new BirthDoc{ GenderId = 1, RelationId = 1 },
                new BirthDoc{ GenderId = 1, RelationId = 1 }
            };
        }

        private IEnumerable<BirthDoc> GetFakeValidBirthDocsForFirstTime()
        {
            return new List<BirthDoc>
            {
                new BirthDoc{ GenderId = 1, RelationId = 1, IsFirstTime = true }
            };
        }

        private IEnumerable<BirthDoc> GetFakeValidBirthDocsNotForFirstTime()
        {
            return new List<BirthDoc>
            {
                new BirthDoc{ GenderId = 1, RelationId = 1, IsFirstTime = false, NID = new Domain.ValueObjects.NID("28410071402991") }
            };
        }

        private DocumentType GetFakeDocType()
        {
            return new DocumentType
            {        
                Id = 1,
                Code = "MOICSO001",
                Price = 100
            };
        }
    }
}
