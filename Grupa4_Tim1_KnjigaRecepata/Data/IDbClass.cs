using Grupa4_Tim1_KnjigaRecepata.Models;

namespace Grupa4_Tim1_KnjigaRecepata.Data
{
    public interface IDbClass
    {
        public void addSastojak(Sastojak sastojak);
        public Sastojak? getSastojak(int sastojakId);
        public List<Sastojak> getAllSastojci();
        public void addRecept(Recept recept);
        public Recept? getRecept(int receptId);
        public List<Recept> getAllRecepti();
        public List<Recept> getReceptiForTipRecepta(VrstaJela vrstaJela);
    }
}
