﻿using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PATIO.CAPA.Interfaces;
using PATIO.CAPA.Classes;
using System.Threading;
using PATIO.Modules;
using PATIO.ADMIN;

namespace PATIO
{
    public partial class frmMain : Form
    {
        public AccesNet Acces;
        public string Chemin = "C:\\temp\\patio";

        public ctrlConsole Console;
        public Utilisateur user_appli = new Utilisateur();

        int Nb_Minutes=0;

        DockContent D_Gestion;

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

            Afficher_Accueil();
            Afficher_GestionObjet();

            //Affichage du temps de chargement
            DateTime d2 = DateTime.Now;
            Console.Ajouter("Temps de chargement : " + (d2 - d1).Milliseconds + " ms");
            timer1.Start();

            //Sauvegarde automatique
            timer2.Start();
            //Acces.Sauvegarde_local();

            //Affichage de la version
        }

        void Afficher_Console()
        {
            DockContent D1 = new DockContent();

            Console = new ctrlConsole();
            Console.Dock = DockStyle.Fill;
            Console.Chemin = Chemin;

            D1.Controls.Add(Console);

            D1.Show(DP, DockState.DockLeftAutoHide);
            D1.Text = "Console";
            D1.ShowInTaskbar = false;
            D1.CloseButton = false;
        }

        Boolean Initialiser_Connexion()
        {
            //Initialise la connexion
            Acces = new AccesNet();
            Acces.Chemin = Chemin;
            Acces.Console = Console;
            if (!Acces.Initialiser()) { return false; }

            //Vérificaton de la validité de la connexion
            if (!Acces.cls.Verifie()) { MessageBox.Show("Problème avec les paramètres de connexion"); }

            //Identifiant de l'utilisateur
            Identifier_Utilisateur();

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
            if (user_appli.Code.Contains("MSI")) { user_appli.Code = "dfernagut"; }
            Console.Ajouter("Identifiant retenu : " + user_appli.Code);

            //Recherche de l'identifiant dans la base
            if ( Acces.Existe_Element(Acces.type_UTILISATEUR,"CODE", user_appli.Code))
            {
                user_appli = Acces.Trouver_Utilisateur(user_appli.Code);
                Console.Ajouter("Identifiant Id : " + user_appli.ID.ToString());
            }
        }

        void Afficher_Accueil()
        {
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.user_appli = user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialise();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Accueil";
            D1.ShowInTaskbar = false;
            D1.CloseButton = false;

        }

        void Afficher_XWiki_Plan_Action()
        {
            DockContent D1 = new DockContent();

            PATIO.CAPA.Interfaces.ctrlWeb ctrl = new PATIO.CAPA.Interfaces.ctrlWeb();
            ctrl.url = "https://ars-hdf.xwiki.com/xwiki/wiki/plansactions/view/Liste/";
            ctrl.Initialise();
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "XWiki Plan actions";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;

        }

        void Afficher_XWiki_Technique()
        {
            DockContent D1 = new DockContent();

            PATIO.CAPA.Interfaces.ctrlWeb ctrl = new PATIO.CAPA.Interfaces.ctrlWeb();
            ctrl.url = "https://ars-hdf.xwiki.com/xwiki/wiki/projetssi/6PO/";
            ctrl.Initialise();
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "XWiki Technique";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;

        }

        void Afficher_PRS()
        {
            DockContent D1 = new DockContent();

            PATIO.CAPA.Interfaces.ctrlWeb ctrl = new PATIO.CAPA.Interfaces.ctrlWeb();
            ctrl.url = "https://ars-hdf.xwiki.com/xwiki/bin/view/Main/";
            ctrl.Initialise();
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "PRS";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;

        }

        void Afficher_GestionObjet()
        {
            D_Gestion = new DockContent();

            GestionPlan  ctrl = new GestionPlan();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Chemin = Chemin;
            ctrl.Console = Console;

            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialise();
            D_Gestion.Controls.Add(ctrl);

            D_Gestion.Show(DP, DockState.DockLeft);
            D_Gestion.Text = "Objets de gestion";
            D_Gestion.ShowInTaskbar = false;
            D_Gestion.CloseButton = false;
        }

        void Afficher_Admin_User()
        { 
            DockContent D1 = new DockContent();

            ctrlListeUtilisateur ctrl = new ctrlListeUtilisateur();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeUser();

            D1.Show(DP, DockState.Document);
            D1.Text = "Utilisateurs";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        private void btnRecharger_Click(object sender, EventArgs e)
        {
            Acces.Charger_Element();
            Acces.Charger_Lien();
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

        private void MenuXWikiPRS_Click(object sender, EventArgs e)
        {
            Afficher_PRS();
        }

        private void MenuXWikiTechnique_Click(object sender, EventArgs e)
        {
            Afficher_XWiki_Technique();
        }

        private void MenuXWikiCAPA_Click(object sender, EventArgs e)
        {
            Afficher_XWiki_Plan_Action();
        }

        void ReduireGestionObjet()
        {
            D_Gestion.Hide();
        }

        private void btnPATIO_Site_PlanAction_Click(object sender, EventArgs e)
        {
            Afficher_XWiki_Plan_Action();
        }

        private void btnPATIO_Site_PRS_Click(object sender, EventArgs e)
        {
            Afficher_PRS();
        }

        private void btnCAPA_Edition_Plan_Click(object sender, EventArgs e)
        {
            Afficher_EditionPlan();
        }

        void Afficher_EditionPlan()
        {
            DockContent D1 = new DockContent();

            ctrlEditionPlan ctrl = new ctrlEditionPlan();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Edition par plan";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        void Afficher_EditionDirection()
        {
            DockContent D1 = new DockContent();

            ctrlEditionDirection ctrl = new ctrlEditionDirection();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Edition par direction";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        void Afficher_EditionTerritoire()
        {
            DockContent D1 = new DockContent();

            ctrlEditionTerritoire ctrl = new ctrlEditionTerritoire();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Edition par territoire";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        void Afficher_EditionStat()
        {
            DockContent D1 = new DockContent();

            ctrlEditionStat ctrl = new ctrlEditionStat();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(DP, DockState.Document);
            D1.Text = "Edition des statistiques";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        private void btnCAPA_Edition_Direction_Click(object sender, EventArgs e)
        {
            Afficher_EditionDirection();
        }

        private void btnCAPA_Edition_Territoire_Click(object sender, EventArgs e)
        {
            Afficher_EditionTerritoire();
        }

        private void btnCAPA_Edition_Stat_Click(object sender, EventArgs e)
        {
            Afficher_EditionStat();
        }
    }
}
