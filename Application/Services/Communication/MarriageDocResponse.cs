using Domain.Entities.Documents;

namespace Application.Services.Communication
{
    public class MarriageDocResponse : BaseResponse
    {
        public MarriageDoc MarriageDoc { get; private set; }
        private MarriageDocResponse(bool success, string message, MarriageDoc marriageDoc) : base(success, message)
        => MarriageDoc = marriageDoc;

        public MarriageDocResponse(MarriageDoc marriageDoc) : this(true, string.Empty, marriageDoc) { }
        public MarriageDocResponse(string message) : this(false, message, null) { }
    }
}
