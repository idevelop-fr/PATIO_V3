namespace PATIO.CAPA.Interfaces
{
    partial class ElementProjet
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementProjet));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.btnOuvrir = new System.Windows.Forms.Button();
            this.lblStatut = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lstInfo = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDown.Image = global::PATIO.Properties.Resources.fleche_bas;
            this.btnDown.Location = new System.Drawing.Point(390, 1);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(25, 30);
            this.btnDown.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnDown, "Agrandir l\'élément");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUp.Image = global::PATIO.Properties.Resources.fleche_haut;
            this.btnUp.Location = new System.Drawing.Point(415, 1);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(25, 30);
            this.btnUp.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnUp, "Réduire l\'élément");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitre);
            this.panel1.Controls.Add(this.btnOuvrir);
            this.panel1.Controls.Add(this.lblStatut);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(441, 32);
            this.panel1.TabIndex = 4;
            // 
            // lblTitre
            // 
            this.lblTitre.BackColor = System.Drawing.Color.White;
            this.lblTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitre.Location = new System.Drawing.Point(19, 1);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(319, 30);
            this.lblTitre.TabIndex = 1;
            this.lblTitre.Text = "Titre du projet";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOuvrir
            // 
            this.btnOuvrir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOuvrir.Location = new System.Drawing.Point(338, 1);
            this.btnOuvrir.Name = "btnOuvrir";
            this.btnOuvrir.Size = new System.Drawing.Size(47, 30);
            this.btnOuvrir.TabIndex = 11;
            this.btnOuvrir.Text = "Ouvrir";
            this.btnOuvrir.UseVisualStyleBackColor = true;
            this.btnOuvrir.Click += new System.EventHandler(this.btnOuvrir_Click);
            this.btnOuvrir.MouseEnter += new System.EventHandler(this.btnOuvrir_MouseEnter);
            this.btnOuvrir.MouseLeave += new System.EventHandler(this.btnOuvrir_MouseLeave);
            // 
            // lblStatut
            // 
            this.lblStatut.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatut.Image = global::PATIO.Properties.Resources.btn_triangle_jaune;
            this.lblStatut.Location = new System.Drawing.Point(1, 1);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(18, 30);
            this.lblStatut.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(385, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 30);
            this.panel3.TabIndex = 10;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btn_cercle-D.png");
            this.imageList1.Images.SetKeyName(1, "btn_cercle-F.png");
            this.imageList1.Images.SetKeyName(2, "btn_cercle-i.png");
            // 
            // lstInfo
            // 
            this.lstInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInfo.FormattingEnabled = true;
            this.lstInfo.Location = new System.Drawing.Point(1, 33);
            this.lstInfo.Name = "lstInfo";
            this.lstInfo.Size = new System.Drawing.Size(441, 115);
            this.lstInfo.TabIndex = 5;
            // 
            // ElementProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lstInfo);
            this.Controls.Add(this.panel1);
            this.Name = "ElementProjet";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(443, 149);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnOuvrir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.ListBox lstInfo;
    }
}
