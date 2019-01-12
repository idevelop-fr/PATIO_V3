using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.ADMIN;
using WeifenLuo.WinFormsUI.Docking;

namespace PATIO.MAIN.Classes
{
    public class ClasseMAIN
    {
        public AccesNet Acces;
        public ctrlConsole Console;

        public void Afficher_Accueil()
        {
            string Tag = "ACCUEIL";
            //Recherche s'il est affiché
            foreach (DockContent d in Acces.DP.Documents)
            {
                if (d.Tag.ToString() == Tag) { d.Show(); return; }
            }
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.user_appli = Acces.user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Accueil";
            D1.Tag = "ACCUEIL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;

        }

        public void Afficher_Accueil_Favori()
        {
            string Tag = "ACCUEIL_FAVORI";
            //Recherche s'il est affiché
            foreach (DockContent d in Acces.DP.Documents)
            {
                if (d.Tag.ToString() == Tag) { d.Show(); return; }
            }
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.user_appli = Acces.user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Accueil";
            D1.Tag = "ACCUEIL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Accueil_CAPA()
        {
            string Tag = "ACCUEIL_FAVORI";
            //Recherche s'il est affiché
            foreach (DockContent d in Acces.DP.Documents)
            {
                if (d.Tag.ToString() == Tag) { d.Show(); return; }
            }
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.user_appli = Acces.user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Accueil";
            D1.Tag = "ACCUEIL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Accueil_OMEGA()
        {
            string Tag = "ACCUEIL_FAVORI";
            //Recherche s'il est affiché
            foreach (DockContent d in Acces.DP.Documents)
            {
                if (d.Tag.ToString() == Tag) { d.Show(); return; }
            }
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.user_appli = Acces.user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Accueil";
            D1.Tag = "ACCUEIL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Accueil_Compte_Info()
        {
            string Tag = "ACCUEIL_FAVORI";
            //Recherche s'il est affiché
            foreach (DockContent d in Acces.DP.Documents)
            {
                if (d.Tag.ToString() == Tag) { d.Show(); return; }
            }
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.user_appli = Acces.user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Accueil";
            D1.Tag = "ACCUEIL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Accueil_Compte_Pref()
        {
            string Tag = "ACCUEIL_FAVORI";
            //Recherche s'il est affiché
            foreach (DockContent d in Acces.DP.Documents)
            {
                if (d.Tag.ToString() == Tag) { d.Show(); return; }
            }
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.user_appli = Acces.user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Accueil";
            D1.Tag = "ACCUEIL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Accueil_Compte_Droit()
        {
            string Tag = "ACCUEIL_FAVORI";
            //Recherche s'il est affiché
            foreach (DockContent d in Acces.DP.Documents)
            {
                if (d.Tag.ToString() == Tag) { d.Show(); return; }
            }
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.user_appli = Acces.user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Accueil";
            D1.Tag = "ACCUEIL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Accueil_CAPA_Pilotage()
        {
            string Tag = "ACCUEIL_CAPA_PILOTAGE";
            //Recherche s'il est affiché
            foreach (DockContent d in Acces.DP.Documents)
            {
                if (d.Tag.ToString() == Tag) { d.Show(); return; }
            }
            DockContent D1 = new DockContent();

            ctrlAccueil ctrl = new ctrlAccueil();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Acces.Console;
            ctrl.Chemin = Acces.CheminTemp;
            ctrl.user_appli = Acces.user_appli;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Accueil";
            D1.Tag = "ACCUEIL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_XWiki_Plan_Action()
        {
            DockContent D1 = new DockContent();

            PATIO.CAPA.Interfaces.ctrlWeb ctrl = new PATIO.CAPA.Interfaces.ctrlWeb();
            ctrl.url = "https://ars-hdf.xwiki.com/xwiki/wiki/plansactions/view/Liste/";
            ctrl.Initialise();
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "XWiki Plan actions";
            D1.Tag = "XWIKI_PLAN_ACTION";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_XWiki_Technique()
        {
            DockContent D1 = new DockContent();

            PATIO.CAPA.Interfaces.ctrlWeb ctrl = new PATIO.CAPA.Interfaces.ctrlWeb();
            ctrl.url = "https://ars-hdf.xwiki.com/xwiki/wiki/projetssi/6PO/";
            ctrl.Initialise();
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "XWiki Technique";
            D1.Tag = "XWIKI_TECHNIQUE";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;

        }

        public void Afficher_XWiki_PRS()
        {
            DockContent D1 = new DockContent();

            PATIO.CAPA.Interfaces.ctrlWeb ctrl = new PATIO.CAPA.Interfaces.ctrlWeb();
            ctrl.url = "https://ars-hdf.xwiki.com/xwiki/bin/view/Main/";
            ctrl.Initialise();
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "PRS";
            D1.Tag = "XWIKI_PRS";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;

        }

    }
}
