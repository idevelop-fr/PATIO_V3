using System;
using System.Collections.Generic;
using PATIO.MAIN.Classes;
using System.Data;

namespace PATIO.MAIN.Classes
{
    public class TypeElement
    {
        public AccesNet Acces;
        public int ID { get; set; }
        public string Code { get; set; }
        public string Valeur = "";
        public string Valeur_6PO = "";

        public TypeElement()
        {

        }

        public TypeElement(string code, string valeur, string valeur_6po="")
        {
            Code = code;
            Valeur = valeur;
            Valeur_6PO = valeur_6po;
        }

        public TypeElement(string code, int id)
        {
            Code = code;
            ID = id;
        }

        public void Ajouter()
        {
            string sql;

            sql = "INSERT INTO table_valeur(nom, code, valeur, valeur_6PO) VALUES (";
            sql += "'TYPE_ELEMENT',";
            sql += "'" + Code + "',";
            sql += "'" + Valeur + "',";
            sql += "'" + Valeur_6PO + "')";

            Acces.cls.Execute(sql);

            sql = "SELECT ID FROM table_valeur";
            sql += " WHERE nom='TYPE_ELEMENT'";
            sql += " AND code='" + Code + "'";
            sql += " AND valeur='" + Valeur + "'";

            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes>0) { ID = int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString()); }
        }

        public void Supprimer()
        {
            string sql;

            sql = "DELETE FROM table_valeur";
            sql += " WHERE nom='TYPE_ELEMENT'";
            sql += " AND code=' " + Code + "'";
            sql += " AND valeur='" + Valeur + "'";
            Acces.cls.Execute(sql);
        }

        public bool Trouver()
        {
            string sql;

            sql = "SELECT ID FROM table_valeur";
            sql += " WHERE nom='TYPE_ELEMENT'";
            sql += " AND code='" + Code + "'";

            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes>0)
            {
                //Actualise l'ID d'après la base actuelle
                ID = int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString());
                return true;
            }

            return false;
        }
    }
}
