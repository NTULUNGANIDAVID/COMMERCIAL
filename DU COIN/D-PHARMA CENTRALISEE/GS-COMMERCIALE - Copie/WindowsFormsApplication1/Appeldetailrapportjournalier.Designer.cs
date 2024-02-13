namespace WindowsFormsApplication1
{
    partial class Appeldetailrapportjournalier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Appeldetailrapportjournalier));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblsiterapport = new System.Windows.Forms.Label();
            this.lblrolerapport = new System.Windows.Forms.Label();
            this.lbluserrapportjour = new System.Windows.Forms.Label();
            this.lblbackmenu = new System.Windows.Forms.Label();
            this.crystalReportViewer1rapportjournalierdetaillee = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystaljournalierDetaillee1 = new WindowsFormsApplication1.CrystaljournalierDetaillee();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblsiterapport);
            this.panel1.Controls.Add(this.lblrolerapport);
            this.panel1.Controls.Add(this.lbluserrapportjour);
            this.panel1.Controls.Add(this.lblbackmenu);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 35);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(259, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "RAPPORT JOURNALIER DETAILLES";
            // 
            // lblsiterapport
            // 
            this.lblsiterapport.AutoSize = true;
            this.lblsiterapport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsiterapport.ForeColor = System.Drawing.Color.White;
            this.lblsiterapport.Location = new System.Drawing.Point(74, 9);
            this.lblsiterapport.Name = "lblsiterapport";
            this.lblsiterapport.Size = new System.Drawing.Size(28, 17);
            this.lblsiterapport.TabIndex = 4;
            this.lblsiterapport.Text = "site";
            // 
            // lblrolerapport
            // 
            this.lblrolerapport.AutoSize = true;
            this.lblrolerapport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrolerapport.ForeColor = System.Drawing.Color.White;
            this.lblrolerapport.Location = new System.Drawing.Point(703, 16);
            this.lblrolerapport.Name = "lblrolerapport";
            this.lblrolerapport.Size = new System.Drawing.Size(31, 17);
            this.lblrolerapport.TabIndex = 3;
            this.lblrolerapport.Text = "role";
            // 
            // lbluserrapportjour
            // 
            this.lbluserrapportjour.AutoSize = true;
            this.lbluserrapportjour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserrapportjour.ForeColor = System.Drawing.Color.White;
            this.lbluserrapportjour.Location = new System.Drawing.Point(703, 0);
            this.lbluserrapportjour.Name = "lbluserrapportjour";
            this.lbluserrapportjour.Size = new System.Drawing.Size(33, 17);
            this.lbluserrapportjour.TabIndex = 2;
            this.lbluserrapportjour.Text = "user";
            // 
            // lblbackmenu
            // 
            this.lblbackmenu.AutoSize = true;
            this.lblbackmenu.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbackmenu.ForeColor = System.Drawing.Color.White;
            this.lblbackmenu.Location = new System.Drawing.Point(827, 4);
            this.lblbackmenu.Name = "lblbackmenu";
            this.lblbackmenu.Size = new System.Drawing.Size(24, 25);
            this.lblbackmenu.TabIndex = 1;
            this.lblbackmenu.Text = "X";
            this.lblbackmenu.Click += new System.EventHandler(this.lblbackmenu_Click);
            // 
            // crystalReportViewer1rapportjournalierdetaillee
            // 
            this.crystalReportViewer1rapportjournalierdetaillee.ActiveViewIndex = 0;
            this.crystalReportViewer1rapportjournalierdetaillee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1rapportjournalierdetaillee.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1rapportjournalierdetaillee.Location = new System.Drawing.Point(1, 36);
            this.crystalReportViewer1rapportjournalierdetaillee.Name = "crystalReportViewer1rapportjournalierdetaillee";
            this.crystalReportViewer1rapportjournalierdetaillee.ReportSource = this.CrystaljournalierDetaillee1;
            this.crystalReportViewer1rapportjournalierdetaillee.Size = new System.Drawing.Size(851, 553);
            this.crystalReportViewer1rapportjournalierdetaillee.TabIndex = 1;
            // 
            // Appeldetailrapportjournalier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 589);
            this.Controls.Add(this.crystalReportViewer1rapportjournalierdetaillee);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Appeldetailrapportjournalier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appeldetailrapportjournalier";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblsiterapport;
        public System.Windows.Forms.Label lblrolerapport;
        public System.Windows.Forms.Label lbluserrapportjour;
        private System.Windows.Forms.Label lblbackmenu;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1rapportjournalierdetaillee;
        private CrystaljournalierDetaillee CrystaljournalierDetaillee1;
    }
}