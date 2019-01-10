namespace PATIO.OMEGA.Interfaces
{
    partial class frmOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperation));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCode = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblMontant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstTypeMontant = new System.Windows.Forms.ComboBox();
            this.lstTypeOperation = new System.Windows.Forms.ComboBox();
            this.lblDateOpe = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstGEO = new System.Windows.Forms.ComboBox();
            this.lstORG = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstTypeFlux = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstPeriode = new System.Windows.Forms.ComboBox();
            this.lstTypeEnveloppe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCommentaire = new System.Windows.Forms.TextBox();
            this.ChoixCompte = new PATIO.MAIN.Interfaces.ctrlChoixListe();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeInfo = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.lblCode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 417);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(713, 30);
            this.toolStrip1.TabIndex = 2;
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
            this.BtnAnnuler.Size = new System.Drawing.Size(64, 27);
            this.BtnAnnuler.Text = "Fermer";
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
            this.BtnValider.Size = new System.Drawing.Size(65, 27);
            this.BtnValider.Text = "Ajouter";
            this.BtnValider.Click += new System.EventHandler(this.BtnValider_Click);
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
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 417);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.ChoixCompte);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(705, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblMontant);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(517, 199);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(179, 106);
            this.panel4.TabIndex = 80;
            // 
            // lblMontant
            // 
            this.lblMontant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontant.Location = new System.Drawing.Point(17, 44);
            this.lblMontant.Name = "lblMontant";
            this.lblMontant.Size = new System.Drawing.Size(144, 23);
            this.lblMontant.TabIndex = 9;
            this.lblMontant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lblMontant.Leave += new System.EventHandler(this.lblMontant_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 23);
            this.label5.TabIndex = 56;
            this.label5.Text = "Montant de l\'opération :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstTypeMontant);
            this.panel2.Controls.Add(this.lstTypeOperation);
            this.panel2.Controls.Add(this.lblDateOpe);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(271, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 106);
            this.panel2.TabIndex = 79;
            // 
            // lstTypeMontant
            // 
            this.lstTypeMontant.FormattingEnabled = true;
            this.lstTypeMontant.Location = new System.Drawing.Point(132, 12);
            this.lstTypeMontant.Name = "lstTypeMontant";
            this.lstTypeMontant.Size = new System.Drawing.Size(99, 21);
            this.lstTypeMontant.TabIndex = 62;
            // 
            // lstTypeOperation
            // 
            this.lstTypeOperation.FormattingEnabled = true;
            this.lstTypeOperation.Location = new System.Drawing.Point(132, 73);
            this.lstTypeOperation.Name = "lstTypeOperation";
            this.lstTypeOperation.Size = new System.Drawing.Size(99, 21);
            this.lstTypeOperation.TabIndex = 8;
            // 
            // lblDateOpe
            // 
            this.lblDateOpe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lblDateOpe.Location = new System.Drawing.Point(132, 43);
            this.lblDateOpe.Name = "lblDateOpe";
            this.lblDateOpe.Size = new System.Drawing.Size(99, 20);
            this.lblDateOpe.TabIndex = 7;
            this.lblDateOpe.ValueChanged += new System.EventHandler(this.lblDateOpe_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 23);
            this.label4.TabIndex = 55;
            this.label4.Text = "Date de l\'opération :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 23);
            this.label9.TabIndex = 61;
            this.label9.Text = "Type d\'opération :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 23);
            this.label7.TabIndex = 59;
            this.label7.Text = "Type de montant :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstGEO);
            this.panel1.Controls.Add(this.lstORG);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(8, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 106);
            this.panel1.TabIndex = 78;
            // 
            // lstGEO
            // 
            this.lstGEO.FormattingEnabled = true;
            this.lstGEO.Location = new System.Drawing.Point(132, 42);
            this.lstGEO.Name = "lstGEO";
            this.lstGEO.Size = new System.Drawing.Size(125, 21);
            this.lstGEO.TabIndex = 5;
            // 
            // lstORG
            // 
            this.lstORG.FormattingEnabled = true;
            this.lstORG.Location = new System.Drawing.Point(132, 12);
            this.lstORG.Name = "lstORG";
            this.lstORG.Size = new System.Drawing.Size(125, 21);
            this.lstORG.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 23);
            this.label8.TabIndex = 63;
            this.label8.Text = "Zone géographique :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 61;
            this.label6.Text = "Zone organisationnelle :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstTypeFlux);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lstPeriode);
            this.panel3.Controls.Add(this.lstTypeEnveloppe);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(8, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(688, 35);
            this.panel3.TabIndex = 77;
            // 
            // lstTypeFlux
            // 
            this.lstTypeFlux.FormattingEnabled = true;
            this.lstTypeFlux.Location = new System.Drawing.Point(539, 7);
            this.lstTypeFlux.Name = "lstTypeFlux";
            this.lstTypeFlux.Size = new System.Drawing.Size(100, 21);
            this.lstTypeFlux.TabIndex = 2;
            this.lstTypeFlux.SelectedIndexChanged += new System.EventHandler(this.lstTypeFlux_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(477, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 65;
            this.label3.Text = "Flux :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 61;
            this.label1.Text = "Enveloppe :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstPeriode
            // 
            this.lstPeriode.FormattingEnabled = true;
            this.lstPeriode.Location = new System.Drawing.Point(322, 7);
            this.lstPeriode.Name = "lstPeriode";
            this.lstPeriode.Size = new System.Drawing.Size(149, 21);
            this.lstPeriode.TabIndex = 1;
            this.lstPeriode.SelectedIndexChanged += new System.EventHandler(this.lstPeriode_SelectedIndexChanged);
            // 
            // lstTypeEnveloppe
            // 
            this.lstTypeEnveloppe.FormattingEnabled = true;
            this.lstTypeEnveloppe.Location = new System.Drawing.Point(87, 7);
            this.lstTypeEnveloppe.Name = "lstTypeEnveloppe";
            this.lstTypeEnveloppe.Size = new System.Drawing.Size(149, 21);
            this.lstTypeEnveloppe.TabIndex = 0;
            this.lstTypeEnveloppe.SelectedIndexChanged += new System.EventHandler(this.lstTypeEnveloppe_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(242, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 63;
            this.label2.Text = "Période :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCommentaire);
            this.groupBox1.Location = new System.Drawing.Point(8, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 67);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commentaires";
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.AcceptsReturn = true;
            this.lblCommentaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommentaire.Location = new System.Drawing.Point(3, 16);
            this.lblCommentaire.Multiline = true;
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(682, 48);
            this.lblCommentaire.TabIndex = 10;
            // 
            // ChoixCompte
            // 
            this.ChoixCompte.Location = new System.Drawing.Point(8, 43);
            this.ChoixCompte.Name = "ChoixCompte";
            this.ChoixCompte.Size = new System.Drawing.Size(688, 150);
            this.ChoixCompte.TabIndex = 3;
            this.ChoixCompte.Tag = "CHOIXLISTE";
            this.ChoixCompte.EVT_Echanger += new System.EventHandler<PATIO.MAIN.Interfaces.ctrlChoixListe.evt_Echanger>(this.ChoixCompte_EVT_Echanger);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FloralWhite;
            this.groupBox2.Controls.Add(this.treeInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(713, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 447);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informations complémentaires";
            // 
            // treeInfo
            // 
            this.treeInfo.BackColor = System.Drawing.Color.FloralWhite;
            this.treeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeInfo.Location = new System.Drawing.Point(3, 16);
            this.treeInfo.Name = "treeInfo";
            this.treeInfo.Size = new System.Drawing.Size(289, 428);
            this.treeInfo.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(705, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Droits";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(705, 379);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Historique";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // frmOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 447);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOperation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fiche d\'une operation";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.ToolStripLabel lblCode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker lblDateOpe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private MAIN.Interfaces.ctrlChoixListe ChoixCompte;
        private System.Windows.Forms.ComboBox lstTypeFlux;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lstPeriode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lstTypeEnveloppe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox lstGEO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox lstORG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lblCommentaire;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeInfo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox lstTypeOperation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lblMontant;
        private System.Windows.Forms.ComboBox lstTypeMontant;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}