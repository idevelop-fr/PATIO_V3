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
    public partial class frmEnveloppe : Form
    {
        public AccesNet Acces;

        public bool Creation;
        public Budget_Enveloppe budget_enveloppe = new Budget_Enveloppe();

        Fonctions fct = new Fonctions();
        string[] listeTypeEnveloppe;

        public frmEnveloppe()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblEntete.Text = "ENV";
            lblLibelle.Text = budget_enveloppe.Libelle;

            lblCodeGenere.Text = budget_enveloppe.Code;
            Afficher_Code();

            Afficher_ListeTypeEnveloppe();
            lstTypeEnveloppe.SelectedIndex = lstTypeEnveloppe.Items.IndexOf(budget_enveloppe.TypeEnveloppe.ToString());

            lblCodeGenere.Tag = lblCodeGenere.Text;

            OptActive.Checked = budget_enveloppe.Actif;
        }

        void Afficher_ListeTypeEnveloppe()
        {
            lstTypeEnveloppe.Items.Clear();

            listeTypeEnveloppe = Enum.GetNames(typeof(TypeEnveloppe));

            foreach (var t in listeTypeEnveloppe)
            {
                lstTypeEnveloppe.Items.Add(t);
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void Valider()
        {
            string LibEnveloppe = lblLibelle.Text.Trim();
            string CodeEnveloppe = lblCodeGenere.Text;
            bool OptActive = this.OptActive.Checked;
            var TypeEnveloppe = (TypeEnveloppe)lstTypeEnveloppe.SelectedIndex;

            if (LibEnveloppe.Length == 0)
            {
                MessageBox.Show("Libellé de l'enveloppe obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (CodeEnveloppe.Length == 0)
            {
                MessageBox.Show("Code de l'enveloppe obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            budget_enveloppe.Acces = Acces;
            budget_enveloppe.Libelle = LibEnveloppe;
            budget_enveloppe.Code = CodeEnveloppe;
            budget_enveloppe.TypeEnveloppe = TypeEnveloppe;
            budget_enveloppe.Actif = OptActive;

            TypeElement Type_Element = Acces.type_BUDGET_ENVELOPPE;
            if (Creation)
            {
                if (!(Acces.Existe_Element(Type_Element, "CODE", CodeEnveloppe)))
                { budget_enveloppe.ID = Acces.Ajouter_Element(Type_Element, budget_enveloppe); }
                else { MessageBox.Show("Code existant"); return; }
            }
            else
            {
                Acces.Enregistrer(Type_Element, budget_enveloppe);

                //Test du changement de code --> Impact sur les liens
                if (lblCodeGenere.Text != lblCodeGenere.Tag.ToString())
                {
                    Lien l = new Lien() { Acces = Acces, };
                    l.MettreAJourCode(Type_Element, budget_enveloppe.ID, budget_enveloppe.Code);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        void Generer_Code()
        {
            lblCodeGenere.Text = lblEntete.Text + "-" + lblRef.Text.Replace("-", "_");
        }

        void Afficher_Code()
        {
            try
            {
                string txt = lblCodeGenere.Text.Replace(lblEntete.Text + "-", "");
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
