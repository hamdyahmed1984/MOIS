using System.Linq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ClientApp.Controllers;
using Domain.Entities.Documents;
using Application.Services.Communication;
using ClientApp.Controllers.Resources;

using ClientApp.Mapping;

namespace ClientApp.Tests
{
    public class MarriageDocControllerTests
    {
        ILoggerFactory logFactory;
        IMapper mapper;
        Mock<IMarriageDocService> mockDocService;

        [Fact]
        public async Task CreateMarriageDocsAsync_ReturnsBadRequest_WhenFailedToAddDocs()
        {
            //Arrange  
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateMarriageDocsAsync(It.IsAny<IEnumerable<MarriageDoc>>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakeInvalidDocsResponseList());
            var controller = new MarriageDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateMarriageDocsAsync(GetFakeDocResourceInList());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Failed to create death doc!", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateMarriageDocsAsync_ReturnsMarriageDocResourceOutList_WhenSucceededToAddMarriageDocs()
        {
            //Arrange
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateMarriageDocsAsync(It.IsAny<IEnumerable<MarriageDoc>>(), It.IsAny<bool>()))
                .ReturnsAsync(GetFakeValidDocsResponseList());
            var controller = new MarriageDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateMarriageDocsAsync(GetFakeDocResourceInList());

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            var succeededMarriageDocResponce = Assert.IsType<List<MarriageDocResourceOut>>(okRequestResult.Value);
            Assert.Equal(1, succeededMarriageDocResponce.First().StateId);
        }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsMarriageDocPrice()
        {
            //Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects();
            mockDocService.Setup(s => s.GetDocPrice())
                .ReturnsAsync(defaultPrice);
            var controller = new MarriageDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetDocPriceAsync();

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(defaultPrice, okRequestResult.Value);
        }

        private IEnumerable<MarriageDocResourceIn> GetFakeDocResourceInList()
        {
            return new List<MarriageDocResourceIn>
            {
                new MarriageDocResourceIn{ NumberOfCopies = 1, RelationId = 1 }
            };
        }

        private IEnumerable<MarriageDocResponse> GetFakeInvalidDocsResponseList()
        {
            return new List<MarriageDocResponse>
            {
                new MarriageDocResponse("Failed to create death doc!")
            };
        }

        private IEnumerable<MarriageDocResponse> GetFakeValidDocsResponseList()
        {
            return new List<MarriageDocResponse>()
            {
                new MarriageDocResponse( new MarriageDoc{ StateId=1 })
            };
        }

        private void CreateMockedObjects()
        {
            logFactory = CreateLogger();
            mapper = CreateMapper();
            mockDocService = new Mock<IMarriageDocService>();
        }
        private IMapper CreateMapper()
        {
            //var mockIMapper = new Mock<IMapper>();
            var config = new MapperConfiguration(opts =>
            {
                // Add your mapper profile configs or mappings here
                opts.AddProfile<ModelToResourceProfile>();
                opts.AddProfile<ResourceToModelProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }

        private ILoggerFactory CreateLogger()
        {
            //var mockLogger = new Mock<ILoggerFactory>();
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();
            var logFactory = serviceProvider.GetService<ILoggerFactory>();
            //var logger = factory.CreateLogger<MarriageDocController>();
            return logFactory;
        }
    }
}
