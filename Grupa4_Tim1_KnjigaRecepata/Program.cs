using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ShoppingListaServices;
using System;
using System.Runtime.Versioning;

namespace Grupa4_Tim1_KnjigaRecepata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbClass baza = new DbClass();
            SastojakService ss = new SastojakService(baza);
            ReceptService rs = new ReceptService(baza, ss);

            // TODO: Implementacija klase "KnjigaRecepataService"
            KnjigaRecepataService kr = new KnjigaRecepataService();
            
            OcjenaService oc = new OcjenaService();
            ShoppingListaService sl = new ShoppingListaService(baza, ss);

            Sastojak sastojak1 = new Sastojak(1, "mlijeko", 4, 2, 5, 3, 4, null, 4, MjernaJedinica.CAJNA_KASIKA);
            Dictionary<Sastojak, double> sastojci = new Dictionary<Sastojak, double>();
            sastojci.Add(sastojak1, 4);

            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            List<Ocjena> ocjene = new List<Ocjena>();
            ocjene.Add(ocjena1);

            Recept recept1 = new Recept(1, "prvi", VrstaJela.PREDJELO, "...", 4, sastojci, KompleksnostPripreme.LAKO, ocjene);

            Console.WriteLine("Dobrodošli u kuharicu!");
            Console.WriteLine("Odaberite opciju: ");
            Console.WriteLine("1. Pretraga recepata po nazivu");
            Console.WriteLine("2. Pretraga recepata po ocjeni");
            Console.WriteLine("3. Odabir vrste recepta");
            Console.WriteLine("4. Dodavanje novog recepta");
            Console.WriteLine("5. Pretraga sastojka po nazivu");
            Console.WriteLine("6. Dodavanje novog sastojka");
            
            int opcija = Convert.ToInt32(Console.ReadLine());
            Meni:
            switch(opcija) {
                case 1:
                    Console.WriteLine("Unesite naziv recepta: ");
                    string naziv = Console.ReadLine();
                    // Treba da pronađe recept po nazivu i ispiše ga u konzoli ili 
                    // da ispiše poruku da recept nije pronađen (moze biti i u obliku exceptiona),
                    // a zatim da ponudi korisniku da unese novi naziv ili da odustane
                    kr.pretraziPoNazivu(naziv);
                    
                    break;
                case 2:
                    Console.WriteLine("Unesite ocjenu recepta: ");
                    int ocjena = Convert.ToInt32(Console.ReadLine());
                    // Isto kao i za pretragu po nazivu
                    kr.pretraziPoOcjeni(ocjena);
                    break;
                case 3:
                    Console.WriteLine("Unesite vrstu jela: ");
                    string vrstaJela = Console.ReadLine();
                    // Isto kao i za pretragu po nazivu
                    kr.pretraziPoVrstiJela(vrstaJela);
                    break;
                case 4:
                    Console.WriteLine("Unesite podatke za novi recept: ");
                    // Treba da omogući korisniku unos podataka za novi recept
                    // i da ga doda u bazu
                    kr.dodajRecept();
                    break;
                case 5:
                    Console.WriteLine("Unesite naziv sastojka: ");
                    string nazivSastojka = Console.ReadLine();
                    // Isto kao i za pretragu po nazivu
                    ss.pretraziPoNazivu(nazivSastojka);
                    break;
                case 6:
                    Console.WriteLine("Unesite podatke za novi sastojak: ");
                    // Treba da omogući korisniku unos podataka za novi sastojak
                    // i da ga doda u bazu
                    ss.dodajSastojak();
                    break;
                default:
                    Console.WriteLine("Unijeli ste pogrešnu opciju!");
                    goto Meni;
            }

            


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

           
            Console.WriteLine(oc.dajProsjecnuOcjenu(recept1.ocjene));
        }
    }
}