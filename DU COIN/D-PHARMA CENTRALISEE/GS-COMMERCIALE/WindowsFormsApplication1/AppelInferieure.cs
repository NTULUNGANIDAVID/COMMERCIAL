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
    public partial class AppelInferieure : Form
    {
        public AppelInferieure()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            PAGE_ACCUEIL pc = new PAGE_ACCUEIL();
            pc.label48.Text = label1.Text;
            pc.label49.Text = label2.Text;
            pc.txtnomvende.Text = label2.Text;
            pc.lblsiteuser.Text = laluserinferieure.Text;
            this.Hide();
            pc.Show();
        }

        private void laluserinferieure_Click(object sender, EventArgs e)
        {

        }
    }
}
