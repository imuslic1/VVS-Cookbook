using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using System.Globalization;
using CsvHelper;

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

        static IEnumerable<object[]> SastojakTestPodaciCSV
        {
            get
            {
                return LoadDataCSV();
            }
        }

        public static IEnumerable<object[]> LoadDataCSV()
        {
            using (var reader = new StreamReader("SastojakTestPodaci.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach(var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(x => x.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2], elements[3], elements[4] };
                }
            }
        }

        [TestMethod]
        [DynamicData("SastojakTestPodaciCSV")]
        public void DajBrojKalorijaPoJedinici_ValidniPodaci_DobijeniBrojKalorija(string ugljikohidrati, string masti, string proteini, string vlakna, string expected)
        {
            Sastojak sastojak = new(0, "Testni sastojak", double.Parse(ugljikohidrati, CultureInfo.InvariantCulture), double.Parse(masti, CultureInfo.InvariantCulture), double.Parse(proteini, CultureInfo.InvariantCulture), double.Parse(vlakna, CultureInfo.InvariantCulture), 0, null, 0, MjernaJedinica.GRAM);
            Assert.AreEqual(double.Parse(expected, CultureInfo.InvariantCulture), sastojakService.dajBrojKalorijaPoJedinici(sastojak));
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
                    new object[] { MjernaJedinica.SUPENA_KASIKA, "tbsp" },
                    new object[] { MjernaJedinica.CASA, "cup" },
                    new object[] { MjernaJedinica.UNCA, "oz" },
                    new object[] { MjernaJedinica.MILILITAR, "ml" },
                    new object[] { MjernaJedinica.GRAM, "g" },
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
                    new object[] { new Sastojak(1, "Krompir", 17, 0.1, 2, 1.8, 3, null, 2, MjernaJedinica.GRAM), "Sastojak: Krompir\nNutrijenti po jedinici\n- ugljikohidrati: 17\n- masti: 0.1\n- proteini: 2\n- vlakna: 1.8\n- sol: 3\nAlergeni: nema" },
                    new object[] { new Sastojak(2, "Kravlje mlijeko", 4.7, 3.6, 3.2, 0, 0, Alergen.LAKTOZA, 2.3, MjernaJedinica.MILILITAR), "Sastojak: Kravlje mlijeko\nNutrijenti po jedinici\n- ugljikohidrati: 4.7\n- masti: 3.6\n- proteini: 3.2\n- vlakna: 0\n- sol: 0\nAlergeni: LAKTOZA" },
					new object[] { new Sastojak(1, "Bijelo brasno", 70, 1, 10, 3, 0.01, Alergen.GLUTEN, 2, MjernaJedinica.GRAM), "Sastojak: Bijelo brasno\nNutrijenti po jedinici\n- ugljikohidrati: 70\n- masti: 1\n- proteini: 10\n- vlakna: 3\n- sol: 0.01\nAlergeni: GLUTEN" },
					new object[] { new Sastojak(2, "Kikiriki", 10, 50, 25, 8, 0, Alergen.ORASASTI_PLODOVI, 2, MjernaJedinica.GRAM), "Sastojak: Kikiriki\nNutrijenti po jedinici\n- ugljikohidrati: 10\n- masti: 50\n- proteini: 25\n- vlakna: 8\n- sol: 0\nAlergeni: ORASASTI_PLODOVI" },
					new object[] { new Sastojak(3, "Med", 80, 0, 0, 0, 0.02, Alergen.MED, 2, MjernaJedinica.GRAM), "Sastojak: Med\nNutrijenti po jedinici\n- ugljikohidrati: 80\n- masti: 0\n- proteini: 0\n- vlakna: 0\n- sol: 0.02\nAlergeni: MED" }
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
