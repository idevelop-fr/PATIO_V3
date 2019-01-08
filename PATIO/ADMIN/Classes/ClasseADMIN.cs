using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PATIO.MAIN.Classes;
using PATIO.ADMIN.Interfaces;

namespace PATIO.ADMIN.Classes
{
    public class ClasseADMIN
    {
        public AccesNet Acces;
        public ctrlConsole Console;

        public void Afficher_Executer_SQL()
        {
            DockContent D1 = new DockContent();

            ctrlAdmin_DataBase ctrl = new ctrlAdmin_DataBase();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Console = Console;
            ctrl.Dock = DockStyle.Fill;
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Exécuter SQL";
            D1.Tag = "EXECUTER_SQL";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Admin_User()
        {
            DockContent D1 = new DockContent();

            ctrlListeUtilisateur ctrl = new ctrlListeUtilisateur();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeUser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Utilisateurs";
            D1.Tag = "ADMIN_UTILISATEUR";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Admin_Attribut()
        {
            DockContent D1 = new DockContent();

            ctrlAdmin_Attribut ctrl = new ctrlAdmin_Attribut();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Attributs";
            D1.Tag = "ATTRIBUTS";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Admin_TableValeur()
        {
            DockContent D1 = new DockContent();

            ctrlAdmin_TableValeur ctrl = new ctrlAdmin_TableValeur();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Tables de valeurs";
            D1.Tag = "TABLE_DE_VALEURS";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Admin_Parametre()
        {
            DockContent D1 = new DockContent();

            ctrlAdmin_Parametre ctrl = new ctrlAdmin_Parametre();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Paramètres";
            D1.Tag = "PARAMETRES";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Admin_Importation()
        {
            DockContent D1 = new DockContent();

            ctrlImport ctrl = new ctrlImport();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            //ctrl.Console = Console;
            //ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Importation";
            D1.Tag = "IMPORTATION";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Admin_Exportation()
        {
            DockContent D1 = new DockContent();

            ctrlExport ctrl = new ctrlExport();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            //ctrl.Console = Console;
            //ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Exportation";
            D1.Tag = "EXPORTATION";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Admin_BDD()
        {
            DockContent D1 = new DockContent();

            ctrlAdmin_DataBase ctrl = new ctrlAdmin_DataBase();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            //ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Base de données";
            D1.Tag = "DATABASE";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

        public void Afficher_Admin_ModeleDoc()
        {
            DockContent D1 = new DockContent();

            ctrlGestionModele ctrl = new ctrlGestionModele();
            ctrl.Acces = Acces;
            ctrl.DP = Acces.DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Console = Console;
            ctrl.Initialiser();
            D1.Controls.Add(ctrl);

            D1.Show(Acces.DP, DockState.Document);
            D1.Text = "Modèles de documents";
            D1.Tag = "MODELEDOC";
            D1.ShowInTaskbar = false;
            D1.CloseButton = true;
        }

    }
}
