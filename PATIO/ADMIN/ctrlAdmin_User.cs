using System;
using System.Windows.Forms;
using PATIO.Modules;

namespace PATIO.ADMIN
{
    public partial class ctrlAdmin_User : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public ctrlAdmin_User()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            ctrlListeUtilisateur ctrl = new ctrlListeUtilisateur();
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Dock = DockStyle.Fill;
            ctrl.Afficher_ListeUser();
        }
    }
}
