using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.Modules;

namespace PATIO.ADMIN
{
    public partial class ctrlAdmin_Parametre : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public ctrlAdmin_Parametre()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeParam();
        }

        void Afficher_ListeParam()
        {
            Acces.Charger_ListeParametre();
            DG_Param.DataSource = Acces.ListeParametre;
            DG_Param.Columns["ID"].Visible = false;

            //Filtre par raport à la zone de recherche
            string recherche = lblRechercheParam.Text.Trim().ToUpper();
            if (recherche.Length > 0)
            {
                for (int k = 0; k < DG_Param.Rows.Count; k++)
                {
                    DG_Param.Rows[k].Visible = DG_Param.Rows[k].Cells["nom"].Value.ToString().ToUpper().Contains(recherche)
                        || DG_Param.Rows[k].Cells["code"].Value.ToString().ToUpper().Contains(recherche);
                }
            }

            for (int k = 0; k < DG_Param.Columns.Count; k++)
            {
                DG_Param.Columns[k].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        void AjouterParam()
        {
            frmParametre f = new frmParametre();
            f.Acces = Acces;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeParam();
            }
        }

        void ModifierParam()
        {
            if (DG_Param.SelectedRows.Count == 0) { return; }

            frmParametre f = new frmParametre();
            f.Acces = Acces;
            f.ID = int.Parse(DG_Param.SelectedRows[0].Cells["ID"].Value.ToString());
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeParam();
            }
        }

        void SupprimerParam()
        {
            if (DG_Param.SelectedRows.Count == 0) { return; }

            if (MessageBox.Show("Etes-vous sûr de vouloir supprimer ce paramètre ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }

            Parametre p = new Parametre();
            p.Acces = Acces;
            p.ID = int.Parse(DG_Param.SelectedRows[0].Cells["id"].Value.ToString());
            p.Supprimer();

            Afficher_ListeParam();
        }

        private void btnAjouterParam_Click(object sender, EventArgs e)
        {
            AjouterParam();
        }

        private void btnModifierParam_Click(object sender, EventArgs e)
        {
            ModifierParam();
        }

        private void btnsupprimerParam_Click(object sender, EventArgs e)
        {
            SupprimerParam();
        }

        private void btnActualiserParam_Click(object sender, EventArgs e)
        {
            Afficher_ListeParam();
        }

        private void lblRechercherParam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            { Afficher_ListeParam(); }
        }
    }
}
