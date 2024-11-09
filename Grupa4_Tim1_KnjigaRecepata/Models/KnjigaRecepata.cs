using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Models
{
    public class KnjigaRecepata
    {
        public int id { get; set; }
        public VrstaJela tip {  get; set; }  
        public List<Recept> recepti { get; set; }
        public Boolean sortirana = false;

        public KnjigaRecepata(int id, VrstaJela tip, List<Recept> recepti) { 
            this.id = id; 
            this.tip = tip; 
            this.recepti = recepti;
        }
    }
}
