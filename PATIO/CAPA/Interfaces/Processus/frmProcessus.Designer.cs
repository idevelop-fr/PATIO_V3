namespace PATIO.CAPA.Interfaces
{
    partial class frmProcessus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessus));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lstTypeProcessus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.OptActiveProcessus = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEntete = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLibelleProcessus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRef1 = new System.Windows.Forms.TextBox();
            this.lblRef2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCodeProcessus = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAjouterDonnée = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ChoixDonneeSortant = new PATIO.MAIN.Interfaces.ctrlChoixListe();
            this.ChoixDonneeEntrant = new PATIO.MAIN.Interfaces.ctrlChoixListe();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.btnAjouterDonnée,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 311);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(521, 30);
            this.toolStrip1.TabIndex = 8;
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
            this.BtnValider.Size = new System.Drawing.Size(62, 27);
            this.BtnValider.Text = "Valider";
            this.BtnValider.Click += new System.EventHandler(this.BtnValider_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // lstTypeProcessus
            // 
            this.lstTypeProcessus.FormattingEnabled = true;
            this.lstTypeProcessus.Location = new System.Drawing.Point(183, 136);
            this.lstTypeProcessus.Name = "lstTypeProcessus";
            this.lstTypeProcessus.Size = new System.Drawing.Size(149, 21);
            this.lstTypeProcessus.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(28, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "Type de processus :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OptActiveProcessus
            // 
            this.OptActiveProcessus.AutoSize = true;
            this.OptActiveProcessus.Location = new System.Drawing.Point(192, 113);
            this.OptActiveProcessus.Name = "OptActiveProcessus";
            this.OptActiveProcessus.Size = new System.Drawing.Size(42, 17);
            this.OptActiveProcessus.TabIndex = 3;
            this.OptActiveProcessus.Text = "Oui";
            this.OptActiveProcessus.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(31, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Activation :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEntete
            // 
            this.lblEntete.Enabled = false;
            this.lblEntete.Location = new System.Drawing.Point(183, 56);
            this.lblEntete.Name = "lblEntete";
            this.lblEntete.Size = new System.Drawing.Size(51, 20);
            this.lblEntete.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(31, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Code du processus :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLibelleProcessus
            // 
            this.lblLibelleProcessus.Location = new System.Drawing.Point(183, 20);
            this.lblLibelleProcessus.Name = "lblLibelleProcessus";
            this.lblLibelleProcessus.Size = new System.Drawing.Size(298, 20);
            this.lblLibelleProcessus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Libellé du processus :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRef1
            // 
            this.lblRef1.Location = new System.Drawing.Point(240, 56);
            this.lblRef1.Name = "lblRef1";
            this.lblRef1.Size = new System.Drawing.Size(92, 20);
            this.lblRef1.TabIndex = 1;
            this.lblRef1.TextChanged += new System.EventHandler(this.lblRef1_TextChanged);
            // 
            // lblRef2
            // 
            this.lblRef2.Location = new System.Drawing.Point(338, 56);
            this.lblRef2.Name = "lblRef2";
            this.lblRef2.Size = new System.Drawing.Size(143, 20);
            this.lblRef2.TabIndex = 2;
            this.lblRef2.TextChanged += new System.EventHandler(this.lblRef2_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(31, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Code du processus :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCodeProcessus
            // 
            this.lblCodeProcessus.Enabled = false;
            this.lblCodeProcessus.Location = new System.Drawing.Point(183, 86);
            this.lblCodeProcessus.Name = "lblCodeProcessus";
            this.lblCodeProcessus.Size = new System.Drawing.Size(298, 20);
            this.lblCodeProcessus.TabIndex = 28;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(69, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(521, 311);
            this.tabControl1.TabIndex = 29;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(513, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTypeProcessus);
            this.groupBox1.Controls.Add(this.lblLibelleProcessus);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblCodeProcessus);
            this.groupBox1.Controls.Add(this.OptActiveProcessus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblRef1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblEntete);
            this.groupBox1.Controls.Add(this.lblRef2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 170);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(513, 273);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Données";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ChoixDonneeSortant);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(513, 133);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Données sortantes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChoixDonneeEntrant);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 133);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Données entrantes";
            // 
            // btnAjouterDonnée
            // 
            this.btnAjouterDonnée.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAjouterDonnée.Image = ((System.Drawing.Image)(resources.GetObject("btnAjouterDonnée.Image")));
            this.btnAjouterDonnée.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjouterDonnée.Name = "btnAjouterDonnée";
            this.btnAjouterDonnée.Size = new System.Drawing.Size(151, 27);
            this.btnAjouterDonnée.Text = "Ajouter une donnée";
            this.btnAjouterDonnée.Click += new System.EventHandler(this.btnAjouterDonnée_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // ChoixDonneeSortant
            // 
            this.ChoixDonneeSortant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChoixDonneeSortant.Location = new System.Drawing.Point(3, 16);
            this.ChoixDonneeSortant.Name = "ChoixDonneeSortant";
            this.ChoixDonneeSortant.Size = new System.Drawing.Size(507, 114);
            this.ChoixDonneeSortant.TabIndex = 30;
            this.ChoixDonneeSortant.Tag = "CHOIXLISTE";
            // 
            // ChoixDonneeEntrant
            // 
            this.ChoixDonneeEntrant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChoixDonneeEntrant.Location = new System.Drawing.Point(3, 16);
            this.ChoixDonneeEntrant.Name = "ChoixDonneeEntrant";
            this.ChoixDonneeEntrant.Size = new System.Drawing.Size(507, 114);
            this.ChoixDonneeEntrant.TabIndex = 30;
            this.ChoixDonneeEntrant.Tag = "CHOIXLISTE";
            // 
            // frmProcessus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 341);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessus";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche Processus";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnAnnuler;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnValider;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ComboBox lstTypeProcessus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox OptActiveProcessus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lblEntete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lblLibelleProcessus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lblRef1;
        private System.Windows.Forms.TextBox lblRef2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lblCodeProcessus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private MAIN.Interfaces.ctrlChoixListe ChoixDonneeSortant;
        private System.Windows.Forms.GroupBox groupBox2;
        private MAIN.Interfaces.ctrlChoixListe ChoixDonneeEntrant;
        private System.Windows.Forms.ToolStripButton btnAjouterDonnée;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}