namespace PATIO.ADMIN.Interfaces
{
    partial class ctrlAdmin_DataBase
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSQL = new System.Windows.Forms.TextBox();
            this.lblSortie = new System.Windows.Forms.TextBox();
            this.btnExecuter = new System.Windows.Forms.ToolStripButton();
            this.btnEffacer = new System.Windows.Forms.ToolStripButton();
            this.btnModele = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSuppression_lien = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSQL);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requête SQL";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnExecuter,
            this.toolStripSeparator2,
            this.btnEffacer,
            this.toolStripSeparator3,
            this.btnModele});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSortie);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(802, 282);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sortie";
            // 
            // lblSQL
            // 
            this.lblSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSQL.Location = new System.Drawing.Point(3, 41);
            this.lblSQL.Multiline = true;
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Size = new System.Drawing.Size(796, 96);
            this.lblSQL.TabIndex = 1;
            // 
            // lblSortie
            // 
            this.lblSortie.AcceptsReturn = true;
            this.lblSortie.AcceptsTab = true;
            this.lblSortie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSortie.Location = new System.Drawing.Point(3, 16);
            this.lblSortie.Multiline = true;
            this.lblSortie.Name = "lblSortie";
            this.lblSortie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblSortie.Size = new System.Drawing.Size(796, 263);
            this.lblSortie.TabIndex = 0;
            // 
            // btnExecuter
            // 
            this.btnExecuter.Image = global::PATIO.Properties.Resources.fleche_droite_vert;
            this.btnExecuter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExecuter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExecuter.Name = "btnExecuter";
            this.btnExecuter.Size = new System.Drawing.Size(65, 22);
            this.btnExecuter.Text = "Exécuter";
            this.btnExecuter.Click += new System.EventHandler(this.btnExecuter_Click);
            // 
            // btnEffacer
            // 
            this.btnEffacer.Image = global::PATIO.Properties.Resources.supprimer;
            this.btnEffacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(63, 22);
            this.btnEffacer.Text = "Effacer";
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // btnModele
            // 
            this.btnModele.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModele.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSuppression_lien});
            this.btnModele.Image = global::PATIO.Properties.Resources.btn_ajouter;
            this.btnModele.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnModele.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModele.Name = "btnModele";
            this.btnModele.Size = new System.Drawing.Size(28, 22);
            this.btnModele.Text = "toolStripDropDownButton1";
            // 
            // btnSuppression_lien
            // 
            this.btnSuppression_lien.Name = "btnSuppression_lien";
            this.btnSuppression_lien.Size = new System.Drawing.Size(187, 22);
            this.btnSuppression_lien.Text = "Suppression d\'un lien";
            this.btnSuppression_lien.Click += new System.EventHandler(this.btnSuppression_lien_Click);
            // 
            // ctrlAdmin_DataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlAdmin_DataBase";
            this.Size = new System.Drawing.Size(802, 422);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox lblSQL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExecuter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEffacer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox lblSortie;
        private System.Windows.Forms.ToolStripDropDownButton btnModele;
        private System.Windows.Forms.ToolStripMenuItem btnSuppression_lien;
    }
}
