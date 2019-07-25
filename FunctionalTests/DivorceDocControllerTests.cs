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
    public class DivorceDocControllerTests : IClassFixture<CustomWebApplicationFactory<TestingStartup>>
    {
        public DivorceDocControllerTests(CustomWebApplicationFactory<TestingStartup> factory) => Client = factory.CreateClient();

        private const decimal DocPrice = 59;

        public HttpClient Client { get; }

        [Fact]
        public async Task GetDocPriceAsync_ReturnsCorrectPrice()
        {
            var response = await Client.GetAsync("/api/divorcedoc/doc-price");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var price = JsonConvert.DeserializeObject<decimal>(stringResponse);
            Assert.Equal(DocPrice, price);
        }

        [Fact]
        public async Task CreateDivorceDocsAsync_ShouldReturnOkResultWithCreatedDocs()
        {
            List<MarriageDocResourceIn> docs = GetDocsToSave();
            var response = await Client.PostAsJsonAsync("/api/divorcedoc/create-divorce-docs", docs);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var savedDocs = JsonConvert.DeserializeObject<IEnumerable<MarriageDocResourceOut>>(stringResponse);
            Assert.Single(savedDocs);
        }

        private List<MarriageDocResourceIn> GetDocsToSave()
        {
            return new List<MarriageDocResourceIn>
            {
                new MarriageDocResourceIn()
                {
                    Name = new RequesterNameResource
                    {
                        FirstName = "first", FatherName="father", GrandFatherName="grand", FamilyName="family"
                    },
                    SpouseFullName = "Fatema",
                    NumberOfCopies = 3,
                    NID = new NIDResource{NationalIdenNumber="28410071402991" },
                    RelationId = 1
                }
            };
        }
    }
}
