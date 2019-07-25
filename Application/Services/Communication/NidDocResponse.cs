
using Domain.Entities.Documents;

namespace Application.Services.Communication
{
    public class NidDocResponse : BaseResponse
    {
        public NidDoc NidDoc { get; private set; }
        private NidDocResponse(bool success, string message, NidDoc nationalIdenNumber) : base(success, message) => NidDoc = nationalIdenNumber;
        public NidDocResponse(NidDoc nationalIdenNumber) : this(true, string.Empty, nationalIdenNumber) { }
        public NidDocResponse(string message) : this(false, message, null) { }
    }
}
