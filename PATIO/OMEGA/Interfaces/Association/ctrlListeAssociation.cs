using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.OMEGA.Classes;
using PATIO.MAIN.Classes;

namespace PATIO.OMEGA.Interfaces.Association
{
    public partial class ctrlListeAssociation : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;
        public Budget budget;
        public Budget_Version budget_version;

        List<Budget> listeBudget;
        List<Budget_Periode> listeBudgetPeriode;
        List<Budget_Version> listeBudgetVersion;

        int Periode_choix = 0;

        public ctrlListeAssociation()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListePeriode();
        }

        void Afficher_ListePeriode()
        {
            lstPeriode.Items.Clear();

            listeBudgetPeriode = (List<Budget_Periode>)Acces.Remplir_ListeElement(Acces.type_BUDGET_PERIODE, "", true);

            foreach (Budget_Periode bp in listeBudgetPeriode)
            {
                lstPeriode.Items.Add(bp.Libelle);
            }

            if (lstPeriode.Items.Count > 0) { lstPeriode.SelectedIndex = 0; }
        }

        public void Afficher_ListeBudget()
        {
            lstBudget.Nodes.Clear();

            if (lstPeriode.SelectedIndex < 0) { return; }

            listeBudget = Acces.clsOMEGA.Remplir_ListeBudget(Periode_choix);

            foreach (Budget bg in listeBudget)
            {
                //if(bg. == )
                TreeNode nd = new TreeNode(bg.Libelle);
                nd.Name = bg.ID.ToString();
                nd.Tag = bg;
                //Ajout des sous-dossiers
                /*TreeNode nd_ligne = new TreeNode("Lignes budgétaires"); nd_ligne.Tag = "LIGNE";
                TreeNode nd_version = new TreeNode("Versions"); nd_version.Tag = "VERSION";
                //nd.Nodes.Add(nd_ligne);
                nd.Nodes.Add(nd_version);*/
                nd.Expand();
                lstBudget.Nodes.Add(nd);
            }

            if (budget != null)
            {
                TreeNode[] liste = lstBudget.Nodes.Find(budget.ID.ToString(), true);
                if (liste.Length > 0) { lstBudget.SelectedNode = liste[0]; }
            }
        }

        private void lstPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPeriode.SelectedIndex < 0) { return; }

            Periode_choix = listeBudgetPeriode[lstPeriode.SelectedIndex].ID;
            Afficher_ListeBudget();
        }

    }
}
