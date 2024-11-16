using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;

namespace Grupa4_Tim1_KnjigaRecepata.Services.ShoppingListaServices
{
    public class ShoppingListaService : IShoppingListaService
    {
        private readonly DbClass _db;
        private readonly SastojakService _sastojakService;

        public ShoppingListaService(DbClass db, SastojakService sastojakService)
        {
            _db = db;
            _sastojakService = sastojakService;
        }

        public double cijenaSastojaka(Recept recept)
        {
            double suma = 0.0;

            foreach (var sastojak in recept.sastojci)
            {
                Sastojak s = sastojak.Key;
                suma += s.jedinicnaCijena * sastojak.Value;
            }

            return suma;
        }

        public string prikaziShoppingListu(ShoppingLista lista)
        {
            StringBuilder sb = new StringBuilder();

            if (lista.recept.sastojci == null || lista.recept.sastojci.Count == 0)
                throw new ArgumentException("Nemoguce izracunati cijenu - lista sastojaka je prazna");

            sb.AppendLine("Kako biste pripremili " + lista.recept.name + " potrebno je da kupite:");

            foreach (var sastojak in lista.recept.sastojci)
            {
                Sastojak s = sastojak.Key;
                double kolicina = sastojak.Value;
                sb.AppendLine("- " + s.naziv + ": " + kolicina + " " + _sastojakService.dajSkracenicu(s.mjernaJedinica));
            }

            sb.AppendLine("Ukupni trosak: " + cijenaSastojaka(lista.recept));

            return sb.ToString();
        }
    }
}
