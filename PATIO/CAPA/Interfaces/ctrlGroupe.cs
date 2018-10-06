using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.Modules;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlGroupe : UserControl
    {
        public AccesNet Acces;
        public TreeNode NodG;
        public string GroupeId;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public Groupe groupe;

        public ctrlGroupe()
        {
            InitializeComponent();
        }

        public void Affiche()
        {

        }
    }
}
