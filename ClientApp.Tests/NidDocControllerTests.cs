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
    public class NidDocControllerTests
    {
        ILoggerFactory logFactory;
        IMapper mapper;
        Mock<INidDocService> mockDocService;

        [Fact]
        public async Task CreateNidDocsAsync_ReturnsBadRequest_WhenFailedToAddDocs()
        {
            //Arrange  
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateNidDocAsync(It.IsAny<NidDoc>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakeInvalidDocResponse());
            var controller = new NidDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateNidDocAsync(GetFakeDocResourceIn());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Failed to create Nid doc!", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateNidDocsAsync_ReturnsNidDocResourceOutList_WhenSucceededToAddNidDocs()
        {
            //Arrange
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateNidDocAsync(It.IsAny<NidDoc>(), It.IsAny<bool>()))
                .ReturnsAsync(GetFakeValidDocsResponse());
            var controller = new NidDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateNidDocAsync(GetFakeDocResourceIn());

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            var succeededNidDocResponce = Assert.IsType<NidDocResourceOut>(okRequestResult.Value);
            Assert.Equal(1, succeededNidDocResponce.StateId);
        }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsNidDocPrice()
        {
            //Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects();
            mockDocService.Setup(s => s.GetDocPrice())
                .ReturnsAsync(defaultPrice);
            var controller = new NidDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetDocPriceAsync();

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(defaultPrice, okRequestResult.Value);
        }

        private NidDocResourceIn GetFakeDocResourceIn()
        {
            return new NidDocResourceIn();
        }

        private NidDocResponse GetFakeInvalidDocResponse()
        {
            return new NidDocResponse("Failed to create Nid doc!");
        }

        private NidDocResponse GetFakeValidDocsResponse()
        {
            return new NidDocResponse(new NidDoc { StateId = 1 });
        }

        private void CreateMockedObjects()
        {
            logFactory = CreateLogger();
            mapper = CreateMapper();
            mockDocService = new Mock<INidDocService>();
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
            //var logger = factory.CreateLogger<NidDocController>();
            return logFactory;
        }
    }
}
