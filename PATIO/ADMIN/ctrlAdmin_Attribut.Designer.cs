namespace PATIO.ADMIN
{
    partial class ctrlAdmin_Attribut
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
            this.btnAjouterAttribut = new System.Windows.Forms.ToolStripButton();
            this.btnModifierAttribut = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerAttribut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualiserAttribut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRechercheAttribut = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lstElement = new System.Windows.Forms.ToolStripComboBox();
            this.DG_Attribut = new System.Windows.Forms.DataGridView();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Attribut)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.btnAjouterAttribut,
            this.btnModifierAttribut,
            this.btnSupprimerAttribut,
            this.toolStripSeparator7,
            this.btnActualiserAttribut,
            this.toolStripSeparator19,
            this.toolStripSeparator12,
            this.lblRechercheAttribut,
            this.toolStripSeparator13,
            this.toolStripLabel1,
            this.lstElement});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(668, 25);
            this.toolStrip3.TabIndex = 15;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAjouterAttribut
            // 
            this.btnAjouterAttribut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouterAttribut.Image = global::PATIO.Properties.Resources.plus;
            this.btnAjouterAttribut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAjouterAttribut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouterAttribut.Name = "btnAjouterAttribut";
            this.btnAjouterAttribut.Size = new System.Drawing.Size(23, 22);
            this.btnAjouterAttribut.Text = "Créer";
            this.btnAjouterAttribut.Click += new System.EventHandler(this.btnAjouterAttribut_Click);
            // 
            // btnModifierAttribut
            // 
            this.btnModifierAttribut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierAttribut.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierAttribut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierAttribut.Name = "btnModifierAttribut";
            this.btnModifierAttribut.Size = new System.Drawing.Size(23, 22);
            this.btnModifierAttribut.Text = "Modifier";
            this.btnModifierAttribut.Click += new System.EventHandler(this.btnModifierAttribut_Click);
            // 
            // btnSupprimerAttribut
            // 
            this.btnSupprimerAttribut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerAttribut.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerAttribut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerAttribut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerAttribut.Name = "btnSupprimerAttribut";
            this.btnSupprimerAttribut.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerAttribut.Text = "Supprimer";
            this.btnSupprimerAttribut.Click += new System.EventHandler(this.btnSupprimerAttribut_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActualiserAttribut
            // 
            this.btnActualiserAttribut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualiserAttribut.Image = global::PATIO.Properties.Resources.btn_maj;
            this.btnActualiserAttribut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualiserAttribut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualiserAttribut.Name = "btnActualiserAttribut";
            this.btnActualiserAttribut.Size = new System.Drawing.Size(23, 22);
            this.btnActualiserAttribut.Text = "Actualiser";
            this.btnActualiserAttribut.Click += new System.EventHandler(this.btnActualiserAttribut_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // lblRechercheAttribut
            // 
            this.lblRechercheAttribut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblRechercheAttribut.Name = "lblRechercheAttribut";
            this.lblRechercheAttribut.Size = new System.Drawing.Size(100, 25);
            this.lblRechercheAttribut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lblRechercheAttribut_KeyPress);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "Elément :";
            // 
            // lstElement
            // 
            this.lstElement.Name = "lstElement";
            this.lstElement.Size = new System.Drawing.Size(100, 25);
            this.lstElement.SelectedIndexChanged += new System.EventHandler(this.lstElement_SelectedIndexChanged);
            // 
            // DG_Attribut
            // 
            this.DG_Attribut.AllowUserToAddRows = false;
            this.DG_Attribut.AllowUserToDeleteRows = false;
            this.DG_Attribut.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DG_Attribut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Attribut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Attribut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DG_Attribut.Location = new System.Drawing.Point(0, 25);
            this.DG_Attribut.MultiSelect = false;
            this.DG_Attribut.Name = "DG_Attribut";
            this.DG_Attribut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_Attribut.Size = new System.Drawing.Size(668, 495);
            this.DG_Attribut.TabIndex = 16;
            // 
            // ctrlAdmin_Attribut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DG_Attribut);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrlAdmin_Attribut";
            this.Size = new System.Drawing.Size(668, 520);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Attribut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnAjouterAttribut;
        private System.Windows.Forms.ToolStripButton btnModifierAttribut;
        private System.Windows.Forms.ToolStripButton btnSupprimerAttribut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnActualiserAttribut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripTextBox lblRechercheAttribut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox lstElement;
        private System.Windows.Forms.DataGridView DG_Attribut;
    }
}
