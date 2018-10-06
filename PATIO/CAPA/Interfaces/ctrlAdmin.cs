using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PATIO.Modules;
using PATIO.CAPA.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlAdmin : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public ctrlAdmin()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_OngletUtilisateurs();
            Afficher_OngletExport();
            Afficher_OngletImport();
            Afficher_OngletImportXWiki();
            Afficher_OngletParametre();
            Afficher_FichierLog();
            Afficher_OngletCorrectifs();
        }

        void Afficher_OngletUtilisateurs()
        {
            tabUser.Controls.Clear();
            ctrlListeUtilisateur ctrl = new ctrlListeUtilisateur();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeUser();
            tabUser.Controls.Add(ctrl);
        }

        void Afficher_OngletExport()
        {
            tabExport.Controls.Clear();
            ctrlExport  ctrl = new ctrlExport();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialise();
            tabExport.Controls.Add(ctrl);
        }

        void Afficher_OngletImport()
        {
            tabImport.Controls.Clear();
            ctrlImport  ctrl = new ctrlImport();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Chemin = Chemin;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialise();
            tabImport.Controls.Add(ctrl);
        }

        void Afficher_OngletImportXWiki()
        {
            tabXWiki.Controls.Clear();
            ctrlXWiki ctrl = new ctrlXWiki();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Chemin = Chemin;
            ctrl.Initialise();
            tabXWiki.Controls.Add(ctrl);
        }

        void Afficher_OngletParametre()
        {
            tabParametre.Controls.Clear();
            ctrlAdminParam ctrl = new ctrlAdminParam();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Chemin = Chemin;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Initialiser();
            tabParametre.Controls.Add(ctrl);
        }

        private void btnActualiserFichierLog_Click(object sender, EventArgs e)
        {
            Afficher_FichierLog();
        }

        void Afficher_FichierLog()
        {
            try
            { string txt = System.IO.File.ReadAllText(Chemin + "\\log.txt");
                lblFichierLog.Text = txt; }
            catch { }
        }

        void Afficher_OngletCorrectifs()
        {
            tabCorrectif.Controls.Clear();
            ctrlCorrectif ctrl = new ctrlCorrectif();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Initialiser();
            tabCorrectif.Controls.Add(ctrl);
        }
    }
}
