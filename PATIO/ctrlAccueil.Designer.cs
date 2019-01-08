namespace PATIO
{
    partial class ctrlAccueil
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
            this.BarreMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualiser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lstUtilisateur = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lstEspace = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCAPA_Favori = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treeFavori = new System.Windows.Forms.TreeView();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.btnOuvrirFavori = new System.Windows.Forms.ToolStripButton();
            this.tabCAPA_Pilote = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treePilote = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnOuvrirPilotage = new System.Windows.Forms.ToolStripButton();
            this.tabCAPA_Membre = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeAsso = new System.Windows.Forms.TreeView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnOuvrirMembre = new System.Windows.Forms.ToolStripButton();
            this.tabOMEGA = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabRecherche = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BarreMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCAPA_Favori.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.tabCAPA_Pilote.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabCAPA_Membre.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabOMEGA.SuspendLayout();
            this.tabRecherche.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarreMenu
            // 
            this.BarreMenu.AutoSize = false;
            this.BarreMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.BarreMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.btnActualiser,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.lstUtilisateur,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.lstEspace,
            this.toolStripSeparator2});
            this.BarreMenu.Location = new System.Drawing.Point(0, 0);
            this.BarreMenu.Name = "BarreMenu";
            this.BarreMenu.Size = new System.Drawing.Size(853, 30);
            this.BarreMenu.TabIndex = 5;
            this.BarreMenu.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // btnActualiser
            // 
            this.btnActualiser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnActualiser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualiser.Image = global::PATIO.Properties.Resources.btn_maj;
            this.btnActualiser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualiser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(23, 27);
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 30);
            // 
            // lstUtilisateur
            // 
            this.lstUtilisateur.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lstUtilisateur.BackColor = System.Drawing.Color.LightYellow;
            this.lstUtilisateur.Name = "lstUtilisateur";
            this.lstUtilisateur.Size = new System.Drawing.Size(200, 30);
            this.lstUtilisateur.SelectedIndexChanged += new System.EventHandler(this.lstUtilisateur_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 27);
            this.toolStripLabel1.Text = "Profil utilisateur :";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(49, 27);
            this.toolStripLabel2.Text = "Espace :";
            // 
            // lstEspace
            // 
            this.lstEspace.BackColor = System.Drawing.Color.LightYellow;
            this.lstEspace.Name = "lstEspace";
            this.lstEspace.Size = new System.Drawing.Size(200, 30);
            this.lstEspace.SelectedIndexChanged += new System.EventHandler(this.lstEspace_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCAPA_Favori);
            this.tabControl.Controls.Add(this.tabCAPA_Pilote);
            this.tabControl.Controls.Add(this.tabCAPA_Membre);
            this.tabControl.Controls.Add(this.tabOMEGA);
            this.tabControl.Controls.Add(this.tabRecherche);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(76, 27);
            this.tabControl.Location = new System.Drawing.Point(0, 30);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(853, 588);
            this.tabControl.TabIndex = 6;
            // 
            // tabCAPA_Favori
            // 
            this.tabCAPA_Favori.Controls.Add(this.groupBox4);
            this.tabCAPA_Favori.Location = new System.Drawing.Point(4, 31);
            this.tabCAPA_Favori.Name = "tabCAPA_Favori";
            this.tabCAPA_Favori.Padding = new System.Windows.Forms.Padding(3);
            this.tabCAPA_Favori.Size = new System.Drawing.Size(845, 553);
            this.tabCAPA_Favori.TabIndex = 1;
            this.tabCAPA_Favori.Text = "Objets favoris";
            this.tabCAPA_Favori.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeFavori);
            this.groupBox4.Controls.Add(this.toolStrip4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(839, 547);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Objets favoris";
            // 
            // treeFavori
            // 
            this.treeFavori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFavori.Location = new System.Drawing.Point(3, 16);
            this.treeFavori.Name = "treeFavori";
            this.treeFavori.Size = new System.Drawing.Size(809, 528);
            this.treeFavori.TabIndex = 0;
            this.treeFavori.DoubleClick += new System.EventHandler(this.treeFavori_DoubleClick);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOuvrirFavori});
            this.toolStrip4.Location = new System.Drawing.Point(812, 16);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(24, 528);
            this.toolStrip4.TabIndex = 1;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // btnOuvrirFavori
            // 
            this.btnOuvrirFavori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOuvrirFavori.Image = global::PATIO.Properties.Resources.btn_voir;
            this.btnOuvrirFavori.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOuvrirFavori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOuvrirFavori.Name = "btnOuvrirFavori";
            this.btnOuvrirFavori.Size = new System.Drawing.Size(21, 19);
            this.btnOuvrirFavori.Text = "Ouvrir l\'élément";
            this.btnOuvrirFavori.Click += new System.EventHandler(this.btnOuvrirFavori_Click);
            // 
            // tabCAPA_Pilote
            // 
            this.tabCAPA_Pilote.Controls.Add(this.groupBox2);
            this.tabCAPA_Pilote.Location = new System.Drawing.Point(4, 31);
            this.tabCAPA_Pilote.Name = "tabCAPA_Pilote";
            this.tabCAPA_Pilote.Padding = new System.Windows.Forms.Padding(3);
            this.tabCAPA_Pilote.Size = new System.Drawing.Size(845, 553);
            this.tabCAPA_Pilote.TabIndex = 0;
            this.tabCAPA_Pilote.Text = "CAPA-Pilotage";
            this.tabCAPA_Pilote.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treePilote);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 547);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Objets dont vous êtes Pilote";
            // 
            // treePilote
            // 
            this.treePilote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePilote.Location = new System.Drawing.Point(3, 16);
            this.treePilote.Name = "treePilote";
            this.treePilote.Size = new System.Drawing.Size(809, 528);
            this.treePilote.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOuvrirPilotage});
            this.toolStrip2.Location = new System.Drawing.Point(812, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(24, 528);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnOuvrirPilotage
            // 
            this.btnOuvrirPilotage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOuvrirPilotage.Image = global::PATIO.Properties.Resources.btn_voir;
            this.btnOuvrirPilotage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOuvrirPilotage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOuvrirPilotage.Name = "btnOuvrirPilotage";
            this.btnOuvrirPilotage.Size = new System.Drawing.Size(21, 19);
            this.btnOuvrirPilotage.Text = "Ouvrir l\'élément";
            this.btnOuvrirPilotage.Click += new System.EventHandler(this.btnOuvrirPilotage_Click);
            // 
            // tabCAPA_Membre
            // 
            this.tabCAPA_Membre.Controls.Add(this.groupBox3);
            this.tabCAPA_Membre.Location = new System.Drawing.Point(4, 31);
            this.tabCAPA_Membre.Name = "tabCAPA_Membre";
            this.tabCAPA_Membre.Size = new System.Drawing.Size(845, 553);
            this.tabCAPA_Membre.TabIndex = 2;
            this.tabCAPA_Membre.Text = "CAPA-Membres";
            this.tabCAPA_Membre.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeAsso);
            this.groupBox3.Controls.Add(this.toolStrip3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(845, 553);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objets dont vous êtes Membre de l\'équipe";
            // 
            // treeAsso
            // 
            this.treeAsso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAsso.Location = new System.Drawing.Point(3, 16);
            this.treeAsso.Name = "treeAsso";
            this.treeAsso.Size = new System.Drawing.Size(815, 534);
            this.treeAsso.TabIndex = 0;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOuvrirMembre});
            this.toolStrip3.Location = new System.Drawing.Point(818, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(24, 534);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnOuvrirMembre
            // 
            this.btnOuvrirMembre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOuvrirMembre.Image = global::PATIO.Properties.Resources.btn_voir;
            this.btnOuvrirMembre.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOuvrirMembre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOuvrirMembre.Name = "btnOuvrirMembre";
            this.btnOuvrirMembre.Size = new System.Drawing.Size(21, 19);
            this.btnOuvrirMembre.Text = "Ouvrir l\'action";
            this.btnOuvrirMembre.Click += new System.EventHandler(this.btnOuvrirMembre_Click);
            // 
            // tabOMEGA
            // 
            this.tabOMEGA.Controls.Add(this.groupBox5);
            this.tabOMEGA.Location = new System.Drawing.Point(4, 31);
            this.tabOMEGA.Name = "tabOMEGA";
            this.tabOMEGA.Padding = new System.Windows.Forms.Padding(1);
            this.tabOMEGA.Size = new System.Drawing.Size(845, 553);
            this.tabOMEGA.TabIndex = 3;
            this.tabOMEGA.Text = "OMEGA";
            this.tabOMEGA.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(1, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(843, 143);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "OMEGA";
            // 
            // tabRecherche
            // 
            this.tabRecherche.Controls.Add(this.groupBox1);
            this.tabRecherche.Location = new System.Drawing.Point(4, 31);
            this.tabRecherche.Name = "tabRecherche";
            this.tabRecherche.Padding = new System.Windows.Forms.Padding(1);
            this.tabRecherche.Size = new System.Drawing.Size(845, 553);
            this.tabRecherche.TabIndex = 4;
            this.tabRecherche.Text = "Recherche";
            this.tabRecherche.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtres de recherche";
            // 
            // ctrlAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.BarreMenu);
            this.Name = "ctrlAccueil";
            this.Size = new System.Drawing.Size(853, 618);
            this.BarreMenu.ResumeLayout(false);
            this.BarreMenu.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabCAPA_Favori.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tabCAPA_Pilote.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabCAPA_Membre.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabOMEGA.ResumeLayout(false);
            this.tabRecherche.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip BarreMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnActualiser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeAsso;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treePilote;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnOuvrirMembre;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnOuvrirPilotage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox lstUtilisateur;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCAPA_Favori;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView treeFavori;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton btnOuvrirFavori;
        private System.Windows.Forms.TabPage tabCAPA_Pilote;
        private System.Windows.Forms.TabPage tabCAPA_Membre;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox lstEspace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabPage tabOMEGA;
        private System.Windows.Forms.TabPage tabRecherche;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
