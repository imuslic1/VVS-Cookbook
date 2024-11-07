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

    }
}
