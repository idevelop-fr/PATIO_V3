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
    public partial class frmVersion : Form
    {
        public AccesNet Acces;

        public bool Creation;
        public int Budget_id;
        public Budget_Version budget_version = new Budget_Version();

        List<Budget> listeBudget;

        Fonctions fct = new Fonctions();
        string[] listeTypeBudget;

        public frmVersion()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblEntete.Text = "BVR";
            lblLibelleVersion.Text = budget_version.Libelle;

            Afficher_ListeType();
            lstTypeBudget.SelectedIndex = lstTypeBudget.Items.IndexOf(budget_version.TypeBudget.ToString());

            lblCodeGenere.Text = budget_version.Code;
            Afficher_Code();

            Afficher_ListeBudget();

            Afficher_ListeType();
            lstTypeBudget.SelectedIndex= budget_version.TypeBudget;

            //Paramétrage des dates
            lblDateDebut.Value = DateTime.Parse(("01/01/" + DateTime.Now.Year));
            if (budget_version.DateDeb != null) { lblDateDebut.Value = fct.ConvertiStringToDate(budget_version.DateDeb); }
            if (budget_version.DateFin != null) { lblDateFin.Value = fct.ConvertiStringToDate(budget_version.DateFin); }

            lblCodeGenere.Tag = lblCodeGenere.Text;

            OptActive.Checked = budget_version.Actif;
            optVersionTravail.Checked = budget_version.VersionTravail;
            optReference.Checked = budget_version.ReferenceBudget;

        }

        void Afficher_ListeType()
        {
            lstTypeBudget.Items.Clear();

            listeTypeBudget = Enum.GetNames(typeof(TypeBudget));

            foreach (var t in listeTypeBudget)
            {
                lstTypeBudget.Items.Add(t);
            }
        }

        void Afficher_ListeBudget()
        {
            lstBudget.Items.Clear();

            listeBudget = (List<Budget>)Acces.Remplir_ListeElement(Acces.type_BUDGET, "");

            foreach (Budget bdg in listeBudget)
            {
                lstBudget.Items.Add(bdg.Libelle);

                if (budget_version.Libelle != null)
                {
                    if (budget_version.Budget_ID == bdg.ID) { lstBudget.SelectedIndex = lstBudget.Items.Count - 1; }
                }
                else
                {
                    if (bdg.ID == Budget_id) { lstBudget.SelectedIndex = lstBudget.Items.Count - 1; }
                }
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void Valider()
        {
            string LibVersion = lblLibelleVersion.Text;//= lblLibelle.Text.Trim();
            string CodeVersion = lblCodeGenere.Text;
            var TypeBudget = (TypeBudget)lstTypeBudget.SelectedIndex;

            if (LibVersion.Length == 0)
            {
                MessageBox.Show("Libellé de la version obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (lstTypeBudget.SelectedIndex<0)
            {
                MessageBox.Show("Type de budget obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (lstBudget.SelectedIndex < 0)
            {
                MessageBox.Show("Budget obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (lblRef2.Text.Length == 0)
            {
                MessageBox.Show("Référence de la version obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            Budget budget = listeBudget[lstBudget.SelectedIndex];

            budget_version.Acces = Acces;
            budget_version.Libelle = LibVersion;
            budget_version.Code = CodeVersion;
            budget_version.TypeBudget = (int)TypeBudget;

            budget_version.Budget_ID = listeBudget[lstBudget.SelectedIndex].ID;
            budget_version.DateDeb = string.Format("{0:yyyyMMdd}", lblDateDebut.Value);
            budget_version.DateFin = string.Format("{0:yyyyMMdd}", lblDateFin.Value);
            budget_version.Enveloppe = budget.Enveloppe;
            budget_version.Periode = budget.Periode;
            budget_version.DateDeb = fct.ConvertiDateToString(lblDateDebut.Value);
            budget_version.DateFin = fct.ConvertiDateToString(lblDateFin.Value);
            budget_version.Actif = OptActive.Checked;
            budget_version.VersionTravail = optVersionTravail.Checked;
            budget_version.ReferenceBudget = optReference.Checked;

            TypeElement typeElement = Acces.type_BUDGET_VERSION;
            if (Creation)
            {
                if (!(Acces.Existe_Element(typeElement, "CODE", CodeVersion)))
                { budget_version.ID = Acces.Ajouter_Element(typeElement, budget_version); }
                else { MessageBox.Show("Code existant"); return; }
            }
            else
            {
                Acces.Enregistrer(typeElement, budget_version);

                //Test du changement de code --> Impact sur les liens
                if (lblCodeGenere.Text != lblCodeGenere.Tag.ToString())
                {
                    Lien l = new Lien() { Acces = Acces, };
                    l.MettreAJourCode(typeElement, budget_version.ID, budget_version.Code);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        void Generer_Code()
        {
            lblCodeGenere.Text = lblEntete.Text + "-" + lblRef1.Text.Replace("-", "_") + "-" + lblRef2.Text.Replace("-", "_");
        }

        void Afficher_Code()
        {
            try
            {
                string txt = lblCodeGenere.Text.Replace(lblEntete.Text + "-", "");
                lblRef1.Text = txt.Split('-')[0];
                lblRef2.Text = txt.Split('-')[1];
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

        private void lstBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Affiche les informations rel  tives au budget sélectionné
            if (lstBudget.SelectedIndex < 0) { return; }

            Budget budget = listeBudget[lstBudget.SelectedIndex];
            //Enveloppe concernée
            if (budget.Enveloppe > 0)
            {
                Budget_Enveloppe Enveloppe = (Budget_Enveloppe)Acces.Trouver_Element(Acces.type_BUDGET_ENVELOPPE, budget.Enveloppe);
                lblEnveloppe.Text = Enveloppe.Libelle;
            }

            //Période et dates concernées
            Budget_Periode bp = (Budget_Periode)Acces.Trouver_Element(Acces.type_BUDGET_PERIODE, budget.Periode);
            lblPeriode.Text = bp.Libelle;
            lblDatePeriodeDebut.Value = fct.ConvertiStringToDate(bp.DateDeb);
            lblDatePeriodeFin.Value = fct.ConvertiStringToDate(bp.DateFin);

            lblRef1.Text = budget.Code.Replace("BUD-", "");
        }

        private void lblRef2_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }
    }
}
