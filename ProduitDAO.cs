using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WC_SoapGestionProduit2;

namespace WS_SoapListeProduits
{
    public class ProduitDAO
    {
        public static string Acheter(string nom, int qte)
        {
            if (qte > 0)
            {
                int stock = GetQte(nom);
                if (stock > 0)
                {
                    if (stock > 0 && qte <= stock)
                    {
                        int newQte = stock - qte;
                        string sql = "UPDATE PRODUIT SET QTE = :newQteProduit WHERE NOM = :nomProduit";

                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = Connection.GetConnection();
                        if (cmd.Connection != null)
                        {
                            cmd.CommandText = sql;
                            cmd.CommandType = System.Data.CommandType.Text;

                            OracleParameter pNewQte = new OracleParameter();
                            pNewQte.Value = newQte;
                            pNewQte.ParameterName = "newQteProduit";
                            cmd.Parameters.Add(pNewQte);

                            OracleParameter pNom = new OracleParameter();
                            pNom.Value = nom;
                            pNom.ParameterName = "nomProduit";
                            cmd.Parameters.Add(pNom);

                            cmd.ExecuteNonQuery();

                            cmd.Dispose();

                            Connection.CloseConnection(cmd.Connection);

                            return "Vous vennez d'acheter " + qte + " des " + nom + ", nouvelle qte " + newQte;
                        }
                        else
                            return "Erreur de connection";
                    }
                    else
                        return "Il n'y pas assez de stock, vous avez commander " + qte + " mais le stock max est " + stock + ")";
                }
                else
                    return "Le produit " + nom + " n'existe pas";
            }
            else
                return "La Qte doit etre positive";
        }

        public static int GetQte(string nom)
        {
            string sql = "SELECT QTE FROM PRODUIT WHERE NOM = :nomProduit";
            int qte = -1;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = Connection.GetConnection();
            if (cmd.Connection != null)
            {
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                OracleParameter pNom = new OracleParameter();
                pNom.Value = nom;
                pNom.ParameterName = "nomProduit";

                cmd.Parameters.Add(pNom);

                cmd.ExecuteNonQuery();

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    qte = (int)reader[0];
                }

                cmd.Dispose();

                Connection.CloseConnection(cmd.Connection);

                return qte;
            }
            else
                return qte;
        }
        public static List<Produit> GetAll()
        {
            List<Produit> listProduits = new List<Produit>();
            string sql = "SELECT NOM, QTE, PRIX FROM PRODUIT WHERE NOT(QTE = 0)";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = Connection.GetConnection();
            if (cmd.Connection != null)
            {
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;

                //cmd.CommandText = "produit";
                //cmd.CommandType = CommandType.TableDirect;

                cmd.ExecuteNonQuery();

                OracleDataReader reader = cmd.ExecuteReader();
                Produit produit;
                while (reader.Read())
                {
                    produit = new Produit
                    {
                        Nom = Convert.ToString(reader["NOM"]),
                        Qte = Convert.ToInt32(reader["QTE"]),
                        Prix = Convert.ToDouble(reader["PRIX"], System.Globalization.CultureInfo.InvariantCulture)
                    };
                    listProduits.Add(produit);
                }

                cmd.Dispose();

                Connection.CloseConnection(cmd.Connection);

                return listProduits;
            }
            else
                return listProduits;
        }
    }
}
