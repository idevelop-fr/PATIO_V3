using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;
using PATIO.ADMIN.Classes;
using PATIO.CAPA.Interfaces;

namespace PATIO
{
    public partial class ctrlAccueil : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public Utilisateur user_appli;

        List<Utilisateur> Liste;

        bool Chargé = false;

        public ctrlAccueil()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Procédure d'initialisation du composant
        /// </summary>
        public void Initialiser()
        {
            tabControl.SendToBack();
            Afficher_ListeUtilisateur();
            Afficher_ListeEspace();
        }

        /// <summary>
        /// Affiche les différentes options d'affichage 
        /// Cible : Combo
        /// </summary>
        void Afficher_ListeEspace()
        {
            lstEspace.Items.Clear();
            lstEspace.Items.Add("Mes éléments favoris");
            lstEspace.Items.Add("CAPA - Mes éléments Pilote");
            lstEspace.Items.Add("CAPA - Mes éléments Membre");
            lstEspace.Items.Add("OMEGA - Tableau de bord");
            lstEspace.Items.Add("Recherche");

            lstEspace.SelectedIndex = 0;
        }

        /// <summary>
        /// Affiche les éléments dont l'utilisateur est identifié comme pilote
        /// Cible : Treeview
        /// </summary>
        /// <param name="user"></param>
        public void Afficher_ObjetPilote(Utilisateur user)
        {
            if (!Chargé) { return; }

            List<Plan> Liste1 = (List<Plan>)Acces.Remplir_ListeElement(Acces.type_PLAN, "");
            TreeNode Nd1 = new TreeNode("Plans");

            foreach (Plan p in Liste1)
            {
                if (!(p.Pilote is null))
                {
                    if (p.Pilote.ID == user.ID)
                    {
                        TreeNode nd = new TreeNode(p.Libelle);
                        nd.Name = "PLA-" + p.ID;
                        nd.Tag = p;
                        Nd1.Nodes.Add(nd);
                    }
                }
            }
            Nd1.Expand();

            List<Objectif> Liste2 = (List<Objectif>)Acces.Remplir_ListeElement(Acces.type_OBJECTIF, "");
            TreeNode Nd2 = new TreeNode("Objectifs");

            foreach (Objectif p in Liste2)
            {
                if (!(p.Pilote is null))
                {
                    if (p.Pilote.ID == user.ID)
                    {
                        TreeNode nd = new TreeNode(p.Libelle);
                        nd.Name = "OBJ-" + p.ID;
                        nd.Tag = p;
                        Nd2.Nodes.Add(nd);
                    }
                }
            }
            Nd2.Expand();

            List<PATIO.CAPA.Classes.Action> Liste3 = (List<PATIO.CAPA.Classes.Action>)Acces.Remplir_ListeElement(Acces.type_ACTION, "");
            TreeNode Nd3 = new TreeNode("Actions");

            foreach (PATIO.CAPA.Classes.Action p in Liste3)
            {
                if (!(p.Pilote is null))
                {
                    if (p.Pilote.ID == user.ID)
                    {
                        TreeNode nd = new TreeNode(p.Libelle);
                        nd.Name = "ACT-" + p.ID;
                        nd.Tag = p;
                        Nd3.Nodes.Add(nd);
                    }
                }
            }
            Nd3.Expand();

            treePilote.Nodes.Add(Nd1);
            treePilote.Nodes.Add(Nd2);
            treePilote.Nodes.Add(Nd3);
        }

        /// <summary>
        /// Affiche les éléments dont l'utilisateur est identifié comme membre de l'équipe projet
        /// Cible : Treeview
        /// </summary>
        /// <param name="user"></param>
        public void Afficher_ObjetMembre(Utilisateur user)
        {
            treeAsso.Nodes.Clear();
            List<PATIO.CAPA.Classes.Action> Liste= (List<PATIO.CAPA.Classes.Action>)Acces.Donner_ListeActionMembre(user.ID);
            TreeNode Nd = new TreeNode("Actions");

            foreach (PATIO.CAPA.Classes.Action p in Liste)
            {
                TreeNode nd = new TreeNode(p.Libelle);
                nd.Name = "ACT-" + p.ID;
                nd.Tag = p;
                Nd.Nodes.Add(nd);
            }
            Nd.Expand();

            treeAsso.Nodes.Add(Nd);
        }

        /// <summary>
        /// Affiche les éléments favoris ajoutés par l'utilisateur
        /// Cible : Treeview
        /// </summary>
        /// <param name="user"></param>
        public void Afficher_ObjetFavori(Utilisateur user)
        {
            treeFavori.Nodes.Clear();
            List<PATIO.CAPA.Classes.Action> Liste = (List<PATIO.CAPA.Classes.Action>)Acces.Remplir_ListeElement(Acces.type_ACTION,"");
            TreeNode Nd = new TreeNode("Actions");

            foreach (PATIO.CAPA.Classes.Action p in Liste)
            {
                TreeNode nd = new TreeNode(p.Libelle);
                nd.Name = "ACT-" + p.ID;
                nd.Tag = p;
                Nd.Nodes.Add(nd);
            }
            Nd.Expand();

            treeFavori.Nodes.Add(Nd);
        }

        /// <summary>
        /// Actualise les listes du composant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            Initialiser();
        }

        /// <summary>
        /// Procédure d'entrée d'ouverture d'un élément
        /// </summary>
        void Ouvrir()
        {
            if(treePilote.SelectedNode is null ) { return; }
            string Code = treePilote.SelectedNode.Name;
            
            if(Code.Split('-')[0] == Acces.type_PLAN.Code)
            {
                int ID = int.Parse(Code.Split('-')[1]);
                Ouvrir_Plan(ID);
            }
            if (Code.Split('-')[0] == Acces.type_OBJECTIF.Code)
            {
                int ID = int.Parse(Code.Split('-')[1]);
                Ouvrir_Objectif(ID);
            }
            if (Code.Split('-')[0] == Acces.type_ACTION.Code)
            {
                int ID = int.Parse(Code.Split('-')[1]);
                Ouvrir_Action(ID);
            }
        }

        /// <summary>
        /// Procédure d'ouverture d'un élément de type Plan
        /// </summary>
        /// <param name="ID"></param>
        void Ouvrir_Plan(int ID)
        {
            Plan plan = (Plan)Acces.Trouver_Element(Acces.type_PLAN, ID);

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Plan " + plan.Code;
            //MessageBox.Show(int.Parse(lstPlan.SelectedNode.Name).ToString());

            var ctrl = new ctrlPlan();
            ctrl.Acces = Acces;
            ctrl.plan = plan;
            ctrl.DP = DP;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Afficher();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        /// <summary>
        /// Procédure d'ouverture d'un élément de type Objectif
        /// </summary>
        /// <param name="ID"></param>
        void Ouvrir_Objectif(int ID)
        {
            Objectif objectif = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, ID);

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Objectif " + objectif.Code;

            var ctrl = new ctrlFicheObjectif();
            ctrl.Acces = Acces;
            ctrl.objectif = objectif;
            ctrl.Initialiser();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        /// <summary>
        /// Procédure d'ouverture d'un élément de type Action
        /// </summary>
        /// <param name="ID"></param>
        void Ouvrir_Action(int ID)
        {
            PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, ID);

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Action " + action.Code;

            ctrlFicheAction ctrl = new ctrlFicheAction();
            ctrl.Acces = Acces;
            ctrl.action = action;
            ctrl.Initialiser();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        /// <summary>
        /// Evénement du bouton pour l'ouverture d'un élément en tant que pilote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOuvrirMembre_Click(object sender, EventArgs e)
        {
            Ouvrir();
        }

        /// <summary>
        /// Evénement du bouton pour l'ouverture d'un élément en tant que membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOuvrirPilotage_Click(object sender, EventArgs e)
        {
            if(treeAsso.SelectedNode is null) { return; }
            Ouvrir_Action(int.Parse(treeAsso.SelectedNode.Name.Split('-')[1]));
        }

        /// <summary>
        /// Affiche la liste des utilisateurs en base (pour test des profils)
        /// Cible : Combo
        /// </summary>
        void Afficher_ListeUtilisateur()
        {
            lstUtilisateur.Items.Clear();
            Chargé = false;
            Liste = (List<Utilisateur>)Acces.Remplir_ListeElement(Acces.type_UTILISATEUR, "");
            int n = -1;

            foreach(Utilisateur user in Liste)
            {
                lstUtilisateur.Items.Add(user.Nom + " " + user.Prenom);
                if(user.Code == user_appli.Code) { n = lstUtilisateur.Items.Count-1; }
            }
            Chargé = true;
            if (!(n < 0)) { lstUtilisateur.SelectedIndex = n; }
        }

        /// <summary>
        /// Evénement suite à une sélection d'un utilisateur dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUtilisateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Chargé) { return; }

            if (lstUtilisateur.SelectedIndex < 0) { return; }

            Utilisateur user = Liste[lstUtilisateur.SelectedIndex];

            user_appli = Acces.Trouver_Utilisateur(user.Code);

            Acces.user_appli = user_appli;
            Acces.Trouver_User_Admin();
            Acces.Charger_ListeDroit();

            treePilote.Nodes.Clear();
            treeAsso.Nodes.Clear();

            Afficher_ObjetPilote(user);
            Afficher_ObjetMembre(user);
            Afficher_ObjetFavori(user);
        }

        /// <summary>
        /// Evénement du bouton pour l'ouverture d'un élément favori
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOuvrirFavori_Click(object sender, EventArgs e)
        {
            if (treeFavori.SelectedNode is null) { return; }
            Ouvrir_Favori(int.Parse(treeFavori.SelectedNode.Name.Split('-')[1]));
        }

        /// <summary>
        /// Procédure d'ouverture d'un élément favori
        /// </summary>
        /// <param name="ID"></param>
        void Ouvrir_Favori(int ID)
        {
            PATIO.CAPA.Classes.Action action = (PATIO.CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, ID);

            var D = new WeifenLuo.WinFormsUI.Docking.DockContent();
            D.TabText = "Action " + action.Code;
            D.Tag = "ACTION_GESTION";

            ctrlGestionAction ctrl = new ctrlGestionAction();
            ctrl.Acces = Acces;
            ctrl.action = action;
            ctrl.Console = Console;
            ctrl.Initialiser();

            ctrl.Dock = DockStyle.Fill;
            D.Controls.Add(ctrl);

            D.Show(DP, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        /// <summary>
        /// Evénement par double clic sur le treeview des éléments favoris -> Ouverture de l'élément
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeFavori_DoubleClick(object sender, EventArgs e)
        {
            if (treeFavori.SelectedNode is null) { return; }
            Ouvrir_Favori(int.Parse(treeFavori.SelectedNode.Name.Split('-')[1]));
        }

        /// <summary>
        /// Evénement par sélection d'un espace d'affichage dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstEspace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEspace.SelectedIndex < 0) { return; }
            tabControl.SelectedIndex = lstEspace.SelectedIndex;
        }
    }
}
