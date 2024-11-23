using Grupa4_Tim1_KnjigaRecepata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Services.ShoppingListaServices
{
    public interface IShoppingListaService
    {
        string prikaziShoppingListu(ShoppingLista list);
        double cijenaSastojaka(Recept recept);
        string prikaziNedostajuceSastojke(Recept recept, string postojeci);
    }
}
