using Grupa4_Tim1_KnjigaRecepata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Data
{
    public class DbClass
    {
        public List<Sastojak> sastojci { get; set; }
        public List<Recept> recepti { get; set; }

        public DbClass() 
        { 
            sastojci = new List<Sastojak>();
            recepti = new List<Recept>();
        }
        public void addSastojak(Sastojak sastojak)
        {
            sastojci.Add(sastojak);
        }
        public Sastojak? getSastojak(int sastojakId)
        {
            return sastojci.FirstOrDefault(s => s.id == sastojakId);
        }

        public void addRecept(Recept recept) { 
            recepti.Add(recept);
        }

        public Recept? getRecept(int receptId) {
            return recepti.FirstOrDefault(s => s.id == receptId);
        }
    }
}
