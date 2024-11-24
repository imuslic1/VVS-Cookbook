using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices;
using Grupa4_Tim1_KnjigaRecepata.Services.ShoppingListaServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KnjigaRecepataTest
{
    public class StubSastojakService : SastojakService
    {
        public StubSastojakService() : base(null) { }

        public string dajSkracenicu(MjernaJedinica jedinica)
        {
            return jedinica switch
            {
                MjernaJedinica.GRAM => "g",
                MjernaJedinica.MILILITAR => "ml",
                _ => "n/a"
            };
        }
    }

    [TestClass]
    public class ShoppingListaTestStub
    {
            [TestMethod]
            public void PrikaziShoppingListuSaStub()
            {
                var stubSastojakService = new StubSastojakService();
                var shoppingListaService = new ShoppingListaService(null, stubSastojakService);

                var sastojak1 = new Sastojak(1, "Brašno", 10, 1, 2, 3, 0.5, null, 1.5, MjernaJedinica.GRAM);
                var sastojak2 = new Sastojak(2, "Mlijeko", 12, 5, 3, 2, 0.7, null, 0.8, MjernaJedinica.MILILITAR);

                var recept = new Recept
                (
                    1,
                    "Palačinke",
                    VrstaJela.DESERT,
                    "Sve sastojke izmiješati i ispeći na tavi.",
                    20,
                    new Dictionary<Sastojak, double>
                        {
                            { sastojak1, 500 }, // 500 g brašna
                            { sastojak2, 1000 }    // 1000 ml mlijeka
                        },
                    KompleksnostPripreme.LAKO,
                    new List<Ocjena>()

                );

                var shoppingLista = new ShoppingLista(recept);

                var rezultat = shoppingListaService.prikaziShoppingListu(shoppingLista);

                Assert.IsTrue(rezultat.Contains("Palačinke"));
                Assert.IsTrue(rezultat.Contains("Brašno"));
                Assert.IsTrue(rezultat.Contains("Mlijeko"));
                Assert.IsTrue(rezultat.Contains(shoppingListaService.cijenaSastojaka(recept).ToString()));
            }
    }
}
