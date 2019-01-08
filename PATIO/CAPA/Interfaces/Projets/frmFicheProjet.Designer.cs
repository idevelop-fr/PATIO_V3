namespace PATIO.CAPA.Interfaces
{
    partial class frmFicheProjet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFicheProjet));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCode = new System.Windows.Forms.ToolStripLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstStatut = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLibelleProjet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRef2 = new System.Windows.Forms.TextBox();
            this.lblCodeProjet = new System.Windows.Forms.TextBox();
            this.lblEntete = new System.Windows.Forms.TextBox();
            this.lblRef1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lstPilote = new System.Windows.Forms.ComboBox();
            this.lstTypeProjet = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OptActiveProjet = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.toolStripSeparator3,
            this.lblCode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 471);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1114, 58);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 58);
            // 
            // BtnAnnuler
            // 
            this.BtnAnnuler.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnAnnuler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnnuler.Image")));
            this.BtnAnnuler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAnnuler.Name = "BtnAnnuler";
            this.BtnAnnuler.Size = new System.Drawing.Size(135, 55);
            this.BtnAnnuler.Text = "Annuler";
            this.BtnAnnuler.Click += new System.EventHandler(this.BtnAnnuler_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 58);
            // 
            // BtnValider
            // 
            this.BtnValider.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnValider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnValider.Image = ((System.Drawing.Image)(resources.GetObject("BtnValider.Image")));
            this.BtnValider.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnValider.Name = "BtnValider";
            this.BtnValider.Size = new System.Drawing.Size(121, 55);
            this.BtnValider.Text = "Valider";
            this.BtnValider.Click += new System.EventHandler(this.BtnValider_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 58);
            // 
            // lblCode
            // 
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(0, 55);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstStatut);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lblLibelleProjet);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblRef2);
            this.tabPage1.Controls.Add(this.lblCodeProjet);
            this.tabPage1.Controls.Add(this.lblEntete);
            this.tabPage1.Controls.Add(this.lblRef1);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.lstPilote);
            this.tabPage1.Controls.Add(this.lstTypeProjet);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.OptActiveProjet);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(8, 38);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(1098, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstStatut
            // 
            this.lstStatut.FormattingEnabled = true;
            this.lstStatut.Location = new System.Drawing.Point(690, 333);
            this.lstStatut.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstStatut.Name = "lstStatut";
            this.lstStatut.Size = new System.Drawing.Size(372, 33);
            this.lstStatut.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(476, 333);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 44);
            this.label6.TabIndex = 26;
            this.label6.Text = "Statut :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLibelleProjet
            // 
            this.lblLibelleProjet.Location = new System.Drawing.Point(328, 35);
            this.lblLibelleProjet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblLibelleProjet.Name = "lblLibelleProjet";
            this.lblLibelleProjet.Size = new System.Drawing.Size(734, 31);
            this.lblLibelleProjet.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 281);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 44);
            this.label5.TabIndex = 25;
            this.label5.Text = "Pilote :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRef2
            // 
            this.lblRef2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblRef2.Location = new System.Drawing.Point(736, 187);
            this.lblRef2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblRef2.Name = "lblRef2";
            this.lblRef2.Size = new System.Drawing.Size(326, 31);
            this.lblRef2.TabIndex = 3;
            this.lblRef2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblRef2.TextChanged += new System.EventHandler(this.lblRef2_TextChanged);
            // 
            // lblCodeProjet
            // 
            this.lblCodeProjet.Enabled = false;
            this.lblCodeProjet.Location = new System.Drawing.Point(328, 235);
            this.lblCodeProjet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblCodeProjet.Name = "lblCodeProjet";
            this.lblCodeProjet.Size = new System.Drawing.Size(734, 31);
            this.lblCodeProjet.TabIndex = 18;
            // 
            // lblEntete
            // 
            this.lblEntete.Enabled = false;
            this.lblEntete.Location = new System.Drawing.Point(328, 185);
            this.lblEntete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblEntete.Name = "lblEntete";
            this.lblEntete.Size = new System.Drawing.Size(108, 31);
            this.lblEntete.TabIndex = 20;
            this.lblEntete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRef1
            // 
            this.lblRef1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblRef1.Location = new System.Drawing.Point(452, 185);
            this.lblRef1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblRef1.Name = "lblRef1";
            this.lblRef1.Size = new System.Drawing.Size(268, 31);
            this.lblRef1.TabIndex = 2;
            this.lblRef1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblRef1.TextChanged += new System.EventHandler(this.lblRef1_TextChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(730, 142);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(336, 50);
            this.label12.TabIndex = 23;
            this.label12.Text = "Réf 2";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(452, 140);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(272, 50);
            this.label11.TabIndex = 22;
            this.label11.Text = "Réf.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 235);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(310, 44);
            this.label9.TabIndex = 19;
            this.label9.Text = "Code généré :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstPilote
            // 
            this.lstPilote.FormattingEnabled = true;
            this.lstPilote.Location = new System.Drawing.Point(328, 285);
            this.lstPilote.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstPilote.Name = "lstPilote";
            this.lstPilote.Size = new System.Drawing.Size(734, 33);
            this.lstPilote.TabIndex = 6;
            // 
            // lstTypeProjet
            // 
            this.lstTypeProjet.FormattingEnabled = true;
            this.lstTypeProjet.Location = new System.Drawing.Point(328, 85);
            this.lstTypeProjet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstTypeProjet.Name = "lstTypeProjet";
            this.lstTypeProjet.Size = new System.Drawing.Size(578, 33);
            this.lstTypeProjet.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 44);
            this.label4.TabIndex = 6;
            this.label4.Text = "Type de projet :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Libellé du projet :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OptActiveProjet
            // 
            this.OptActiveProjet.AutoSize = true;
            this.OptActiveProjet.Location = new System.Drawing.Point(334, 337);
            this.OptActiveProjet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OptActiveProjet.Name = "OptActiveProjet";
            this.OptActiveProjet.Size = new System.Drawing.Size(77, 29);
            this.OptActiveProjet.TabIndex = 7;
            this.OptActiveProjet.Text = "Oui";
            this.OptActiveProjet.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 325);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 44);
            this.label3.TabIndex = 4;
            this.label3.Text = "Activation :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 44);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code Projet :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(328, 142);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 48);
            this.label10.TabIndex = 21;
            this.label10.Text = "Type";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(69, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1114, 471);
            this.tabControl1.TabIndex = 3;
            // 
            // frmFicheProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 529);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFicheProjet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche projet";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnAnnuler;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnValider;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblCode;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox lblRef2;
        private System.Windows.Forms.TextBox lblCodeProjet;
        private System.Windows.Forms.TextBox lblEntete;
        private System.Windows.Forms.TextBox lblLibelleProjet;
        private System.Windows.Forms.TextBox lblRef1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox lstPilote;
        private System.Windows.Forms.ComboBox lstTypeProjet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox OptActiveProjet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox lstStatut;
        private System.Windows.Forms.Label label6;
    }
}