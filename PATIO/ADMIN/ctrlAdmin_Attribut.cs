using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.Modules;

namespace PATIO.ADMIN
{
    public partial class ctrlAdmin_Attribut : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        List<table_valeur> listeTypeElement;

        public ctrlAdmin_Attribut()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeAttribut();

            Afficher_ListeElement();
        }

        void Afficher_ListeElement()
        {
            lstElement.Items.Clear();

            listeTypeElement = Acces.Remplir_ListeTableValeur("TYPE_ELEMENT");

            foreach (var t in listeTypeElement)
            {
                lstElement.Items.Add(t.Code);
            }
        }

        void Afficher_ListeAttribut()
        {
            Acces.Charger_ListeAttribut();
            DG_Attribut.DataSource = Acces.ListeAttribut;
            DG_Attribut.Columns["ID"].Visible = false;

            //Filtre par raport à la zone de recherche
            string recherche = lblRechercheAttribut.Text.Trim().ToUpper();
            if (recherche.Length > 0)
            {
                try
                {
                    for (int k = 0; k < DG_Attribut.Rows.Count; k++)
                    {
                        DG_Attribut.Rows[k].Visible =
                            DG_Attribut.Rows[k].Cells["Libelle"].Value.ToString().ToUpper().Contains(recherche)
                            || DG_Attribut.Rows[k].Cells["Code"].Value.ToString().ToUpper().Contains(recherche);
                    }
                }
                catch { }
            }

            if (!(lstElement.SelectedIndex < 0))
            {
                for (int k = 0; k < DG_Attribut.Rows.Count; k++)
                {
                    try
                    {
                        DG_Attribut.Rows[k].Visible =
                           (DG_Attribut.Rows[k].Cells["element_type"].Value.ToString() == listeTypeElement[lstElement.SelectedIndex].ID.ToString());
                    }
                    catch { }
                }
            }

            for (int k = 0; k < DG_Attribut.Columns.Count; k++)
            {
                DG_Attribut.Columns[k].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnAjouterAttribut_Click(object sender, EventArgs e)
        {
            AjouterAttribut();
        }

        private void btnSupprimerAttribut_Click(object sender, EventArgs e)
        {
            SupprimerAttribut();
        }

        private void btnModifierAttribut_Click(object sender, EventArgs e)
        {
            ModifierAttribut();
        }

        void AjouterAttribut()
        {
            frmAttribut f = new frmAttribut();
            f.Acces = Acces;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeAttribut();
            }
        }

        void ModifierAttribut()
        {
            if (DG_Attribut.SelectedRows.Count == 0) { return; }

            frmAttribut f = new frmAttribut();
            f.Acces = Acces;
            f.ID = int.Parse(DG_Attribut.SelectedRows[0].Cells["ID"].Value.ToString());
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeAttribut();
            }
        }

        void SupprimerAttribut()
        {
            if (DG_Attribut.SelectedRows.Count == 0) { return; }

            if (MessageBox.Show("Etes-vous sûr de vouloir supprimer cet attribut ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }

            Attribut att = new Attribut();
            att.Acces = Acces;
            att.ID = int.Parse(DG_Attribut.SelectedRows[0].Cells["id"].Value.ToString());
            att.Supprimer();

            //Impact sur dElement !!!!!

            Afficher_ListeAttribut();
        }

        private void btnActualiserAttribut_Click(object sender, EventArgs e)
        {
            Afficher_ListeAttribut();
        }

        private void lblRechercheAttribut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            { Afficher_ListeAttribut(); }
        }

        private void lstElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_ListeAttribut();
        }
    }
}
