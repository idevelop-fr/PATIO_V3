using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PATIO.CAPA.Interfaces;
using PATIO.OMEGA.Interfaces;
using PATIO.CAPA.Classes;
using PATIO.OMEGA.Classes;
using System.Threading;
using PATIO.MAIN.Classes;
using PATIO.ADMIN;
using System.Collections.Generic;
using PATIO.ADMIN.Classes;

namespace PATIO
{
    public partial class frmMain : Form
    {
        public AccesNet Acces;
        public string Chemin = Properties.Settings.Default.Chemin_Temp;

        public ctrlConsole Console;
        public Utilisateur user_appli = new Utilisateur();

        int Nb_Minutes=0;

        public frmMain()
        {
            InitializeComponent();
            Initialiser();
        }

        void Initialiser()
        {
            //Vérification environnement local
            if (!(System.IO.Directory.Exists(Chemin))) { System.IO.Directory.CreateDirectory(Chemin); }
            if (!(System.IO.Directory.Exists(Chemin + "\\Fichiers"))) { System.IO.Directory.CreateDirectory(Chemin + "\\Fichiers"); }
            if (!(System.IO.Directory.Exists(Chemin + "\\Export"))) { System.IO.Directory.CreateDirectory(Chemin + "\\Export"); }
            
            //Supprimer le fichier de traçage des requêtes
            if (System.IO.File.Exists(Chemin + "\\log.txt")) { System.IO.File.Delete(Chemin + "\\log.txt"); }
            
            //Supprimer les fichiers d'édition
            foreach(string f in System.IO.Directory.GetFiles(Chemin + "\\Fichiers","F*.*"))
            {
                try { System.IO.File.Delete(f); } catch { }
            }

            //Création de la console permetant de suivre les opérations
            Afficher_Console();
            Console.Ajouter("Démarrage du chargement...");
            DateTime d1 = DateTime.Now;

            //Initialisation des fonctionnalités
            if (!Initialiser_Connexion()) { return; /*Fin dû à un pb de connexion*/ }

            Afficher_Menu();
            Acces.clsMAIN.Afficher_Accueil();
            lblNom.Text = user_appli.NomPrenom;
            lblCodeUser.Text = user_appli.Code;
            //Afficher_GestionObjet();

            //Affichage du temps de chargement
            DateTime d2 = DateTime.Now;
            Console.Ajouter("Temps de chargement : " + (d2 - d1).Milliseconds + " ms");
            timer_Connexion.Start();

            //Sauvegarde automatique
            //timer2.Start();
            //Acces.Sauvegarde_local();

            //Ouverture des éléments par commande externe
            timer_Ouverture.Start();

            Agrandir();
        }

        void Afficher_Menu()
        {
            treeAdmin.Nodes.Clear();
            treeFonction.Nodes.Clear();

            Afficher_MenuFonction("CAPA");
            Afficher_MenuFonction("OMEGA");
            Afficher_MenuAdministration();
        }

        void Afficher_MenuFonction(string Fonction)
        {
            int n = 0;
            if (Fonction == "CAPA")
            {
                TreeNode Nd_CAPA = new TreeNode("CAPA");
                Nd_CAPA.Name = "CAPA";
                Nd_CAPA.ImageIndex = n++;

                //Partie gestion de CAPA
                TreeNode Nd_Gestion = new TreeNode("Gestion");
                Nd_Gestion.Name = "CAPA_GESTION";
                Nd_Gestion.ImageIndex = n++;
                AjouterNoeud(Nd_Gestion, "Plans d'actions", "CAPA_GESTION_PLAN", n++);
                AjouterNoeud(Nd_Gestion, "Objectifs", "CAPA_GESTION_OBJECTIF", n++);
                AjouterNoeud(Nd_Gestion, "Actions", "CAPA_GESTION_ACTION", n++);
                AjouterNoeud(Nd_Gestion, "Indicateurs", "CAPA_GESTION_INDICATEUR", n++);
                AjouterNoeud(Nd_Gestion, "Processus", "CAPA_GESTION_PROCESSUS", n++);
                Nd_Gestion.Expand();
                Nd_CAPA.Nodes.Add(Nd_Gestion);

                //Partie édition de CAPA
                TreeNode Nd_Edition = new TreeNode("Editions");
                Nd_Edition.Name = "CAPA_EDITION";
                Nd_Edition.ImageIndex = n++;
                AjouterNoeud(Nd_Edition, "Par plan", "CAPA_EDITION_PLAN", n++);
                AjouterNoeud(Nd_Edition, "Par direction", "CAPA_EDITION_DIRECTION", n++);
                AjouterNoeud(Nd_Edition, "Par territoire", "CAPA_EDITION_TERRITOIRE", n++);
                AjouterNoeud(Nd_Edition, "Statistiques", "CAPA_EDITION_STAT", n++);
                Nd_Edition.Expand();
                Nd_CAPA.Nodes.Add(Nd_Edition);
                Nd_CAPA.Expand();
                treeFonction.Nodes.Add(Nd_CAPA);
            }

            if(Fonction=="OMEGA")
            {
                TreeNode Nd_OMEGA = new TreeNode("OMEGA");
                Nd_OMEGA.Name = "OMEGA";
                Nd_OMEGA.ImageIndex = n++;

                //Partie BUDGET
                TreeNode Nd_Gestion = new TreeNode("Budgets");
                Nd_Gestion.Name = "OMEGA_BUDGET";
                Nd_Gestion.ImageIndex = n++;
                AjouterNoeud(Nd_Gestion, "Périodes budgétaires", "OMEGA_BUDGET_PERIODE", n++);
                AjouterNoeud(Nd_Gestion, "Enveloppes budgétaires", "OMEGA_BUDGET_ENVELOPPE", n++);
                AjouterNoeud(Nd_Gestion, "Nomenclatures budgétaires", "OMEGA_BUDGET_NOMENCLATURE", n++);
                AjouterNoeud(Nd_Gestion, "Budgets", "OMEGA_BUDGET_BUDGET", n++);
                AjouterNoeud(Nd_Gestion, "Opérations budgétaires", "OMEGA_BUDGET_OPERATION", n++);
                AjouterNoeud(Nd_Gestion, "Virements", "OMEGA_BUDGET_VIREMENT", n++);
                Nd_Gestion.Expand();
                Nd_OMEGA.Nodes.Add(Nd_Gestion);

                //Partie EXECUTION
                TreeNode Nd_Execution = new TreeNode("Exécution FIR");
                Nd_Execution.Name = "OMEGA_EXECUTION_FIR";
                Nd_Execution.ImageIndex = n++;
                AjouterNoeud(Nd_Execution, "Associations", "OMEGA_EXECUTION_FIR_ASSOCIATION", n++);
                AjouterNoeud(Nd_Execution, "Fiches d'expression de besoins", "OMEGA_EXECUTION_FIR_FEB", n++);
                AjouterNoeud(Nd_Execution, "Engagements juridiques", "OMEGA_EXECUTION_FIR_EJ", n++);
                AjouterNoeud(Nd_Execution, "Echéances", "OMEGA_EXECUTION_FIR_ECHEANCE", n++);
                AjouterNoeud(Nd_Execution, "Liquidation", "OMEGA_EXECUTION_FIR_LIQUIDATION", n++);
                AjouterNoeud(Nd_Execution, "Ordre de paiement", "OMEGA_EXECUTION_FIR_OP", n++);
                Nd_Execution.Expand();
                Nd_OMEGA.Nodes.Add(Nd_Execution);

                //Partie Cloture/Préparation
                TreeNode Nd_Prepa = new TreeNode("Préparation/clôture");
                Nd_Prepa.Name = "OMEGA_PREPA";
                Nd_Prepa.ImageIndex = n++;
                AjouterNoeud(Nd_Prepa, "Préparation budgétaire N+1", "OMEGA_PREPA_PREPARATION", n++);
                AjouterNoeud(Nd_Prepa, "Clôture budgétaire N", "OMEGA_PREPA_CLOTURE", n++);
                Nd_Prepa.Expand();
                Nd_OMEGA.Nodes.Add(Nd_Prepa);
                Nd_OMEGA.Expand();
                treeFonction.Nodes.Add(Nd_OMEGA);
            }
        }

        void Afficher_MenuAdministration()
        {
            int n = 0;

            TreeNode Nd_Admin = new TreeNode("Administration");
            Nd_Admin.Name = "ADMIN";
            Nd_Admin.ImageIndex = n++;

            //Partie Gestion des utilisateurs
            TreeNode Nd_Gestion = new TreeNode("Gestion");
            Nd_Gestion.Name = "ADMIN_GESTION";
            Nd_Gestion.ImageIndex = n++;
            AjouterNoeud(Nd_Gestion, "Utilisateurs", "ADMIN_GESTION_UTILISATEUR", n++);
            Nd_Gestion.Expand();
            Nd_Admin.Nodes.Add(Nd_Gestion);

            //Partie Gestion des paramètres
            TreeNode Nd_Parametre = new TreeNode("Paramètres");
            Nd_Parametre.Name = "ADMIN_PARAM";
            Nd_Parametre.ImageIndex = n++;
            AjouterNoeud(Nd_Parametre, "Attributs", "ADMIN_PARAM_ATTRIBUT", n++);
            AjouterNoeud(Nd_Parametre, "Tables de valeurs", "ADMIN_PARAM_TABLE_VALEUR", n++);
            AjouterNoeud(Nd_Parametre, "Paramètres de l'application", "ADMIN_PARAM_PARAMETRE", n++);
            Nd_Parametre.Expand();
            Nd_Admin.Nodes.Add(Nd_Parametre);

            //Partie Import/Export
            TreeNode Nd_Flux = new TreeNode("Flux");
            Nd_Flux.Name = "ADMIN_FLUX";
            Nd_Flux.ImageIndex = n++;
            AjouterNoeud(Nd_Flux, "Importation", "ADMIN_FLUX_IMPORTATION", n++);
            AjouterNoeud(Nd_Flux, "Exportation", "ADMIN_FLUX_EXPORTATION", n++);
            AjouterNoeud(Nd_Flux, "XWiki", "ADMIN_FLUX_XWIKI", n++);
            Nd_Flux.Expand();
            Nd_Admin.Nodes.Add(Nd_Flux);

            //Partie Base de données
            TreeNode Nd_BDD = new TreeNode("Base de données");
            Nd_BDD.Name = "ADMIN_BDD";
            Nd_BDD.ImageIndex = n++;
            Nd_BDD.Expand();
            Nd_Admin.Nodes.Add(Nd_BDD);

            //Partie Base de données
            TreeNode Nd_ModeleDoc = new TreeNode("Modèles de documents");
            Nd_ModeleDoc.Name = "ADMIN_MODELEDOC";
            Nd_ModeleDoc.ImageIndex = n++;
            Nd_ModeleDoc.Expand();
            Nd_Admin.Nodes.Add(Nd_ModeleDoc);

            //Partie Archivage
            TreeNode Nd_Archive = new TreeNode("Archivage");
            Nd_Archive.Name = "ADMIN_ARCHIVAGE";
            Nd_Archive.ImageIndex = n++;
            Nd_Archive.Expand();
            Nd_Admin.Nodes.Add(Nd_Archive);

            Nd_Admin.Expand();
            treeAdmin.Nodes.Add(Nd_Admin);
            Expander_Administration.IsExpanded = false;
        }

        TreeNode AjouterNoeud(TreeNode Nd, string Titre, string Name, int idImage)
        {
            TreeNode Nd_Ajout = new TreeNode(Titre);
            Nd_Ajout.Name = Name;
            Nd_Ajout.ImageIndex = idImage;
            Nd.Nodes.Add(Nd_Ajout);
            return Nd;
        }

        void Afficher_Console()
        {
            DockContent D1 = new DockContent();

            Console = new ctrlConsole();
            Console.Dock = DockStyle.Fill;
            Console.Chemin = Chemin;

            D1.Controls.Add(Console);

            D1.Text = "Console";
            D1.Tag = "CONSOLE";
            D1.ShowInTaskbar = false;
            D1.CloseButton = false;
            D1.Show(DP, DockState.DockLeftAutoHide);
        }

        Boolean Initialiser_Connexion()
        {
            //Initialise la connexion
            Acces = new AccesNet();
            Acces.CheminTemp = Chemin;
            Acces.Console = Console;
            Acces.Main = this;
            Acces.DP = DP;
            if (!Acces.Initialiser()) { return false; }

            //Vérificaton de la validité de la connexion
            if (!Acces.cls.Verifie()) { MessageBox.Show("Problème avec les paramètres de connexion"); }

            //Identifiant de l'utilisateur
            Identifier_Utilisateur();

            Acces.user_appli = user_appli;
            Acces.Trouver_User_Admin();
            Console.Ajouter("Administrateur : " + (Acces.user_admin?"OUI":"NON"));

            Acces.Charger_ListeDroit();

            Application.DoEvents();
            return true;
        }

        void Identifier_Utilisateur()
        {
            System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
            Thread.CurrentPrincipal = new System.Security.Principal.WindowsPrincipal(wi);
            user_appli.Code = wi.Name;
            Console.Ajouter("Identifiant initial : " + user_appli.Code);
            user_appli.Code=user_appli.Code.Replace("SD\\","");
            if (user_appli.Code.Contains("DESKTOP")) { user_appli.Code = "dofernagut"; } //Cas Local
            if (user_appli.Code.Contains("DOMINIQUE")) { user_appli.Code = "dofernagut"; } //Cas Mac
            Console.Ajouter("Identifiant retenu : " + user_appli.Code);

            //Recherche de l'identifiant dans la base
            if ( Acces.Existe_Element(Acces.type_UTILISATEUR,"CODE", user_appli.Code))
            {
                user_appli = Acces.Trouver_Utilisateur(user_appli.Code);
                Console.Ajouter("Identifiant Id : " + user_appli.ID.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Acces.cls.Verifie()) { Console.Ajouter("Pb connexion"); }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Nb_Minutes++;
            //if(Nb_Minutes>=5) { Acces.Sauvegarder_local(); Nb_Minutes = 0; }
        }
 
        private void timer_Ouverture_Tick(object sender, EventArgs e)
        {
            Ouvrir_Element_Appel_Externe();
        }

        void Ouvrir_Element_Appel_Externe()
        {
            foreach (string f in System.IO.Directory.GetFiles(Chemin + "\\Fichiers", "EXT_*.*"))
            {
                try {
                    string cmd = System.IO.File.ReadAllText(f);
                    string element = cmd.Split(':')[0].ToUpper().Trim();
                    string id = cmd.Split(':')[1];

                    switch(element)
                    {
                        case "PLAN":
                            {
                                CAPA.Interfaces.ctrlListePlan ctrl = new ctrlListePlan();
                                ctrl.Acces = Acces;
                                ctrl.DP = DP;
                                ctrl.Chemin = Chemin;
                                ctrl.Console = Console;
                                ctrl.plan = (Plan)Acces.Trouver_Element(Acces.type_PLAN, int.Parse(id));
                                ctrl.Ouvrir_Plan();
                                break;
                            }

                        case "OBJECTIF":
                            {
                                CAPA.Interfaces.ctrlListeObjectif ctrl = new ctrlListeObjectif();
                                ctrl.Acces = Acces;
                                ctrl.DP = DP;
                                ctrl.Chemin = Chemin;
                                ctrl.Console = Console;
                                ctrl.obj = (Objectif)Acces.Trouver_Element(Acces.type_OBJECTIF, int.Parse(id));
                                ctrl.Modifier_Objectif();
                                break;
                            }

                        case "ACTION":
                            {
                                CAPA.Interfaces.ctrlListeAction ctrl = new ctrlListeAction();
                                ctrl.Acces = Acces;
                                ctrl.DP = DP;
                                ctrl.Chemin = Chemin;
                                ctrl.Console = Console;
                                ctrl.action = (CAPA.Classes.Action)Acces.Trouver_Element(Acces.type_ACTION, int.Parse(id));
                                ctrl.Modifier_Action();
                                break;
                            }

                        /*case "INDICATEUR":
                            {
                                CAPA.Interfaces.ctrlListeIndicateur ctrl = new ctrlListeIndicateur();
                                ctrl.Acces = Acces;
                                ctrl.DP = DP;
                                ctrl.Chemin = Chemin;
                                ctrl.Console = Console;
                                ctrl.indicateur = (Indicateur)Acces.Trouver_Element(Acces.type_INDICATEUR, int.Parse(id));
                                ctrl.Ouvrir_Indicateur();
                                break;
                            }*/
                    }
                    //Suppression du fichier de commande externe
                    System.IO.File.Delete(f);
                } catch { }
            }
        }

        void Recharger()
        {
            Acces.Charger_Element();
            Acces.Charger_Lien();
        }
 
        private void treeAdmin_DoubleClick(object sender, EventArgs e)
        {
            Ajouter_Admin();
        }

        private void treeFonction_DoubleClick(object sender, EventArgs e)
        {
            Ajouter_Fonction();
        }

        void Ajouter_Admin()
        {
            if(treeAdmin.SelectedNode == null) { return; }

            treeAdmin.SelectedNode.Expand();

            string item = treeAdmin.SelectedNode.Name;
            Console.Ajouter("#LANCEMENT Admin " + item);

            if (item == "ADMIN_GESTION_UTILISATEUR") { Acces.clsADMIN.Afficher_Admin_User(); }

            if (item == "ADMIN_PARAM_ATTRIBUT") { Acces.clsADMIN.Afficher_Admin_Attribut(); }
            if (item == "ADMIN_PARAM_TABLE_VALEUR") { Acces.clsADMIN.Afficher_Admin_TableValeur(); }
            if (item == "ADMIN_PARAM_PARAMETRE") { Acces.clsADMIN.Afficher_Admin_Parametre(); }

            if (item == "ADMIN_FLUX_IMPORTATION") { Acces.clsADMIN.Afficher_Admin_Importation(); }
            if (item == "ADMIN_FLUX_EXPORTATION") { Acces.clsADMIN.Afficher_Admin_Exportation(); }
            if (item == "ADMIN_FLUX_XWIKI") { Acces.clsMAIN.Afficher_XWiki_Technique(); }

            if (item == "ADMIN_BDD") { Acces.clsADMIN.Afficher_Admin_BDD(); }

            if (item == "ADMIN_MODELEDOC") { Acces.clsADMIN.Afficher_Admin_ModeleDoc(); }
        }

        void Ajouter_Fonction()
        {
            if (treeFonction.SelectedNode == null) { return; }

            treeFonction.SelectedNode.Expand();

            string item = treeFonction.SelectedNode.Name;
            Console.Ajouter("#LANCEMENT Fonction " + item);

            //CAPA Gestion
            if (item == "CAPA_GESTION_PLAN") { Acces.clsCAPA.Afficher_GestionPlan(); }
            if (item == "CAPA_GESTION_OBJECTIF") { Acces.clsCAPA.Afficher_GestionObjectif(); }
            if (item == "CAPA_GESTION_ACTION") { Acces.clsCAPA.Afficher_GestionAction(); }
            if (item == "CAPA_GESTION_INDICATEUR") { Acces.clsCAPA.Afficher_GestionIndicateur(); }
            if (item == "CAPA_GESTION_PROCESSUS") { Acces.clsCAPA.Afficher_GestionProcessus(); }
            //CAPA Editions
            if (item == "CAPA_EDITION_PLAN") { Acces.clsCAPA.Afficher_EditionPlan(); }
            if (item == "CAPA_EDITION_DIRECTION") { Acces.clsCAPA.Afficher_EditionDirection(); }
            if (item == "CAPA_EDITION_TERRITOIRE") { Acces.clsCAPA.Afficher_EditionTerritoire(); }
            if (item == "CAPA_EDITION_STAT") { Acces.clsCAPA.Afficher_EditionStat(); }

            //OMEGA Budgets
            if (item == "OMEGA_BUDGET_PERIODE") { Acces.clsOMEGA.Afficher_BudgetPeriode(); }
            if (item == "OMEGA_BUDGET_ENVELOPPE") { Acces.clsOMEGA.Afficher_BudgetEnveloppe(); }
            if (item == "OMEGA_BUDGET_NOMENCLATURE") { Acces.clsOMEGA.Afficher_Nomenclature(); }
            if (item == "OMEGA_BUDGET_BUDGET") { Acces.clsOMEGA.Afficher_BudgetStructure("BUDGET"); }
            if (item == "OMEGA_BUDGET_OPERATION") { Acces.clsOMEGA.Afficher_BudgetStructure("OPERATION"); }
            if (item == "OMEGA_BUDGET_VIREMENT") { Acces.clsOMEGA.Afficher_BudgetStructure("VIREMENT"); }
            //OMEGA Exécution FIR
            if (item == "OMEGA_EXECUTION_FIR_ASSOCIATION") { Acces.clsOMEGA.Afficher_GestionAssociation(); }
            //if (item == "OMEGA_EXECUTION_FIR_FEB") { Acces.clsOMEGA.Afficher_GestionAssociation(); }
            //if (item == "OMEGA_EXECUTION_FIR_EJ") { Acces.clsOMEGA.Afficher_GestionAssociation(); }
            //if (item == "OMEGA_EXECUTION_FIR_ECHEANCE") { Acces.clsOMEGA.Afficher_GestionAssociation(); }
            //if (item == "OMEGA_EXECUTION_FIR_LIQUIDATION") { Acces.clsOMEGA.Afficher_GestionAssociation(); }
            //if (item == "OMEGA_EXECUTION_FIR_OP") { Acces.clsOMEGA.Afficher_GestionAssociation(); }

            //OMEGA Préparation/Clôture
            //if (item == "OMEGA_PREPA_PREPARATION") { Acces.clsOMEGA.Afficher_GestionAssociation(); }
            //if (item == "OMEGA_PREPA_CLOTURE") { Acces.clsOMEGA.Afficher_GestionAssociation(); }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            Afficher_Menu();
        }

        private void MenuXWIKI_PRS_Click(object sender, EventArgs e)
        {
            Acces.clsMAIN.Afficher_XWiki_PRS();
        }

        private void MenuXWIKI_PlanAction_Click(object sender, EventArgs e)
        {
            Acces.clsMAIN.Afficher_XWiki_Plan_Action();
        }

        private void btnRecharger_Click(object sender, EventArgs e)
        {
            Recharger();
        }

        void Agrandir()
        {
            btnAgrandir.Visible = false;
            panelMenu.Visible = true;

            panelMenu.Width = 260;
        }

        void Réduire()
        {
            btnAgrandir.Visible= true;
            panelMenu.Visible = false;
        }

        private void btnAgrandir_Click(object sender, EventArgs e)
        {
            Agrandir();
        }

        private void btnReduire_Click(object sender, EventArgs e)
        {
            Réduire();
        }
    }
}
