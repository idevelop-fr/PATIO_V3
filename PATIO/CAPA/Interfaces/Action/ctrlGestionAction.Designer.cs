namespace PATIO.CAPA.Interfaces
{
    partial class ctrlGestionAction
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
            this.tabControlElement = new System.Windows.Forms.TabControl();
            this.tabProjet = new System.Windows.Forms.TabPage();
            this.tabInformation = new System.Windows.Forms.TabPage();
            this.tabIndicateur = new System.Windows.Forms.TabPage();
            this.tabDocument = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ctrlGestionAction_Information1 = new PATIO.CAPA.Interfaces.ctrlGestionAction_Information();
            this.ctrlGestionAction_Indicateur1 = new PATIO.CAPA.Interfaces.ctrlGestionAction_Indicateur();
            this.ctrlGestionAction_Document1 = new PATIO.CAPA.Interfaces.ctrlGestionAction_Document();
            this.ctrlListeProjet1 = new PATIO.CAPA.Interfaces.ctrlListeProjet();
            this.tabControlElement.SuspendLayout();
            this.tabProjet.SuspendLayout();
            this.tabInformation.SuspendLayout();
            this.tabIndicateur.SuspendLayout();
            this.tabDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlElement
            // 
            this.tabControlElement.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlElement.Controls.Add(this.tabProjet);
            this.tabControlElement.Controls.Add(this.tabInformation);
            this.tabControlElement.Controls.Add(this.tabIndicateur);
            this.tabControlElement.Controls.Add(this.tabDocument);
            this.tabControlElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlElement.ItemSize = new System.Drawing.Size(20, 40);
            this.tabControlElement.Location = new System.Drawing.Point(4, 0);
            this.tabControlElement.Multiline = true;
            this.tabControlElement.Name = "tabControlElement";
            this.tabControlElement.SelectedIndex = 0;
            this.tabControlElement.Size = new System.Drawing.Size(672, 473);
            this.tabControlElement.TabIndex = 0;
            // 
            // tabProjet
            // 
            this.tabProjet.Controls.Add(this.ctrlListeProjet1);
            this.tabProjet.Location = new System.Drawing.Point(4, 44);
            this.tabProjet.Name = "tabProjet";
            this.tabProjet.Size = new System.Drawing.Size(664, 425);
            this.tabProjet.TabIndex = 3;
            this.tabProjet.Text = "Projets";
            this.tabProjet.UseVisualStyleBackColor = true;
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.ctrlGestionAction_Information1);
            this.tabInformation.ImageIndex = 0;
            this.tabInformation.Location = new System.Drawing.Point(4, 44);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformation.Size = new System.Drawing.Size(664, 425);
            this.tabInformation.TabIndex = 0;
            this.tabInformation.Text = "Informations";
            this.tabInformation.UseVisualStyleBackColor = true;
            // 
            // tabIndicateur
            // 
            this.tabIndicateur.Controls.Add(this.ctrlGestionAction_Indicateur1);
            this.tabIndicateur.ImageIndex = 1;
            this.tabIndicateur.Location = new System.Drawing.Point(4, 44);
            this.tabIndicateur.Name = "tabIndicateur";
            this.tabIndicateur.Padding = new System.Windows.Forms.Padding(3);
            this.tabIndicateur.Size = new System.Drawing.Size(664, 425);
            this.tabIndicateur.TabIndex = 1;
            this.tabIndicateur.Text = "Indicateurs";
            this.tabIndicateur.UseVisualStyleBackColor = true;
            // 
            // tabDocument
            // 
            this.tabDocument.Controls.Add(this.ctrlGestionAction_Document1);
            this.tabDocument.Location = new System.Drawing.Point(4, 44);
            this.tabDocument.Name = "tabDocument";
            this.tabDocument.Size = new System.Drawing.Size(664, 425);
            this.tabDocument.TabIndex = 2;
            this.tabDocument.Text = "Documents";
            this.tabDocument.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 473);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // ctrlGestionAction_Information1
            // 
            this.ctrlGestionAction_Information1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGestionAction_Information1.Location = new System.Drawing.Point(3, 3);
            this.ctrlGestionAction_Information1.Name = "ctrlGestionAction_Information1";
            this.ctrlGestionAction_Information1.Padding = new System.Windows.Forms.Padding(3);
            this.ctrlGestionAction_Information1.Size = new System.Drawing.Size(658, 419);
            this.ctrlGestionAction_Information1.TabIndex = 0;
            // 
            // ctrlGestionAction_Indicateur1
            // 
            this.ctrlGestionAction_Indicateur1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlGestionAction_Indicateur1.Location = new System.Drawing.Point(3, 3);
            this.ctrlGestionAction_Indicateur1.Name = "ctrlGestionAction_Indicateur1";
            this.ctrlGestionAction_Indicateur1.Padding = new System.Windows.Forms.Padding(3);
            this.ctrlGestionAction_Indicateur1.Size = new System.Drawing.Size(658, 429);
            this.ctrlGestionAction_Indicateur1.TabIndex = 0;
            // 
            // ctrlGestionAction_Document1
            // 
            this.ctrlGestionAction_Document1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGestionAction_Document1.Location = new System.Drawing.Point(0, 0);
            this.ctrlGestionAction_Document1.Name = "ctrlGestionAction_Document1";
            this.ctrlGestionAction_Document1.Padding = new System.Windows.Forms.Padding(3);
            this.ctrlGestionAction_Document1.Size = new System.Drawing.Size(664, 425);
            this.ctrlGestionAction_Document1.TabIndex = 0;
            // 
            // ctrlListeProjet1
            // 
            this.ctrlListeProjet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlListeProjet1.Location = new System.Drawing.Point(0, 0);
            this.ctrlListeProjet1.Name = "ctrlListeProjet1";
            this.ctrlListeProjet1.Size = new System.Drawing.Size(664, 425);
            this.ctrlListeProjet1.TabIndex = 0;
            // 
            // ctrlGestionAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlElement);
            this.Controls.Add(this.splitter1);
            this.Name = "ctrlGestionAction";
            this.Size = new System.Drawing.Size(676, 473);
            this.tabControlElement.ResumeLayout(false);
            this.tabProjet.ResumeLayout(false);
            this.tabInformation.ResumeLayout(false);
            this.tabIndicateur.ResumeLayout(false);
            this.tabDocument.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlElement;
        private System.Windows.Forms.TabPage tabInformation;
        private System.Windows.Forms.TabPage tabIndicateur;
        private System.Windows.Forms.TabPage tabDocument;
        private ctrlGestionAction_Information ctrlGestionAction_Information1;
        private ctrlGestionAction_Indicateur ctrlGestionAction_Indicateur1;
        private ctrlGestionAction_Document ctrlGestionAction_Document1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabPage tabProjet;
        private ctrlListeProjet ctrlListeProjet1;
    }
}
