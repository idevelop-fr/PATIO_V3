namespace PATIO.CAPA.Interfaces
{
    partial class ctrlListeProcessus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlListeProcessus));
            this.lstProcessus = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjouter = new System.Windows.Forms.ToolStripButton();
            this.BtnAjouterSous = new System.Windows.Forms.ToolStripButton();
            this.BtnModifier = new System.Windows.Forms.ToolStripButton();
            this.BtnSupprimer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecherche = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstProcessus
            // 
            this.lstProcessus.AllowDrop = true;
            this.lstProcessus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProcessus.FullRowSelect = true;
            this.lstProcessus.HideSelection = false;
            this.lstProcessus.ImageIndex = 0;
            this.lstProcessus.ImageList = this.imageList1;
            this.lstProcessus.Location = new System.Drawing.Point(0, 25);
            this.lstProcessus.Name = "lstProcessus";
            this.lstProcessus.SelectedImageIndex = 0;
            this.lstProcessus.ShowNodeToolTips = true;
            this.lstProcessus.Size = new System.Drawing.Size(398, 382);
            this.lstProcessus.TabIndex = 10;
            this.lstProcessus.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstProcessus_AfterSelect);
            this.lstProcessus.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstProcessus_DragDrop);
            this.lstProcessus.DragOver += new System.Windows.Forms.DragEventHandler(this.lstProcessus_DragOver);
            this.lstProcessus.DoubleClick += new System.EventHandler(this.lstProcessus_DoubleClick);
            this.lstProcessus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstProcessus_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_green.gif");
            this.imageList1.Images.SetKeyName(1, "dossier.gif");
            this.imageList1.Images.SetKeyName(2, "btn_losange_bleu.png");
            this.imageList1.Images.SetKeyName(3, "btn_cercle_orange.png");
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.btnAjouter,
            this.BtnAjouterSous,
            this.BtnModifier,
            this.BtnSupprimer,
            this.toolStripSeparator7,
            this.toolStripSeparator10,
            this.BtnActualiser,
            this.toolStripSeparator19,
            this.lblRecherche});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(398, 25);
            this.toolStrip3.TabIndex = 9;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.SystemColors.Control;
            this.btnAjouter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouter.Image = global::PATIO.Properties.Resources.plus;
            this.btnAjouter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAjouter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(23, 22);
            this.btnAjouter.Text = "Créer une action";
            this.btnAjouter.Click += new System.EventHandler(this.btnCréerProcessus_Click);
            // 
            // BtnAjouterSous
            // 
            this.BtnAjouterSous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAjouterSous.Image = global::PATIO.Properties.Resources.plus_o;
            this.BtnAjouterSous.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnAjouterSous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAjouterSous.Name = "BtnAjouterSous";
            this.BtnAjouterSous.Size = new System.Drawing.Size(23, 22);
            this.BtnAjouterSous.Text = "Créer une sous-action";
            this.BtnAjouterSous.Click += new System.EventHandler(this.BtnAjouterSousProcessus_Click);
            // 
            // BtnModifier
            // 
            this.BtnModifier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnModifier.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.BtnModifier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModifier.Name = "BtnModifier";
            this.BtnModifier.Size = new System.Drawing.Size(23, 22);
            this.BtnModifier.Text = "Modifier";
            this.BtnModifier.Click += new System.EventHandler(this.BtnModifierProcessus_Click);
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
            this.BtnSupprimer.Click += new System.EventHandler(this.BtnSupprimerProcessus_Click);
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
            this.BtnActualiser.Click += new System.EventHandler(this.BtnActualiserProcessus_Click);
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
            this.lblRecherche.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblRecherche_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatut,
            this.lblNb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(398, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatut
            // 
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(354, 17);
            this.lblStatut.Spring = true;
            this.lblStatut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNb
            // 
            this.lblNb.Name = "lblNb";
            this.lblNb.Size = new System.Drawing.Size(29, 17);
            this.lblNb.Text = "Nb :";
            // 
            // ctrlListeProcessus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstProcessus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrlListeProcessus";
            this.Size = new System.Drawing.Size(398, 429);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BtnAjouterSous;
        private System.Windows.Forms.ToolStripButton BtnModifier;
        private System.Windows.Forms.ToolStripButton BtnSupprimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton BtnActualiser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        public System.Windows.Forms.TreeView lstProcessus;
        private System.Windows.Forms.ToolStripButton btnAjouter;
        public System.Windows.Forms.ToolStripTextBox lblRecherche;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatut;
        private System.Windows.Forms.ToolStripStatusLabel lblNb;
        private System.Windows.Forms.ImageList imageList1;
    }
}
