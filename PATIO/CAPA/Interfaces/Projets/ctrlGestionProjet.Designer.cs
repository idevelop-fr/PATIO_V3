namespace PATIO.CAPA.Interfaces
{
    partial class ctrlGestionProjet
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Démarrage");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Planification");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Exécution");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Surveillance");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Iteration 01", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Planification");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Exécution");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Surveillance");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Iteration 02", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Clôture");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Processus", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Finances");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Documents");
            this.panel1 = new System.Windows.Forms.Panel();
            this.treePhase = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjouterIteration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModifierPlan = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerPlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAfficherProcessus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDemarrage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.treeDemarrage = new System.Windows.Forms.TreeView();
            this.tabIteration = new System.Windows.Forms.TabPage();
            this.treeIteration = new System.Windows.Forms.TreeView();
            this.tabCloture = new System.Windows.Forms.TabPage();
            this.treeCloture = new System.Windows.Forms.TreeView();
            this.tabDonnee = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstDonnee = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabFinance = new System.Windows.Forms.TabPage();
            this.tabDocumentation = new System.Windows.Forms.TabPage();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjouterFinance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModifierFinance = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerFinance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.treeFinance = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabDemarrage.SuspendLayout();
            this.tabIteration.SuspendLayout();
            this.tabCloture.SuspendLayout();
            this.tabDonnee.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabFinance.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treePhase);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 446);
            this.panel1.TabIndex = 0;
            // 
            // treePhase
            // 
            this.treePhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePhase.ImageIndex = 0;
            this.treePhase.ImageList = this.imageList1;
            this.treePhase.Location = new System.Drawing.Point(0, 25);
            this.treePhase.Name = "treePhase";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Nœud0";
            treeNode1.Tag = "DEMARRAGE";
            treeNode1.Text = "Démarrage";
            treeNode2.ImageIndex = 3;
            treeNode2.Name = "Nœud4";
            treeNode2.Tag = "PLANIF";
            treeNode2.Text = "Planification";
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "Nœud5";
            treeNode3.Tag = "EXECUTION";
            treeNode3.Text = "Exécution";
            treeNode4.ImageIndex = 5;
            treeNode4.Name = "Nœud6";
            treeNode4.Tag = "SURVEILLANCE";
            treeNode4.Text = "Surveillance";
            treeNode5.ImageIndex = 2;
            treeNode5.Name = "Nœud3";
            treeNode5.Tag = "ITERATION";
            treeNode5.Text = "Iteration 01";
            treeNode6.ImageIndex = 3;
            treeNode6.Name = "Nœud9";
            treeNode6.Tag = "PLANIF";
            treeNode6.Text = "Planification";
            treeNode7.ImageIndex = 4;
            treeNode7.Name = "Nœud10";
            treeNode7.Tag = "EXECUTION";
            treeNode7.Text = "Exécution";
            treeNode8.ImageIndex = 5;
            treeNode8.Name = "Nœud11";
            treeNode8.Tag = "SURVEILLANCE";
            treeNode8.Text = "Surveillance";
            treeNode9.ImageIndex = 2;
            treeNode9.Name = "Nœud8";
            treeNode9.Tag = "ITERATION";
            treeNode9.Text = "Iteration 02";
            treeNode10.ImageIndex = 6;
            treeNode10.Name = "Nœud7";
            treeNode10.Tag = "CLOTURE";
            treeNode10.Text = "Clôture";
            treeNode11.Name = "Nœud0";
            treeNode11.Text = "Processus";
            treeNode12.Name = "Nœud1";
            treeNode12.Text = "Finances";
            treeNode13.Name = "Nœud2";
            treeNode13.Text = "Documents";
            this.treePhase.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            this.treePhase.SelectedImageIndex = 0;
            this.treePhase.Size = new System.Drawing.Size(221, 421);
            this.treePhase.TabIndex = 14;
            this.treePhase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePhase_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(18, 18);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnAjouterIteration,
            this.toolStripSeparator17,
            this.btnModifierPlan,
            this.btnSupprimerPlan,
            this.toolStripSeparator2,
            this.toolStripSeparator16,
            this.btnAfficherProcessus,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(221, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAjouterIteration
            // 
            this.btnAjouterIteration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouterIteration.Image = global::PATIO.Properties.Resources.btn_carre_iteration;
            this.btnAjouterIteration.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAjouterIteration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouterIteration.Name = "btnAjouterIteration";
            this.btnAjouterIteration.Size = new System.Drawing.Size(23, 22);
            this.btnAjouterIteration.Text = "Ajouter une itération";
            this.btnAjouterIteration.Click += new System.EventHandler(this.btnAjouterIteration_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // btnModifierPlan
            // 
            this.btnModifierPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierPlan.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierPlan.Name = "btnModifierPlan";
            this.btnModifierPlan.Size = new System.Drawing.Size(23, 22);
            this.btnModifierPlan.Text = "Modifier";
            // 
            // btnSupprimerPlan
            // 
            this.btnSupprimerPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerPlan.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerPlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerPlan.Name = "btnSupprimerPlan";
            this.btnSupprimerPlan.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerPlan.Text = "Supprimer";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAfficherProcessus
            // 
            this.btnAfficherProcessus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAfficherProcessus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAfficherProcessus.Image = global::PATIO.Properties.Resources.parametre;
            this.btnAfficherProcessus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAfficherProcessus.Name = "btnAfficherProcessus";
            this.btnAfficherProcessus.Size = new System.Drawing.Size(23, 22);
            this.btnAfficherProcessus.Text = "Afficher le processus correspondant à l\'étape";
            this.btnAfficherProcessus.Click += new System.EventHandler(this.btnAfficherProcessus_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(221, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 446);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Location = new System.Drawing.Point(226, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(693, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDemarrage);
            this.tabControl.Controls.Add(this.tabIteration);
            this.tabControl.Controls.Add(this.tabCloture);
            this.tabControl.Controls.Add(this.tabDonnee);
            this.tabControl.Controls.Add(this.tabFinance);
            this.tabControl.Controls.Add(this.tabDocumentation);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(226, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(693, 421);
            this.tabControl.TabIndex = 3;
            // 
            // tabDemarrage
            // 
            this.tabDemarrage.Controls.Add(this.panel2);
            this.tabDemarrage.Controls.Add(this.splitter2);
            this.tabDemarrage.Controls.Add(this.treeDemarrage);
            this.tabDemarrage.Location = new System.Drawing.Point(4, 22);
            this.tabDemarrage.Name = "tabDemarrage";
            this.tabDemarrage.Padding = new System.Windows.Forms.Padding(3);
            this.tabDemarrage.Size = new System.Drawing.Size(685, 395);
            this.tabDemarrage.TabIndex = 0;
            this.tabDemarrage.Text = "Démarrage";
            this.tabDemarrage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(264, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 389);
            this.panel2.TabIndex = 2;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(261, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 389);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // treeDemarrage
            // 
            this.treeDemarrage.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeDemarrage.Location = new System.Drawing.Point(3, 3);
            this.treeDemarrage.Name = "treeDemarrage";
            this.treeDemarrage.Size = new System.Drawing.Size(258, 389);
            this.treeDemarrage.TabIndex = 0;
            // 
            // tabIteration
            // 
            this.tabIteration.Controls.Add(this.treeIteration);
            this.tabIteration.Location = new System.Drawing.Point(4, 22);
            this.tabIteration.Name = "tabIteration";
            this.tabIteration.Size = new System.Drawing.Size(685, 395);
            this.tabIteration.TabIndex = 7;
            this.tabIteration.Text = "Itération";
            this.tabIteration.UseVisualStyleBackColor = true;
            // 
            // treeIteration
            // 
            this.treeIteration.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeIteration.ImageIndex = 0;
            this.treeIteration.ImageList = this.imageList2;
            this.treeIteration.Location = new System.Drawing.Point(0, 0);
            this.treeIteration.Name = "treeIteration";
            this.treeIteration.SelectedImageIndex = 0;
            this.treeIteration.Size = new System.Drawing.Size(258, 395);
            this.treeIteration.TabIndex = 1;
            // 
            // tabCloture
            // 
            this.tabCloture.Controls.Add(this.treeCloture);
            this.tabCloture.Location = new System.Drawing.Point(4, 22);
            this.tabCloture.Name = "tabCloture";
            this.tabCloture.Size = new System.Drawing.Size(685, 395);
            this.tabCloture.TabIndex = 4;
            this.tabCloture.Text = "Cloture";
            this.tabCloture.UseVisualStyleBackColor = true;
            // 
            // treeCloture
            // 
            this.treeCloture.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeCloture.Location = new System.Drawing.Point(0, 0);
            this.treeCloture.Name = "treeCloture";
            this.treeCloture.Size = new System.Drawing.Size(258, 395);
            this.treeCloture.TabIndex = 1;
            // 
            // tabDonnee
            // 
            this.tabDonnee.Controls.Add(this.panel3);
            this.tabDonnee.Location = new System.Drawing.Point(4, 22);
            this.tabDonnee.Name = "tabDonnee";
            this.tabDonnee.Size = new System.Drawing.Size(685, 395);
            this.tabDonnee.TabIndex = 5;
            this.tabDonnee.Text = "Données du projet";
            this.tabDonnee.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstDonnee);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 395);
            this.panel3.TabIndex = 0;
            // 
            // lstDonnee
            // 
            this.lstDonnee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDonnee.FormattingEnabled = true;
            this.lstDonnee.Location = new System.Drawing.Point(0, 19);
            this.lstDonnee.Name = "lstDonnee";
            this.lstDonnee.Size = new System.Drawing.Size(210, 376);
            this.lstDonnee.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liste des données de projet";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabFinance
            // 
            this.tabFinance.Controls.Add(this.panel4);
            this.tabFinance.Location = new System.Drawing.Point(4, 22);
            this.tabFinance.Name = "tabFinance";
            this.tabFinance.Size = new System.Drawing.Size(685, 395);
            this.tabFinance.TabIndex = 6;
            this.tabFinance.Text = "Données de finances";
            this.tabFinance.UseVisualStyleBackColor = true;
            // 
            // tabDocumentation
            // 
            this.tabDocumentation.Location = new System.Drawing.Point(4, 22);
            this.tabDocumentation.Name = "tabDocumentation";
            this.tabDocumentation.Size = new System.Drawing.Size(685, 395);
            this.tabDocumentation.TabIndex = 8;
            this.tabDocumentation.Text = "Documentation";
            this.tabDocumentation.UseVisualStyleBackColor = true;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.treeFinance);
            this.panel4.Controls.Add(this.toolStrip3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(226, 395);
            this.panel4.TabIndex = 15;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.btnAjouterFinance,
            this.toolStripSeparator5,
            this.btnModifierFinance,
            this.btnSupprimerFinance,
            this.toolStripSeparator6,
            this.toolStripSeparator7});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(226, 25);
            this.toolStrip3.TabIndex = 15;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAjouterFinance
            // 
            this.btnAjouterFinance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouterFinance.Image = global::PATIO.Properties.Resources.plus;
            this.btnAjouterFinance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAjouterFinance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouterFinance.Name = "btnAjouterFinance";
            this.btnAjouterFinance.Size = new System.Drawing.Size(23, 22);
            this.btnAjouterFinance.Text = "Ajouter une itération";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnModifierFinance
            // 
            this.btnModifierFinance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierFinance.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierFinance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierFinance.Name = "btnModifierFinance";
            this.btnModifierFinance.Size = new System.Drawing.Size(23, 22);
            this.btnModifierFinance.Text = "Modifier";
            // 
            // btnSupprimerFinance
            // 
            this.btnSupprimerFinance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerFinance.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerFinance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerFinance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerFinance.Name = "btnSupprimerFinance";
            this.btnSupprimerFinance.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerFinance.Text = "Supprimer";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // treeFinance
            // 
            this.treeFinance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFinance.ImageIndex = 0;
            this.treeFinance.ImageList = this.imageList2;
            this.treeFinance.Location = new System.Drawing.Point(0, 25);
            this.treeFinance.Name = "treeFinance";
            this.treeFinance.SelectedImageIndex = 0;
            this.treeFinance.Size = new System.Drawing.Size(226, 370);
            this.treeFinance.TabIndex = 16;
            // 
            // ctrlGestionProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlGestionProjet";
            this.Size = new System.Drawing.Size(919, 446);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabDemarrage.ResumeLayout(false);
            this.tabIteration.ResumeLayout(false);
            this.tabCloture.ResumeLayout(false);
            this.tabDonnee.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabFinance.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treePhase;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAjouterIteration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton btnModifierPlan;
        private System.Windows.Forms.ToolStripButton btnSupprimerPlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton btnAfficherProcessus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDemarrage;
        private System.Windows.Forms.TabPage tabCloture;
        private System.Windows.Forms.TreeView treeDemarrage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TreeView treeCloture;
        private System.Windows.Forms.TabPage tabDonnee;
        private System.Windows.Forms.TabPage tabFinance;
        private System.Windows.Forms.TabPage tabIteration;
        private System.Windows.Forms.TabPage tabDocumentation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstDonnee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeIteration;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView treeFinance;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnAjouterFinance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnModifierFinance;
        private System.Windows.Forms.ToolStripButton btnSupprimerFinance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}
