namespace PATIO.ADMIN
{
    partial class frmModeleDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModeleDoc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabModele = new System.Windows.Forms.TabPage();
            this.btnChoisirFichierBase = new System.Windows.Forms.Button();
            this.lblFichierBase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstTypeModele = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabZone = new System.Windows.Forms.TabPage();
            this.lblConditionZone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabLigne = new System.Windows.Forms.TabPage();
            this.lblConditionLigne = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabColonne = new System.Windows.Forms.TabPage();
            this.lblBordureColonne = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lstAlignementColonne = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTexteColonne = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLibelle = new System.Windows.Forms.TextBox();
            this.OptActive = new System.Windows.Forms.CheckBox();
            this.lblEntete = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRef = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblPct = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabModele.SuspendLayout();
            this.tabZone.SuspendLayout();
            this.tabLigne.SuspendLayout();
            this.tabColonne.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPct)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.BtnAnnuler,
            this.toolStripSeparator2,
            this.BtnValider,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 240);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(520, 30);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // BtnAnnuler
            // 
            this.BtnAnnuler.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnAnnuler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnnuler.Image")));
            this.BtnAnnuler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAnnuler.Name = "BtnAnnuler";
            this.BtnAnnuler.Size = new System.Drawing.Size(69, 27);
            this.BtnAnnuler.Text = "Annuler";
            this.BtnAnnuler.Click += new System.EventHandler(this.BtnAnnuler_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // BtnValider
            // 
            this.BtnValider.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnValider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnValider.Image = ((System.Drawing.Image)(resources.GetObject("BtnValider.Image")));
            this.BtnValider.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnValider.Name = "BtnValider";
            this.BtnValider.Size = new System.Drawing.Size(63, 27);
            this.BtnValider.Text = "Valider";
            this.BtnValider.Click += new System.EventHandler(this.BtnValider_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(69, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 240);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabModele);
            this.tabControl2.Controls.Add(this.tabZone);
            this.tabControl2.Controls.Add(this.tabLigne);
            this.tabControl2.Controls.Add(this.tabColonne);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 77);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(506, 122);
            this.tabControl2.TabIndex = 14;
            // 
            // tabModele
            // 
            this.tabModele.Controls.Add(this.btnChoisirFichierBase);
            this.tabModele.Controls.Add(this.lblFichierBase);
            this.tabModele.Controls.Add(this.label6);
            this.tabModele.Controls.Add(this.lstTypeModele);
            this.tabModele.Controls.Add(this.label5);
            this.tabModele.Location = new System.Drawing.Point(4, 22);
            this.tabModele.Name = "tabModele";
            this.tabModele.Padding = new System.Windows.Forms.Padding(3);
            this.tabModele.Size = new System.Drawing.Size(498, 96);
            this.tabModele.TabIndex = 0;
            this.tabModele.Text = "Modele";
            this.tabModele.UseVisualStyleBackColor = true;
            // 
            // btnChoisirFichierBase
            // 
            this.btnChoisirFichierBase.Location = new System.Drawing.Point(458, 38);
            this.btnChoisirFichierBase.Name = "btnChoisirFichierBase";
            this.btnChoisirFichierBase.Size = new System.Drawing.Size(30, 23);
            this.btnChoisirFichierBase.TabIndex = 11;
            this.btnChoisirFichierBase.Text = "...";
            this.btnChoisirFichierBase.UseVisualStyleBackColor = true;
            // 
            // lblFichierBase
            // 
            this.lblFichierBase.Location = new System.Drawing.Point(130, 41);
            this.lblFichierBase.Name = "lblFichierBase";
            this.lblFichierBase.Size = new System.Drawing.Size(322, 20);
            this.lblFichierBase.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(22, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fichier de base :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstTypeModele
            // 
            this.lstTypeModele.FormattingEnabled = true;
            this.lstTypeModele.Location = new System.Drawing.Point(130, 14);
            this.lstTypeModele.Name = "lstTypeModele";
            this.lstTypeModele.Size = new System.Drawing.Size(322, 21);
            this.lstTypeModele.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(22, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type de modèle :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabZone
            // 
            this.tabZone.Controls.Add(this.lblConditionZone);
            this.tabZone.Controls.Add(this.label2);
            this.tabZone.Location = new System.Drawing.Point(4, 22);
            this.tabZone.Name = "tabZone";
            this.tabZone.Padding = new System.Windows.Forms.Padding(3);
            this.tabZone.Size = new System.Drawing.Size(498, 96);
            this.tabZone.TabIndex = 4;
            this.tabZone.Text = "Zone";
            this.tabZone.UseVisualStyleBackColor = true;
            // 
            // lblConditionZone
            // 
            this.lblConditionZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConditionZone.Location = new System.Drawing.Point(86, 3);
            this.lblConditionZone.Multiline = true;
            this.lblConditionZone.Name = "lblConditionZone";
            this.lblConditionZone.Size = new System.Drawing.Size(409, 90);
            this.lblConditionZone.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 90);
            this.label2.TabIndex = 9;
            this.label2.Text = "Conditions :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabLigne
            // 
            this.tabLigne.Controls.Add(this.lblConditionLigne);
            this.tabLigne.Controls.Add(this.label7);
            this.tabLigne.Location = new System.Drawing.Point(4, 22);
            this.tabLigne.Name = "tabLigne";
            this.tabLigne.Padding = new System.Windows.Forms.Padding(3);
            this.tabLigne.Size = new System.Drawing.Size(498, 96);
            this.tabLigne.TabIndex = 1;
            this.tabLigne.Text = "Ligne";
            this.tabLigne.UseVisualStyleBackColor = true;
            // 
            // lblConditionLigne
            // 
            this.lblConditionLigne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConditionLigne.Location = new System.Drawing.Point(86, 3);
            this.lblConditionLigne.Multiline = true;
            this.lblConditionLigne.Name = "lblConditionLigne";
            this.lblConditionLigne.Size = new System.Drawing.Size(409, 90);
            this.lblConditionLigne.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 90);
            this.label7.TabIndex = 11;
            this.label7.Text = "Conditions :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabColonne
            // 
            this.tabColonne.Controls.Add(this.lblPct);
            this.tabColonne.Controls.Add(this.lblBordureColonne);
            this.tabColonne.Controls.Add(this.label12);
            this.tabColonne.Controls.Add(this.lstAlignementColonne);
            this.tabColonne.Controls.Add(this.label11);
            this.tabColonne.Controls.Add(this.label10);
            this.tabColonne.Controls.Add(this.lblTexteColonne);
            this.tabColonne.Controls.Add(this.label9);
            this.tabColonne.Location = new System.Drawing.Point(4, 22);
            this.tabColonne.Name = "tabColonne";
            this.tabColonne.Size = new System.Drawing.Size(498, 96);
            this.tabColonne.TabIndex = 3;
            this.tabColonne.Text = "Colonne";
            this.tabColonne.UseVisualStyleBackColor = true;
            // 
            // lblBordureColonne
            // 
            this.lblBordureColonne.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblBordureColonne.Location = new System.Drawing.Point(410, 59);
            this.lblBordureColonne.Name = "lblBordureColonne";
            this.lblBordureColonne.Size = new System.Drawing.Size(85, 20);
            this.lblBordureColonne.TabIndex = 18;
            this.toolTip1.SetToolTip(this.lblBordureColonne, "Combiner les lettres\r\nH pour Haut\r\nB pour Bas\r\nG pour Gauche\r\nD pour droite");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(355, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 23);
            this.label12.TabIndex = 17;
            this.label12.Text = "Bordure :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstAlignementColonne
            // 
            this.lstAlignementColonne.FormattingEnabled = true;
            this.lstAlignementColonne.Location = new System.Drawing.Point(254, 58);
            this.lstAlignementColonne.Name = "lstAlignementColonne";
            this.lstAlignementColonne.Size = new System.Drawing.Size(95, 21);
            this.lstAlignementColonne.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(183, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Alignement :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(24, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 23);
            this.label10.TabIndex = 14;
            this.label10.Text = "Taille :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTexteColonne
            // 
            this.lblTexteColonne.Location = new System.Drawing.Point(86, 10);
            this.lblTexteColonne.Multiline = true;
            this.lblTexteColonne.Name = "lblTexteColonne";
            this.lblTexteColonne.Size = new System.Drawing.Size(409, 40);
            this.lblTexteColonne.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 40);
            this.label9.TabIndex = 11;
            this.label9.Text = "Texte :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLibelle);
            this.panel1.Controls.Add(this.OptActive);
            this.panel1.Controls.Add(this.lblEntete);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblRef);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 74);
            this.panel1.TabIndex = 12;
            // 
            // lblLibelle
            // 
            this.lblLibelle.Location = new System.Drawing.Point(134, 14);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(322, 20);
            this.lblLibelle.TabIndex = 0;
            // 
            // OptActive
            // 
            this.OptActive.AutoSize = true;
            this.OptActive.Location = new System.Drawing.Point(414, 46);
            this.OptActive.Name = "OptActive";
            this.OptActive.Size = new System.Drawing.Size(42, 17);
            this.OptActive.TabIndex = 3;
            this.OptActive.Text = "Oui";
            this.OptActive.UseVisualStyleBackColor = true;
            // 
            // lblEntete
            // 
            this.lblEntete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblEntete.Enabled = false;
            this.lblEntete.Location = new System.Drawing.Point(134, 42);
            this.lblEntete.Name = "lblEntete";
            this.lblEntete.Size = new System.Drawing.Size(47, 20);
            this.lblEntete.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(334, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Activation :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRef
            // 
            this.lblRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblRef.Location = new System.Drawing.Point(184, 42);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(113, 20);
            this.lblRef.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Libelle :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Code :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPct
            // 
            this.lblPct.Location = new System.Drawing.Point(86, 57);
            this.lblPct.Name = "lblPct";
            this.lblPct.Size = new System.Drawing.Size(47, 20);
            this.lblPct.TabIndex = 19;
            this.lblPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmModeleDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 270);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModeleDoc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche Utilisateur";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabModele.ResumeLayout(false);
            this.tabModele.PerformLayout();
            this.tabZone.ResumeLayout(false);
            this.tabZone.PerformLayout();
            this.tabLigne.ResumeLayout(false);
            this.tabLigne.PerformLayout();
            this.tabColonne.ResumeLayout(false);
            this.tabColonne.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblPct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnAnnuler;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnValider;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox lstTypeModele;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox OptActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lblLibelle;
        private System.Windows.Forms.TextBox lblEntete;
        private System.Windows.Forms.TextBox lblRef;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabModele;
        private System.Windows.Forms.TabPage tabLigne;
        private System.Windows.Forms.TabPage tabColonne;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabZone;
        private System.Windows.Forms.TextBox lblConditionZone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChoisirFichierBase;
        private System.Windows.Forms.TextBox lblFichierBase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lblConditionLigne;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox lblTexteColonne;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lblBordureColonne;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox lstAlignementColonne;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.NumericUpDown lblPct;
    }
}