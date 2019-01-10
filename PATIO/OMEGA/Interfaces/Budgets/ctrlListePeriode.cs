using System;
using PATIO.MAIN.Classes;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.OMEGA.Classes;

namespace PATIO.OMEGA.Interfaces.Budgets
{
    public partial class ctrlListePeriode : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public string Chemin;
        public ctrlConsole Console;

        List<Budget_Periode> listeBudgetPeriode;

        public ctrlListePeriode()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListePeriode();
        }

        void Afficher_ListePeriode()
        {
            lstPeriode.Nodes.Clear();

            listeBudgetPeriode = (List<Budget_Periode>)Acces.Remplir_ListeElement(Acces.type_BUDGET_PERIODE, "");

            Console.Ajouter("BUDGET_PERIODE : " + listeBudgetPeriode.Count);

            foreach(Budget_Periode bp in listeBudgetPeriode)
            {
                TreeNode nd = new TreeNode();
                nd.Name = bp.ID.ToString();
                nd.Tag = bp;
                nd.Text = bp.Libelle;
                lstPeriode.Nodes.Add(nd);
            }
        }

        private void btnCréerPeriode_Click(object sender, EventArgs e)
        {
            AjouterPeriodeBudget();
        }

        void AjouterPeriodeBudget()
        {
            frmPeriode f = new frmPeriode();
            f.Acces = Acces;
            f.Creation = true;
            f.Initialiser();

            if(f.ShowDialog()== DialogResult.OK)
            {
                Afficher_ListePeriode();
            }
        }

        private void btnActualiserPeriode_Click(object sender, EventArgs e)
        {
            Afficher_ListePeriode();
        }

        private void btnModifierPeriode_Click(object sender, EventArgs e)
        {
            ModifierBudgetPeriode();
        }

        void ModifierBudgetPeriode()
        {
            if(lstPeriode.SelectedNode == null) { return; }

            frmPeriode f = new frmPeriode();
            f.Acces = Acces;
            f.Creation = false;
            f.budget_periode = (Budget_Periode)lstPeriode.SelectedNode.Tag;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListePeriode();
            }
        }

        private void btnSupprimerPeriode_Click(object sender, EventArgs e)
        {
            SupprimerPeriode();
        }

        void SupprimerPeriode()
        {
            if (lstPeriode.SelectedNode == null) { return; }

            if(MessageBox.Show("Supprimer ?","Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) { return; }

            Budget_Periode bp = (Budget_Periode)lstPeriode.SelectedNode.Tag;
            Acces.Supprimer_Element(Acces.type_BUDGET_PERIODE, bp);

            Afficher_ListePeriode();
        }
    }
}
