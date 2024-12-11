using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LocarAndTrack.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        [AllowNull]
        public List<Locacao> Locacoes { get; set; }
        public string Role { get; set; } = string.Empty;
        public int PerfilId { get; set; }
        public Perfil? Perfil { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }

}
