namespace PATIO.OMEGA.Interfaces.Budgets
{
    partial class ctrl_Nomenclature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrl_Nomenclature));
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lstTypeEnveloppe = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lstPeriode = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lstTypeFlux = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImporter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DG_Nomenclature = new System.Windows.Forms.DataGridView();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Nomenclature)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.lstTypeEnveloppe,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.lstPeriode,
            this.toolStripSeparator19,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.lstTypeFlux,
            this.toolStripSeparator4,
            this.btnImporter,
            this.toolStripSeparator3});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(826, 25);
            this.toolStrip3.TabIndex = 16;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel1.Text = "Enveloppe :";
            // 
            // lstTypeEnveloppe
            // 
            this.lstTypeEnveloppe.Name = "lstTypeEnveloppe";
            this.lstTypeEnveloppe.Size = new System.Drawing.Size(100, 25);
            this.lstTypeEnveloppe.SelectedIndexChanged += new System.EventHandler(this.lstTypeEnveloppe_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel2.Text = "Période :";
            // 
            // lstPeriode
            // 
            this.lstPeriode.Name = "lstPeriode";
            this.lstPeriode.Size = new System.Drawing.Size(200, 25);
            this.lstPeriode.SelectedIndexChanged += new System.EventHandler(this.lstPeriode_SelectedIndexChanged);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel3.Text = "Type de flux :";
            // 
            // lstTypeFlux
            // 
            this.lstTypeFlux.Name = "lstTypeFlux";
            this.lstTypeFlux.Size = new System.Drawing.Size(121, 25);
            this.lstTypeFlux.SelectedIndexChanged += new System.EventHandler(this.lstTypeFlux_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnImporter
            // 
            this.btnImporter.BackColor = System.Drawing.Color.Yellow;
            this.btnImporter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnImporter.Image = ((System.Drawing.Image)(resources.GetObject("btnImporter.Image")));
            this.btnImporter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImporter.Name = "btnImporter";
            this.btnImporter.Size = new System.Drawing.Size(57, 22);
            this.btnImporter.Text = "Importer";
            this.btnImporter.Click += new System.EventHandler(this.btnImporter_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // DG_Nomenclature
            // 
            this.DG_Nomenclature.AllowUserToAddRows = false;
            this.DG_Nomenclature.AllowUserToDeleteRows = false;
            this.DG_Nomenclature.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DG_Nomenclature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Nomenclature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Nomenclature.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DG_Nomenclature.Location = new System.Drawing.Point(0, 25);
            this.DG_Nomenclature.MultiSelect = false;
            this.DG_Nomenclature.Name = "DG_Nomenclature";
            this.DG_Nomenclature.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_Nomenclature.Size = new System.Drawing.Size(826, 414);
            this.DG_Nomenclature.TabIndex = 17;
            // 
            // ctrl_Nomenclature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DG_Nomenclature);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrl_Nomenclature";
            this.Size = new System.Drawing.Size(826, 439);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Nomenclature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox lstTypeEnveloppe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox lstPeriode;
        private System.Windows.Forms.ToolStripButton btnImporter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView DG_Nomenclature;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox lstTypeFlux;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
