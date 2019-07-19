using System.Linq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Application.Interfaces;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ClientApp.Controllers;
using ClientApp.Mapping;
using System;
using Domain.Entities.Lookups;
using ClientApp.Controllers.Resources.Lookups;
using System.Linq.Expressions;
using Domain.Enums;

namespace ClientApp.Tests
{
    public class LookupsControllerTests
    {
        ILoggerFactory logFactory;
        IMapper mapper;
        Mock<ICachedLookupsService> mockCackedLookupsService;

        [Fact]
        public async Task GetGendersAsync_ReturnsListOfGenders()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetGendersAsync();

            //Assert
            var lookupsList = Assert.IsAssignableFrom <IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetGovsAsync_ReturnsListOfGovs()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetGovsAsync();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetPoliceDepartmentsAsync_ReturnsListOfPoliceDepts()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetPoliceDepartmentsAsync();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetPostalCodesAsync_ReturnsListOfPostalCodes()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetPostalCodesAsync();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetRelationsAsync_ReturnsListOfRelations()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetRelationsAsync();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetNidIssueReasonsAsync_ReturnsListOfNidIssuingReasons()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetNidIssueReasonsAsync();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetNidJobTypesAsync_ReturnsListOfNidJobtypes()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetNidJobTypesAsync();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetStatesAsync_ReturnsListOfStates()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetStatesAsync();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public void GetLookupTypes_ReturnsListOfLookupTypesEnumValues()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = controller.GetLookupTypes();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<string>>(result);
            Assert.Equal(lookupsList, Enum.GetNames(typeof(LookupType)));
        }

        [Fact]
        public async Task GetLookups_ReturnsListOfGenders()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetLookups("Genders");

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetLookups_ReturnsListOfRelations()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetLookups("Relations");

            //Assert
            var lookupsList = Assert.IsAssignableFrom<IEnumerable<LookupBaseResource>>(result);
            Assert.Single(lookupsList);
        }

        [Fact]
        public async Task GetAllLookups_ReturnsListOfAllLookups()
        {
            //Arrange  
            CreateMockedObjects();
            var controller = new LookupsController(mockCackedLookupsService.Object, mapper, logFactory);

            //Act
            var result = await controller.GetAllLookups();

            //Assert
            var lookupsList = Assert.IsAssignableFrom<Dictionary<string, IEnumerable<LookupBaseResource>>>(result);
            Assert.Single(lookupsList["Genders"]);
        }

        private void CreateMockedObjects()
        {
            logFactory = CreateLogger();
            mapper = CreateMapper();
            mockCackedLookupsService = new Mock<ICachedLookupsService>();

            mockCackedLookupsService.Setup(s => s.GetLookups<Gender>())
                    .ReturnsAsync(GetFakeGenderList());
            mockCackedLookupsService.Setup(s => s.GetLookups<Governorate>())
                    .ReturnsAsync(GetFakeGovsList());
            mockCackedLookupsService.Setup(s => s.GetLookups<PoliceDepartment>(It.IsAny<Expression<Func<PoliceDepartment, bool>>>(),
                It.IsAny<Func<IQueryable<PoliceDepartment>, IOrderedQueryable<PoliceDepartment>>>(), It.IsAny<string>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakePoliceDeptList());
            mockCackedLookupsService.Setup(s => s.GetLookups<PostalCode>(It.IsAny<Expression<Func<PostalCode, bool>>>(),
                It.IsAny<Func<IQueryable<PostalCode>, IOrderedQueryable<PostalCode>>>(), It.IsAny<string>(), It.IsAny<bool>()))
                    .ReturnsAsync(GetFakePostalCodeList());
            mockCackedLookupsService.Setup(s => s.GetLookups<Relation>())
                    .ReturnsAsync(GetFakeRelationList());
            mockCackedLookupsService.Setup(s => s.GetLookups<NidIssueReason>())
                    .ReturnsAsync(GetFakeNidIssuingReasonList());
            mockCackedLookupsService.Setup(s => s.GetLookups<JobTypeNID>())
                    .ReturnsAsync(GetFakeNidJobTypeList());
            mockCackedLookupsService.Setup(s => s.GetLookups<State>())
                    .ReturnsAsync(GetFakeStateList());
        }


        private IEnumerable<Governorate> GetFakeGovsList()
        {
            return new List<Governorate> { new Governorate() };
        }

        private IEnumerable<PostalCode> GetFakePostalCodeList()
        {
            return new List<PostalCode> { new PostalCode() };
        }

        private IEnumerable<PoliceDepartment> GetFakePoliceDeptList()
        {
            return new List<PoliceDepartment> { new PoliceDepartment() };
        }

        private IEnumerable<Gender> GetFakeGenderList()
        {
            return new List<Gender> { new Gender() };
        }

        private IEnumerable<Relation> GetFakeRelationList()
        {
            return new List<Relation> { new Relation() };
        }

        private IEnumerable<NidIssueReason> GetFakeNidIssuingReasonList()
        {
            return new List<NidIssueReason> { new NidIssueReason() };
        }

        private IEnumerable<JobTypeNID> GetFakeNidJobTypeList()
        {
            return new List<JobTypeNID> { new JobTypeNID() };
        }

        private IEnumerable<State> GetFakeStateList()
        {
            return new List<State> { new State() };
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
