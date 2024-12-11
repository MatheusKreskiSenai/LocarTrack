using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocarAndTrack.Models
{
    public class LocacaoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLocacao { get; set; }
        public int QtdDias { get; set; }
        public float Preco { get; set; }
        public int ClienteId { get; set; }
        public string VeiculoPlaca { get; set; }
    }
}
