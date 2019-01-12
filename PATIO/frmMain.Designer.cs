namespace PATIO
{
    partial class frmMain
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.DP = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.timer_Connexion = new System.Windows.Forms.Timer(this.components);
            this.timer_Sauvegarde = new System.Windows.Forms.Timer(this.components);
            this.timer_Ouverture = new System.Windows.Forms.Timer(this.components);
            this.panelMenu = new System.Windows.Forms.Panel();
            this.expanderTablePanel1 = new WinFormsExpander.ExpanderTablePanel();
            this.Expander_Administration = new WinFormsExpander.Expander();
            this.treeAdmin = new System.Windows.Forms.TreeView();
            this.Expander_Fonction = new WinFormsExpander.Expander();
            this.treeFonction = new System.Windows.Forms.TreeView();
            this.BarreBtn = new System.Windows.Forms.ToolStrip();
            this.btnReduire = new System.Windows.Forms.ToolStripButton();
            this.Separ1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualiser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.imageListFonction = new System.Windows.Forms.ImageList(this.components);
            this.imageListAccueil = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPerso = new System.Windows.Forms.ToolStripDropDownButton();
            this.monCompteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesDroitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesPréférencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRecharger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAide = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuXWIKI = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuXWIKI_PRS = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuXWIKI_PlanAction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAide_Ligne = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCodeUser = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNom = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgrandir = new System.Windows.Forms.ToolStripButton();
            this.panelMenu.SuspendLayout();
            this.expanderTablePanel1.SuspendLayout();
            this.Expander_Administration.Content.SuspendLayout();
            this.Expander_Fonction.Content.SuspendLayout();
            this.BarreBtn.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DP
            // 
            this.DP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DP.Location = new System.Drawing.Point(265, 25);
            this.DP.Name = "DP";
            this.DP.Size = new System.Drawing.Size(597, 586);
            this.DP.TabIndex = 4;
            // 
            // timer_Connexion
            // 
            this.timer_Connexion.Interval = 10000;
            this.timer_Connexion.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer_Sauvegarde
            // 
            this.timer_Sauvegarde.Interval = 60000;
            this.timer_Sauvegarde.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.expanderTablePanel1);
            this.panelMenu.Controls.Add(this.BarreBtn);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(1);
            this.panelMenu.Size = new System.Drawing.Size(262, 611);
            this.panelMenu.TabIndex = 13;
            // 
            // expanderTablePanel1
            // 
            this.expanderTablePanel1.ColumnCount = 1;
            this.expanderTablePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expanderTablePanel1.Controls.Add(this.Expander_Administration, 0, 1);
            this.expanderTablePanel1.Controls.Add(this.Expander_Fonction, 0, 0);
            this.expanderTablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expanderTablePanel1.Location = new System.Drawing.Point(1, 26);
            this.expanderTablePanel1.MinimumSize = new System.Drawing.Size(0, 159);
            this.expanderTablePanel1.Name = "expanderTablePanel1";
            this.expanderTablePanel1.RowCount = 2;
            this.expanderTablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expanderTablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.expanderTablePanel1.Size = new System.Drawing.Size(260, 584);
            this.expanderTablePanel1.TabIndex = 1;
            // 
            // Expander_Administration
            // 
            this.Expander_Administration.AutoScroll = true;
            this.Expander_Administration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Expander_Administration.CollapseImage = ((System.Drawing.Image)(resources.GetObject("Expander_Administration.CollapseImage")));
            // 
            // Expander_Administration.Content
            // 
            this.Expander_Administration.Content.AutoScroll = true;
            this.Expander_Administration.Content.AutoScrollMinSize = new System.Drawing.Size(150, 50);
            this.Expander_Administration.Content.Controls.Add(this.treeAdmin);
            this.Expander_Administration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Expander_Administration.ExpandImage = ((System.Drawing.Image)(resources.GetObject("Expander_Administration.ExpandImage")));
            this.Expander_Administration.Header = "Administration";
            this.Expander_Administration.Location = new System.Drawing.Point(3, 287);
            this.Expander_Administration.MinimumSize = new System.Drawing.Size(0, 53);
            this.Expander_Administration.Name = "Expander_Administration";
            this.Expander_Administration.Size = new System.Drawing.Size(254, 294);
            this.Expander_Administration.TabIndex = 19;
            // 
            // treeAdmin
            // 
            this.treeAdmin.BackColor = System.Drawing.Color.MintCream;
            this.treeAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAdmin.Location = new System.Drawing.Point(0, 0);
            this.treeAdmin.Name = "treeAdmin";
            this.treeAdmin.Size = new System.Drawing.Size(252, 264);
            this.treeAdmin.TabIndex = 4;
            this.treeAdmin.DoubleClick += new System.EventHandler(this.treeAdmin_DoubleClick);
            // 
            // Expander_Fonction
            // 
            this.Expander_Fonction.AutoScroll = true;
            this.Expander_Fonction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Expander_Fonction.CollapseImage = ((System.Drawing.Image)(resources.GetObject("Expander_Fonction.CollapseImage")));
            // 
            // Expander_Fonction.Content
            // 
            this.Expander_Fonction.Content.AutoScroll = true;
            this.Expander_Fonction.Content.AutoScrollMinSize = new System.Drawing.Size(150, 50);
            this.Expander_Fonction.Content.Controls.Add(this.treeFonction);
            this.Expander_Fonction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Expander_Fonction.ExpandImage = ((System.Drawing.Image)(resources.GetObject("Expander_Fonction.ExpandImage")));
            this.Expander_Fonction.Header = "Fonctions";
            this.Expander_Fonction.Location = new System.Drawing.Point(3, 3);
            this.Expander_Fonction.MinimumSize = new System.Drawing.Size(0, 53);
            this.Expander_Fonction.Name = "Expander_Fonction";
            this.Expander_Fonction.Size = new System.Drawing.Size(254, 278);
            this.Expander_Fonction.TabIndex = 18;
            // 
            // treeFonction
            // 
            this.treeFonction.BackColor = System.Drawing.Color.Ivory;
            this.treeFonction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFonction.Location = new System.Drawing.Point(0, 0);
            this.treeFonction.Name = "treeFonction";
            this.treeFonction.Size = new System.Drawing.Size(252, 248);
            this.treeFonction.TabIndex = 3;
            this.treeFonction.DoubleClick += new System.EventHandler(this.treeFonction_DoubleClick);
            // 
            // BarreBtn
            // 
            this.BarreBtn.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.BarreBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReduire,
            this.Separ1,
            this.btnActualiser,
            this.toolStripSeparator2});
            this.BarreBtn.Location = new System.Drawing.Point(1, 1);
            this.BarreBtn.Name = "BarreBtn";
            this.BarreBtn.Size = new System.Drawing.Size(260, 25);
            this.BarreBtn.TabIndex = 0;
            this.BarreBtn.Text = "toolStrip2";
            // 
            // btnReduire
            // 
            this.btnReduire.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnReduire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReduire.Image = global::PATIO.Properties.Resources.fleche_gauche_vert;
            this.btnReduire.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReduire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReduire.Name = "btnReduire";
            this.btnReduire.Size = new System.Drawing.Size(23, 22);
            this.btnReduire.Text = "Réduire la barre de fonctions";
            this.btnReduire.Click += new System.EventHandler(this.btnReduire_Click);
            // 
            // Separ1
            // 
            this.Separ1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Separ1.Name = "Separ1";
            this.Separ1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActualiser
            // 
            this.btnActualiser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnActualiser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualiser.Image = global::PATIO.Properties.Resources.squares_2;
            this.btnActualiser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualiser.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(23, 22);
            this.btnActualiser.Text = "Actualiser les listes de fonctions";
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // imageListFonction
            // 
            this.imageListFonction.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListFonction.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListFonction.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListAccueil
            // 
            this.imageListAccueil.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListAccueil.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListAccueil.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(262, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 611);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.MenuPerso,
            this.MenuAide,
            this.toolStripSeparator4,
            this.lblCodeUser,
            this.toolStripSeparator5,
            this.lblNom,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.btnAgrandir});
            this.toolStrip1.Location = new System.Drawing.Point(265, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(597, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // MenuPerso
            // 
            this.MenuPerso.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuPerso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuPerso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monCompteToolStripMenuItem,
            this.mesDroitsToolStripMenuItem,
            this.mesPréférencesToolStripMenuItem,
            this.toolStripSeparator8,
            this.btnRecharger,
            this.toolStripSeparator9,
            this.quitterToolStripMenuItem});
            this.MenuPerso.Image = global::PATIO.Properties.Resources.utilisateur;
            this.MenuPerso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuPerso.Name = "MenuPerso";
            this.MenuPerso.Size = new System.Drawing.Size(29, 22);
            this.MenuPerso.Text = "toolStripDropDownButton1";
            // 
            // monCompteToolStripMenuItem
            // 
            this.monCompteToolStripMenuItem.Name = "monCompteToolStripMenuItem";
            this.monCompteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.monCompteToolStripMenuItem.Text = "Mon compte";
            // 
            // mesDroitsToolStripMenuItem
            // 
            this.mesDroitsToolStripMenuItem.Name = "mesDroitsToolStripMenuItem";
            this.mesDroitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mesDroitsToolStripMenuItem.Text = "Mes droits";
            // 
            // mesPréférencesToolStripMenuItem
            // 
            this.mesPréférencesToolStripMenuItem.Name = "mesPréférencesToolStripMenuItem";
            this.mesPréférencesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mesPréférencesToolStripMenuItem.Text = "Mes préférences";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
            // 
            // btnRecharger
            // 
            this.btnRecharger.Name = "btnRecharger";
            this.btnRecharger.Size = new System.Drawing.Size(180, 22);
            this.btnRecharger.Text = "Recharger";
            this.btnRecharger.Click += new System.EventHandler(this.btnRecharger_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(177, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // MenuAide
            // 
            this.MenuAide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuAide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuAide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuXWIKI,
            this.MenuXWIKI_PRS,
            this.MenuXWIKI_PlanAction,
            this.toolStripMenuItem2,
            this.MenuAide_Ligne});
            this.MenuAide.Image = global::PATIO.Properties.Resources.help;
            this.MenuAide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuAide.Name = "MenuAide";
            this.MenuAide.Size = new System.Drawing.Size(29, 22);
            this.MenuAide.Text = "toolStripDropDownButton1";
            // 
            // MenuXWIKI
            // 
            this.MenuXWIKI.BackColor = System.Drawing.Color.DarkGray;
            this.MenuXWIKI.Name = "MenuXWIKI";
            this.MenuXWIKI.Size = new System.Drawing.Size(153, 22);
            this.MenuXWIKI.Text = "XWIKI";
            // 
            // MenuXWIKI_PRS
            // 
            this.MenuXWIKI_PRS.Name = "MenuXWIKI_PRS";
            this.MenuXWIKI_PRS.Size = new System.Drawing.Size(153, 22);
            this.MenuXWIKI_PRS.Text = "PRS";
            this.MenuXWIKI_PRS.Click += new System.EventHandler(this.MenuXWIKI_PRS_Click);
            // 
            // MenuXWIKI_PlanAction
            // 
            this.MenuXWIKI_PlanAction.Name = "MenuXWIKI_PlanAction";
            this.MenuXWIKI_PlanAction.Size = new System.Drawing.Size(153, 22);
            this.MenuXWIKI_PlanAction.Text = "Plans d\'actions";
            this.MenuXWIKI_PlanAction.Click += new System.EventHandler(this.MenuXWIKI_PlanAction_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.DarkGray;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem2.Text = "Aide";
            // 
            // MenuAide_Ligne
            // 
            this.MenuAide_Ligne.Name = "MenuAide_Ligne";
            this.MenuAide_Ligne.Size = new System.Drawing.Size(153, 22);
            this.MenuAide_Ligne.Text = "Aide en ligne";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblCodeUser
            // 
            this.lblCodeUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCodeUser.Name = "lblCodeUser";
            this.lblCodeUser.Size = new System.Drawing.Size(58, 22);
            this.lblCodeUser.Text = "CodeUser";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // lblNom
            // 
            this.lblNom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(89, 22);
            this.lblNom.Text = "Nom utilisateur";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAgrandir
            // 
            this.btnAgrandir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgrandir.Image = global::PATIO.Properties.Resources.fleche_droite_vert;
            this.btnAgrandir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAgrandir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgrandir.Name = "btnAgrandir";
            this.btnAgrandir.Size = new System.Drawing.Size(23, 22);
            this.btnAgrandir.Text = "Agrandir la barre de fonctions";
            this.btnAgrandir.Click += new System.EventHandler(this.btnAgrandir_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 611);
            this.Controls.Add(this.DP);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "Application PATIO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.expanderTablePanel1.ResumeLayout(false);
            this.Expander_Administration.Content.ResumeLayout(false);
            this.Expander_Fonction.Content.ResumeLayout(false);
            this.BarreBtn.ResumeLayout(false);
            this.BarreBtn.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WeifenLuo.WinFormsUI.Docking.DockPanel DP;
        private System.Windows.Forms.Timer timer_Connexion;
        private System.Windows.Forms.Timer timer_Sauvegarde;
        private System.Windows.Forms.RibbonComboBox lstPlan;
        private System.Windows.Forms.Timer timer_Ouverture;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView treeFonction;
        private System.Windows.Forms.ToolStrip BarreBtn;
        private System.Windows.Forms.ToolStripButton btnReduire;
        private System.Windows.Forms.ToolStripSeparator Separ1;
        private System.Windows.Forms.ImageList imageListFonction;
        private System.Windows.Forms.ImageList imageListAccueil;
        private System.Windows.Forms.ToolStripButton btnActualiser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private WinFormsExpander.ExpanderTablePanel expanderTablePanel1;
        private WinFormsExpander.Expander Expander_Administration;
        private System.Windows.Forms.TreeView treeAdmin;
        private WinFormsExpander.Expander Expander_Fonction;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblCodeUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel lblNom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripDropDownButton MenuPerso;
        private System.Windows.Forms.ToolStripMenuItem monCompteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesDroitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesPréférencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton MenuAide;
        private System.Windows.Forms.ToolStripMenuItem MenuXWIKI_PRS;
        private System.Windows.Forms.ToolStripMenuItem MenuXWIKI_PlanAction;
        private System.Windows.Forms.ToolStripMenuItem MenuXWIKI;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuAide_Ligne;
        private System.Windows.Forms.ToolStripMenuItem btnRecharger;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnAgrandir;
    }
}

