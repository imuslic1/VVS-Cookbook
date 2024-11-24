using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Services.KnjigaRecepataServices;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnjigaRecepataTest
{
    [TestClass]
    public class KnjigaRecepataMockTest
    {
        private static OcjenaService ocjenaService = new OcjenaService();
        private static SastojakService sastojakService = new SastojakService(new DbClass());
        public class FakeReceptService : IReceptService
        {
            public double dajUkupanBrojKalorija(Recept recept)
            {
                throw new NotImplementedException();
            }

            public string prikazi(Recept recept)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("\n\nRecept: " + recept.name);
                sb.AppendLine("Vrsta jela: " + recept.tipRecepta);
                sb.AppendLine("Vrijeme pripreme: " + recept.vrijemePripreme + " minuta");
                sb.AppendLine("Kompleksnost pripreme: " + recept.kompleksnost);
                sb.AppendLine("\nSastojci:");

                foreach (var sastojakEntry in recept.sastojci)
                {
                    Sastojak sastojak = sastojakEntry.Key;
                    double kolicina = sastojakEntry.Value;
                    sb.AppendLine("- " + sastojak.naziv + ": " + kolicina + " " + sastojakService.dajSkracenicu(sastojak.mjernaJedinica));
                }

                sb.AppendLine("Priprema: " + recept.priprema);

                sb.AppendLine("\nOcjene:");
                foreach (var ocjena in recept.ocjene)
                {
                    sb.AppendLine("- " + ocjena.ocjena + "/5: " + ocjena.komentar);
                }

                Console.WriteLine(sb.ToString());
                return sb.ToString();
            }

            public string prikaziAlergene(Recept recept)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("*** ALERGENI ***");

                HashSet<Alergen> alergeni = new HashSet<Alergen>();

                foreach (var sastojakEntry in recept.sastojci)
                {
                    Sastojak sastojak = sastojakEntry.Key;

                    if (sastojak.alergen.HasValue)
                        alergeni.Add(sastojak.alergen.Value);
                }

                if (alergeni.Contains(Alergen.LAKTOZA)) sb.AppendLine("- LAKTOZA");
                if (alergeni.Contains(Alergen.GLUTEN)) sb.AppendLine("- GLUTEN");
                if (alergeni.Contains(Alergen.ORASASTI_PLODOVI)) sb.AppendLine("- ORASASTI PLODOVI");
                if (alergeni.Contains(Alergen.MED)) sb.AppendLine("- MED");

                Console.WriteLine(sb.ToString());

                return sb.ToString();
            }
            public void konvertujMjerneJedinice(Recept recept)
            {
                throw new NotImplementedException();
            }
            public void ocijeni(Recept recept, Ocjena ocjena)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void ispisiKnjiguRecepata_MockTest()
        {
            var fakeReceptService = new FakeReceptService();
            KnjigaRecepataService knjigaRecepataService = new KnjigaRecepataService(new DbClass(), fakeReceptService, ocjenaService);
            var knjigaRecepata = new KnjigaRecepata(1, VrstaJela.PREDJELO, new List<Recept>{
                            new Recept(1, "bcd", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>{
                                { new Sastojak(1, "Šećer", 99.8, 0.0, 0.0, 0.0, 0.0, null, 0.5, MjernaJedinica.GRAM), 200.0 },
                                { new Sastojak(2, "Maslac", 0.1, 81.0, 0.9, 0.0, 1.0, Alergen.LAKTOZA, 2.0, MjernaJedinica.GRAM), 100.0 }}, KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>())
                        });
            string expectedOutput = fakeReceptService.prikazi(knjigaRecepata.recepti[0]);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                knjigaRecepataService.ispisiKnjiguRecepata(knjigaRecepata);

                // Assert
                var result = sw.ToString();
                Console.WriteLine(result);
                Console.WriteLine(expectedOutput);
                Assert.AreEqual(expectedOutput.Replace("\r\n", "\n").Trim(), result.Replace("\r\n", "\n").Trim());
            }

        }
    }
}
