using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.OMEGA.Classes;

namespace PATIO.OMEGA.Interfaces
{
    public partial class frmBudget : Form
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public ctrlConsole Console;

        public Budget budget = new Budget();

        public string Chemin;
        public bool Creation = false;
        public int Period_id;

        public Budget_Periode periode;

        List<Budget_Periode> listeBudgetPeriode;
        List<Budget_Enveloppe> listeTypeEnveloppe;

        Fonctions fct = new Fonctions();

        public frmBudget()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblEntete.Text = "BUD";
            lblLibelleBudget.Text = budget.Libelle;

            lblCodeBudget.Text = budget.Code;
            Afficher_Code();

            //Paramétrage des dates
            if (Creation)
            {
                lblDateDebut.Value = DateTime.Parse("01/01/" + DateTime.Now.Year);
                lblDateFin.Value = DateTime.Parse("31/12/" + DateTime.Now.Year);
            }

            if (budget.DateDeb != null) { lblDateDebut.Value = fct.ConvertiStringToDate(budget.DateDeb); }
            if (budget.DateFin != null) { lblDateFin.Value = fct.ConvertiStringToDate(budget.DateFin); }

            lblCodeBudget.Tag = lblCodeBudget.Text;

            Afficher_ListeBudgetPeriode();

            OptActiveBudget.Checked = budget.Actif;

            Afficher_TypeEnveloppe();
        }

        void Afficher_ListeBudgetPeriode()
        {
            lstPeriode.Items.Clear();

            listeBudgetPeriode = (List<Budget_Periode>)Acces.Remplir_ListeElement(Acces.type_BUDGET_PERIODE, "");

            foreach(Budget_Periode bp in listeBudgetPeriode)
            {
                lstPeriode.Items.Add(bp.Libelle);
                
                if(budget.Libelle != null)
                { if(budget.Periode == bp.ID) { lstPeriode.SelectedIndex = lstPeriode.Items.Count - 1; } }
                else
                { if (bp.ID == Period_id) { lstPeriode.SelectedIndex = lstPeriode.Items.Count - 1; } }
            }
        }

        void Afficher_TypeEnveloppe()
        {
            lstTypeEnveloppe.Items.Clear();
            listeTypeEnveloppe= (List<Budget_Enveloppe>)Acces.Remplir_ListeElement(Acces.type_BUDGET_ENVELOPPE, "");

            foreach (Budget_Enveloppe benv in listeTypeEnveloppe)
            {
                lstTypeEnveloppe.Items.Add(benv.Libelle);
                if (benv.ID == budget.Enveloppe)
                { lstTypeEnveloppe.SelectedIndex = lstTypeEnveloppe.Items.Count - 1; }
            }
        }

        void Valider()
        {
            if (lstTypeEnveloppe.SelectedIndex < 0) { MessageBox.Show("Enveloppe ?"); return; }
            if (lstPeriode.SelectedIndex < 0) { MessageBox.Show("Période ?"); return; }

            string LibBudget = lblLibelleBudget.Text.Trim();
            string Codebudget = lblCodeBudget.Text.Trim().ToUpper();
            int Enveloppe = listeTypeEnveloppe[lstTypeEnveloppe.SelectedIndex].ID;
            int Periode = listeBudgetPeriode[lstPeriode.SelectedIndex].ID;
            bool OptActive = OptActiveBudget.Checked;

            if (LibBudget.Length == 0)
            {
                MessageBox.Show("Libellé du budget obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (Codebudget.Length == 0)
            {
                MessageBox.Show("Code du budget obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            budget.Acces = Acces;
            budget.Libelle = LibBudget;
            budget.Code = Codebudget;
            budget.Enveloppe = Enveloppe;
            budget.Periode = Periode;
            budget.DateDeb = string.Format("{0:yyyyMMdd}", lblDateDebut.Value);
            budget.DateFin = string.Format("{0:yyyyMMdd}", lblDateFin.Value);
            budget.Actif = OptActive;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_BUDGET, "CODE", Codebudget)))
                { budget.ID = Acces.Ajouter_Element(Acces.type_BUDGET, budget); }
                else { MessageBox.Show("Code existant"); return; }
            }
            else
            {
                Acces.Enregistrer(Acces.type_BUDGET, budget);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        private void lblRef1_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }

        void Generer_Code()
        {
            lblCodeBudget.Text=lblEntete.Text + "-" + lblRef1.Text.Replace("-", "_") + ((lblRef2.Text.Length>0)?"-" + lblRef2.Text.Replace("-", "_") : "");
        }

        private void lblRef2_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }

        void Afficher_Code()

        {
            try
            {
                string txt = lblCodeBudget.Text.Replace(lblEntete.Text + "-","");
                string ref1 = txt.Split('-')[0];
                lblRef1.Text = ref1;
                string ref2 = txt.Split('-')[1];
                lblRef2.Text = ref2;
            }
            catch { }
        }

        private void lstPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPeriode.SelectedIndex < 0) { return; }
            if(listeBudgetPeriode[lstPeriode.SelectedIndex].DateDeb == null){ return; }
            lblDateDebut.Value = fct.ConvertiStringToDate(listeBudgetPeriode[lstPeriode.SelectedIndex].DateDeb);
            lblDateFin.Value = fct.ConvertiStringToDate(listeBudgetPeriode[lstPeriode.SelectedIndex].DateFin);
        }
    }
}
