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
    public class BirthDocControllerTests: IClassFixture<CustomWebApplicationFactory<TestingStartup>>
    {
        public BirthDocControllerTests(CustomWebApplicationFactory<TestingStartup> factory) => Client = factory.CreateClient();

        private const decimal DocPrice = 54;

        public HttpClient Client { get; }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsCorrectPrice()
        {
            var response = await Client.GetAsync("/api/birthdoc/doc-price");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var price = JsonConvert.DeserializeObject<decimal>(stringResponse);
            Assert.Equal(DocPrice, price);
        }

        [Fact]
        public async Task CreateBirthDocsAsync_ShouldReturnOkResultWithCreatedDocs()
        {
            List<BirthDocResourceIn> docs = GetDocsToSave();
            var response = await Client.PostAsJsonAsync("/api/birthdoc/create-birth-docs", docs);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var savedDocs = JsonConvert.DeserializeObject<IEnumerable<BirthDocResourceOut>>(stringResponse);
            Assert.Single(savedDocs);
        }

        private List<BirthDocResourceIn> GetDocsToSave()
        {
            return new List<BirthDocResourceIn>
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
            };
        }
    }
}
