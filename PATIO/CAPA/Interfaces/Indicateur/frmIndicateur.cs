using System;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;
using System.Collections.Generic;

namespace PATIO.CAPA.Interfaces
{
    public partial class frmIndicateur : Form
    {
        public frmIndicateur()
        {
            InitializeComponent();
        }

        public Indicateur indicateur;
        public AccesNet Acces;
        public Boolean Creation = false;

        Fonctions fonc = new Fonctions();

        string[] listeTypeIndicateur;

        List<table_valeur> ListeGenre;
        List<table_valeur> ListeCategorie;
        List<table_valeur> ListeType;
        List<table_valeur> ListeRepartition;

        public void Initialiser()
        {
            lblLibelleIndicateur.Text = indicateur.Libelle;

            lblCodeIndicateur.Text = indicateur.Code;
            if(lblCodeIndicateur.Text.Length == 0) { lblCodeIndicateur.Text = "IND-"; }

            lblCodeIndicateur.Tag = lblCodeIndicateur.Text;

            OptActiveIndicateur.Checked = indicateur.Actif;

            AfficheTypeIndicateur();
            lstTypeIndicateur.SelectedIndex = lstTypeIndicateur.Items.IndexOf(indicateur.TypeIndicateur.ToString());

            AfficheListeType();
            AfficheListeGenre();
            AfficheListeCategorie();
            AfficheListeRepartition();

        }

        void AfficheTypeIndicateur()
        {
            lstTypeIndicateur.Items.Clear();

            listeTypeIndicateur = Enum.GetNames(typeof(TypeIndicateur));

            foreach (var t in listeTypeIndicateur)
            {
                lstTypeIndicateur.Items.Add(t);
            }
        }

        void AfficheListeGenre()
        {
            lstGenre_6PO.Items.Clear();
            ListeGenre = Acces.Remplir_ListeTableValeur("INDICATEUR_GENRE");
            foreach (table_valeur tv in ListeGenre)
            {
                lstGenre_6PO.Items.Add(tv.Valeur);
                if (tv.ID == indicateur.Genre)
                { lstGenre_6PO.SelectedIndex = lstGenre_6PO.Items.Count - 1; }
            }
            
        }

        void AfficheListeCategorie()
        {
            lstCateg_6PO.Items.Clear();
            ListeCategorie = Acces.Remplir_ListeTableValeur("INDICATEUR_CATEGORIE");
            foreach (table_valeur tv in ListeCategorie)
            {
                lstCateg_6PO.Items.Add(tv.Valeur);
                if (tv.ID == indicateur.Categorie)
                { lstCateg_6PO.SelectedIndex = lstCateg_6PO.Items.Count - 1; }
            }
        }

        void AfficheListeType()
        {
            lstType_6PO.Items.Clear();
            ListeType = Acces.Remplir_ListeTableValeur("INDICATEUR_TYPE");
            foreach (table_valeur tv in ListeType)
            {
                lstType_6PO.Items.Add(tv.Valeur);
                if (tv.ID == (int)indicateur.Type)
                { lstType_6PO.SelectedIndex = lstType_6PO.Items.Count - 1; }
            }

            if (lstType_6PO.SelectedIndex < 0 && lstType_6PO.Items.Count >0) { lstType_6PO.SelectedIndex = 0; }
        }

        void AfficheListeRepartition()
        {
            lstRepartition_6PO.Items.Clear();
            ListeRepartition = Acces.Remplir_ListeTableValeur("INDICATEUR_REPARTITION");
            foreach (table_valeur tv in ListeRepartition)
            {
                lstRepartition_6PO.Items.Add(tv.Valeur);
                if (tv.ID == indicateur.Genre)
                { lstRepartition_6PO.SelectedIndex = lstRepartition_6PO.Items.Count - 1; }
            }
            if (lstRepartition_6PO.SelectedIndex < 0 && lstRepartition_6PO.Items.Count>0) { lstRepartition_6PO.SelectedIndex = 0; }

        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        void Valider()
        {
            var LibIndicateur = lblLibelleIndicateur.Text.Trim();
            var CodeIndicateur = lblCodeIndicateur.Text.Trim().ToUpper();
            var OptActive = OptActiveIndicateur.Checked;
            var TypeIndicateur = (TypeIndicateur)lstTypeIndicateur.SelectedIndex;

            if (LibIndicateur.Length == 0)
            {
                MessageBox.Show("Libellé de l'indicateur obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            if (CodeIndicateur.Length == 0)
            {
                MessageBox.Show("Code de l'indicateur obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            indicateur.Acces = Acces;
            indicateur.Libelle = LibIndicateur;
            indicateur.Code = CodeIndicateur;
            indicateur.TypeIndicateur = TypeIndicateur;
            indicateur.Actif = OptActive;

            indicateur.Type = ListeType[lstType_6PO.SelectedIndex].ID;
            try { indicateur.Genre = ListeGenre[lstGenre_6PO.SelectedIndex].ID; } catch { }
            try { indicateur.Categorie = ListeCategorie[lstCateg_6PO.SelectedIndex].ID; } catch { }
            indicateur.Repartition = ListeRepartition[lstRepartition_6PO.SelectedIndex].ID;

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_INDICATEUR, "CODE", CodeIndicateur)))
                {indicateur.ID = Acces.Ajouter_Element(Acces.type_INDICATEUR, indicateur); }
            }
            else
            {
                Acces.Enregistrer(Acces.type_INDICATEUR, indicateur);

                //Test du changement de code --> Impact sur les liens
                if (lblCodeIndicateur.Text != lblCodeIndicateur.Tag.ToString())
                {
                    Lien l = new Lien() { Acces = Acces, };
                    l.MettreAJourCode(Acces.type_INDICATEUR, indicateur.ID, indicateur.Code);
                }
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
