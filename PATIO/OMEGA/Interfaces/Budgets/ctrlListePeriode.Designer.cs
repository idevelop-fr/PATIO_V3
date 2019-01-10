namespace PATIO.OMEGA.Interfaces.Budgets
{
    partial class ctrlListePeriode
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
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCréerPeriode = new System.Windows.Forms.ToolStripButton();
            this.btnModifierPeriode = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerPeriode = new System.Windows.Forms.ToolStripButton();
            this.btnActualiserPeriode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lstPeriode = new System.Windows.Forms.TreeView();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.btnCréerPeriode,
            this.btnModifierPeriode,
            this.btnSupprimerPeriode,
            this.btnActualiserPeriode,
            this.toolStripSeparator2});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(263, 25);
            this.toolStrip3.TabIndex = 11;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCréerPeriode
            // 
            this.btnCréerPeriode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCréerPeriode.Image = global::PATIO.Properties.Resources.plus_orange;
            this.btnCréerPeriode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCréerPeriode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCréerPeriode.Name = "btnCréerPeriode";
            this.btnCréerPeriode.Size = new System.Drawing.Size(23, 22);
            this.btnCréerPeriode.Text = "Créer une structure";
            this.btnCréerPeriode.Click += new System.EventHandler(this.btnCréerPeriode_Click);
            // 
            // btnModifierPeriode
            // 
            this.btnModifierPeriode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierPeriode.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierPeriode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierPeriode.Name = "btnModifierPeriode";
            this.btnModifierPeriode.Size = new System.Drawing.Size(23, 22);
            this.btnModifierPeriode.Text = "Modifier";
            this.btnModifierPeriode.Click += new System.EventHandler(this.btnModifierPeriode_Click);
            // 
            // btnSupprimerPeriode
            // 
            this.btnSupprimerPeriode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerPeriode.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerPeriode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerPeriode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerPeriode.Name = "btnSupprimerPeriode";
            this.btnSupprimerPeriode.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerPeriode.Text = "Supprimer";
            this.btnSupprimerPeriode.Click += new System.EventHandler(this.btnSupprimerPeriode_Click);
            // 
            // btnActualiserPeriode
            // 
            this.btnActualiserPeriode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualiserPeriode.Image = global::PATIO.Properties.Resources.btn_maj;
            this.btnActualiserPeriode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualiserPeriode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualiserPeriode.Name = "btnActualiserPeriode";
            this.btnActualiserPeriode.Size = new System.Drawing.Size(23, 22);
            this.btnActualiserPeriode.Text = "Actualiser";
            this.btnActualiserPeriode.Click += new System.EventHandler(this.btnActualiserPeriode_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lstPeriode
            // 
            this.lstPeriode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPeriode.Location = new System.Drawing.Point(0, 25);
            this.lstPeriode.Name = "lstPeriode";
            this.lstPeriode.Size = new System.Drawing.Size(263, 405);
            this.lstPeriode.TabIndex = 12;
            // 
            // ctrlListePeriode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstPeriode);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrlListePeriode";
            this.Size = new System.Drawing.Size(263, 430);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnCréerPeriode;
        private System.Windows.Forms.ToolStripButton btnModifierPeriode;
        private System.Windows.Forms.ToolStripButton btnSupprimerPeriode;
        private System.Windows.Forms.ToolStripButton btnActualiserPeriode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TreeView lstPeriode;
    }
}
