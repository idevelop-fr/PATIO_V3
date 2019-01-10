using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;
using WeifenLuo.WinFormsUI.Docking;
using PATIO.CAPA.Interfaces;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlListeProcessus : UserControl
    {
        /// <summary>
        /// Définition des paramètres publics
        /// </summary>
        public AccesNet Acces;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DP;

        public string Chemin;

        public List<Process> ListeProcessus;
        public List<Process> lProcessus;
        public Process processus;

        public ctrlConsole Console;

        /// <summary>
        /// Définition des paramètres locaux
        /// </summary>
        TreeNode ndTemp = new TreeNode();

        /// <summary>
        /// Procédure d'initialisation standard du composant
        /// </summary>
        public ctrlListeProcessus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Procédure d'initialisation paramétrée du composant
        /// </summary>
        void Initialiser()
        {
            /*imageList1.Images.Add(PATIO.Properties.Resources.suivant);
            imageList1.Images.Add(PATIO.Properties.Resources.Processus);
            imageList1.Images.Add(PATIO.Properties.Resources.Processus_sous);*/
        }

        /// <summary>
        /// Affichage de la liste des processus
        /// </summary>
        public void Afficher_ListeProcessus()
        {
            List<int> liste = new List<int>();

            lstProcessus.Nodes.Clear();

            //Recherche de la liste des processus
            ListeProcessus = (List<Process>)Acces.Remplir_ListeElement(Acces.type_PROCESSUS, "");
            ListeProcessus.Sort();

            string txt = lblRecherche.Text.Trim().ToUpper();
            int n = 0;
            foreach (var p in ListeProcessus)
            {
                TreeNode T = new TreeNode(p.Libelle);
                T.Name = p.ID.ToString();
                T.ForeColor = (p.Actif) ? Color.Black : Color.Red;
                T.ImageIndex = Donner_IndexImage(p.Type_Processus);
                T.ToolTipText = p.Code + " (" + p.ID + ")";
                if (txt.Length > 0)
                {
                    if (p.Libelle.ToUpper().Contains(txt) || p.Code.ToUpper().Contains(txt))
                    {
                        bool ok = true;

                        if(ok)
                        {
                            lstProcessus.Nodes.Add(T);
                            liste.Add(p.ID);
                            n++;
                        }
                    }
                }
                else
                {
                    bool ok = true;

                    if (ok)
                    {
                        lstProcessus.Nodes.Add(T);
                        liste.Add(p.ID);
                        n++;
                    }
                }
            }

            lblNb.Text = "Nb : " + n.ToString();

            //Repositionnement des éléments selon la hiérarchie
            Repositionner(liste);

            foreach(TreeNode nd in lstProcessus.Nodes) { nd.Expand(); }
        }

        /// <summary>
        /// Repositionnement des processus dans une hiérarchie
        /// </summary>
        void Repositionner(List<int> liste)
        {
            //Placement des objectifs/sous-objectifs
            List<Lien> ListeLienSysteme = Acces.Remplir_ListeLienSYSTEME(Acces.type_PROCESSUS);
            ListeLienSysteme.Sort();

            //On balaye la liste des processus
            //Si un lien existe,
            //on recherche la position des 2 processus
            //On déplace le fils sous le parent
            foreach (Lien p in ListeLienSysteme)
            {
                TreeNode[] Nod1 = lstProcessus.Nodes.Find(p.Element1_ID.ToString(), true);
                TreeNode[] Nod2 = lstProcessus.Nodes.Find(p.Element2_ID.ToString(), true);

                if (Nod1.Count() > 0 && Nod2.Count() > 0)
                {
                    TreeNode parent = Nod1[0];
                    TreeNode Element = Nod2[0];

                    if (parent.Name == Element.Name) { break; }
                    Element.Tag = p;

                    //Element.Remove();
                    lstProcessus.Nodes.Remove(Element);
                    parent.Nodes.Add(Element);
                }
                else
                {
                    if (p.Element0_ID > 0)
                    { /*Console.Ajouter("[Move processus] Erreur Lien" + p.ID);*/ }
                    else { if (p.Element0_Code.Length > 0) { Console.Ajouter("[Erreur Lien] Id : " + p.ID); } }
                }
            }
        }

        /// <summary>
        /// Renvoie l'image associée au type de processus
        /// </summary>
        int Donner_IndexImage(TypeProcessus t)
        {
            if (t == TypeProcessus.DOSSIER) { return 1; }
            if (t == TypeProcessus.GROUPE) { return 2; }
            if (t == TypeProcessus.PROCESSUS) { return 3; }
            return 0;
        }

        /// <summary>
        /// Procédure déclenchée lors de la création d'une processus
        /// </summary>
        private void btnCréerProcessus_Click(object sender, EventArgs e)
        {
            Ajouter_Processus();
        }

        /// <summary>
        /// Création d'un sous-processus par l'intermédiaire de la fiche processus
        /// </summary>
        void Ajouter_Processus()
        {
            Console.Ajouter("[AJOUT PROCESSUS]");
            frmProcessus f = new frmProcessus();
            f.Acces = Acces;
            f.Creation = true;

            f.processus = new Process();
            f.processus.Code = "PRO-";
            f.processus.Actif = true;
            f.processusParent = null;

            f.Initialiser();

            if(f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeProcessus();
            }
        }

        /// <summary>
        /// Procédure de création d'une sous-processus
        /// Un lien est créé
        /// </summary>
        private void BtnAjouterSousProcessus_Click(object sender, EventArgs e)
        {
            Ajouter_SousProcessus();
        }

        /// <summary>
        /// Création d'une sous-processus par l'intermédiaire de la fiche processus
        /// </summary>
        void Ajouter_SousProcessus()
        {
            Console.Ajouter("[AJOUT SOUS-PROCESSUS");
            //Recherche du code du parent pour optimiser le codage des processus
            if (lstProcessus.SelectedNode is null)
            {
                MessageBox.Show("Vous devez sélectionner un processus.", "Erreur");
                return;
            }

            frmProcessus f = new frmProcessus();
            f.Acces = Acces;
            f.Creation = true;

            f.processus = new Process();
            f.processus.Code = "PRO-" + processus.Code;

            f.processus.Actif = true;

            f.processusParent = (Process)Acces.Trouver_Element(Acces.type_PROCESSUS, int.Parse(lstProcessus.SelectedNode.Name));
            f.processus.Type_Processus = TypeProcessus.GROUPE;
            if(f.processusParent.Type_Processus == TypeProcessus.GROUPE) { f.processus.Type_Processus = TypeProcessus.PROCESSUS; }

            Console.Ajouter("Processus parent : " + f.processusParent.Code);

            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                Afficher_ListeProcessus();

                TreeNode[] liste = lstProcessus.Nodes.Find(f.processusParent.ID.ToString(), true);
                if(liste.Length>0) { liste[0].Expand(); lstProcessus.SelectedNode = liste[0];  }
            }
        }

        /// <summary>
        /// Procédure de suppression d'une processus ou sous-processus
        /// </summary>
        private void BtnSupprimerProcessus_Click(object sender, EventArgs e)
        {
            SupprimerProcessus();
        }

        /// <summary>
        /// Suppression d'une processus ou sous-processus
        /// </summary>
        void SupprimerProcessus()
        {
            if (lstProcessus.SelectedNode != null)
            {
                var Id = Int32.Parse(lstProcessus.SelectedNode.Name);
                Acces.Supprimer_Element(Acces.type_PROCESSUS, (Process) Acces.Trouver_Element(Acces.type_PROCESSUS, Id));

                lstProcessus.Nodes.Remove(lstProcessus.SelectedNode);
            }
        }

        /// <summary>
        /// Procédure de modification d'une processus ou sous-processus
        /// </summary>
        private void BtnModifierProcessus_Click(object sender, EventArgs e)
        {
            Modifier_Processus();
        }

        /// <summary>
        /// Modiication d'une processus ou sous-processus par l'intermédiaire de la fiche processus
        /// </summary>
        public void Modifier_Processus()
        {
            if (processus == null) { return; }

            Console.Ajouter("[MODIFICATION PROCESSUS]");

            frmProcessus f = new frmProcessus();
            f.Acces = Acces;
            f.Creation = false;
            f.processus = processus;

            f.Initialiser();

            if (f.ShowDialog() == DialogResult.OK)
            {
                processus = f.processus;
                lstProcessus.SelectedNode.Text = processus.Libelle;
                lstProcessus.SelectedNode.ImageIndex = Donner_IndexImage(processus.Type_Processus);
                lstProcessus.SelectedNode.ToolTipText = processus.Code + " ( " + processus.ID.ToString() + ")";

            }
        }

        /// <summary>
        /// Procédure déclenchée par double clic pour la modification d'un processus ou sous-processus
        /// </summary>
        private void lstProcessus_DoubleClick(object sender, EventArgs e)
        {
            Modifier_Processus();
        }

        /// <summary>
        /// Procédure déclenchée pour l'ctualisation de la liste des processus
        /// </summary>
        private void BtnActualiserProcessus_Click(object sender, EventArgs e)
        {
            Afficher_ListeProcessus();
        }

        /// <summary>
        /// Recharge les informations et affiche la liste deProcessuss processus sous forme d'une hiérarchie
        /// </summary>
        void Actualiser()
        {
            Afficher_ListeProcessus();

            TreeNode[] Nod = lstProcessus.Nodes.Find(processus.ID.ToString(), true);
            if (Nod.Length > 0) { lstProcessus.SelectedNode = Nod[0]; Nod[0].EnsureVisible(); }
        }

        /// <summary>
        /// Procédure déclenchée au début d'un drag and drop
        /// </summary>
        private void lstProcessus_MouseDown(object sender, MouseEventArgs e)
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

        /// <summary>
        /// Procédure déclenchée en cours d'un drag and drop
        /// </summary>
        private void lstProcessus_DragOver(object sender, DragEventArgs e)
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

        /// <summary>
        /// Procédure déclenchée en fin d'un drag and drop
        /// </summary>
        private void lstProcessus_DragDrop(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the screen point.
            System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);

            // Convert to a point in the TreeView's coordinate system.
            pt = tree.PointToClient(pt);

            // Get the node underneath the mouse.
            TreeNode NodDest = tree.GetNodeAt(pt);
            TreeNode nodSrc = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (NodDest == nodSrc) { return; }//Système anti-bouclage

            //Prise en compte du changement en base
            //Recherche d'un lien du NodSrc
            if (!(nodSrc.Tag is null))
            { Acces.Supprimer_Lien((Lien)nodSrc.Tag); Console.Ajouter("Suppression du lien"); }
            else { Console.Ajouter("Pas de lien à supprimer"); }

            //Création du lien
            Lien p = new Lien() { Acces = Acces };
            p.Element0_Type = Acces.type_PLAN.ID; //SYSTEME
            p.Element0_ID = 1; //SYSTEME
            p.Element0_Code = "SYSTEME"; //SYSTEME
            p.Element1_Type = Acces.type_PROCESSUS.ID;
            p.Element1_ID = int.Parse(NodDest.Name);
            p.Element1_Code = ((Process)Acces.Trouver_Element(Acces.type_PROCESSUS, p.Element1_ID)).Code;
            p.Element2_Type = Acces.type_PROCESSUS.ID;
            p.Element2_ID = int.Parse(nodSrc.Name);
            p.Element2_Code = ((Process)Acces.Trouver_Element(Acces.type_PROCESSUS, p.Element2_ID)).Code;
            p.ordre = p.Donner_Ordre() + 1;

            p.Ajouter();
            Acces.Ajouter_Lien(p);
            Console.Ajouter("Création du lien : " + p.ID);

            //Afficher_ListeProcessus();
            TreeNode nd = new TreeNode();
            nd = (TreeNode)nodSrc.Clone();
            NodDest.Nodes.Add(nd);
            lstProcessus.SelectedNode = nd;

            TreeNode[] Nods = lstProcessus.Nodes.Find(nodSrc.Name.ToString(), true);

            try { Nods[0].Remove(); } catch { }
        }

        /// <summary>
        /// Procédure déclenchée lors de la validation d'une recherche
        /// </summary>
        private void lblRecherche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            { Afficher_ListeProcessus(); }
        }

        /// <summary>
        /// Procédure permettant de déterminer la liste des éléments cochés
        /// </summary>
        public void Trouver_Selection()
        {
            lProcessus = new List<Process>();
            foreach (TreeNode n in lstProcessus.Nodes)
            {
                if (n.Checked) { lProcessus.Add((Process)Acces.Trouver_Element(Acces.type_PROCESSUS, int.Parse(n.Name))); }
                Explorer(n);
            }
        }

        /// <summary>
        /// Sous-procédure de recherche des éléments cochés
        /// </summary>
        void Explorer(TreeNode nod)
        {
            foreach (TreeNode n in nod.Nodes)
            {
                if (n.Checked) { lProcessus.Add((Process)Acces.Trouver_Element(Acces.type_PROCESSUS, int.Parse(n.Name))); }
                if (n.Nodes.Count > 0) { Explorer(n); }
            }
        }

        /// <summary>
        /// Procédure déclenchée pour la suppression d'un lien
        /// Ceci permet de ramener au niveau de base un élément mis dans une hiérarchie
        /// </summary>
        private void MenuSupprimer_Lien_Click(object sender, EventArgs e)
        {
            Supprimer_Lien();
        }

        /// <summary>
        /// Suppression du lien hiérarchique
        /// </summary>
        void Supprimer_Lien()
        {
            if (lstProcessus.SelectedNode is null) { return; }

            if (lstProcessus.SelectedNode.Parent is null) { return; }

            List<Lien> ListeLienSysteme = Acces.Remplir_ListeLienSYSTEME(Acces.type_PROCESSUS, lstProcessus.SelectedNode.Parent.Name, lstProcessus.SelectedNode.Name);

            foreach (Lien ln in ListeLienSysteme)
            {
                ln.Acces = Acces;
                ln.Supprimer();
                Acces.Supprimer_Lien(ln);
            }

            Afficher_ListeProcessus();
        }

        /// <summary>
        /// Procédure déclenchée lors d'un clic sur un élément de la liste
        /// Permet de déterminer le processus sélectionnée
        /// </summary>
        private void lstProcessus_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = int.Parse(lstProcessus.SelectedNode.Name);

            processus = (Process)Acces.Trouver_Element(Acces.type_PROCESSUS, id);
        }

    }
}