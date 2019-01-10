namespace PATIO.CAPA.Interfaces
{
    partial class ctrlProjetFinance
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Expression de besoins");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Conventions/EJ");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Eléments financiers");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Rapports/Bilans");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Eléments de suivi");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Evaluation");
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeFiche = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAjouter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModifierPlan = new System.Windows.Forms.ToolStripButton();
            this.btnSupprimerPlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeFiche);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 306);
            this.panel1.TabIndex = 15;
            // 
            // treeFiche
            // 
            this.treeFiche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFiche.Location = new System.Drawing.Point(0, 25);
            this.treeFiche.Name = "treeFiche";
            treeNode1.Name = "Nœud0";
            treeNode1.Text = "Expression de besoins";
            treeNode2.Name = "Nœud1";
            treeNode2.Text = "Conventions/EJ";
            treeNode3.Name = "Nœud2";
            treeNode3.Text = "Eléments financiers";
            treeNode4.Name = "Nœud3";
            treeNode4.Text = "Rapports/Bilans";
            treeNode5.Name = "Nœud4";
            treeNode5.Text = "Eléments de suivi";
            treeNode6.Name = "Nœud6";
            treeNode6.Text = "Evaluation";
            this.treeFiche.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeFiche.Size = new System.Drawing.Size(215, 281);
            this.treeFiche.TabIndex = 16;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnAjouter,
            this.toolStripSeparator17,
            this.btnModifierPlan,
            this.btnSupprimerPlan,
            this.toolStripSeparator2,
            this.toolStripSeparator16});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(215, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAjouter
            // 
            this.btnAjouter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjouter.Image = global::PATIO.Properties.Resources.plus;
            this.btnAjouter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAjouter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(23, 22);
            this.btnAjouter.Text = "Ajouter une itération";
            this.btnAjouter.ToolTipText = "Ajouter un document";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // btnModifierPlan
            // 
            this.btnModifierPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnModifierPlan.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.btnModifierPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifierPlan.Name = "btnModifierPlan";
            this.btnModifierPlan.Size = new System.Drawing.Size(23, 22);
            this.btnModifierPlan.Text = "Modifier";
            // 
            // btnSupprimerPlan
            // 
            this.btnSupprimerPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSupprimerPlan.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.btnSupprimerPlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSupprimerPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSupprimerPlan.Name = "btnSupprimerPlan";
            this.btnSupprimerPlan.Size = new System.Drawing.Size(23, 22);
            this.btnSupprimerPlan.Text = "Supprimer";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(215, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 306);
            this.panel2.TabIndex = 16;
            // 
            // ctrlProjetFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlProjetFinance";
            this.Size = new System.Drawing.Size(613, 306);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeFiche;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAjouter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton btnModifierPlan;
        private System.Windows.Forms.ToolStripButton btnSupprimerPlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.Panel panel2;
    }
}
