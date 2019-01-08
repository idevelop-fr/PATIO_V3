using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.MAIN.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlProjetProcessus : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;

        public ctrlProjetProcessus()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            ctrlProjet_01_Demarrage1.Acces = Acces;
            ctrlProjet_01_Demarrage1.Initialiser();

            ctrlProjet_02_Planification1.Acces = Acces;
            ctrlProjet_02_Planification1.Initialiser();
        }

        private void treePhase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treePhase.SelectedNode.Tag.ToString() == "DEMARRAGE") { tabControl1.SelectedIndex = 0; }
            if (treePhase.SelectedNode.Tag.ToString() == "ITERATION") { tabControl1.SelectedIndex = 1; }
            if (treePhase.SelectedNode.Tag.ToString() == "PLANIF") { tabControl1.SelectedIndex = 2; }
            if (treePhase.SelectedNode.Tag.ToString() == "EXECUTION") { tabControl1.SelectedIndex = 3; }
            if (treePhase.SelectedNode.Tag.ToString() == "SURVEILLANCE") { tabControl1.SelectedIndex = 4; }
            if (treePhase.SelectedNode.Tag.ToString() == "CLOTURE") { tabControl1.SelectedIndex = 5; }
        }
    }
}
