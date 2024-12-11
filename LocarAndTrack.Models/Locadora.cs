using System.ComponentModel.DataAnnotations;

namespace LocarAndTrack.Models
{
    public class Locadora
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Veiculo> Veiculos { get; set; }
    }
}
