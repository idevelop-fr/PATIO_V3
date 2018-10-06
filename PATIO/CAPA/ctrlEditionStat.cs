using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.Classes;

namespace PATIO.CAPA
{
    public partial class ctrlEditionStat : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public Utilisateur user_appli;

        //Définition des structures
        class LigneS01
        {
            public int id;
            public string libelle;
            public int nb_obj;
            public int nb_action;
            public int nb_ope;
            public int nb_indic;
        }

        public ctrlEditionStat()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeStat();
        }

        void Afficher_ListeStat()
        {
            lstStat.Items.Clear();

            lstStat.Items.Add("S01 : Nombre d'éléments par plan");
        }

        void Afficher()
        {
            if (lstStat.SelectedIndex < 0) { return; }
            string codestat = lstStat.Text.Split(':')[0].Trim();

            if(codestat == "S01") { Stat_S01(); }

        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            Afficher();
        }

        void Stat_S01() //Nombre d'éléments par plan
        {
            string fichier = Chemin + "\\Fichiers\\F_S01.html";

            //Requête
            string sql;
            sql = "SELECT distinct element0_id, element2_type, element2_id from lien";
            sql += " WHERE element0_code <>'SYSTEME'";

            DataSet Sn = Acces.cls.ContenuRequete(sql);

            if(Acces.cls.NbLignes == 0) { goto Suite; }

            List<LigneS01> Liste = new List<LigneS01>();

            //Ligne total
            LigneS01 lg = new LigneS01();
            lg.id = 0;
            lg.libelle = "zzTOTAL";
            lg.nb_obj = 0;
            lg.nb_action = 0;
            lg.nb_ope = 0;
            lg.nb_indic = 0;
            Liste.Add(lg);

            foreach (DataRow r in Sn.Tables["dataset"].Rows)
            {
                int id_plan = int.Parse(r[0].ToString());
                int id_type = int.Parse(r[1].ToString());
                int id_element = int.Parse(r[2].ToString());

                //Détermine l'incrément affecté
                int i_obj = 0; int i_action = 0; int i_ope = 0; int i_indic = 0;

                if (id_type == Acces.type_OBJECTIF.id) { i_obj=1; }
                if (id_type == Acces.type_ACTION.id) //Cas d'une action
                {
                    PATIO.Classes.Action action = (PATIO.Classes.Action) Acces.Trouver_Element(id_type, id_element);
                    try
                    {
                        if (action.TypeAction == TypeAction.ACTION) { i_action=1; }
                        if (action.TypeAction == TypeAction.OPERATION) { i_ope=1; }
                    } catch { /*MessageBox.Show(r[2].ToString()); */}
                }
                if(id_type == Acces.type_INDICATEUR.id) { i_indic=1; }

                //Intégration si la ligne (du plan) existe
                Boolean ok = false;
                for(int i=0; i<Liste.Count;i++)
                {
                    LigneS01 l = Liste[i];
                    if(id_plan.ToString() == l.id.ToString())
                    {
                        ok = true;
                        l.nb_obj += i_obj;
                        l.nb_action += i_action;
                        l.nb_ope += i_ope;
                        l.nb_indic += i_indic;
                        break;
                    }
                }

                if(!ok) //Création de la ligne
                {
                    Plan plan = (Plan)Acces.Trouver_Element(Acces.type_PLAN.id, id_plan);
                    LigneS01 l = new LigneS01();
                    l.id = plan.ID;
                    l.libelle = plan.Libelle;
                    l.nb_obj += i_obj;
                    l.nb_action += i_action;
                    l.nb_ope += i_ope;
                    l.nb_indic += i_indic;
                    Liste.Add(l);
                }

                //Incrémentation sur la ligne total
                LigneS01 lt = Liste[0];
                lt.nb_obj += i_obj;
                lt.nb_action += i_action;
                lt.nb_ope += i_ope;
                lt.nb_indic += i_indic;
                Console.Ajouter(lt.nb_obj.ToString());
            }

            //Affichage du résultat
            string Texte = "<table width=\"100%\" border=\"1\">";

            Texte += "<tr>";
            Texte += "<td>Plan</td>";
            Texte += "<td>Nb objectifs</td>";
            Texte += "<td>Nb actions</td>";
            Texte += "<td>Nb opérations</td>";
            Texte += "<td>Nb indicateurs</td>";
            Texte += "</tr>\n";

            foreach (LigneS01 l in Liste)
            {
                Texte += "<tr>";
                Texte += "<td>" + l.libelle + "</td>";
                Texte += "<td>" + l.nb_obj + "</td>";
                Texte += "<td>" + l.nb_action + "</td>";
                Texte += "<td>" + l.nb_ope + "</td>";
                Texte += "<td>" + l.nb_indic + "</td>";
                Texte += "</tr>\n";
            }
            Texte += "</table>";

            //Ecriture du fichier
            System.IO.File.WriteAllText(fichier, Texte);

            Suite:;
            //Affichag du fichier
            wb.Navigate(fichier);
        }
    }
}
