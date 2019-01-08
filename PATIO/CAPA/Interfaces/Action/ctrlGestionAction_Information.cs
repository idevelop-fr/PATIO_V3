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
    public partial class ctrlGestionAction_Information : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public PATIO.CAPA.Classes.Action action;
        public AccesNet Acces;
        public int ID;

        public ctrlGestionAction_Information()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {

        }
    }
}
