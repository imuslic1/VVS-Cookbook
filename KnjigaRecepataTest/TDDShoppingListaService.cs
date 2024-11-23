using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ShoppingListaServices;

namespace KnjigaRecepataTest {
    [TestClass]
    public class TDDShoppingListaService {
        // Kako da pisem test za metodu koja ne postoji :D
        static DbClass baza = new DbClass();
        static SastojakService ss = new SastojakService(baza);
        ShoppingListaService sl = new ShoppingListaService(baza, ss);

        private static Recept r1, r2, r3, r4;

        [ClassInitialize]
        public static void setup(TestContext tc) {
            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            Ocjena ocjena3 = new Ocjena(2, 2, "...");

            var ocjene1 = new List<Ocjena> { ocjena2, ocjena1, ocjena3 };

            var sastojci = new List<Sastojak> {
                new Sastojak(1, "Brašno", 76.3, 1.0, 10.0, 2.7, 0.02, Alergen.GLUTEN, 0.5, MjernaJedinica.CASA),
                new Sastojak(2, "Šećer", 99.8, 0.0, 0.0, 0.0, 0.01, null, 0.4, MjernaJedinica.GRAM),
                };

            r1 = new Recept(2, "Pohovana piletina", VrstaJela.GLAVNO_JELO,
                            "Pohujte piletinu s brašnom i jajima, pržite do zlatne boje.", 30,
                            new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[1], 1 }, },
                            KompleksnostPripreme.SREDNJE_TESKO, ocjene1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void prikaziNedostajuceSastojke_NevalidanUnos_Exception() {
            string unos = "1cd2fnestoRandom!";
            sl.prikaziNedostajuceSastojke(r1, unos);
        }

        [TestMethod]
        public void prikaziNedostajuceSastojke_ValidanUnos() {
            string unos = "brašno";
            string rezultat = sl.prikaziNedostajuceSastojke(r1, unos);
            Assert.AreEqual("Nedostaje: Šećer", rezultat);
        }
    }
}
