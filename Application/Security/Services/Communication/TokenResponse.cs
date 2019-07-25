using Application.Security.Tokens;
using Application.Services.Communication;

namespace Application.Security.Services.Communication
{
    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set; }

        public TokenResponse(bool success, string message, AccessToken token) : base(success, message) => Token = token;
    }
}
