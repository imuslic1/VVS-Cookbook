using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupa4_Tim1_KnjigaRecepata.Models
{
    public class Sastojak
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public double ugljikohidratiPoJedinici { get; set; }
        public double mastiPoJedinici { get; set; }
        public double proteiniPoJedinici { get; set; }
        public double vlaknaPoJedinici { get; set; }
        public double solPoJedinici { get; set; }
        public Alergen? alergen { get; set; }
        public double jedinicnaCijena { get; set; }
        public MjernaJedinica mjernaJedinica { get; set; }

        public Sastojak(int id, string naziv, double ugljikohidratiPoJedinici, 
                        double mastiPoJedinici, double proteiniPoJedinici, 
                        double vlaknaPoJedinici, double solPoJedinici, Alergen? alergen, 
                        double jedinicnaCijena, MjernaJedinica mjernaJedinica)
        {
            this.id = id;
            this.naziv = naziv;
            this.ugljikohidratiPoJedinici = ugljikohidratiPoJedinici;
            this.mastiPoJedinici = mastiPoJedinici;
            this.proteiniPoJedinici = proteiniPoJedinici;
            this.vlaknaPoJedinici = vlaknaPoJedinici;
            this.solPoJedinici = solPoJedinici;
            this.alergen = alergen;
            this.jedinicnaCijena = jedinicnaCijena;
            this.mjernaJedinica = mjernaJedinica;
        }

        public override bool Equals(object obj)
        {
            if (obj is Sastojak other)
            {
                return id == other.id &&
                       naziv == other.naziv &&
                       ugljikohidratiPoJedinici.Equals(other.ugljikohidratiPoJedinici) &&
                       mastiPoJedinici.Equals(other.mastiPoJedinici) &&
                       proteiniPoJedinici.Equals(other.proteiniPoJedinici) &&
                       vlaknaPoJedinici.Equals(other.vlaknaPoJedinici) &&
                       solPoJedinici.Equals(other.solPoJedinici) &&
                       alergen == other.alergen &&
                       jedinicnaCijena.Equals(other.jedinicnaCijena) &&
                       mjernaJedinica == other.mjernaJedinica;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + id.GetHashCode();
            hash = hash * 31 + (naziv != null ? naziv.GetHashCode() : 0);
            hash = hash * 31 + ugljikohidratiPoJedinici.GetHashCode();
            hash = hash * 31 + mastiPoJedinici.GetHashCode();
            hash = hash * 31 + proteiniPoJedinici.GetHashCode();
            hash = hash * 31 + vlaknaPoJedinici.GetHashCode();
            hash = hash * 31 + solPoJedinici.GetHashCode();
            hash = hash * 31 + (alergen != null ? alergen.GetHashCode() : 0);
            hash = hash * 31 + jedinicnaCijena.GetHashCode();
            hash = hash * 31 + (mjernaJedinica.GetHashCode());
            return hash;
        }
    }
}
