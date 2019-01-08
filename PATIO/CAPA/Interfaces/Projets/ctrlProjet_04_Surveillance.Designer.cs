namespace PATIO.CAPA.Interfaces
{
    partial class ctrlProjet_04_Surveillance
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstProcessus = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(191, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 370);
            this.panel1.TabIndex = 6;
            // 
            // lstProcessus
            // 
            this.lstProcessus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstProcessus.FormattingEnabled = true;
            this.lstProcessus.Location = new System.Drawing.Point(0, 0);
            this.lstProcessus.Name = "lstProcessus";
            this.lstProcessus.Size = new System.Drawing.Size(191, 370);
            this.lstProcessus.TabIndex = 5;
            // 
            // ctrlProjet_04_Surveillance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstProcessus);
            this.Name = "ctrlProjet_04_Surveillance";
            this.Size = new System.Drawing.Size(731, 370);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstProcessus;
    }
}
