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
    public class DeathDocControllerTests
    {
        ILoggerFactory logFactory;
        IMapper mapper;
        Mock<IDeathDocService> mockDocService;

        [Fact]
        public async Task CreateDeathDocsAsync_ReturnsBadRequest_WhenFailedToAddDocs()
        {
            //Arrange  
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateDeathDocsAsync(It.IsAny<IEnumerable<DeathDoc>>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakeInvalidDocsResponseList());
            var controller = new DeathDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateDeathDocsAsync(GetFakeDocResourceInList());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Failed to create death doc!", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateDeathDocsAsync_ReturnsDeathDocResourceOutList_WhenSucceededToAddDeathDocs()
        {
            //Arrange
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateDeathDocsAsync(It.IsAny<IEnumerable<DeathDoc>>(), It.IsAny<bool>()))
                .ReturnsAsync(GetFakeValidDocsResponseList());
            var controller = new DeathDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateDeathDocsAsync(GetFakeDocResourceInList());

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            var succeededDeathDocResponce = Assert.IsType<List<DeathDocResourceOut>>(okRequestResult.Value);
            Assert.Equal(1, succeededDeathDocResponce.First().StateId);
        }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsDeathDocPrice()
        {
            //Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects();
            mockDocService.Setup(s => s.GetDocPrice())
                .ReturnsAsync(defaultPrice);
            var controller = new DeathDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetDocPriceAsync();

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(defaultPrice, okRequestResult.Value);
        }

        private IEnumerable<DeathDocResourceIn> GetFakeDocResourceInList()
        {
            return new List<DeathDocResourceIn>
            {
                new DeathDocResourceIn{ GenderId=1, MotherFullName="Fatema", NumberOfCopies=1, RelationId=1 }
            };
        }

        private IEnumerable<DeathDocResponse> GetFakeInvalidDocsResponseList()
        {
            return new List<DeathDocResponse>
            {
                new DeathDocResponse("Failed to create death doc!")
            };
        }

        private IEnumerable<DeathDocResponse> GetFakeValidDocsResponseList()
        {
            return new List<DeathDocResponse>()
            {
                new DeathDocResponse( new DeathDoc{ StateId=1, GenderId=1, MotherFullName="Fatema" })
            };
        }

        private void CreateMockedObjects()
        {
            logFactory = CreateLogger();
            mapper = CreateMapper();
            mockDocService = new Mock<IDeathDocService>();
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
            //var logger = factory.CreateLogger<DeathDocController>();
            return logFactory;
        }
    }
}
