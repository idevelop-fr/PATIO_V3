using System;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.CAPA.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlListeProjet : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        ///         
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public ctrlConsole Console;
        public PATIO.CAPA.Classes.Action action;

        public int ID;

        /// <summary>
        /// Définition des paramètres privés
        /// </summary>
        List<Projet> listeProjet = new List<Projet>();
        List<ElementProjet> listeElementProjet = new List<ElementProjet>();
        List<table_valeur> listeStatut;
        List<Lien> listeLien = new List<Lien>();

        /// <summary>
        /// Procédure d'initialisation automatique du composant
        /// </summary>
        public ctrlListeProjet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Procédure d'initialisation déclenchée du composant
        /// </summary>
        public void Initialiser()
        {
            Afficher_ListeStatut();
            Charger_Liste();
            Afficher_Projet();
        }

        /// <summary>
        /// Affiche la liste des statuts pour les projets
        /// Cible : Combo
        /// </summary>
        void Afficher_ListeStatut()
        {
            lstStatut.Items.Clear();
            listeStatut = Acces.Remplir_ListeTableValeur("STATUT");

            listeStatut.Add(new table_valeur("TOUS","(Tous)"));
            listeStatut.Sort();

            foreach(table_valeur tv in listeStatut)
            {
                lstStatut.Items.Add(tv.Valeur);
            }
            if(lstStatut.Items.Count >0) { lstStatut.SelectedIndex = 0; }
        }

        /// <summary>
        /// Procédure de chargement de la liste des projets en lien avec l'action mère
        /// Cible : List<>
        /// </summary>
        void Charger_Liste()
        {
            listeProjet = (List<Projet>)Acces.Remplir_ListeElement(Acces.type_PROJET, "");
            listeProjet.Sort();
            listeElementProjet = new List<ElementProjet>();

            int Statut = 0;
            if(!(lstStatut.SelectedIndex<0)) { Statut = listeStatut[lstStatut.SelectedIndex].ID; }

            listeLien = Acces.Remplir_ListeLien_Niv1(Acces.type_ACTION, action.ID.ToString());

            foreach (Lien l in listeLien)
            {
                if (l.Element2_Type == Acces.type_PROJET.ID)
                {
                    foreach (Projet prj in listeProjet)
                    {
                        if(l.Element2_ID == prj.ID && prj.Actif)
                        {
                            ElementProjet e = new ElementProjet();
                            e.Acces = Acces;
                            e.listeStatut = listeStatut;
                            e.Id = prj.ID;
                            e.Libelle = prj.Libelle;
                            e.Ouvert = false;
                            e.Statut = prj.Statut;
                            e.projet = prj;
                            listeElementProjet.Add(e);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Affiche la liste des projets répondant aux critères de sélection
        /// Cible : FlowLayoutPanel + composants ElementProjet
        /// </summary>
        void Afficher_Projet()
        {
            FLP.Controls.Clear();
            int statut = 0;
            if(!(lstStatut.SelectedIndex<0)) { statut = listeStatut[lstStatut.SelectedIndex].ID; }

            FLP.Controls.Clear();

            foreach(ElementProjet e in listeElementProjet)
            {
                if (e.Statut == statut || statut == 0)
                {
                    e.Acces = Acces;
                    e.Console = Console;
                    e.action = action;
                    e.Initialiser();
                    FLP.Controls.Add(e);
                }
            }
        }
        
        /// <summary>
        /// Evénement sur sélection d'un statut dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstStatut_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afficher_Projet();
        }

        /// <summary>
        /// Evénement sur bouton Agrandir le composant ElementProjet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgranditTout_Click(object sender, EventArgs e)
        {
            Agrandir();
        }

        /// <summary>
        /// Procédure d'agrandissement du composant ElementProjet
        /// </summary>
        void Agrandir()
        {
            foreach (Control c in FLP.Controls)
            {
                ElementProjet e = (ElementProjet)c;
                e.Agrandir();
            }
        }

        /// <summary>
        /// Evénement sur bouton Réduire le composant ElementProjet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReduireTout_Click(object sender, EventArgs e)
        {
            Reduire();
        }

        /// <summary>
        /// Procédure de réduction du composant ElementProjet
        /// </summary>
        void Reduire()
        {
            foreach(Control c in FLP.Controls)
            {
                ElementProjet e = (ElementProjet)c;
                e.Reduire();
            }
        }

        /// <summary>
        /// Evénement sur bouton de création d'un nouveau projet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCréerProjet_Click(object sender, EventArgs e)
        {
            AjouterProjet();
        }

        /// <summary>
        /// Procédure de création d'un nouveau projet
        /// </summary>
        void AjouterProjet()
        {
            //Phase 1 : Création du projet
            frmFicheProjet f = new frmFicheProjet();
            f.Acces = Acces;
            f.Creation = true;
            f.Console = Console;
            f.action = action;
            f.Initialiser();

            if(f.ShowDialog() == DialogResult.Cancel) { return; }

            Projet prj = f.projet;

            Charger_Liste();
            Afficher_Projet();

            //Ouverture de la fiche 
            DockContent D_Processus = new DockContent();

            ctrlProjetProcessus ctrl = new ctrlProjetProcessus();
            ctrl.Dock = DockStyle.Fill;
            ctrl.Acces = Acces;
            ctrl.Initialiser();

            D_Processus.Controls.Add(ctrl);

            D_Processus.Show(Acces.DP, DockState.Document);
            D_Processus.Text = "Projet " + prj.Libelle;
            D_Processus.Tag = "PROJET+" + prj.ID.ToString();
            D_Processus.ShowInTaskbar = false;
            D_Processus.CloseButton = true;
        }

        /// <summary>
        /// Evénement sur bouton Actualiser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            Initialiser();
        }
    }
}
