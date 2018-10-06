using System;
using System.Collections.Generic;
using System.Data;
using PATIO.Modules;
using System.Windows.Forms;

namespace PATIO.OMEGA.Classes
{
    public class AccesNet
    {
        public ClassePHP cls;
        public string Chemin;

        public ctrlConsole Console;

        public Fonctions fonc = new Fonctions();

        List<Element> Liste_Element = new List<Element>();
        List<dElement> Liste_dElement = new List<dElement>();
        public List<Lien> ListeLien = new List<Lien>();

        public AccesNet()
        {
        }

        public Boolean Initialiser()
        {
            cls = new ClassePHP();
            cls.Trace = true; //Active le traçage des requêtes pour le débuggage
            cls.Chemin = Chemin;
            if (!cls.Initialiser()) { return false; }

            cls.Console = Console;

           // Nettoyer(); //Corrige automatiquement les bugs possibles

            //Corriger_tv();
            //Charger_ListeTableValeur();

            Charger_Element();
            Charger_Lien();
            //Charger_ListeParametre();
            //Charger_ListeAttribut();

            //Remplir_ListeElement(type_UTILISATEUR.id, "");
            return true;
        }

        //Intègre l'ensemble des éléments en mémoire
        //Evite de faire un appel récurrent
        public void Charger_Element()
        {
            string sql = "";

            Liste_Element = new List<Element>();
            Liste_dElement = new List<dElement>();
            ListeLien = new List<Lien>();

            //ELEMENT
            sql = "SELECT * FROM element";
            DataSet Sn = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                Element e = new Element();
                e.ID = int.Parse(r["id"].ToString());
                e.Element_Type = int.Parse(r["element_type"].ToString());
                e.Code = r["code"].ToString();
                e.Libelle = r["libelle"].ToString();
                e.Type_Element = int.Parse(r["type_element"].ToString());
                e.Actif = (r["actif"].ToString() == "1");

                Liste_Element.Add(e);
            }

            //Recherche des détails des éléments DELEMENT
            sql = "SELECT * FROM delement";

            //DataSet DSn = cls.ContenuTable("delement");
            DataSet DSn = cls.ContenuRequete(sql);
            foreach (DataRow r in DSn.Tables["dataset"].Rows)
            {
                dElement de = new dElement();
                de.ID = int.Parse(r["id"].ToString());
                de.Element_ID = int.Parse(r["element_id"].ToString());
                de.Attribut_ID = int.Parse(r["attribut_id"].ToString());
                de.Attribut_Code = r["attribut_code"].ToString();
                de.Valeur = r["Valeur"].ToString();
                Liste_dElement.Add(de);
            }

            //Rattachement des détails aux éléments principaux
            foreach (Element e in Liste_Element)
            {
                foreach (dElement d in Liste_dElement)
                {
                    if (e.ID == d.Element_ID) { e.Liste.Add(d); }
                }
            }
        }

        /// <summary>
        /// Procédure de chargement de la liste des liens
        /// </summary>
        public void Charger_Lien(Boolean InclusSysteme=true)
        {
            //LIEN
            string sql = "SELECT * FROM lien";
            if(!InclusSysteme) { sql += " WHERE element0_code <>'SYSTEME'"; }
            /*sql += " ORDER BY element0_type, element1_type, element2_type,";
            sql += " element0_code, element1_code, ordre";*/

            DataSet SnLien = cls.ContenuRequete(sql);

            if (cls.NbLignes == 0) { return; }

            foreach (DataRow r in SnLien.Tables["dataset"].Rows)
            {
                Lien l = new Lien();
                l.ID = int.Parse(r["id"].ToString());
                l.element0_type = int.Parse(r["element0_type"].ToString());
                l.element0_code = r["element0_code"].ToString();
                l.element0_id = int.Parse(r["element0_id"].ToString());
                l.element1_type = int.Parse(r["element1_type"].ToString());
                l.element1_code = r["element1_code"].ToString();
                l.element1_id = int.Parse(r["element1_id"].ToString());
                l.element2_type = int.Parse(r["element2_type"].ToString());
                l.element2_code = r["element2_code"].ToString();
                l.element2_id = int.Parse(r["element2_id"].ToString());
                l.ordre = int.Parse(r["ordre"].ToString());
                l.complement = r["complement"].ToString();
                ListeLien.Add(l);
            }
        }

    }
}
