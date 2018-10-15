namespace PATIO.OMEGA.Interfaces
{
    partial class frmBudget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudget));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCode = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.OptVersionTravail = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstTypeEnveloppe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstExercice = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRef2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCodeBudget = new System.Windows.Forms.TextBox();
            this.lblEntete = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lstPilote = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLibelleBudget = new System.Windows.Forms.TextBox();
            this.lstTypeBudget = new System.Windows.Forms.ComboBox();
            this.lblRef1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OptActiveBudget = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 339);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(534, 30);
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
            // lblCode
            // 
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(0, 27);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 339);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.OptVersionTravail);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lstTypeEnveloppe);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lstExercice);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblRef2);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.lblCodeBudget);
            this.tabPage1.Controls.Add(this.lblEntete);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.lstPilote);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lblLibelleBudget);
            this.tabPage1.Controls.Add(this.lstTypeBudget);
            this.tabPage1.Controls.Add(this.lblRef1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.OptActiveBudget);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 301);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // OptVersionTravail
            // 
            this.OptVersionTravail.AutoSize = true;
            this.OptVersionTravail.Location = new System.Drawing.Point(391, 243);
            this.OptVersionTravail.Name = "OptVersionTravail";
            this.OptVersionTravail.Size = new System.Drawing.Size(42, 17);
            this.OptVersionTravail.TabIndex = 46;
            this.OptVersionTravail.Text = "Oui";
            this.OptVersionTravail.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(239, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 23);
            this.label7.TabIndex = 45;
            this.label7.Text = "Version de travail :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstTypeEnveloppe
            // 
            this.lstTypeEnveloppe.FormattingEnabled = true;
            this.lstTypeEnveloppe.Location = new System.Drawing.Point(166, 44);
            this.lstTypeEnveloppe.Name = "lstTypeEnveloppe";
            this.lstTypeEnveloppe.Size = new System.Drawing.Size(291, 21);
            this.lstTypeEnveloppe.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 23);
            this.label6.TabIndex = 44;
            this.label6.Text = "Type d\'enveloppe :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstExercice
            // 
            this.lstExercice.FormattingEnabled = true;
            this.lstExercice.Location = new System.Drawing.Point(166, 107);
            this.lstExercice.Name = "lstExercice";
            this.lstExercice.Size = new System.Drawing.Size(91, 21);
            this.lstExercice.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 23);
            this.label5.TabIndex = 42;
            this.label5.Text = "Exercice :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRef2
            // 
            this.lblRef2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblRef2.Location = new System.Drawing.Point(282, 160);
            this.lblRef2.Name = "lblRef2";
            this.lblRef2.Size = new System.Drawing.Size(175, 20);
            this.lblRef2.TabIndex = 29;
            this.lblRef2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(282, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 26);
            this.label12.TabIndex = 40;
            this.label12.Text = "Référence";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(228, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 26);
            this.label11.TabIndex = 39;
            this.label11.Text = "Exercice";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCodeBudget
            // 
            this.lblCodeBudget.Enabled = false;
            this.lblCodeBudget.Location = new System.Drawing.Point(166, 185);
            this.lblCodeBudget.Name = "lblCodeBudget";
            this.lblCodeBudget.Size = new System.Drawing.Size(291, 20);
            this.lblCodeBudget.TabIndex = 35;
            // 
            // lblEntete
            // 
            this.lblEntete.Enabled = false;
            this.lblEntete.Location = new System.Drawing.Point(166, 159);
            this.lblEntete.Name = "lblEntete";
            this.lblEntete.Size = new System.Drawing.Size(56, 20);
            this.lblEntete.TabIndex = 37;
            this.lblEntete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(14, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 23);
            this.label9.TabIndex = 36;
            this.label9.Text = "Code généré :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstPilote
            // 
            this.lstPilote.FormattingEnabled = true;
            this.lstPilote.Location = new System.Drawing.Point(166, 217);
            this.lstPilote.Name = "lstPilote";
            this.lstPilote.Size = new System.Drawing.Size(291, 21);
            this.lstPilote.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(14, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "Pilote :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLibelleBudget
            // 
            this.lblLibelleBudget.Location = new System.Drawing.Point(166, 18);
            this.lblLibelleBudget.Name = "lblLibelleBudget";
            this.lblLibelleBudget.Size = new System.Drawing.Size(291, 20);
            this.lblLibelleBudget.TabIndex = 24;
            // 
            // lstTypeBudget
            // 
            this.lstTypeBudget.FormattingEnabled = true;
            this.lstTypeBudget.Location = new System.Drawing.Point(166, 74);
            this.lstTypeBudget.Name = "lstTypeBudget";
            this.lstTypeBudget.Size = new System.Drawing.Size(291, 21);
            this.lstTypeBudget.TabIndex = 26;
            // 
            // lblRef1
            // 
            this.lblRef1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblRef1.Location = new System.Drawing.Point(228, 159);
            this.lblRef1.Name = "lblRef1";
            this.lblRef1.Size = new System.Drawing.Size(48, 20);
            this.lblRef1.TabIndex = 27;
            this.lblRef1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "Type de budget :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "Libellé du budget :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OptActiveBudget
            // 
            this.OptActiveBudget.AutoSize = true;
            this.OptActiveBudget.Location = new System.Drawing.Point(166, 245);
            this.OptActiveBudget.Name = "OptActiveBudget";
            this.OptActiveBudget.Size = new System.Drawing.Size(42, 17);
            this.OptActiveBudget.TabIndex = 33;
            this.OptActiveBudget.Text = "Oui";
            this.OptActiveBudget.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Activation :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "Code budget :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(166, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 25);
            this.label10.TabIndex = 38;
            this.label10.Text = "Type";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 369);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBudget";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche budget";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.TextBox lblRef2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox lblCodeBudget;
        private System.Windows.Forms.TextBox lblEntete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox lstPilote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblLibelleBudget;
        private System.Windows.Forms.ComboBox lstTypeBudget;
        private System.Windows.Forms.TextBox lblRef1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox OptActiveBudget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox lstExercice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox lstTypeEnveloppe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox OptVersionTravail;
        private System.Windows.Forms.Label label7;
    }
}