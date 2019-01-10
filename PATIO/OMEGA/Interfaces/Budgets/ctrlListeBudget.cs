using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.OMEGA.Classes;
using PATIO.MAIN.Classes;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Reporting.WinForms;

namespace PATIO.OMEGA.Interfaces.Budgets
{
    public partial class ctrlListeBudget : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;

        public int Periode_choix = 0;

        public Budget budget;
        public Budget_Ligne budget_ligne;
        public Budget_Version budget_version;
        public Budget_Operation budget_operation;
        public Budget_Virement budget_virement;

        List<Budget> listeBudget;
        List<Budget_Periode> listeBudgetPeriode;
        List<Budget_Enveloppe> listeTypeEnveloppe;
        List<Budget_Ligne> listeBudgetLigne;
        List<Budget_Version> listeBudgetVersion;
        List<Budget_Operation> listeBudgetOperation;
        List<Budget_Virement> listeBudgetVirement;

        string[] listeTypeFlux;
        string[] listeTypeMontant;
        List<table_valeur> listeORG;
        List<table_valeur> listeGEO;

        int Enveloppe_Select =-1;
        TypeFlux Flux_Select = TypeFlux.Dépenses;
        TypeMontant Montant_Select = TypeMontant.CP;
        int budget_org_Select = -1;
        int budget_geo_Select = -1;

        string DateMin_Select = "";
        string DateMax_Select = "";
        List<int> listeCompte_Select = new List<int>();

        public ctrlListeBudget()
        {
            InitializeComponent();
            tabControl.SendToBack(); //Force la Barre d'onglets à passer sous la barre de boutons (présentation)
        }

        public void Initialiser()
        {
            Afficher_ListePeriode();
            Afficher_ListeBudget();
            Afficher_LigneVersion();

            Afficher_ListeSelectionEnvFlux();

            Afficher_SelectionBudget();
            Redimensionner();

            Afficher_ListeOperation();
            Afficher_ListeVirement();
            Afficher_SelectionBouton();

        }

        void Afficher_ListePeriode()
        {
            lstPeriode.Items.Clear();

            listeBudgetPeriode = (List<Budget_Periode>)Acces.Remplir_ListeElement(Acces.type_BUDGET_PERIODE, "", true);

            foreach (Budget_Periode bp in listeBudgetPeriode)
            {
                lstPeriode.Items.Add(bp.Libelle);
            }

            if (lstPeriode.Items.Count > 0) { lstPeriode.SelectedIndex = 0; }
        }

        public void Afficher_ListeBudget()
        {
            lstBudget.Nodes.Clear();

            if (lstPeriode.SelectedIndex < 0) { return; }

            listeBudget = Acces.clsOMEGA.Remplir_ListeBudget(Periode_choix);

            foreach (Budget bg in listeBudget)
            {
                TreeNode nd = new TreeNode(bg.Libelle);
                nd.Name = bg.ID.ToString();
                nd.Tag = bg;
                //Ajout des sous-dossiers
                TreeNode nd_ligne = new TreeNode("Lignes budgétaires"); nd_ligne.Tag = "LIGNE";
                TreeNode nd_version = new TreeNode("Versions"); nd_version.Tag = "VERSION";
                nd.Nodes.Add(nd_ligne); nd.Nodes.Add(nd_version);
                nd.Expand();
                lstBudget.Nodes.Add(nd);
            }

            if(budget != null)
            {
                TreeNode[] liste = lstBudget.Nodes.Find(budget.ID.ToString(), true);
                if (liste.Length > 0){ lstBudget.SelectedNode = liste[0]; }
            }

            Afficher_LigneBudget();

            DateMin_Select = ""; DateMax_Select = "";
            listeCompte_Select = new List<int>();
        }

        void Afficher_SelectionBudget()
        {
            treeSelectionBudget.Nodes.Clear();
            foreach (TreeNode nd in lstBudget.Nodes)
            {
                TreeNode ndc = (TreeNode) nd.Clone();
                treeSelectionBudget.Nodes.Add(ndc);
            }
            treeSelectionBudget.ExpandAll();
        }

        void lstPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstPeriode.SelectedIndex<0) { return; }

            Periode_choix = listeBudgetPeriode[lstPeriode.SelectedIndex].ID;
            Afficher_ListeBudget();
        }

        void Afficher_LigneBudget()
        {
            listeBudgetLigne = Acces.clsOMEGA.Remplir_ListeBudgetLigne(Periode_choix);
            listeBudgetLigne.Sort();

            foreach (Budget_Ligne bgl in listeBudgetLigne)
            {
                TreeNode nd = new TreeNode(bgl.Libelle);
                nd.Name = bgl.ID.ToString();
                nd.Tag = bgl;
                nd.ForeColor = Color.Black;

                //Recherche le budget
                TreeNode[] nd_budget = lstBudget.Nodes.Find(bgl.Budget_ID.ToString(),true );
                if (nd_budget.Length > 0)
                {
                    TreeNode nb_ligne = nd_budget[0].Nodes[0];
                    nb_ligne.Nodes.Add(nd);
                    nb_ligne.Expand();
                }
                else { MessageBox.Show("Budget non trouvé !"); }
            }
        }

        void Afficher_LigneVersion()
        {
            listeBudgetVersion = Acces.clsOMEGA.Remplir_ListeBudgetVersion(Periode_choix);
            listeBudgetVersion.Sort();

            foreach (Budget_Version bgl in listeBudgetVersion)
            {
                TreeNode nd = new TreeNode(bgl.Libelle);
                nd.Name = bgl.ID.ToString();
                nd.Tag = bgl;
                nd.ForeColor = Color.Black;

                //Recherche le budget
                TreeNode[] nd_budget = lstBudget.Nodes.Find(bgl.Budget_ID.ToString(), true);
                if (nd_budget.Length > 0)
                {
                    TreeNode nb_ligne = nd_budget[0].Nodes[1];
                    nb_ligne.Nodes.Add(nd);
                    nb_ligne.Expand();
                }
                else { MessageBox.Show("Budget non trouvé !"); }
            }
        }

        public void Afficher_DetailBudget()
        {
            List<ClasseRapport> ListeRapport = new List<ClasseRapport>();
            ClasseRapport clsRpt = new ClasseRapport();

            //Calcul des statistiques
            {
                List<Budget> ListeBudget = Acces.clsOMEGA.Remplir_ListeBudget(Periode_choix);
                List<Budget_Operation> ListeOperation = Acces.clsOMEGA.Remplir_ListeBudgetOperation(Periode_choix);

                foreach (Budget bg in ListeBudget)
                {
                    ClasseRapport.Ligne Ligne = new ClasseRapport.Ligne();
                    Ligne.Budget = bg.Libelle;

                    //AE
                    double S_Recette = 0;
                    double S_Depense = 0;

                    foreach (Budget_Operation bo in ListeOperation)
                    {
                        if (bg.Enveloppe == bo.Enveloppe && bo.Type_Montant == TypeMontant.AE)
                        {
                            if (bo.Type_Flux == TypeFlux.Recettes) { S_Recette += bo.Montant; }
                            if (bo.Type_Flux == TypeFlux.Dépenses) { S_Depense += bo.Montant; }
                        }
                    }

                    Ligne.Recette_AE = string.Format("{0:#,###,###.00}", S_Recette);
                    Ligne.Dépense_AE = string.Format("{0:#,###,###.00}", S_Depense);

                    //CP
                    S_Recette = 0;
                    S_Depense = 0;

                    foreach (Budget_Operation bo in ListeOperation)
                    {
                        if (bg.Enveloppe == bo.Enveloppe && bo.Type_Montant == TypeMontant.CP)
                        {
                            if (bo.Type_Flux == TypeFlux.Recettes) { S_Recette += bo.Montant; }
                            if (bo.Type_Flux == TypeFlux.Dépenses) { S_Depense += bo.Montant; }
                        }
                    }

                    Ligne.Recette_CP = string.Format("{0:#,###,###.00}", S_Recette);
                    Ligne.Dépense_CP = string.Format("{0:#,###,###.00}", S_Depense);

                    clsRpt.Liste.Add(Ligne);
                }
            }

            tabBudget.Controls.Clear();
            ReportViewer rpt = new ReportViewer();

            rpt.LocalReport.ReportEmbeddedResource = "PATIO.OMEGA.Rapports.Rapport_Budget.rdlc";

            rpt.LocalReport.DataSources.Clear();

            ReportDataSource rpt_data = new ReportDataSource();
            rpt_data.Name = "Data_Budget";
            rpt_data.Value = clsRpt.Liste;
            rpt.LocalReport.DataSources.Add(rpt_data);
            rpt.LocalReport.Refresh();

            rpt.RefreshReport();

            rpt.Dock = DockStyle.Fill;
            tabBudget.Controls.Add(rpt);
        }

        private void btnActualiserStructure_Click(object sender, EventArgs e)
        {
            Afficher_ListePeriode();
        }

        private void lstBudget_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (lstBudget.SelectedNode == null) { return; }

            TreeNode Nod = lstBudget.SelectedNode;
            if (Nod.Tag.ToString() == "LIGNE") { Nod = Nod.Parent; }
            if (Nod.Tag.ToString() == "VERSION") { Nod = Nod.Parent; }

            budget = null;
            budget_ligne = null;
            budget_version = null;
            try { budget = (Budget)Nod.Tag; } catch { }
            try { budget_ligne = (Budget_Ligne)Nod.Tag; } catch { }
            try { budget_version = (Budget_Version)Nod.Tag; } catch { }

            if (budget != null) { tabControlBudget.SelectedIndex = 0; }
            if (budget_ligne != null || lstBudget.SelectedNode.Tag.ToString() == "LIGNE") { tabControlBudget.SelectedIndex = 1; }
            if (budget_version != null || lstBudget.SelectedNode.Tag.ToString() == "VERSION") { tabControlBudget.SelectedIndex = 2; }

            Afficher_DetailBudget();
        }

        private void btnBudgetAjouter_Click(object sender, EventArgs e)
        {
            BudgetAjouter();
        }

        void BudgetAjouter()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }

            frmBudget f = new frmBudget();
            f.Acces = Acces;
            f.Chemin = Acces.CheminTemp;
            f.Console = Console;
            f.Creation = true;
            f.Period_id = Periode_choix;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget = f.budget;
                Afficher_ListeBudget();
            }
        }

        private void btnBudgetModifier_Click(object sender, EventArgs e)
        {
            BudgetModifier();
        }

        void BudgetModifier()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if (budget == null) { MessageBox.Show("Aucun budget sélection"); return; }

            frmBudget f = new frmBudget();
            f.Acces = Acces;
            //f.periode = exercice;
            f.Chemin = Acces.CheminTemp;
            f.Creation = false;
            f.Console = Console;
            f.budget = budget;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget = f.budget;
                lstBudget.SelectedNode.Text = f.budget.Libelle;
                Afficher_DetailBudget();
            }
        }

        private void btnBudgetSupprimer_Click(object sender, EventArgs e)
        {
            BudgetSupprimer();
        }

        void BudgetSupprimer()
        {
            if (budget == null) { MessageBox.Show("Aucun budget sélection"); return; }
            if (lstBudget.SelectedNode.Nodes.Count > 0) { MessageBox.Show("Il faut supprimer d'abord les lignes budgétaires."); return; }

            if (MessageBox.Show("Voulez-vous supprimer ce budget ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) { return; }

            Acces.Supprimer_Element(Acces.type_BUDGET, budget);
            lstBudget.Nodes.Remove(lstBudget.SelectedNode);

        }

        private void btnLigneAjouter_Click(object sender, EventArgs e)
        {
            LigneAjouter();
        }

        void LigneAjouter()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if(budget == null) { MessageBox.Show("Choisir un budget"); return; }

            frmLigne f = new frmLigne();
            f.Acces = Acces;
            f.Chemin = Acces.CheminTemp;
            f.Creation = true;
            f.Budget_id = budget.ID;
            f.Console = Console;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget_ligne = f.budget_ligne;
                Afficher_ListeBudget();
            }
        }

        private void btnLigneModifier_Click(object sender, EventArgs e)
        {
            LigneModifier();
        }

        void LigneModifier()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if (budget_ligne == null) { MessageBox.Show("Aucune ligne budgétaire sélectionnée"); return; }

            frmLigne f = new frmLigne();
            f.Acces = Acces;
            f.Chemin = Acces.CheminTemp;
            f.Creation = false;
            f.Console = Console;
            f.budget_ligne = budget_ligne;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget_ligne = f.budget_ligne;
                lstBudget.SelectedNode.Text = f.budget_ligne.Libelle;
                Afficher_DetailBudget();
            }
        }

        private void btnLigneSupprimer_Click(object sender, EventArgs e)
        {
            LigneSupprimer();
        }

        void LigneSupprimer()
        {
            if (budget_ligne == null) { MessageBox.Show("Aucune ligne budgétaire sélectionnée"); return; }

            if (MessageBox.Show("Voulez-vous supprimer cette ligne budgétaire ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) { return; }

            Acces.Supprimer_Element(Acces.type_BUDGET_LIGNE, budget_ligne);
            lstBudget.Nodes.Remove(lstBudget.SelectedNode);
        }

        private void btnVersionAjouter_Click(object sender, EventArgs e)
        {
            VersionAjouter();
        }

        void VersionAjouter()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if (budget == null) { MessageBox.Show("Choisir un budget"); return; }

            frmVersion f = new frmVersion();
            f.Acces = Acces;
            f.Creation = true;
            f.Budget_id = budget.ID;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget_version = f.budget_version;
                Afficher_LigneVersion();
            }
        }

        private void btnVersionModifier_Click(object sender, EventArgs e)
        {
            VersionModifier();
        }

        void VersionModifier()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if (budget_version == null) { MessageBox.Show("Choisir une version"); return; }

            frmVersion f = new frmVersion();
            f.Acces = Acces;
            f.Creation = false;
            f.budget_version = budget_version;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget_version = f.budget_version;
                lstBudget.SelectedNode.Text = budget_version.Libelle;
            }
        }

        private void btnVersionSupprimer_Click(object sender, EventArgs e)
        {
            VersionSupprimer();
        }

        void VersionSupprimer()
        {
            if (budget_version == null) { MessageBox.Show("Aucune version budgétaire sélectionnée"); return; }

            if (MessageBox.Show("Voulez-vous supprimer cette version budgétaire ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) { return; }

            Acces.Supprimer_Element(Acces.type_BUDGET_VERSION, budget_version);
            lstBudget.Nodes.Remove(lstBudget.SelectedNode);
        }

        private void btnOperationAjouter_Click(object sender, EventArgs e)
        {
            OperationAjouter();
        }

        void OperationAjouter()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if (Enveloppe_Select < 0) { MessageBox.Show("Il convient de choisir une enveloppe"); return; }
            if(!(Flux_Select == TypeFlux.Dépenses || Flux_Select == TypeFlux.Recettes)) { MessageBox.Show("Il convient de choisir un flux"); return; }

            frmOperation f = new frmOperation();
            f.Acces = Acces;
            f.Creation = true;
            f.Periode = Periode_choix;
            f.Enveloppe = Enveloppe_Select;
            f.TypeFlux = Flux_Select;
            f.budget_org = budget_org_Select;
            f.budget_geo = budget_geo_Select;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget_operation = f.budget_operation;
                Afficher_ListeOperation();
            }
        }

        private void btnOperationModifier_Click(object sender, EventArgs e)
        {
            OperationModifier();
        }

        void OperationModifier()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if (Enveloppe_Select < 0) { MessageBox.Show("Il convient de choisir une enveloppe"); return; }
            if (!(Flux_Select == TypeFlux.Dépenses || Flux_Select == TypeFlux.Recettes)) { MessageBox.Show("Il convient de choisir un flux"); return; }
            if (budget_operation == null) { MessageBox.Show("Il convient de choisir une opération"); return; }

            frmOperation f = new frmOperation();
            f.Acces = Acces;
            f.Creation = false;
            f.Periode = Periode_choix;
            f.Enveloppe = Enveloppe_Select;
            f.TypeFlux = Flux_Select;
            f.budget_org = budget_org_Select;
            f.budget_geo = budget_geo_Select;
            f.budget_operation = budget_operation;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget_operation = f.budget_operation;
                Afficher_ListeOperation();
            }
        }

        private void btnOperationSupprimer_Click(object sender, EventArgs e)
        {
            OperationSupprimer();
        }

        void OperationSupprimer()
        {
            if (budget_operation == null) { MessageBox.Show("Aucune opération sélectionnée"); return; }

            if (MessageBox.Show("Voulez-vous supprimer cette opération ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) { return; }

            Acces.Supprimer_Element(Acces.type_BUDGET_OPERATION, budget_operation);
            Afficher_ListeOperation();
        }

        void Afficher_ListeOperation()
        {
            double Somme = 0;
            DG_Operation.DataSource = null;

            //Extraction des données
            listeBudgetOperation = Acces.clsOMEGA.Remplir_ListeBudgetOperation(Periode_choix);

            //Application des filtres
            List<Budget_Operation> Liste = new List<Budget_Operation>();

            foreach (Budget_Operation bo in listeBudgetOperation)
            {
                bool ok = true;

                ok = ok && (bo.Enveloppe == Enveloppe_Select);
                ok = ok && (bo.Type_Flux == Flux_Select);
                ok = ok && (bo.Type_Montant == Montant_Select);
                if (!(budget_org_Select < 0)) { ok = ok && (bo.Budget_ORG == budget_org_Select); }
                if (!(budget_geo_Select < 0)) { ok = ok && (bo.Budget_GEO == budget_geo_Select); }

                //Lignes budgétaires sélectionnées
                if(listeCompte_Select.Count>0)
                {
                    bool ok_ligne = false;
                    foreach(int k in listeCompte_Select)
                    {
                        if(bo.Compte_ID == k) { ok_ligne = true; break; }
                    }
                    ok = ok_ligne;
                }

                //Versions sélectionnées
                if(DateMin_Select.Length>0)
                {
                    if (int.Parse(DateMin_Select) > int.Parse(bo.DateOperation)) { ok = false; }
                    if (int.Parse(DateMax_Select) < int.Parse(bo.DateOperation)) { ok = false; }
                }

                if (ok)
                {
                    Liste.Add(bo);
                    Somme += bo.Montant;
                }
            }

            //Affichage des informations
            DG_Operation.DataSource = Liste;
            lblMontantTotal.Text = string.Format("{0:#,###,##0.00}", Somme);

            Mettre_En_Forme_ListeOperation();
        }

        void Mettre_En_Forme_ListeOperation()
        { 
            //Masquer les colonnes
            DG_Operation.Columns["Type_Flux"].Visible = false;
            DG_Operation.Columns["Type_Operation"].Visible = false;
            DG_Operation.Columns["Enveloppe"].Visible = false;
            DG_Operation.Columns["Periode"].Visible = false;

            DG_Operation.Columns["ID"].Visible = false;
            DG_Operation.Columns["Code"].Visible = false;
            DG_Operation.Columns["Element_Type"].Visible = false;
            DG_Operation.Columns["Type_Element"].Visible = false;
            DG_Operation.Columns["DateOperation"].Visible = false;

            DG_Operation.Columns["Budget_ORG"].Visible = false;
            DG_Operation.Columns["Budget_GEO"].Visible = false;
            DG_Operation.Columns["Compte_ID"].Visible = false;
            DG_Operation.Columns["Libelle"].Visible = false;
            DG_Operation.Columns["Actif"].Visible = false;

            DG_Operation.Columns["Virement_ID"].Visible = false;

            //Renommer les colonnes affichées
            DG_Operation.Columns["Compte_Code_Afficher"].HeaderText = "N° Compte";
            DG_Operation.Columns["Compte_Libelle_Afficher"].HeaderText = "Libellé du Compte";
            DG_Operation.Columns["Budget_ORG_Afficher"].HeaderText = "ORG";
            DG_Operation.Columns["Budget_GEO_Afficher"].HeaderText = "GEO";
            DG_Operation.Columns["Date_Afficher"].HeaderText = "Date";
            DG_Operation.Columns["Type_Montant"].HeaderText = "TpM";

            //Réordonner les colonnes affichées
            DG_Operation.Columns["Compte_Code_Afficher"].DisplayIndex = 0;
            DG_Operation.Columns["Compte_Libelle_Afficher"].DisplayIndex = 1;

            //Alignement des colonnes affichées
            DG_Operation.Columns["Date_Afficher"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DG_Operation.Columns["Montant"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Définition des formats d'affichage
            DG_Operation.Columns["Montant"].DefaultCellStyle.Format = "#,###,###.00";

            //Définition des largeurs de colonnes
            for (int i =0;i<DG_Operation.Columns.Count;i++)
            { DG_Operation.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; }
            DG_Operation.Refresh();

            DG_Operation.Columns["Compte_Libelle_Afficher"].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;

        }

        void Afficher_ListeSelectionEnvFlux()
        {
            treeSelectionEnvFlux.Nodes.Clear();

            //Ajout de la liste des enveloppes
            TreeNode nd_Enveloppe = new TreeNode("Enveloppes");
            nd_Enveloppe.Tag = "ENVELOPPE";

            listeTypeEnveloppe = (List<Budget_Enveloppe>)Acces.Remplir_ListeElement(Acces.type_BUDGET_ENVELOPPE, "");

            foreach (Budget_Enveloppe benv in listeTypeEnveloppe)
            {
                TreeNode nd_plus = new TreeNode(benv.Libelle);
                nd_plus.Name = benv.ID.ToString();
                nd_Enveloppe.Nodes.Add(nd_plus);
            }
            //Sélection du premier
            if (nd_Enveloppe.Nodes.Count > 0)
            {
                nd_Enveloppe.Nodes[0].ForeColor = Color.Red;
                Enveloppe_Select = int.Parse(nd_Enveloppe.Nodes[0].Name);
            }
            nd_Enveloppe.Expand();
            treeSelectionEnvFlux.Nodes.Add(nd_Enveloppe);

            //Ajout de la liste des flux
            TreeNode nd_Flux = new TreeNode("Flux");
            nd_Flux.Tag = "FLUX";

            listeTypeFlux = Enum.GetNames(typeof(TypeFlux));

            int index = 0;
            foreach (var t in listeTypeFlux)
            {
                TreeNode nd_plus = new TreeNode(t);
                nd_plus.Tag = (TypeFlux) index;
                nd_Flux.Nodes.Add(nd_plus);
                if(t == TypeFlux.Dépenses.ToString()) { nd_plus.ForeColor = Color.Red; }
                index++;
            }
            nd_Flux.Expand();
            treeSelectionEnvFlux.Nodes.Add(nd_Flux);

            //Ajout de la liste des types montants
            TreeNode nd_Montant = new TreeNode("Types de montants");
            nd_Montant.Tag = "MONTANT";

            listeTypeMontant = Enum.GetNames(typeof(TypeMontant));

            index = 0;
            foreach (var t in listeTypeMontant)
            {
                TreeNode nd_plus = new TreeNode(t);
                nd_plus.Tag = (TypeMontant) index;
                nd_Montant.Nodes.Add(nd_plus);
                if (t == TypeMontant.CP.ToString()) { nd_plus.ForeColor = Color.Red; }
                index++;
            }
            nd_Montant.Expand();
            treeSelectionEnvFlux.Nodes.Add(nd_Montant);

            //Ajout de la liste des zones geographiques
            TreeNode nd_ORG = new TreeNode("Zones organisationnelles");
            nd_ORG.Tag = "ORG";

            listeORG = Acces.Remplir_ListeTableValeur("BUDGET_ORG");

            foreach (table_valeur tv in listeORG)
            {
                TreeNode nd_plus = new TreeNode(tv.Valeur);
                nd_plus.Name = tv.ID.ToString();
                nd_ORG.Nodes.Add(nd_plus);
                if (tv.ID == budget_org_Select) { nd_plus.ForeColor = Color.Red; }
            }
            nd_ORG.Expand();
            treeSelectionEnvFlux.Nodes.Add(nd_ORG);

            //Ajout de la liste des zones geographiques
            TreeNode nd_GEO = new TreeNode("Zones géographiques");
            nd_GEO.Tag = "GEO";

            listeGEO = Acces.Remplir_ListeTableValeur("BUDGET_GEO");

            foreach (table_valeur tv in listeGEO)
            {
                TreeNode nd_plus = new TreeNode(tv.Valeur);
                nd_plus.Name = tv.ID.ToString();
                nd_GEO.Nodes.Add(nd_plus);
                if (tv.ID == budget_geo_Select) { nd_plus.ForeColor = Color.Red; }
            }
            nd_GEO.Expand();
            treeSelectionEnvFlux.Nodes.Add(nd_GEO);
        }

        private void treeSelectionEnvFlux_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nd = treeSelectionEnvFlux.SelectedNode;

            if (nd.Parent == null) { return; } //Noeud sans parent
            if (nd.Nodes.Count > 0) { return; } //Noeud avec enfant

            foreach(TreeNode ndd in nd.Parent.Nodes)
            {
                ndd.ForeColor=Color.Black;
            }

            nd.ForeColor=(nd.ForeColor == Color.Black? Color.Red : Color.Black);

            if (nd.Parent.Tag.ToString() == "ENVELOPPE")
            {
                Enveloppe_Select = (nd.ForeColor == Color.Black ? -1 : int.Parse(nd.Name));
            }

            if (nd.Parent.Tag.ToString() == "FLUX")
            {
                Flux_Select = (nd.ForeColor == Color.Black ? TypeFlux.Dépenses : (TypeFlux) nd.Tag);
            }

            if (nd.Parent.Tag.ToString() == "MONTANT")
            {
                Montant_Select = (nd.ForeColor == Color.Black ? TypeMontant.CP : (TypeMontant)nd.Tag);
            }

            if (nd.Parent.Tag.ToString() == "ORG")
            {
                budget_org_Select = (nd.ForeColor == Color.Black ? 0: int.Parse(nd.Name));
            }

            if (nd.Parent.Tag.ToString() == "GEO")
            {
                budget_geo_Select = (nd.ForeColor == Color.Black ? 0 : int.Parse(nd.Name));
            }

            Afficher_ListeOperation();
            Afficher_ListeVirement();
        }

        private void ctrlListeBudget_Resize(object sender, EventArgs e)
        {
            Redimensionner();
        }

        void Redimensionner()
        {
            Application.DoEvents();
            try
            {
                groupEnvFlux.Height = panelOperationGauche.Height / 2;
            }
            catch { }
        }

        private void tabOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Redimensionner();
        }

        private void DG_SelectionChanged(object sender, EventArgs e)
        {
            budget_operation = null;
            if(DG_Operation.SelectedRows.Count == 0) { return; }
            int operation_id = int.Parse(DG_Operation.SelectedRows[0].Cells["ID"].Value.ToString());
            budget_operation = (Budget_Operation)Acces.Trouver_Element(Acces.type_BUDGET_OPERATION,operation_id);
        }

        private void treeSelectionBudget_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nd = treeSelectionBudget.SelectedNode;

            DateMin_Select = "";
            DateMax_Select = "";
            listeCompte_Select = new List<int>();

            if (nd.Parent == null) { return; } //Noeud sans parent
            if (nd.Nodes.Count > 0) { return; } //Noeud avec enfant

            nd.ForeColor = (nd.ForeColor == Color.Black ? Color.Red : Color.Black);

            TreeNode NdBudget = nd.Parent.Parent;

            Console.Ajouter("Nb nodes=" + nd.Parent.Nodes.Count.ToString());

            foreach (TreeNode ndd in NdBudget.Nodes[0].Nodes)
            {
                Console.Ajouter("->" + ndd.Text);
                if(ndd.ForeColor == Color.Red)
                {
                    Budget_Ligne bl = (Budget_Ligne) ndd.Tag;
                    foreach (int k in bl.ListeCompte) { listeCompte_Select.Add(k); }
                }
            }

            foreach (TreeNode ndd in NdBudget.Nodes[1].Nodes)
            {
                Console.Ajouter("->" + ndd.Text + " : " + ndd.ForeColor.ToString());
                if (ndd.ForeColor == Color.Red)
                {
                    Budget_Version bv = (Budget_Version)ndd.Tag;
                    Console.Ajouter("ID=" + bv.ID.ToString());
                    Console.Ajouter("DateMin : " + (DateMin_Select.CompareTo(bv.DateDeb).ToString()));

                    if (DateMin_Select.Length == 0) { DateMin_Select = bv.DateDeb; }
                    else
                    {
                        if (DateMin_Select.CompareTo(bv.DateDeb) < 0)
                        { Console.Ajouter("Date_Min" + bv.DateDeb); DateMin_Select = bv.DateDeb; }
                    }
                    if (DateMax_Select.Length == 0) { DateMax_Select = bv.DateFin; }
                    else
                    {
                        if (DateMax_Select.CompareTo(bv.DateFin) < 0)
                        { Console.Ajouter("Date_Max="+bv.DateFin); DateMax_Select = bv.DateFin; }
                    }
                }
            }

            Afficher_ListeOperation();
            Afficher_ListeVirement();
        }

        private void lstEnveloppeVirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeVirement();
        }

        void Afficher_ListeVirement()
        {
            DG_Virement.DataSource = null;

            //Extraction des données
            listeBudgetVirement = Acces.clsOMEGA.Remplir_ListeBudgetVirement(Periode_choix);

            //Application des filtres
            List<Budget_Virement> Liste = new List<Budget_Virement>();

            foreach (Budget_Virement bo in listeBudgetVirement)
            {
                bool ok = true;

                ok = ok && ((bo.Enveloppe_Src == Enveloppe_Select) || (bo.Enveloppe_Dest == Enveloppe_Select));
                ok = ok && (bo.Type_Flux == Flux_Select);
                ok = ok && (bo.Type_Montant == Montant_Select);
                if (!(budget_org_Select < 0)) { ok = ok && ((bo.Budget_ORG_Src == budget_org_Select) || (bo.Budget_ORG_Dest == budget_org_Select)); }
                if (!(budget_geo_Select < 0)) { ok = ok && ((bo.Budget_GEO_Src == budget_geo_Select) || (bo.Budget_GEO_Dest == budget_geo_Select)); }

                //Virement budgétaires sélectionnées
                if (listeCompte_Select.Count > 0)
                {
                    bool ok_ligne = false;
                    foreach (int k in listeCompte_Select)
                    {
                        if ((bo.Compte_ID_Src == k) || (bo.Compte_ID_Dest == k)) { ok_ligne = true; break; }
                    }
                    ok = ok_ligne;
                }

                //Versions sélectionnées
                if (DateMin_Select.Length > 0)
                {
                    if (int.Parse(DateMin_Select) > int.Parse(bo.DateEffet)) { ok = false; }
                    if (int.Parse(DateMax_Select) < int.Parse(bo.DateEffet)) { ok = false; }
                }

                if (ok)
                {
                    Liste.Add(bo);
                }
            }

            Console.Ajouter("NB Virements : " + Liste.Count);
            //Affichage des informations
            DG_Virement.DataSource = Liste;

            Mettre_En_Forme_ListeVirement();
        }

        void Mettre_En_Forme_ListeVirement()
        {
            //Masquer les colonnes
            DG_Virement.Columns["Periode"].Visible = false;

            DG_Virement.Columns["Enveloppe_Src"].Visible = false;
            DG_Virement.Columns["Budget_ORG_Src"].Visible = false;
            DG_Virement.Columns["Budget_GEO_Src"].Visible = false;
            DG_Virement.Columns["Compte_ID_Src"].Visible = false;

            DG_Virement.Columns["Enveloppe_Dest"].Visible = false;
            DG_Virement.Columns["Budget_ORG_Dest"].Visible = false;
            DG_Virement.Columns["Budget_GEO_Dest"].Visible = false;
            DG_Virement.Columns["Compte_ID_Dest"].Visible = false;
            DG_Virement.Columns["Validé"].Visible = false;

            DG_Virement.Columns["ID"].Visible = false;
            DG_Virement.Columns["Code"].Visible = false;
            DG_Virement.Columns["Libelle"].Visible = false;
            DG_Virement.Columns["Element_Type"].Visible = false;
            DG_Virement.Columns["Type_Element"].Visible = false;
            DG_Virement.Columns["Actif"].Visible = false;

            DG_Virement.Columns["DateDemande"].Visible = false;
            DG_Virement.Columns["DateEffet"].Visible = false;

            //Renommer les colonnes affichées
            DG_Virement.Columns["DateDemande_Afficher"].HeaderText = "Date Demande";
            DG_Virement.Columns["DateEffet_Afficher"].HeaderText = "Date Effet";

            DG_Virement.Columns["Budget_ORG_Src_Afficher"].HeaderText = "ORG SRC";
            DG_Virement.Columns["Budget_GEO_Src_Afficher"].HeaderText = "GEO SRC";
            DG_Virement.Columns["Enveloppe_Src_Afficher"].HeaderText = "Env. SRC";
            DG_Virement.Columns["Compte_Code_Src_Afficher"].HeaderText = "Cpt. SRC";
            DG_Virement.Columns["Budget_ORG_Dest_Afficher"].HeaderText = "ORG DEST";
            DG_Virement.Columns["Budget_GEO_Dest_Afficher"].HeaderText = "GEO DEST";
            DG_Virement.Columns["Enveloppe_Dest_Afficher"].HeaderText = "Env. DEST";
            DG_Virement.Columns["Compte_Code_Dest_Afficher"].HeaderText = "Cpt. DEST";
            DG_Virement.Columns["Type_Flux"].HeaderText = "Flux";
            DG_Virement.Columns["Type_Montant"].HeaderText = "AE/CP";
            DG_Virement.Columns["Validé_Afficher"].HeaderText = "Val.";

            //Réordonner les colonnes affichées
            /* DG_Virement.Columns["Compte_Code_Afficher"].DisplayIndex = 0;
             DG_Virement.Columns["Compte_Libelle_Afficher"].DisplayIndex = 1;

             //Alignement des colonnes affichées
             DG_Virement.Columns["Date_Afficher"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             DG_Virement.Columns["Montant"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
             */
            //Définition des formats d'affichage
            DG_Virement.Columns["Montant"].DefaultCellStyle.Format = "#,###,##0.00";

            //Définition des largeurs de colonnes
            for (int i = 0; i < DG_Virement.Columns.Count; i++)
            { DG_Virement.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; }
            DG_Virement.Refresh();

            //DG_Virement.Columns["Compte_Libelle_Afficher"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnCréerVirement_Click(object sender, EventArgs e)
        {
            VirementAjouter();
        }

        void VirementAjouter()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if (Enveloppe_Select < 0) { MessageBox.Show("Il convient de choisir une enveloppe"); return; }
            if (!(Flux_Select == TypeFlux.Dépenses || Flux_Select == TypeFlux.Recettes)) { MessageBox.Show("Il convient de choisir un flux"); return; }

            frmVirement f = new frmVirement();
            f.Acces = Acces;
            f.Creation = true;
            f.Periode = Periode_choix;
            f.Enveloppe = Enveloppe_Select;
            f.TypeFlux = Flux_Select;
            f.budget_org = budget_org_Select;
            f.budget_geo = budget_geo_Select;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget_virement = f.budget_virement;
                Afficher_ListeVirement();
            }
        }

        private void btnModifierVirement_Click(object sender, EventArgs e)
        {
            VirementModifier();
        }

        void VirementModifier()
        {
            if (Periode_choix == 0) { MessageBox.Show("Il convient de choisir une période"); return; }
            if (Enveloppe_Select < 0) { MessageBox.Show("Il convient de choisir une enveloppe"); return; }
            if (!(Flux_Select == TypeFlux.Dépenses || Flux_Select == TypeFlux.Recettes)) { MessageBox.Show("Il convient de choisir un flux"); return; }
            if(DG_Virement.SelectedRows.Count == 0) { MessageBox.Show("IL faut sélectionner un virement"); return; }

            frmVirement f = new frmVirement();
            f.Acces = Acces;
            f.Creation = false;
            f.Periode = Periode_choix;
            f.Enveloppe = Enveloppe_Select;
            f.TypeFlux = Flux_Select;
            f.budget_org = budget_org_Select;
            f.budget_geo = budget_geo_Select;
            f.budget_virement = budget_virement;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                budget_virement = f.budget_virement;
                Afficher_ListeVirement();
            }
        }

        private void btnSupprimerVirement_Click(object sender, EventArgs e)
        {
            VirementSupprimer();
        }

        void VirementSupprimer()
        {
            if (budget_virement == null) { MessageBox.Show("Aucun virement sélectionné"); return; }

            if (MessageBox.Show("Voulez-vous supprimer ce virement ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) { return; }

            Acces.Supprimer_Element(Acces.type_BUDGET_VIREMENT, budget_virement);
            Afficher_ListeVirement();
        }

        private void btnValiderVirement_Click(object sender, EventArgs e)
        {
            VirementValider();
        }

        void VirementValider()
        {
            if(budget_virement == null) { return; }

            if(budget_virement.Validé)
            {
                MessageBox.Show("Ce virement est déjà validé.");
                return;
            }

            string message = "Etes-vous sûr de vouloir valider ce virement ?" + (char) Keys.Return +
                            "2 opérations vont être créées correspondant aux flux souhaités";
            if(MessageBox.Show(message,"Confirmation", MessageBoxButtons.YesNo)  == DialogResult.No) { return; }

            //Création de l'opération en débit
            Budget_Operation bo1 = new Budget_Operation();
            bo1.Acces = Acces;
            bo1.Type_Flux = budget_virement.Type_Flux;
            bo1.Code = "OPE-" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + "D";
            bo1.Libelle = "OPERATION - VIREMENT - DEBIT";
            bo1.Periode = budget_virement.Periode;
            bo1.Enveloppe = budget_virement.Enveloppe_Src;
            bo1.Budget_ORG = budget_virement.Budget_ORG_Src;
            bo1.Budget_GEO = budget_virement.Budget_GEO_Src;
            bo1.Compte_ID = budget_virement.Compte_ID_Src;
            bo1.Type_Montant = budget_virement.Type_Montant;
            bo1.Virement_ID = budget_virement.ID;
            bo1.Type_Element = (int)TypeVirement.Normal;
            bo1.DateOperation = budget_virement.DateEffet;
            bo1.Montant = -budget_virement.Montant;
            bo1.Actif = true;
            int id1 = Acces.Ajouter_Element(Acces.type_BUDGET_OPERATION, bo1);
            Console.Ajouter("Création opération id " + id1.ToString());

            //Création de l'opration en crédit
            Budget_Operation bo2 = new Budget_Operation();
            bo2.Acces = Acces;
            bo2.Type_Flux = budget_virement.Type_Flux;
            bo2.Code = "OPE-" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + "C";
            bo2.Libelle = "OPERATION - VIREMENT - CREDIT";
            bo2.Periode = budget_virement.Periode;
            bo2.Enveloppe = budget_virement.Enveloppe_Dest;
            bo2.Budget_ORG = budget_virement.Budget_ORG_Dest;
            bo2.Budget_GEO = budget_virement.Budget_GEO_Dest;
            bo2.Compte_ID = budget_virement.Compte_ID_Dest;
            bo2.Type_Montant = budget_virement.Type_Montant;
            bo2.Virement_ID = budget_virement.ID;
            bo2.Type_Element = (int)TypeVirement.Normal;
            bo2.DateOperation = budget_virement.DateEffet;
            bo2.Montant = budget_virement.Montant;
            bo2.Actif = true;
            int id2 =  Acces.Ajouter_Element(Acces.type_BUDGET_OPERATION, bo2);
            Console.Ajouter("Création opération id " + id2.ToString());

            //Enregistrement de la validation
            budget_virement.Validé = true;
            Acces.Enregistrer(Acces.type_BUDGET_VIREMENT, budget_virement);
            Console.Ajouter("Virement id " + budget_virement.ID.ToString() + " mis à jour");

            Afficher_ListeVirement();
            Afficher_ListeOperation();
        }

        private void DG_Virement_SelectionChanged(object sender, EventArgs e)
        {
            budget_virement = null;
            if(DG_Virement.SelectedRows.Count == 0) { return; }

            int id = int.Parse(DG_Virement.SelectedRows[0].Cells["ID"].Value.ToString());
            budget_virement = (Budget_Virement)Acces.Trouver_Element(Acces.type_BUDGET_VIREMENT, id);
        }

        private void btnBUDGET_Click(object sender, EventArgs e)
        {
            Afficher_Tab_BUDGET();
        }

        public void Afficher_Tab_BUDGET()
        { 
            btnBUDGET.CheckState = CheckState.Checked;
            btnOPERATION.CheckState = CheckState.Unchecked;
            btnVIREMENT.CheckState = CheckState.Unchecked;

            tabControl.SelectedIndex = 0;
            Afficher_SelectionBouton();
        }

        private void btnOPERATION_Click(object sender, EventArgs e)
        {
            Afficher_Tab_OPERATION();
        }

        public void Afficher_Tab_OPERATION()
        { 
            btnBUDGET.CheckState =  CheckState.Unchecked;
            btnOPERATION.CheckState = CheckState.Checked;
            btnVIREMENT.CheckState = CheckState.Unchecked;

            tabControl.SelectedIndex = 1;
            tabControlOpeVir.SelectedIndex = 0;
            Afficher_SelectionBouton();
        }

        private void btnVIREMENT_Click(object sender, EventArgs e)
        {
            Afficher_Tab_VIREMENT();
        }

        public void Afficher_Tab_VIREMENT()
        { 
            btnBUDGET.CheckState = CheckState.Unchecked;
            btnOPERATION.CheckState = CheckState.Unchecked;
            btnVIREMENT.CheckState = CheckState.Checked;

            tabControl.SelectedIndex = 1;
            tabControlOpeVir.SelectedIndex = 1;
            Afficher_SelectionBouton();
        }

        void Afficher_SelectionBouton()
        {
            btnBUDGET.BackgroundImage = (btnBUDGET.Checked) ? PATIO.Properties.Resources.fond_jaune : null;
            btnOPERATION.BackgroundImage = (btnOPERATION.Checked) ? PATIO.Properties.Resources.fond_jaune : null;
            btnVIREMENT.BackgroundImage = (btnVIREMENT.Checked) ? PATIO.Properties.Resources.fond_jaune : null;
        }
    }
}
