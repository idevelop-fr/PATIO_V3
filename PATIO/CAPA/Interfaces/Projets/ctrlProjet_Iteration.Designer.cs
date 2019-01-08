namespace PATIO.CAPA.Interfaces
{
    partial class ctrlProjet_Iteration
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrlProjet_02_Planification1 = new ctrlProjet_02_Planification();
            this.ctrlProjet_03_Execution1 = new ctrlProjet_03_Execution();
            this.ctrlProjet_04_Surveillance1 = new ctrlProjet_04_Surveillance();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(845, 511);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlProjet_02_Planification1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(837, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Planification";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlProjet_03_Execution1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(837, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Exécution";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlProjet_04_Surveillance1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(837, 485);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Surveillance";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctrlProjet_02_Planification1
            // 
            this.ctrlProjet_02_Planification1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_02_Planification1.Location = new System.Drawing.Point(3, 3);
            this.ctrlProjet_02_Planification1.Name = "ctrlProjet_02_Planification1";
            this.ctrlProjet_02_Planification1.Size = new System.Drawing.Size(831, 479);
            this.ctrlProjet_02_Planification1.TabIndex = 0;
            // 
            // ctrlProjet_03_Execution1
            // 
            this.ctrlProjet_03_Execution1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_03_Execution1.Location = new System.Drawing.Point(3, 3);
            this.ctrlProjet_03_Execution1.Name = "ctrlProjet_03_Execution1";
            this.ctrlProjet_03_Execution1.Size = new System.Drawing.Size(831, 479);
            this.ctrlProjet_03_Execution1.TabIndex = 0;
            // 
            // ctrlProjet_04_Surveillance1
            // 
            this.ctrlProjet_04_Surveillance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjet_04_Surveillance1.Location = new System.Drawing.Point(0, 0);
            this.ctrlProjet_04_Surveillance1.Name = "ctrlProjet_04_Surveillance1";
            this.ctrlProjet_04_Surveillance1.Size = new System.Drawing.Size(837, 485);
            this.ctrlProjet_04_Surveillance1.TabIndex = 0;
            // 
            // ctrlProjet_Iteration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ctrlProjet_Iteration";
            this.Size = new System.Drawing.Size(845, 511);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ctrlProjet_02_Planification ctrlProjet_02_Planification1;
        private ctrlProjet_03_Execution ctrlProjet_03_Execution1;
        private ctrlProjet_04_Surveillance ctrlProjet_04_Surveillance1;
    }
}
