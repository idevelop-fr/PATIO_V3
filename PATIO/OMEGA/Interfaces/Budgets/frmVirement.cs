using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PATIO.OMEGA.Classes;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.MAIN.Interfaces;

namespace PATIO.OMEGA.Interfaces.Budgets
{
    public partial class frmVirement : Form
    {
        public AccesNet Acces;

        public Budget_Virement budget_virement = new Budget_Virement();
        public bool Creation = false;
        public int Periode;
        public int Enveloppe;
        public TypeFlux TypeFlux;
        public TypeMontant TypeMontant;
        public int budget_org;
        public int budget_geo;

        List<Budget_Enveloppe> listeTypeEnveloppe;
        List<Budget_Periode> listePeriode;
        string[] listeTypeMontant;
        string[] listeTypeVirement;
        List<table_valeur> listeORG;
        List<table_valeur> listeGEO;

        Fonctions fct = new Fonctions();

        public frmVirement()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            string valeur_defaut_ORG = Acces.Trouver_Parametre("BUDGET_ORG").Valeur;
            string valeur_defaut_GEO = Acces.Trouver_Parametre("BUDGET_GEO").Valeur;

            listeGEO = Acces.Remplir_ListeTableValeur("BUDGET_GEO");
            listeORG = Acces.Remplir_ListeTableValeur("BUDGET_ORG");

            Afficher_ListePeriode();
            Afficher_TypeMontant();

            lblDateDemande.Value = fct.ConvertiStringToDate(budget_virement.DateDemande);
            lblDateEffet.Value = fct.ConvertiStringToDate(budget_virement.DateEffet);

            Afficher_TypeVirement();
            lblMontant.Text = string.Format("{0:#,###,##0.00}", budget_virement.Montant);

            Afficher_TypeEnveloppe(lstEnveloppe_Src, budget_virement.Enveloppe_Src);
            Afficher_ListeNomenclature(choixListe_Src, lstEnveloppe_Src, budget_virement.Compte_ID_Src);
            Afficher_ListeORG(lstORG_Src, budget_virement.Budget_ORG_Src, valeur_defaut_ORG);
            Afficher_ListeGEO(lstGEO_Src, budget_virement.Budget_GEO_Src, valeur_defaut_GEO);

            Afficher_TypeEnveloppe(lstEnveloppe_Dest, budget_virement.Enveloppe_Dest);
            Afficher_ListeNomenclature(choixListe_Dest, lstEnveloppe_Dest, budget_virement.Compte_ID_Dest);
            Afficher_ListeORG(lstORG_Dest, budget_virement.Budget_ORG_Dest, valeur_defaut_ORG);
            Afficher_ListeGEO(lstGEO_Dest, budget_virement.Budget_GEO_Dest, valeur_defaut_GEO);

            lblCommentaire.Text = budget_virement.Commentaire;
        }

        void Afficher_TypeMontant()
        {
            lstTypeMontant.Items.Clear();
            listeTypeMontant = Enum.GetNames(typeof(TypeMontant));

            foreach (var t in listeTypeMontant)
            {
                lstTypeMontant.Items.Add(t);
                if (t == budget_virement.Type_Montant.ToString()) { lstTypeMontant.SelectedIndex = lstTypeMontant.Items.Count - 1; }
            }
        }

        void Afficher_TypeVirement()
        {
            lstTypeVirement.Items.Clear();
            listeTypeVirement = Enum.GetNames(typeof(TypeVirement));

            foreach (var t in listeTypeVirement)
            {
                lstTypeVirement.Items.Add(t);
                if (t == budget_virement.Type_Montant.ToString()) { lstTypeVirement.SelectedIndex = lstTypeVirement.Items.Count - 1; }
            }
            if (lstTypeVirement.Items.Count > 0 && lstTypeVirement.SelectedIndex < 0) { lstTypeVirement.SelectedIndex = 0; }
        }

        void Afficher_ListePeriode()
        {
            lstPeriode.Items.Clear();
            listePeriode = (List<Budget_Periode>)Acces.Remplir_ListeElement(Acces.type_BUDGET_PERIODE, "");

            foreach (Budget_Periode bp in listePeriode)
            {
                lstPeriode.Items.Add(bp.Libelle);
                if (bp.ID == Periode) { lstPeriode.SelectedIndex = lstPeriode.Items.Count - 1; }
            }
        }

        void Afficher_TypeEnveloppe(ComboBox lst, int Enveloppe)
        {
            lst.Items.Clear();
            listeTypeEnveloppe = (List<Budget_Enveloppe>)Acces.Remplir_ListeElement(Acces.type_BUDGET_ENVELOPPE, "");

            foreach (Budget_Enveloppe benv in listeTypeEnveloppe)
            {
                lst.Items.Add(benv.Libelle);
                if (benv.ID == Enveloppe) { lst.SelectedIndex = lst.Items.Count - 1; }
            }
            if (lst.Items.Count > 0 && lst.SelectedIndex < 0) { lst.SelectedIndex = 0; }
        }

        void Afficher_ListeNomenclature(ctrlChoixListe ctrl, ComboBox lstTypeEnveloppe, int Compte_ID )
        {
            ctrl.Initialiser(); ;

            if (lstTypeEnveloppe.SelectedIndex < 0) { return; }
            if (lstPeriode.SelectedIndex < 0) { return; }

            int periode = listePeriode[lstPeriode.SelectedIndex].ID;
            int enveloppe = listeTypeEnveloppe[lstTypeEnveloppe.SelectedIndex].ID;
            TypeFlux typeflux = TypeFlux.Dépenses;

            List<Budget_Nomenclature> ListeCompte = Acces.clsOMEGA.Remplir_ListeBudgetNomenclature(enveloppe, periode, typeflux);

            foreach (Budget_Nomenclature tv in ListeCompte)
            {
                if (tv.ID == Compte_ID)
                {
                    ctrl.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Code + " : " + tv.Libelle));
                }
                else
                {
                    ctrl.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Code + " : " + tv.Libelle));
                }
            }
            ctrl.Afficher_Liste();
        }

        void Afficher_ListeORG(ComboBox lst, int CodeCherché, string valeur_defaut)
        {
            lst.Items.Clear();
            foreach (table_valeur tv in listeORG)
            {
                lst.Items.Add(tv.Valeur);

                if (tv.Valeur.ToUpper() == valeur_defaut.ToUpper() && CodeCherché == 0)
                { CodeCherché = tv.ID; }
                if (tv.ID == CodeCherché)
                { lst.SelectedIndex = lst.Items.Count - 1; }
            }

            if (lst.Items.Count == 1) { lst.SelectedIndex = 0; }
        }

        void Afficher_ListeGEO(ComboBox lst, int CodeCherché, string valeur_defaut)
        {
            lst.Items.Clear();
            foreach (table_valeur tv in listeGEO)
            {
                lst.Items.Add(tv.Valeur);

                if (tv.Valeur.ToUpper() == valeur_defaut.ToUpper() && CodeCherché == 0)
                { CodeCherché = tv.ID; }
                if (tv.ID == CodeCherché)
                { lst.SelectedIndex = lst.Items.Count - 1; }
            }

            if (lst.Items.Count == 1) { lst.SelectedIndex = 0; }
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        void Valider()
        {
            if (lstPeriode.SelectedIndex < 0) { MessageBox.Show("Période ?"); return; }
            if (lstTypeVirement.SelectedIndex < 0) { MessageBox.Show("Type de virement ?"); return; }

            if (choixListe_Src.ListeSelection.Count == 0) { MessageBox.Show("Un compte source doit être sélectionné ?"); return; }
            if (lstEnveloppe_Src.SelectedIndex < 0) { MessageBox.Show("Enveloppe de la source ?"); return; }
            if (lstORG_Src.SelectedIndex < 0) { MessageBox.Show("ORG de la source ?"); return; }
            if (lstGEO_Src.SelectedIndex < 0) { MessageBox.Show("GEO de la source ?"); return; }

            if (choixListe_Dest.ListeSelection.Count == 0) { MessageBox.Show("Un compte destination doit être sélectionné ?"); return; }
            if (lstEnveloppe_Dest.SelectedIndex < 0) { MessageBox.Show("Enveloppe de la destination ?"); return; }
            if (lstORG_Dest.SelectedIndex < 0) { MessageBox.Show("ORG de la destination ?"); return; }
            if (lstGEO_Dest.SelectedIndex < 0) { MessageBox.Show("GEO de la destination ?"); return; }

            if (lstTypeMontant.SelectedIndex < 0) { MessageBox.Show("Type de montant ?"); return; }

            string LibelleVirement = "VIREMENT";
            string CodeVirement = "VIR-" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
            int Periode = listePeriode[lstPeriode.SelectedIndex].ID;

            TypeMontant TypeMontant = (TypeMontant)lstTypeMontant.SelectedIndex;


            double Montant = double.Parse(lblMontant.Text);

            budget_virement.Acces = Acces;

            budget_virement.Periode = Periode;
            budget_virement.Type_Flux = TypeFlux;
            budget_virement.Libelle = LibelleVirement;
            budget_virement.Code = CodeVirement;

            int Enveloppe_Src = listeTypeEnveloppe[lstEnveloppe_Src.SelectedIndex].ID;
            int ORG_Src = listeORG[lstORG_Src.SelectedIndex].ID;
            int GEO_Src = listeGEO[lstGEO_Src.SelectedIndex].ID;
            int Compte_ID_Src = choixListe_Src.ListeSelection[0].ID;

            budget_virement.Enveloppe_Src = Enveloppe_Src;
            budget_virement.Compte_ID_Src = Compte_ID_Src;
            budget_virement.Budget_ORG_Src = ORG_Src;
            budget_virement.Budget_GEO_Src = GEO_Src;

            int Enveloppe_Dest = listeTypeEnveloppe[lstEnveloppe_Dest.SelectedIndex].ID;
            int ORG_Dest = listeORG[lstORG_Dest.SelectedIndex].ID;
            int GEO_Dest = listeGEO[lstGEO_Dest.SelectedIndex].ID;
            int Compte_ID_Dest = choixListe_Dest.ListeSelection[0].ID;

            budget_virement.Enveloppe_Dest = Enveloppe_Dest;
            budget_virement.Compte_ID_Dest = Compte_ID_Dest;
            budget_virement.Budget_ORG_Dest = ORG_Dest;
            budget_virement.Budget_GEO_Dest = GEO_Dest;

            budget_virement.DateDemande = string.Format("{0:yyyyMMdd}", lblDateDemande.Value);
            budget_virement.DateEffet = string.Format("{0:yyyyMMdd}", lblDateEffet.Value);
            budget_virement.Type_Montant = TypeMontant;
            budget_virement.Montant = Montant;
            budget_virement.Commentaire = lblCommentaire.Text.Trim();

            TypeElement typeElement = Acces.type_BUDGET_VIREMENT;
            if (Creation)
            {
                if (!(Acces.Existe_Element(typeElement, "CODE", CodeVirement)))
                {
                    budget_virement.ID = Acces.Ajouter_Element(typeElement, budget_virement);
                }
                else { MessageBox.Show("Code existant"); return; }
            }
            else
            {
                Acces.Enregistrer(typeElement, budget_virement);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
