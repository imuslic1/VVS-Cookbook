using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Models {
    public class Recept {
        public int id { get; set; }
        public string name { get; set; }
        public VrstaJela tipRecepta { get; set; }
        public string priprema { get; set; }
        public int vrijemePripreme { get; set; }
        public Dictionary<Sastojak, double> sastojci {  get; set; }
        public KompleksnostPripreme kompleksnost {  get; set; }
        // TODO: Implementacija klase "Ocjena"
        public List<Ocjena> ocjene { get; set; }

        public Recept(int id, string name, VrstaJela tipRecepta, string priprema,
                      int vrijemePripreme, Dictionary<Sastojak, double> sastojci,
                      KompleksnostPripreme kompleksnost, List<Ocjena> ocjene) 
        {
            this.id = id;
            this.name = name;
            this.tipRecepta = tipRecepta;
            this.priprema = priprema;
            this.vrijemePripreme = vrijemePripreme;
            this.sastojci = sastojci;
            this.kompleksnost = kompleksnost;
            this.ocjene = ocjene;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Recept)obj;

            return id == other.id &&
                   name == other.name &&
                   tipRecepta.Equals(other.tipRecepta) &&
                   priprema == other.priprema &&
                   vrijemePripreme == other.vrijemePripreme &&
                   sastojci.SequenceEqual(other.sastojci) &&
                   kompleksnost.Equals(other.kompleksnost) &&
                   ocjene.SequenceEqual(other.ocjene);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + id.GetHashCode();
            hash = hash * 23 + (name?.GetHashCode() ?? 0);
            hash = hash * 23 + (tipRecepta.GetHashCode());
            hash = hash * 23 + (priprema?.GetHashCode() ?? 0);
            hash = hash * 23 + vrijemePripreme.GetHashCode();
            hash = hash * 23 + (sastojci?.GetHashCode() ?? 0);
            hash = hash * 23 + (kompleksnost.GetHashCode());
            hash = hash * 23 + (ocjene?.GetHashCode() ?? 0);
            return hash;
        }

    }
}
