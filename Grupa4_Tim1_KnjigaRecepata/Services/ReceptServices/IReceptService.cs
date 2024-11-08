using Grupa4_Tim1_KnjigaRecepata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices {
    public interface IReceptService {
        double dajUkupanBrojKalorija(Recept recept);
        void prikazi(Recept recept);
        void prikaziAlergene(Recept recept);
        void konvertujMjerneJedinice(Recept recept);
        void ocijeni(Recept recept);
    }
}
