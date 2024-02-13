using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Creationcompte : Form
    {
        Seconnecter conn = new Seconnecter();
        public Creationcompte()
        {
            InitializeComponent();
            SelectSites();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            creer();
            annuler();
        }
        public void creer()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "INSERT INTO [DBO].[COMPTE] values('" + nom.Text + "','"+ postnom.Text + "','"+ prenom.Text + "','"+ cmbstatus.Text + "','"+ phone.Text + "','"+ password.Text + "','"+ confirm.Text + "','"+ adresse.Text + "','"+cmbsite.Text+"')";
            if (password == confirm)
            { 
                MessageBox.Show("Le mot de pass doit être identique ");
                password.Clear();
                confirm.Clear();
            }
            else
            {
                MessageBox.Show(" Le compte est bien créer!");
            }

            if (conn.cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Salut");
            }
            else
            {
                MessageBox.Show("Erreur *"+nom.Text);
            }
            conn.con.Close();
        }
        public void annuler()
        {
            nom.Clear();
            postnom.Clear();
            prenom.Clear();
            cmbstatus.Text = "";
            phone.Clear();
            password.Clear();
            confirm.Clear();
            adresse.Clear();
            cmbsite.Text = "Selectionner";
        }
        void  afficheruser()
        {
            conn.communication();
            conn.da = new SqlDataAdapter("select * FROM [dbo].[COMPTE]",conn .con );
            conn.dt = new DataTable();
            conn.da.Fill(conn.dt);
            dataGridView1.DataSource = conn.dt;
            conn.con.Close();
        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Form1 LOG = new Form1();
            this.Hide();
            LOG.Show();
        }
        void rechercheuser()
        {
            conn.communication();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            conn.cmd1.CommandText = "SELECT [Nom],[Postnom],[Prenom],[Statut],[Telephone],[Password],[Confirme],[Adresse],[Site] FROM [dbo].[COMPTE] where Telephone='" + txtrecherche.Text + "'";
            
            conn .dr =conn.cmd1.ExecuteReader();
                if (conn.dr.HasRows)
                {
                    if (conn.dr .Read ())
                    {
            nom.Text = conn.dr["Nom"].ToString();
            postnom.Text = conn.dr["Postnom"].ToString();
            prenom.Text = conn.dr["Prenom"].ToString();
            cmbstatus.Text = conn.dr["Statut"].ToString();
            phone.Text = conn.dr["Telephone"].ToString();
            password.Text = conn.dr["Password"].ToString();
            confirm.Text = conn.dr["Confirme"].ToString();
            adresse.Text = conn.dr["Adresse"].ToString(); 
            cmbsite.Text = conn.dr["Site"].ToString(); 
                    }
        }
        }
        public void SelectSites()
        {
            conn.communication();
            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
            conn.cmd2.CommandText = "SELECT * FROM [GS_ALIMENT].[dbo].[Sites]";
            conn.cmd2.Connection = conn.con;
            SqlDataReader myreder;
            try
            {
                myreder = conn.cmd2.ExecuteReader();
                while (myreder.Read())
                {
                    string sname = myreder.GetString(1);
                    cmbsite.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            afficheruser();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            creer();
            annuler();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            annuler();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            rechercheuser();
        }

        private void Creationcompte_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        private void nom_TextChanged(object sender, EventArgs e)
        {
            this.nom.Text = this.nom.Text.ToUpper();
            this.nom.SelectionStart = this.nom.Text.Length;
        }

        private void postnom_TextChanged(object sender, EventArgs e)
        {
            this.postnom.Text = this.postnom.Text.ToUpper();
            this.postnom.SelectionStart = this.postnom.Text.Length;
        }

        private void prenom_TextChanged(object sender, EventArgs e)
        {
            this.prenom.Text = this.prenom.Text.ToUpper();
            this.prenom.SelectionStart = this.prenom.Text.Length;
        }

        private void adresse_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
