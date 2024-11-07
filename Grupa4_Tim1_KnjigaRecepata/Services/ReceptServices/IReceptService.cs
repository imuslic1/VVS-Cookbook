using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices {
    public interface IReceptService {
        double dajUkupanBrojKalorija();
        string prikazi();
        string prikaziAlergene();
        void konvertujMjerneJedinice();
    }
}
