using System;
using PATIO.CAPA.Classes;
using System.Windows.Forms;

namespace PATIO.Modules
{
    public partial class ctrlConsole : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public string Chemin;

        public ctrlConsole Console;

        public ctrlConsole()
        {
            InitializeComponent();
        }

        public void Afficher()
        {
            lst.Items.Clear();
        }

        public void Ajouter(string texte)
        {
            lst.Items.Add(texte);
            lst.SelectedIndex = lst.Items.Count - 1;
            System.IO.File.AppendAllText(Chemin + "\\log.txt", "[->] " + texte + "\n");

        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            lst.Items.Clear();
        }
    }
}
