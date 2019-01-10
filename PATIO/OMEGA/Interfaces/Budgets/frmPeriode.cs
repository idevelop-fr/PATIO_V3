using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.OMEGA.Classes;

namespace PATIO.OMEGA.Interfaces.Budgets
{
    public partial class frmPeriode : Form
    {
        public AccesNet Acces;

        public bool Creation;
        public Budget_Periode budget_periode = new Budget_Periode();

        Fonctions fct = new Fonctions();
        string[] listeTypePeriode;

        public frmPeriode()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblEntete.Text = "BPE";
            lblLibelle.Text = budget_periode.Libelle;

            lblCodePeriode.Text = budget_periode.Code;
            Afficher_Code();

            Afficher_ListeType();
            lstTypePeriode.SelectedIndex = lstTypePeriode.Items.IndexOf(budget_periode.TypePeriode.ToString());

            //Paramétrage des dates
            lblDateDebut.Value = DateTime.Parse("01/01/" + DateTime.Now.Year);
            lblDateFin.Value = DateTime.Parse("31/12/" + DateTime.Now.Year);

            if (budget_periode.DateDeb != null) { lblDateDebut.Value = fct.ConvertiStringToDate(budget_periode.DateDeb); }
            if (budget_periode.DateFin != null) { lblDateFin.Value = fct.ConvertiStringToDate(budget_periode.DateFin); }

            lblCodePeriode.Tag = lblCodePeriode.Text;

            OptActive.Checked = budget_periode.Actif;
        }

        void Afficher_ListeType()
        {
            lstTypePeriode.Items.Clear();

            listeTypePeriode = Enum.GetNames(typeof(TypePeriode));

            foreach (var t in listeTypePeriode)
            {
                lstTypePeriode.Items.Add(t);
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void Valider()
        {
            string LibBudget = lblLibelle.Text.Trim();
            string CodeBudget = lblCodePeriode.Text;
            bool OptActive = this.OptActive.Checked;
            var TypePeriode = (TypePeriode)lstTypePeriode.SelectedIndex;

            if (LibBudget.Length == 0)
            {
                MessageBox.Show("Libellé de la période obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (CodeBudget.Length == 0)
            {
                MessageBox.Show("Code de la période obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            budget_periode.Acces = Acces;
            budget_periode.Libelle = LibBudget;
            budget_periode.Code = CodeBudget;
            budget_periode.TypePeriode = TypePeriode;
            budget_periode.DateDeb = string.Format("{0:yyyyMMdd}", lblDateDebut.Value);
            budget_periode.DateFin = string.Format("{0:yyyyMMdd}", lblDateFin.Value);
            budget_periode.Actif = OptActive;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_BUDGET_PERIODE, "CODE", CodeBudget)))
                { budget_periode.ID = Acces.Ajouter_Element(Acces.type_BUDGET_PERIODE, budget_periode); }
                else { MessageBox.Show("Code existant"); return; }
            }
            else
            {
                Acces.Enregistrer(Acces.type_BUDGET_PERIODE, budget_periode);

                //Test du changement de code --> Impact sur les liens
                if (lblCodePeriode.Text != lblCodePeriode.Tag.ToString())
                {
                    Lien l = new Lien() { Acces = Acces, };
                    l.MettreAJourCode(Acces.type_BUDGET_PERIODE, budget_periode.ID, budget_periode.Code);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        void Generer_Code()
        {
            lblCodePeriode.Text = lblEntete.Text + "-" + lblRef.Text.Replace("-", "_");
        }

        void Afficher_Code()
        {
            try
            {
                string txt = lblCodePeriode.Text.Replace(lblEntete.Text + "-", "");
                lblRef.Text = txt;
            }
            catch { }
        }

        private void lblRef_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

    }
}
