using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.KnjigaRecepataServices;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnjigaRecepataTest
{
    [TestClass]
    public class KnjigaRecepataTestFake
    {
        public class FakeDbClass : IDbClass
        {
            static List<Sastojak> sastojci = new List<Sastojak>{
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

            static Ocjena ocjena1 = new Ocjena(1, 3, "...");
            static Ocjena ocjena2 = new Ocjena(2, 5, "...");
            static Ocjena ocjena3 = new Ocjena(2, 2, "...");
            static Ocjena ocjena4 = new Ocjena(2, 1, "...");
            static Ocjena ocjena5 = new Ocjena(2, 4, "...");

            static List<Ocjena> ocjene1 = new List<Ocjena> { ocjena1, ocjena2, ocjena3 };
            static List<Ocjena> ocjene2 = new List<Ocjena> { ocjena3, ocjena4, ocjena5 };
            static List<Ocjena> ocjene3 = new List<Ocjena> { ocjena5, ocjena1, ocjena4 };
            static List<Ocjena> ocjene4 = new List<Ocjena> { ocjena3 };
            static List<Ocjena> ocjene5 = new List<Ocjena> { ocjena5 };
            static List<Ocjena> ocjene6 = new List<Ocjena> { ocjena2, ocjena2, ocjena3, ocjena5 };

            static List<Recept> predjeloRecepti = new List<Recept> { 
                new Recept(6, "Juha od povrca", VrstaJela.PREDJELO,
                    "Kuhajte povrće u vodi s dodatkom soli.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[8], 50 }, { sastojci[9], 50 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene2),

                new Recept(7, "Omlet sa sirom", VrstaJela.PREDJELO,
                    "Izmiksajte jaja i sir, pecite u tavi.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[3], 2 }, { sastojci[7], 30 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene3),

                 new Recept(12, "Supa od rajcice", VrstaJela.PREDJELO,
                    "Pirjajte rajčice, dodajte vodu i začine.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[9], 200 }, { sastojci[6], 1 } },
                    KompleksnostPripreme.LAKO, ocjene4)
            };

            static List<Recept> glavnoJeloRecepti = new List<Recept>
            {
                new Recept(2, "Pohovana piletina", VrstaJela.GLAVNO_JELO,
                    "Pohujte piletinu s brašnom i jajima, pržite do zlatne boje.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[4], 1 }, { sastojci[6], 1 }, { sastojci[5], 150 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene3),

                new Recept(4, "Rižoto sa safranom", VrstaJela.GLAVNO_JELO,
                    "Pirjajte rižu, dodajte šafran i vodu, kuhajte do mekane teksture.", 40,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[6], 1 }, { sastojci[7], 20 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene4),

                new Recept(10, "Spageti sa maslacem i cesnjakom", VrstaJela.GLAVNO_JELO,
                    "Skuhajte špagete, pomiješajte s maslacem i češnjakom.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[2], 30 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene6),

                new Recept(17, "Tjestenina Carbonara", VrstaJela.GLAVNO_JELO,
                    "Skuhajte tjesteninu, dodajte slaninu, sir i jaja.", 25,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[4], 1 }, { sastojci[7], 30 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene1),

                new Recept(19, "Vege burger", VrstaJela.GLAVNO_JELO,
                    "Pomiješajte povrće i brašno, oblikujte i pržite.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[8], 50 }, { sastojci[9], 50 }, { sastojci[0], 50 } },
                    KompleksnostPripreme.PROFESIONALAC, ocjene4),

                new Recept(20, "Sos Bolognese", VrstaJela.GLAVNO_JELO,
                    "Pirjajte povrće i meso, kuhajte uz dodatak rajčice.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[9], 100 }, { sastojci[8], 50 }, { sastojci[6], 1 } },
                    KompleksnostPripreme.PROFESIONALAC, ocjene6)
            };

            static List<Recept> desertRecepti = new List<Recept>
            {
                new Recept(1, "Palacinke", VrstaJela.DESERT,
                    "Pomiješajte sastojke, ispecite na tavi.", 15,
                    new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[1], 50 }, { sastojci[3], 1 }, { sastojci[5], 200 } },
                    KompleksnostPripreme.LAKO, ocjene1),

                new Recept(5, "Medeni kolacici", VrstaJela.DESERT,
                    "Pomiješajte sastojke i pecite 15 minuta.", 25,
                    new Dictionary<Sastojak, double> { { sastojci[3], 50 }, { sastojci[0], 100 }, { sastojci[1], 50 }, { sastojci[2], 20 } },
                    KompleksnostPripreme.LAKO, ocjene3),

                new Recept(8, "Smoothie od bademovog mlijeka", VrstaJela.DESERT,
                    "Pomiješajte sastojke u blenderu.", 5,
                    new Dictionary<Sastojak, double> { { sastojci[5], 200 }, { sastojci[7], 50 } },
                    KompleksnostPripreme.LAKO, ocjene2),

                new Recept(11, "Bademova torta", VrstaJela.DESERT,
                    "Pomiješajte bademe s brašnom i jajima, pecite.", 50,
                    new Dictionary<Sastojak, double> { { sastojci[7], 100 }, { sastojci[0], 100 }, { sastojci[4], 1 } },
                    KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),

                new Recept(14, "Strudla od jabuka", VrstaJela.DESERT,
                    "Pomiješajte sastojke, pecite dok ne porumeni.", 40,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[1], 50 }, { sastojci[2], 50 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene5),

                new Recept(16, "Cokoladni kolac", VrstaJela.DESERT,
                    "Pomiješajte sastojke, pecite na 180°C.", 45,
                    new Dictionary<Sastojak, double> { { sastojci[0], 150 }, { sastojci[1], 100 }, { sastojci[2], 30 }, { sastojci[3], 1 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene2),

                 new Recept(18, "Muffini sa borovnicama", VrstaJela.DESERT,
                    "Pomiješajte sastojke, dodajte borovnice, pecite.", 35,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[1], 50 }, { sastojci[3], 1 } },
                    KompleksnostPripreme.TESKO, ocjene2)
            };

            static List<Recept> prilogRecepti = new List<Recept>
            {
                new Recept(9, "Peceni krompirici", VrstaJela.PRILOG,
                    "Ispecite krumpiriće u pećnici uz dodatak soli.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[6], 1 } },
                    KompleksnostPripreme.LAKO, ocjene1),

                new Recept(15, "Riza sa povrcem", VrstaJela.PRILOG,
                    "Kuhajte rižu s povrćem dok ne omekša.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[8], 50 }, { sastojci[9], 50 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene1),
            };

            static List<Recept> salataRecepti = new List<Recept>
            {
                new Recept(3, "Salata od rajcice", VrstaJela.SALATA,
                    "Nasjeckajte rajčicu i luk, začinite solju.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[9], 100 }, { sastojci[8], 20 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene5),

                new Recept(13, "Salata od badema i spinata", VrstaJela.SALATA,
                    "Pomiješajte špinat i bademe, začinite po želji.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[7], 30 }, { sastojci[8], 50 } },
                    KompleksnostPripreme.LAKO, ocjene5)
            };

            public void addRecept(Recept recept){ }

            public void addSastojak(Sastojak sastojak){ }

            public List<Recept> getAllRecepti()
            {
                return new List<Recept>();
            }

            public List<Sastojak> getAllSastojci()
            {
                return new List<Sastojak>();
            }

            public Recept? getRecept(int receptId)
            {
                return null;
            }

            public Sastojak? getSastojak(int sastojakId)
            {
                return null;
            }

            public List<Recept> getReceptiForTipRecepta(VrstaJela vrstaJela)
            {
                if(vrstaJela == VrstaJela.PREDJELO)
                {
                    return predjeloRecepti;
                }
                else if(vrstaJela == VrstaJela.GLAVNO_JELO)
                {
                    return glavnoJeloRecepti;
                }
                else if(vrstaJela == VrstaJela.DESERT)
                {
                    return desertRecepti;
                }
                else if(vrstaJela == VrstaJela.PRILOG)
                {
                    return prilogRecepti;
                }
                else if(vrstaJela == VrstaJela.SALATA)
                {
                    return salataRecepti;
                }
                else
                {
                    return new List<Recept>();
                }
            }
        }

        private static OcjenaService ocjenaService = new OcjenaService();
        private static SastojakService sastojakService = new SastojakService(new DbClass());
        private static ReceptService receptService = new ReceptService(new DbClass(), sastojakService);
        private static FakeDbClass fakeDB = new FakeDbClass();
        private static KnjigaRecepataService knjigaRecepataService = new KnjigaRecepataService(fakeDB, receptService, ocjenaService);

        private static KnjigaRecepata predjeloKR = new KnjigaRecepata(1, VrstaJela.PREDJELO, fakeDB.getReceptiForTipRecepta(VrstaJela.PREDJELO));
        private static KnjigaRecepata glavnoJeloKR = new KnjigaRecepata(2, VrstaJela.GLAVNO_JELO, fakeDB.getReceptiForTipRecepta(VrstaJela.GLAVNO_JELO));
        private static KnjigaRecepata desertKR = new KnjigaRecepata(3, VrstaJela.DESERT, fakeDB.getReceptiForTipRecepta(VrstaJela.DESERT));
        private static KnjigaRecepata prilogKR = new KnjigaRecepata(4, VrstaJela.PRILOG, fakeDB.getReceptiForTipRecepta(VrstaJela.PRILOG));
        private static KnjigaRecepata salataKR = new KnjigaRecepata(5, VrstaJela.SALATA, fakeDB.getReceptiForTipRecepta(VrstaJela.SALATA));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReceptiBezAlergena_NulaAlergena_Izuzetak()
        {
            knjigaRecepataService.receptiBezAlergena(predjeloKR, new List<Alergen>());
        }

        [TestMethod]
        public void ReceptiBezAlergena_JedanAlergen_ListaRecepata()
        {
            List<Recept> expected = new List<Recept> {
                new Recept(10, "Spageti sa maslacem i cesnjakom", VrstaJela.GLAVNO_JELO,
                    "Skuhajte špagete, pomiješajte s maslacem i češnjakom.", 20,
                    new Dictionary<Sastojak, double> { 
                        { new Sastojak(3, "Maslac", 0.8, 81.0, 1.0, 0.0, 0.02, Alergen.LAKTOZA, 1.5, MjernaJedinica.GRAM), 30 }, 
                        { new Sastojak(7, "Sol", 0.0, 0.0, 0.0, 0.0, 99.0, null, 0.05, MjernaJedinica.CAJNA_KASIKA), 0.5 } },
                    KompleksnostPripreme.LAKO, new List<Ocjena> {
                        new Ocjena(2, 5, "..."),
                        new Ocjena(2, 5, "..."),
                        new Ocjena(2, 2, "..."),
                        new Ocjena(2, 4, "...")
                    }),

                new Recept(20, "Sos Bolognese", VrstaJela.GLAVNO_JELO,
                    "Pirjajte povrće i meso, kuhajte uz dodatak rajčice.", 30,
                    new Dictionary<Sastojak, double> { 
                        { new Sastojak(10, "Rajčica", 3.9, 0.2, 0.9, 1.2, 0.02, null, 0.3, MjernaJedinica.GRAM), 100 }, 
                        { new Sastojak(9, "Luk", 9.3, 0.1, 1.1, 1.7, 0.01, null, 0.2, MjernaJedinica.GRAM), 50 }, 
                        { new Sastojak(7, "Sol", 0.0, 0.0, 0.0, 0.0, 99.0, null, 0.05, MjernaJedinica.CAJNA_KASIKA), 1 } },
                    KompleksnostPripreme.PROFESIONALAC, new List<Ocjena> {
                        new Ocjena(2, 5, "..."),
                        new Ocjena(2, 5, "..."),
                        new Ocjena(2, 2, "..."),
                        new Ocjena(2, 4, "...")
                    })
            };

            CollectionAssert.AreEqual(expected, knjigaRecepataService.receptiBezAlergena(glavnoJeloKR, new List<Alergen> { Alergen.GLUTEN }));
        }

        [TestMethod]
        public void ReceptiBezAlergena_ViseAlergena_JedanRecept()
        {
            List<Recept> expected = new List<Recept>
            {
                new Recept(8, "Smoothie od bademovog mlijeka", VrstaJela.DESERT,
                    "Pomiješajte sastojke u blenderu.", 5,
                    new Dictionary<Sastojak, double> { 
                        { new Sastojak(6, "Piletina", 0.0, 3.6, 31.0, 0.0, 0.1, null, 2.0, MjernaJedinica.GRAM), 200 }, 
                        { new Sastojak(8, "Bademi", 21.6, 49.4, 21.2, 12.5, 0.01, Alergen.ORASASTI_PLODOVI, 5.0, MjernaJedinica.GRAM), 50 } },
                    KompleksnostPripreme.LAKO, new List<Ocjena> {
                        new Ocjena(2, 2, "..."),
                        new Ocjena(2, 1, "..."),
                        new Ocjena(2, 4, "...")
                    })
            };

            CollectionAssert.AreEqual(expected, knjigaRecepataService.receptiBezAlergena(desertKR, new List<Alergen> { Alergen.GLUTEN, Alergen.LAKTOZA }));
        }

        [TestMethod]
        public void ReceptiBezAlergena_ViseAlergena_ListaRecepata()
        {
            List<Recept> expected = new List<Recept>
            {
                new Recept(9, "Peceni krompirici", VrstaJela.PRILOG,
                    "Ispecite krumpiriće u pećnici uz dodatak soli.", 30,
                    new Dictionary<Sastojak, double> { 
                        { new Sastojak(7, "Sol", 0.0, 0.0, 0.0, 0.0, 99.0, null, 0.05, MjernaJedinica.CAJNA_KASIKA), 1 } 
                    },
                    KompleksnostPripreme.LAKO, new List<Ocjena>
                    {
                        new Ocjena(1, 3, "..."),
                        new Ocjena(2, 5, "..."),
                        new Ocjena(2, 2, "...")
                    }),

                new Recept(15, "Riza sa povrcem", VrstaJela.PRILOG,
                    "Kuhajte rižu s povrćem dok ne omekša.", 30,
                    new Dictionary<Sastojak, double> { 
                        { new Sastojak(1, "Brašno", 76.3, 1.0, 10.0, 2.7, 0.02, Alergen.GLUTEN, 0.5, MjernaJedinica.GRAM), 200 }, 
                        { new Sastojak(9, "Luk", 9.3, 0.1, 1.1, 1.7, 0.01, null, 0.2, MjernaJedinica.GRAM), 50 }, 
                        { new Sastojak(10, "Rajčica", 3.9, 0.2, 0.9, 1.2, 0.02, null, 0.3, MjernaJedinica.GRAM), 50 } },
                    KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>
                    {
                        new Ocjena(1, 3, "..."),
                        new Ocjena(2, 5, "..."),
                        new Ocjena(2, 2, "...")
                    })
            };

            CollectionAssert.AreEqual(expected, knjigaRecepataService.receptiBezAlergena(prilogKR, new List<Alergen> { Alergen.MED, Alergen.ORASASTI_PLODOVI, Alergen.LAKTOZA }));
        }

        [TestMethod]
        public void ReceptiBezAlergena_SviAlergeni_JedanRecept()
        {
            List<Recept> expected = new List<Recept>
            {
                new Recept(3, "Salata od rajcice", VrstaJela.SALATA,
                    "Nasjeckajte rajčicu i luk, začinite solju.", 10,
                    new Dictionary<Sastojak, double> { 
                        { new Sastojak(10, "Rajčica", 3.9, 0.2, 0.9, 1.2, 0.02, null, 0.3, MjernaJedinica.GRAM), 100 }, 
                        { new Sastojak(9, "Luk", 9.3, 0.1, 1.1, 1.7, 0.01, null, 0.2, MjernaJedinica.GRAM), 20 }, 
                        { new Sastojak(7, "Sol", 0.0, 0.0, 0.0, 0.0, 99.0, null, 0.05, MjernaJedinica.CAJNA_KASIKA), 0.5 } },
                    KompleksnostPripreme.LAKO, new List<Ocjena>
                    {
                        new Ocjena(2, 4, "...")
                    })
            };

            CollectionAssert.AreEqual(expected, knjigaRecepataService.receptiBezAlergena(salataKR, new List<Alergen> { Alergen.LAKTOZA, Alergen.GLUTEN, Alergen.ORASASTI_PLODOVI, Alergen.MED }));
        }
    }
}
