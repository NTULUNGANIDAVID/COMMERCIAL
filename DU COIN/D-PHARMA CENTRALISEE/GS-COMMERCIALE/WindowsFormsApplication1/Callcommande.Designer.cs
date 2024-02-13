namespace WindowsFormsApplication1
{
    partial class Callcommande
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Callcommande));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer11 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalRequisition1 = new WindowsFormsApplication1.CrystalRequisition();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 36);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(195, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "IMPRIMER LE BON DE COMMANDE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(756, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // crystalReportViewer11
            // 
            this.crystalReportViewer11.ActiveViewIndex = 0;
            this.crystalReportViewer11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer11.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer11.Location = new System.Drawing.Point(1, 42);
            this.crystalReportViewer11.Name = "crystalReportViewer11";
            this.crystalReportViewer11.ReportSource = this.CrystalRequisition1;
            this.crystalReportViewer11.Size = new System.Drawing.Size(783, 544);
            this.crystalReportViewer11.TabIndex = 1;
            this.crystalReportViewer11.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Callcommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 598);
            this.Controls.Add(this.crystalReportViewer11);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Callcommande";
            this.Text = "Callcommande";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer11;
        private CrystalRequisition CrystalRequisition1;
    }
}