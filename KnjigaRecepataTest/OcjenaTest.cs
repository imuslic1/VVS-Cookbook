using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;

namespace KnjigaRecepataTest
{
    [TestClass]
    public class OcjenaTest
    {
        private static OcjenaService ocjenaService = new OcjenaService();

        public static IEnumerable<object[]> GenerateListuOcjena
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new List<Ocjena>
                        {
                            new Ocjena(1, 5, "Odlicno!"),
                            new Ocjena(2, 4, "Vrlo dobro."),
                            new Ocjena(3, 3, "Prosjecno."),
                            new Ocjena(4, 2, "Treba biti bolje."),
                            new Ocjena(5, 1, "Jako lose."),
                        }, 3
                    },
                    new object[] {
                        new List<Ocjena>
                        {
                            new Ocjena(6, 1, "Jako lose."),
                            new Ocjena(7, 5, "Odlicno!"),
                            new Ocjena(8, 4, "Vrlo dobro."),
                            new Ocjena(9, 3, "Prosjecno."),
                        }, 3.25
                    },
                    new object[] {
                        new List<Ocjena>
                        {
                            new Ocjena(10, 4, "Vrlo dobro."),
                            new Ocjena(11, 2, "Treba biti bolje."),
                            new Ocjena(12, 1, "Jako lose."),
                            new Ocjena(13, 5, "Odlicno!"),
                            new Ocjena(14, 3, "Prosjecno."),
                            new Ocjena(15, 4, "Jako dobro."),
                            new Ocjena(16, 2, "Prosjecno."),
                        }, 3
                    }
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(GenerateListuOcjena))]
        public void DajProsjecnuOcjenu_SmisleniPodaci_SrednjaVr(List<Ocjena> ocjene, double expected)
        {
            double actual = ocjenaService.dajProsjecnuOcjenu(ocjene);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DajProsjecnuOcjenu_ManjaVrijednostOdDozvoljene_Izuzetak()
        {
            Ocjena ocj1 = new Ocjena(0, 4, "Vrlo dobro.");
            Ocjena ocj2 = new Ocjena(1, 0, "Lose.");

            List<Ocjena> ocjene = new List<Ocjena>();
            ocjene.Add(ocj1);
            ocjene.Add(ocj2);

            ocjenaService.dajProsjecnuOcjenu(ocjene);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DajProsjecnuOcjenu_VecaVrijednostOdDozvoljene_Izuzetak()
        {
            Ocjena ocj1 = new Ocjena(0, 4, "Vrlo dobro.");
            Ocjena ocj2 = new Ocjena(1, 10, "Fantastivcno.");

            List<Ocjena> ocjene = new List<Ocjena>();
            ocjene.Add(ocj1);
            ocjene.Add(ocj2);

            ocjenaService.dajProsjecnuOcjenu(ocjene);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DajProsjecnuOcjenu_Null_Izuzetak()
        {
            ocjenaService.dajProsjecnuOcjenu(null);
        }

        [TestMethod]
        public void DodajOcjenu_DodavanjeUPostojeciRecept_UspjesnoDodavanje()
        {
            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            Ocjena ocjena3 = new Ocjena(3, 2, "...");

            var ocjene3 = new List<Ocjena> { ocjena1, ocjena2, ocjena3 };

            var sastojci = new List<Sastojak>{
                new Sastojak(1, "Brašno", 76.3, 1.0, 10.0, 2.7, 0.02, Alergen.GLUTEN, 0.5, MjernaJedinica.GRAM),
                new Sastojak(2, "Šećer", 99.8, 0.0, 0.0, 0.0, 0.01, null, 0.4, MjernaJedinica.GRAM),
                new Sastojak(3, "Maslac", 0.8, 81.0, 1.0, 0.0, 0.02, Alergen.LAKTOZA, 1.5, MjernaJedinica.GRAM),
                new Sastojak(4, "Med", 82.4, 0.0, 0.3, 0.2, 0.02, Alergen.MED, 2.0, MjernaJedinica.SUPENA_KASIKA),
                new Sastojak(5, "Mlijeko", 4.8, 3.4, 3.3, 0.0, 0.05, Alergen.LAKTOZA, 0.8, MjernaJedinica.MILILITAR),
            };

            Recept r1 = new Recept(2, "Pohovana piletina", VrstaJela.GLAVNO_JELO,
                    "Pohujte piletinu s brašnom i jajima, pržite do zlatne boje.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[1], 1 }, { sastojci[2], 1 }, { sastojci[3], 150 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene3);

            Ocjena ocjena4 = new Ocjena(4, 4, "...");

            ocjenaService.dodajOcjenu(r1, ocjena4);
            Assert.AreEqual(4, r1.ocjene.Count);
        }
    }
}
