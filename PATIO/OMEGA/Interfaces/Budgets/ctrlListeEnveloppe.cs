using System;
using PATIO.MAIN.Classes;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.OMEGA.Classes;

namespace PATIO.OMEGA.Interfaces.Budgets
{
    public partial class ctrlListeEnveloppe : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public string Chemin;
        public ctrlConsole Console;

        List<Budget_Enveloppe> listeBudgetEnveloppe;

        public ctrlListeEnveloppe()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeEnveloppe();
        }

        void Afficher_ListeEnveloppe()
        {
            lstEnveloppe.Nodes.Clear();

            listeBudgetEnveloppe = (List<Budget_Enveloppe>)Acces.Remplir_ListeElement(Acces.type_BUDGET_ENVELOPPE, "");

            Console.Ajouter("Budget_Enveloppe : " + listeBudgetEnveloppe.Count);

            foreach(Budget_Enveloppe bp in listeBudgetEnveloppe)
            {
                TreeNode nd = new TreeNode();
                nd.Name = bp.ID.ToString();
                nd.Tag = bp;
                nd.Text = bp.Libelle;
                lstEnveloppe.Nodes.Add(nd);
            }
        }

        private void btnCréerPeriode_Click(object sender, EventArgs e)
        {
            AjouterEnveloppe();
        }

        void AjouterEnveloppe()
        {
            frmEnveloppe f = new frmEnveloppe();
            f.Acces = Acces;
            f.Creation = true;
            f.Initialiser();

            if(f.ShowDialog()== DialogResult.OK)
            {
                Afficher_ListeEnveloppe();
            }
        }

        private void btnActualiserEnveloppe_Click(object sender, EventArgs e)
        {
            Afficher_ListeEnveloppe();
        }

        private void btnModifierEnveloppe_Click(object sender, EventArgs e)
        {
            ModifierBudgetEnveloppe();
        }

        void ModifierBudgetEnveloppe()
        {
            if(lstEnveloppe.SelectedNode == null) { return; }

            frmEnveloppe f = new frmEnveloppe();
            f.Acces = Acces;
            f.Creation = false;
            f.budget_enveloppe = (Budget_Enveloppe)lstEnveloppe.SelectedNode.Tag;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeEnveloppe();
            }
        }

        private void btnSupprimerPeriode_Click(object sender, EventArgs e)
        {
            SupprimerPeriode();
        }

        void SupprimerPeriode()
        {
            if (lstEnveloppe.SelectedNode == null) { return; }

            if(MessageBox.Show("Supprimer ?","Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) { return; }

            Budget_Enveloppe bp = (Budget_Enveloppe)lstEnveloppe.SelectedNode.Tag;
            Acces.Supprimer_Element(Acces.type_BUDGET_ENVELOPPE, bp);

            Afficher_ListeEnveloppe();
        }
    }
}
