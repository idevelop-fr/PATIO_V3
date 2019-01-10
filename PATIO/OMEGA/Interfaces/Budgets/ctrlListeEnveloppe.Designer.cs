namespace PATIO.OMEGA.Interfaces.Budgets
{
    partial class ctrlListeEnveloppe
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
            this.btnCréerEnveloppe = new System.Windows.Forms.ToolStripButton();
            this.btnModifierEnveloppe = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerEnveloppe = new System.Windows.Forms.ToolStripButton();
            this.btnActualiserEnveloppe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lstEnveloppe = new System.Windows.Forms.TreeView();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.btnCréerEnveloppe,
            this.btnModifierEnveloppe,
            this.btnSupprimerEnveloppe,
            this.btnActualiserEnveloppe,
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
            // btnCréerEnveloppe
            // 
            this.btnCréerEnveloppe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCréerEnveloppe.Image = global::PATIO.Properties.Resources.plus_orange;
            this.btnCréerEnveloppe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCréerEnveloppe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCréerEnveloppe.Name = "btnCréerEnveloppe";
            this.btnCréerEnveloppe.Size = new System.Drawing.Size(23, 22);
            this.btnCréerEnveloppe.Text = "Créer une enveloppe";
            this.btnCréerEnveloppe.Click += new System.EventHandler(this.btnCréerPeriode_Click);
            // 
            // btnModifierEnveloppe
            // 
            this.btnModifierEnveloppe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierEnveloppe.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierEnveloppe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierEnveloppe.Name = "btnModifierEnveloppe";
            this.btnModifierEnveloppe.Size = new System.Drawing.Size(23, 22);
            this.btnModifierEnveloppe.Text = "Modifier l\'enveloppe";
            this.btnModifierEnveloppe.Click += new System.EventHandler(this.btnModifierEnveloppe_Click);
            // 
            // btnSupprimerEnveloppe
            // 
            this.btnSupprimerEnveloppe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerEnveloppe.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerEnveloppe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerEnveloppe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerEnveloppe.Name = "btnSupprimerEnveloppe";
            this.btnSupprimerEnveloppe.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerEnveloppe.Text = "Supprimer l\'enveloppe";
            this.btnSupprimerEnveloppe.Click += new System.EventHandler(this.btnSupprimerPeriode_Click);
            // 
            // btnActualiserEnveloppe
            // 
            this.btnActualiserEnveloppe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualiserEnveloppe.Image = global::PATIO.Properties.Resources.btn_maj;
            this.btnActualiserEnveloppe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualiserEnveloppe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualiserEnveloppe.Name = "btnActualiserEnveloppe";
            this.btnActualiserEnveloppe.Size = new System.Drawing.Size(23, 22);
            this.btnActualiserEnveloppe.Text = "Actualiser";
            this.btnActualiserEnveloppe.Click += new System.EventHandler(this.btnActualiserEnveloppe_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lstEnveloppe
            // 
            this.lstEnveloppe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEnveloppe.Location = new System.Drawing.Point(0, 25);
            this.lstEnveloppe.Name = "lstEnveloppe";
            this.lstEnveloppe.Size = new System.Drawing.Size(263, 405);
            this.lstEnveloppe.TabIndex = 12;
            // 
            // ctrlListeEveloppe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstEnveloppe);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrlListeEveloppe";
            this.Size = new System.Drawing.Size(263, 430);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnCréerEnveloppe;
        private System.Windows.Forms.ToolStripButton btnModifierEnveloppe;
        private System.Windows.Forms.ToolStripButton btnSupprimerEnveloppe;
        private System.Windows.Forms.ToolStripButton btnActualiserEnveloppe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TreeView lstEnveloppe;
    }
}
