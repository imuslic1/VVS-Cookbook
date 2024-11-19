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

            var ocjene3 = new List<Ocjena> { ocjena5, ocjena1, ocjena4 };
            var ocjene4 = new List<Ocjena> { ocjena3 };

            var sastojci = new List<Sastojak> {
                new Sastojak(1, "Brašno", 76.3, 1.0, 10.0, 2.7, 0.02, Alergen.GLUTEN, 0.5, MjernaJedinica.GRAM),
                new Sastojak(2, "Šećer", 99.8, 0.0, 0.0, 0.0, 0.01, null, 0.4, MjernaJedinica.GRAM),
                new Sastojak(3, "Maslac", 0.8, 81.0, 1.0, 0.0, 0.02, Alergen.LAKTOZA, 1.5, MjernaJedinica.GRAM),
                new Sastojak(4, "Med", 82.4, 0.0, 0.3, 0.2, 0.02, Alergen.MED, 2.0, MjernaJedinica.SUPENA_KASIKA)
            };


        }
        
    }
}
