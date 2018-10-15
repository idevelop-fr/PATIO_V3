namespace PATIO.OMEGA.Interfaces
{
    partial class ctrlBudget_FIR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlBudget_FIR));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.expanderTablePanel1 = new WinFormsExpander.ExpanderTablePanel();
            this.expander1 = new WinFormsExpander.Expander();
            this.expander2 = new WinFormsExpander.Expander();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblEtatBudget = new System.Windows.Forms.Label();
            this.lblTypeBudget = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.expanderTablePanel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel10);
            this.splitContainer1.Size = new System.Drawing.Size(878, 679);
            this.splitContainer1.SplitterDistance = 620;
            this.splitContainer1.TabIndex = 0;
            // 
            // expanderTablePanel1
            // 
            this.expanderTablePanel1.ColumnCount = 1;
            this.expanderTablePanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expanderTablePanel1.Controls.Add(this.lblTypeBudget, 0, 0);
            this.expanderTablePanel1.Controls.Add(this.lblEtatBudget, 0, 0);
            this.expanderTablePanel1.Controls.Add(this.expander2, 0, 2);
            this.expanderTablePanel1.Controls.Add(this.expander1, 0, 1);
            this.expanderTablePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.expanderTablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expanderTablePanel1.MinimumSize = new System.Drawing.Size(0, 159);
            this.expanderTablePanel1.Name = "expanderTablePanel1";
            this.expanderTablePanel1.RowCount = 3;
            this.expanderTablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.expanderTablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.expanderTablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.expanderTablePanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.expanderTablePanel1.Size = new System.Drawing.Size(207, 679);
            this.expanderTablePanel1.TabIndex = 4;
            // 
            // expander1
            // 
            this.expander1.AutoScroll = true;
            this.expander1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expander1.CollapseImage = ((System.Drawing.Image)(resources.GetObject("expander1.CollapseImage")));
            // 
            // expander1.Content
            // 
            this.expander1.Content.AutoScroll = true;
            this.expander1.Content.AutoScrollMinSize = new System.Drawing.Size(150, 50);
            this.expander1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expander1.ExpandImage = ((System.Drawing.Image)(resources.GetObject("expander1.ExpandImage")));
            this.expander1.Header = "Statistiques";
            this.expander1.Location = new System.Drawing.Point(3, 74);
            this.expander1.MinimumSize = new System.Drawing.Size(0, 53);
            this.expander1.Name = "expander1";
            this.expander1.Size = new System.Drawing.Size(201, 462);
            this.expander1.TabIndex = 0;
            // 
            // expander2
            // 
            this.expander2.AutoScroll = true;
            this.expander2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expander2.CollapseImage = ((System.Drawing.Image)(resources.GetObject("expander2.CollapseImage")));
            // 
            // expander2.Content
            // 
            this.expander2.Content.AutoScroll = true;
            this.expander2.Content.AutoScrollMinSize = new System.Drawing.Size(150, 50);
            this.expander2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expander2.ExpandImage = ((System.Drawing.Image)(resources.GetObject("expander2.ExpandImage")));
            this.expander2.Location = new System.Drawing.Point(3, 542);
            this.expander2.MinimumSize = new System.Drawing.Size(0, 53);
            this.expander2.Name = "expander2";
            this.expander2.Size = new System.Drawing.Size(201, 134);
            this.expander2.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.expanderTablePanel1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(254, 679);
            this.panel10.TabIndex = 7;
            // 
            // lblEtatBudget
            // 
            this.lblEtatBudget.BackColor = System.Drawing.Color.Yellow;
            this.lblEtatBudget.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEtatBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtatBudget.ForeColor = System.Drawing.Color.Black;
            this.lblEtatBudget.Location = new System.Drawing.Point(3, 0);
            this.lblEtatBudget.Name = "lblEtatBudget";
            this.lblEtatBudget.Size = new System.Drawing.Size(201, 35);
            this.lblEtatBudget.TabIndex = 3;
            this.lblEtatBudget.Text = "Budget actif";
            this.lblEtatBudget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTypeBudget
            // 
            this.lblTypeBudget.BackColor = System.Drawing.Color.Wheat;
            this.lblTypeBudget.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTypeBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeBudget.ForeColor = System.Drawing.Color.Black;
            this.lblTypeBudget.Location = new System.Drawing.Point(3, 36);
            this.lblTypeBudget.Name = "lblTypeBudget";
            this.lblTypeBudget.Size = new System.Drawing.Size(201, 33);
            this.lblTypeBudget.TabIndex = 4;
            this.lblTypeBudget.Text = "Budget Préparatoire";
            this.lblTypeBudget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlBudget_FIR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctrlBudget_FIR";
            this.Size = new System.Drawing.Size(878, 679);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.expanderTablePanel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel10;
        private WinFormsExpander.ExpanderTablePanel expanderTablePanel1;
        internal System.Windows.Forms.Label lblTypeBudget;
        internal System.Windows.Forms.Label lblEtatBudget;
        private WinFormsExpander.Expander expander2;
        private WinFormsExpander.Expander expander1;
    }
}
