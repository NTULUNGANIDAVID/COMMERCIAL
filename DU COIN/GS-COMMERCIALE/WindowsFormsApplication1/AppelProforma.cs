using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class AppelProforma : Form
    {
        public AppelProforma()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            PAGE_ACCUEIL retour = new PAGE_ACCUEIL();
            retour.label48.Text = proformauser.Text;
            retour.label49.Text = proformastatu.Text;
            retour.lblsiteuser.Text = Siteproforma.Text;
            if (retour.label49.Text == proformastatu.Text)
            {
                this.Hide();
                retour.Show();
            }
            else {
                retour.label48.Text = proformauser.Text;
                retour.label49.Text = proformastatu.Text;
                retour.lblsiteuser.Text = proformauser.Text;
                retour.txtnomvende.Text = proformauser.Text;
                retour.lblsiteuser.Text = Siteproforma.Text;
                retour.xtraTabPage2.Visible = false;
                retour.groupBox10.Visible = false;
                retour.groupBox9.Visible = false;
                retour.groupBox20.Visible = false;
                retour.groupBox3.Visible = false;
                retour.groupBox52.Enabled = false;
                retour.xtraTabPage8.Enabled = false;
                retour.groupBox50.Enabled = false;
                retour.richnomprod.Enabled = false;
                retour.GK.Enabled = true;
                retour.GKK.Enabled = true;
                retour.groupBox10.Visible = false;
                retour.groupBox17.Enabled = false;
                retour.groupBox29.Visible = false;
                retour.groupBox8.Enabled = false;
            }   
        }
    }
}