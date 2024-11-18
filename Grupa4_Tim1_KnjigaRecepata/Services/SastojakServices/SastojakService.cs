using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices
{
    public class SastojakService : ISastojakService
    {
        private readonly DbClass _db;

        public SastojakService(DbClass db)
        {
            _db = db;
        }

        public double dajBrojKalorijaPoJedinici(Sastojak? sastojak)
        {
            if(sastojak == null)
            {
                throw new ArgumentNullException("Nije moguce izracunati broj kalorija za ovaj sastojak!");
            }
            return sastojak.ugljikohidratiPoJedinici * 4 + sastojak.mastiPoJedinici * 9 + sastojak.proteiniPoJedinici * 4 + sastojak.vlaknaPoJedinici * 2;
        }

        public void prikaziSastojak(Sastojak? sastojak)
        {
            if (sastojak == null)
            {
                throw new ArgumentNullException(null, "Sastojak nije validan!");
            }

            StringBuilder sb = new StringBuilder();
            var culture = CultureInfo.InvariantCulture; // Use InvariantCulture to ensure dot separator
            sb.AppendLine("Sastojak: " + sastojak.naziv);
            sb.AppendLine("Nutrijenti po jedinici");
            sb.AppendLine("- ugljikohidrati: " + sastojak.ugljikohidratiPoJedinici.ToString(culture));
            sb.AppendLine("- masti: " + sastojak.mastiPoJedinici.ToString(culture));
            sb.AppendLine("- proteini: " + sastojak.proteiniPoJedinici.ToString(culture));
            sb.AppendLine("- vlakna: " + sastojak.vlaknaPoJedinici.ToString(culture));
            sb.AppendLine("- sol: " + sastojak.solPoJedinici.ToString(culture));
            sb.AppendLine("Alergeni: " + (sastojak.alergen == null ? "nema" : sastojak.alergen));

            Console.WriteLine(sb.ToString());
        }

        public string dajSkracenicu(MjernaJedinica jedinica)
        {
            return jedinica switch
            {
                MjernaJedinica.CAJNA_KASIKA => "tsp",
                MjernaJedinica.SUPENA_KASIKA => "tbsp",
                MjernaJedinica.CASA => "cup",
                MjernaJedinica.UNCA => "oz",
                MjernaJedinica.MILILITAR => "ml",
                MjernaJedinica.GRAM => "g",
                _ => ""
            };
        }
    }
}
