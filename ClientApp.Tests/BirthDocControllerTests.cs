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
    public class BirthDocControllerTests
    {
        ILoggerFactory logFactory;
        IMapper mapper;
        Mock<IBirthDocService> mockDocService;

        [Fact]
        public async Task CreateBirthDocsAsync_ReturnsBadRequest_WhenFailedToAddDocs()
        {
            //Arrange  
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateBirthDocsAsync(It.IsAny<IEnumerable<BirthDoc>>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakeInvalidDocsResponseList());
            var controller = new BirthDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateBirthDocsAsync(GetFakeDocResourceInList());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Failed to create birth doc!", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateBirthDocsAsync_ReturnsBirthDocResourceOutList_WhenSucceededToAddBirthDocs()
        {
            //Arrange
            CreateMockedObjects();
            mockDocService.Setup(s => s.CreateBirthDocsAsync(It.IsAny<IEnumerable<BirthDoc>>(), It.IsAny<bool>()))
                .ReturnsAsync(GetFakeValidDocsResponseList());
            var controller = new BirthDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.CreateBirthDocsAsync(GetFakeDocResourceInList());

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            var succeededBirthDocResponce = Assert.IsType<List<BirthDocResourceOut>>(okRequestResult.Value);
            Assert.Equal(1, succeededBirthDocResponce.First().StateId);
        }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsBirthDocPrice()
        {
            //Arrange
            decimal defaultPrice = 100;
            CreateMockedObjects();
            mockDocService.Setup(s => s.GetDocPrice())
                .ReturnsAsync(defaultPrice);
            var controller = new BirthDocController(mockDocService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetDocPriceAsync();

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(defaultPrice, okRequestResult.Value);
        }

        private IEnumerable<BirthDocResourceIn> GetFakeDocResourceInList()
        {
            return new List<BirthDocResourceIn>
            {
                new BirthDocResourceIn{ GenderId=1, MotherFullName="Fatema", NumberOfCopies=1, RelationId=1 }
            };
        }

        private IEnumerable<BirthDocResponse> GetFakeInvalidDocsResponseList()
        {
            return new List<BirthDocResponse>
            {
                new BirthDocResponse("Failed to create birth doc!")
            };
        }

        private IEnumerable<BirthDocResponse> GetFakeValidDocsResponseList()
        {
            return new List<BirthDocResponse>()
            {
                new BirthDocResponse( new BirthDoc{ StateId=1, GenderId=1, MotherFullName="Fatema" })
            };
        }

        private void CreateMockedObjects()
        {
            logFactory = CreateLogger();
            mapper = CreateMapper();
            mockDocService = new Mock<IBirthDocService>();
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
            //var logger = factory.CreateLogger<BirthDocController>();
            return logFactory;
        }
    }
}
