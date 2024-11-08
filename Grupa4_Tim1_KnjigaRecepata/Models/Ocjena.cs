using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Models
{
    public class Ocjena
    {
        public int id { get; set; }
        public int ocjena { get; set; }
        public string komentar { get; set; }

        public Ocjena(int id, int ocjena, string komentar) 
        { 
            this.id = id;
            this.ocjena = ocjena;
            this.komentar = komentar;  
        }
    }
}
