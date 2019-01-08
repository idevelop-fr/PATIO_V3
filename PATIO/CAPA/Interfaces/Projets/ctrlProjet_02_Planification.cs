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
    public partial class ctrlProjet_02_Planification : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public List<Process> ListeProcessus;
        public ctrlConsole Console;

        public ctrlProjet_02_Planification()
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
                if (p.Code.Contains("PRO-PMBOK-02_"))
                {
                    lstProcessus.Items.Add(p.Libelle);
                }
            }
        }
    }
}
