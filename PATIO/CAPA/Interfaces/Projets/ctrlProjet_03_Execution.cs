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
    public partial class ctrlProjet_03_Execution : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public List<Process> ListeProcessus;
        public ctrlConsole Console;

        public ctrlProjet_03_Execution()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeProcessus();
        }

        void Afficher_ListeProcessus()
        {
            lstProcessus.Items.Clear();

            ListeProcessus = (List<Process>)Acces.Remplir_ListeElement(Acces.type_PROCESSUS, "");
            foreach (Process p in ListeProcessus)
            {
                if (p.Code.Contains("PRO-PMBOK-03_"))
                {
                    lstProcessus.Items.Add(p.Libelle);
                }
            }
        }
    }
}
