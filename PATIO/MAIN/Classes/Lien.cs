using System;
using System.Data;
using PATIO.MAIN.Classes;

namespace PATIO.MAIN.Classes
{
    public class Lien : IComparable<Lien>
    {
        public AccesNet Acces;

        public int ID { get; set; }
        //Element0 : clé de Regroupement ex : Plan
        public int Element0_Type { get; set; }
        public string Element0_Code { get; set; }
        public int Element0_ID { get; set; }
        //Element1: clé représentant un parent dans la structure
        public int Element1_Type { get; set; }
        public string Element1_Code { get; set; }
        public int Element1_ID { get; set; }
        //Element1: clé représentant un fils dans la structure
        public int Element2_Type { get; set; }
        public string Element2_Code { get; set; }
        public int Element2_ID { get; set; }

        public int ordre=0;
        public string complement;

        //Met à jour les champs de la table Lien
        public void MettreAJour()
        {
            string sql;

            sql = "UPDATE lien SET ";
            sql += " Element0_Type='" + Element0_Type + "',";
            sql += " Element0_Code='" + Element0_Code + "',";
            sql += " Element0_ID='" + Element0_ID + "',";
            sql += " Element1_Type='" + Element1_Type + "',";
            sql += " Element1_Code='" + Element1_Code + "',";
            sql += " Element1_ID='" + Element1_ID + "',";
            sql += " Element2_Type='" + Element2_Type + "',";
            sql += " Element2_Code='" + Element2_Code + "',";
            sql += " Element2_ID='" + Element2_ID + "',";
            sql += " ordre='" + ordre + "',";
            sql += " complement='" + complement + "'";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        //Ajouter un nouveau lien
        public void Ajouter()
        {
            string sql;

            //Ajoute des informations
            sql = "INSERT INTO lien (Element0_Type, Element0_Code, Element0_ID,";
            sql += " Element1_Type, Element1_Code, Element1_ID,";
            sql += " Element2_Type, Element2_Code, Element2_ID,";
            sql += " ordre, complement) VALUES (";
            sql += "'" + Element0_Type + "',";
            sql += "'" + Element0_Code + "',";
            sql += "'" + Element0_ID + "',";
            sql += "'" + Element1_Type + "',";
            sql += "'" + Element1_Code + "',";
            sql += "'" + Element1_ID + "',";
            sql += "'" + Element2_Type + "',";
            sql += "'" + Element2_Code + "',";
            sql += "'" + Element2_ID + "',";
            sql += "'" + ordre + "',";
            sql += "'" + complement + "')";

            Acces.cls.Execute(sql);

            //Recherche de l'ID
            sql = "SELECT id FROM lien";
            sql += " WHERE Element0_ID='" + Element0_ID + "'";
            sql += " AND Element1_ID='" + Element1_ID + "'";
            sql += " AND Element2_ID='" + Element2_ID + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes ==0) { return; }
            ID = int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString());
        }

        //Supprimer un lien
        public void Supprimer()
        {
            string sql;

            sql = "DELETE FROM lien";
            sql += " WHERE ID='" + ID + "'";
            Acces.cls.Execute(sql);
        }

        //Donne l'ordre max des enfants du lien
        public int Donner_Ordre()
        {
            string sql;
            sql = "SELECT max(ordre) as maxordre FROM lien";
            sql += " WHERE Element0_ID = '" + Element0_ID + "'";
            sql += " AND Element1_ID = '" + Element1_ID + "'";

            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes == 0) { return 0; }

            try
            {
                if (Sn.Tables["dataset"].Rows[0][0].ToString().Length > 0)
                { return int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString()); }
                else
                { return 0; }
            }
            catch { return 0; }
        }

        public Boolean Exister_Lien(string Element0_Type, string Element0_Code, string Element1_Type, string Element1_Code, string Element2_Type, string Element2_Code)
        {
            string sql;

            sql = "SELECT * FROM lien";
            sql += " WHERE Element0_Type='" + Element0_Type + "'";
            sql += " AND Element0_Code='" + Element0_Code + "'";
            sql += " AND Element1_Type='" + Element1_Type + "'";
            sql += " AND Element1_Code='" + Element1_Code + "'";
            sql += " AND Element2_Type='" + Element2_Type + "'";
            sql += " AND Element2_Code='" + Element2_Code + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes==0) { return false; }

            return true;
        }

        //Met à jour les codes lors d'une modification du code sur l'objet
        public void MettreAJourCode(TypeElement typeelement,int id, string code)
        {
            string sql;

            sql = "UPDATE lien SET Element0_Code='" + code + "'";
            sql += " WHERE Element0_Type='" + typeelement.ID + "'";
            sql += " AND Element0_ID='" + id + "'";
            Acces.cls.Execute(sql);

            sql = "UPDATE lien SET Element1_Code='" + code + "'";
            sql += " WHERE Element1_Type='" + typeelement.ID + "'";
            sql += " AND Element1_ID='" + id + "'";
            Acces.cls.Execute(sql);

            sql = "UPDATE lien SET Element2_Code='" + code + "'";
            sql += " WHERE Element2_Type='" + typeelement.ID + "'";
            sql += " AND Element2_ID='" + id + "'";
            Acces.cls.Execute(sql);
        }

        //Comparateur par défaut
        public int CompareTo(Lien p)
        {
            if (p is null) { return 1; }
            else
            {
                string A = Element0_Type.ToString()
                           + Element1_Type.ToString()
                           + Element2_Type.ToString()
                           + Element0_Code + Element1_Code
                           + string.Format("{0,5:X5}", ordre);
                string B = p.Element0_Type.ToString()
                           + p.Element1_Type.ToString()
                           + p.Element2_Type.ToString()
                           + p.Element0_Code + p.Element1_Code
                           + string.Format("{0,5:X5}", p.ordre);

                return (A.CompareTo(B));
            }
        }

        public int ComparePlan(Lien p)
        {
            if (p is null) { return 1; }
            else
            {
                string A = Element0_Code;
                string B = p.Element0_Code;

                return (A.CompareTo(B));
            }
        }
    }
}
