using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;
using PATIO.ADMIN.Classes;

namespace PATIO.ADMIN
{
    public partial class ctrlListeModeleDoc : UserControl
    {
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public List<ModeleDoc> ListeModeleDoc;
        public ctrlConsole Console;

        public int UserId;
        public string UserCode;

        public ctrlListeModeleDoc()
        {
            InitializeComponent();
        }

        public void Initialiser()
        {
            Afficher_ListeModeleDoc();
        }

        void Afficher_ListeModeleDoc()
        {
            lstModele.Nodes.Clear();
            List<int> liste = new List<int>();

            //Recherche de la liste des utilisateurs
            ListeModeleDoc = (List<ModeleDoc>)Acces.Remplir_ListeElement(Acces.type_MODELEDOC, "");

            int n = 0;
            foreach (var p in ListeModeleDoc)
            {
                TreeNode T = new TreeNode(p.Libelle);
                T.Name = p.ID.ToString();
                T.ForeColor = (p.Actif) ? Color.Black : Color.Red;

                string txt = lblRecherche.Text.Trim().ToUpper();
                if (txt.Length > 0)
                {
                    if (p.Libelle.ToUpper().Contains(txt))
                    {
                        lstModele.Nodes.Add(T);
                        liste.Add(p.ID);
                        n++;
                    }
                }
                else
                {
                    lstModele.Nodes.Add(T);
                    liste.Add(p.ID);
                    n++;
                }
            }
            lblNb.Text = "Nb : " + n.ToString();
        }

         private void BtnAjouterModeleDoc_Click(object sender, EventArgs e)
        {
            Ajouter_ModeleDoc();
        }

        void Ajouter_ModeleDoc()
        {
            var f = new frmModeleDoc();
            f.Acces = Acces;
            f.Creation = true;

            f.modele_doc = new ModeleDoc();
            f.modele_doc.Actif = true;

            f.Initialiser();

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                Afficher_ListeModeleDoc();
            }
        }

        private void BtnModifierModeleDoc_Click(object sender, EventArgs e)
        {
            Modifier_ModeleDoc();
        }

        void Modifier_ModeleDoc()
        {
            if (lstModele.SelectedNode != null)
            {
                var f = new frmUser();
                f.Acces = Acces;
                f.Creation = false;

                f.User =(Utilisateur) Acces.Trouver_Element(Acces.type_UTILISATEUR, int.Parse(lstModele.SelectedNode.Name));

                f.Initialise();

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    Afficher_ListeModeleDoc();
                }
            }
        }

        private void BtnSupprimerModeleDoc_Click(object sender, EventArgs e)
        {
            Supprimer_ModeleDoc();
        }

        void Supprimer_ModeleDoc()
        {
            if (lstModele.SelectedNode != null)
            {
                var Id = Int32.Parse(lstModele.SelectedNode.Name);
                Utilisateur user = Acces.Trouver_Utilisateur(Id);
                Acces.Supprimer_Element(Acces.type_UTILISATEUR, user);

                Afficher_ListeModeleDoc();
            }
        }

        private void BtnActualiserModeleDoc_Click(object sender, EventArgs e)
        {
            Acces.Charger_Element();
            Acces.Charger_Lien();
            Afficher_ListeModeleDoc();
        }

        private void lstModeleDoc_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the node underneath the mouse.
            TreeNode node = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = node;

            // Start the drag-and-drop operation with a cloned copy of the node.
            if (node != null && e.Button == MouseButtons.Right)
            {
                tree.DoDragDrop(node.Clone(), DragDropEffects.Copy);
            }
        }

        private void lstModeleDoc_DragOver(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Drag and drop denied by default.
            e.Effect = DragDropEffects.None;

            // Is it a valid format?
            if (e.Data.GetData(typeof(TreeNode)) != null)
            {
                // Get the screen point.
                System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);

                // Convert to a point in the TreeView's coordinate system.
                pt = tree.PointToClient(pt);

                // Is the mouse over a valid node?
                TreeNode node = tree.GetNodeAt(pt);

                if (node != null)
                {
                    e.Effect = DragDropEffects.Copy;
                    tree.SelectedNode = node;
                }
            }
        }

        private void lstModeleDoc_DragDrop(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the screen point.
            System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);

            // Convert to a point in the TreeView's coordinate system.
            pt = tree.PointToClient(pt);

            // Get the node underneath the mouse.
            TreeNode NodDest = tree.GetNodeAt(pt);

            // Add a child node.
            //node.Nodes.Add((TreeNode)e.Data.GetData(typeof(TreeNode)));

            // Show the newly added node if it is not already visible.
            //node.Expand();

            TreeNode nodSrc = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (NodDest.Name == nodSrc.Name) { return; }

            //Vérification du type de destination
            if (!(Acces.Trouver_Utilisateur(int.Parse(NodDest.Name.ToString())).TypeUtilisateur == TypeUtilisateur.DOSSIER))
            {
                MessageBox.Show("Un utilisateur (hors type DOSSIER) ne peut contenir d'autres utilisateurs", "Erreur", MessageBoxButtons.OK);
                return;
            }
            //Prise en compte du changement en base
            //Recherche d'un lien du NodSrc
            Lien k = Acces.Donner_LienParent(((Lien) nodSrc.Tag).ID);

            if (!(k is null)) //Suppression des liens existants pour le Prop 0 (SYSTEME)
            {
                k.Acces = Acces;
                k.Supprimer();
            }

            //Création du lien
            Lien p = new Lien();
            p.element1_type = Acces.type_UTILISATEUR.ID;
            p.element1_id = int.Parse(NodDest.Name);
            p.element1_code = Acces.Trouver_Utilisateur(p.element1_id).Code;
            p.element2_type = Acces.type_UTILISATEUR.ID;
            p.element1_id = int.Parse(nodSrc.Name);
            p.element2_code = Acces.Trouver_Utilisateur(p.element2_id).Code;
            p.element0_type = Acces.type_PLAN.ID;
            p.element0_id = 1; //SYSTEME
            p.ordre = p.Donner_Ordre() + 1;

            if (p.element1_id == p.element2_id) { return; } //Système anti-bouclage

            p.Ajouter();

            Acces.Ajouter_Lien(p);
            Afficher_ListeModeleDoc();

            TreeNode[] Nods = lstModele.Nodes.Find(nodSrc.Name.ToString(), true);

            lstModele.SelectedNode = Nods[0];
            Nods[0].EnsureVisible();
        }

        private void lstModeleDoc_DoubleClick(object sender, EventArgs e)
        {
            Modifier_ModeleDoc();
        }

        private void lblRecherche_TextChanged(object sender, EventArgs e)
        {
            Afficher_ListeModeleDoc();
        }
    }
}
