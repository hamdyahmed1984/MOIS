using Domain.Entities.Documents;

namespace Application.Services.Communication
{
    public class DivorceDocResponse : BaseResponse
    {
        public DivorceDoc DivorceDoc { get; private set; }
        private DivorceDocResponse(bool success, string message, DivorceDoc divorceDoc) : base(success, message)
        {
            DivorceDoc = divorceDoc;
        }
        public DivorceDocResponse(DivorceDoc divorceDoc) : this(true, string.Empty, divorceDoc) { }
        public DivorceDocResponse(string message) : this(false, message, null) { }
    }
}
