using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PATIO.MAIN.Classes;
using PATIO.OMEGA.Classes;
using PATIO.ADMIN.Classes;

namespace PATIO.ADMIN.Interfaces
{
    public partial class ctrlGestionModele : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        public ctrlConsole Console;

        List<table_valeur> listeTypeModele = new List<table_valeur>();
        List<ModeleDoc> listeModele = new List<ModeleDoc>();
        string[] listeAlignement;

        ModeleDoc modele_doc;

        public ctrlGestionModele()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeModele();
        }

        void Afficher_ListeModele()
        {
            treeModele.Nodes.Clear();

            listeModele = (List<ModeleDoc>)Acces.Remplir_ListeElement(Acces.type_MODELEDOC, "");

            //Affichage des dossiers
            foreach (ModeleDoc md in listeModele)
            {
                if (md.Type_Modele == Type_Modele.DOSSIER)
                {
                    TreeNode NdType = new TreeNode(md.Libelle);
                    NdType.Name = "TYPE-" + md.ID.ToString();
                    treeModele.Nodes.Add(NdType);
                }
            }

            //Affichage des modèles
            foreach (ModeleDoc md in listeModele)
            {
                TreeNode[] node = treeModele.Nodes.Find("TYPE-" + md.Parent_ID.ToString(), true);
                foreach (TreeNode nd in node)
                {
                    TreeNode NdModele = new TreeNode(md.Libelle);
                    NdModele.Name = "MODELE-" + md.ID.ToString();
                    nd.Nodes.Add(NdModele);
                    nd.Expand();
                }
            }
        }

        private void btnAjouterType_Click(object sender, EventArgs e)
        {
            Ajouter_TypeModele();
        }

        void Ajouter_TypeModele()
        {
            string Libelle = Microsoft.VisualBasic.Interaction.InputBox("Saisir le libellé du type de modèle", "Création d'un type de modèle");

            if (Libelle.Length == 0) { return; }

            ModeleDoc md = new ModeleDoc() { Acces = Acces, };
            md.Libelle = Libelle;
            md.Type_Modele = Type_Modele.DOSSIER;
            md.Actif = true;
            md.Ordre = treeModele.Nodes.Count;

            Acces.Ajouter_Element(Acces.type_MODELEDOC, md);

            Afficher_ListeModele();
        }

        void Ajouter_Modele()
        {
            if (treeModele.SelectedNode == null) { return; }
            int Parent_ID = int.Parse(treeModele.SelectedNode.Name.Split('-')[1]);
            Console.Ajouter("Parent_ID = " + Parent_ID);

            ModeleDoc mdl = new ModeleDoc();
            mdl.Type_Modele = Type_Modele.MODELE;
            mdl.Parent_ID = Parent_ID;
            mdl.Code = "MDL-";
            mdl.Ordre = treeModele.SelectedNode.Nodes.Count;

            frmModeleDoc f = new frmModeleDoc();
            f.Acces = Acces;
            f.Creation = true;
            f.modele_doc = mdl;
            f.Parent_ID = Parent_ID;
            f.type_modele = Type_Modele.MODELE;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeModele();
            }
        }

        void Modifier_Modele()
        {
            if (treeModele.SelectedNode == null) { return; }
            string Module = treeModele.SelectedNode.Name.Split('-')[0];
            int ID = int.Parse(treeModele.SelectedNode.Name.Split('-')[1]);

            ModeleDoc md = (ModeleDoc)Acces.Trouver_Element(Acces.type_MODELEDOC, ID);

            if (Module == "TYPE")
            {
                string Libelle = Microsoft.VisualBasic.Interaction.InputBox("Saisir le libellé du type de modèle",
                                                                            "Création d'un type de modèle", md.Libelle);

                if (Libelle.Length == 0 || md.Libelle == Libelle) { return; }

                md.Libelle = Libelle;

                Acces.Enregistrer(Acces.type_MODELEDOC, md);
                treeModele.SelectedNode.Text = Libelle;
            }

            if (Module == "MODELE")
            {
                frmModeleDoc f = new frmModeleDoc();
                f.Acces = Acces;
                f.Creation = false;
                f.modele_doc = md;
                f.Parent_ID = md.Parent_ID;
                f.Initialiser();

                if (f.ShowDialog() == DialogResult.OK)
                { treeModele.SelectedNode.Text = f.modele_doc.Libelle; }
            }
        }

        void Supprimer_Modele()
        {
            if (treeModele.SelectedNode == null) { return; }
            if (treeModele.SelectedNode.Nodes.Count > 0) { MessageBox.Show("Il faut supprimer tous les modèles pour ce type"); return; }

            int ID = int.Parse(treeModele.SelectedNode.Name.Split('-')[1]);
            ModeleDoc md = (ModeleDoc)Acces.Trouver_Element(Acces.type_MODELEDOC, ID);

            Acces.Supprimer_Element(Acces.type_MODELEDOC, md);

            Afficher_ListeModele();
        }

        private void btnAjouterModele_Click(object sender, EventArgs e)
        {
            if (treeModele.SelectedNode == null) { return; }
            if (!treeModele.SelectedNode.Name.Contains("TYPE")) { MessageBox.Show("Il faut sélectionner un type de modèle"); return; }

            Ajouter_Modele();
        }

        void Afficher_Modele()
        {
            treeStructure.Nodes.Clear();
            if (treeModele.SelectedNode == null) { return; }
            int ID = int.Parse(treeModele.SelectedNode.Name.Split('-')[1]);

            listeModele = (List<ModeleDoc>)Acces.Remplir_ListeElement(Acces.type_MODELEDOC, "");

            //Affichage des informations sur le modèle
            lblFichierBase.Text = "";
            foreach (ModeleDoc md in listeModele)
            {
                if (md.Type_Modele == Type_Modele.MODELE && md.ID == ID)
                {
                    lblFichierBase.Text = md.FichierBase;
                    break;
                }
            }

            //Affichage des zones
            foreach (ModeleDoc md in listeModele)
            {
                if (md.Type_Modele == Type_Modele.ZONE && md.Parent_ID == ID)
                {
                    TreeNode Nd = new TreeNode(md.Libelle);
                    Nd.Name = "ZONE-" + md.ID.ToString();
                    treeStructure.Nodes.Add(Nd);
                }
            }

            //Affichage des lignes
            foreach (ModeleDoc md in listeModele)
            {
                if (md.Type_Modele == Type_Modele.LIGNE)
                {
                    TreeNode[] node = treeStructure.Nodes.Find("ZONE-" + md.Parent_ID.ToString(), true);
                    foreach (TreeNode nd in node)
                    {
                        TreeNode NdModele = new TreeNode(md.Libelle);
                        NdModele.Name = "LIGNE-" + md.ID.ToString();
                        nd.Nodes.Add(NdModele);
                        nd.Expand();
                    }
                }
            }

            //Affichage des colonnes
            foreach (ModeleDoc md in listeModele)
            {
                if (md.Type_Modele == Type_Modele.COLONNE)
                {
                    TreeNode[] node = treeStructure.Nodes.Find("LIGNE-" + md.Parent_ID.ToString(), true);
                    foreach (TreeNode nd in node)
                    {
                        TreeNode NdModele = new TreeNode(md.Libelle);
                        NdModele.Name = "COLONNE-" + md.ID.ToString();
                        nd.Nodes.Add(NdModele);
                        nd.Expand();
                    }
                }
            }
        }

        void AjouterZone()
        {
            if (treeModele.SelectedNode == null) { MessageBox.Show("Il faut sélectionner un modèle."); return; }
            if (treeModele.SelectedNode.Nodes.Count > 0) { MessageBox.Show("Il faut sélectionner un modèle."); return; }

            int ID = int.Parse(treeModele.SelectedNode.Name.Split('-')[1]);

            ModeleDoc md_parent = (ModeleDoc)Acces.Trouver_Element(Acces.type_MODELEDOC, ID);

            ModeleDoc mdl = new ModeleDoc();
            mdl.Code = "MDL-";
            mdl.Parent_ID = ID;
            mdl.Type_Modele = Type_Modele.ZONE;
            mdl.Ordre = treeStructure.Nodes.Count;
            mdl.Code = md_parent.Code;

            frmModeleDoc f = new frmModeleDoc();
            f.Acces = Acces;
            f.Creation = true;
            f.modele_doc = mdl;
            f.type_modele = Type_Modele.ZONE;
            f.Console = Console;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_Modele();
                TreeNode[] lNd = treeStructure.Nodes.Find("ZONE-" + f.modele_doc.ID.ToString(), true);
                if (lNd.Length != 0) { treeStructure.SelectedNode = lNd[0]; }
            }
        }

        void AjouterLigne()
        {
            if (treeModele.SelectedNode == null) { MessageBox.Show("Il faut sélectionner un modèle."); return; }
            if (treeModele.SelectedNode.Nodes.Count > 0) { MessageBox.Show("Il faut sélectionner un modèle."); return; }
            if (treeStructure.SelectedNode == null) { MessageBox.Show("Il faut sélectionner une zone."); return; }

            string TypeElement = treeStructure.SelectedNode.Name.Split('-')[0];
            int ID = int.Parse(treeStructure.SelectedNode.Name.Split('-')[1]);

            if (TypeElement != "ZONE") { MessageBox.Show("Il faut sélectionner une zone."); }

            ModeleDoc md_parent = (ModeleDoc)Acces.Trouver_Element(Acces.type_MODELEDOC, ID);

            ModeleDoc mdl = new ModeleDoc();
            mdl.Code = "MDL-";
            mdl.Parent_ID = ID;
            mdl.Type_Modele = Type_Modele.LIGNE;
            mdl.Ordre = treeStructure.Nodes.Count;
            mdl.Code = md_parent.Code;

            frmModeleDoc f = new frmModeleDoc();
            f.Acces = Acces;
            f.Creation = true;
            f.modele_doc = mdl;
            f.type_modele = Type_Modele.LIGNE;
            f.Console = Console;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_Modele();
                TreeNode[] lNd = treeStructure.Nodes.Find("LIGNE-" + f.modele_doc.ID.ToString(), true);
                if (lNd.Length != 0) { treeStructure.SelectedNode = lNd[0]; }
            }
        }

        void AjouterColonne()
        {
            if (treeModele.SelectedNode == null) { MessageBox.Show("Il faut sélectionner un modèle."); return; }
            if (treeModele.SelectedNode.Nodes.Count > 0) { MessageBox.Show("Il faut sélectionner un modèle."); return; }
            if (treeStructure.SelectedNode == null) { MessageBox.Show("Il faut sélectionner une ligne."); return; }

            string TypeElement = treeStructure.SelectedNode.Name.Split('-')[0];
            int ID = int.Parse(treeStructure.SelectedNode.Name.Split('-')[1]);

            if (TypeElement != "LIGNE") { MessageBox.Show("Il faut sélectionner une ligne."); }

            ModeleDoc md_parent = (ModeleDoc)Acces.Trouver_Element(Acces.type_MODELEDOC, ID);

            ModeleDoc mdl = new ModeleDoc();
            mdl.Code = "MDL-";
            mdl.Parent_ID = ID;
            mdl.Type_Modele = Type_Modele.COLONNE;
            mdl.Ordre = treeStructure.Nodes.Count;
            mdl.Code = md_parent.Code;

            frmModeleDoc f = new frmModeleDoc();
            f.Acces = Acces;
            f.Creation = true;
            f.modele_doc = mdl;
            f.type_modele = Type_Modele.COLONNE;
            f.Console = Console;
            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_Modele();
                TreeNode[] lNd = treeStructure.Nodes.Find("COLONNE-" + f.modele_doc.ID.ToString(), true);
                if (lNd.Length != 0) { treeStructure.SelectedNode = lNd[0]; }
            }
        }

        private void btnModifierModele_Click(object sender, EventArgs e)
        {
            Modifier_Modele();
        }

        private void btnSupprimerModele_Click(object sender, EventArgs e)
        {
            Supprimer_Modele();
        }

        private void MenuZone_Click(object sender, EventArgs e)
        {
            AjouterZone();
        }

        private void MenuLigne_Click(object sender, EventArgs e)
        {
            AjouterLigne();
        }

        private void MenuColonne_Click(object sender, EventArgs e)
        {
            AjouterColonne();
        }

        private void treeModele_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Afficher_Modele();
        }

        private void btnImporterFichier_Click(object sender, EventArgs e)
        {
            Choisir_FichierBase();
        }

        void Choisir_FichierBase()
        {
            treeStructure.Nodes.Clear();
            if (treeModele.SelectedNode == null) { return; }
            if (treeModele.SelectedNode.Nodes.Count > 0) { MessageBox.Show("Choisir un modèle"); return; }
            int ID = int.Parse(treeModele.SelectedNode.Name.Split('-')[1]);

            ModeleDoc md = (ModeleDoc)Acces.Trouver_Element(Acces.type_MODELEDOC, ID);

            OpenFileDialog f = new OpenFileDialog();
            f.Title = "Choix du fichier de base";
            f.InitialDirectory = Acces.CheminBase + "\\Modeles";
            f.Filter = "*.docx|*.docx";

            if (f.ShowDialog() == DialogResult.OK)
            {
                lblFichierBase.Text = f.FileName.Replace(Acces.CheminBase + "\\Modeles\\", "");
                md.Acces = Acces;
                md.FichierBase = f.FileName.Replace(Acces.CheminBase + "\\Modeles\\", "");
                Acces.Enregistrer(Acces.type_MODELEDOC, md);
            }
        }

        private void treeStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Afficher_Tab();
        }

        void Afficher_Tab()
        {
            modele_doc = null;
            if (treeStructure.SelectedNode == null) { return; }
            string type = treeStructure.SelectedNode.Name.Split('-')[0];
            int ID = int.Parse(treeStructure.SelectedNode.Name.Split('-')[1]);

            modele_doc = (ModeleDoc)Acces.Trouver_Element(Acces.type_MODELEDOC, ID);

            lblLibelle.Text = modele_doc.Libelle;
            lblEntete.Text = "MDL";
            lblRef.Text = modele_doc.Code.Replace("MDL-", "");
            OptActive.Checked = modele_doc.Actif;

            tabElement.TabPages[0].Enabled = false;
            tabElement.TabPages[1].Enabled = false;
            tabElement.TabPages[2].Enabled = false;
            if (type == "ZONE") {
                tabElement.SelectedIndex = 0;
                tabElement.TabPages[0].Enabled = true;
                lblConditionZone.Text = modele_doc.Condition;
            }
            if (type == "LIGNE") {
                tabElement.SelectedIndex = 1;
                tabElement.TabPages[1].Enabled = true;
                lblConditionLigne.Text = modele_doc.Condition;
            }
            if (type == "COLONNE") {
                tabElement.SelectedIndex = 2;
                tabElement.TabPages[2].Enabled = true;
                lblTexteColonne.Text = modele_doc.Contenu;
                lblBordureColonne.Text = modele_doc.Bordure;
                lstAlignementColonne.Text = modele_doc.Alignement.ToString();
                lblPct.Value = modele_doc.Taille;
            }
        }

        void Enregistrer()
        {
            if (treeStructure.SelectedNode == null)
            {
                MessageBox.Show("Sélectionner une zone, une ligne ou une colonne", "Erreur", MessageBoxButtons.OK);
                return;
            }

            var Libelle = lblLibelle.Text.Trim();
            var code = lblEntete.Text + "-" + lblRef.Text.ToUpper();
            if (lblRef.Text.Length == 0)
            {
                MessageBox.Show("Référence obligatoire", "Erreur", MessageBoxButtons.OK);
                return;
            }

            string type = treeStructure.SelectedNode.Name.Split('-')[0];
            int ID = int.Parse(treeStructure.SelectedNode.Name.Split('-')[1]);
            Type_Modele type_modele = Type_Modele.ZONE;
            modele_doc = (ModeleDoc)Acces.Trouver_Element(Acces.type_MODELEDOC, ID);

            if (type == "ZONE") { type_modele = Type_Modele.ZONE; }
            if (type == "LIGNE") { type_modele = Type_Modele.LIGNE; }
            if (type == "COLONNE") { type_modele = Type_Modele.COLONNE; }

            modele_doc.Acces = Acces;
            modele_doc.Code = code;
            modele_doc.Libelle = Libelle;
            modele_doc.Type_Modele = type_modele;
            modele_doc.Actif = OptActive.Checked;

            /*if (modele_doc.Type_Modele == Type_Modele.MODELE)
            {
                if (lstTypeModele.SelectedIndex < 0) { MessageBox.Show("Type de modèle ?"); return; }
                var p_ID = listeTypeModele[lstTypeModele.SelectedIndex].ID;
                modele_doc.Parent_ID = p_ID;
            }*/

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

            Acces.Enregistrer(Acces.type_MODELEDOC, modele_doc);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            Enregistrer();
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

        void Afficher_ListeValeur()
        {
            treeVariable.Nodes.Clear();

            TreeNode gNode = new TreeNode("Paramètres");
            gNode.Name = "?";
            gNode.Tag = 0;

            //-------------------------------------------------------
            //Paramètres porteur
            TreeNode NodPorteur = new TreeNode("Porteurs");
            NodPorteur.Name = "PORTEUR";
            NodPorteur.Tag = 1;
            AffichePropriétés(NodPorteur, "PORTEUR");
            gNode.Nodes.Add(NodPorteur);

            //-------------------------------------------------------
            //Paramètres porteur
            TreeNode NodPorteurCpl = new TreeNode("Porteurs complémentaires");
            NodPorteur.Name = "PORTEURCPL";
            NodPorteur.Tag = 1;
            AffichePropriétés(NodPorteurCpl, "PORTEURCPL");
            gNode.Nodes.Add(NodPorteurCpl);

            //-------------------------------------------------------
            //Paramètres Fiche de commande
            TreeNode NodFC = new TreeNode("Fiches de commande");
            NodFC.Name = "FICHE_COMMANDE";
            NodFC.Tag = 1;
            AffichePropriétés(NodFC, "FICHE_COMMANDE");
            gNode.Nodes.Add(NodFC);

            //-------------------------------------------------------
            //Paramètres Ligne de commande
            TreeNode NodLC = new TreeNode("Lignes de commande");
            NodLC.Name = "LIGNE_COMMANDE";
            NodLC.Tag = 1;
            AffichePropriétés(NodLC, "LIGNE_COMMANDE");
            gNode.Nodes.Add(NodLC);

            //-------------------------------------------------------
            //Paramètres Engagements juridiques
            TreeNode NodEJ = new TreeNode("Engagements juridiques");
            NodEJ.Name = "DECISION";
            NodEJ.Tag = 1;
            AffichePropriétés(NodEJ, "DECISION");
            gNode.Nodes.Add(NodEJ);

            //-------------------------------------------------------
            //Paramètres Echéances
            TreeNode NodEch = new TreeNode("Echéances");
            NodEch.Name = "ECHEANCE";
            NodEch.Tag = 1;
            AffichePropriétés(NodEch, "ECHEANCE");
            gNode.Nodes.Add(NodEch);

            //-------------------------------------------------------
            //Paramètres Liquidation
            TreeNode NodLq = new TreeNode("Liquidations");
            NodLq.Name = "LIQUIDATION";
            NodLq.Tag = 1;
            AffichePropriétés(NodLq, "LIQUIDATION");
            gNode.Nodes.Add(NodLq);

            //-------------------------------------------------------
            //Paramètres Ordres de paiement
            TreeNode NodOP = new TreeNode("Ordres de paiement");
            NodOP.Name = "ORDRE_PAIEMENT";
            NodOP.Tag = 1;
            AffichePropriétés(NodOP, "ORDRE_PAIEMENT");
            gNode.Nodes.Add(NodOP);

            gNode.Expand();
            treeVariable.Nodes.Add(gNode);
        }

        void AffichePropriétés(TreeNode Nod, string mClasse)
        {

            switch (mClasse.ToUpper().Trim())
            {
                case "USER":
                    {
                        //Recherche la liste des propriétés de la classe
                        Utilisateur user = new Utilisateur();
                        foreach (string str in user.ListeAttribut)
                        {
                            string libelle = Acces.Trouver_Attribut_Libelle(str);
                            TreeNode nod = new TreeNode(libelle);
                            nod.Name = Acces.type_UTILISATEUR.Code + "_" + str;
                            Nod.Nodes.Add(nod);
                        }
                        break;
                    }
                case "PORTEUR":
                    {
                        //Recherche la liste des propriétés de la classe
                        Porteur Prt = new Porteur();
                        foreach (string str in Prt.ListeAttribut)
                        {
                            string libelle = Acces.Trouver_Attribut_Libelle(str);
                            TreeNode nod = new TreeNode(libelle);
                            nod.Name = Acces.type_PORTEUR.Code + "_" + str;
                            Nod.Nodes.Add(nod);
                        }
                        break;
                    }
                case "FICHE_COMMANDE":
                    {
                        //Recherche la liste des propriétés de la classe
                        Fiche Fic = new Fiche();
                        foreach (string str in Fic.ListeAttribut)
                        {
                            string libelle = Acces.Trouver_Attribut_Libelle(str);
                            TreeNode nod = new TreeNode(libelle);
                            nod.Name = Acces.type_FICHE.Code + "_" + str;
                            Nod.Nodes.Add(nod);
                        }
                        break;
                    }
                case "LIGNE_COMMANDE":
                    {
                        //Recherche la liste des propriétés de la classe
                        Fiche_Ligne fcl = new Fiche_Ligne();
                        foreach (string str in fcl.ListeAttribut)
                        {
                            string libelle = Acces.Trouver_Attribut_Libelle(str);
                            TreeNode nod = new TreeNode(libelle);
                            nod.Name = Acces.type_LIGNE.Code + "_" + str;
                            Nod.Nodes.Add(nod);
                        }
                        break;
                    }
                case "DECISION":
                    {
                        /* 'Recherche la liste des propriétés de la classe
                 Dim cls As New mdl_execution.Decision
                 For Each P As System.Reflection.PropertyInfo In cls.GetType().GetProperties
                     Dim Nd As New TreeNode(P.Name)
                     Nd.Name = "EJ_" & P.Name.ToUpper
                     Nod.Nodes.Add(Nd)
                 Next*/
                        break;
                    }
                case "ECHEANCE":
                    {
                        /* 'Recherche la liste des propriétés de la classe
                 Dim cls As New mdl_execution.Echéance
                 For Each P As System.Reflection.PropertyInfo In cls.GetType().GetProperties
                     Dim Nd As New TreeNode(P.Name)
                     Nd.Name = "ECHEANCE_" & P.Name.ToUpper
                     Nod.Nodes.Add(Nd)
                 Next*/
                        break;
                    }
                case "LIQUIDATION":
                    {
                        /*'Recherche la liste des propriétés de la classe
                Dim cls As New mdl_execution.Liquidation
                For Each P As System.Reflection.PropertyInfo In cls.GetType().GetProperties
                    Dim Nd As New TreeNode(P.Name)
                    Nd.Name = "LIQUIDATION_" & P.Name.ToUpper
                    Nod.Nodes.Add(Nd)
                Next*/
                        break;
                    }
                case "ORDRE_PAIEMENT":
                    {
                        /*'Recherche la liste des propriétés de la classe
                 Dim cls As New mdl_execution.Ordre_Paiement
                 For Each P As System.Reflection.PropertyInfo In cls.GetType().GetProperties
                     Dim Nd As New TreeNode(P.Name)
                     Nd.Name = "ORDRE_PAIEMENT_" & P.Name.ToUpper
                     Nod.Nodes.Add(Nd)
                 Next*/
                        break;
                    }
            }
        }
    }
}
