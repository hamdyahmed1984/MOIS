using Domain.Entities.Documents;

namespace Application.Services.Communication
{
    public class BirthDocResponse : BaseResponse
    {
        public BirthDoc BirthDoc { get; private set; }
        private BirthDocResponse(bool success, string message, BirthDoc birthDoc) : base(success, message)
        {
            BirthDoc = birthDoc;
        }
        public BirthDocResponse(BirthDoc birthDoc) : this(true, string.Empty, birthDoc) { }
        public BirthDocResponse(string message) : this(false, message, null) { }
    }
}
