using Application.Services.Communication;
using Domain.Entities.Security;

namespace Application.Security.Services.Communication
{
    public class CreateUserResponse : BaseResponse
    {
        public User User { get; private set; }

        public CreateUserResponse(bool success, string message, User user) : base(success, message) => User = user;
    }
}
