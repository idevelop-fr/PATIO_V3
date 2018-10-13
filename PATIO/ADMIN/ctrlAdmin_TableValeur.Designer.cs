namespace PATIO.ADMIN
{
    partial class ctrlAdmin_TableValeur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlAdmin_TableValeur));
            this.toolstrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjouterTV = new System.Windows.Forms.ToolStripButton();
            this.btnModifierTV = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerTV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualiserTV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRechercheTV = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTV_CopierVers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.DG_TV = new System.Windows.Forms.DataGridView();
            this.toolstrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_TV)).BeginInit();
            this.SuspendLayout();
            // 
            // toolstrip1
            // 
            this.toolstrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolstrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnAjouterTV,
            this.btnModifierTV,
            this.btnSupprimerTV,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.btnActualiserTV,
            this.toolStripSeparator4,
            this.toolStripSeparator10,
            this.lblRechercheTV,
            this.toolStripSeparator14,
            this.btnTV_CopierVers,
            this.toolStripSeparator17});
            this.toolstrip1.Location = new System.Drawing.Point(0, 0);
            this.toolstrip1.Name = "toolstrip1";
            this.toolstrip1.Size = new System.Drawing.Size(554, 25);
            this.toolstrip1.TabIndex = 16;
            this.toolstrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAjouterTV
            // 
            this.btnAjouterTV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouterTV.Image = global::PATIO.Properties.Resources.plus;
            this.btnAjouterTV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAjouterTV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouterTV.Name = "btnAjouterTV";
            this.btnAjouterTV.Size = new System.Drawing.Size(23, 22);
            this.btnAjouterTV.Text = "Créer";
            this.btnAjouterTV.Click += new System.EventHandler(this.btnAjouterTV_Click);
            // 
            // btnModifierTV
            // 
            this.btnModifierTV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierTV.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierTV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierTV.Name = "btnModifierTV";
            this.btnModifierTV.Size = new System.Drawing.Size(23, 22);
            this.btnModifierTV.Text = "Modifier";
            this.btnModifierTV.Click += new System.EventHandler(this.btnModifierTV_Click);
            // 
            // btnSupprimerTV
            // 
            this.btnSupprimerTV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerTV.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerTV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerTV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerTV.Name = "btnSupprimerTV";
            this.btnSupprimerTV.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerTV.Text = "Supprimer";
            this.btnSupprimerTV.Click += new System.EventHandler(this.btnSupprimerTV_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActualiserTV
            // 
            this.btnActualiserTV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualiserTV.Image = global::PATIO.Properties.Resources.btn_maj;
            this.btnActualiserTV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualiserTV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualiserTV.Name = "btnActualiserTV";
            this.btnActualiserTV.Size = new System.Drawing.Size(23, 22);
            this.btnActualiserTV.Text = "Actualiser";
            this.btnActualiserTV.Click += new System.EventHandler(this.btnActualiserTV_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRechercheTV
            // 
            this.lblRechercheTV.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblRechercheTV.Name = "lblRechercheTV";
            this.lblRechercheTV.Size = new System.Drawing.Size(100, 25);
            this.lblRechercheTV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblRechercheTV_KeyPress);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTV_CopierVers
            // 
            this.btnTV_CopierVers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTV_CopierVers.Image = ((System.Drawing.Image)(resources.GetObject("btnTV_CopierVers.Image")));
            this.btnTV_CopierVers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTV_CopierVers.Name = "btnTV_CopierVers";
            this.btnTV_CopierVers.Size = new System.Drawing.Size(79, 22);
            this.btnTV_CopierVers.Text = "Copier vers...";
            this.btnTV_CopierVers.Click += new System.EventHandler(this.btnTV_CopierVers_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // DG_TV
            // 
            this.DG_TV.AllowUserToAddRows = false;
            this.DG_TV.AllowUserToDeleteRows = false;
            this.DG_TV.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DG_TV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_TV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_TV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DG_TV.Location = new System.Drawing.Point(0, 25);
            this.DG_TV.MultiSelect = false;
            this.DG_TV.Name = "DG_TV";
            this.DG_TV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_TV.Size = new System.Drawing.Size(554, 422);
            this.DG_TV.TabIndex = 17;
            // 
            // ctrlAdmin_TableValeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DG_TV);
            this.Controls.Add(this.toolstrip1);
            this.Name = "ctrlAdmin_TableValeur";
            this.Size = new System.Drawing.Size(554, 447);
            this.toolstrip1.ResumeLayout(false);
            this.toolstrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_TV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolstrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAjouterTV;
        private System.Windows.Forms.ToolStripButton btnModifierTV;
        private System.Windows.Forms.ToolStripButton btnSupprimerTV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnActualiserTV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripTextBox lblRechercheTV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton btnTV_CopierVers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.DataGridView DG_TV;
    }
}
