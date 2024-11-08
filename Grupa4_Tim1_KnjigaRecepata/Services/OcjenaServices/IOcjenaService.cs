using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupa4_Tim1_KnjigaRecepata.Models;

namespace Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices
{
    public interface IOcjenaService
    {
        double dajProsjecnuOcjenu(List<Ocjena> ocjene);
        void dodajOcjenu(Recept recept, Ocjena ocjena);
    }
}
