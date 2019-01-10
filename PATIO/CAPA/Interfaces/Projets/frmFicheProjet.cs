using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.CAPA.Classes;
using PATIO.ADMIN.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class frmFicheProjet : Form
    {
        public PATIO.CAPA.Classes.Action action;
        public Projet projet = new Projet();
        public AccesNet Acces;
        public Boolean Creation = false;
        public ctrlConsole Console;

        List<Utilisateur> ListePilote = new List<Utilisateur>();
        List<table_valeur> ListeTypeProjet = new List<table_valeur>();
        List<table_valeur> ListeStatut = new List<table_valeur>();

        Fonctions fonc = new Fonctions();

        public frmFicheProjet()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblEntete.Text = "PRJ";
            lblLibelleProjet.Text = projet.Libelle;
            lblCode.Text = projet.Code;
            OptActiveProjet.Checked = projet.Actif;

            Afficher_ListeTypeProjet();
            Afficher_ListeStatut();
            Afficher_ListePilote();
        }

        void Afficher_ListeTypeProjet()
        {
            lstTypeProjet.Items.Clear();

            ListeTypeProjet = Acces.Remplir_ListeTableValeur("TYPE_PROJET");
            ListeTypeProjet.Sort();

            foreach(table_valeur tv in ListeTypeProjet)
            {
                lstTypeProjet.Items.Add(tv.Valeur);
                if (projet.TypeProjet == tv.ID) { lstTypeProjet.SelectedIndex = lstTypeProjet.Items.Count - 1; }
            }

            if (lstTypeProjet.Items.Count > 0) { lstTypeProjet.SelectedIndex = 0; }
        }

        void Afficher_ListeStatut()
        {
            lstStatut.Items.Clear();

            ListeStatut = Acces.Remplir_ListeTableValeur("STATUT");
            ListeStatut.Sort();

            foreach (table_valeur tv in ListeStatut)
            {
                lstStatut.Items.Add(tv.Valeur);
                if(projet.Statut == tv.ID) { lstStatut.SelectedIndex = lstStatut.Items.Count - 1; }
            }

            if (lstStatut.Items.Count > 0) { lstStatut.SelectedIndex = 0; }
        }

        void Afficher_ListePilote()
        {
            lstPilote.Items.Clear();

            ListePilote = Acces.Remplir_ListeUtilisateurPilote();
            foreach (Utilisateur t in ListePilote)
            {
                lstPilote.Items.Add(t.NomPrenom);
            }

            if (lstPilote.Items.Count > 0) { lstPilote.SelectedIndex = 0; }
        }

        void Generer_Code()
        {
            string code = "";

            code = lblEntete.Text + "-" +
                lblRef1.Text.Replace("-", "_").Trim() +
                lblRef2.Text.Replace("-", "_").Trim();

            lblCodeProjet.Text = code;
        }

        void Afficher_Code()
        {
            string code = lblCodeProjet.Text.Replace("PRJ-","");
            try
            {
                lblRef1.Text = code.Split('-')[0];
                lblRef2.Text = code.Split('-')[1];
            } catch { }
        }

        void Valider()
        {
            if(action == null) { MessageBox.Show("Action ?"); return; }
            if (lstTypeProjet.SelectedIndex < 0) { MessageBox.Show("Type de projet ?"); return; }
            if (lstPilote.SelectedIndex < 0) { MessageBox.Show("Pilote du projet ?"); return; }
            if (lstStatut.SelectedIndex < 0) { MessageBox.Show("Statut du projet ?"); return; }

            var LibProjet = lblLibelleProjet.Text.Trim();
            var EnteteProjet = lblEntete.Text.Trim().ToUpper();
            var CodeProjet = lblCodeProjet.Text;
            var OptActive = OptActiveProjet.Checked;
            var TypeProjet = ListeTypeProjet[lstTypeProjet.SelectedIndex].ID;
            var Statut = ListeStatut[lstStatut.SelectedIndex].ID;

            int Pilote = -1;
            try { Pilote = ListePilote[lstPilote.SelectedIndex].ID; } catch { }

            if (CodeProjet.Length == 0)
            {
                MessageBox.Show("Code du projet obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            projet.Acces = Acces;
            projet.Libelle = LibProjet;
            projet.Code = CodeProjet;
            projet.TypeProjet = TypeProjet;
            projet.Statut = Statut;
            projet.Actif = OptActive;

            projet.Pilote = Acces.Trouver_Utilisateur(Pilote);

            TypeElement type = Acces.type_PROJET;

            if (Creation)
            {
                if (!(Acces.Existe_Element(type, "CODE", projet.Code)))
                {
                    projet.ID = Acces.Ajouter_Element(type, projet);

                    //Création du lien
                    if (action != null)
                    {
                        //Création du lien avec le parent
                        Lien l = new Lien() { Acces = Acces, };
                        l.element0_type = Acces.type_PLAN.ID;
                        l.element0_id = 1;
                        l.element0_code = "SYSTEME";
                        l.element1_type = Acces.type_ACTION.ID;
                        l.element1_id = action.ID;
                        l.element1_code = action.Code;
                        l.element2_type = Acces.type_PROJET.ID;
                        l.element2_id = projet.ID;
                        l.element2_code = projet.Code;
                        l.Ajouter();
                        Acces.Ajouter_Lien(l);
                        Creation = false;
                    }

                    Acces.Enregistrer(Acces.type_ACTION, action);
                }
                else { MessageBox.Show("Projet existant (Code)", "Erreur"); return; }
            }
            else
            {
                Acces.Enregistrer(type, projet);
            }

            //Test du changement de code --> Impact sur les liens
            /*if (lblCodePlan.Text != lblCodePlan.Tag.ToString())
            {
                Lien l = new Lien() { Acces = Acces, };
                l.MettreAJourCode(Acces.type_PLAN, plan.ID, plan.Code);
            }*/

            this.DialogResult = DialogResult.OK;
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Valider();
        }

        private void lblRef1_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }

        private void lblRef2_TextChanged(object sender, EventArgs e)
        {
            Generer_Code();
        }
    }
}
