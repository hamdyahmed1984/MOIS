using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApp;
using Newtonsoft.Json;
using ClientApp.Controllers.Resources;
using System.Collections.Generic;

namespace FunctionalTests
{
    public class RequestsControllerTests : IClassFixture<CustomWebApplicationFactory<TestingStartup>>
    {
        public RequestsControllerTests(CustomWebApplicationFactory<TestingStartup> factory) => Client = factory.CreateClient();

        const string MOTHER_FULL_NAME = "Fatema";

        public HttpClient Client { get; }

        [Fact]
        public async Task CreateCsoRequestAsync_ShouldReturnOkResultWithCreatedDocs()
        {
            RequestResourceIn request = GetRequestToSave();
            Client.DefaultRequestHeaders.Add("email", "email");
            Client.DefaultRequestHeaders.Add("token", "token");
            var response = await Client.PostAsJsonAsync("/api/requests/create-cso-request", request);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var savedRequest = JsonConvert.DeserializeObject<RequestResourceOut>(stringResponse);
            Assert.True(savedRequest.Id > 0);
            Assert.Single(savedRequest.BirthDocs);
        }

        [Fact]
        public async Task GetRequestAsync_ShouldReturnOkResultWithFoundRequest()
        {
            //Create the request
            RequestResourceIn request = GetRequestToSave();
            Client.DefaultRequestHeaders.Add("email", "email");
            Client.DefaultRequestHeaders.Add("token", "token");
            var response = await Client.PostAsJsonAsync("/api/requests/create-cso-request", request);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var savedRequest = JsonConvert.DeserializeObject<RequestResourceOut>(stringResponse);

            //Get the request
            Client.DefaultRequestHeaders.Add("requestId", savedRequest.Id.ToString());
            response = await Client.GetAsync("/api/requests/request-status");
            response.EnsureSuccessStatusCode();
            stringResponse = await response.Content.ReadAsStringAsync();
            var foundRequest = JsonConvert.DeserializeObject<RequestResourceOut>(stringResponse);
            Assert.True(foundRequest.Id == savedRequest.Id);
            Assert.Single(foundRequest.BirthDocs);
        }

        private RequestResourceIn GetRequestToSave()
        {
            return new RequestResourceIn()
            {
                Name = new RequesterNameResource
                {
                    FirstName = "first",
                    FatherName = "father",
                    GrandFatherName = "grand",
                    FamilyName = "family"
                },
                ContactDetails = new ContactDetailsResource
                {
                    Email = "a@a.a", Mobile1 = "01009868724"
                },
                ResidencyAddress = new AddressResourceIn { FlatNumber=1, FloorNumber=1, BuildingNumber="1", StreetName="1", DistrictName="1", GovernorateId=1, PoliceDepartmentId=1, PostalCodeId=1 },
                DeliveryAddress = new AddressResourceIn { FlatNumber = 1, FloorNumber = 1, BuildingNumber = "1", StreetName = "1", DistrictName = "1", GovernorateId = 1, PoliceDepartmentId = 1, PostalCodeId = 1 },
                GenderId = 1,
                MotherFullName = MOTHER_FULL_NAME,
                NID = new NIDResource { NationalIdenNumber = "27906250103655" },
                BirthDocs = new List<BirthDocResourceIn>
                {
                    new BirthDocResourceIn()
                    {
                        Name = new RequesterNameResource
                        {
                            FirstName = "first", FatherName="father", GrandFatherName="grand", FamilyName="family"
                        },
                        MotherFullName = "Fatema",
                        NumberOfCopies = 3,
                        NID = new NIDResource{NationalIdenNumber="28410071402991" },
                        GenderId = 1,
                        RelationId = 1
                    }
                }
            };
        }
    }
}
