using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupa4_Tim1_KnjigaRecepata.Models;

namespace Grupa4_Tim1_KnjigaRecepata.Services.KnjigaRecepataServices
{
    public interface IKnjigaRecepataService{
        void dodajRecept(KnjigaRecepata knjigaRecepata, Recept recept);
        void sortirajPremaVremenuPripreme(KnjigaRecepata knjigaRecepata);
        void sortirajPremaKompleksnosti(KnjigaRecepata knjigaRecepata);
        void sortirajPremaNazivu(KnjigaRecepata knjigaRecepata);
        void ispisiKnjiguRecepata(KnjigaRecepata knjigaRecepata);
        Recept pretraziKnjiguRecepata(KnjigaRecepata knjigaRecepata, String naziv);
        List<Recept> pretraziKnjiguRecepata(KnjigaRecepata knjigaRecepata, double ocjena);
    }
}
