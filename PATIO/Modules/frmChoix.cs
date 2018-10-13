using System;
using System.Windows.Forms;

namespace PATIO.Modules
{
    public partial class frmChoix : Form
    {
        public string choix = "";
        public frmChoix()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex < 0) { MessageBox.Show("Aucun choix !"); return; }

            choix = lst.Items[lst.SelectedIndex].ToString();

            this.DialogResult = DialogResult.OK;

        }
    }
}
