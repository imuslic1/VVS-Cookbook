using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using System;
using System.Collections.Generic;
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

        public double dajBrojKalorijaPoJedinici(Sastojak sastojak)
        {
            return sastojak.ugljikohidratiPoJedinici * 4 + sastojak.mastiPoJedinici * 9 + sastojak.proteiniPoJedinici * 4 + sastojak.vlaknaPoJedinici * 2;
        }

        public void prikaziSastojak(Sastojak sastojak)
        {
            Console.WriteLine("Sastojak: " + sastojak.naziv + "\nNutrijenti po jedinici\n- ugljikohidrati: " + sastojak.ugljikohidratiPoJedinici
                + "\n- masti: " + sastojak.mastiPoJedinici + "\n- proteini: " + sastojak.proteiniPoJedinici 
                + "\n- vlakna: " + sastojak.vlaknaPoJedinici + "\n- sol: " + sastojak.solPoJedinici + "\nAlergeni: "
                + (sastojak.alergen == null ? "nema" : sastojak.alergen));
        }
    }
}
