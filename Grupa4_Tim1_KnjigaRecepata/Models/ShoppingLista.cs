using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Models
{
    internal class ShoppingLista
    { 
        public Recept recept {  get; set; }

        public ShoppingLista(Recept recept)
        {
            this.recept = recept;
        }
    }
}
