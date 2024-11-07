using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices {
    public class ReceptService : IReceptService {
        private readonly DbClass _db;
        private readonly SastojakService _sastojakService;

        private string DajSkracenicu(MjernaJedinica jedinica) {
            return jedinica switch {
                MjernaJedinica.CAJNA_KASIKA => "tsp",
                MjernaJedinica.SUPENA_KASIKA => "tbsp",
                MjernaJedinica.CASA => "cup",
                MjernaJedinica.UNCA => "oz",
                MjernaJedinica.MILILITAR => "ml",
                MjernaJedinica.GRAM => "g",
                _ => ""
            };
        }

        public ReceptService(DbClass db, SastojakService sastojakService) {
            _db = db;
            _sastojakService = sastojakService;
        }
        public double dajUkupanBrojKalorija(Recept recept) {
            double ukupanBrojKalorija = 0;
            foreach (var sastojakEntry in recept.sastojci) {
                Sastojak sastojak = sastojakEntry.Key;
                double kolicina = sastojakEntry.Value;

                ukupanBrojKalorija += _sastojakService.dajBrojKalorijaPoJedinici(sastojak) * kolicina;
            }

            return ukupanBrojKalorija;
        }

        public void prikazi(Recept recept) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Recept: " + recept.name);
            sb.AppendLine("Vrsta jela: " + recept.tipRecepta);
            sb.AppendLine("Vrijeme pripreme: " + recept.vrijemePripreme + " minuta");
            sb.AppendLine("Kompleksnost pripreme: " + recept.kompleksnost);
            sb.AppendLine("\nSastojci:");

            foreach (var sastojakEntry in recept.sastojci) {
                Sastojak sastojak = sastojakEntry.Key;
                double kolicina = sastojakEntry.Value;
                sb.AppendLine("- " + sastojak.naziv + ": " + kolicina + " " + DajSkracenicu(sastojak.mjernaJedinica));
            }

            sb.AppendLine("Priprema: " + recept.priprema);

            // TODO: dovrsiti implementaciju za ispis podataka o ocjeni
            //       kada klasa "Ocjena" bude zavrsena


            Console.WriteLine(sb.ToString());
        }

        public void prikaziAlergene(Recept recept) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** ALERGENI ***");

            HashSet<Alergen> alergeni = new HashSet<Alergen>();

            foreach(var sastojakEntry in recept.sastojci) {
                Sastojak sastojak = sastojakEntry.Key;

                if(sastojak.alergen.HasValue)
                    alergeni.Add(sastojak.alergen.Value);
            }

            if (alergeni.Contains(Alergen.LAKTOZA)) sb.AppendLine("- LAKTOZA");
            if (alergeni.Contains(Alergen.GLUTEN)) sb.AppendLine("- GLUTEN");
            if (alergeni.Contains(Alergen.ORASASTI_PLODOVI)) sb.AppendLine("- ORASASTI PLODOVI");
            if (alergeni.Contains(Alergen.MED)) sb.AppendLine("- MED");

            Console.WriteLine(sb.ToString());
        }

        public void konvertujMjerneJedinice(Recept recept) {
            // TODO: maybe implementirati sa jos jednim enumom {IMPERIAL, METRIC} 
            //       kao parametrom u klasi Recept. Na taj nacin bi se mogao mijenjati ispis
            //       mjerne jedinice prilikom ispisa recepta a preracunavanje jedinica bi se moglo 
            //       raditi pomocnom private metodom u klasi Recept.
        }
        
    }
}
