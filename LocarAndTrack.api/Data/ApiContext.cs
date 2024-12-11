
using LocarAndTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace LocarAndTrack.api.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Locadora> Locadoras { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
    }
}
