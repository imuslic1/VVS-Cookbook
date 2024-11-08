using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using System;
using System.Runtime.Versioning;

namespace Grupa4_Tim1_KnjigaRecepata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sastojak sastojak1 = new Sastojak(1, "mlijeko", 4, 2, 5, 3, 4, null, 4, MjernaJedinica.CAJNA_KASIKA);
            Dictionary<Sastojak, double> sastojci = new Dictionary<Sastojak, double>();
            sastojci.Add(sastojak1, 4);

            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            List<Ocjena> ocjene = new List<Ocjena>();
            ocjene.Add(ocjena1);
            
            DbClass baza = new DbClass();
            SastojakService ss = new SastojakService(baza);
            ReceptService rs = new ReceptService(baza, ss);

            Recept recept1 = new Recept(1, "prvi", VrstaJela.PREDJELO, "...", 4, sastojci, KompleksnostPripreme.LAKO, ocjene);

            /* ---- Ovaj dio moze ostati za konzolnu ---- */
            Console.WriteLine("Želite li ocijeniti odabrani recept (DA/NE): ");
            string unos = Console.ReadLine();

            if(unos == "DA")
            {
                rs.ocijeni(recept1);
            }

            /* -------- */
            
            for (int i = 0; i < recept1.ocjene.Count; i++)
            {
                Console.WriteLine(recept1.ocjene[i].ocjena);
                Console.WriteLine(recept1.ocjene[i].komentar);
            }

            OcjenaService oc = new OcjenaService();
            Console.WriteLine(oc.dajProsjecnuOcjenu(recept1.ocjene));
        }
    }
}