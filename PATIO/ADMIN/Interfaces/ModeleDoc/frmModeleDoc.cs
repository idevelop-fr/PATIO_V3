using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;


namespace PATIO.ADMIN
{
    public partial class frmModeleDoc : Form
    {
        public ModeleDoc modele_doc;
        public AccesNet Acces;
        public Boolean Creation = false;
        public int Parent_ID;
        public Type_Modele type_modele;
        public ctrlConsole Console;

        List<ModeleDoc> listeTypeModele;
        string[] listeAlignement;

        public frmModeleDoc()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            OptActive.Checked = true;
            lblEntete.Text = "MDL";
            lblRef.Text = modele_doc.Code.Replace("MDL-", "");
            lblLibelle.Text = modele_doc.Libelle;
            OptActive.Checked = modele_doc.Actif;

            Console.Ajouter(modele_doc.Type_Modele.ToString());
            //Modèle
            if (modele_doc.Type_Modele == Type_Modele.MODELE)
            {
                tabControl2.SelectedIndex = 0;
                Afficher_ListeTypeModele();
                lblFichierBase.Text = modele_doc.FichierBase;
            }

            //Zone
            if (modele_doc.Type_Modele == Type_Modele.ZONE)
            {
                tabControl2.SelectedIndex = 1;
                lblConditionZone.Text = modele_doc.Condition;
            }

            //Ligne
            if (modele_doc.Type_Modele == Type_Modele.LIGNE)
            {
                tabControl2.SelectedIndex = 2;
                lblConditionZone.Text = modele_doc.Condition;
            }

            //Colonne
            if (modele_doc.Type_Modele == Type_Modele.COLONNE)
            {
                tabControl2.SelectedIndex = 3;
                lblTexteColonne.Text = modele_doc.Contenu;
                lblTexteColonne.Text = modele_doc.Contenu;
                lblPct.Value = modele_doc.Taille;
                lblBordureColonne.Text = modele_doc.Bordure;
                Afficher_ListeAlignement();
            }

            //Protection des zones non utilisées
            for(int i=0; i<tabControl2.TabPages.Count;i++)
            {
                if(tabControl2.TabPages[i] != tabControl2.SelectedTab)
                {
                    for(int j=0; j<tabControl2.TabPages[i].Controls.Count;j++)
                    {
                        tabControl2.TabPages[i].Controls[j].Enabled = false;
                    }
                }
            }
        }

        void Afficher_ListeAlignement()
        {
            lstAlignementColonne.Items.Clear();

            listeAlignement = Enum.GetNames(typeof(Alignement));

            foreach (var t in listeAlignement)
            {
                lstAlignementColonne.Items.Add(t);
            }
            lstAlignementColonne.SelectedIndex = lstAlignementColonne.Items.IndexOf(modele_doc.Type_Modele.ToString());
        }

        void Afficher_ListeTypeModele()
        {
            listeTypeModele =(List<ModeleDoc>) Acces.Remplir_ListeElement(Acces.type_MODELEDOC,"");

            lstTypeModele.Items.Clear();
            foreach (ModeleDoc md in listeTypeModele)
            {
                if (md.Type_Modele == Type_Modele.DOSSIER)
                {
                    lstTypeModele.Items.Add(md.Libelle);
                    if (md.ID == Parent_ID)
                    { lstTypeModele.SelectedIndex = lstTypeModele.Items.Count - 1; }
                }
            }
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
            var Libelle = lblLibelle.Text.Trim();
            var code = lblEntete.Text + "-" + lblRef.Text.ToUpper();
            if (lblRef.Text.Length == 0)
            {
                MessageBox.Show("Référence obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            modele_doc.Acces = Acces;
            modele_doc.Code = code;
            modele_doc.Libelle = Libelle;
            modele_doc.Type_Modele = type_modele;
            modele_doc.Actif = OptActive.Checked;

            if (modele_doc.Type_Modele == Type_Modele.MODELE)
            {
                if (lstTypeModele.SelectedIndex < 0) { MessageBox.Show("Type de modèle ?"); return; }
                var p_ID = listeTypeModele[lstTypeModele.SelectedIndex].ID;
                modele_doc.Parent_ID = p_ID;
            }

            if (modele_doc.Type_Modele == Type_Modele.ZONE)
            {
                modele_doc.Condition = lblConditionZone.Text;
            }

            if (modele_doc.Type_Modele == Type_Modele.LIGNE)
            {
                modele_doc.Condition = lblConditionLigne.Text;
            }

            if (modele_doc.Type_Modele == Type_Modele.COLONNE)
            {
                modele_doc.Contenu = lblTexteColonne.Text;
                modele_doc.Taille = int.Parse(lblPct.Value.ToString());
                modele_doc.Alignement = (Alignement)lstAlignementColonne.SelectedIndex;
                modele_doc.Bordure = lblBordureColonne.Text;
            }

            if (Creation)
            {
                if (!(Acces.Existe_Element(Acces.type_MODELEDOC, "CODE", code)))
                { Acces.Ajouter_Element(Acces.type_MODELEDOC, modele_doc); }
            }
            else
            {
                Acces.Enregistrer(Acces.type_MODELEDOC, modele_doc);
            }

            this.DialogResult = DialogResult.OK;
        }

    }
}
