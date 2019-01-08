using System;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using System.Drawing;
using PATIO.CAPA.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class ElementProjet : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public ctrlConsole Console;
        public Projet projet;

        public List<table_valeur> listeStatut;

        int id=0;
        string libelle = "";
        bool ouvert = true;
        int statut = 0;

        //Variables 
        public int Id { get; set;}

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; lblTitre.Text = libelle; toolTip1.Show(lblTitre.Text, lblTitre); }
        }

        public bool Ouvert
        {
            get { return ouvert; }
            set
            {
                ouvert = value;
                if (ouvert) { Agrandir(); }
                else { Reduire(); }
            }
        }
        
        public int Statut
        {
            get { return statut; }
            set {
                statut = value;
                Afficher_Status();
            }
        }

        //Procédure
        public ElementProjet()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            //tabControl1.SendToBack();
            Agrandir();
            Afficher_Info();
        }

        void Afficher_Status()
        {
            foreach (table_valeur tv in listeStatut)
            {
                if (tv.ID == statut)
                {
                    toolTip1.Show(tv.Valeur, lblStatut);
                    int val_status = int.Parse(tv.Valeur.Split('-')[0]);

                    if (val_status == 0) { lblStatut.Image = Properties.Resources.btn_triangle_jaune; } //A débuter
                    if (val_status == 1) { lblStatut.Image = Properties.Resources.btn_triangle_vert; }  //En cours
                    if (val_status == 2) { lblStatut.Image = Properties.Resources.btn_triangle_bleu; }  //Terminé
                    if (val_status == 3) { lblStatut.Image = Properties.Resources.btn_triangle_orange; }//Suspendu
                    if (val_status == 4) { lblStatut.Image = Properties.Resources.btn_triangle_rouge; } //Abandonné
                    break;
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Reduire();
        }

        public void Reduire()
        {
            this.Height = 35;
            btnUp.Visible = false;
            btnDown.Visible = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Agrandir();
        }

        public void Agrandir()
        {
            this.Height = 150;
            btnUp.Visible = true;
            btnDown.Visible = false;
        }

        private void btnOuvrir_Click(object sender, EventArgs e)
        {
            Ouvrir();
        }

        void Ouvrir()
        {
            DockContent D_Processus = new DockContent();

            ctrlGestionProjet ctrl = new ctrlGestionProjet();
            ctrl.Dock = DockStyle.Fill;
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Initialiser();

            D_Processus.Controls.Add(ctrl);

            D_Processus.Show(Acces.DP, DockState.Document);
            D_Processus.Text = "Projet " + libelle;
            D_Processus.Tag = "PROJET";
            D_Processus.ShowInTaskbar = false;
            D_Processus.CloseButton = true;
        }

        void Afficher_Info()
        {
            lstInfo.Items.Clear();

            lstInfo.Items.Add("Id : " + projet.ID);
            lstInfo.Items.Add("Pilote : " + projet.Pilote.NomPrenom);
        }

        void OuvrirFinance()
        {
            DockContent D_Processus = new DockContent();

            ctrlProjetFinance ctrl = new ctrlProjetFinance();
            ctrl.Dock = DockStyle.Fill;
            ctrl.Acces = Acces;
            ctrl.DP = DP;
            ctrl.Initialiser();

            D_Processus.Controls.Add(ctrl);

            D_Processus.Show(Acces.DP, DockState.Document);
            D_Processus.Text = "Projet-Finance " + libelle;
            D_Processus.Tag = "PROJET-FINANCE";
            D_Processus.ShowInTaskbar = false;
            D_Processus.CloseButton = true;
        }

        private void Mouse_Enter()
        {
            lblTitre.BackColor = Color.LightGreen;
        }

        private void Mouse_Leave()
        {
            lblTitre.BackColor = Color.White;
        }

        private void btnOuvrir_MouseEnter(object sender, EventArgs e)
        {
            Mouse_Enter();
        }

        private void btnOuvrir_MouseLeave(object sender, EventArgs e)
        {
            Mouse_Leave();
        }
    }
}
