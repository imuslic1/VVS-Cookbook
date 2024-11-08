using Grupa4_Tim1_KnjigaRecepata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Services.SastojakServices
{
    public interface ISastojakService
    {
        double dajBrojKalorijaPoJedinici(Sastojak sastojak);
        void prikaziSastojak(Sastojak sastojak);
        string dajSkracenicu(MjernaJedinica jedinica);
    }
}
