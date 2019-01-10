namespace PATIO.OMEGA.Interfaces.Budgets
{
    partial class frmVirement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVirement));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCode = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblCommentaire = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.choixListe_Dest = new PATIO.MAIN.Interfaces.ctrlChoixListe();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstEnveloppe_Dest = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstGEO_Dest = new System.Windows.Forms.ComboBox();
            this.lstORG_Dest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.choixListe_Src = new PATIO.MAIN.Interfaces.ctrlChoixListe();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstEnveloppe_Src = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstGEO_Src = new System.Windows.Forms.ComboBox();
            this.lstORG_Src = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstTypeMontant = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lstPeriode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDateDemande = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMontant = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDateEffet = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstTypeVirement = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.toolStrip1.Location = new System.Drawing.Point(3, 452);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(846, 30);
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
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 25);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 449);
            this.tabControl1.TabIndex = 81;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(838, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblCommentaire);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 339);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(832, 74);
            this.groupBox4.TabIndex = 82;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Commentaires";
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommentaire.Location = new System.Drawing.Point(3, 16);
            this.lblCommentaire.Multiline = true;
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(826, 55);
            this.lblCommentaire.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.choixListe_Dest);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 135);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination";
            // 
            // choixListe_Dest
            // 
            this.choixListe_Dest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choixListe_Dest.Location = new System.Drawing.Point(270, 16);
            this.choixListe_Dest.Name = "choixListe_Dest";
            this.choixListe_Dest.Size = new System.Drawing.Size(559, 116);
            this.choixListe_Dest.TabIndex = 79;
            this.choixListe_Dest.Tag = "CHOIXLISTE";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstEnveloppe_Dest);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lstGEO_Dest);
            this.panel1.Controls.Add(this.lstORG_Dest);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 116);
            this.panel1.TabIndex = 77;
            // 
            // lstEnveloppe_Dest
            // 
            this.lstEnveloppe_Dest.FormattingEnabled = true;
            this.lstEnveloppe_Dest.Location = new System.Drawing.Point(130, 17);
            this.lstEnveloppe_Dest.Name = "lstEnveloppe_Dest";
            this.lstEnveloppe_Dest.Size = new System.Drawing.Size(125, 21);
            this.lstEnveloppe_Dest.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 23);
            this.label5.TabIndex = 71;
            this.label5.Text = "Enveloppe :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstGEO_Dest
            // 
            this.lstGEO_Dest.FormattingEnabled = true;
            this.lstGEO_Dest.Location = new System.Drawing.Point(130, 78);
            this.lstGEO_Dest.Name = "lstGEO_Dest";
            this.lstGEO_Dest.Size = new System.Drawing.Size(125, 21);
            this.lstGEO_Dest.TabIndex = 65;
            // 
            // lstORG_Dest
            // 
            this.lstORG_Dest.FormattingEnabled = true;
            this.lstORG_Dest.Location = new System.Drawing.Point(130, 48);
            this.lstORG_Dest.Name = "lstORG_Dest";
            this.lstORG_Dest.Size = new System.Drawing.Size(125, 21);
            this.lstORG_Dest.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 67;
            this.label1.Text = "Zone géographique :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 23);
            this.label2.TabIndex = 66;
            this.label2.Text = "Zone organisationnelle :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.choixListe_Src);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 135);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // choixListe_Src
            // 
            this.choixListe_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choixListe_Src.Location = new System.Drawing.Point(270, 16);
            this.choixListe_Src.Name = "choixListe_Src";
            this.choixListe_Src.Size = new System.Drawing.Size(559, 116);
            this.choixListe_Src.TabIndex = 79;
            this.choixListe_Src.Tag = "CHOIXLISTE";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstEnveloppe_Src);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lstGEO_Src);
            this.panel2.Controls.Add(this.lstORG_Src);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 116);
            this.panel2.TabIndex = 77;
            // 
            // lstEnveloppe_Src
            // 
            this.lstEnveloppe_Src.FormattingEnabled = true;
            this.lstEnveloppe_Src.Location = new System.Drawing.Point(130, 15);
            this.lstEnveloppe_Src.Name = "lstEnveloppe_Src";
            this.lstEnveloppe_Src.Size = new System.Drawing.Size(125, 21);
            this.lstEnveloppe_Src.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 23);
            this.label3.TabIndex = 69;
            this.label3.Text = "Enveloppe :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstGEO_Src
            // 
            this.lstGEO_Src.FormattingEnabled = true;
            this.lstGEO_Src.Location = new System.Drawing.Point(130, 75);
            this.lstGEO_Src.Name = "lstGEO_Src";
            this.lstGEO_Src.Size = new System.Drawing.Size(125, 21);
            this.lstGEO_Src.TabIndex = 65;
            // 
            // lstORG_Src
            // 
            this.lstORG_Src.FormattingEnabled = true;
            this.lstORG_Src.Location = new System.Drawing.Point(130, 45);
            this.lstORG_Src.Name = "lstORG_Src";
            this.lstORG_Src.Size = new System.Drawing.Size(125, 21);
            this.lstORG_Src.TabIndex = 64;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 23);
            this.label8.TabIndex = 67;
            this.label8.Text = "Zone géographique :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 66;
            this.label6.Text = "Zone organisationnelle :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstTypeVirement);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lstTypeMontant);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lstPeriode);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblDateDemande);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblMontant);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblDateEffet);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(832, 66);
            this.groupBox3.TabIndex = 85;
            this.groupBox3.TabStop = false;
            // 
            // lstTypeMontant
            // 
            this.lstTypeMontant.FormattingEnabled = true;
            this.lstTypeMontant.Location = new System.Drawing.Point(96, 39);
            this.lstTypeMontant.Name = "lstTypeMontant";
            this.lstTypeMontant.Size = new System.Drawing.Size(162, 21);
            this.lstTypeMontant.TabIndex = 72;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 23);
            this.label11.TabIndex = 73;
            this.label11.Text = "Type montant :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstPeriode
            // 
            this.lstPeriode.FormattingEnabled = true;
            this.lstPeriode.Location = new System.Drawing.Point(96, 13);
            this.lstPeriode.Name = "lstPeriode";
            this.lstPeriode.Size = new System.Drawing.Size(162, 21);
            this.lstPeriode.TabIndex = 70;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(9, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 23);
            this.label10.TabIndex = 71;
            this.label10.Text = "Période :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 61;
            this.label9.Text = "Date d\'effet :";
            // 
            // lblDateDemande
            // 
            this.lblDateDemande.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lblDateDemande.Location = new System.Drawing.Point(405, 15);
            this.lblDateDemande.Name = "lblDateDemande";
            this.lblDateDemande.Size = new System.Drawing.Size(99, 20);
            this.lblDateDemande.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(301, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Date de demande :";
            // 
            // lblMontant
            // 
            this.lblMontant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontant.Location = new System.Drawing.Point(685, 37);
            this.lblMontant.Name = "lblMontant";
            this.lblMontant.Size = new System.Drawing.Size(144, 23);
            this.lblMontant.TabIndex = 57;
            this.lblMontant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(550, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 58;
            this.label4.Text = "Montant de l\'opération :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateEffet
            // 
            this.lblDateEffet.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lblDateEffet.Location = new System.Drawing.Point(405, 40);
            this.lblDateEffet.Name = "lblDateEffet";
            this.lblDateEffet.Size = new System.Drawing.Size(99, 20);
            this.lblDateEffet.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(838, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Droits";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(838, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Historique";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstTypeVirement
            // 
            this.lstTypeVirement.FormattingEnabled = true;
            this.lstTypeVirement.Location = new System.Drawing.Point(685, 10);
            this.lstTypeVirement.Name = "lstTypeVirement";
            this.lstTypeVirement.Size = new System.Drawing.Size(144, 21);
            this.lstTypeVirement.TabIndex = 74;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(566, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 23);
            this.label12.TabIndex = 75;
            this.label12.Text = "Type de virement :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmVirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 485);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVirement";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche Virement";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox lblCommentaire;
        private System.Windows.Forms.GroupBox groupBox2;
        private MAIN.Interfaces.ctrlChoixListe choixListe_Dest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox lstEnveloppe_Dest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox lstGEO_Dest;
        private System.Windows.Forms.ComboBox lstORG_Dest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MAIN.Interfaces.ctrlChoixListe choixListe_Src;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox lstEnveloppe_Src;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lstGEO_Src;
        private System.Windows.Forms.ComboBox lstORG_Src;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox lstTypeMontant;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox lstPeriode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker lblDateDemande;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox lblMontant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker lblDateEffet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox lstTypeVirement;
        private System.Windows.Forms.Label label12;
    }
}