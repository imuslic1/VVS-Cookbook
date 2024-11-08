using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Services.ShoppingListaServices
{
    public class ShoppingListaService : IShoppingListaService
    {
        private readonly DbClass _db;

        private string DajSkracenicu(MjernaJedinica jedinica)
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

        public ShoppingListaService(DbClass db)
        {
            _db = db;
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
                sb.AppendLine("- " + s.naziv + ": " + kolicina + " " + DajSkracenicu(s.mjernaJedinica));

                sb.AppendLine("Ukupni trosak: " + cijena);
            }
        }
    }
}
