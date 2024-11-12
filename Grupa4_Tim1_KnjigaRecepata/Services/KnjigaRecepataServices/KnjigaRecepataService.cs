using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupa4_Tim1_KnjigaRecepata.Data;
using Grupa4_Tim1_KnjigaRecepata.Models;
using Grupa4_Tim1_KnjigaRecepata.Services.ReceptServices;
using Grupa4_Tim1_KnjigaRecepata.Services.OcjenaServices;

namespace Grupa4_Tim1_KnjigaRecepata.Services.KnjigaRecepataServices
{
    public class KnjigaRecepataService : IKnjigaRecepataService
    {
        private readonly DbClass _db;
        private readonly ReceptService _receptService;
        private readonly OcjenaService _ocjenaService;

        public KnjigaRecepataService(DbClass db, ReceptService receptService, OcjenaService ocjenaService)
        {
            _db = db;
            _receptService = receptService;
            _ocjenaService = ocjenaService;
        }
        public void dodajRecept(KnjigaRecepata knjigaRecepata, Recept recept)
        {
            if (knjigaRecepata.tip != recept.tipRecepta)
            {
                throw new ArgumentException("Tip knjige i tip recepta moraju biti isti!");
            }
            knjigaRecepata.recepti.Add(recept);
        }
        public void sortirajPremaVremenuPripreme(KnjigaRecepata knjigaRecepata)
        {
            knjigaRecepata.recepti.OrderBy(r => r.vrijemePripreme).ToList();
            knjigaRecepata.sortirana = true;
        }
        public void sortirajPremaKompleksnosti(KnjigaRecepata knjigaRecepata)
        {
            knjigaRecepata.recepti.OrderBy(r => r.kompleksnost).ToList();
            knjigaRecepata.sortirana = true;
        }
        public void sortirajPremaNazivu(KnjigaRecepata knjigaRecepata)
        {
            knjigaRecepata.recepti.OrderBy(r => r.name).ToList();
            knjigaRecepata.sortirana = true;
        }
        // NOTICE: Mrvicu je nelogično da se (kako je navedeno u specifikaciji) vrši ispis isključivo po nazivu, jer onda
        // efektivno druge dvije metode sortiranja apsolutno ničemu ne koriste tako da sam dodao atribut "sortiran" koji
        // označava da li je knjiga recepata već sortirana po nekom redoslijedu, ukoliko nije bazni sort će biti po nazivu
        // u suprotnom će sadržati već određeni sort.
        public void ispisiKnjiguRecepata(KnjigaRecepata knjigaRecepata)
        {
            if (!knjigaRecepata.sortirana)
            {
                sortirajPremaNazivu(knjigaRecepata);
            }
            var sortiraniRecepti = knjigaRecepata.recepti;
            foreach (var recept in sortiraniRecepti)
            {
                Console.WriteLine($"Naziv: {recept.name}, Priprema: {recept.priprema}, Vrijeme pripreme: {recept.vrijemePripreme} minuta, Kompleksnost: {recept.kompleksnost}");
                Console.WriteLine("Sastojci:");
                var sastojci = recept.sastojci;
                foreach (var sastojak in sastojci)
                {
                    Console.WriteLine($"Naziv sastojka: {sastojak.Key.naziv}, Količina: {sastojak.Value}g");
                }
            }
        }
        public Recept pretraziKnjiguRecepata(KnjigaRecepata knjigaRecepata, String naziv)
        {
            var listaIstih = knjigaRecepata.recepti.Where(r => r.name.ToLower() == naziv.ToLower());
            var recept = listaIstih.FirstOrDefault();
            if (recept == null)
            {
                throw new Exception("Recept nije pronađen!");
            }
            return recept;
        }
        public List<Recept> pretraziKnjiguRecepata(KnjigaRecepata knjigaRecepata, double ocjena)
        {
            var listaOdgovarajućih = knjigaRecepata.recepti.Where(r => _ocjenaService.dajProsjecnuOcjenu(r.ocjene) >= ocjena);
            var pronađeniRecepti = listaOdgovarajućih.ToList();
            if (pronađeniRecepti.Count == 0)
            {
                throw new Exception("Nijedan recept nije pronađen sa željenom ocjenom");
            }
            return pronađeniRecepti;
        }
    }
}
