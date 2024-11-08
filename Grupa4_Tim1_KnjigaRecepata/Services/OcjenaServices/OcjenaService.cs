using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupa4_Tim1_KnjigaRecepata.Models;

namespace Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices
{
    public class OcjenaService : IOcjenaService
    {
        public double dajProsjecnuOcjenu(List<Ocjena> ocjene)
        {
            double suma = 0;
            for (int i = 0; i < ocjene.Count; i++)
            {
                suma += ocjene[i].ocjena;
            }

            if (ocjene.Count > 0)
            {
                suma /= ocjene.Count;
            }

            return suma;
        }

        public void dodajOcjenu(Recept recept, Ocjena ocjena)
        {
            recept.ocjene.Add(ocjena);
        }
    }
}
