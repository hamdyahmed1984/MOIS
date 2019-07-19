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
    public class DivorceDocControllerTests
    {
        ILoggerFactory logFactory;
        IMapper mapper;
        Mock<IDivorceDocService> mockDocService;

        [Fact]
        public async Task CreateDivorceDocsAsync_ReturnsBadRequest_WhenFailedToAddDocs()
        {
            //Arrange  
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateDivorceDocsAsync(It.IsAny<IEnumerable<DivorceDoc>>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakeInvalidDocsResponseList());
            var controller = new DivorceDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateDivorceDocsAsync(GetFakeDocResourceInList());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Failed to create divorce doc!", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateDivorceDocsAsync_ReturnsDivorceDocResourceOutList_WhenSucceededToAddDivorceDocs()
        {
            //Arrange
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateDivorceDocsAsync(It.IsAny<IEnumerable<DivorceDoc>>(), It.IsAny<bool>()))
                .ReturnsAsync(GetFakeValidDocsResponseList());
            var controller = new DivorceDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateDivorceDocsAsync(GetFakeDocResourceInList());

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            var succeededDivorceDocResponce = Assert.IsType<List<DivorceDocResourceOut>>(okRequestResult.Value);
            Assert.Equal(1, succeededDivorceDocResponce.First().StateId);
        }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsDivorceDocPrice()
        {
            //Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects();
            mockDocService.Setup(s => s.GetDocPrice())
                .ReturnsAsync(defaultPrice);
            var controller = new DivorceDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetDocPriceAsync();

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(defaultPrice, okRequestResult.Value);
        }

        private IEnumerable<DivorceDocResourceIn> GetFakeDocResourceInList()
        {
            return new List<DivorceDocResourceIn>
            {
                new DivorceDocResourceIn{ NumberOfCopies = 1, RelationId = 1 }
            };
        }

        private IEnumerable<DivorceDocResponse> GetFakeInvalidDocsResponseList()
        {
            return new List<DivorceDocResponse>
            {
                new DivorceDocResponse("Failed to create divorce doc!")
            };
        }

        private IEnumerable<DivorceDocResponse> GetFakeValidDocsResponseList()
        {
            return new List<DivorceDocResponse>()
            {
                new DivorceDocResponse( new DivorceDoc{ StateId=1 })
            };
        }

        private void CreateMockedObjects()
        {
            logFactory = CreateLogger();
            mapper = CreateMapper();
            mockDocService = new Mock<IDivorceDocService>();
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
            //var logger = factory.CreateLogger<DivorceDocController>();
            return logFactory;
        }
    }
}
