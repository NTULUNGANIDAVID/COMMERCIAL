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
    public partial class Chargement : Form
    {
        DialogResult echo = new DialogResult();
        public Chargement()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            charge();
        }
        public void charge()
        {
            if (label1.Text == "50")
            {
                timer1.Stop();
                echo = MessageBox.Show("Veuillez pretez attention au % ", " Chers Utilisateur ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                Form1 men = new Form1 ();
                this.Hide();
                men.Show();
            }
            else
            {
                int temps; int recupe;
                temps = int.Parse(label1.Text);
                recupe = temps + 1;
                label1.Text = Convert.ToString(recupe);
            }




        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Chargement_Load(object sender, EventArgs e)
        {
            label10.Text = Convert.ToString(DateTime.Today.ToString("yyyy"));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
