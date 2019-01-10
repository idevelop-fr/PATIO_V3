using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using System.Data;

namespace PATIO.ADMIN
{
    public partial class ctrlAdmin_TableValeur : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public string Chemin;

        public ctrlConsole Console;

        List<table_valeur> listeTV;

        public ctrlAdmin_TableValeur()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_Liste();
            Afficher_ListeTV();
        }

        void Afficher_Liste()
        {
            lstTable.Items.Clear();

            List<string> liste = Acces.Remplir_ListeTableValeurNom();

            foreach(string st in liste)
            {
                lstTable.Items.Add(st);
            }
        }

        void Afficher_ListeTV()
        {
            DG_TV.DataSource = null;
            if (lstTable.SelectedIndex < 0) { return; }

            Acces.Charger_ListeTableValeur();
            listeTV = Acces.ListeTableValeur;
            DG_TV.DataSource = listeTV;
            DG_TV.Columns["ID"].Visible = false;

            //Filtre par raport à la zone de recherche
            string recherche = lblRechercheTV.Text.Trim().ToUpper();
            if (recherche.Length > 0)
            {
                for (int k = 0; k < DG_TV.Rows.Count; k++)
                {
                    DG_TV.Rows[k].Visible = DG_TV.Rows[k].Cells["nom"].Value.ToString().ToUpper().Contains(recherche)
                        || DG_TV.Rows[k].Cells["code"].Value.ToString().ToUpper().Contains(recherche)
                        || DG_TV.Rows[k].Cells["valeur"].Value.ToString().ToUpper().Contains(recherche);
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
            string selection = "";
            if (!(lstTable.SelectedIndex < 0)){ selection = lstTable.SelectedItem.ToString(); }

            frmTableValeur f = new frmTableValeur();
            f.Acces = Acces;
            f.Initialiser();
            if (selection.Length > 0) { f.lstNom.SelectedItem = selection; }

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_Liste();
                Afficher_ListeTV();

                if(selection.Length>0) { lstTable.SelectedItem = selection; }
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
                Afficher_Liste();
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

            Afficher_Liste();
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
            Afficher_Liste();
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

        private void lstParametre_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRechercheTV.Text = lstTable.Items[lstTable.SelectedIndex].ToString();
            Afficher_ListeTV();
        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            Exporter();
        }

        void Exporter()
        {
            string tv = lstTable.SelectedItem.ToString();

            string fichier = Acces.CheminTemp + "\\Export\\tv_" + tv + ".xml";

            string sql;
            sql = "SELECT * FROM table_valeur";
            sql += " WHERE nom='" + tv + "'";
            DataSet Sn = Acces.cls.ContenuRequete(sql);

            Sn.WriteXml(fichier);

            MessageBox.Show("Export effectué" + (char) Keys.Return + fichier
                 + (char)Keys.Return + Sn.Tables["Stat"].Rows[0][0].ToString() + " lignes exportées");
        }

        private void btnImporter_Click(object sender, EventArgs e)
        {
            Importer();
        }

        void Importer()
        {

            OpenFileDialog f = new OpenFileDialog();
            f.Title = "Choix d'un fichier d'import";
            f.Filter = "*.xml|*.xml";
            f.InitialDirectory = Acces.CheminTemp + "\\Export";

            if(f.ShowDialog() == DialogResult.OK)
            {
                string[] liste = f.FileName.Split('\\');

                string nom = liste[liste.Length-1].Replace("tv_", "").Replace(".xml", "");

                Console.Ajouter("### IMPORT TV ###");
                if(MessageBox.Show("Vous allez importer les données pour la table " + nom + ". Continuez ?","Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) { return; }

                string fichier = f.FileName;
                listeTV = Acces.ListeTableValeur;

                DataSet Sn = new DataSet();
                Sn.ReadXml(fichier);
                int n = 0;

                foreach (DataRow r in Sn.Tables["dataset"].Rows)
                {
                    table_valeur tv = new table_valeur();
                    //tv.ID = int.Parse(r["id"].ToString());
                    tv.Nom = r["nom"].ToString();
                    tv.Code = r["code"].ToString();
                    tv.Valeur = r["valeur"].ToString();
                    tv.Valeur6PO = r["valeur_6po"].ToString();

                    bool ok = false;
                    foreach (table_valeur tv1 in listeTV)
                    { if (tv1.Nom.ToUpper() == tv.Nom.ToUpper() &&
                            tv1.Code.ToUpper() == tv.Code.ToUpper()) { ok = true; break; } }

                    if (!ok)
                    {
                        tv.Acces = Acces;
                        tv.Ajouter();
                        Console.Ajouter("Ajout TV : " + tv.Code);
                        n++;
                    }
                    else
                    {
                        Console.Ajouter("Valeur existante : " + tv.Code);
                    }
                }
                if(lstTable.SelectedIndex<0) { Afficher_Liste(); }
                Afficher_ListeTV();
                MessageBox.Show("Import terminé. " + n + " ajout(s)");
            }
        }
    }
}
