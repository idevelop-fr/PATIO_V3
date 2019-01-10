using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.OMEGA.Classes;

namespace PATIO.OMEGA.Interfaces.Budgets
{
    public partial class frmLigne : Form
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public ctrlConsole Console;

        public Budget_Ligne budget_ligne = new Budget_Ligne();

        public string Chemin;
        public bool Creation = false;
        public int Budget_id;

        List<Budget> listeBudget;
        List<table_valeur> listeORG;
        List<table_valeur> listeGEO;

        string[] listeTypeMontant;
        string[] listeTypeFlux;
        List<Budget_Nomenclature> ListeCompte = new List<Budget_Nomenclature>();

        Fonctions fct = new Fonctions();

        public frmLigne()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblEntete.Text = "BLG";
            lblLibelleBudget.Text = budget_ligne.Libelle;

            lblCodeGenere.Text = budget_ligne.Code;
            Afficher_Code();
            lblCodeGenere.Tag = lblCodeGenere.Text;

            //Budget, ORG, GEO
            Afficher_ListeBudget();
            Afficher_ListeORG();
            Afficher_ListeGEO();
            AfficheTypeMontant();
            lstTypeMontant.SelectedIndex = lstTypeMontant.Items.IndexOf(budget_ligne.TypeMontant.ToString());
            Afficher_TypeFlux();
            lstTypeFlux.SelectedIndex = lstTypeFlux.Items.IndexOf(budget_ligne.TypeFlux.ToString());

            //Paramétrage des dates
            lblDateDebut.Value = DateTime.Parse("01/01/" + DateTime.Now.Year);
            lblDateFin.Value = DateTime.Parse("31/12/" + DateTime.Now.Year);

            if (budget_ligne.DateDeb != null) { lblDateDebut.Value = fct.ConvertiStringToDate(budget_ligne.DateDeb); }
            if (budget_ligne.DateFin != null) { lblDateFin.Value = fct.ConvertiStringToDate(budget_ligne.DateFin); }


            optLimitatif.Checked = budget_ligne.Limitatif;
            OptActiveBudget.Checked = budget_ligne.Actif;

            Afficher_ListeCompte();
        }

        void Afficher_ListeCompte()
        {
            ListeCompte = Acces.clsOMEGA.Remplir_ListeBudgetNomenclature(budget_ligne.Enveloppe, budget_ligne.Periode, budget_ligne.TypeFlux);
            ListeCompte.Sort();

            ChoixCompte.Initialiser();
            foreach (Budget_Nomenclature tv in ListeCompte)
            {
                Boolean ok = false;
                foreach (int k in budget_ligne.ListeCompte)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixCompte.ListeSelection.Add(new Parametre(tv.ID, tv.Code,tv.Code + " : " + tv.Libelle));
                }
                ChoixCompte.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Code + " : " + tv.Libelle));
            }
            ChoixCompte.Afficher_Liste();
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void Valider()
        {
            if (lstBudget.SelectedIndex < 0) { MessageBox.Show("Budget ?"); return; }
            if (lstORG.SelectedIndex < 0) { MessageBox.Show("ORG ?"); return; }
            if (lstGEO.SelectedIndex < 0) { MessageBox.Show("GEO ?"); return; }
            //if (lstPeriode.SelectedIndex < 0) { MessageBox.Show("Période ?"); return; }

            Budget budget = listeBudget[lstBudget.SelectedIndex];

            int budget_id = budget.ID;
            string LibBudget = lblLibelleBudget.Text.Trim();
            string Codebudget = lblCodeGenere.Text.Trim().ToUpper();
            int Enveloppe = budget.Enveloppe;
            int Periode = budget.Periode;
            string DateDeb = budget.DateDeb;
            string DateFin = budget.DateFin;
            bool OptActive = OptActiveBudget.Checked;
            bool OptLimitatif = optLimitatif.Checked;
            var TypeMontant = (TypeMontant)lstTypeMontant.SelectedIndex;
            var TypeFlux = (TypeFlux)lstTypeFlux.SelectedIndex;
            int ORG = listeORG[lstORG.SelectedIndex].ID;
            int GEO = listeGEO[lstGEO.SelectedIndex].ID;

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

            budget_ligne.Console = Console;
            budget_ligne.Acces = Acces;
            budget_ligne.Budget_ID = listeBudget[lstBudget.SelectedIndex].ID;
            budget_ligne.Libelle = LibBudget;
            budget_ligne.Code = Codebudget;
            budget_ligne.Enveloppe = Enveloppe;
            budget_ligne.Periode = Periode;
            budget_ligne.DateDeb = string.Format("{0:yyyyMMdd}", lblDateDebut.Value);
            budget_ligne.DateFin = string.Format("{0:yyyyMMdd}", lblDateFin.Value);
            budget_ligne.Actif = OptActive;
            budget_ligne.Budget_ORG = ORG;
            budget_ligne.Budget_GEO = GEO;
            budget_ligne.TypeMontant = TypeMontant;
            budget_ligne.TypeFlux = TypeFlux;

            List<int> ListeChoix = new List<int>();
            foreach (int i in ChoixCompte.ListeSelectionId) { ListeChoix.Add(i); }
            budget_ligne.ListeCompte = ListeChoix;

            TypeElement typeElement = Acces.type_BUDGET_LIGNE;
            if (Creation)
            {
                if (!(Acces.Existe_Element(typeElement, "CODE", Codebudget)))
                { budget_ligne.ID = Acces.Ajouter_Element(typeElement, budget_ligne); }
                else { MessageBox.Show("Code existant"); return; }
            }
            else
            {
                Acces.Enregistrer(typeElement, budget_ligne);

                //Test du changement de code --> Impact sur les liens
                if (lblCodeGenere.Text != lblCodeGenere.Tag.ToString())
                {
                    Lien l = new Lien() { Acces = Acces, };
                    l.MettreAJourCode(typeElement, budget_ligne.ID, budget_ligne.Code);
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
                lblRef1.Text = txt.Split('-')[1];
                lblRef2.Text = txt.Split('-')[2];
            }
            catch { }
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        void Afficher_ListeBudget()
        {
            lstBudget.Items.Clear();

            listeBudget = (List<Budget>)Acces.Remplir_ListeElement(Acces.type_BUDGET, "");

            foreach (Budget bdg in listeBudget)
            {
                lstBudget.Items.Add(bdg.Libelle);

                if (budget_ligne.Libelle != null)
                {
                    if (budget_ligne.Budget_ID == bdg.ID) { lstBudget.SelectedIndex = lstBudget.Items.Count - 1; }
                }
                else
                {
                    if (bdg.ID == Budget_id) { lstBudget.SelectedIndex = lstBudget.Items.Count - 1; }
                }
            }
        }

        private void lstBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Affiche les informations rel  tives au budget sélectionné
            if (lstBudget.SelectedIndex < 0) { return; }

            Budget budget = listeBudget[lstBudget.SelectedIndex];
            budget_ligne.Budget_ID = budget.ID;
            budget_ligne.Enveloppe  = budget.Enveloppe;
            budget_ligne.Periode = budget.Periode;
            //Enveloppe concernée
            if (budget.Enveloppe > 0)
            {
                Budget_Enveloppe Enveloppe =(Budget_Enveloppe) Acces.Trouver_Element(Acces.type_BUDGET_ENVELOPPE, budget.Enveloppe);
                lblEnveloppe.Text = Enveloppe.Libelle ;
            }

            //Période et dates concernées
            Budget_Periode bp = (Budget_Periode)Acces.Trouver_Element(Acces.type_BUDGET_PERIODE, budget.Periode);
            lblPeriode.Text = bp.Libelle;
            lblDateDebut.Value = fct.ConvertiStringToDate(bp.DateDeb);
            lblDateFin.Value = fct.ConvertiStringToDate(bp.DateFin);

            lblRef1.Text = budget.Code.Replace("BUD-", "").Replace("-","_");

            Afficher_ListeCompte();
        }

        void Afficher_ListeORG()
        {
            string valeur_defaut = "";

            try { valeur_defaut = Acces.Trouver_Parametre("BUDGET_ORG").Valeur; } catch { };

            lstORG.Items.Clear();
            listeORG = Acces.Remplir_ListeTableValeur("BUDGET_ORG");

            foreach (table_valeur tv in listeORG)
            {
                lstORG.Items.Add(tv.Valeur);
                if (tv.Valeur.ToUpper() == valeur_defaut.ToUpper() && budget_ligne.Budget_ORG == 0)
                { budget_ligne.Budget_ORG = tv.ID; }
                if (tv.ID == budget_ligne.Budget_ORG)
                { lstORG.SelectedIndex = lstORG.Items.Count - 1; }
            }
            if (lstORG.Items.Count == 1) { lstORG.SelectedIndex = 0; }

        }

        void Afficher_ListeGEO()
        {
            string valeur_defaut = Acces.Trouver_Parametre("BUDGET_GEO").Valeur;

            lstGEO.Items.Clear();
            listeGEO = Acces.Remplir_ListeTableValeur("BUDGET_GEO");
            foreach (table_valeur tv in listeGEO)
            {
                lstGEO.Items.Add(tv.Valeur);
                if (tv.Valeur.ToUpper() == valeur_defaut.ToUpper() && budget_ligne.Budget_GEO == 0)
                { budget_ligne.Budget_GEO = tv.ID; }
                { lstGEO.SelectedIndex = lstGEO.Items.Count - 1; }
            }
            if (lstGEO.Items.Count == 1) { lstORG.SelectedIndex = 0; }
        }

        void AfficheTypeMontant()
        {
            lstTypeMontant.Items.Clear();

            listeTypeMontant = Enum.GetNames(typeof(TypeMontant));

            foreach (var t in listeTypeMontant)
            {
                lstTypeMontant.Items.Add(t);
            }
        }

        void Afficher_TypeFlux()
        {
            lstTypeFlux.Items.Clear();

            listeTypeFlux = Enum.GetNames(typeof(TypeFlux));

            foreach (var t in listeTypeFlux)
            {
                lstTypeFlux.Items.Add(t);
            }
        }

        private void lblRef_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }

        private void lblRef2_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }

        private void lstTypeFlux_SelectedIndexChanged(object sender, EventArgs e)
        {
            budget_ligne.TypeFlux = (TypeFlux)lstTypeFlux.SelectedIndex;
            Afficher_ListeCompte();
        }
    }
}
