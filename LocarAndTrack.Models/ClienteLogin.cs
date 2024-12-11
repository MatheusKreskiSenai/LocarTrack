using System.ComponentModel.DataAnnotations;
namespace LocarAndTrack.Models
{
    public class ClienteLogin
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória.")]
        public string Password { get; set; } = string.Empty;
    }
}
