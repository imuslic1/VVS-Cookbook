using System;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using Grupa4_Tim1_KnjigaRecepata.Services.KnjigaRecepataServices;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;


namespace KnjigaRecepataTest
{
    [TestClass]
    public class KnjigaRecepataTest
    {
        private static OcjenaService ocjenaService = new OcjenaService();
        private static SastojakService sastojakService = new SastojakService(new DbClass());
        private static ReceptService receptService = new ReceptService(new DbClass(), sastojakService);
        private static KnjigaRecepataService knjigaRecepataService = new KnjigaRecepataService(new DbClass(), receptService, ocjenaService);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DodajRecept_RazlicitiTipoviRecepta_Izuzetak()
        {
            KnjigaRecepata knjigaRecepata = new KnjigaRecepata(0, VrstaJela.DESERT, new List<Recept>());
            Recept recept = new Recept(0, "Testni recept", VrstaJela.GLAVNO_JELO, "Testni opis", 0, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>());
            knjigaRecepataService.dodajRecept(knjigaRecepata, recept);
        }

        [TestMethod]
        public void DodajRecept_IstiTipoviRecepta_DodanRecept()
        {
            KnjigaRecepata knjigaRecepata = new KnjigaRecepata(0, VrstaJela.DESERT, new List<Recept>());
            Recept recept = new Recept(0, "Testni recept", VrstaJela.DESERT, "Testni opis", 0, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>());
            knjigaRecepataService.dodajRecept(knjigaRecepata, recept);
            Assert.AreEqual(1, knjigaRecepata.recepti.Count);
        }

        [TestMethod]
        public void SortirajPremaVremenuPripreme_Sortiranje_PravilnoSortiranje()
        {
            KnjigaRecepata knjigaRecepata = new KnjigaRecepata(0, VrstaJela.DESERT, new List<Recept>());
            Recept recept1 = new Recept(0, "Testni recept 1", VrstaJela.DESERT, "Testni opis", 10, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>());
            Recept recept2 = new Recept(1, "Testni recept 2", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>());
            Recept recept3 = new Recept(2, "Testni recept 3", VrstaJela.DESERT, "Testni opis", 15, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>());
            knjigaRecepata.recepti.Add(recept1);
            knjigaRecepata.recepti.Add(recept2);
            knjigaRecepata.recepti.Add(recept3);
            knjigaRecepataService.sortirajPremaVremenuPripreme(knjigaRecepata);
            Assert.AreEqual(5, knjigaRecepata.recepti[0].vrijemePripreme);
            Assert.AreEqual(1, knjigaRecepata.recepti[0].id);
        }

        [TestMethod]
        public void SortirajPremaKompleksnosti_Sortiranje_PravilnoSortiranje()
        {
            KnjigaRecepata knjigaRecepata = new KnjigaRecepata(0, VrstaJela.DESERT, new List<Recept>());
            Recept recept1 = new Recept(0, "Testni recept 1", VrstaJela.DESERT, "Testni opis", 10, new Dictionary<Sastojak, double>(), KompleksnostPripreme.LAKO, new List<Ocjena>());
            Recept recept2 = new Recept(1, "Testni recept 2", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>());
            Recept recept3 = new Recept(2, "Testni recept 3", VrstaJela.DESERT, "Testni opis", 15, new Dictionary<Sastojak, double>(), KompleksnostPripreme.TESKO, new List<Ocjena>());
            knjigaRecepata.recepti.Add(recept3);
            knjigaRecepata.recepti.Add(recept1);
            knjigaRecepata.recepti.Add(recept2);
            knjigaRecepataService.sortirajPremaKompleksnosti(knjigaRecepata);
            Assert.AreEqual(KompleksnostPripreme.LAKO, knjigaRecepata.recepti[0].kompleksnost);
            Assert.AreEqual(0, knjigaRecepata.recepti[0].id);
        }

        [TestMethod]
        public void SortirajPremaNazivu_Sortiranje_PravilnoSortiranje()
        {
            KnjigaRecepata knjigaRecepata = new KnjigaRecepata(0, VrstaJela.DESERT, new List<Recept>());
            Recept recept1 = new Recept(0, "abc", VrstaJela.DESERT, "Testni opis", 10, new Dictionary<Sastojak, double>(), KompleksnostPripreme.LAKO, new List<Ocjena>());
            Recept recept2 = new Recept(1, "bcd", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>());
            Recept recept3 = new Recept(2, "fgh", VrstaJela.DESERT, "Testni opis", 15, new Dictionary<Sastojak, double>(), KompleksnostPripreme.TESKO, new List<Ocjena>());
            knjigaRecepata.recepti.Add(recept3);
            knjigaRecepata.recepti.Add(recept1);
            knjigaRecepata.recepti.Add(recept2);
            knjigaRecepataService.sortirajPremaNazivu(knjigaRecepata);
            Assert.AreEqual("abc", knjigaRecepata.recepti[0].name);
        }

        public static IEnumerable<object[]> GenerateIspisanaKnjigaData
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new KnjigaRecepata(0, VrstaJela.DESERT, new List<Recept>
                        {
                            new Recept(1, "bcd", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(0, "abc", VrstaJela.DESERT, "Testni opis", 10, new Dictionary<Sastojak, double>(), KompleksnostPripreme.LAKO, new List<Ocjena>()),
                            new Recept(2, "fgh", VrstaJela.DESERT, "Testni opis", 15, new Dictionary<Sastojak, double>(), KompleksnostPripreme.TESKO, new List<Ocjena>())
                        }),
                        "Recept: abc\nVrsta jela: DESERT\nVrijeme pripreme: 10 minuta\nKompleksnost pripreme: LAKO\nSastojci:\nPriprema: Testni opis\nOcjene:\nRecept: bcd\nVrsta jela: DESERT\nVrijeme pripreme: 5 minuta\nKompleksnost pripreme: SREDNJE_TESKO\nSastojci:\nPriprema: Testni opis\nOcjene: \nRecept: fgh\nVrsta jela: DESERT\nVrijeme pripreme: 15 minuta\nKompleksnost pripreme: TESKO\nSastojci:\nPriprema: Testni opis\nOcjene: "
                    },
                    new object[] {
                        new KnjigaRecepata(1, VrstaJela.PREDJELO, new List<Recept>
                        {
                            new Recept(1, "bcd", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(2, "fgh", VrstaJela.DESERT, "Testni opis", 15, new Dictionary<Sastojak, double>(), KompleksnostPripreme.TESKO, new List<Ocjena>()),
                            new Recept(3, "ggg", VrstaJela.DESERT, "Testni opis", 25, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(4, "nesortirana", VrstaJela.DESERT, "Testni opis", 40, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(0, "abc", VrstaJela.DESERT, "Testni opis", 10, new Dictionary<Sastojak, double>(), KompleksnostPripreme.LAKO, new List<Ocjena>()),
                        }, true),
                        "Recept: bcd\nVrsta jela: DESERT\nVrijeme pripreme: 5 minuta\nKompleksnost pripreme: SREDNJE_TESKO\nSastojci:\nPriprema: Testni opis\nOcjene: \nRecept: fgh\nVrsta jela: DESERT\nVrijeme pripreme: 15 minuta\nKompleksnost pripreme: TESKO\nSastojci:\nPriprema: Testni opis\nOcjene: \nRecept: ggg\nVrsta jela: DESERT\nVrijeme pripreme: 25 minuta\nKompleksnost pripreme: SREDNJE_TESKO\nSastojci:\nPriprema: Testni opis\nOcjene: \nRecept: nesortirana\nVrsta jela: DESERT\nVrijeme pripreme: 40 minuta\nKompleksnost pripreme: SREDNJE_TESKO\nSastojci:\nPriprema: Testni opis\nOcjene: \n" +
                    "Recept: abc\nVrsta jela: DESERT\nVrijeme pripreme: 10 minuta\nKompleksnost pripreme: LAKO\nSastojci:\nPriprema: Testni opis\nOcjene: \n"
                    },
                    new object[]
                    {
                        new KnjigaRecepata(1, VrstaJela.PREDJELO, new List<Recept>{
                            new Recept(1, "bcd", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>{
                                { new Sastojak(1, "Šećer", 99.8, 0.0, 0.0, 0.0, 0.0, null, 0.5, MjernaJedinica.GRAM), 200.0 },
                                { new Sastojak(2, "Maslac", 0.1, 81.0, 0.9, 0.0, 1.0, Alergen.LAKTOZA, 2.0, MjernaJedinica.GRAM), 100.0 }}, KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>())
                        }), "Recept: bcd\nVrsta jela: DESERT\nVrijeme pripreme: 5 minuta\nKompleksnost pripreme: SREDNJE_TESKO\nSastojci:\n- Šećer: 200 g\n- Maslac: 100 g\nPriprema: Testni opis\nOcjene: "
                    }
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(GenerateIspisanaKnjigaData))]
        public void IspisiKnjiguRecepata_ShouldPrintSortedRecipes(KnjigaRecepata knjigaRecepata, string expectedOutput)
        {
            var result = knjigaRecepataService.ispisiKnjiguRecepata(knjigaRecepata);

            // Assert
            result = result.Replace("\r\n", "\n").Trim().Replace("\n", "").Replace(" ", "");
            expectedOutput = expectedOutput.Replace("\r\n", "\n").Trim().Replace("\n", "").Replace(" ", "");
            Console.WriteLine(result);
            //Console.WriteLine(expectedOutput);
            Assert.AreEqual(expectedOutput.Replace("\r\n", "\n").Trim(), result.Replace("\r\n", "\n").Trim());

        }

        [TestMethod]
        public void PretraziKnjiguRecepata_PostojiRecept_VracenRecept(){
            var knjigaRecepata = new KnjigaRecepata(1, VrstaJela.PREDJELO, new List<Recept>
                        {
                            new Recept(1, "bcd", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(3, "ggg", VrstaJela.DESERT, "Testni opis", 25, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(4, "nesortirana", VrstaJela.DESERT, "Testni opis", 40, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(0, "abc", VrstaJela.DESERT, "Testni opis", 10, new Dictionary<Sastojak, double>(), KompleksnostPripreme.LAKO, new List<Ocjena>()),
                            new Recept(2, "fgh", VrstaJela.DESERT, "Testni opis", 15, new Dictionary<Sastojak, double>(), KompleksnostPripreme.TESKO, new List<Ocjena>())});

            var rezultat = knjigaRecepataService.pretraziKnjiguRecepata(knjigaRecepata, "abc");
            Assert.AreEqual("abc", rezultat.name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PretraziKnjiguRecepata_NePostojiRecept_Izuzetak(){
            var knjigaRecepata = new KnjigaRecepata(1, VrstaJela.PREDJELO, new List<Recept>
                        {
                            new Recept(1, "bcd", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(3, "ggg", VrstaJela.DESERT, "Testni opis", 25, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(4, "nesortirana", VrstaJela.DESERT, "Testni opis", 40, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),
                            new Recept(0, "abc", VrstaJela.DESERT, "Testni opis", 10, new Dictionary<Sastojak, double>(), KompleksnostPripreme.LAKO, new List<Ocjena>()),
                            new Recept(2, "fgh", VrstaJela.DESERT, "Testni opis", 15, new Dictionary<Sastojak, double>(), KompleksnostPripreme.TESKO, new List<Ocjena>())});
            var rezultat = knjigaRecepataService.pretraziKnjiguRecepata(knjigaRecepata, "ne postoji");
        }

        [TestMethod]
        public void PretraziKnjiguRecepata_ReceptiIznadOcjenePostoje_VraceniRecepti(){
            var knjigaRecepata = new KnjigaRecepata(1, VrstaJela.PREDJELO, new List<Recept>
                        {
                            new Recept(1, "bcd", VrstaJela.DESERT, "Testni opis", 5, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>{new Ocjena(1, 5, ""), new Ocjena(2, 4, "")}),
                            new Recept(3, "ggg", VrstaJela.DESERT, "Testni opis", 25, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>{new Ocjena(1, 3, ""), new Ocjena(3, 5, "")}),
                            new Recept(4, "nesortirana", VrstaJela.DESERT, "Testni opis", 40, new Dictionary<Sastojak, double>(), KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>{new Ocjena(1, 4, "")}),
                            new Recept(0, "abc", VrstaJela.DESERT, "Testni opis", 10, new Dictionary<Sastojak, double>(), KompleksnostPripreme.LAKO, new List<Ocjena>{new Ocjena(1, 2, "")}),
                            new Recept(2, "fgh", VrstaJela.DESERT, "Testni opis", 15, new Dictionary<Sastojak, double>(), KompleksnostPripreme.TESKO, new List<Ocjena>{new Ocjena(1, 1, "")})});
            var rezultat = knjigaRecepataService.pretraziKnjiguRecepata(knjigaRecepata, 3);
            Assert.AreEqual(3, rezultat.Count);
            Assert.AreEqual("bcd", rezultat[0].name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PretraziKnjiguRecepata_ReceptiIznadOcjeneNePostoje_Izuzetak(){
            var knjigaRecepata = new KnjigaRecepata(1, VrstaJela.SALATA, new List<Recept>());
            var rezultat = knjigaRecepataService.pretraziKnjiguRecepata(knjigaRecepata, 3);
        }




    }
}
