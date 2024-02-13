namespace WindowsFormsApplication1
{
    partial class AppelProforma
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Proforma1 = new WindowsFormsApplication1.Proforma();
            this.proformauser = new System.Windows.Forms.Label();
            this.proformastatu = new System.Windows.Forms.Label();
            this.Siteproforma = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.Siteproforma);
            this.panel1.Controls.Add(this.proformastatu);
            this.panel1.Controls.Add(this.proformauser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 33);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial MT Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(734, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(142, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "PHARMACIE DU COIN/ PROFORMA";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 36);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.Proforma1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(757, 531);
            this.crystalReportViewer1.TabIndex = 1;
            // 
            // proformauser
            // 
            this.proformauser.AutoSize = true;
            this.proformauser.ForeColor = System.Drawing.Color.White;
            this.proformauser.Location = new System.Drawing.Point(645, 3);
            this.proformauser.Name = "proformauser";
            this.proformauser.Size = new System.Drawing.Size(25, 13);
            this.proformauser.TabIndex = 3;
            this.proformauser.Text = "000";
            // 
            // proformastatu
            // 
            this.proformastatu.AutoSize = true;
            this.proformastatu.ForeColor = System.Drawing.Color.White;
            this.proformastatu.Location = new System.Drawing.Point(645, 20);
            this.proformastatu.Name = "proformastatu";
            this.proformastatu.Size = new System.Drawing.Size(25, 13);
            this.proformastatu.TabIndex = 4;
            this.proformastatu.Text = "000";
            // 
            // Siteproforma
            // 
            this.Siteproforma.AutoSize = true;
            this.Siteproforma.ForeColor = System.Drawing.Color.White;
            this.Siteproforma.Location = new System.Drawing.Point(12, 9);
            this.Siteproforma.Name = "Siteproforma";
            this.Siteproforma.Size = new System.Drawing.Size(25, 13);
            this.Siteproforma.TabIndex = 5;
            this.Siteproforma.Text = "000";
            // 
            // AppelProforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 579);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppelProforma";
            this.Text = "AppelProforma";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Proforma Proforma1;
        public System.Windows.Forms.Label Siteproforma;
        public System.Windows.Forms.Label proformastatu;
        public System.Windows.Forms.Label proformauser;
    }
}