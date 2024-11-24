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
        private readonly ISastojakService _sastojakService;

        public ReceptService(DbClass db, ISastojakService sastojakService) {
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

        public string prikazi(Recept recept) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\n\nRecept: " + recept.name);
            sb.AppendLine("Vrsta jela: " + recept.tipRecepta);
            sb.AppendLine("Vrijeme pripreme: " + recept.vrijemePripreme + " minuta");
            sb.AppendLine("Kompleksnost pripreme: " + recept.kompleksnost);
            sb.AppendLine("\nSastojci:");

            foreach (var sastojakEntry in recept.sastojci) {
                Sastojak sastojak = sastojakEntry.Key;
                double kolicina = sastojakEntry.Value;
                sb.AppendLine("- " + sastojak.naziv + ": " + kolicina + " " + _sastojakService.dajSkracenicu(sastojak.mjernaJedinica));
            }

            sb.AppendLine("Priprema: " + recept.priprema);

            sb.AppendLine("\nOcjene:");
            foreach (var ocjena in recept.ocjene) {
                sb.AppendLine("- " + ocjena.ocjena + "/5: " + ocjena.komentar);
            }

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public string prikaziAlergene(Recept recept) {
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

            return sb.ToString();
        }

        public void konvertujMjerneJedinice(Recept recept) { 
            List<Sastojak> sastojci = recept.sastojci.Keys.ToList();
            foreach (var sastojak in sastojci) {
                if (sastojak.mjernaJedinica == MjernaJedinica.CASA) {
                    double kolicina = recept.sastojci[sastojak];
                    recept.sastojci.Remove(sastojak);
                    recept.sastojci.Add(sastojak, kolicina * 236.59);
                }
                else if (sastojak.mjernaJedinica == MjernaJedinica.UNCA) {
                    double kolicina = recept.sastojci[sastojak];
                    recept.sastojci.Remove(sastojak);
                    recept.sastojci.Add(sastojak, kolicina * 29.57);
                }
            }
        }

        public void ocijeni(Recept recept, Ocjena ocjena)
        {
            if(ocjena.ocjena < 1 || ocjena.ocjena > 5)
            {
                throw new Exception("Pogresan unos");
            }
            recept.ocjene.Add(ocjena);     
        }
        
    }
}
