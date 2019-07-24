using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WC_SoapGestionProduit2;

namespace WS_SoapListeProduits
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public string AcheterProduit(string nom, int qte)
        {
            return ProduitDAO.Acheter(nom, qte);
        }
        public List<Produit> getListProduits()
        {
            return ProduitDAO.GetAll();
        }
    }
}
