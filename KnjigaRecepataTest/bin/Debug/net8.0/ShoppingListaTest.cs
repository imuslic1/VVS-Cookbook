using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ShoppingListaServices;

namespace KnjigaRecepataTest
{
    [TestClass]
    public class ShoppingListaTest
    {
        static DbClass baza = new DbClass();
        static SastojakService ss = new SastojakService(baza);
        ShoppingListaService sl = new ShoppingListaService(baza, ss);

        private static Recept r1, r2, r3, r4;

        [ClassInitialize]
        public static void SetUp(TestContext tc)
        {
            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            Ocjena ocjena3 = new Ocjena(2, 2, "...");
            Ocjena ocjena4 = new Ocjena(2, 1, "...");
            Ocjena ocjena5 = new Ocjena(2, 4, "...");

            var ocjene3 = new List<Ocjena> { ocjena5, ocjena1, ocjena4 };
            var ocjene4 = new List<Ocjena> { ocjena3 };

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

            r1 = new Recept(2, "Pohovana piletina", VrstaJela.GLAVNO_JELO,
                    "Pohujte piletinu s brašnom i jajima, pržite do zlatne boje.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[4], 1 }, { sastojci[6], 1 }, { sastojci[5], 150 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene3);
            r2 = new Recept(4, "Rižoto sa safranom", VrstaJela.GLAVNO_JELO,
                    "Pirjajte rižu, dodajte šafran i vodu, kuhajte do mekane teksture.", 40,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[6], 1 }, { sastojci[7], 20 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene4);
            r3 = new Recept(12, "Supa od rajcice", VrstaJela.PREDJELO,
                    "Pirjajte rajčice, dodajte vodu i začine.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[9], 200 }, { sastojci[6], 1 } },
                    KompleksnostPripreme.LAKO, ocjene4);
            r4= new Recept(7, "Omlet sa sirom", VrstaJela.PREDJELO,
                    "Izmiksajte jaja i sir, pecite u tavi.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[3], 2 }, { sastojci[7], 30 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene3);
        }

        [TestMethod]
        public void IzracunajCijenu()
        {
            double expected1 = 350.85;
            double actual1 = sl.cijenaSastojaka(r1);

            double expected2 = 200.05;
            double actual2 = sl.cijenaSastojaka(r2);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrikaziShoppingListuPraznaLista()
        {
            ShoppingLista lista = new ShoppingLista(r3);
            lista.recept.sastojci = new Dictionary<Sastojak, double>();

            sl.prikaziShoppingListu(lista);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrikaziShoppingListuNullLista()
        {
            ShoppingLista lista = new ShoppingLista(r4);
            lista.recept.sastojci = null;

            sl.prikaziShoppingListu(lista);
        }

        [TestMethod]
        public void PrikaziShoppingListu()
        {
            ShoppingLista lista = new ShoppingLista(r1);
            string expected1 = "Kako biste pripremili Pohovana piletina potrebno je da kupite:\r\n- Brašno: 100 g\r\n- Mlijeko: 1 ml\r\n- Sol: 1 tsp\r\n- Piletina: 150 g\r\nUkupni trosak: 350,85\r\n";
            string actual1 = sl.prikaziShoppingListu(lista);

            Assert.AreEqual(expected1, actual1);
        }

    }
}