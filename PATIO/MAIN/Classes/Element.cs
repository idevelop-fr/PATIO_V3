using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PATIO.MAIN.Classes
{
    public class Element
    {
        public AccesNet Acces;

        public int ID { get; set; }
        public int Element_Type { get; set; }
        public String Code { get; set; }
        public String Libelle { get; set; }
        public int Type_Element { get; set; }
        public Boolean Actif { get; set; }

        public List<dElement> Liste = new List<dElement>();

        public Element()
        {
            Liste = new List<dElement>();
        }

        //Procédure de suppression de l'ensemble ds informations relatives à l'élément
        public Boolean Supprimer()
        {
            string sql;

            sql = "DELETE FROM element";
            sql += " WHERE element_type='" + Element_Type + "'";
            sql += " AND id='" + ID + "'";

            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { return false; }

            sql = "DELETE FROM delement";
            sql += " WHERE element_id='" + ID + "'";

            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { return false; }

            return true;
        }

        //Met à jour les informations relative à l'élémént
        public Boolean MettreAJour()
        {
            string sql;

            //Mise à jour des informations principales relatives à l'élément
            sql = "UPDATE element SET ";
            sql += " code='" + Code + "',";
            sql += " libelle='" + CorrigeTexte(Libelle.Replace("'", "''")) + "',";
            sql += " type_element='" + Type_Element + "',";
            sql += " actif='" + (Actif ? "1" : "0") + "'";
            sql += " WHERE id='" + ID + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); return false; }

            //Suppresion des détails existants
            sql = "DELETE FROM delement";
            sql += " WHERE element_id='" + ID + "'";
            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); return false; }

            //Ajout des détails (non vide)
            foreach (dElement d in Liste) //On balaie la liste des détails de l'élément
            {
                if(d.Valeur != null)
                { 
                    if (d.Valeur.Trim().Length > 0)
                    {
                        sql = "INSERT INTO delement (element_id, attribut_id, attribut_code, valeur) ";
                        sql += " VALUES (";
                        sql += "'" + ID + "',";
                        sql += "'" + d.Attribut_ID + "',";
                        sql += "'" + d.Attribut_Code + "',";
                        sql += "'" + d.Valeur.Replace("'", "''") + "')";
                        Acces.cls.Execute(sql);
                    }
                }
            }

            //Suppression des détails d'informations
            Acces.Actualiser_dElement(ID);

            return true;
        }

        public int Enregistrer()
        {
            string sql = "";

            //Insertion des informations
            sql = "INSERT INTO element (element_type, code, libelle, type_element, actif) VALUES (";
            sql += "'" + Element_Type + "',";
            sql += "'" + Code + "',";
            sql += "'" + CorrigeTexte(Libelle.Replace("'","''")) + "',";
            sql += "'" + Type_Element + "',";
            sql += "'" + (Actif ? "1":"0") + "')";

            Acces.cls.Execute(sql);
            if (Acces.cls.erreur.Length > 0) { MessageBox.Show("Erreur dans la requête"); }

            //Recherche de l'identifiant attribué
            sql = "SELECT id FROM element";
            sql += " WHERE element_type='" + Element_Type + "'";
            sql += " AND code='" + Code + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            ID = 0;
            if (Acces.cls.NbLignes > 0) { ID =int.Parse(Sn.Tables["dataset"].Rows[0][0].ToString()); }
            else { return 0; }

            for(int i =0; i< Liste.Count; i++)
            {
                if (Liste[i].Attribut_ID == 0)
                {
                    MessageBox.Show("Le valeur de l'attribut " + Liste[i].Attribut_Code + " n'existe pas");
                }

                Liste[i].ID = ID;
                if (Liste[i].Valeur != null)
                {
                    sql = "INSERT INTO delement(element_id, attribut_id, attribut_code, valeur) VALUES (";
                    sql += "'" + Liste[i].ID + "',";
                    sql += "'" + Liste[i].Attribut_ID + "',";
                    sql += "'" + Liste[i].Attribut_Code + "',";
                    sql += "'" + Liste[i].Valeur.Replace("'", "''") + "')";
                    Acces.cls.Execute(sql);
                    if (Acces.cls.erreur.Length > 0) { MessageBox.Show(Acces.cls.erreur); }
                }
            }

            return ID;
        }

        string CorrigeTexte(string txt)
        {
            string texte = "";

            //Correction des caractères
            txt = txt.Replace("\u009c", "oe").Replace("\u0085", "");
            txt = txt.Replace("\u0092", "'");

            for (int i = 0; i < txt.Length; i++)
            {
                char c = txt[i];
                int ichar = (int)c;

                switch (ichar)
                {
                    case 145: { c = (char)44; break; }
                    case 146: { c = (char)44; break; }
                    case 150: { c = ' '; break; }
                    case 160: { c = ' '; break; }
                    default: { break; }
                }

                texte += c;
            }

            return texte;
        }

        public void Charger_dElement()
        {
            Liste = new List<dElement>();
            foreach (dElement d in Acces.Liste_dElement)
            {
                if(d.Element_ID == ID) { Liste.Add(d); }
            }
        }
    }
}
