using System.ComponentModel.DataAnnotations;

namespace LocarAndTrack.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int LocadoraId { get; set; }
        public Locadora Locadora { get; set; }
        public List<Locacao> Locacoes { get; set; }
        public string Role { get; set; } = string.Empty;
        public int PerfilId { get; set; }
        public Perfil? Perfil { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}
