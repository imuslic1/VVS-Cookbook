using System;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;

namespace KnjigaRecepataTest
{
	[TestClass]
	public class SastojakTest
	{
		private static SastojakService sastojakService = new SastojakService(new DbClass());

        [TestMethod]
        [DataRow(28, 0.3, 2.7, 0.4, 126.3)]
		[DataRow(0.6, 10, 13, 0, 144.4)]
		[DataRow(100, 0, 0, 0, 400)]
		public void DajBrojKalorijaPoJedinici_SmisleniPodaci_BrojKalorija(double ugljikohidrati, double masti, double proteini, double vlakna, double expected)
		{
            Sastojak sastojak = new(0, "Testni sastojak", ugljikohidrati, masti, proteini, vlakna, 0, null, 0, MjernaJedinica.GRAM);
			Assert.AreEqual(expected, sastojakService.dajBrojKalorijaPoJedinici(sastojak));
        }

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DajBrojKalorijaPoJedinici_Null_Izuzetak()
		{
			sastojakService.dajBrojKalorijaPoJedinici(null);
		}

		public static IEnumerable<object[]> GenerateMjernaJedinicaTestData
		{
            get
            {
                return new[]
                {
					new object[] { MjernaJedinica.CAJNA_KASIKA, "tsp" },
					new object[] { MjernaJedinica.MILILITAR, "ml" }
				};
            }
		}

		[TestMethod]
		[DynamicData(nameof(GenerateMjernaJedinicaTestData))]
		public void DajSkracenicu_Podaci_Skracenica(MjernaJedinica mjernaJedinica, string expected)
		{
			Assert.AreEqual(expected, sastojakService.dajSkracenicu(mjernaJedinica));
		}

		public static IEnumerable<object[]> GeneratePrikazSastojkaTestData
		{
            get
            {
                return new[]
                {
                    new object[] { new Sastojak(1, "Krompir", 17, 0.1, 2, 1.8, 3, null, 2, MjernaJedinica.GRAM), "Sastojak: Krompir\nNutrijenti po jedinici\n- ugljikohidrati: 17\n- masti: 0,1\n- proteini: 2\n- vlakna: 1,8\n- sol: 3\nAlergeni: nema" },
                    new object[] { new Sastojak(2, "Kravlje mlijeko", 4.7, 3.6, 3.2, 0, 0, Alergen.LAKTOZA, 2.3, MjernaJedinica.MILILITAR), "Sastojak: Kravlje mlijeko\nNutrijenti po jedinici\n- ugljikohidrati: 4,7\n- masti: 3,6\n- proteini: 3,2\n- vlakna: 0\n- sol: 0\nAlergeni: LAKTOZA" }
                };
            }
		}

        [TestMethod]
        [DynamicData(nameof(GeneratePrikazSastojkaTestData))]
		public void PrikaziSastojak_SmisleniPodaci_IspisSastojka(Sastojak sastojak, string expected)
		{
			var originalConsoleOut = Console.Out;

            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
			sastojakService.prikaziSastojak(sastojak);
			var ispis = stringWriter.ToString().Trim();

            string normalizedExpected = expected.Replace("\r\n", "\n");
            string normalizedIspis = ispis.Replace("\r\n", "\n");

            Assert.AreEqual(normalizedExpected, normalizedIspis);

			Console.SetOut(originalConsoleOut);
        }

		[TestMethod]
		public void PrikaziSastojak_Null_IspisPoruke()
		{
			try
			{
				sastojakService.prikaziSastojak(null);
			}
			catch(ArgumentNullException e)
			{
				Assert.AreEqual("Sastojak nije validan!", e.Message);
			}
		}
    }
}
