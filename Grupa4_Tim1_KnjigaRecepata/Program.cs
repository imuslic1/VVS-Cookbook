using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.KnjigaRecepataServices;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ShoppingListaServices;
using System;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;

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

            OcjenaService oc = new OcjenaService();
            ShoppingListaService sl = new ShoppingListaService(baza, ss);
            KnjigaRecepataService kr = new KnjigaRecepataService(baza, rs, oc);

            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            Ocjena ocjena3 = new Ocjena(2, 2, "...");
            Ocjena ocjena4 = new Ocjena(2, 1, "...");
            Ocjena ocjena5 = new Ocjena(2, 4, "...");

            var ocjene1 = new List<Ocjena> { ocjena1, ocjena2, ocjena3 };
            var ocjene2 = new List<Ocjena> { ocjena3, ocjena4, ocjena5 };
            var ocjene3 = new List<Ocjena> { ocjena5, ocjena1, ocjena4 };
            var ocjene4 = new List<Ocjena> { ocjena3 };
            var ocjene5 = new List<Ocjena> { ocjena5 };
            var ocjene6 = new List<Ocjena> { ocjena2, ocjena2, ocjena3, ocjena5 };

            //Random nekih 10 sastojaka da mogu koristiti za različite recepte
            var sastojci = new List<Sastojak>{
            new Sastojak(1, "Brašno", 76.3, 1.0, 10.0, 2.7, 0.02, Alergen.GLUTEN, 0.5, MjernaJedinica.GRAM),
            new Sastojak(2, "Šećer", 99.8, 0.0, 0.0, 0.0, 0.01, null, 0.4, MjernaJedinica.GRAM),
            new Sastojak(3, "Maslac", 0.8, 81.0, 1.0, 0.0, 0.02, Alergen.LAKTOZA, 1.5, MjernaJedinica.GRAM),
            new Sastojak(4, "Med", 82.4, 0.0, 0.3, 0.2, 0.02, Alergen.MED, 2.0, MjernaJedinica.SUPENA_KASIKA),
            new Sastojak(5, "Mlijeko", 4.8, 3.4, 3.3, 0.0, 0.05, Alergen.LAKTOZA, 0.8, MjernaJedinica.MILILITAR),
            new Sastojak(6, "Piletina", 0.0, 3.6, 31.0, 0.0, 0.1, null, 2.0, MjernaJedinica.GRAM),
            new Sastojak(7, "Sol", 0.0, 0.0, 0.0, 0.0, 99.0, null, 0.05, MjernaJedinica.CAJNA_KASIKA),
            new Sastojak(8, "Bademi", 21.6, 49.4, 21.2, 12.5, 0.01, Alergen.ORASASTI_PLODOVI, 5.0, MjernaJedinica.GRAM),
            new Sastojak(9, "Luk", 9.3, 0.1, 1.1, 1.7, 0.01, null, 0.2, MjernaJedinica.GRAM),
            new Sastojak(10, "Rajčica", 3.9, 0.2, 0.9, 1.2, 0.02, null, 0.3, MjernaJedinica.GRAM)
            };

            var recepti = new List<Recept>
{
    new Recept(1, "Palacinke", VrstaJela.DESERT,
        "Pomiješajte sastojke, ispecite na tavi.", 15,
        new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[1], 50 }, { sastojci[3], 1 }, { sastojci[5], 200 } },
        KompleksnostPripreme.LAKO, ocjene1),

    new Recept(2, "Pohovana piletina", VrstaJela.GLAVNO_JELO,
        "Pohujte piletinu s brašnom i jajima, pržite do zlatne boje.", 30,
        new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[4], 1 }, { sastojci[6], 1 }, { sastojci[5], 150 } },
        KompleksnostPripreme.SREDNJE_TESKO, ocjene3),

    new Recept(3, "Salata od rajcice", VrstaJela.SALATA,
        "Nasjeckajte rajčicu i luk, začinite solju.", 10,
        new Dictionary<Sastojak, double> { { sastojci[9], 100 }, { sastojci[8], 20 }, { sastojci[6], 0.5 } },
        KompleksnostPripreme.LAKO, ocjene5),

    new Recept(4, "Rižoto sa safranom", VrstaJela.GLAVNO_JELO,
        "Pirjajte rižu, dodajte šafran i vodu, kuhajte do mekane teksture.", 40,
        new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[6], 1 }, { sastojci[7], 20 } },
        KompleksnostPripreme.SREDNJE_TESKO, ocjene4),

    new Recept(5, "Medeni kolacici", VrstaJela.DESERT,
        "Pomiješajte sastojke i pecite 15 minuta.", 25,
        new Dictionary<Sastojak, double> { { sastojci[3], 50 }, { sastojci[0], 100 }, { sastojci[1], 50 }, { sastojci[2], 20 } },
        KompleksnostPripreme.LAKO, ocjene3),

    new Recept(6, "Juha od povrca", VrstaJela.PREDJELO,
        "Kuhajte povrće u vodi s dodatkom soli.", 20,
        new Dictionary<Sastojak, double> { { sastojci[8], 50 }, { sastojci[9], 50 }, { sastojci[6], 0.5 } },
        KompleksnostPripreme.LAKO, ocjene2),

    new Recept(7, "Omlet sa sirom", VrstaJela.PREDJELO,
        "Izmiksajte jaja i sir, pecite u tavi.", 10,
        new Dictionary<Sastojak, double> { { sastojci[3], 2 }, { sastojci[7], 30 }, { sastojci[6], 0.5 } },
        KompleksnostPripreme.LAKO, ocjene3),

    new Recept(8, "Smoothie od bademovog mlijeka", VrstaJela.DESERT,
        "Pomiješajte sastojke u blenderu.", 5,
        new Dictionary<Sastojak, double> { { sastojci[5], 200 }, { sastojci[7], 50 } },
        KompleksnostPripreme.LAKO, ocjene2),

    new Recept(9, "Peceni krompirici", VrstaJela.PRILOG,
        "Ispecite krumpiriće u pećnici uz dodatak soli.", 30,
        new Dictionary<Sastojak, double> { { sastojci[6], 1 } },
        KompleksnostPripreme.LAKO, ocjene1),

    new Recept(10, "Spageti sa maslacem i cesnjakom", VrstaJela.GLAVNO_JELO,
        "Skuhajte špagete, pomiješajte s maslacem i češnjakom.", 20,
        new Dictionary<Sastojak, double> { { sastojci[2], 30 }, { sastojci[6], 0.5 } },
        KompleksnostPripreme.LAKO, ocjene6),

    new Recept(11, "Bademova torta", VrstaJela.DESERT,
        "Pomiješajte bademe s brašnom i jajima, pecite.", 50,
        new Dictionary<Sastojak, double> { { sastojci[7], 100 }, { sastojci[0], 100 }, { sastojci[4], 1 } },
        KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),

    new Recept(12, "Supa od rajcice", VrstaJela.PREDJELO,
        "Pirjajte rajčice, dodajte vodu i začine.", 20,
        new Dictionary<Sastojak, double> { { sastojci[9], 200 }, { sastojci[6], 1 } },
        KompleksnostPripreme.LAKO, ocjene4),

    new Recept(13, "Salata od badema i spinata", VrstaJela.SALATA,
        "Pomiješajte špinat i bademe, začinite po želji.", 10,
        new Dictionary<Sastojak, double> { { sastojci[7], 30 }, { sastojci[8], 50 } },
        KompleksnostPripreme.LAKO, ocjene5),

    new Recept(14, "Strudla od jabuka", VrstaJela.DESERT,
        "Pomiješajte sastojke, pecite dok ne porumeni.", 40,
        new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[1], 50 }, { sastojci[2], 50 } },
        KompleksnostPripreme.SREDNJE_TESKO, ocjene5),

    new Recept(15, "Riza sa povrcem", VrstaJela.PRILOG,
        "Kuhajte rižu s povrćem dok ne omekša.", 30,
        new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[8], 50 }, { sastojci[9], 50 } },
        KompleksnostPripreme.SREDNJE_TESKO, ocjene1),

    new Recept(16, "Cokoladni kolac", VrstaJela.DESERT,
        "Pomiješajte sastojke, pecite na 180°C.", 45,
        new Dictionary<Sastojak, double> { { sastojci[0], 150 }, { sastojci[1], 100 }, { sastojci[2], 30 }, { sastojci[3], 1 } },
        KompleksnostPripreme.SREDNJE_TESKO, ocjene2),

    new Recept(17, "Tjestenina Carbonara", VrstaJela.GLAVNO_JELO,
        "Skuhajte tjesteninu, dodajte slaninu, sir i jaja.", 25,
        new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[4], 1 }, { sastojci[7], 30 } },
        KompleksnostPripreme.SREDNJE_TESKO, ocjene1),

    new Recept(18, "Muffini sa borovnicama", VrstaJela.DESERT,
        "Pomiješajte sastojke, dodajte borovnice, pecite.", 35,
        new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[1], 50 }, { sastojci[3], 1 } },
        KompleksnostPripreme.TESKO, ocjene2),

    new Recept(19, "Vege burger", VrstaJela.GLAVNO_JELO,
        "Pomiješajte povrće i brašno, oblikujte i pržite.", 20,
        new Dictionary<Sastojak, double> { { sastojci[8], 50 }, { sastojci[9], 50 }, { sastojci[0], 50 } },
        KompleksnostPripreme.PROFESIONALAC, ocjene4),

    new Recept(20, "Sos Bolognese", VrstaJela.GLAVNO_JELO,
        "Pirjajte povrće i meso, kuhajte uz dodatak rajčice.", 30,
        new Dictionary<Sastojak, double> { { sastojci[9], 100 }, { sastojci[8], 50 }, { sastojci[6], 1 } },
        KompleksnostPripreme.PROFESIONALAC, ocjene6)
};


            var knjigeRecepata = new List<KnjigaRecepata>
{
    // Knjiga recepata za PREDJELO
    new KnjigaRecepata(
        1,
        VrstaJela.PREDJELO,
        recepti.Where(r => r.tipRecepta == VrstaJela.PREDJELO).ToList()
    ),
    
    // Knjiga recepata za GLAVNO JELO
    new KnjigaRecepata(
        2,
        VrstaJela.GLAVNO_JELO,
        recepti.Where(r => r.tipRecepta == VrstaJela.GLAVNO_JELO).ToList()
    ),

    // Knjiga recepata za DESERT
    new KnjigaRecepata(
        3,
        VrstaJela.DESERT,
        recepti.Where(r => r.tipRecepta == VrstaJela.DESERT).ToList()
    ),

    // Knjiga recepata za PRILOG
    new KnjigaRecepata(
        4,
        VrstaJela.PRILOG,
        recepti.Where(r => r.tipRecepta == VrstaJela.PRILOG).ToList()
    ),

    // Knjiga recepata za SALATA
    new KnjigaRecepata(
        5,
        VrstaJela.SALATA,
        recepti.Where(r => r.tipRecepta == VrstaJela.SALATA).ToList()
    )
};

            int ispisMenija(string tipKnjige) {

                Console.WriteLine($"\nOdabrali ste knjigu sa {tipKnjige}.\n");
                Console.WriteLine("1. Pretraga recepata po nazivu");
                Console.WriteLine("2. Ocjeni recept po nazivu");
                Console.WriteLine("3. Dodavanje novog recepta");
                Console.WriteLine("4. Pretraga sastojka po nazivu");
                Console.WriteLine("5. Dodavanje novog sastojka");
                Console.WriteLine("6. Pretraga recepata po ocjeni");
                Console.WriteLine("7. Ispiši trenutnu knjigu recepata");
                Console.WriteLine("8. Ispiši trenutnu knjigu recepata sortiranu prema vremenu pripreme");
                Console.WriteLine("9. Ispiši trenutnu knjigu recepata sortiranu prema kompleksnosti");
                Console.WriteLine("\n0. Povratak na početni meni");
                return Convert.ToInt32(Console.ReadLine());
            }

            void drugiMeni(int drugaOpcija, int indeksTrenutneKnjige) {
                switch (drugaOpcija)
                {
                    case 1:
                        Console.WriteLine("Unesite naziv recepta: ");
                        string naziv;
                        // Treba da pronađe recept po nazivu i ispiše ga u konzoli ili 
                        // da ispiše poruku da recept nije pronađen (moze biti i u obliku exceptiona),
                        // a zatim da ponudi korisniku da unese novi naziv ili da odustane
                        Boolean korektanNaziv = false;
                        while (!korektanNaziv)
                        {
                            try
                            {
                                naziv = Convert.ToString(Console.ReadLine());
                                if (naziv == "0") break;
                                var pronadjeniRecept = kr.pretraziKnjiguRecepata(knjigeRecepata[indeksTrenutneKnjige], naziv);
                                rs.prikazi(pronadjeniRecept);
                                korektanNaziv = true;

                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); Console.WriteLine("Unesite ponovno naziv recepta ili unesite 0 za prekid: "); }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Unesite naziv recepta: ");
                        Boolean korektanNaziv2 = false;
                        Recept trazeniRecept = null;
                        while (!korektanNaziv2)
                        {
                            try
                            {
                                naziv = Convert.ToString(Console.ReadLine());
                                trazeniRecept = kr.pretraziKnjiguRecepata(knjigeRecepata[indeksTrenutneKnjige], naziv);
                                korektanNaziv2 = true;

                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); Console.WriteLine("Unesite ponovno naziv recepta: "); }
                        }
                        Console.WriteLine("Unesite ocjenu recepta: ");
                        int ocjena = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Unesite komentar uz Vašu ocjenu: ");
                        string komentar = Convert.ToString(Console.ReadLine());
                        oc.dodajOcjenu(trazeniRecept, new Ocjena(new Random().Next(), ocjena, komentar));
                        break;
                    case 3:
                        Console.WriteLine("Unesite podatke za novi recept: ");
                        Console.WriteLine("Unesite naziv recepta: ");
                        string imeRecepta = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Izaberite jedan od tipova recepta (predjelo, glavno jelo, desert, prilog ili salata): ");
                        string tipRecepta = Convert.ToString(Console.ReadLine());
                        tipRecepta = tipRecepta.ToLower();
                        VrstaJela tipReceptaEnum = VrstaJela.PRILOG;
                        switch (tipRecepta)
                        {
                            case "predjelo":
                                tipReceptaEnum = VrstaJela.PREDJELO;
                                break;
                            case "glavno jelo":
                                tipReceptaEnum = VrstaJela.GLAVNO_JELO;
                                break;
                            case "desert":
                                tipReceptaEnum = VrstaJela.DESERT;
                                break;
                            case "prilog":
                                tipReceptaEnum = VrstaJela.PRILOG;
                                break;
                            case "salata":
                                tipReceptaEnum = VrstaJela.SALATA;
                                break;
                            default:
                                Console.WriteLine("Pogrešan tip jela");
                                break;
                        }
                        Console.WriteLine("Unesite napomenu koja će pomoći tokom same pripreme jela: ");
                        string napomena = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Unesite vrijeme pripreme: ");
                        int vrijemePripreme = Convert.ToInt32(Console.ReadLine());
                        //While
                        
                        Console.WriteLine($"Unesite indekse (od 1 do {sastojci.Count}) koje sastojke vaš recept uključuje, te unesite količinu potrebnu za Vaš recept (kada ste završili, unesite 0): ");
                        int indeksSastojka = Convert.ToInt32(Console.ReadLine());
                        double kolicina;
                        var noviSastojci = new Dictionary<Sastojak, double>();
                        while (indeksSastojka > 0 && indeksSastojka <= sastojci.Count)
                        {
                            Console.WriteLine("Unesite potrebnu količinu sastojka (u gramima): ");
                            kolicina = Convert.ToDouble(Console.ReadLine());
                            noviSastojci.Add(sastojci[indeksSastojka], kolicina);
                            Console.WriteLine($"Unesite indekse (od 1 do {sastojci.Count}) koje sastojke vaš recept uključuje, te unesite količinu potrebnu za Vaš recept (kada ste završili, unesite 0): ");
                            indeksSastojka = Convert.ToInt32(Console.ReadLine());

                        }
                        Console.WriteLine("Unesite kompleksnost pripreme (lako, srednje, tesko, profesionalac): ");
                        string kompleksnostPripreme = Console.ReadLine();
                        kompleksnostPripreme = kompleksnostPripreme.ToLower();
                        KompleksnostPripreme kompleksnostEnum = KompleksnostPripreme.LAKO;
                        switch (kompleksnostPripreme)
                        {
                            case "lako":
                                kompleksnostEnum = KompleksnostPripreme.LAKO;
                                break;
                            case "srednje":
                                kompleksnostEnum = KompleksnostPripreme.SREDNJE_TESKO;
                                break;
                            case "tesko":
                                kompleksnostEnum = KompleksnostPripreme.TESKO;
                                break;
                            case "profesionalac":
                                kompleksnostEnum = KompleksnostPripreme.PROFESIONALAC;
                                break;
                            default:
                                Console.WriteLine("Pogrešno unesena kompleksnost pripreme!");
                                break;
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            if (knjigeRecepata[i].tip == tipReceptaEnum)
                            {
                                Recept noviRecept = new Recept(new Random().Next(), imeRecepta, tipReceptaEnum, napomena, vrijemePripreme, noviSastojci, kompleksnostEnum, new List<Ocjena>());
                                kr.dodajRecept(knjigeRecepata[i],noviRecept);
                                recepti.Add(noviRecept);
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Unesite naziv sastojka: ");
                        string nazivSastojka = null;
                        korektanNaziv = false;
                        while (!korektanNaziv) {
                            try
                            {
                                Sastojak trazeniSastojak = null;
                                nazivSastojka = Console.ReadLine();
                                for (int i = 0; i < sastojci.Count; i++) {
                                    if (sastojci[i].naziv == nazivSastojka) { 
                                        trazeniSastojak = sastojci[i];
                                        korektanNaziv = true;
                                        break;
                                    }
                                }
                                if (trazeniSastojak != null) { 
                                    ss.prikaziSastojak(trazeniSastojak);
                                }
                                else {
                                    Console.WriteLine("Takav sastojak ne postoji u našoj bazi!");
                                    Console.WriteLine("Unesite ponovo naziv: ");
                                }
                            }
                            catch(Exception ex)
                            {
                                //hendlovanoo!!!
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Unesite podatke za novi sastojak: ");
                        Console.WriteLine("Unesite naziv sastojka: ");
                        string noviNaziv = Console.ReadLine();
                        Console.WriteLine("Unesite količinu ugljikohidrata po gramu: ");
                        double ugljikohidratiPoG = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Unesite količinu masti po gramu: ");
                        double mastiPoG = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Unesite količinu proteina po gramu: ");
                        double proteiniPoG = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Unesite količinu vlakna po gramu: ");
                        double vlaknaPoG = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Unesite količinu soli po gramu: ");
                        double solPoG = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Da li vaš sastojak sadrži neki alergen? (DA ili NE)");
                        string alerg = Console.ReadLine();
                        Alergen? alergenEnum = null;
                        if (alerg.ToLower() == "da")
                        {
                            Console.WriteLine("Unesite koji alergen vaš sastojak sadrži? (laktoza, gluten, orasasti plodovi ili med)");
                            string alergen = Console.ReadLine();
                            alergen = alergen.ToLower();
                            switch (alergen) {
                                case "laktoza":
                                    alergenEnum = Alergen.LAKTOZA;
                                    break;
                                case "med":
                                    alergenEnum = Alergen.MED;
                                    break;
                                case "gluten":
                                    alergenEnum = Alergen.GLUTEN;
                                    break;
                                case "orasasti plodovi":
                                    alergenEnum = Alergen.ORASASTI_PLODOVI;
                                    break;
                                default:
                                    Console.WriteLine("Takav alergen ne postoji u našoj bazi!");
                                    break;
                            }

                        }
                        Console.WriteLine("Unesite cijenu po gramu: ");
                        double cijenaPoG = Convert.ToDouble(Console.ReadLine());
                        MjernaJedinica mjernaJed = MjernaJedinica.GRAM;
                        Sastojak noviSastojak = new Sastojak(new Random().Next(), noviNaziv, ugljikohidratiPoG, mastiPoG, proteiniPoG, vlaknaPoG, solPoG, alergenEnum, cijenaPoG, mjernaJed);
                        sastojci.Add(noviSastojak);
                        break;
                    case 6:
                        Console.WriteLine("Unesite minimalnu ocjenu koju želite da recepti posjeduju: ");
                        double unesenaOcjena = Convert.ToDouble(Console.ReadLine());
                        var listaRecepata = kr.pretraziKnjiguRecepata(knjigeRecepata[indeksTrenutneKnjige], unesenaOcjena);
                        foreach(var recept in listaRecepata)
                        {
                            rs.prikazi(recept);
                        }
                        break;
                    case 7:
                        kr.ispisiKnjiguRecepata(knjigeRecepata[indeksTrenutneKnjige]);
                        break;
                    case 8:
                        kr.sortirajPremaVremenuPripreme(knjigeRecepata[indeksTrenutneKnjige]);
                        kr.ispisiKnjiguRecepata(knjigeRecepata[indeksTrenutneKnjige]);
                        break;
                    case 9:
                        kr.sortirajPremaKompleksnosti(knjigeRecepata[indeksTrenutneKnjige]);
                        kr.ispisiKnjiguRecepata(knjigeRecepata[indeksTrenutneKnjige]);
                        break;
                    case 0:
                        Console.WriteLine("Povratak na početni meni");
                        break;
                    default:
                        Console.WriteLine("Unijeli ste pogrešnu opciju!");
                        break;
                        
                }

            }
        
            // TODO: Dodati opciju korisniku da se vrati na drugiMeni nakon što završi sa pretragom

            // NOTICE: Cijeli kod za meni je subject to change, ovo je osnovna napamet sklepana verzija.

            // Da, koristio sam flagove i goto :P

            // ADDITION: Vodio sam se enumom VrstaJela i za tipove KnjigeRecepata, tkd sam dodao i 5 mogućih odabira knjiga recepata!

            // NOTICE: Imo ovdje switchevi nisu potrebni jer se za svaku knjigu recepata isti meni treba nuditi logički so yeah,
            // rather uzeti samo odabir trenutne "glavne knjige recepata". 
            int prvaOpcija = 20;
            var tipoviKnjiga = new List<string> { "predjelima", "glavnim jelima", "desertima", "prilozima", "salatama" }; 
            int indeksTrenutneKnjige = 0;
            while (prvaOpcija != 0)
            {
                Console.WriteLine("\nDobrodošli u kuharicu!\n");
                Console.WriteLine("Odaberite željenu knjigu: ");
                Console.WriteLine("1. Predjela");
                Console.WriteLine("2. Glavna jela");
                Console.WriteLine("3. Deserti");
                Console.WriteLine("4. Prilozi");
                Console.WriteLine("5. Salate");
                Console.WriteLine("\n0. Izlaz");
                prvaOpcija = Convert.ToInt32(Console.ReadLine());
                if (prvaOpcija == 0) break;
                int sljedeciKorak = 1;
                while (sljedeciKorak != 0)
                {
                    sljedeciKorak = ispisMenija(tipoviKnjiga[prvaOpcija - 1]);
                    drugiMeni(sljedeciKorak, prvaOpcija - 1);
                }





                // TODO: Dodati u svaki case gdje se prikazuje recept nakon prikaza, maybe izdvojiti u posebnu metodu
                /* ---- Ovaj dio moze ostati za konzolnu ---- */
                /*nsole.WriteLine("Želite li ocijeniti odabrani recept (DA/NE): ");
                string unos = Console.ReadLine();

                if (unos == "DA")
                {
                    rs.ocijeni(recept1);
                }

                /* -------- */

                /*r (int i = 0; i < recept1.ocjene.Count; i++)
                {
                    Console.WriteLine(recept1.ocjene[i].ocjena);
                    Console.WriteLine(recept1.ocjene[i].komentar);
                }


                Console.WriteLine(oc.dajProsjecnuOcjenu(recept1.ocjene));*/
            }
            Console.WriteLine("Hvala Vam na korištenju naše kuharice i doviđenja!");
        }
    }
}