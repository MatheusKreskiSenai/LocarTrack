using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocarAndTrack.Models
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = string.Empty;
        public int PerfilId { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
