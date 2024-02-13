using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient ;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Seconnecter conn = new Seconnecter();
        SqlDataAdapter da = new SqlDataAdapter();
        //DialogResult echo = new DialogResult();
        public Form1()
        {
            InitializeComponent();
            SelectSites();
            recupourcentage();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = " "+DateTime.Now;
        }
        public void connect()
        {
            try
            {
                if (label7.Text == "4")
            {
                MessageBox.Show("** Vous n'êtes pas resposable de ce compte! **");
                this.Close();
            }
            else 
            {
            conn.communication();
            da= new SqlDataAdapter ("select Statut from compte where Nom='" + nom.Text + "' and Statut='" + statut.Text + "' and Password='" + code.Text + "' and Site='"+combosite.Text+"'", conn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                timer2.Stop();
                if (statut.Text =="ADMIN" )
                {
                  PAGE_ACCUEIL men = new PAGE_ACCUEIL();
                  men.label48.Text = nom.Text;
                  men.label49.Text = statut.Text;
                  men.txtnomvende.Text = nom.Text;
                  men.txtnomv.Text = nom.Text;
                  men.lblsiteuser.Text = combosite.Text;
                  this.Hide();
                  men.Show();
                }
                else if (statut.Text == "SUPPORT")
                {
                    PAGE_ACCUEIL men = new PAGE_ACCUEIL();
                    men.label48.Text = nom.Text;
                    men.label49.Text = statut.Text;
                    men.txtnomvende.Text = nom.Text;
                    men.txtnomv.Text = nom.Text;
                    men.lblsiteuser.Text = combosite.Text;
                    men.label48.Text = nom.Text;
                    men.label49.Text = statut.Text;
                    men.txtnomvende.Text = nom.Text;
                    men.txtnomv.Text = nom.Text;
                    men.xtraTabPage2.Visible = false;
                    men.groupBox10.Visible = false;
                    men.groupBox9.Visible = false;
                    men.groupBox11.Visible = false;
                    men.groupBox52.Enabled = false;
                    men.xtraTabPage8.Enabled = false;
                    men.groupBox50.Enabled = false;
                    men.GK.Enabled = false;
                    men.GKK.Enabled = false;
                    men.groupBox10.Visible = false;
                    this.Hide();
                    men.Show();
                }
                else 
                {
                    PAGE_ACCUEIL aa = new PAGE_ACCUEIL();
                    aa.label48.Text = nom.Text;
                    aa.label49.Text = statut.Text;
                    aa.txtnomvende.Text = nom.Text;
                    aa.lblsiteuser.Text = combosite.Text;
                    aa.txtnomv.Text = nom.Text;
                    aa.xtraTabPage2.Visible = false;
                    aa.groupBox10.Visible = false;
                    aa.groupBox9.Visible = false;
                    aa.groupBox20.Visible = false;
                    aa.groupBox3.Visible = false;
                    aa.groupBox52.Enabled = false;
                    aa.xtraTabPage8.Enabled = false;
                    aa.groupBox50.Enabled = false;
                    aa.GK.Enabled = true;
                    aa.GKK.Enabled = true;
                    aa.groupBox10.Visible = false;
                    aa.groupBox17.Enabled = false;
                    aa.groupBox29.Visible = false;
                    aa.groupBox8.Enabled = false;
                    this.Hide();
                    aa.Show();
                }
            }
            else
            {
                MessageBox.Show("Le nom, le mot de passe et ou le statut est incorrect", "GS-COMMERCIALE");
            }
            conn.con.Close();
        }
            }
            catch (Exception david)
            {
                MessageBox.Show(david.Message.ToString());
            }
        }  
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            annuler();
        }
        public void annuler()
        {
            nom.Clear();
            code.Clear();
            statut.Text = "";
        }
        private void label1_Click(object sender, EventArgs e)
        {
              
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //testdcontrolapk();
            connect();
        
        }
        private void label5_Click(object sender, EventArgs e)
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {  
        }
        void connadmin()
        {
            try
            {
                if (label7.Text == "4")
                {
                    MessageBox.Show("* Vous n'avais pas ce droit, veuillez contacter l'administrateur !*", "GS-COMMERCIALE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    if (nom.Text == "PHARMACIE" && code.Text == "ADMIN" && statut.Text == "ADMIN")
                    {
                        timer2.Stop();
                        MessageBox.Show("Vous êtes administrateur");
                        Creationcompte cpt = new Creationcompte();
                        this.Hide();
                        cpt.Show();
                    }
                    else
                    {
                        MessageBox.Show("Opération échoué, vueillez vérifiez les informations introduites");
                    }
                }   
            }
            catch (Exception dav)
            {
                MessageBox.Show(dav.Message.ToString());
            } 
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            montre();
            connadmin();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void nom_Click(object sender, EventArgs e)
        {
            nom.Clear();
        }
        private void code_Click(object sender, EventArgs e)
        {
            code.Clear();
        }
        private void statut_Click(object sender, EventArgs e)
        {
           
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            montre();
        }
        public void montre()
        {
            int cpt, recup;
            cpt = int.Parse(label7.Text);
            recup = cpt + 1;
            label7.Text = Convert.ToString(recup);
        }
        private void code_TextChanged(object sender, EventArgs e)
        {
            code.PasswordChar = '*';
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.30)
            {
                this.Opacity -= 0.10;
            }
            else 
            {
                timer3.Stop();
                Application.Exit();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }
        private void combosite_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //void testdcontrolapk()
        //{
        //    DateTime dat1 = DateTime.Now;
        //    DateTime dat2 = DateTime.Parse("2023-06-16");
        //    if (dat1.Date > dat2.Date)
        //    {
        //        MessageBox.Show("Votre abonnement est arrivé à terme, veuillez contacter l'administrateur", "GS-COMMERCIALE");
        //        Form1 PGC = new Form1();
        //        PGC.Hide();
        //       // PGC.ShowDialog();
        //    }
        //    else
        //    {
        //        connect();       
        //    }
        //}
        void recupourcentage()
        {
            try
            {
                conn.communication();
                conn.cmd = new System.Data.SqlClient.SqlCommand();
                conn.cmd.Connection = conn.con;
                conn.cmd.CommandType = CommandType.Text;
                conn.cmd.CommandText = "SELECT [Pourcentage] FROM [GS_ALIMENT].[dbo].[T_pourcentage]";
                conn.dr1 = conn.cmd.ExecuteReader();
                while (conn.dr1.Read())
                {
                    txtmodifmodulo.Text = conn.dr1["Pourcentage"].ToString();
                }
                conn.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        void modifiemodulo()
        {
            conn.communication();
            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
            conn.cmd2.Connection = conn.con;
            conn.cmd2.CommandType = CommandType.Text;
            conn.cmd2.CommandText = "UPDATE [dbo].[T_pourcentage] SET [Pourcentage]='" + txtmodifmodulo.Text + "'where Ordre= 1";
            if (conn.cmd2.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(" Mise a jour effectué ");
            }
            else {
                MessageBox.Show("Opération échoué, veuillez allumer votre serveur !");
                txtmodifmodulo.Focus();
            }
        }
        public void SelectSites()
        {
            conn.communication();
            conn.cmd3 = new System.Data.SqlClient.SqlCommand();
            conn.cmd3.CommandText = "SELECT * FROM [GS_ALIMENT].[dbo].[Sites]";
            conn.cmd3.Connection = conn.con;
            SqlDataReader myreder;
            try
            {
                myreder = conn.cmd3.ExecuteReader();
                while (myreder.Read())
                {
                    string sname = myreder.GetString(1);
                    combosite.Items.Add(sname);
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            modifiemodulo();
            button1.Visible = false;
            txtmodifmodulo.Visible = false;
        }
        private void txtmodifmodulo_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtvalider_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txtvalider_TextChanged_1(object sender, EventArgs e)
        {
            if (txton.Text == "M" && txttwo.Text == "A" && txtfree.Text == "C" && txtfour.Text == "I" && txtvalider.Text == "e")
            {
                txtmodifmodulo.Visible = true;
                button1.Visible = true;
            }
            else 
            {
                MessageBox.Show("Accès refusé");
                txtmodifmodulo.Visible = false;
                button1.Visible = false;
            }
        }
        private void txton_Click(object sender, EventArgs e)
        {
            txton.Clear();
        }
        private void txttwo_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void txtfree_Click(object sender, EventArgs e)
        {
            txtfree.Clear();
        }
        private void txttwo_Click(object sender, EventArgs e)
        {
            txttwo.Clear();
        }
        private void txtfour_Click(object sender, EventArgs e)
        {
            txtfour.Clear();
        }
        private void txtvalider_Click(object sender, EventArgs e)
        {
            txtvalider.Clear();
        }
        private void nom_TextChanged(object sender, EventArgs e)
        {
            this.nom.Text = this.nom.Text.ToUpper();
            this.nom.SelectionStart = this.nom.Text.Length;
        }
    }
}
