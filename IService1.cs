using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WC_SoapGestionProduit2;

namespace WS_SoapListeProduits
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string  AcheterProduit(String nom, int qte);

        [OperationContract]
        List<Produit> getListProduits();
    }
}
