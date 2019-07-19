using Domain.Entities.Lookups;
using System.Collections.Generic;

namespace ClientApp.Controllers.Resources
{
    public class RequestStateResource
    {
        public int Id { get; set; }
        public State State { get; set; }

        public IEnumerable<BirthDocStateResource> BirthDocs { get; set; }
        public IEnumerable<DeathDocStateResource> DeathDocs { get; set; }
        public IEnumerable<MarriageDocStateResource> MarriageDocs { get; set; }
        public IEnumerable<DivorceDocStateResource> DivorceDocs { get; set; }
        public IEnumerable<NidDocStateResource> NidDoc { get; set; }
    }
}
