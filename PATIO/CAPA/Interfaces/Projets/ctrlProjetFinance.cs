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
using PATIO.CAPA.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlProjetFinance : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public ctrlConsole Console;

        public Projet projet;

        public ctrlProjetFinance()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {

        }
    }
}
