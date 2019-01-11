namespace PATIO.OMEGA.Interfaces.Association
{
    partial class frmFicheAssociation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFicheAssociation));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCode = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlChoixListe2 = new PATIO.MAIN.Interfaces.ctrlChoixListe();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlChoixListe1 = new PATIO.MAIN.Interfaces.ctrlChoixListe();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblLibelle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstTypePeriode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optValidation = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.toolStripSeparator3,
            this.lblCode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 441);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(691, 30);
            this.toolStrip1.TabIndex = 4;
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
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // lblCode
            // 
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(0, 27);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(69, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 441);
            this.tabControl1.TabIndex = 65;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlChoixListe2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(677, 147);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choix d\'un projet";
            // 
            // ctrlChoixListe2
            // 
            this.ctrlChoixListe2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChoixListe2.Location = new System.Drawing.Point(3, 16);
            this.ctrlChoixListe2.Name = "ctrlChoixListe2";
            this.ctrlChoixListe2.Size = new System.Drawing.Size(671, 128);
            this.ctrlChoixListe2.TabIndex = 2;
            this.ctrlChoixListe2.Tag = "CHOIXLISTE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlChoixListe1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 159);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choix d\'un compte budgétaire";
            // 
            // ctrlChoixListe1
            // 
            this.ctrlChoixListe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChoixListe1.Location = new System.Drawing.Point(3, 16);
            this.ctrlChoixListe1.Name = "ctrlChoixListe1";
            this.ctrlChoixListe1.Size = new System.Drawing.Size(671, 140);
            this.ctrlChoixListe1.TabIndex = 1;
            this.ctrlChoixListe1.Tag = "CHOIXLISTE";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.optValidation);
            this.groupBox3.Controls.Add(this.lblLibelle);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lstTypePeriode);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(677, 81);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // lblLibelle
            // 
            this.lblLibelle.Location = new System.Drawing.Point(322, 46);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(150, 20);
            this.lblLibelle.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(201, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 68;
            this.label4.Text = "Montant prévisionnel :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(581, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(86, 21);
            this.comboBox2.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(480, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 67;
            this.label3.Text = "Pôle budgétaire :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(322, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(201, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 65;
            this.label2.Text = "Enveloppe budgétaire :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstTypePeriode
            // 
            this.lstTypePeriode.FormattingEnabled = true;
            this.lstTypePeriode.Location = new System.Drawing.Point(101, 19);
            this.lstTypePeriode.Name = "lstTypePeriode";
            this.lstTypePeriode.Size = new System.Drawing.Size(86, 21);
            this.lstTypePeriode.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 63;
            this.label1.Text = "Période :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // optValidation
            // 
            this.optValidation.AutoSize = true;
            this.optValidation.Location = new System.Drawing.Point(581, 46);
            this.optValidation.Name = "optValidation";
            this.optValidation.Size = new System.Drawing.Size(72, 17);
            this.optValidation.TabIndex = 71;
            this.optValidation.Text = "Validation";
            this.optValidation.UseVisualStyleBackColor = true;
            // 
            // frmFicheAssociation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 471);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmFicheAssociation";
            this.Text = "Fiche Association";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private MAIN.Interfaces.ctrlChoixListe ctrlChoixListe2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MAIN.Interfaces.ctrlChoixListe ctrlChoixListe1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lstTypePeriode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lblLibelle;
        private System.Windows.Forms.CheckBox optValidation;
    }
}