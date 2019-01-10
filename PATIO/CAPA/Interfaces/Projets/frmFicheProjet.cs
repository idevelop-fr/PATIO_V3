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
using PATIO.OMEGA.Classes;

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
        List<Budget_Enveloppe> ListeEnveloppe = new List<Budget_Enveloppe>();

        Fonctions fonc = new Fonctions();

        public frmFicheProjet()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            lblEntete.Text = "PRJ";
            lblLibelleProjet.Text = projet.Libelle;
            lblCodeProjet.Text = projet.Code;
            lblCode.Text = projet.Code;
            Afficher_Code();
            OptActiveProjet.Checked = projet.Actif;

            Afficher_ListeTypeProjet();
            Afficher_ListeStatut();
            Afficher_ListePilote();
            Afficher_ListeEnveloppe();
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

        void Afficher_ListeEnveloppe()
        {
            ListeEnveloppe = (List<Budget_Enveloppe>)Acces.Remplir_ListeElement(Acces.type_BUDGET_ENVELOPPE, "");

            ChoixEnveloppe.Initialiser();
            foreach (Budget_Enveloppe tv in ListeEnveloppe)
            {
                Boolean ok = false;
                foreach (int k in projet.EnveloppeBudget)
                {
                    if (tv.ID == k) { ok = true; break; }
                }
                if (ok)
                {
                    ChoixEnveloppe.ListeSelection.Add(new Parametre(tv.ID, tv.Code, tv.Libelle));
                }
                ChoixEnveloppe.ListeChoix.Add(new Parametre(tv.ID, tv.Code, tv.Libelle));
            }
            ChoixEnveloppe.Afficher_Liste();
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
            projet.EnveloppeBudget = ChoixEnveloppe.ListeSelectionId;

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
                        l.Element0_Type = Acces.type_PLAN.ID;
                        l.Element0_ID = 1;
                        l.Element0_Code = "SYSTEME";
                        l.Element1_Type = Acces.type_ACTION.ID;
                        l.Element1_ID = action.ID;
                        l.Element1_Code = action.Code;
                        l.Element2_Type = Acces.type_PROJET.ID;
                        l.Element2_ID = projet.ID;
                        l.Element2_Code = projet.Code;
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
