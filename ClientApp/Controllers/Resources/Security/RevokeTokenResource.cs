using System.ComponentModel.DataAnnotations;

namespace ClientApp.Controllers.Resources.Security
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}