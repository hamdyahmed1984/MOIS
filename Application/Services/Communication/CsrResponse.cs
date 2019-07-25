using Domain.Entities.Documents;

namespace Application.Services.Communication
{
    public class CsrResponse : BaseResponse
    {
        public CriminalStateRecord CSR { get; private set; }
        private CsrResponse(bool success, string message, CriminalStateRecord csr) : base(success, message)
        => CSR = csr;
        
        public CsrResponse(CriminalStateRecord csr) : this(true, string.Empty, csr) { }
        public CsrResponse(string message) : this(false, message, null) { }
    }
}
