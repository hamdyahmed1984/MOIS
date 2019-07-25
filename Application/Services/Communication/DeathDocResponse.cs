
using Domain.Entities.Documents;

namespace Application.Services.Communication
{
    public class DeathDocResponse : BaseResponse
    {
        public DeathDoc DeathDoc { get; private set; }
        private DeathDocResponse(bool success, string message, DeathDoc deathRecord) : base(success, message)
        => DeathDoc = deathRecord;
        public DeathDocResponse(DeathDoc deathRecord) : this(true, string.Empty, deathRecord) { }
        public DeathDocResponse(string message) : this(false, message, null) { }
    }
}
