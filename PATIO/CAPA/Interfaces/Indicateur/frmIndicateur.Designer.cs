namespace PATIO.CAPA.Interfaces
{
    partial class frmIndicateur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndicateur));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstTypeIndicateur = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OptActiveIndicateur = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodeIndicateur = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLibelleIndicateur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstRepartition_6PO = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstCateg_6PO = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstGenre_6PO = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstType_6PO = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.BtnAnnuler,
            this.toolStripSeparator2,
            this.BtnValider,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 234);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(618, 30);
            this.toolStrip1.TabIndex = 6;
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 234);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(610, 208);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations générales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTypeIndicateur);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.OptActiveIndicateur);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblCodeIndicateur);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblLibelleIndicateur);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 202);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informations sur l\'indicateur";
            // 
            // lstTypeIndicateur
            // 
            this.lstTypeIndicateur.FormattingEnabled = true;
            this.lstTypeIndicateur.Location = new System.Drawing.Point(178, 78);
            this.lstTypeIndicateur.Name = "lstTypeIndicateur";
            this.lstTypeIndicateur.Size = new System.Drawing.Size(406, 21);
            this.lstTypeIndicateur.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(26, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Type d\'indicateur :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OptActiveIndicateur
            // 
            this.OptActiveIndicateur.AutoSize = true;
            this.OptActiveIndicateur.Location = new System.Drawing.Point(187, 140);
            this.OptActiveIndicateur.Name = "OptActiveIndicateur";
            this.OptActiveIndicateur.Size = new System.Drawing.Size(42, 17);
            this.OptActiveIndicateur.TabIndex = 3;
            this.OptActiveIndicateur.Text = "Oui";
            this.OptActiveIndicateur.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Activation :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCodeIndicateur
            // 
            this.lblCodeIndicateur.Location = new System.Drawing.Point(178, 107);
            this.lblCodeIndicateur.Name = "lblCodeIndicateur";
            this.lblCodeIndicateur.Size = new System.Drawing.Size(406, 20);
            this.lblCodeIndicateur.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code de l\'indicateur :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLibelleIndicateur
            // 
            this.lblLibelleIndicateur.Location = new System.Drawing.Point(178, 30);
            this.lblLibelleIndicateur.Multiline = true;
            this.lblLibelleIndicateur.Name = "lblLibelleIndicateur";
            this.lblLibelleIndicateur.Size = new System.Drawing.Size(406, 42);
            this.lblLibelleIndicateur.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Libellé de l\'indicateur :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstRepartition_6PO);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.lstCateg_6PO);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.lstGenre_6PO);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lstType_6PO);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(610, 208);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "6PO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstRepartition_6PO
            // 
            this.lstRepartition_6PO.FormattingEnabled = true;
            this.lstRepartition_6PO.Location = new System.Drawing.Point(161, 98);
            this.lstRepartition_6PO.Name = "lstRepartition_6PO";
            this.lstRepartition_6PO.Size = new System.Drawing.Size(423, 21);
            this.lstRepartition_6PO.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Répartition :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstCateg_6PO
            // 
            this.lstCateg_6PO.FormattingEnabled = true;
            this.lstCateg_6PO.Location = new System.Drawing.Point(161, 71);
            this.lstCateg_6PO.Name = "lstCateg_6PO";
            this.lstCateg_6PO.Size = new System.Drawing.Size(423, 21);
            this.lstCateg_6PO.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Catégorie :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstGenre_6PO
            // 
            this.lstGenre_6PO.FormattingEnabled = true;
            this.lstGenre_6PO.Location = new System.Drawing.Point(161, 44);
            this.lstGenre_6PO.Name = "lstGenre_6PO";
            this.lstGenre_6PO.Size = new System.Drawing.Size(423, 21);
            this.lstGenre_6PO.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Genre :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstType_6PO
            // 
            this.lstType_6PO.FormattingEnabled = true;
            this.lstType_6PO.Location = new System.Drawing.Point(161, 17);
            this.lstType_6PO.Name = "lstType_6PO";
            this.lstType_6PO.Size = new System.Drawing.Size(423, 21);
            this.lstType_6PO.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmIndicateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 264);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIndicateur";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche Indicateur";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox lstTypeIndicateur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox OptActiveIndicateur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lblCodeIndicateur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lblLibelleIndicateur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox lstType_6PO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox lstCateg_6PO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox lstGenre_6PO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox lstRepartition_6PO;
    }
}