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
    public partial class Appeldetailrapportjournalier : Form
    {
        public Appeldetailrapportjournalier()
        {
            InitializeComponent();
        }

        private void lblbackmenu_Click(object sender, EventArgs e)
        {
            PAGE_ACCUEIL PGA = new PAGE_ACCUEIL();
            PGA.label48.Text = lbluserrapportjour.Text;
            PGA.label49.Text = lblrolerapport.Text;
            PGA.lblsiteuser.Text = lblsiterapport.Text;
            PGA.Hide();
            PGA.Show();
        }
    }
}
