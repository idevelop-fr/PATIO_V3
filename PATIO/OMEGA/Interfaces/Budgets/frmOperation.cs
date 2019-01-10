using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.OMEGA.Classes;
using PATIO.MAIN.Classes;
using PATIO.MAIN.Interfaces;

namespace PATIO.OMEGA.Interfaces
{
    public partial class frmOperation : Form
    {
        public AccesNet Acces;

        public Budget_Operation budget_operation = new Budget_Operation();
        public bool Creation = false;
        public int Periode;
        public int Enveloppe;
        public TypeFlux TypeFlux;
        public TypeMontant TypeMontant;
        public int budget_org;
        public int budget_geo;
        public int type_operation;

        List<Budget_Enveloppe> listeTypeEnveloppe;
        List<Budget_Periode> listePeriode;
        string[] listeTypeFlux;
        string[] listeTypeMontant;
        List<table_valeur> listeORG;
        List<table_valeur> listeGEO;
        List<table_valeur> listeTypeOperation;

        Fonctions fct = new Fonctions();

        public frmOperation()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            BtnValider.Text=(Creation)?"Ajouter":"Modifier";

            Afficher_ListePeriode();
            Afficher_TypeEnveloppe();
            Afficher_TypeFlux();
            Afficher_TypeMontant();
            Afficher_ListeORG();
            Afficher_ListeGEO();
            Afficher_ListeTypeOperation();

            lblMontant.Text =string.Format("{0:# ### ##0.00}", budget_operation.Montant);
            lblCommentaire.Text = budget_operation.Commentaire;
        }

        void Afficher_TypeFlux()
        {
            lstTypeFlux.Items.Clear();

            listeTypeFlux = Enum.GetNames(typeof(TypeFlux));

            foreach (var t in listeTypeFlux)
            {
                lstTypeFlux.Items.Add(t);
                if (t == TypeFlux.ToString()) { lstTypeFlux.SelectedIndex = lstTypeFlux.Items.Count - 1; }
            }
        }

        void Afficher_TypeMontant()
        {
            lstTypeMontant.Items.Clear();
            listeTypeMontant = Enum.GetNames(typeof(TypeMontant));

            foreach (var t in listeTypeMontant)
            {
                lstTypeMontant.Items.Add(t);
                if (t == budget_operation.Type_Montant.ToString()) { lstTypeMontant.SelectedIndex = lstTypeMontant.Items.Count - 1; }
            }
        }

        void Afficher_TypeEnveloppe()
        {
            lstTypeEnveloppe.Items.Clear();
            listeTypeEnveloppe = (List<Budget_Enveloppe>)Acces.Remplir_ListeElement(Acces.type_BUDGET_ENVELOPPE, "");

            foreach (Budget_Enveloppe benv in listeTypeEnveloppe)
            {
                lstTypeEnveloppe.Items.Add(benv.Libelle);
                if (benv.ID == Enveloppe) { lstTypeEnveloppe.SelectedIndex = lstTypeEnveloppe.Items.Count - 1; }
            }
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

        void Afficher_ListeNomenclature()
        {
            ChoixCompte.Initialiser(); ;

            if (lstTypeEnveloppe.SelectedIndex < 0) { return; }
            if (lstPeriode.SelectedIndex < 0) { return; }
            if (lstTypeFlux.SelectedIndex < 0) { return; }

            int periode = listePeriode[lstPeriode.SelectedIndex].ID;
            int enveloppe = listeTypeEnveloppe[lstTypeEnveloppe.SelectedIndex].ID;
            TypeFlux typeflux = (TypeFlux)lstTypeFlux.SelectedIndex;

            List<Budget_Nomenclature> ListeCompte = Acces.clsOMEGA.Remplir_ListeBudgetNomenclature(enveloppe, periode, typeflux);

            foreach (Budget_Nomenclature tv in ListeCompte)
            {
                if (tv.ID == budget_operation.Compte_ID)
                {
                    ChoixCompte.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Code + " : " + tv.Libelle));
                }
                else
                {
                    ChoixCompte.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Code + " : " + tv.Libelle));
                }
            }
            ChoixCompte.Afficher_Liste();
        }

        void Afficher_ListeTypeOperation()
        {

            //Recherche des valeurs par défaut
            string valeur_defaut = Acces.Trouver_Parametre("BUDGET_OPERATION").Valeur;

            lstTypeOperation.Items.Clear();
            listeTypeOperation = Acces.Remplir_ListeTableValeur("TYPE_OPERATION");

            foreach (table_valeur tv in listeTypeOperation)
            {
                lstTypeOperation.Items.Add(tv.Valeur);
                if (tv.Valeur.ToUpper() == valeur_defaut.ToUpper() && budget_operation.Type_Operation == 0) { budget_operation.Type_Operation = tv.ID; }
                if (tv.ID == budget_operation.Type_Operation) { lstTypeOperation.SelectedIndex = lstTypeOperation.Items.Count - 1; }
            }
        }

        private void lstTypeEnveloppe_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeNomenclature();
            Afficher_InfoCpl();
        }

        private void lstPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeNomenclature();
            Afficher_InfoCpl();
        }

        private void lstTypeFlux_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeNomenclature();
        }

        void Afficher_InfoCpl()
        {
            treeInfo.Nodes.Clear();
            if (lstPeriode.SelectedIndex < 0) { return; }
            if (lstTypeEnveloppe.SelectedIndex < 0) { return; }

            int Periode = listePeriode[lstPeriode.SelectedIndex].ID;
            int Enveloppe = listeTypeEnveloppe[lstTypeEnveloppe.SelectedIndex].ID;

            List<Budget> ListeBudget = Acces.clsOMEGA.Remplir_ListeBudget(Periode, Enveloppe);

            foreach (Budget bg in ListeBudget)
            {
                TreeNode NodB = new TreeNode(bg.Libelle);
                NodB.Nodes.Add(new TreeNode("Début: " + string.Format("{0:dd/MM/yyyy}", fct.ConvertiStringToDate(bg.DateDeb))));
                NodB.Nodes.Add(new TreeNode("Fin: " + string.Format("{0:dd/MM/yyyy}", fct.ConvertiStringToDate(bg.DateFin))));
                //lblDateOpe.MinDate = fct.ConvertiStringToDate(bg.DateDeb);
                //lblDateOpe.MaxDate = fct.ConvertiStringToDate(bg.DateFin);

                //Lignes budgétaires
                TreeNode nd_Ligne = new TreeNode("Lignes");
                List<Budget_Ligne> ListeBudgetLigne = Acces.clsOMEGA.Remplir_ListeBudgetLigne_ID(bg.ID);
                foreach(Budget_Ligne lg in ListeBudgetLigne)
                {
                    bool ok = (ChoixCompte.ListeSelection.Count ==0);
                    if (ChoixCompte.ListeSelection.Count == 1)
                    {
                        foreach(int cpt in lg.ListeCompte)
                        {
                            if(cpt == ChoixCompte.ListeSelection[0].ID) { ok = true; }
                        }
                    }
                    if (ok) { nd_Ligne.Nodes.Add(new TreeNode(lg.Libelle)); }
                }
                NodB.Nodes.Add(nd_Ligne);

                //Versions
                TreeNode nd_Version = new TreeNode("Versions");
                List<Budget_Version> ListeBudgetVersion = Acces.clsOMEGA.Remplir_ListeBudgetVersion_ID(bg.ID);

                int date = int.Parse(string.Format("{0:yyyyMMdd}", lblDateOpe.Value));
                foreach (Budget_Version lv in ListeBudgetVersion)
                {
                    if (date >= int.Parse(lv.DateDeb) && date <= int.Parse(lv.DateFin))
                    { nd_Version.Nodes.Add(new TreeNode(lv.Libelle)); }
                }
                NodB.Nodes.Add(nd_Version);

                treeInfo.Nodes.Add(NodB);
            }

            treeInfo.ExpandAll();

        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void Valider()
        {
            if (lstTypeEnveloppe.SelectedIndex < 0) { MessageBox.Show("Enveloppe ?"); return; }
            if (lstPeriode.SelectedIndex < 0) { MessageBox.Show("Période ?"); return; }
            if (lstTypeFlux.SelectedIndex < 0) { MessageBox.Show("Flux ?"); return; }
            if (ChoixCompte.ListeSelection.Count == 0) { MessageBox.Show("Un compte doit être sélectionné  ?"); return; }
            if (ChoixCompte.ListeSelection.Count > 1) { MessageBox.Show("Un seul compte doit être sélectionné  ?"); return; }
            if (lstORG.SelectedIndex < 0) { MessageBox.Show("ORG ?"); return; }
            if (lstGEO.SelectedIndex < 0) { MessageBox.Show("GEO ?"); return; }
            if (lstTypeMontant.SelectedIndex < 0) { MessageBox.Show("Type de montant ?"); return; }
            if (lstTypeOperation.SelectedIndex < 0) { MessageBox.Show("Type d'opération ?"); return; }

            string LibelleOpe = "OPERATION";
            string CodeOpe = "OPE-" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
            int Enveloppe = listeTypeEnveloppe[lstTypeEnveloppe.SelectedIndex].ID;
            int Periode = listePeriode[lstPeriode.SelectedIndex].ID;
            var TypeFlux = (TypeFlux)lstTypeFlux.SelectedIndex;

            int Compte_ID = ChoixCompte.ListeSelection[0].ID;

            TypeMontant TypeMontant = (TypeMontant)lstTypeMontant.SelectedIndex;
            int ORG = listeORG[lstORG.SelectedIndex].ID;
            int GEO = listeGEO[lstGEO.SelectedIndex].ID;

            double Montant = double.Parse(lblMontant.Text);

            budget_operation.Acces = Acces;

            budget_operation.Libelle = LibelleOpe;
            budget_operation.Code = CodeOpe;

            budget_operation.Enveloppe = Enveloppe;
            budget_operation.Periode = Periode;
            budget_operation.Type_Flux = TypeFlux;

            budget_operation.Compte_ID = Compte_ID;
            budget_operation.Budget_ORG = ORG;
            budget_operation.Budget_GEO = GEO;

            budget_operation.DateOperation = string.Format("{0:yyyyMMdd}", lblDateOpe.Value);
            budget_operation.Type_Operation = listeTypeOperation[lstTypeOperation.SelectedIndex].ID;
            budget_operation.Type_Montant = TypeMontant;
            budget_operation.Montant = Montant;
            budget_operation.Commentaire = lblCommentaire.Text.Trim();

            TypeElement typeElement = Acces.type_BUDGET_OPERATION;
            if (Creation)
            {
                if (!(Acces.Existe_Element(typeElement, "CODE", CodeOpe)))
                {
                    budget_operation.ID = Acces.Ajouter_Element(typeElement, budget_operation);

                    if(TypeMontant == TypeMontant.AE)
                    {
                        if(MessageBox.Show("Créer une opération en CP correspondante ?","Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string mt = Microsoft.VisualBasic.Interaction.InputBox("Saisir le montant des CP", "Montant des CP", string.Format("{0:# ### ###.00}", budget_operation.Montant));
                            if (mt.Length > 0)
                            {
                                budget_operation.ID = 0;
                                budget_operation.Type_Montant = TypeMontant.CP;
                                budget_operation.Montant = double.Parse(mt);
                                budget_operation.ID = Acces.Ajouter_Element(typeElement, budget_operation);
                            }
                        }
                    }
                }
                else { MessageBox.Show("Code existant"); return; }
            }
            else
            {
                Acces.Enregistrer(typeElement, budget_operation);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        void Afficher_ListeORG()
        {
            string valeur_defaut = Acces.Trouver_Parametre("BUDGET_ORG").Valeur;

            lstORG.Items.Clear();
            listeORG = Acces.Remplir_ListeTableValeur("BUDGET_ORG");

            foreach (table_valeur tv in listeORG)
            {
                lstORG.Items.Add(tv.Valeur);
                if (tv.Valeur.ToUpper() == valeur_defaut.ToUpper() && budget_operation.Budget_ORG == 0)
                { budget_operation.Budget_ORG= tv.ID; }

                if (tv.ID == budget_operation.Budget_ORG)
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

                if (tv.Valeur.ToUpper() == valeur_defaut.ToUpper() && budget_operation.Budget_GEO == 0)
                { budget_operation.Budget_GEO = tv.ID; }
                if (tv.ID == budget_operation.Budget_GEO)
                { lstGEO.SelectedIndex = lstGEO.Items.Count - 1; }
            }

            if (lstGEO.Items.Count == 1) { lstGEO.SelectedIndex = 0; }
        }

        private void ChoixCompte_EVT_Echanger(object sender, ctrlChoixListe.evt_Echanger e)
        {
            Afficher_InfoCpl();
        }

        private void lblDateOpe_ValueChanged(object sender, EventArgs e)
        {
            Afficher_InfoCpl();
        }

        private void lblMontant_Leave(object sender, EventArgs e)
        {
            double mnt = double.Parse(lblMontant.Text.Trim());
            lblMontant.Text = string.Format("{0:# ### ##0.00}", mnt);
        }
    }
}
