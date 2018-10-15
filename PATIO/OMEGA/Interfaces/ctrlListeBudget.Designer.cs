namespace PATIO.OMEGA.Interfaces
{
    partial class ctrlListeBudget
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
            this.btnCréerExercice = new System.Windows.Forms.ToolStripButton();
            this.BtnCréerSousAction = new System.Windows.Forms.ToolStripButton();
            this.BtnModifierAction = new System.Windows.Forms.ToolStripButton();
            this.BtnSupprimerAction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnActualiserAction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecherche = new System.Windows.Forms.ToolStripTextBox();
            this.lstBudget = new System.Windows.Forms.TreeView();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.btnCréerExercice,
            this.BtnCréerSousAction,
            this.BtnModifierAction,
            this.BtnSupprimerAction,
            this.toolStripSeparator7,
            this.toolStripSeparator10,
            this.BtnActualiserAction,
            this.toolStripSeparator19,
            this.lblRecherche});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(350, 25);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCréerExercice
            // 
            this.btnCréerExercice.BackColor = System.Drawing.SystemColors.Control;
            this.btnCréerExercice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCréerExercice.Image = global::PATIO.Properties.Resources.plus;
            this.btnCréerExercice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCréerExercice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCréerExercice.Name = "btnCréerExercice";
            this.btnCréerExercice.Size = new System.Drawing.Size(23, 22);
            this.btnCréerExercice.Text = "Créer un exercice";
            this.btnCréerExercice.Click += new System.EventHandler(this.btnCréerExercice_Click);
            // 
            // BtnCréerSousAction
            // 
            this.BtnCréerSousAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCréerSousAction.Image = global::PATIO.Properties.Resources.plus_o;
            this.BtnCréerSousAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnCréerSousAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCréerSousAction.Name = "BtnCréerSousAction";
            this.BtnCréerSousAction.Size = new System.Drawing.Size(23, 22);
            this.BtnCréerSousAction.Text = "Créer une sous-action";
            this.BtnCréerSousAction.Click += new System.EventHandler(this.BtnCréerSousAction_Click);
            // 
            // BtnModifierAction
            // 
            this.BtnModifierAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnModifierAction.Image = global::PATIO.Properties.Resources.btn_modifier;
            this.BtnModifierAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnModifierAction.Name = "BtnModifierAction";
            this.BtnModifierAction.Size = new System.Drawing.Size(23, 22);
            this.BtnModifierAction.Text = "Modifier";
            // 
            // BtnSupprimerAction
            // 
            this.BtnSupprimerAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSupprimerAction.Image = global::PATIO.Properties.Resources.btn_supprimer;
            this.BtnSupprimerAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnSupprimerAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSupprimerAction.Name = "BtnSupprimerAction";
            this.BtnSupprimerAction.Size = new System.Drawing.Size(23, 22);
            this.BtnSupprimerAction.Text = "Supprimer";
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
            // BtnActualiserAction
            // 
            this.BtnActualiserAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnActualiserAction.Image = global::PATIO.Properties.Resources.btn_maj;
            this.BtnActualiserAction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnActualiserAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnActualiserAction.Name = "BtnActualiserAction";
            this.BtnActualiserAction.Size = new System.Drawing.Size(23, 22);
            this.BtnActualiserAction.Text = "Actualiser";
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
            this.lblRecherche.Size = new System.Drawing.Size(150, 25);
            // 
            // lstBudget
            // 
            this.lstBudget.AllowDrop = true;
            this.lstBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBudget.FullRowSelect = true;
            this.lstBudget.HideSelection = false;
            this.lstBudget.Location = new System.Drawing.Point(0, 25);
            this.lstBudget.Name = "lstBudget";
            this.lstBudget.ShowNodeToolTips = true;
            this.lstBudget.Size = new System.Drawing.Size(350, 416);
            this.lstBudget.TabIndex = 11;
            // 
            // ctrlListeBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstBudget);
            this.Controls.Add(this.toolStrip3);
            this.Name = "ctrlListeBudget";
            this.Size = new System.Drawing.Size(350, 441);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnCréerExercice;
        private System.Windows.Forms.ToolStripButton BtnCréerSousAction;
        private System.Windows.Forms.ToolStripButton BtnModifierAction;
        private System.Windows.Forms.ToolStripButton BtnSupprimerAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton BtnActualiserAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        public System.Windows.Forms.ToolStripTextBox lblRecherche;
        public System.Windows.Forms.TreeView lstBudget;
    }
}
