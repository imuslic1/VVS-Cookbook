using Grupa4_Tim1_KnjigaRecepata.Models;

namespace Grupa4_Tim1_KnjigaRecepata.Data
{
    public class DbClass
    {
        public List<Sastojak> sastojci { get; set; }
        public List<Recept> recepti { get; set; }

        public DbClass() 
        { 
            sastojci = new List<Sastojak>{
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

            Ocjena ocjena1 = new Ocjena(1, 3, "...");
            Ocjena ocjena2 = new Ocjena(2, 5, "...");
            Ocjena ocjena3 = new Ocjena(2, 2, "...");
            Ocjena ocjena4 = new Ocjena(2, 1, "...");
            Ocjena ocjena5 = new Ocjena(2, 4, "...");

            var ocjene1 = new List<Ocjena> { ocjena1, ocjena2, ocjena3 };
            var ocjene2 = new List<Ocjena> { ocjena3, ocjena4, ocjena5 };
            var ocjene3 = new List<Ocjena> { ocjena5, ocjena1, ocjena4 };
            var ocjene4 = new List<Ocjena> { ocjena3 };
            var ocjene5 = new List<Ocjena> { ocjena5 };
            var ocjene6 = new List<Ocjena> { ocjena2, ocjena2, ocjena3, ocjena5 };

            recepti = new List<Recept>
            {
                new Recept(1, "Palacinke", VrstaJela.DESERT,
                    "Pomiješajte sastojke, ispecite na tavi.", 15,
                    new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[1], 50 }, { sastojci[3], 1 }, { sastojci[5], 200 } },
                    KompleksnostPripreme.LAKO, ocjene1),

                new Recept(2, "Pohovana piletina", VrstaJela.GLAVNO_JELO,
                    "Pohujte piletinu s brašnom i jajima, pržite do zlatne boje.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[0], 100 }, { sastojci[4], 1 }, { sastojci[6], 1 }, { sastojci[5], 150 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene3),

                new Recept(3, "Salata od rajcice", VrstaJela.SALATA,
                    "Nasjeckajte rajčicu i luk, začinite solju.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[9], 100 }, { sastojci[8], 20 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene5),

                new Recept(4, "Rižoto sa safranom", VrstaJela.GLAVNO_JELO,
                    "Pirjajte rižu, dodajte šafran i vodu, kuhajte do mekane teksture.", 40,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[6], 1 }, { sastojci[7], 20 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene4),

                new Recept(5, "Medeni kolacici", VrstaJela.DESERT,
                    "Pomiješajte sastojke i pecite 15 minuta.", 25,
                    new Dictionary<Sastojak, double> { { sastojci[3], 50 }, { sastojci[0], 100 }, { sastojci[1], 50 }, { sastojci[2], 20 } },
                    KompleksnostPripreme.LAKO, ocjene3),

                new Recept(6, "Juha od povrca", VrstaJela.PREDJELO,
                    "Kuhajte povrće u vodi s dodatkom soli.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[8], 50 }, { sastojci[9], 50 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene2),

                new Recept(7, "Omlet sa sirom", VrstaJela.PREDJELO,
                    "Izmiksajte jaja i sir, pecite u tavi.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[3], 2 }, { sastojci[7], 30 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene3),

                new Recept(8, "Smoothie od bademovog mlijeka", VrstaJela.DESERT,
                    "Pomiješajte sastojke u blenderu.", 5,
                    new Dictionary<Sastojak, double> { { sastojci[5], 200 }, { sastojci[7], 50 } },
                    KompleksnostPripreme.LAKO, ocjene2),

                new Recept(9, "Peceni krompirici", VrstaJela.PRILOG,
                    "Ispecite krumpiriće u pećnici uz dodatak soli.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[6], 1 } },
                    KompleksnostPripreme.LAKO, ocjene1),

                new Recept(10, "Spageti sa maslacem i cesnjakom", VrstaJela.GLAVNO_JELO,
                    "Skuhajte špagete, pomiješajte s maslacem i češnjakom.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[2], 30 }, { sastojci[6], 0.5 } },
                    KompleksnostPripreme.LAKO, ocjene6),

                new Recept(11, "Bademova torta", VrstaJela.DESERT,
                    "Pomiješajte bademe s brašnom i jajima, pecite.", 50,
                    new Dictionary<Sastojak, double> { { sastojci[7], 100 }, { sastojci[0], 100 }, { sastojci[4], 1 } },
                    KompleksnostPripreme.SREDNJE_TESKO, new List<Ocjena>()),

                new Recept(12, "Supa od rajcice", VrstaJela.PREDJELO,
                    "Pirjajte rajčice, dodajte vodu i začine.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[9], 200 }, { sastojci[6], 1 } },
                    KompleksnostPripreme.LAKO, ocjene4),

                new Recept(13, "Salata od badema i spinata", VrstaJela.SALATA,
                    "Pomiješajte špinat i bademe, začinite po želji.", 10,
                    new Dictionary<Sastojak, double> { { sastojci[7], 30 }, { sastojci[8], 50 } },
                    KompleksnostPripreme.LAKO, ocjene5),

                new Recept(14, "Strudla od jabuka", VrstaJela.DESERT,
                    "Pomiješajte sastojke, pecite dok ne porumeni.", 40,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[1], 50 }, { sastojci[2], 50 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene5),

                new Recept(15, "Riza sa povrcem", VrstaJela.PRILOG,
                    "Kuhajte rižu s povrćem dok ne omekša.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[8], 50 }, { sastojci[9], 50 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene1),

                new Recept(16, "Cokoladni kolac", VrstaJela.DESERT,
                    "Pomiješajte sastojke, pecite na 180°C.", 45,
                    new Dictionary<Sastojak, double> { { sastojci[0], 150 }, { sastojci[1], 100 }, { sastojci[2], 30 }, { sastojci[3], 1 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene2),

                new Recept(17, "Tjestenina Carbonara", VrstaJela.GLAVNO_JELO,
                    "Skuhajte tjesteninu, dodajte slaninu, sir i jaja.", 25,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[4], 1 }, { sastojci[7], 30 } },
                    KompleksnostPripreme.SREDNJE_TESKO, ocjene1),

                new Recept(18, "Muffini sa borovnicama", VrstaJela.DESERT,
                    "Pomiješajte sastojke, dodajte borovnice, pecite.", 35,
                    new Dictionary<Sastojak, double> { { sastojci[0], 200 }, { sastojci[1], 50 }, { sastojci[3], 1 } },
                    KompleksnostPripreme.TESKO, ocjene2),

                new Recept(19, "Vege burger", VrstaJela.GLAVNO_JELO,
                    "Pomiješajte povrće i brašno, oblikujte i pržite.", 20,
                    new Dictionary<Sastojak, double> { { sastojci[8], 50 }, { sastojci[9], 50 }, { sastojci[0], 50 } },
                    KompleksnostPripreme.PROFESIONALAC, ocjene4),

                new Recept(20, "Sos Bolognese", VrstaJela.GLAVNO_JELO,
                    "Pirjajte povrće i meso, kuhajte uz dodatak rajčice.", 30,
                    new Dictionary<Sastojak, double> { { sastojci[9], 100 }, { sastojci[8], 50 }, { sastojci[6], 1 } },
                    KompleksnostPripreme.PROFESIONALAC, ocjene6)
            };
        }
        public void addSastojak(Sastojak sastojak)
        {
            sastojci.Add(sastojak);
        }
        public Sastojak? getSastojak(int sastojakId)
        {
            return sastojci.FirstOrDefault(s => s.id == sastojakId);
        }
        public List<Sastojak> getAllSastojci()
        {
            return sastojci;
        }

        public void addRecept(Recept recept) { 
            recepti.Add(recept);
        }

        public Recept? getRecept(int receptId) {
            return recepti.FirstOrDefault(s => s.id == receptId);
        }
        public List<Recept> getAllRecepti()
        {
            return recepti;
        }
        public List<Recept> getReceptiForTipRecepta(VrstaJela vrstaJela)
        {
            return recepti.Where(r => r.tipRecepta == vrstaJela).ToList();
        }
    }
}
