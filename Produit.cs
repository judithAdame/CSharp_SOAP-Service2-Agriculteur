using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC_SoapGestionProduit2
{
    public class Produit
    {
        private string nom;
        private int qte;
        private double prix;
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                this.nom = ((value.Length < 1) ? "" : value);
            }
        }
        public int Qte {
            get
            {
                return qte;
            }
            set
            {
                this.qte = ((value < 0) ? 0 : value);
            }
        }
        public double Prix {
            get
            {
                return prix;
            }
            set
            {
                this.prix = ((value < 0) ? 0 : value);
            }
        }

    }
}
