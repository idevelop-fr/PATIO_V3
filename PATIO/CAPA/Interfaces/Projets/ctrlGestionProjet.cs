using System;
using System.Collections.Generic;
using PATIO.MAIN.Classes;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlGestionProjet : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public ctrlConsole Console;

        public Projet projet;

        TreeNode Nod_Processus;
        TreeNode Nod_Start;
        TreeNode Nod_Iteration;
        TreeNode Nod_Close;
        TreeNode Nod_Donnee;
        TreeNode Nod_Finance;
        TreeNode Nod_Document;

        List<Process> ListeProcessus;
        List<table_valeur> ListeDonnees;
        List<table_valeur> ListeFinance;

        int nb_iteration = 0;

        public ctrlGestionProjet()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Initaliser_Images();
            ListeDonnees = Acces.Remplir_ListeTableValeur("DONNEE_PROCESSUS");
            ListeProcessus = (List<Process>)Acces.Remplir_ListeElement(Acces.type_PROCESSUS, "");

            treePhase.Nodes.Clear();

            Nod_Processus = new TreeNode("Processus");
            Nod_Processus.ImageIndex = 1;
            Nod_Processus.Name = "PROCESS-";

            Nod_Start = new TreeNode("Démarrage");
            Nod_Start.ImageIndex = 2;
            Nod_Start.Name = "START-";
            Nod_Processus.Nodes.Add(Nod_Start);

            Nod_Iteration = new TreeNode("Itérations");
            Nod_Iteration.ImageIndex = 3;
            Nod_Iteration.Name = "ITERATION-";
            Nod_Processus.Nodes.Add(Nod_Iteration);

            Nod_Close = new TreeNode("Cloture");
            Nod_Close.ImageIndex = 5;
            Nod_Close.Name = "CLOSE-";
            Nod_Processus.Nodes.Add(Nod_Close);

            Nod_Donnee = new TreeNode("Données du projet");
            Nod_Donnee.ImageIndex = 6;
            Nod_Donnee.Name = "DONNEE-";
            Afficher_Donnee_Projet();

            Nod_Finance = new TreeNode("Données financières");
            Nod_Finance.ImageIndex = 7;
            Nod_Finance.Name = "FINANCE-";
            Ajouter_Structure_Finance();

            Nod_Document = new TreeNode("Documentation");
            Nod_Document.ImageIndex = 8;
            Nod_Document.Name = "DOC-";

            Ajouter_Iteration();

            Nod_Processus.Expand();
            treePhase.Nodes.Add(Nod_Processus);
            treePhase.Nodes.Add(Nod_Donnee);
            treePhase.Nodes.Add(Nod_Finance);
            treePhase.Nodes.Add(Nod_Document);
        }

        void Initaliser_Images()
        {
            imageList1.Images.Clear();
            imageList1.Images.Add(Properties.Resources.fleche_droite_vert);
            imageList1.Images.Add(Properties.Resources.Processus);
            imageList1.Images.Add(Properties.Resources.btn_carre_demarrage);
            imageList1.Images.Add(Properties.Resources.btn_losange_);
            imageList1.Images.Add(Properties.Resources.btn_carre_iteration);
            imageList1.Images.Add(Properties.Resources.btn_carre_cloture);
            imageList1.Images.Add(Properties.Resources.SP_D);
            imageList1.Images.Add(Properties.Resources.analyse);
            imageList1.Images.Add(Properties.Resources.pj1);

            imageList2.Images.Clear();
            imageList2.Images.Add(Properties.Resources.fleche_droite_vert);
            imageList2.Images.Add(Properties.Resources.btn_carre_planif);
            imageList2.Images.Add(Properties.Resources.btn_carre_execution);
            imageList2.Images.Add(Properties.Resources.btn_carre_surveillance);
            imageList2.Images.Add(Properties.Resources.btn_carre_jaune);
            imageList2.Images.Add(Properties.Resources.btn_carre_vert);

        }

        private void btnAjouterIteration_Click(object sender, EventArgs e)
        {
            Ajouter_Iteration();
        }

        void Ajouter_Iteration()
        {
            nb_iteration++;
            TreeNode Nd = new TreeNode("Itération " + nb_iteration);
            Nd.ImageIndex = 4;
            Nd.Name = "ITERATION-" + nb_iteration;
            Ajouter_Structure_Iteration();

            Nd.Expand();
            Nod_Iteration.Nodes.Add(Nd);
            Nod_Iteration.Expand();
        }

        void Ajouter_Structure_Iteration()
        {
            TreeNode Nod_Planif = new TreeNode("Planification");
            Nod_Planif.ImageIndex = 1;
            Nod_Planif.Name = "PLAN-" + nb_iteration;
            treeIteration.Nodes.Add(Nod_Planif);
            Ajouter_Contenu_Phase(Nod_Planif, "PRO-PMBOK-02_", "PLAN");

            TreeNode Nod_Exe = new TreeNode("Exécution");
            Nod_Exe.ImageIndex = 2;
            Nod_Exe.Name = "EXEC-" + nb_iteration;
            treeIteration.Nodes.Add(Nod_Exe);
            Ajouter_Contenu_Phase(Nod_Exe, "PRO-PMBOK-03_", "EXEC");

            TreeNode Nod_Surv = new TreeNode("Surveillance");
            Nod_Surv.ImageIndex = 3;
            Nod_Surv.Name = "SURV-" + nb_iteration;
            treeIteration.Nodes.Add(Nod_Surv);
            Ajouter_Contenu_Phase(Nod_Surv, "PRO-PMBOK-04_", "SUIV");
        }

        void Ajouter_Structure_Finance()
        {
            treeFinance.Nodes.Clear();
            ListeFinance = Acces.Remplir_ListeTableValeur("MODELE_DONNEE");

            foreach(table_valeur tv in ListeFinance)
            {
                if (tv.Code.Contains("DONNEE-FIN"))
                {
                    TreeNode Nd = new TreeNode(tv.Valeur);
                    Nd.Name = "FINANCE-" + tv.ID;
                    treeFinance.Nodes.Add(Nd);
                }
            }
            treeFinance.ExpandAll();
        }

        void Ajouter_Structure_Projet()
        {
            treeFinance.Nodes.Clear();
            ListeFinance = Acces.Remplir_ListeTableValeur("MODELE_DONNEE");

            foreach (table_valeur tv in ListeFinance)
            {
                if (tv.Code.Contains("DONNEE-PROJET"))
                {
                    TreeNode Nd = new TreeNode(tv.Valeur);
                    Nd.Name = "FINANCE-" + tv.ID;
                    treeFinance.Nodes.Add(Nd);
                }
            }
            treeFinance.ExpandAll();
        }

        private void btnAfficherProcessus_Click(object sender, EventArgs e)
        {
            Ouvrir_Processus();   
        }

        void Ouvrir_Processus()
        {
            if (treePhase.SelectedNode == null) { return; }

            string processus = treePhase.SelectedNode.Name.Split('-')[0];

            if (processus == "START") { Ouvrir_Processus_Démarrage(); }
            //if (processus == "PLAN") { Ouvrir_Processus_Iteration_Planification(); }
            //if (processus == "EXEC") { Ouvrir_Processus_Iteration_Execution(); }
            //if (processus == "SURV") { Ouvrir_Processus_Iteration_Surveillance(); }
            if (processus == "CLOSE") { Ouvrir_Processus_Cloture(); }
        }

        void Ouvrir_Processus_Démarrage()
        {
            ctrlProjet_01_Demarrage ctrl = new ctrlProjet_01_Demarrage();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Initialiser();
            ctrl.Dock = DockStyle.Fill;

            DockContent D = new DockContent();
            D.Controls.Add(ctrl);

            D.Text = "Processus Démarrage";
            D.Tag = "PROCESSUS-DEMARRAGE";
            D.ShowInTaskbar = false;
            D.CloseButton = true;
            D.Show(Acces.DP, DockState.Document);
        }

        void Ouvrir_Processus_Cloture()
        {
            ctrlProjet_05_Cloture ctrl = new ctrlProjet_05_Cloture();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Initialiser();
            ctrl.Dock = DockStyle.Fill;

            DockContent D = new DockContent();
            D.Controls.Add(ctrl);

            D.Text = "Processus Cloture";
            D.Tag = "PROCESSUS-CLOTURE";
            D.ShowInTaskbar = false;
            D.CloseButton = true;
            D.Show(Acces.DP, DockState.Document);
        }

        private void treePhase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Afficher_Contenu_Phase();
        }

        void Afficher_Contenu_Phase()
        {
            {
                if (treePhase.SelectedNode == null) { return; }

                string processus = treePhase.SelectedNode.Name.Split('-')[0];

                if (processus == "START") { tabControl.SelectedTab = tabDemarrage; Ajouter_Contenu_Phase(treeDemarrage, "PRO-PMBOK-01_","START"); }
                if (processus == "ITERATION") { tabControl.SelectedTab = tabIteration; }
                //if (processus == "PLAN") { tabControl.SelectedTab = tabPlanification; Afficher_Contenu_Phase(treePlanification, "PRO-PMBOK-02_", "PLAN"); }
                //if (processus == "EXEC") { tabControl.SelectedTab = tabExecution; Afficher_Contenu_Phase(treeExecution, "PRO-PMBOK-03_","EXEC"); }
                //if (processus == "SURV") { tabControl.SelectedTab = tabSurveillance; Afficher_Contenu_Phase(treeSurveillance, "PRO-PMBOK-04_","SURV"); }
                if (processus == "CLOSE") { tabControl.SelectedTab = tabCloture; Ajouter_Contenu_Phase(treeCloture, "PRO-PMBOK-05_","CLOSE"); }
                if (processus == "DONNEE") { tabControl.SelectedTab = tabDonnee; }
                if (processus == "FINANCE") { tabControl.SelectedTab = tabFinance; }
                if (processus == "DOC") { tabControl.SelectedTab = tabDocumentation; }
            }
        }

        void Ajouter_Contenu_Phase(TreeNode Nod, string recherche, string Tag)
        {
            Nod.Nodes.Clear();
            List<int> lDonnee = new List<int>();
            bool ok;

            TreeNode Nd_Entrant = new TreeNode("Données entrantes",4,0);
            TreeNode Nd_Sortant = new TreeNode("Données sortantes",5,0);

            foreach (Process p in ListeProcessus)
            {
                if (p.Code.Contains(recherche))
                {
                    foreach (int k in p.DonneeSortante)
                    {
                        ok = true;
                        foreach (int i in lDonnee) { if (i == k) { ok = false; break; } }
                        if (ok) { Nd_Sortant.Nodes.Add(Tag + k, Acces.Trouver_TableValeur(k).Valeur); lDonnee.Add(k); }
                    }

                    foreach (int k in p.DonneeEntrante)
                    {
                        ok = true;
                        foreach(int i in lDonnee) { if(i == k) { ok = false; break; } }
                        if (ok) { Nd_Entrant.Nodes.Add(Tag + k, Acces.Trouver_TableValeur(k).Valeur); lDonnee.Add(k); }
                    }
                }
            }

            Nd_Entrant.Expand();
            Nd_Sortant.Expand();
            Nod.Nodes.Add(Nd_Entrant);
            Nod.Nodes.Add(Nd_Sortant);
        }

        void Ajouter_Contenu_Phase(TreeView Nod, string recherche, string Tag)
        {
            Nod.Nodes.Clear();
            List<int> lDonnee = new List<int>();
            bool ok;

            TreeNode Nd_Entrant = new TreeNode("Données entrantes",4,0);
            TreeNode Nd_Sortant = new TreeNode("Données sortantes",5,0);

            foreach (Process p in ListeProcessus)
            {
                if (p.Code.Contains(recherche))
                {
                    foreach (int k in p.DonneeSortante)
                    {
                        ok = true;
                        foreach (int i in lDonnee) { if (i == k) { ok = false; break; } }
                        if (ok) { Nd_Sortant.Nodes.Add(Tag + k, Acces.Trouver_TableValeur(k).Valeur); lDonnee.Add(k); }
                    }

                    foreach (int k in p.DonneeEntrante)
                    {
                        ok = true;
                        foreach (int i in lDonnee) { if (i == k) { ok = false; break; } }
                        if (ok) { Nd_Entrant.Nodes.Add(Tag + k, Acces.Trouver_TableValeur(k).Valeur); lDonnee.Add(k); }
                    }
                }
            }

            Nd_Entrant.Expand();
            Nd_Sortant.Expand();
            Nod.Nodes.Add(Nd_Entrant);
            Nod.Nodes.Add(Nd_Sortant);
        }

        void Afficher_Donnee_Projet()
        {
            lstDonnee.Items.Clear();
            List<int> lDonnee = new List<int>();
            bool ok;

            foreach (Process p in ListeProcessus)
            {
                foreach (int k in p.DonneeSortante)
                {
                    ok = true;
                    foreach (int i in lDonnee) { if (i == k) { ok = false; break; } }
                    if (ok) { lstDonnee.Items.Add(Acces.Trouver_TableValeur(k).Valeur); lDonnee.Add(k); }
                }

                foreach (int k in p.DonneeEntrante)
                {
                    ok = true;
                    foreach (int i in lDonnee) { if (i == k) { ok = false; break; } }
                    if (ok) { lstDonnee.Items.Add(Acces.Trouver_TableValeur(k).Valeur); lDonnee.Add(k); }
                }
            }
        }
    }
}
