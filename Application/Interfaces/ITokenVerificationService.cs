using Domain.VerificationPlatform;

namespace Application.Interfaces
{
    public interface ITokenVerificationService
    {
        VerificationModel ValidateLogin(string email, string token);
        VerificationModel ValidateLogin_Test(string email, string token);
    }
}
