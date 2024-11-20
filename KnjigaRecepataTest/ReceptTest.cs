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



namespace KnjigaRecepataTest {
    [TestClass]
    public class ReceptTest {

        private static OcjenaService ocjenaService = new OcjenaService();
        private static SastojakService sastojakService = new SastojakService(new DbClass());
        private static ReceptService receptService = new ReceptService(new DbClass(), sastojakService);
        private static KnjigaRecepataService knjigaRecepataService = new KnjigaRecepataService(new DbClass(), receptService, ocjenaService);

        static DbClass baza = new DbClass();
        static SastojakService ss = new SastojakService(baza);
        ReceptService rs = new ReceptService(baza, ss);

        private static Recept r1, r2, r3, r4;

        [ClassInitialize]
        public static void SetUp(TestContext tc) {
            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            Ocjena ocjena3 = new Ocjena(2, 2, "...");
            Ocjena ocjena4 = new Ocjena(2, 1, "...");
            Ocjena ocjena5 = new Ocjena(2, 4, "...");

            var ocjene1 = new List<Ocjena> { ocjena5, ocjena1, ocjena4 };
            var ocjene2 = new List<Ocjena> { ocjena3, ocjena2 };

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
        }


        [TestMethod]
        public void TestDajUkupanBrojKalorija() {
            double kalorije = rs.dajUkupanBrojKalorija(r1);
            Assert.AreEqual(36023, kalorije);
        }




        [TestMethod]
        public void TestPrikazi() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\nRecept: " + r1.name);
            sb.AppendLine("Vrsta jela: " + r1.tipRecepta);
            sb.AppendLine("Vrijeme pripreme: " + r1.vrijemePripreme + " minuta");
            sb.AppendLine("Kompleksnost pripreme: " + r1.kompleksnost);
            sb.AppendLine("\nSastojci:");
            foreach (var sastojakEntry in r1.sastojci) {
                Sastojak sastojak = sastojakEntry.Key;
                double kolicina = sastojakEntry.Value;
                sb.AppendLine("- " + sastojak.naziv + ": " + kolicina + " " + ss.dajSkracenicu(sastojak.mjernaJedinica));
            }
            sb.AppendLine("Priprema: " + r1.priprema);
            sb.AppendLine("\nOcjene:");
            foreach (var ocjena in r1.ocjene) {
                sb.AppendLine("- " + ocjena.ocjena + "/5: " + ocjena.komentar);
            }
            Assert.AreEqual(sb.ToString(), rs.prikazi(r1));

        }

        [TestMethod]
        public void TestPrikaziAlergene() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** ALERGENI ***");
            HashSet<Alergen> alergeni = new HashSet<Alergen>();
            foreach (var sastojakEntry in r1.sastojci) {
                Sastojak sastojak = sastojakEntry.Key;
                if (sastojak.alergen.HasValue)
                    alergeni.Add(sastojak.alergen.Value);
            }
            if (alergeni.Contains(Alergen.LAKTOZA)) sb.AppendLine("- LAKTOZA");
            if (alergeni.Contains(Alergen.GLUTEN)) sb.AppendLine("- GLUTEN");
            if (alergeni.Contains(Alergen.ORASASTI_PLODOVI)) sb.AppendLine("- ORASASTI PLODOVI");
            if (alergeni.Contains(Alergen.MED)) sb.AppendLine("- MED");
            Assert.AreEqual(sb.ToString(), rs.prikaziAlergene(r1));
        }

        [TestMethod]
        public void konvertujMjerneJedinice_UnceUMililitre_Konvertuje() {
            rs.konvertujMjerneJedinice(r4);
            Assert.AreEqual(5*29.57, r4.sastojci.ElementAt(1).Value);
        }

        [TestMethod]
        public void konvertujMjerneJedinice_CaseUGrame_Konvertuje() {
            rs.konvertujMjerneJedinice(r4);
            Assert.AreEqual(0.5 * 236.59, r4.sastojci.ElementAt(2).Value);
        }

        [TestMethod]
        public void Ocijeni_IspravnaOcjena_OcjenaDodana() {
            Ocjena ocjena = new Ocjena(1, 4, "...");
            rs.ocijeni(r1, ocjena);
            Assert.AreEqual(4, r1.ocjene[3].ocjena);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Ocijeni_NevalidnaOcjena_Izuzetak() {
            Ocjena ocjena = new Ocjena(1, 6, "...");
            rs.ocijeni(r1, ocjena);
        }




        








    }
}
