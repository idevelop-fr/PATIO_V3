﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.Modules;
namespace PATIO.ADMIN
{
    public partial class ctrlAdmin_TableValeur : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        public ctrlAdmin_TableValeur()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeTV();
        }

        void Afficher_ListeTV()
        {
            DG_TV.DataSource = null;
            Acces.Charger_ListeTableValeur();
            DG_TV.DataSource = Acces.ListeTableValeur;
            DG_TV.Columns["ID"].Visible = false;

            //Filtre par raport à la zone de recherche
            string recherche = lblRechercheTV.Text.Trim().ToUpper();
            if (recherche.Length > 0)
            {
                for (int k = 0; k < DG_TV.Rows.Count; k++)
                {
                    DG_TV.Rows[k].Visible = DG_TV.Rows[k].Cells["nom"].Value.ToString().ToUpper().Contains(recherche)
                        || DG_TV.Rows[k].Cells["code"].Value.ToString().ToUpper().Contains(recherche);
                }
            }

            for (int k = 0; k < DG_TV.Columns.Count; k++)
            {
                DG_TV.Columns[k].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            DG_TV.Columns["valeur"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        void AjouterTV()
        {
            frmTableValeur f = new frmTableValeur();
            f.Acces = Acces;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeTV();
            }
        }

        void ModifierTV()
        {
            if (DG_TV.SelectedRows.Count == 0) { return; }

            frmTableValeur f = new frmTableValeur();
            f.Acces = Acces;
            f.ID = int.Parse(DG_TV.SelectedRows[0].Cells["ID"].Value.ToString());
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeTV();
            }
        }

        void SupprimerTV()
        {
            if (DG_TV.SelectedRows.Count == 0) { return; }

            if (MessageBox.Show("Etes-vous sûr de vouloir supprimer cet élément de table de valeur ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes) { return; }

            table_valeur tv = new table_valeur();
            tv.Acces = Acces;
            tv.ID = int.Parse(DG_TV.SelectedRows[0].Cells["id"].Value.ToString());
            tv.Supprimer();

            Afficher_ListeTV();
        }

        private void btnAjouterTV_Click(object sender, EventArgs e)
        {
            AjouterTV();
        }

        private void btnModifierTV_Click(object sender, EventArgs e)
        {
            ModifierTV();
        }

        private void btnSupprimerTV_Click(object sender, EventArgs e)
        {
            SupprimerTV();
        }

        private void btnActualiserTV_Click(object sender, EventArgs e)
        {
            Afficher_ListeTV();
        }

        private void lblRechercheTV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            { Afficher_ListeTV(); }
        }

        private void btnTV_CopierVers_Click(object sender, EventArgs e)
        {
            Copier_tv();
        }

        void Copier_tv()
        {
            if (DG_TV.SelectedRows.Count == 0) { return; }

            frmChoix f = new frmChoix();
            List<string> Liste = Acces.Remplir_ListeTableValeurNom();
            foreach (string l in Liste) { f.lst.Items.Add(l); }
            if (f.ShowDialog() == DialogResult.OK)
            {
                string nom = f.choix;
                nom = nom.ToUpper().Trim();
                if (nom.Length == 0) { return; }

                table_valeur tv_src = Acces.Trouver_TableValeur(int.Parse(DG_TV.SelectedRows[0].Cells["ID"].Value.ToString()));
                if (nom == tv_src.Nom) { MessageBox.Show("Table identique !"); return; }

                if (Acces.Trouver_TableValeur_Code(nom, tv_src.Code) != null)
                { MessageBox.Show("Cet élément existe déjà pour la table de destination."); return; }

                //Création du nouvel élément
                table_valeur tv_dest = new table_valeur() { Acces = Acces, };
                tv_dest.Nom = nom;
                tv_dest.Code = tv_src.Code;
                tv_dest.Valeur = tv_src.Valeur;
                tv_dest.Valeur6PO = tv_src.Valeur6PO;

                tv_dest.Ajouter();
                Afficher_ListeTV();
            }
        }
    }
}
