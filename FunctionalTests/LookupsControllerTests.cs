using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApp;
using Newtonsoft.Json;
using ClientApp.Controllers.Resources;
using System.Collections.Generic;
using ClientApp.Controllers.Resources.Security;
using ClientApp.Controllers.Resources.Lookups;

namespace FunctionalTests
{
    public class LookupsControllerTests : IClassFixture<CustomWebApplicationFactory<TestingStartup>>
    {
        public LookupsControllerTests(CustomWebApplicationFactory<TestingStartup> factory) => Client = factory.CreateClient();
        public HttpClient Client { get; }

        [Fact]
        public async Task GetGendersAsync_ShouldReturnAllGenders()
        {
            var response = await Client.GetAsync("/api/lookups/genders");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetGovsAsync_ShouldReturnAllGovs()
        {
            var response = await Client.GetAsync("/api/lookups/govs");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetPoliceDepartmentsAsync_ShouldReturnAllPoliceDepts()
        {
            var response = await Client.GetAsync("/api/lookups/police-depts");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetPostalCodesAsync_ShouldReturnAllPostalCodes()
        {
            var response = await Client.GetAsync("/api/lookups/postal-codes");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetRelationsAsync_ShouldReturnAllRelations()
        {
            var response = await Client.GetAsync("/api/lookups/relations");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetNidIssueReasonsAsync_ShouldReturnAllNidIssuingReasons()
        {
            var response = await Client.GetAsync("/api/lookups/nid-issue-reasons");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetNidJobTypesAsync_ShouldReturnAllNidJobTypes()
        {
            var response = await Client.GetAsync("/api/lookups/nid-job-types");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetStatesAsync_ShouldReturnAllStates()
        {
            var response = await Client.GetAsync("/api/lookups/states");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetLookupTypes_ShouldReturnAllLookupTypes()
        {
            var response = await Client.GetAsync("/api/lookups/lookups-types");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetLookups_ShouldReturnAllLookupsOfSpecificType()
        {
            Client.DefaultRequestHeaders.Add("lookupsType", "Genders");
            var response = await Client.GetAsync("/api/lookups/lookups-by-type");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllLookups_ShouldReturnAllLookups()
        {
            var response = await Client.GetAsync("/api/lookups/all-lookups");
            response.EnsureSuccessStatusCode();
        }
    }
}
