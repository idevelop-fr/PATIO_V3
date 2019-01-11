using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Ce formulaire permet de créer/modifier une assocition existante
/// </summary>
namespace PATIO.OMEGA.Interfaces.Association
{
    public partial class frmFicheAssociation : Form
    {
        public frmFicheAssociation()
        {
            InitializeComponent();
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
