using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocarAndTrack.Models
{
    public class VeiculoModel
    {
        [Key]
        public string Placa { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public float PrecoDiaria { get; set; } = float.MinValue;
        public int N_Passageiros { get; set; } = int.MinValue;
        public string UrlCarroImage { get; set; } = string.Empty;
    }
}
