using Xunit;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using Application.Services.Communication;
using Application.Interfaces;
using Application.Services;
using Domain.Entities.Lookups;
using Domain.Entities.Documents;
using Domain.Entities;
using System;
using Microsoft.Extensions.Options;
using Application.Configs;
using System.Linq.Expressions;

namespace Application.Tests
{
    public class RequestServiceTests
    {
        Mock<ILogger<RequestService>> mockLogger;        
        Mock<ICachedLookupsService> mockCachedLookupsService;
        Mock<IRequestRepository> mockRequestRepo;
        Mock<IBirthDocService> mockBirthDocService;
        Mock<IDeathDocService> mockDeathDocService;
        Mock<IMarriageDocService> mockMarriageDocService;
        Mock<IDivorceDocService> mockDivorceDocService;
        Mock<INidDocService> mockNidDocService;

        private void CreateMockedObjects()
        {
            mockLogger = new Mock<ILogger<RequestService>>();
            mockCachedLookupsService = new Mock<ICachedLookupsService>();
            mockRequestRepo = new Mock<IRequestRepository>();
            mockBirthDocService = new Mock<IBirthDocService>();
            mockDeathDocService = new Mock<IDeathDocService>();
            mockMarriageDocService = new Mock<IMarriageDocService>();
            mockDivorceDocService = new Mock<IDivorceDocService>();
            mockNidDocService = new Mock<INidDocService>();
        }

        [Fact]
        public async Task GetRequestAsync_ReturnsNotFoundRequest()
        {
            // Arrange
            CreateMockedObjects();
            mockRequestRepo.Setup(s => s.GetRequest(It.IsAny<int>()))
                .ReturnsAsync(GetNullRequest());
            var requestService = new RequestService(mockRequestRepo.Object, mockLogger.Object, mockCachedLookupsService.Object, GetFakeConfigs(),
                mockBirthDocService.Object, mockDeathDocService.Object, mockMarriageDocService.Object, mockDivorceDocService.Object, mockNidDocService.Object);

            //Act
            var result = await requestService.GetRequestAsync(1);

            //Assert
            var requestResponse = Assert.IsAssignableFrom<RequestResponse>(result);
            Assert.True(requestResponse.Success);
            Assert.NotNull(requestResponse.Message);
            Assert.Null(requestResponse.Request);
        }

        [Fact]
        public async Task GetRequestAsync_ReturnsRequestResponseWithAllDetails()
        {
            // Arrange
            CreateMockedObjects();
            mockRequestRepo.Setup(s => s.GetRequest(It.IsAny<int>()))
                .ReturnsAsync(GetFakeRequestWithDetails());
            var requestService = new RequestService(mockRequestRepo.Object, mockLogger.Object, mockCachedLookupsService.Object, GetFakeConfigs(),
                mockBirthDocService.Object, mockDeathDocService.Object, mockMarriageDocService.Object, mockDivorceDocService.Object, mockNidDocService.Object);

            //Act
            var result = await requestService.GetRequestAsync(1);

            //Assert
            var requestResponse = Assert.IsAssignableFrom<RequestResponse>(result);
            Assert.True(requestResponse.Success);  
            var request = requestResponse.Request;
            Assert.Equal("CSO", request.Code);
            Assert.Equal(100, request.Price);
            Assert.Equal(12, request.PostalFees);
            Assert.Equal(2, request.BirthDocs.Count);
            Assert.Equal(1, request.DeathDocs.Count);
        }

        [Fact]
        public async Task CreateRequestAsyncc_ReturnsRequestResponseWithAllDetails()
        {
            // Arrange
            CreateMockedObjects();
            mockRequestRepo.Setup(s => s.CreateRequest(It.IsAny<Request>()));
            mockCachedLookupsService.Setup(s => s.FindWhere<Issuer>(It.IsAny<Expression<Func<Issuer, bool>>>()))
              .ReturnsAsync(GetFakeIssuer());
            var requestService = new RequestService(mockRequestRepo.Object, mockLogger.Object, mockCachedLookupsService.Object, GetFakeConfigs(),
                mockBirthDocService.Object, mockDeathDocService.Object, mockMarriageDocService.Object, mockDivorceDocService.Object, mockNidDocService.Object);

            //Act
            var result = await requestService.CreateRequestAsync(GetFakeRequestWithDetails(), "CSO", true);

            //Assert
            var requestResponse = Assert.IsAssignableFrom<RequestResponse>(result);
            Assert.True(requestResponse.Success);
            var request = requestResponse.Request;
            Assert.Equal(1, request.IssuerId);
            Assert.Equal(300, request.Price);
            Assert.Equal(12, request.PostalFees);
            Assert.Equal(2, request.BirthDocs.Count);
            Assert.Equal(1, request.DeathDocs.Count);
        }

        private Issuer GetFakeIssuer()
        {
            return new Issuer { Id = 1, Code = "CSO" };
        }

        private Request GetFakeRequestWithDetails()
        {
            var req = new Request("CSO", null, null, null, null, null, null, null, null, null);
            req.AddBirthDoc(new BirthDoc() { Price = 100 });
            req.SetPrice(100);
            req.SetPostalFees(12);
            req.AddDeathRecordDoc(new DeathDoc() { Price = 100 });
            req.AddBirthDoc(new BirthDoc() { Price = 100 });
            return req;
        }

        private Request GetNullRequest()
        {
            return null;
        }

        private IOptions<AppConfigs> GetFakeConfigs()
        {
            return Options.Create<AppConfigs>(new AppConfigs
            {
                PostalPackageOptions = new PostalPackageOptions
                {
                    PackagePrice = 12,
                    PackageItemsMaxCount = 5
                }
            });
        }
    }
}
