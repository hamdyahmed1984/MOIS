using Domain.Entities.Lookups;
using Persistence.EntityFrameworkDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class LookupsServiceTests : BaseEfRepositoryTestFixture
    {
        private readonly MoisContext _moisContext;
        private readonly LookupsService _lookupsService;

        public LookupsServiceTests()
        {
            _moisContext = new MoisContext(CreateNewContextOptions());
            _lookupsService = new LookupsService(_moisContext);
            PrepareData();
        }

        private void PrepareData()
        {
            if (_moisContext.Genders.Any())
            {
                _moisContext.Genders.ToList().ForEach(a => _moisContext.Genders.Remove(a));
            }
            _moisContext.Genders.AddRange(new List<Gender>()
            {
                new Gender{ Code="M", Name="Male"},
                new Gender{ Code="F", Name="Female"},
            });
            _moisContext.SaveChanges();
        }

        [Fact]
        public async Task GetLookupsTest()
        {
            var gendersFromDB = await _lookupsService.GetLookups<Gender>();
            Assert.Equal(2, gendersFromDB.Count());
        }

        [Fact]
        public async Task FindWhereTest()
        {
            var genderFromDB = await _lookupsService.FindWhere<Gender>(a => a.Code == "M");
            Assert.Equal("M", genderFromDB.Code);
        }

        [Fact]
        public async Task GetLookupsWithPredicateTest()
        {
            var gendersFromDB = await _lookupsService.GetLookups<Gender>(a => a.Code == "M", null, "", true);
            Assert.Single(gendersFromDB);
        }
    }
}
