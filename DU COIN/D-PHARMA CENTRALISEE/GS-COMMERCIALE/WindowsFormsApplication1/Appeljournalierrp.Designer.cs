namespace WindowsFormsApplication1
{
    partial class Appeljournalierrp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Appeljournalierrp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbluserrapport = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2role = new System.Windows.Forms.Label();
            this.label1user = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport1DetailleVente1 = new WindowsFormsApplication1.CrystalReport1DetailleVente();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.lbluserrapport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2role);
            this.panel1.Controls.Add(this.label1user);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 37);
            this.panel1.TabIndex = 0;
            // 
            // lbluserrapport
            // 
            this.lbluserrapport.AutoSize = true;
            this.lbluserrapport.BackColor = System.Drawing.Color.Black;
            this.lbluserrapport.ForeColor = System.Drawing.Color.White;
            this.lbluserrapport.Location = new System.Drawing.Point(12, 16);
            this.lbluserrapport.Name = "lbluserrapport";
            this.lbluserrapport.Size = new System.Drawing.Size(19, 13);
            this.lbluserrapport.TabIndex = 4;
            this.lbluserrapport.Text = "....";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(363, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "RAPPORT DES VENTES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1017, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2role
            // 
            this.label2role.AutoSize = true;
            this.label2role.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2role.ForeColor = System.Drawing.Color.White;
            this.label2role.Location = new System.Drawing.Point(894, 19);
            this.label2role.Name = "label2role";
            this.label2role.Size = new System.Drawing.Size(62, 16);
            this.label2role.TabIndex = 2;
            this.label2role.Text = "Role user";
            // 
            // label1user
            // 
            this.label1user.AutoSize = true;
            this.label1user.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1user.ForeColor = System.Drawing.Color.White;
            this.label1user.Location = new System.Drawing.Point(893, 1);
            this.label1user.Name = "label1user";
            this.label1user.Size = new System.Drawing.Size(69, 16);
            this.label1user.TabIndex = 1;
            this.label1user.Text = "user name";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 40);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport1DetailleVente1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1050, 513);
            this.crystalReportViewer1.TabIndex = 1;
            // 
            // Appeljournalierrp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 557);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Appeljournalierrp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appeljournalierrp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2role;
        public System.Windows.Forms.Label label1user;
        public System.Windows.Forms.Label lbluserrapport;
        private CrystalReport1DetailleVente CrystalReport1DetailleVente1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}