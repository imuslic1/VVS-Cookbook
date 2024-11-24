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

        public override bool Equals(object obj)
        {
            if (obj is Ocjena other)
            {
                return id == other.id &&
                       ocjena == other.ocjena &&
                       komentar == other.komentar;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17; 
            hash = hash * 31 + id.GetHashCode();
            hash = hash * 31 + ocjena.GetHashCode();
            hash = hash * 31 + (komentar != null ? komentar.GetHashCode() : 0);
            return hash;
        }

    }
}
