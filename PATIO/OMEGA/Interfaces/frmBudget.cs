using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.Modules;
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
        public Budget budget = new Budget();

        public string Chemin;
        public bool Creation = false;

        string[] listeTypeEnveloppe;
        string[] listeTypeBudget;

        public frmBudget()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblLibelleBudget.Text = budget.Libelle;

            lblCodeBudget.Text = budget.Code;
            if (lblCodeBudget.Text.Length == 0) { lblCodeBudget.Text = "BUG-"; }

            lblCodeBudget.Tag = lblCodeBudget.Text;

            OptActiveBudget.Checked = budget.Actif;

            Afficher_TypeEnveloppe();
            lstTypeEnveloppe.SelectedIndex = lstTypeEnveloppe.Items.IndexOf(budget.TypeEnveloppe.ToString());

            Afficher_TypeBudget();
            lstTypeBudget.SelectedIndex = lstTypeBudget.Items.IndexOf(budget.TypeBudget.ToString());
        }

        void Afficher_TypeEnveloppe()
        {
            lstTypeEnveloppe.Items.Clear();

            listeTypeEnveloppe = Enum.GetNames(typeof(TypeEnveloppe));

            foreach (var t in listeTypeEnveloppe)
            {
                lstTypeEnveloppe.Items.Add(t);
            }
        }

        void Afficher_TypeBudget()
        {
            lstTypeBudget.Items.Clear();

            listeTypeBudget = Enum.GetNames(typeof(TypeBudget));

            foreach (var t in listeTypeBudget)
            {
                lstTypeBudget.Items.Add(t);
            }
        }

        void Valider()
        {
            var Libbudget = lblLibelleBudget.Text.Trim();
            var Codebudget = lblCodeBudget.Text.Trim().ToUpper();
            var Typeenveloppe = (TypeEnveloppe)lstTypeEnveloppe.SelectedIndex;
            var Typebudget = (TypeBudget)lstTypeBudget.SelectedIndex;
            var OptActive = OptActiveBudget.Checked;
            var optVersionTravail = OptVersionTravail.Checked;

            if (Libbudget.Length == 0)
            {
                MessageBox.Show("Libellé du budget obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (Codebudget.Length == 0)
            {
                MessageBox.Show("Code du budget obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            budget.Libelle = Libbudget;
            budget.Code = Codebudget;
            budget.TypeEnveloppe = Typeenveloppe;
            budget.TypeBudget = Typebudget;
            budget.Actif = OptActive;
            budget.VersionTravail = optVersionTravail;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_BUDGET, "CODE", Codebudget)))
                { budget.ID = Acces.Ajouter_Element(Acces.type_BUDGET, budget); }
            }
            else
            {
                Acces.Enregistrer(Acces.type_BUDGET, budget);

                //Test du changement de code --> Impact sur les liens
                if (lblCodeBudget.Text != lblCodeBudget.Tag.ToString())
                {
                    Lien l = new Lien() { Acces = Acces, };
                    l.MettreAJourCode(Acces.type_BUDGET, budget.ID, budget.Code);
                }
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
    }
}
