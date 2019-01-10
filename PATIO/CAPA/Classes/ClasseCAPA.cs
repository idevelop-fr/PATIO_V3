using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PATIO.CAPA.Interfaces;
using PATIO.ADMIN;
using PATIO.MAIN.Classes;

namespace PATIO.MAIN.Classes
{
    public class ClasseCAPA
    {
        public AccesNet Acces;
        public ctrlConsole Console;

        public void Afficher_EditionPlan()
        {
            DockContent D1 = new DockContent();

            ctrlEditionPlan ctrl = new ctrlEditionPlan();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Edition par plan";
            D1.Tag = "EDITION_PLAN";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_EditionDirection()
        {
            DockContent D1 = new DockContent();

            ctrlEditionDirection ctrl = new ctrlEditionDirection();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Edition par direction";
            D1.Tag = "EDITION_DIRECTION";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_EditionTerritoire()
        {
            DockContent D1 = new DockContent();

            ctrlEditionTerritoire ctrl = new ctrlEditionTerritoire();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Edition par territoire";
            D1.Tag = "EDITION_TERRITOIRE";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_EditionStat()
        {
            DockContent D1 = new DockContent();

            ctrlEditionStat ctrl = new ctrlEditionStat();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Edition des statistiques";
            D1.Tag = "EDITION_STATISTIQUE";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_GestionPlan()
        {
            DockContent D_Gestion = new DockContent();

            GestionPlan ctrl = new GestionPlan();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Console = Acces.Console;

            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D_Gestion.Controls.Add(ctrl);

            D_Gestion.Show(Acces.DP, DockState.DockLeft);
            D_Gestion.Text = "Objets de gestion";
            D_Gestion.Tag = "OBJET_GESTION";
            D_Gestion.ShowInTaskbar = false;
            D_Gestion.CloseButton = true;
        }

        public void Afficher_GestionObjectif()
        {
            DockContent D_Gestion = new DockContent();

            ctrlListeObjectif ctrl = new ctrlListeObjectif();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Console = Acces.Console;

            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeObjectif();
            D_Gestion.Controls.Add(ctrl);

            D_Gestion.Show(Acces.DP, DockState.DockLeft);
            D_Gestion.Text = "Gestion des objectifs";
            D_Gestion.Tag = "GESTION_OBJECTIF";
            D_Gestion.ShowInTaskbar = false;
            D_Gestion.CloseButton = true;
        }

        public void Afficher_GestionAction()
        {
            DockContent D_Gestion = new DockContent();

            ctrlListeAction ctrl = new ctrlListeAction();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Console = Acces.Console;

            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeAction();
            D_Gestion.Controls.Add(ctrl);

            D_Gestion.Show(Acces.DP, DockState.DockLeft);
            D_Gestion.Text = "Gestion des actions";
            D_Gestion.Tag = "GESTION_ACTION";
            D_Gestion.ShowInTaskbar = false;
            D_Gestion.CloseButton = true;
        }

        public void Afficher_GestionIndicateur()
        {
            DockContent D_Gestion = new DockContent();

            ctrlListeIndicateur ctrl = new ctrlListeIndicateur();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.Console = Acces.Console;

            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeIndicateur();
            D_Gestion.Controls.Add(ctrl);

            D_Gestion.Show(Acces.DP, DockState.DockLeft);
            D_Gestion.Text = "Gestion des indicateurs";
            D_Gestion.Tag = "GESTION_INDICATEUR";
            D_Gestion.ShowInTaskbar = false;
            D_Gestion.CloseButton = true;
        }

        public void Afficher_GestionUtilisateur()
        {
            DockContent D_Gestion = new DockContent();

            ctrlListeUtilisateur ctrl = new ctrlListeUtilisateur();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            //ctrl.Chemin = Acces.CheminTemp;
            ctrl.Console = Acces.Console;

            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeUser();
            D_Gestion.Controls.Add(ctrl);

            D_Gestion.Show(Acces.DP, DockState.DockLeft);
            D_Gestion.Text = "Gestion des utilisateurs";
            D_Gestion.Tag = "GESTION_UTILISATEUR";
            D_Gestion.ShowInTaskbar = false;
            D_Gestion.CloseButton = true;
        }

        public void Afficher_GestionProcessus()
        {
            DockContent D_Processus = new DockContent();

            ctrlListeProcessus ctrl = new ctrlListeProcessus();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;

            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeProcessus();
            D_Processus.Controls.Add(ctrl);

            D_Processus.Show(Acces.DP, DockState.Document);
            D_Processus.Text = "Gestion des processus";
            D_Processus.Tag = "GESTION_PROCESSUS";
            D_Processus.ShowInTaskbar = false;
            D_Processus.CloseButton = true;
        }

        public void Afficher_GestionAction_Projet()
        {
            DockContent DkC = (DockContent)Acces.DP.ActiveContent;
            ctrlGestionAction act = (ctrlGestionAction)DkC.Controls[0];

            act.Afficher_Onglets(0);
            
        }

        public void Afficher_GestionAction_Info()
        {
            DockContent DkC = (DockContent)Acces.DP.ActiveContent;
            ctrlGestionAction act = (ctrlGestionAction)DkC.Controls[0];

            act.Afficher_Onglets(1);
        }

        public void Afficher_GestionAction_Indicateur()
        {
            DockContent DkC = (DockContent)Acces.DP.ActiveContent;
            ctrlGestionAction act = (ctrlGestionAction)DkC.Controls[0];

            act.Afficher_Onglets(2);
        }

        public void Afficher_GestionAction_Document()
        {
            DockContent DkC = (DockContent)Acces.DP.ActiveContent;
            ctrlGestionAction act = (ctrlGestionAction)DkC.Controls[0];

            act.Afficher_Onglets(3);
        }

    }
}
