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
using System;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Application.Configs;
using Domain.VerificationPlatform;

namespace ClientApp.Tests
{
    public class RequestsControllerTests
    {
        ILoggerFactory logFactory;
        IMapper mapper;
        Mock<IRequestService> mockRequestService;
        Mock<ITokenVerificationService> mockTokenVerification;

        [Fact]
        public async Task GetRequestAsync_ReturnsBadRequest_WhenRequestIdIsNull()
        {
            //Arrange  
            CreateMockedObjects();
            mockRequestService.Setup(s => s.GetRequestAsync(It.IsAny<int>()))
                    .ReturnsAsync(GetFakeRequestResponse());
            var controller = new RequestsController(mockRequestService.Object, mapper, logFactory, mockTokenVerification.Object);

            //Act
            var result = await controller.GetRequestAsync(null);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsAssignableFrom<ErrorResource>(badRequestResult.Value);
        }

        [Fact]
        public async Task GetRequestAsync_ReturnsNotFound_WhenRequestIdDoesNotExists()
        {
            //Arrange  
            CreateMockedObjects();
            mockRequestService.Setup(s => s.GetRequestAsync(It.IsAny<int>()))
                    .ReturnsAsync(GetFakeRequestResponse_ForNotFoundResult());
            var controller = new RequestsController(mockRequestService.Object, mapper, logFactory, mockTokenVerification.Object);

            //Act
            var result = await controller.GetRequestAsync(99999999);

            //Assert
            var notFountResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.IsAssignableFrom<ErrorResource>(notFountResult.Value);
        }

        [Fact]
        public async Task GetRequestAsync_ReturnsBadRequest_WhenFailedToGetTheRequest()
        {
            //Arrange  
            CreateMockedObjects();
            mockRequestService.Setup(s => s.GetRequestAsync(It.IsAny<int>()))
                    .ReturnsAsync(GetFakeFailedRequestResponse());
            var controller = new RequestsController(mockRequestService.Object, mapper, logFactory, mockTokenVerification.Object);

            //Act
            var result = await controller.GetRequestAsync(111);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsAssignableFrom<ErrorResource>(badRequestResult.Value);
        }

        [Fact]
        public async Task GetRequestAsync_ReturnsTheCreatedRequest_WhenTheRequestIsCreated()
        {
            //Arrange  
            CreateMockedObjects();
            mockRequestService.Setup(s => s.GetRequestAsync(It.IsAny<int>()))
                    .ReturnsAsync(GetFakeRequestResponse());
            var controller = new RequestsController(mockRequestService.Object, mapper, logFactory, mockTokenVerification.Object);

            //Act
            var result = await controller.GetRequestAsync(111);

            //Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<RequestStateResource>(okRequestResult.Value);
        }

        [Fact]
        public async Task CreateRequestAsync_ReturnsBadRequest_WhenFailedToCreateTheRequest()
        {
            //Arrange  
            CreateMockedObjects();
            mockRequestService.Setup(s => s.CreateRequestAsync(It.IsAny<Request>(), It.IsAny<string>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakeFailedRequestResponse());
            mockTokenVerification.Setup(s => s.ValidateLogin(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(GetFakeVerificationModel());
            var controller = new RequestsController(mockRequestService.Object, mapper, logFactory, mockTokenVerification.Object);

            //Act
            var result = await controller.CreateCsoRequestAsync(GetFakeRequestResourceIn(), true, "h@h.h", "token");

            //Assert
            var returnResult = Assert.IsType<ActionResult<RequestResourceOut>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(returnResult.Result);
            Assert.IsAssignableFrom<ErrorResource>(badRequestResult.Value);
        }

        [Fact]
        public async Task CreateRequestAsync_ReturnsTheRequest_WhenSucceededToCreateTheRequest()
        {
            //Arrange  
            CreateMockedObjects();
            mockRequestService.Setup(s => s.CreateRequestAsync(It.IsAny<Request>(), It.IsAny<string>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakeRequestResponse());
            mockTokenVerification.Setup(s => s.ValidateLogin(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(GetFakeVerificationModel());
            var controller = new RequestsController(mockRequestService.Object, mapper, logFactory, mockTokenVerification.Object);

            //Act
            var result = await controller.CreateCsoRequestAsync(GetFakeRequestResourceIn(), true, "h@h.h", "token");

            //Assert
            var returnResult = Assert.IsType<ActionResult<RequestResourceOut>>(result);
            var okResult = Assert.IsType<OkObjectResult>(returnResult.Result);
            Assert.IsAssignableFrom<RequestResourceOut>(okResult.Value);
        }

        private VerificationModel GetFakeVerificationModel()
        {
            VerificationModel model = new VerificationModel();
            model.Status = "1";
            model.Message = "message";
            model.FullName = "باسم إبراهيم محمد";
            model.NID = "27906250103655";
            model.NidFactoryNo = "HC7429791";
            model.Email = "basemibraheem@gmail.com";
            model.MotherFirstName = "بدرة";
            model.Mobile = "01112288890";
            model.GovernorateId = "1040";
            model.Address = "برج المعادي الجديدة الدائري -ميدان الجزائر - البساتين - القاهرة";
            model.JobTitle = "مهندس كهرباء حر";
            return model;
        }

        private RequestResourceIn GetFakeRequestResourceIn()
        {
            return new RequestResourceIn {
                NID= new NIDResource { NationalIdenNumber= "27906250103655" }
            };
        }

        private RequestResponse GetFakeFailedRequestResponse()
        {
            return new RequestResponse("Failed to create the request!");
        }

        private RequestResponse GetFakeRequestResponse()
        {
            return new RequestResponse(new Request(null, null, null, null, null, null, null, null, null, null));
        }

        private RequestResponse GetFakeRequestResponse_ForNotFoundResult()
        {
            return new RequestResponse(true, "Not found request!");
        }

        private void CreateMockedObjects()
        {
            logFactory = CreateLogger();
            mapper = CreateMapper();
            mockRequestService = new Mock<IRequestService>();
            mockTokenVerification = new Mock<ITokenVerificationService>();
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
