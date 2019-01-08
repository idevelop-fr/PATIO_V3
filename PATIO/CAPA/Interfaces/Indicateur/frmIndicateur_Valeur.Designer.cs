namespace PATIO.CAPA.Interfaces
{
    partial class frmIndicateur_Valeur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndicateur_Valeur));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnAnnuler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnValider = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lstTerrioire = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label41 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 142);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(434, 30);
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
            // lstTerrioire
            // 
            this.lstTerrioire.FormattingEnabled = true;
            this.lstTerrioire.Location = new System.Drawing.Point(123, 30);
            this.lstTerrioire.Name = "lstTerrioire";
            this.lstTerrioire.Size = new System.Drawing.Size(200, 21);
            this.lstTerrioire.TabIndex = 14;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(40, 30);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(77, 19);
            this.label43.TabIndex = 13;
            this.label43.Text = "Territoire :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 20);
            this.textBox1.TabIndex = 12;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(40, 84);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(77, 19);
            this.label42.TabIndex = 11;
            this.label42.Text = "Valeur :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(123, 58);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(40, 58);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(77, 19);
            this.label41.TabIndex = 9;
            this.label41.Text = "Période :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmIndicateur_Valeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 172);
            this.Controls.Add(this.lstTerrioire);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmIndicateur_Valeur";
            this.Text = "frmIndicateur_Valeur";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnAnnuler;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnValider;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ComboBox lstTerrioire;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label41;
    }
}