using Domain.Entities.Lookups;

namespace ClientApp.Controllers.Resources
{
    public class DocResource
    {
        public virtual int Id { get; set; }
        public virtual State State { get; set; }
    }
    public class BirthDocStateResource : DocResource { }   
    public class DeathDocStateResource : DocResource { }
    public class MarriageDocStateResource : DocResource { }
    public class DivorceDocStateResource : DocResource { }
    public class NidDocStateResource : DocResource { }
}
