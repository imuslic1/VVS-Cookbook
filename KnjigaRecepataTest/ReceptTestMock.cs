using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KnjigaRecepataTest
{
    [TestClass]
    public class ReceptMockTests
    {
        // Fake implementacija interfejsa
        public class FakeSastojakService : ISastojakService
        {
            public double dajBrojKalorijaPoJedinici(Sastojak? sastojak)
            { 
                return sastojak.ugljikohidratiPoJedinici * 4 +
                       sastojak.mastiPoJedinici * 9 +
                       sastojak.proteiniPoJedinici * 4 +
                       sastojak.vlaknaPoJedinici * 2;
            }

            public string dajSkracenicu(MjernaJedinica jedinica)
            {
                return jedinica switch {
                    MjernaJedinica.SUPENA_KASIKA => "tbsp",
                    MjernaJedinica.CASA => "cup",
                    MjernaJedinica.GRAM => "g",
                    _ => ""
                };
            }

            public void prikaziSastojak(Sastojak sastojak)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void DajUkupanBrojKalorija_IspravniPodaci_IspravanUkupanBrojKalorija()
        {
            var sastojakService = new FakeSastojakService();
            DbClass baza = new DbClass();

            var sastojak1 = new Sastojak(1, "Brašno", 76.3, 1.0, 10.0, 2.7, 0.02, Alergen.GLUTEN, 0.5, MjernaJedinica.CASA);
            var sastojak2 = new Sastojak(2, "Šećer", 99.8, 0.0, 0.0, 0.0, 0.01, null, 0.4, MjernaJedinica.GRAM);

            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            var ocjene1 = new List<Ocjena> { ocjena1, ocjena2 };

            var recept = new Recept(2, "Pohovana piletina", VrstaJela.GLAVNO_JELO,
                            "Pohujte piletinu s brašnom i jajima, pržite do zlatne boje.", 30,
                            new Dictionary<Sastojak, double> { { sastojak1, 2 }, { sastojak2, 1 }, },
                            KompleksnostPripreme.SREDNJE_TESKO, ocjene1);

            var receptService = new ReceptService(baza, sastojakService);

            var result = receptService.dajUkupanBrojKalorija(recept);

            var expected = (76.3 * 4 + 1 * 9 + 10 * 4 + 2.7 * 2) * 2 +
                           (99.8 * 4 + 0 * 9 + 0 * 4 + 0 * 2) * 1;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PrikaziRecept_IspravniPodaci_IspravanPrikaz() {
            var sastojakService = new FakeSastojakService();
            DbClass baza = new DbClass();

            var sastojak1 = new Sastojak(1, "Vrhnje za slag", 6.6, 88, 5.8, 0, 0.066, Alergen.LAKTOZA, 1.5, MjernaJedinica.CASA);
            var sastojak2 = new Sastojak(2, "Tamna cokolada", 0.23, 0.405, 0.08, 0.055, 0, Alergen.ORASASTI_PLODOVI, 0.02, MjernaJedinica.GRAM);
            var sastojak3 = new Sastojak(3, "Med", 17, 0, 0.1, 0, 0, Alergen.MED, 0.63, MjernaJedinica.SUPENA_KASIKA);

            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            var ocjene1 = new List<Ocjena> { ocjena1, ocjena2 };

            var recept = new Recept
                (
                    1,
                    "Cokoladni mousse",
                    VrstaJela.DESERT,
                    "Otopite cokoladu, dodajte vrhnje i med, izmiksajte i ostavite u frizideru.",
                    20,
                    new Dictionary<Sastojak, double>
                    {
                        { sastojak1, 1 },
                        { sastojak2, 50 },
                        { sastojak3, 10 }
                    },
                    KompleksnostPripreme.LAKO,
                    ocjene1
                );

            var receptService = new ReceptService(baza, sastojakService);
            var rezultat = receptService.prikazi(recept);

            // Pri korektnom ispisu, treba da sadrži:
            Assert.IsTrue(rezultat.Contains("Cokoladni mousse"));
            Assert.IsTrue(rezultat.Contains("Vrhnje za slag"));
            Assert.IsTrue(rezultat.Contains("Tamna cokolada"));
            Assert.IsTrue(rezultat.Contains("Med"));
            Assert.IsTrue(rezultat.Contains("cup"));
            Assert.IsTrue(rezultat.Contains("tbsp"));


            // Nije korištena ova mjerna jedinica
            Assert.IsTrue(!rezultat.Contains("ml"));


        }
    }
}
