namespace PATIO.CAPA.Interfaces
{
    partial class ctrlProjetProcessus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlProjetProcessus));
            this.panel1 = new System.Windows.Forms.Panel();
            this.treePhase = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjouterIteration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjouterPlanif = new System.Windows.Forms.ToolStripButton();
            this.btnAjouter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModifierPlan = new System.Windows.Forms.ToolStripButton();
            this.btnDesactiverPlan = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerPlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlProjet_01_Demarrage1 = new ctrlProjet_01_Demarrage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlProjet_Iteration1 = new ctrlProjet_Iteration();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrlProjet_02_Planification1 = new ctrlProjet_02_Planification();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ctrlProjet_03_Execution1 = new ctrlProjet_03_Execution();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ctrlProjet_04_Surveillance1 = new ctrlProjet_04_Surveillance();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ctrlProjet_05_Cloture1 = new ctrlProjet_05_Cloture();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treePhase);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 579);
            this.panel1.TabIndex = 11;
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
            this.treePhase.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode9,
            treeNode10});
            this.treePhase.SelectedImageIndex = 0;
            this.treePhase.Size = new System.Drawing.Size(312, 554);
            this.treePhase.TabIndex = 12;
            this.treePhase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePhase_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_green.gif");
            this.imageList1.Images.SetKeyName(1, "btn_carre_demarrage.png");
            this.imageList1.Images.SetKeyName(2, "btn_carre_iteration.png");
            this.imageList1.Images.SetKeyName(3, "btn_carre_planif.png");
            this.imageList1.Images.SetKeyName(4, "btn_carre_execution.png");
            this.imageList1.Images.SetKeyName(5, "btn_carre_surveillance.png");
            this.imageList1.Images.SetKeyName(6, "btn_carre_cloture.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnAjouterIteration,
            this.toolStripSeparator17,
            this.btnAjouterPlanif,
            this.btnAjouter,
            this.toolStripButton8,
            this.toolStripSeparator4,
            this.btnModifierPlan,
            this.btnDesactiverPlan,
            this.btnSupprimerPlan,
            this.toolStripSeparator2,
            this.toolStripSeparator16});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(312, 25);
            this.toolStrip1.TabIndex = 11;
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
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAjouterPlanif
            // 
            this.btnAjouterPlanif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouterPlanif.Image = global::PATIO.Properties.Resources.btn_carre_planif;
            this.btnAjouterPlanif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouterPlanif.Name = "btnAjouterPlanif";
            this.btnAjouterPlanif.Size = new System.Drawing.Size(23, 22);
            this.btnAjouterPlanif.Text = "toolStripButton7";
            // 
            // btnAjouter
            // 
            this.btnAjouter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouter.Image = global::PATIO.Properties.Resources.btn_carre_execution;
            this.btnAjouter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(23, 22);
            this.btnAjouter.Text = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::PATIO.Properties.Resources.btn_carre_surveillance;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // btnDesactiverPlan
            // 
            this.btnDesactiverPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDesactiverPlan.Image = global::PATIO.Properties.Resources.case_a_cocher;
            this.btnDesactiverPlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDesactiverPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesactiverPlan.Name = "btnDesactiverPlan";
            this.btnDesactiverPlan.Size = new System.Drawing.Size(23, 22);
            this.btnDesactiverPlan.Text = "Activer/Désactiver";
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
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(312, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 579);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(315, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(482, 554);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlProjet_01_Demarrage1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(474, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Démarrage";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlProjet_01_Demarrage1
            // 
            this.ctrlProjet_01_Demarrage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_01_Demarrage1.Location = new System.Drawing.Point(3, 3);
            this.ctrlProjet_01_Demarrage1.Name = "ctrlProjet_01_Demarrage1";
            this.ctrlProjet_01_Demarrage1.Size = new System.Drawing.Size(468, 522);
            this.ctrlProjet_01_Demarrage1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlProjet_Iteration1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(474, 528);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Itération";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlProjet_Iteration1
            // 
            this.ctrlProjet_Iteration1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_Iteration1.Location = new System.Drawing.Point(3, 3);
            this.ctrlProjet_Iteration1.Name = "ctrlProjet_Iteration1";
            this.ctrlProjet_Iteration1.Size = new System.Drawing.Size(468, 522);
            this.ctrlProjet_Iteration1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlProjet_02_Planification1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(474, 528);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Planification";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctrlProjet_02_Planification1
            // 
            this.ctrlProjet_02_Planification1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_02_Planification1.Location = new System.Drawing.Point(0, 0);
            this.ctrlProjet_02_Planification1.Name = "ctrlProjet_02_Planification1";
            this.ctrlProjet_02_Planification1.Size = new System.Drawing.Size(474, 528);
            this.ctrlProjet_02_Planification1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ctrlProjet_03_Execution1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(474, 528);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Exécution";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ctrlProjet_03_Execution1
            // 
            this.ctrlProjet_03_Execution1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_03_Execution1.Location = new System.Drawing.Point(0, 0);
            this.ctrlProjet_03_Execution1.Name = "ctrlProjet_03_Execution1";
            this.ctrlProjet_03_Execution1.Size = new System.Drawing.Size(474, 528);
            this.ctrlProjet_03_Execution1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ctrlProjet_04_Surveillance1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(474, 528);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Surveillance";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ctrlProjet_04_Surveillance1
            // 
            this.ctrlProjet_04_Surveillance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_04_Surveillance1.Location = new System.Drawing.Point(0, 0);
            this.ctrlProjet_04_Surveillance1.Name = "ctrlProjet_04_Surveillance1";
            this.ctrlProjet_04_Surveillance1.Size = new System.Drawing.Size(474, 528);
            this.ctrlProjet_04_Surveillance1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ctrlProjet_05_Cloture1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(474, 528);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Cloture";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ctrlProjet_05_Cloture1
            // 
            this.ctrlProjet_05_Cloture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_05_Cloture1.Location = new System.Drawing.Point(0, 0);
            this.ctrlProjet_05_Cloture1.Name = "ctrlProjet_05_Cloture1";
            this.ctrlProjet_05_Cloture1.Size = new System.Drawing.Size(474, 528);
            this.ctrlProjet_05_Cloture1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator7,
            this.toolStripSeparator8,
            this.toolStripButton6,
            this.toolStripSeparator10,
            this.toolStripTextBox1,
            this.toolStripSeparator12});
            this.toolStrip2.Location = new System.Drawing.Point(315, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(482, 25);
            this.toolStrip2.TabIndex = 14;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::PATIO.Properties.Resources.btn_ajouter;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Créer";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Modifier";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::PATIO.Properties.Resources.case_a_cocher;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Activer/Désactiver";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Supprimer";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::PATIO.Properties.Resources.btn_maj;
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Actualiser";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // ctrlProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlProjet";
            this.Size = new System.Drawing.Size(797, 579);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treePhase;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAjouterIteration;
        private System.Windows.Forms.ToolStripButton btnModifierPlan;
        private System.Windows.Forms.ToolStripButton btnDesactiverPlan;
        private System.Windows.Forms.ToolStripButton btnSupprimerPlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton btnAjouterPlanif;
        private System.Windows.Forms.ToolStripButton btnAjouter;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private ctrlProjet_01_Demarrage ctrlProjet_01_Demarrage1;
        private ctrlProjet_02_Planification ctrlProjet_02_Planification1;
        private ctrlProjet_03_Execution ctrlProjet_03_Execution1;
        private ctrlProjet_04_Surveillance ctrlProjet_04_Surveillance1;
        private ctrlProjet_05_Cloture ctrlProjet_05_Cloture1;
        private ctrlProjet_Iteration ctrlProjet_Iteration1;
    }
}
