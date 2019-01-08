namespace PATIO.ADMIN
{
    partial class ctrlListeModeleDoc
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
            this.lstModele = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAjouter = new System.Windows.Forms.ToolStripButton();
            this.BtnModifier = new System.Windows.Forms.ToolStripButton();
            this.BtnSupprimer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecherche = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstModele
            // 
            this.lstModele.AllowDrop = true;
            this.lstModele.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstModele.FullRowSelect = true;
            this.lstModele.ImageIndex = 0;
            this.lstModele.ImageList = this.imageList1;
            this.lstModele.Location = new System.Drawing.Point(0, 25);
            this.lstModele.Name = "lstModele";
            this.lstModele.SelectedImageIndex = 0;
            this.lstModele.Size = new System.Drawing.Size(276, 400);
            this.lstModele.TabIndex = 12;
            this.lstModele.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstModeleDoc_DragDrop);
            this.lstModele.DragOver += new System.Windows.Forms.DragEventHandler(this.lstModeleDoc_DragOver);
            this.lstModele.DoubleClick += new System.EventHandler(this.lstModeleDoc_DoubleClick);
            this.lstModele.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstModeleDoc_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.BtnAjouter,
            this.BtnModifier,
            this.BtnSupprimer,
            this.toolStripSeparator7,
            this.toolStripSeparator10,
            this.BtnActualiser,
            this.toolStripSeparator19,
            this.lblRecherche,
            this.toolStripSeparator1});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(276, 25);
            this.toolStrip3.TabIndex = 11;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnAjouter
            // 
            this.BtnAjouter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAjouter.Image = global::PATIO.Properties.Resources.plus;
            this.BtnAjouter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnAjouter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAjouter.Name = "BtnAjouter";
            this.BtnAjouter.Size = new System.Drawing.Size(23, 22);
            this.BtnAjouter.Text = "Créer";
            this.BtnAjouter.Click += new System.EventHandler(this.BtnAjouterModeleDoc_Click);
            // 
            // BtnModifier
            // 
            this.BtnModifier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnModifier.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.BtnModifier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModifier.Name = "BtnModifier";
            this.BtnModifier.Size = new System.Drawing.Size(23, 22);
            this.BtnModifier.Text = "Modifier";
            this.BtnModifier.Click += new System.EventHandler(this.BtnModifierModeleDoc_Click);
            // 
            // BtnSupprimer
            // 
            this.BtnSupprimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSupprimer.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.BtnSupprimer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSupprimer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSupprimer.Name = "BtnSupprimer";
            this.BtnSupprimer.Size = new System.Drawing.Size(23, 22);
            this.BtnSupprimer.Text = "Supprimer";
            this.BtnSupprimer.Click += new System.EventHandler(this.BtnSupprimerModeleDoc_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnActualiser
            // 
            this.BtnActualiser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnActualiser.Image = global::PATIO.Properties.Resources.btn_maj;
            this.BtnActualiser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnActualiser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnActualiser.Name = "BtnActualiser";
            this.BtnActualiser.Size = new System.Drawing.Size(23, 22);
            this.BtnActualiser.Text = "Actualiser";
            this.BtnActualiser.Click += new System.EventHandler(this.BtnActualiserModeleDoc_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRecherche
            // 
            this.lblRecherche.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(100, 25);
            this.lblRecherche.TextChanged += new System.EventHandler(this.lblRecherche_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatut,
            this.lblNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(276, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatut
            // 
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(232, 17);
            this.lblStatut.Spring = true;
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNb
            // 
            this.lblNb.Name = "lblNb";
            this.lblNb.Size = new System.Drawing.Size(29, 17);
            this.lblNb.Text = "Nb :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstModele);
            this.panel1.Controls.Add(this.toolStrip3);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 447);
            this.panel1.TabIndex = 14;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(276, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 447);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(279, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 447);
            this.panel2.TabIndex = 16;
            // 
            // ctrlListeModeleDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlListeModeleDoc";
            this.Size = new System.Drawing.Size(502, 447);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView lstModele;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BtnAjouter;
        private System.Windows.Forms.ToolStripButton BtnModifier;
        private System.Windows.Forms.ToolStripButton BtnSupprimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton BtnActualiser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatut;
        private System.Windows.Forms.ToolStripStatusLabel lblNb;
        public System.Windows.Forms.ToolStripTextBox lblRecherche;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
    }
}
