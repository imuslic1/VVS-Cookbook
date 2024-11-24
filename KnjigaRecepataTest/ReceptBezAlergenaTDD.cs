using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.KnjigaRecepataServices;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;

namespace KnjigaRecepataTest
{
    [TestClass]
    public class ReceptBezAlergenaTDD
    {
        static DbClass baza = new DbClass();
        
        KnjigaRecepataService krs = new KnjigaRecepataService(baza, new ReceptService(baza, new SastojakService(baza)), new OcjenaService());
        private static KnjigaRecepata kr1, kr2, kr3;
        private static Recept r1, r2, r3, r4, r5, r6;

        [ClassInitialize]
        public static void SetUp(TestContext tc)
        {
            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            Ocjena ocjena3 = new Ocjena(2, 2, "...");
            Ocjena ocjena4 = new Ocjena(2, 1, "...");
            Ocjena ocjena5 = new Ocjena(2, 4, "...");

            var ocjene1 = new List<Ocjena> { ocjena5, ocjena1, ocjena4 };
            var ocjene2 = new List<Ocjena> { ocjena3, ocjena2 };
            var ocjene5 = new List<Ocjena> { ocjena5 };

            var sastojci = new List<Sastojak> {
                new Sastojak(1, "Brašno", 76.3, 1.0, 10.0, 2.7, 0.02, Alergen.GLUTEN, 0.5, MjernaJedinica.CASA),
                new Sastojak(2, "Šećer", 99.8, 0.0, 0.0, 0.0, 0.01, null, 0.4, MjernaJedinica.GRAM),
                new Sastojak(3, "Maslac", 0.8, 81.0, 1.0, 0.0, 0.02, Alergen.LAKTOZA, 1.5, MjernaJedinica.GRAM),
                new Sastojak(4, "Med", 82.4, 0.0, 0.3, 0.2, 0.02, Alergen.MED, 2.0, MjernaJedinica.SUPENA_KASIKA),
                new Sastojak(5, "Mlijeko", 4.8, 3.4, 3.3, 0.0, 0.05, Alergen.LAKTOZA, 0.8, MjernaJedinica.UNCA),
                new Sastojak(6, "Piletina", 0.0, 3.6, 31.0, 0.0, 0.1, null, 2.0, MjernaJedinica.GRAM),
                new Sastojak(7, "Sol", 0.0, 0.0, 0.0, 0.0, 99.0, null, 0.05, MjernaJedinica.CAJNA_KASIKA),
                new Sastojak(8, "Bademi", 21.6, 49.4, 21.2, 12.5, 0.01, Alergen.ORASASTI_PLODOVI, 5.0, MjernaJedinica.GRAM),
                new Sastojak(9, "Luk", 9.3, 0.1, 1.1, 1.7, 0.01, null, 0.2, MjernaJedinica.GRAM),
                new Sastojak(10, "Rajčica", 3.9, 0.2, 0.9, 1.2, 0.02, null, 0.3, MjernaJedinica.GRAM)
            };

            r1 = new Recept(2, "Pohovana piletina", VrstaJela.GLAVNO_JELO,
                            "Pohujte piletinu s brašnom i jajima, pržite do zlatne boje.", 30,
                            new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[4], 1 }, },
                            KompleksnostPripreme.SREDNJE_TESKO, ocjene1);
            r2 = new Recept(4, "Rižoto sa safranom", VrstaJela.GLAVNO_JELO,
                            "Pirjajte rižu, dodajte šafran i vodu, kuhajte do mekane teksture.", 40,
                            new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[6], 1 }, { sastojci[7], 20 } },
                            KompleksnostPripreme.SREDNJE_TESKO, ocjene2);
            r3 = new Recept(12, "Supa od rajcice", VrstaJela.PREDJELO,
                            "Pirjajte rajčice, dodajte vodu i začine.", 20,
                            new Dictionary<Sastojak, double> { { sastojci[3], 200 }, { sastojci[6], 1 } },
                            KompleksnostPripreme.LAKO, ocjene2);

            r4 = new Recept(7, "Omlet sa sirom", VrstaJela.PREDJELO,
                            "Izmiksajte jaja i sir, pecite u tavi.", 10,
                            new Dictionary<Sastojak, double> { { sastojci[3], 2 }, { sastojci[4], 5 }, { sastojci[0], 0.5 }, { sastojci[6], 0.5 } },
                            KompleksnostPripreme.LAKO, ocjene1);

            r5 = new Recept(3, "Salata od rajcice", VrstaJela.SALATA,
                    "Nasjeckajte rajčicu i luk, začinite solju.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[9], 100 }, { sastojci[8], 20 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene5);

            r6 = new Recept(13, "Salata od badema i spinata", VrstaJela.SALATA,
                    "Pomiješajte špinat i bademe, začinite po želji.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[7], 30 }, { sastojci[8], 50 } },
                    KompleksnostPripreme.LAKO, ocjene5);

            kr1 = new KnjigaRecepata(0, VrstaJela.GLAVNO_JELO, new List<Recept> { r1, r2 });
            kr2 = new KnjigaRecepata(1, VrstaJela.PREDJELO, new List<Recept> { r3, r4 });
            kr3 = new KnjigaRecepata(2, VrstaJela.SALATA, new List<Recept> { r5, r6 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void receptiBezAlergena_NulaAlergena_BacenIzuzetak()
        {
            var res1 = krs.receptiBezAlergena(kr1, new List<Alergen>());
        }

        [TestMethod]
        public void receptiBezAlergena_NulaAlergena_OdgovarajuciTekstIzuzetka()
        {
            try
            {
                var res2 = krs.receptiBezAlergena(kr2, new List<Alergen>());
            }
            catch(ArgumentException e)
            {
                Assert.AreEqual("Potrebno je proslijediti alergen!", e.Message);
            }
        }

        [TestMethod]
        public void receptiBezAlergena_JedanAlergen_IspravanRezultat()
        {
            var res3 = krs.receptiBezAlergena(kr1, new List<Alergen> { Alergen.GLUTEN });
            List<Recept> receptiOcekivani = new List<Recept>();

            CollectionAssert.AreEqual(receptiOcekivani, res3);
        }

        [TestMethod]
        public void receptiBezAlergena_ViseAlergena_JedanRezultat()
        {
            var res4 = krs.receptiBezAlergena(kr1, new List<Alergen> { Alergen.ORASASTI_PLODOVI, Alergen.MED });
            List<Recept> receptiOcekivani = new List<Recept> { r1 };

            CollectionAssert.AreEqual(receptiOcekivani, res4);
        }

        [TestMethod]
        public void receptiBezAlergena_ViseAlergena_ViseRezultata()
        {
            var res5 = krs.receptiBezAlergena(kr3, new List<Alergen> { Alergen.LAKTOZA, Alergen.GLUTEN });
            List<Recept> receptiOcekivani = new List<Recept> { r5, r6 };

            CollectionAssert.AreEqual(receptiOcekivani, res5);
        }
    }
}
