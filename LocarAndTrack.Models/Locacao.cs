using System.ComponentModel.DataAnnotations;

namespace LocarAndTrack.Models
{
    public class Locacao
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLocacao { get; set; }
        public float Preco { get; set; }
        public int QtdDias { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string VeiculoPlaca { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
