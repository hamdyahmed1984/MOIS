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
    public class MarriageDocServiceTests
    {
        Mock<ILogger<MarriageDocService>> mockLogger;
        Mock<IMarriageDocRepository> mockDocRepo;
        Mock<ICachedLookupsService> mockCachedLookupsService;

        private void CreateMockedObjects(out Mock<ILogger<MarriageDocService>> mockLogger, out Mock<IMarriageDocRepository> mockDocRepo, out Mock<ICachedLookupsService> mockCachedLookupsService)
        {
            mockLogger = new Mock<ILogger<MarriageDocService>>();
            mockDocRepo = new Mock<IMarriageDocRepository>();
            mockCachedLookupsService = new Mock<ICachedLookupsService>();
            mockCachedLookupsService.Setup(s => s.GetLookups<DocumentTypeRelation>())
               .ReturnsAsync(GetFakeDocumentTypeRelations());
            mockCachedLookupsService.Setup(s => s.FindWhere<State>(a => a.Code == "NEW"))
               .ReturnsAsync(GetFakeNewState());
            mockCachedLookupsService.Setup(s => s.FindWhere<DocumentType>(a => a.Code == "MOICSO003"))
                .ReturnsAsync(GetFakeDocType());
        }

        [Fact]
        public async Task GetDocPrice_ReturnsDocPrice()
        {
            // Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new MarriageDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.GetDocPrice();

            //Assert
            Assert.Equal(defaultPrice, result);
        }

        [Fact]
        public async Task CreateMarriageDocsAsync_ShouldThrowDomainException_WhenRelationIsNotValid()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new MarriageDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            //Action result = async () => await docService.CreateMarriageDocsAsync(GetTestDocs());

            //Assert
            await Assert.ThrowsAsync<DomainException>(async () => await docService.CreateMarriageDocsAsync(GetFakeInvalidDocs()));
        }

        [Fact]
        public async Task CreateMarriageDocsAsync_ShouldSetStateIdToNew()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new MarriageDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateMarriageDocsAsync(GetFakeValidDocs());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<MarriageDocResponse>>(result);
            Assert.Equal(1, result.First().MarriageDoc.StateId);
        }

        [Fact]
        public async Task CreateMarriageDocsAsync_ShouldSetPriceEquals100()
        {
            // Arrange
            CreateMockedObjects(out mockLogger, out mockDocRepo, out mockCachedLookupsService);
            var docService = new MarriageDocService(mockDocRepo.Object, mockLogger.Object, mockCachedLookupsService.Object);

            //Act
            var result = await docService.CreateMarriageDocsAsync(GetFakeValidDocs());

            //Assert
            Assert.IsAssignableFrom<IEnumerable<MarriageDocResponse>>(result);
            Assert.Equal(100, result.First().MarriageDoc.Price);
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

        private IEnumerable<MarriageDoc> GetFakeInvalidDocs()
        {
            return new List<MarriageDoc>
            {
                new MarriageDoc(),
                new MarriageDoc()
            };
        }

        private IEnumerable<MarriageDoc> GetFakeValidDocs()
        {
            return new List<MarriageDoc>
            {
                new MarriageDoc{ RelationId = 1 },
                new MarriageDoc{ RelationId = 1 }
            };
        }

        private DocumentType GetFakeDocType()
        {
            return new DocumentType
            {        
                Id = 1,
                Code = "MOICSO003",
                Price = 100
            };
        }
    }
}
