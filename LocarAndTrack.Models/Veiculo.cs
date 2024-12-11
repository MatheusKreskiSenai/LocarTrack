using System.ComponentModel.DataAnnotations;

namespace LocarAndTrack.Models
{
    public class Veiculo
    {
        [Key]
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public float PrecoDiaria { get; set; }
        public int N_Passageiros { get; set; }
        public int LocadoraId { get; set; }
        public Locadora Locadora { get; set; }
        public List<Locacao> Locacoes { get; set; }
        public string UrlCarroImage { get; set; }
    }
}
