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

        public void prikaziShoppingListu(ShoppingLista lista)
        {
            StringBuilder sb = new StringBuilder();
            double cijena=0.0;

            sb.AppendLine("Kako biste pripremili " + lista.recept.name + "potrebno je da kupite:");

            foreach (var sastojak in lista.recept.sastojci)
            {
                Sastojak s = sastojak.Key;
                double kolicina = sastojak.Value;
                cijena += kolicina * s.jedinicnaCijena;
                sb.AppendLine("- " + s.naziv + ": " + kolicina + " " + _sastojakService.dajSkracenicu(s.mjernaJedinica));

                sb.AppendLine("Ukupni trosak: " + cijena);
            }
        }
    }
}
