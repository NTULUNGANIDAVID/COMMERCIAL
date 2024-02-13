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
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

using DGVPrinterHelper;

namespace WindowsFormsApplication1
{
    public partial class PAGE_ACCUEIL : Form
    {
        Seconnecter conn = new Seconnecter();
        Classcoin conncoin = new Classcoin();
        Classlimete connlimete = new Classlimete();
        Classbeatrice connbeatrice = new Classbeatrice();
        Classnew connnew = new Classnew();

        DialogResult echo = new DialogResult();
        public PAGE_ACCUEIL()
        {
            InitializeComponent();

            scr_val = 0; scr_david = 0;
            Verificationdateexpiration();
            recupourcentage();
            SelectClient();
            showclient();
            SelectClientVentecredi();
            Rowscolorexpirearticle();
            sommefondApprovisionnemnts();
            
        }
        int scr_val, scr_david;
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1timer.Text = "DATE:" + DateTime.Now;
        }
        private void vScrollBar2_Click(object sender, EventArgs e)
        {

        }
        public void annuler()
        {
            txtunitesarticle.Clear();
            cmbcat.Text = "";
        }
        public void actualiser()
        {
            conn.communication();
            conn.da1 = new SqlDataAdapter("select * FROM [dbo].[Liste_produit]", conn.con);
            conn.dt = new DataTable();
            conn.da1.Fill(conn.dt);
            listeproduits.Refresh();
            conn.con.Close();
        }
        public void enregistrer()
        {
            try
            {
                conn.communication();
                conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                conn.cmd1.Connection = conn.con;
                conn.cmd1.CommandType = CommandType.Text;
                conn.cmd1.CommandText = "INSERT INTO [Liste_produit] VALUES ('" + Regex.Replace(prod.Text, "'", "''") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Regex.Replace(cmbcat.Text, "'", "''") + "', '" + txtunitesarticle .Text+ "')";
                                                                                              //[NOM_PROD],                     [DATE_ENRE],                                                [CATEGORIE]                        ,[UNITES]
                if (conn.cmd1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Le produit " + prod.Text + "est bien enregistrer");
                    annuler();
                }
                else
                {
                    MessageBox.Show("Le produit n'est pas enregistrer");
                }
                conn.con.Close();
            }
            catch (Exception mes)
            {
                MessageBox.Show("Recommancer" + mes);
            }
        }
        public void supprimer()
        {
            echo = MessageBox.Show("Voulez vous supprimer ce produit?", "GS-COMMERCIALE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (prod.Text == "")
            {
                MessageBox.Show("Svp, Veuillez Entrer le nom du produit que vous voulez supprimer");
            }
            else if (echo == DialogResult.Yes)
            {
                conn.communication();
                conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                conn.cmd1.Connection = conn.con;
                conn.cmd1.CommandType = CommandType.Text;
                conn.cmd1.CommandText = "Delete from [Liste_produit] where Nom_prod='" + prod.Text + "'";
                if (conn.cmd1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ce produit est bien supprimer");
                }
                else { MessageBox.Show("Ce produit n'est pas supprimer"); }
            }
            conn.con.Close();
        }
        public void DeleteApprovStatistique()
        {

            if (txtarticlemodif.Text == "")
            {
                MessageBox.Show("Svp, Veuillez cherché l'Article que vous voulez supprimer");
            }
            else
            {
                conn.communication();
                conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                conn.cmd1.Connection = conn.con;
                conn.cmd1.CommandType = CommandType.Text;
                conn.cmd1.CommandText = " Delete FROM [GS_ALIMENT].[dbo].[Approvisionnements] where ID ='" + labeldeleteDapprov.Text + "' and Officine ='" + lblsiteuser.Text + "'and Nom_prod='" + txtarticlemodif.Text + "'";
                if (conn.cmd1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Cet Article est bien supprimer");
                }
                else 
                { 
                    MessageBox.Show("Cet Article n'est pas supprimer"); 
                }
            }
            conn.con.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }
        public void afficher()
        {
            conn.communication();
            conn.da1 = new SqlDataAdapter("select * FROM [dbo].[Liste_produit]", conn.con);
            conn.dt = new DataTable();
            conn.da1.Fill(conn.dt);
            listeproduits.DataSource = conn.dt;
            conn.con.Close();
        }
        private void simpleButton25_Click(object sender, EventArgs e)
        {
            enregistrer();
        }
        public void enregistrerapprovisionnement()
        {
            conn.communication();
            // Random Num_prod = new Random();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            conn.cmd1.CommandText = "INSERT INTO [dbo].[Liste_produit] VALUES ('" + txtnumlotaprov.Text + "','" + Regex.Replace(prod.Text, "'", "''") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Regex.Replace(cmbcat.Text, "'", "''") + "'";
                                                                                     //([Num_prod],          [Nom_prod],       [Qte_sotock],        [Fournisseur],         [PA],           [PV],              [Date_enre],            [Categorie]          
            if (conn.cmd1.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Le produit est bien enregistrer");
            }
            else
            {
                MessageBox.Show("Le produit n'est pas enregistrer");
            }
            conn.con.Close();
        }
        public void recherchenom()
        {
            conn.communication();
            conn.da1 = new SqlDataAdapter("select * FROM [dbo].[Liste_produit] where Nom_prod like '" + richbynom.Text + "%'", conn.con);
            conn.dt = new DataTable();
            conn.da1.Fill(conn.dt);
            listeproduits.DataSource = conn.dt;
            conn.con.Close();
        }
        public void ajouprod()
        {
            if (richprod.Text == "")
            {
                MessageBox.Show("Le champ nom est obligatoire stp !");
                richprod.Focus();
            }
            else if (txtpa.Text == "")
            {
                MessageBox.Show("Le champ prix d'achat est obligatoire stp !");
                txtpa.Focus();
            }
            else if (txtnumlotaprov.Text == "")
            {
                MessageBox.Show("Le champ numéro de lot est obligatoire stp !");
                txtnumlotaprov.Focus();
            }
            else if (txtqtesto.Text == "")
            {
                MessageBox.Show("Le champ quantité stock est obligatoire stp !");
                txtqtesto.Focus();
            }
            else if (txtrecupQteEntre.Text == "")
            {
                MessageBox.Show("Le champ confirmer stock est obligatoire stp !");
                txtrecupQteEntre.Focus();
            }
            else if (cmbformearticle.Text == "")
            {
                MessageBox.Show("Le champ famille est obligatoire stp !");
                cmbformearticle.Focus();
            }
            else if (txtaproetagere.Text == "")
            {
                MessageBox.Show("Le champ rayon est obligatoire stp !");
                txtaproetagere.Focus();
            }
            else if (dateExpiration.Text == "")
            {
                MessageBox.Show(" Selectionner la date d'expiration stp !");    
            }
            else
            {
                try
                {
                    conn.communication();
                    conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                    conn.cmd1.Connection = conn.con;
                    conn.cmd1.CommandType = CommandType.Text;
                    conn.cmd1.CommandText = "INSERT INTO [Approvisionnements] VALUES ('" + Regex.Replace(txtnumlotaprov.Text, "'", "''") + "','" + Regex.Replace(richprod.Text, "'", "''") + "' ,'" + Regex.Replace(txtqtesto.Text, "'", "''") + "' , '" + Regex.Replace(txtpa.Text, "'", "''") + "','" + Regex.Replace(DateTime.Now.ToString("yyyy-MM-dd"), "'", "''") + "','" + Regex.Replace(txtrecupQteEntre.Text, "'", "''") + "','" + Regex.Replace(cmbformearticle.Text, "'", "''") + "','" + Regex.Replace(txtaproetagere.Text, "'", "''") + "','" + Regex.Replace(dateExpiration.Value.ToString("yyyy-MM-dd"), "'", "''") + "', '" +Regex.Replace(richUnitesventes.Text,"'","''") + "', '"+Regex.Replace(lblsiteuser.Text,"'","''")+"')";
                    //                                                                                    [Num_lot],                                         [Nom_prod],                                        [Qte_sotock],                                        [PA],                                              [Date_enre],                                              [StockEntre],                                                            [Famille],                                             [Rayon],                                                 [Date_exp]                                                                      [Unités]                                                Officine                             
                    if (conn.cmd1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Article " + " " + richprod.Text + " ** est bien approvisionné chez ** " + " " +lblsiteuser.Text+ " ");
                        annulapprov();
                    }
                    else
                    {
                        MessageBox.Show(" Article" + richprod.Text + " n'a pas était approvisionné ");
                    }
                }
                catch (Exception req)
                {
                    MessageBox.Show(" Un Article ne peut pas être enregistrer deux(2) fois ! Veuillez aller à la Page Statistique pour ajourter la quantité" + req);
                }

                conn.con.Close();
            }
        }
        void annulapprov()
        {
            txtpa.Clear();
            txtnumlotaprov.Clear();
            txtqtesto.Clear();
            cmbformearticle.Text="";
            txtaproetagere.Clear();
            txtrecupQteEntre.Clear();
            richUnitesventes.Clear();
        }
        void afficheapprov()
        {
            conn.communication();
            conn.da = new SqlDataAdapter("select * FROM [dbo].[Approvisionnements] where Officine='" + lblsiteuser.Text + "'", conn.con);
            conn.dt = new DataTable();
            conn.ds=new DataSet();
            conn.da.Fill(conn.ds, scr_val, 25, "Approvisionnements");
            Listeapprovisionnement.DataSource = conn.ds.Tables[0];
            conn.con.Close();
            lblnbrepage.Text = Listeapprovisionnement.Rows.Count.ToString(); 
        }
        private void simpleButton24_Click(object sender, EventArgs e)
        {
            annuler();
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton22_Click(object sender, EventArgs e)
        {
            afficher();  
        }
        private void simpleButton23_Click(object sender, EventArgs e)
        {
            actualiser();
        }
        private void simpleButton17_Click(object sender, EventArgs e)
        {
            enregistrerapprovisionnement();
        }
        private void simpleButton20_Click(object sender, EventArgs e)
        {
            supprimer();
            annuler();
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
        }
        void SOMMEBENEJOUR()
        {
            //Methode pour afficher la sommation du bénéfice par jour
            conn.communication();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            conn.cmd1.CommandText = "select sum(Benefice)Benefice from [dbo].[T_benefice] where Dateope='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and Sites='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd1.ExecuteReader();
            while (conn.dr2.Read())
            {
                txttotbenjour.Text = Convert.ToString(conn.dr2["Benefice"].ToString());
                text1.Text = Convert.ToString(conn.dr2["Benefice"].ToString());
            }
            conn.dr.Close();
        }
        void sommegenemoi()
        {
            //Methode pour afficher la sommation du bénéfice par mois
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select sum(Benefice)Benefice from [dbo].[T_benefice] where Mois='" + labMoisOperation.Text + "' and Sites='" + lblsiteuser.Text + "'";
            conn.dr = conn.cmd.ExecuteReader();
            while (conn.dr.Read())
            {
                totbemoi.Text = Convert.ToString(conn.dr["Benefice"].ToString());
                text2.Text = Convert.ToString(conn.dr["Benefice"].ToString());
            }
            conn.dr.Close();
        }
        void totalgeneralmoi()
        {
            //Methode pour afficher la somme général du mois
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select sum(Prix_total)Prix_total from [dbo].[Ventes] where Mois='" + labMoisOperation.Text + "' and Sites='" + lblsiteuser.Text + "'";
            conn.dr1 = conn.cmd.ExecuteReader();
            while (conn.dr1.Read())
            {
                //double txttotalgenmoi = 0;
                txttotalgenmoi.Text = Convert.ToString(conn.dr1["Prix_total"].ToString());
                text4.Text = Convert.ToString(conn.dr1["Prix_total"].ToString());
                {

                }
            }
            conn.dr1.Close();
        }
        void totalventescredits()
        {
            //Methode pour affiché le total de vente en crédit
            conn.communication();
            conn.cmd3 = new System.Data.SqlClient.SqlCommand();
            conn.cmd3.Connection = conn.con;
            conn.cmd3.CommandType = CommandType.Text;
            conn.cmd3.CommandText = "select sum(Prix_total)Prix_total from [dbo].[Vente_credit] WHERE Officine='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd3.ExecuteReader();
            while (conn.dr2.Read())
            {
                txttotalcredits.Text = Convert.ToString(conn.dr2["Prix_total"].ToString());
            }
            conn.dr2.Close();
        }
        void sommeventejour()
        {
            //Methode pour afficher(selectionner la sommation de la vente du jour
            conn.communication();
            conn.cmd3 = new System.Data.SqlClient.SqlCommand();
            conn.cmd3.Connection = conn.con;
            conn.cmd3.CommandType = CommandType.Text;
            conn.cmd3.CommandText = "select sum(Prix_total)Prix_total from [dbo].[Ventes] where Date_vendu='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and Sites='" + lblsiteuser.Text + "'";
            conn.dr1 = conn.cmd3.ExecuteReader();
            while (conn.dr1.Read())
            {

                txttotaljour.Text = Convert.ToString(conn.dr1["Prix_total"].ToString());
                text3.Text = Convert.ToString(conn.dr1["Prix_total"].ToString());
            }
            conn.dr1.Close();
        }
        void methodedepensesjour()
        {
            //Methode pour afficher(selectionner la sommation des dépenses du jour
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select sum(Montant)Montant from [dbo].[Depense_prod] where Datedepense='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and Officine='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd.ExecuteReader();
            while (conn.dr2.Read())
            {
                txtdepensejour.Text = Convert.ToString(conn.dr2["Montant"].ToString());
                text5.Text = Convert.ToString(conn.dr2["Montant"].ToString());
            }
            conn.dr2.Close();
        }
        void totalprodenregistrer()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select COUNT (Nom_prod) Nom_prod from [dbo].[Liste_produit] ";
            conn.dr = conn.cmd.ExecuteReader();
            while (conn.dr.Read())
            {
                label57.Text = conn.dr["Nom_prod"].ToString();
            }
            conn.dr.Close();
        }
        void methodedepensesdumoi()
        {
            //Methode pour afficher(selectionner la sommation des dépenses du mois
            conn.communication();
            conn.cmd3 = new System.Data.SqlClient.SqlCommand();
            conn.cmd3.Connection = conn.con;
            conn.cmd3.CommandType = CommandType.Text;
            conn.cmd3.CommandText = "select sum(Montant)Montant FROM [dbo].[Depense_prod] where Mois ='" + labMoisOperation.Text + "' and Officine='" + lblsiteuser.Text + "'";
            conn.dr = conn.cmd3.ExecuteReader();
            while (conn.dr.Read())
            {
                txtdepensesmoi.Text = Convert.ToString(conn.dr["Montant"].ToString());
                text6.Text = Convert.ToString(conn.dr["Montant"].ToString());
            }
            conn.dr.Close();
        }
        private void richbynom_TextChanged(object sender, EventArgs e)
        {
            recherchenom();
        }
        void updatelisteproduit()
        {
            try
            {
                conn.communication();
                conn.cmd3 = new System.Data.SqlClient.SqlCommand();
                conn.cmd3.Connection = conn.con;
                conn.cmd3.CommandType = CommandType.Text;
                echo = MessageBox.Show("Voulez-vous apporter la modification à ce produit?", "GS-COMMERCIALE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (echo == DialogResult.Yes)
                    conn.communication();
                conn.cmd3.CommandText = "UPDATE [dbo].[Liste_produit] SET [NOM_PROD] ='" + prod.Text + "',[CATEGORIE] ='" + cmbcat.Text + "', [UNITES]='" + txtunitesarticle.Text + "' WHERE NOM_PROD='" + lblrecupenomart.Text + "'";
                                                                        //[NOM_PROD],         [DATE_ENRE],[CATEGORIE],                        [UNITES]
                if (conn.cmd3.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("La modification à reussi");
                }
            }
            catch (Exception mess)
            {
                MessageBox.Show("Erreur" + mess);
            }
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            updatelisteproduit();
            annuler();
        }
        private void simpleButton15_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton17_Click_1(object sender, EventArgs e)
        {

        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }
        private void txttot_TextChanged(object sender, EventArgs e)
        {

        }
        void annulervente()
        {
            richnomprod.Clear(); txtprixv.Clear(); txtqteve.Text="0"; txttot.Clear();
        }
        void vendreprod()
        {
            try
            {
                if (richnomprod.Text == "0" && txtprixv.Text == "0" && txtqteve.Text == "0" && txttot.Text == "0")
                {
                    MessageBox.Show("Veuillez d'abord remplire le champs vide");
                }
                else
                {
                    if (txtprixv.Text.Length != 0)
                    {
                        // déclaration des variables de types réel
                        double quantajout, stockQte, QteAugmentat;
                        stockQte = 0;
                        quantajout = Convert.ToDouble(txtqteve.Text);
                        //connection pour sélectionner la quantité qui se trouve dans la base de donnée
                        conn.communication();
                        conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                        conn.cmd1.Connection = conn.con;
                        conn.cmd1.CommandType = CommandType.Text;
                        conn.cmd1.CommandText = "select Qte_sotock from [dbo].[Approvisionnements] where Nom_prod='" + Regex.Replace(richnomprod.Text, "'", "''") + "' and Officine='" + lblsiteuser.Text + "'";
                        conn.dr = conn.cmd1.ExecuteReader();
                        while (conn.dr.Read())
                        {
                            stockQte = Convert.ToDouble(conn.dr["Qte_sotock"]);
                        }
                        conn.dr.Close();

                        QteAugmentat = stockQte - quantajout;
                        // Contrôle de la quantité qui se trouve dans la base de données 

                        if (quantajout > stockQte)
                        {
                            MessageBox.Show("Désolé, la quantité de(du)" + richnomprod.Text + " demandée  n'est pas disponible");
                            txtqteve.Focus();
                            //if (echo == DialogResult.Yes)
                            //{
                            //    txtqteve.Focus();
                            //}
                        }
                        else if (stockQte == 0)
                        {
                            MessageBox.Show("le produit" + richnomprod.Text + " est épuisé");
                            txtqteve.Focus();
                        }
                        //else if(quantajout == stockQte)
                        //{
                        //}
                        else
                        {
                            // modification de quantité
                            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                            conn.cmd1.Connection = conn.con;
                            conn.cmd1.CommandType = CommandType.Text;
                            conn.communication();
                            conn.cmd1.CommandText = "update [dbo].[Approvisionnements] set Qte_sotock='" + QteAugmentat + "' where Nom_prod='" + richnomprod.Text + "' and Officine='" + lblsiteuser.Text + "'";
                            conn.cmd1.ExecuteNonQuery();

                            // Méthode pour enregistrer le bénéfice du jour et moi
                            conn.communication();
                            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                            conn.cmd2.Connection = conn.con;
                            conn.cmd2.CommandType = CommandType.Text;
                            conn.cmd2 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[T_benefice] values (@Nom_prod,@Prix_tot,@Benefice,@Dateope,@Mois,@Nom_vend,@Sites)", conn.con);
                            conn.cmd2.Parameters.AddWithValue("@Nom_prod", richnomprod.Text);
                            conn.cmd2.Parameters.AddWithValue("@Prix_tot", float.Parse(txttot.Text));
                            conn.cmd2.Parameters.AddWithValue("@Benefice", float.Parse(txtbenef.Text));
                            conn.cmd2.Parameters.AddWithValue("@Dateope", DateTime.Now.ToString("yyyy-MM-dd"));
                            conn.cmd2.Parameters.AddWithValue("@Mois", labMoisOperation.Text);
                            conn.cmd2.Parameters.AddWithValue("@Nom_vend", txtnomvende.Text);
                            conn.cmd2.Parameters.AddWithValue("@Sites", lblsiteuser.Text);
                            conn.cmd2.ExecuteNonQuery();
                        }
                    }
                }
            }
        
            catch (Exception david)
            {
               MessageBox.Show(david.Message.ToString());
            }
        }
        void effacerproduitsvendu()
        {
            richnomprod.Clear(); txtprixv.Clear(); txtqteve.Clear(); txttot.Clear(); txtbenef.Clear(); txtrecuppa.Clear(); comboclient.Text = "Selectionner ici"; lblsiteuser.Text = "Selectionner le Site";
        }
        void Factureencours()
        {
            if (label61.Text == "")
            {
                MessageBox.Show("Impossible d'imprimer la Facture sans numéro");
            }
            else
            {
                PAGE_ACCUEIL PA = new PAGE_ACCUEIL();
                CrystalReport2 cry = new CrystalReport2();
                Facture_clients facli = new Facture_clients();
                facli.label5.Text = label48.Text;
                facli.label6.Text = label49.Text;
                facli.labelsitefacture.Text = lblsiteuser.Text;
                this.Hide();
                cry.Load("CrystalReport2.rpt");
                cry.Refresh();
                cry.SetParameterValue("Factureclient", labelrecupnumber.Text);
                facli.crystalReportViewer1.ReportSource = cry;
                facli.Show();
            }
        }
        private void simpleButton10_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton13_Click(object sender, EventArgs e)
        {
        }
        private void txttot_Leave(object sender, EventArgs e)
        {

        }
        private void txttot_CursorChanged(object sender, EventArgs e)
        {

        }
        private void txttot_TabIndexChanged(object sender, EventArgs e)
        {

        }
        private void txttot_MouseLeave(object sender, EventArgs e)
        {

        }
        private void txttot_Validated(object sender, EventArgs e)
        {

        }
        private void txttot_Validating(object sender, CancelEventArgs e)
        {

        }
        void supfact()
        {
            // Méthode pour supprimer la facture précédente 
            try
            {
                conn.communication();
                conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                conn.cmd2.Connection = conn.con;
                conn.cmd2.CommandType = CommandType.Text;
                conn.cmd2.CommandText = " DELETE FROM [dbo].[Factures] where Sites='" + lblsiteuser.Text + "'";
                conn.cmd2.ExecuteNonQuery();
                //MessageBox.Show("Effectué la nouvelle vente");
                annulervente();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }
        void Supprimerrpjpour()
        {
            // Méthode pour supprimer la vente du jour, pour permettre d'imprimer le rapport journalier
            try
            {
                conn.communication();
                conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                conn.cmd1.Connection = conn.con;
                conn.cmd1.CommandType = CommandType.Text;
                conn.cmd1.CommandText = " DELETE FROM [dbo].[Rapportjour] where Sites='" + lblsiteuser.Text + "'";
                conn.cmd1.ExecuteNonQuery();
                MessageBox.Show("Vous pouvez établir un nouveau rapport");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            //supfact();
            recupnumordre();
            Paniervente.Rows.Clear();
            simpleButton18.Enabled = true;
            txtqteve.Focus();
        }
        void recupnumordre()
        {
            try
            {
                conn.communication();
                conn.cmd3 = new System.Data.SqlClient.SqlCommand();
                conn.cmd3.Connection = conn.con;
                conn.cmd3.CommandType = CommandType.Text;
                conn.cmd3.CommandText = "SELECT [N_Ordre] FROM [dbo].[NumOrdre]";
                conn.dr2 = conn.cmd3.ExecuteReader();
                while (conn.dr2.Read())
                {
                    labelrecupnumber.Text = conn.dr2["N_Ordre"].ToString();
                    simpleButton18.Enabled = true;
                }
                conn.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
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
                    lblpourcentage.Text = conn.dr1["Pourcentage"].ToString();
                }
                conn.con.Close();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message.ToString());
            }
        }
        // Méthode pour selectionner le produit par sa formes
        void MethodeInformArticleVenteformes()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "SELECT [Nom_prod],[PA],[Qte_sotock],[Num_lot],[Famille],[Rayon] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + richformes.Text + "' and Officine='" + lblsiteuser.Text + "'";
            conn.dr = conn.cmd.ExecuteReader();
            if (conn.dr.HasRows)
            {
                listbyforme.Visible = true;
                if (conn.dr.Read())
                {
                    txtrecuppa.Text = conn.dr["PA"].ToString();
                    labelreststock.Text = conn.dr["Qte_sotock"].ToString();
                    lbllotnumber.Text = conn.dr["Num_lot"].ToString();
                    labformes.Text = conn.dr["Famille"].ToString();
                    labetagere.Text = conn.dr["Rayon"].ToString();
                }
            }
            else
            {
               // richnomprod.Text = "";
                txtprixv.Text = "";
                listbyforme.Visible = false;
            }
            conn.dr.Close();
        }
        // Méthode pour rechercher un article par l'ordre de formes
        void MethodeAfficheListeBoxVenteformes()
        {
            try
            {
                conn.communication();
                conn.cmd = new System.Data.SqlClient.SqlCommand();
                conn.cmd.Connection = conn.con;
                conn.cmd.CommandType = CommandType.Text;
                if (listbyforme.Text.Length != 0)
                {
                    listbyforme.Visible = true;
                    conn.cmd.CommandText = "SELECT * FROM (Nom_prod) as Prod [dbo].[Approvisionnements] where Famille like'" + richformes.Text + "%' and Officine='" + lblsiteuser.Text + "' order by Famille  ASC";
                    //conn.cmd.CommandText = "SELECT distinct(Formes) as Prod FROM [dbo].[Approvisionnements] where Formes like'" + richformes.Text + "%' order by Formes  ASC";
                    conn.dr2 = conn.cmd.ExecuteReader();
                    listbyforme.Items.Clear();
                    while (conn.dr2.Read())
                    {
                        listbyforme.Items.Add(conn.dr2["Prod"]);
                    }
                    conn.dr2.Close();
                }
                else
                {
                    listbyforme.Visible = false;
                    listbyforme.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        void MethodeInformArticleqteaprovis()
        {
            conn.communication();
            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
            conn.cmd2.Connection = conn.con;
            conn.cmd2.CommandType = CommandType.Text;
            conn.cmd2.CommandText = "SELECT [Num_lot],[Nom_prod],[Qte_sotock],[PA],[StockEntre],[Famille],[Rayon],[Date_exp],[Unites],[ID] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + textnomartapprv.Text + "' and Officine='" + lblsiteuser.Text + "'";
            conn.dr = conn.cmd2.ExecuteReader();
            if (conn.dr.HasRows)
            {
                  listAddqte.Visible = true;
                if (conn.dr.Read())
                {
                    textnumlotaqte.Text = conn.dr["Num_lot"].ToString();
                    textnomartapprv.Text = conn.dr["Nom_prod"].ToString();
                    txtarticlemodif.Text = conn.dr["Nom_prod"].ToString();
                    textqterestestock.Text = conn.dr["Qte_sotock"].ToString();
                    txtprixventemodif.Text = conn.dr["PA"].ToString();
                    textqteaprovstock.Text = conn.dr["StockEntre"].ToString();
                    cmbfamillemodif.Text = conn.dr["Famille"].ToString();
                    txtraoyonmodif.Text = conn.dr["Rayon"].ToString();
                    txtunitventemodif.Text = conn.dr["Unites"].ToString();
                    labeldeleteDapprov.Text = conn.dr["ID"].ToString();
                    dateTimePicker2.Text = conn.dr["Date_exp"].ToString();
                }
            }
            else
            {
                listAddqte.Visible = false;
            }
            conn.dr.Close();
        }
        
        private void txtqteve_TextChanged(object sender, EventArgs e)
        {
            //Calculmodulo();
            //calculpourcentage();
            try
            {
                if (txtprixv.Text == "")
                {
                    txtprixv.Focus();
                }
                else
                {
                    double a, b, result;
                    a = Convert.ToDouble(txtprixv.Text);
                    b = Convert.ToDouble(txtqteve.Text);
                    result = a * b;
                    txttot.Text = Convert.ToString(result);
                    calculpourcentagebenefice();
                    //label60.Text = txttot.Text;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Vous devez entré juste le chiffre" + exc);
            }
        }
        void validertaux()
        {
            try 
            {
                conn.communication();
                conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                conn.cmd2.Connection = conn.con;
                conn.cmd2.CommandType = CommandType.Text;
                conn.cmd2.CommandText = "INSERT INTO [dbo].[Taux] values('" + Regex.Replace(richtaux.Text, "'", "''") + "','" + Regex.Replace(richfranc.Text, "'", "''") + "' ,'" + Regex.Replace(richdollars.Text, "'", "''") + "'";

                if (conn.cmd2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Le taux a été bien enregistrée");
                }
                else
                { MessageBox.Show("Le taux n'a pas été enregistrée"); }  
            }
            catch(Exception door)
            {
                MessageBox.Show(door.Message.ToString());
            }
            conn.con.Close();
        }
        void LireTaux()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select * from Taux";
            conn.dr = conn.cmd.ExecuteReader();
            while (conn.dr.Read())
            {
                richfranc.Text = conn.dr["franc"].ToString();
                label59.Text = richfranc.Text;
            }
        }
        void annulertaux()
        {
            richtaux.Clear();
            richfranc.Clear();
            richdollars.Clear();
        }
        void modifiertaux()
        {
            try
            {
                conn.communication();
                conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                conn.cmd2.Connection = conn.con;
                conn.cmd2.CommandType = CommandType.Text;
                conn.cmd2.CommandText = "UPDATE [dbo].[Taux] SET [franc]='" + richfranc.Text + "',[usd]='" + richdollars.Text + "' where Id_taux='" + richtaux.Text + "'";
                if (conn.cmd2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Le Taux à été modifier avec succès");
                }
            }
            catch (Exception ret)
            {
                MessageBox.Show(ret.Message.ToString());
            }  
        }
        void recherchetaux()
        {
            try
            {
            }
            catch (Exception pan)
            {
                MessageBox.Show(pan.Message.ToString());
            }
            conn.communication();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            conn.cmd1.CommandText = "SELECT [franc],[usd],[Id_taux] FROM [dbo].[Taux] where Id_taux ='" + richTextBox7.Text + "'";
            conn.dr = conn.cmd1.ExecuteReader();
            if (conn.dr.HasRows)
            {
                if (conn.dr.Read())
                {
                    richtaux.Text = conn.dr["Id_taux"].ToString();
                    richfranc.Text = conn.dr["franc"].ToString();
                    richdollars.Text = conn.dr["usd"].ToString();
                    label59.Text = conn.dr["franc"].ToString();
                }
            }
        }
        void recuppriventeetpourcentage()
        {
            conn.communication();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            conn.cmd1.CommandText = "SELECT [PA] FROM [dbo].[Approvisionnements] where Nom_prod ='" + richnomprod.Text + "'and Officine='" + lblsiteuser.Text + "'";
            conn.dr = conn.cmd1.ExecuteReader();
            if (conn.dr.HasRows)
            {
                if (conn.dr.Read())
                {
                    txtrecuppa.Text = conn.dr["PA"].ToString();
                }
            }
        }
        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            annulertaux();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            validertaux();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            modifiertaux();
        }

        //Méthode pour récupéré la quantité de stock resté dans la table approvisionnement
        void recustockdispo()
        {
            conn.communication();
            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
            conn.cmd2.Connection = conn.con;
            conn.cmd2.CommandType = CommandType.Text;
            conn.cmd2.CommandText = "SELECT [Num_lot],[Qte_sotock],[Famille],[Rayon],[Unites] FROM [dbo].[Approvisionnements] where Nom_prod ='" + richnomprod.Text + "' and Officine='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd2.ExecuteReader();
            if (conn.dr2.HasRows)
            {
                if (conn.dr2.Read())
                {
                    lbllotnumber.Text = conn.dr2["Num_lot"].ToString();
                    labelreststock.Text = conn.dr2["Qte_sotock"].ToString();
                    labformes.Text = conn.dr2["Famille"].ToString();
                    labetagere.Text = conn.dr2["Rayon"].ToString();
                    labunitevente.Text=conn.dr2["Unites"].ToString();
                }
            }
        }
        // Afficher la quantité et le prix et unité pour l'autre sites des ventes dans la table approvisionnement

        // Coin

        void recustockdispocoin()
        {
            conncoin.communicationcoin();
            conncoin.cmd5 = new System.Data.SqlClient.SqlCommand();
            conncoin.cmd5.Connection = conncoin.concoin;
            conncoin.cmd5.CommandType = CommandType.Text;
            conncoin.cmd5.CommandText = "SELECT [Qte_sotock],[Unites] FROM [dbo].[Approvisionnements] where Nom_prod ='" + richBoxarticlecoin.Text + "'and Officine='" + lblsiteuser.Text + "'";
            conncoin.dr5 = conncoin.cmd5.ExecuteReader();
            if (conncoin.dr5.HasRows)
            {
                if (conncoin.dr5.Read())
                {
                  
                    richboxqtecoin.Text = conncoin.dr5["Qte_sotock"].ToString();
                    richboxunite.Text = conncoin.dr5["Unites"].ToString();
                }
            }
        }

        // Limeté

        void recustockdispolimete()
        {
            connlimete.communicationlimete();
            connlimete.cmd5 = new System.Data.SqlClient.SqlCommand();
            connlimete.cmd5.Connection = connlimete.conlimete;
            connlimete.cmd5.CommandType = CommandType.Text;
            connlimete.cmd5.CommandText = "SELECT [Qte_sotock],[Unites] FROM [dbo].[Approvisionnements] where Nom_prod ='" + richboxarticlelimete.Text + "'and Officine='" + lblsiteuser.Text + "'";
            connlimete.dr5 = connlimete.cmd5.ExecuteReader();
            if (connlimete.dr5.HasRows)
            {
                if (connlimete.dr5.Read())
                {

                    richboxqtelimete.Text = connlimete.dr5["Qte_sotock"].ToString();
                    richboxunitelimete.Text = connlimete.dr5["Unites"].ToString();
                }
            }
        }
        // Beatrice

        void recustockdispobeatrice()
        {
            connbeatrice.communicationbeatrice();
            connbeatrice.cmd7 = new System.Data.SqlClient.SqlCommand();
            connbeatrice.cmd7.Connection = connbeatrice.conbeatrice;
            connbeatrice.cmd7.CommandType = CommandType.Text;
            connbeatrice.cmd7.CommandText = "SELECT [Qte_sotock],[Unites] FROM [dbo].[Approvisionnements] where Nom_prod ='" + richboxarticlebeatrice.Text + "'and Officine='" + lblsiteuser.Text + "'";
            connbeatrice.dr7 = connbeatrice.cmd7.ExecuteReader();
            if (connbeatrice.dr7.HasRows)
            {
                if (connbeatrice.dr7.Read())
                {
                    richboxqtebeatrice.Text = connbeatrice.dr7["Qte_sotock"].ToString();
                    richboxunitebeatrice.Text = connbeatrice.dr7["Unites"].ToString();
                }
            }
        }
        // New 

        void recustockdisponew()
        {
            connnew.communicationnew();
            connnew.cmd6 = new System.Data.SqlClient.SqlCommand();
            connnew.cmd6.Connection = connnew.connew;
            connnew.cmd6.CommandType = CommandType.Text;
            connnew.cmd6.CommandText = "SELECT [Qte_sotock],[Unites] FROM [dbo].[Approvisionnements] where Nom_prod ='" + richboxarticlenew.Text + "'and Officine='" + lblsiteuser.Text + "'";
            connnew.dr6 = connnew.cmd6.ExecuteReader();
            if (connnew.dr6.HasRows)
            {
                if (connnew.dr6.Read())
                {
                    richboxqtenew.Text = connnew.dr6["Qte_sotock"].ToString();
                    richboxunitenew.Text = connnew.dr6["Unites"].ToString();
                }
            }
        }
        private void simpleButton16_Click(object sender, EventArgs e)
        {
            recherchetaux();
        }
        private void simpleButton18_Click(object sender, EventArgs e)
        {

        }
        private void richnomprod_TextChanged(object sender, EventArgs e)
        {
            recuppriventeetpourcentage();
            recustockdispo();
        }
        // Méthode pour calculer le modulo de prix de vente d'un médicament
        void Calculmodulo()
        {
            try 
            {
                double r, s, resultat;
                if (txtrecuppa.Text == "")
                {
                    txtrecuppa.Text = "0";
                }
                if (lblpourcentage.Text == "")
                {
                    lblpourcentage.Text = "0";
                }
                r = Convert.ToDouble(txtrecuppa.Text);
                s = float.Parse(lblpourcentage.Text);
                resultat = r * s / 100 + r;
                txtprixv.Text = Convert.ToString(resultat);
            }
            catch(Exception mod)
            {
                MessageBox.Show(mod.Message.ToString());
            }
        }
        // Méthode pour calculer le modulo proformat
        void Calculmoduloproforma()
        {
            try
            {
                double r, s, resultat;
                if (txtpvprof.Text == "")
                {
                    txtpvprof.Text = "0";
                }
                if (lblpourcentage.Text == "")
                {
                    lblpourcentage.Text = "0";
                }
                r = Convert.ToDouble(txtpvprof.Text);
                s = float.Parse(lblpourcentage.Text);
                resultat = r * s / 100 + r;
                txtcalulemodulo.Text = Convert.ToString(resultat);
            }
            catch (Exception mod)
            {
                MessageBox.Show(mod.Message.ToString());
            }
        }
        private void txtprixv_TextChanged(object sender, EventArgs e)
        {

        }
        private void label66_Click(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void groupBox28_Enter(object sender, EventArgs e)
        {

        }
        private void simpleButton19_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton27_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton28_Click(object sender, EventArgs e)
        {

        }
        void calculpourcentagebenefice()
        {
            try
            {
                double aa, bb, cc, answer;
                aa = Convert.ToDouble(txtprixv.Text);
                bb= Convert.ToDouble(txtrecuppa.Text);
                cc = Convert.ToDouble(txtqteve.Text);
                answer = (aa - bb) * cc;
                txtbenef.Text = Convert.ToString(answer);
            }
            catch (Exception ms)
            {
                MessageBox.Show("erreur" + ms);
            }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //calculpourcentage();
            //calculdepenses();

        }
        private void listechauffeur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void simpleButton28_Click_1(object sender, EventArgs e)
        {

        }
        private void simpleButton27_Click_1(object sender, EventArgs e)
        {

        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void simpleButton29_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton30_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PAGE_ACCUEIL_Shown(object sender, EventArgs e)
        {
            LireTaux();
            testdate();
            // Méthode pour calculer la sommation du bénéfice du jour et du mois
            sommegenemoi();
            SOMMEBENEJOUR();

            // Méthode pour calculer la sommation de vente du jour et du mois
            sommeventejour();
            totalgeneralmoi();
            totalventescredits();

            // Méthode pour calculer le dépenses du jour et du mois
            methodedepensesdumoi();
            methodedepensesjour();

            // Méthode pour afficher les dépenses automaiquement dans le datagride
            conn.communication();
            conn.da = new SqlDataAdapter("SELECT * FROM [dbo].[Depense_prod] where Officine='" + lblsiteuser.Text + "'", conn.con);
            conn.dt = new DataTable();
            conn.da.Fill(conn.dt);
            listedepenses.DataSource = conn.dt;
            conn.con.Close();

            // Méthode pour afficher les produit vendu par mois en cours
            converssionbjr();
            converssionbmoi();
            converssionejour();
            converssionemoi();
            converssionbejour();
            converssiodepmoi();
        }
        // Convertion de total à payer de franc en dollars
        void converssiototalpayer()
        {
            try
            {
                if (lbltotpayer.Text == "")
                {
                    lbltotpayer.Text = "0";
                }
                if (label98.Text == "")
                {
                    label98.Text = "0";
                }
                if (label59.Text == "")
                {
                    label59.Text = "0";
                }
                else
                {
                    double k, l, m;
                    k = Convert.ToDouble(lbltotpayer.Text);
                    l = Convert.ToDouble(label59.Text);
                    m = k / l;
                    lbltotalpayeusd.Text = Convert.ToString(m);
                }
            }
            catch (Exception echo)
            {
                //MessageBox.Show("Impossible de vider le Stock de cet article !"+echo);
            }   
        }
        // Convertion de total à retourner de franc en dollars
        void converssiototalretourner()
        {
            if (labelfrancretour.Text == "")
            {
                labelfrancretour.Text = "0";
            }
            if (label98.Text == "")
            {
                label98.Text = "0";
            }
            if (label59.Text == "")
            {
                label59.Text = "0";
            }
            else
            {
                double s, l, m;
                s = Convert.ToDouble(labelfrancretour.Text);
                l = Convert.ToDouble(label59.Text);
                m = s / l;
                labelretourdollar.Text = Convert.ToString(m);
            }
        }
        // Calcul pour la converssion en dollars
        void converssionbjr()
        {
            if (text1.Text == "")
            {
                text1.Text = "0";
            }
            if (label98.Text == "")
            {
                label98.Text = "0";
            }
            if (label59.Text == "")
            {
                label59.Text = "0";
            }
            else
            {
                double k, l, m;
                k = Convert.ToDouble(text1.Text);
                l = Convert.ToDouble(label59.Text);
                m = k / l;
                label98.Text = Convert.ToString(m);
            }
        }
        void converssionbmoi()
        {

            if (text2.Text == "")
            {
                text2.Text = "0";
            }
            if (label99.Text == "")
            {
                label99.Text = "0";
            }
            if (label59.Text == "")
            {
                label59.Text = "0";
            }
            else
            {
                double k, l, m;
                k = Convert.ToDouble(text2.Text);
                l = Convert.ToDouble(label59.Text);
                m = k / l;
                label99.Text = Convert.ToString(m);
            }
        }
        void converssionejour()
        {
            if (text3.Text == "")
            {
                text3.Text = "0";
            }
            if (label100.Text == "")
            {
                label100.Text = "0";
            }
            else
            {
                double k, l, m;
                k = Convert.ToDouble(text3.Text);
                l = Convert.ToDouble(label59.Text);
                m = k / l;
                label100.Text = Convert.ToString(m);
            }
        }
        void converssionemoi()
        {
            if (text4.Text == "")
            {
                text4.Text = "0";
            }
            if (label107.Text == "")
            {
                label107.Text = "0";
            }
            else
            {
                double k, l, m;
                k = Convert.ToDouble(text4.Text);
                l = Convert.ToDouble(label59.Text);
                m = k / l;
                label107.Text = Convert.ToString(m);
            }
        }
        void converssionbejour()
        {
            if (text5.Text == "")
            {
                text5.Text = "0";
            }
            if (label108.Text == "")
            {
                label108.Text = "0";
            }
            else
            {
                double k, l, m;
                k = Convert.ToDouble(text5.Text);
                l = Convert.ToDouble(label59.Text);
                m = k / l;
                label108.Text = Convert.ToString(m);
            }
        }
        void converssiodepmoi()
        {
            if (text6.Text == "")
            {
                text6.Text = "0";
            }
            if (label109.Text == "")
            {
                label109.Text = "0";
            }
            else
            {
                double k, l, m;
                k = Convert.ToDouble(text6.Text);
                l = Convert.ToDouble(label59.Text);
                m = k / l;
                label109.Text = Convert.ToString(m);
            }
        }
        // Convertion de fond de l'approvisionnement de franc en dollars
        public void convertssionfondapprovisionnement()
        {
            if (txtshowfondapprov.Text == "")
            {
                txtshowfondapprov.Text = "0";
            }
            if (label59.Text == "")
            {
                label59.Text = "0";
            }
            else
            {
                double manga, pondu, david;
                manga = Convert.ToDouble(txtshowfondapprov.Text);
                pondu = Convert.ToDouble(label59.Text);
                david = manga / pondu;
                txtfondenusd.Text = Convert.ToString(david);
            }
        }
        void testdate()
        {
            string dateCompte;
            dateCompte = DateTime.Today.ToString("MM");
            if (dateCompte == "01")
            {
                labMoisOperation.Text = "JANVIER";
            }
            else if (dateCompte == "02")
            {
                labMoisOperation.Text = "FEVRIER";
            }
            else if (dateCompte == "03")
            {
                labMoisOperation.Text = "MARS";
            }
            else if (dateCompte == "04")
            {
                labMoisOperation.Text = "AVRIL";
            }
            else if (dateCompte == "05")
            {
                labMoisOperation.Text = "MAI";
            }
            else if (dateCompte == "06")
            {
                labMoisOperation.Text = "JUIN";
            }
            else if (dateCompte == "07")
            {
                labMoisOperation.Text = "JUILLET";
            }
            else if (dateCompte == "08")
            {
                labMoisOperation.Text = "AOUT";
            }
            else if (dateCompte == "09")
            {
                labMoisOperation.Text = "SEPTEMBRE";
            }
            else if (dateCompte == "10")
            {
                labMoisOperation.Text = "OCTOBRE";
            }
            else if (dateCompte == "11")
            {
                labMoisOperation.Text = "NOVEMBRE";

            }
            else if (dateCompte == "12")
            {
                labMoisOperation.Text = "DECEMBRE";
            }
        }
        private void txtbenef_TextChanged(object sender, EventArgs e)
        {

        }
        void selectlistepr()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select [Num_prod],[PA],[PV]FROM [dbo].[Liste_produit] where Nom_prod ='" + richprod.Text + "'";
            conn.dr2 = conn.cmd.ExecuteReader();
            if (conn.dr2.HasRows)
            {
                if (conn.dr2.Read())
                {
                    txtnumlotaprov.Text = conn.dr2["Num_prod"].ToString();
                    txtpa.Text = conn.dr2["PA"].ToString();
                }
            }
        }
        private void richprod_TextChanged(object sender, EventArgs e)
        {
            if (richprod.Text == "")
            {
                richprod.Focus();
                listproduits.Visible = false;
            }
            else
            {
                MethodeInformArticleApprovisionner();
                MethodeAfficheListeBoxApprovisionnement();
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtrecuppa_TextChanged(object sender, EventArgs e)
        {

        }
        private void panelControl6_Paint(object sender, PaintEventArgs e)
        {

        }
        void approvisionnerproduit()
        {
            try
            {
                if (textnomartapprv.Text == "" && textqreajout.Text=="")
                {
                    MessageBox.Show("Veuillez d'abord chercher le nom et la quantité en stock de cet article");
                }
                else
                {
                    if (textnomartapprv.Text.Length != 0)
                    {
                        // déclaration des variables de types réel
                        double quantajout, stockQte, QteAugmentat;
                        stockQte = 0;
                        quantajout = Convert.ToDouble(textqreajout.Text);
                        //connection pour sélectionner la quantité qui se trouve dans la base de données
                        conn.communication();
                        conn.cmd3 = new System.Data.SqlClient.SqlCommand();
                        conn.cmd3.Connection = conn.con;
                        conn.cmd3.CommandType = CommandType.Text;
                        conn.cmd3.CommandText = "select Qte_sotock from [dbo].[Approvisionnements] where Nom_prod='" + Regex.Replace(textnomartapprv.Text, "'", "''") + "'and Officine='" + lblsiteuser.Text + "'";
                        conn.dr = conn.cmd3.ExecuteReader();
                        while (conn.dr.Read())
                        {
                            stockQte = Convert.ToDouble(conn.dr["Qte_sotock"]);
                        }
                        conn.dr.Close();
                        QteAugmentat = stockQte + quantajout;
                        // modification de quantité qui se trouve dans l'aaprovisionnement
                        conn.cmd = new System.Data.SqlClient.SqlCommand();
                        conn.cmd.Connection = conn.con;
                        conn.cmd.CommandType = CommandType.Text;
                        echo = MessageBox.Show("Voulez-vous ajouter la quantité de cet article chez "+lblsiteuser.Text+"?", "GS-COMMERCIALE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (echo == DialogResult.Yes)
                        {
                            //conn.communication();
                            conn.cmd.CommandText = "update Approvisionnements set Qte_sotock='" + QteAugmentat + "', [Num_lot]='" + textnumlotaqte.Text + "',[Nom_prod]='" + Regex.Replace(txtarticlemodif.Text, "'", "''") + "',[Famille]='" + Regex.Replace(cmbfamillemodif.Text, "'", "''") + "',[Rayon]='" + txtraoyonmodif.Text + "',[Unites]='" + Regex.Replace(txtunitventemodif.Text, "'", "''") + "',[Date_exp]='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "',[PA]='" + Regex.Replace(txtprixventemodif.Text, "'", "''") + "' where ID='" + labeldeleteDapprov.Text + "'and Officine='" + lblsiteuser.Text + "'";
                            conn.cmd.ExecuteNonQuery();
                            MessageBox.Show("La mise a jours " + textnomartapprv.Text + " est effectuée chez "+lblsiteuser.Text+"");
                            textqreajout.Clear();
                        }
                        conn.dr.Close();
                    }
                }
            }
            catch (Exception run)
            {
                MessageBox.Show(run.Message.ToString());
            }  
        }
        private void simpleButton31_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton32_Click(object sender, EventArgs e)
        {

        }
        private void txtbenjour_TextChanged(object sender, EventArgs e)
        {

        }
        private void PAGE_ACCUEIL_Load(object sender, EventArgs e)
        {
           
            //Méthode pour afficher le total de produit enregistrer 
            totalprodenregistrer();
            totalartapprov();
            totalartavendujour();
            // Méthode pour séléctionner le produit qui est inférieure à 3
            conn.communication();
            conn.da = new SqlDataAdapter("SELECT Nom_prod, Qte_sotock, PA, Date_enre FROM [dbo].[Approvisionnements] where Qte_sotock <= 3 and Officine='" + lblsiteuser.Text + "'", conn.con);
            conn.dt1 = new DataTable();
            conn.da.Fill(conn.dt1);
            listeaaprov.DataSource = conn.dt1;
            conn.con.Close();

            //Méthode pour afficher la quantité de stock approvisionner
            conn.communication();
            conn.da1 = new SqlDataAdapter("select [Nom_prod],[StockEntre],[Date_enre] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Officine='" + lblsiteuser.Text + "' ", conn.con);
            conn.dt1 = new DataTable();
            conn.ds1 = new DataSet();
            conn.da1.Fill(conn.ds1, scr_david, 25, "Approvisionnements");
            datastockentree.DataSource = conn.ds1.Tables[0];
            conn.con.Close();
            nbrsartiparpagestock.Text = datastockentree.Rows.Count.ToString();    
        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtdepensesmoi_TextChanged(object sender, EventArgs e)
        {
            calculetotalgeneraldepenses();
        }
        void methodedepense()
        {
            if (montantdepense.Text == "" && richmotif.Text == "" && txtnomv.Text == "")
            {
                MessageBox.Show("Veuillez d'abord remplire tout les champs");
                montantdepense.Focus();
            }
            else
            {
                if (montantdepense.Text.Length != 0 || richmotif.Text.Length != 0)
                {
                    // déclaration des variables de types réel
                    double quantadepense, stockQte, Qtediminue;
                    stockQte = 0;
                    quantadepense = Convert.ToDouble(montantdepense.Text);
                    //connection pour sélectionner la quantité qui se trouve dans la base de donnée

                    conn.communication();
                    conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                    conn.cmd2.Connection = conn.con;
                    conn.cmd2.CommandType = CommandType.Text;
                    //conn.cmd2.CommandText = "select sum(Benefice)Benefice from [dbo].[T_benefice] where Mois='" + labMoisOperation.Text + "'";
                    conn.cmd2.CommandText = "select Benefice from [dbo].[T_benefice] where Officine='" + lblsiteuser.Text + "'";
                    conn.dr2 = conn.cmd2.ExecuteReader();
                    while (conn.dr2.Read())
                    {
                        stockQte = Convert.ToDouble(conn.dr2["Benefice"]);
                    }
                    conn.dr2.Close();
                    Qtediminue = stockQte - quantadepense;
                    // Contrôle du montan qui se trouve dans la base de données 
                    if (quantadepense > stockQte)
                    {
                        MessageBox.Show("Désolé, le montant demander chef "+lblsiteuser.Text+" est supérieur au bénéfice");
                        montantdepense.Focus();
                    }
                    else if (stockQte == 0)
                    {
                        MessageBox.Show("Le bénéfice est vide");
                        montantdepense.Focus();
                    }
                    else if (quantadepense == stockQte)
                    {
                        MessageBox.Show("voulez-vous épuiser le bénéfice chez "+lblsiteuser.Text+"?");
                    }
                    else
                    {
                        // modification de la quantité (engagé la dépense) 
                        conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                        conn.cmd1.Connection = conn.con;
                        conn.cmd1.CommandType = CommandType.Text;
                        echo = MessageBox.Show("Voulez-vous vraiment engager la dépense?", "GS-COMMERCIALE",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (echo == DialogResult.Yes)
                        {
                            conn.communication();
                            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                            conn.cmd2.Connection = conn.con;
                            conn.cmd2.CommandType = CommandType.Text;
                            conn.cmd2.CommandText = "insert into Depense_prod values('" + Regex.Replace(montantdepense.Text, "'", "''") + "', '" + Regex.Replace(richmotif.Text, "'", "''") + "','" + Regex.Replace(DateTime.Now.ToString("yyyy-MM-dd"), "'", "''") + "' ,'" + Regex.Replace(txtnomv.Text, "'", "''") + "','" + labMoisOperation.Text + "','"+lblsiteuser.Text+"')";
                            conn.cmd2.ExecuteNonQuery();
                            montantdepense.Clear();
                            richmotif.Clear();
                        }
                        else if (echo == DialogResult.No)
                        {
                            MessageBox.Show("Vous avez préféré de rester sur l'application");
                        }
                    }
                }
            }
        }
        // Méthode pour appliqueé la TVA à la facture 
        void CalculTVA()
        {
            //double t, v, tva;
            //t = Convert.ToDouble(lbltotpayer.Text);
            //if (lbltotpayer.Text == "")
            //{
            //    lbltotpayer.Text = "0";
            //}
            //if (texaffitoto.Text == "")
            //{
            //    texaffitoto.Text = "0";
            //}
            //v = Convert.ToDouble(txtTVA.Text);
            //tva = t * v / 100;
            //lbltotpayer.Text = Convert.ToString(tva);
        }
        private void simpleButton33_Click(object sender, EventArgs e)
        {
            methodedepense();
            listedepenses.Refresh();
            txtdepensesmoi.Refresh();
        }
        void sommegeneralbenefice()
        {
            conn.communication();
            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
            conn.cmd2.Connection = conn.con;
            conn.cmd2.CommandType = CommandType.Text;
            conn.cmd2.CommandText = "select sum (Benefice) Benefice FROM [dbo].[T_benefice] where Dateope between '" + datedu.Value + "' and '" + dateau.Value + "'and Officine='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd2.ExecuteReader();
            if (conn.dr2.HasRows)
            {
                if (conn.dr2.Read())
                {
                    totalgeneben.Text = conn.dr2["Benefice"].ToString();
                }
                conn.dr2.Close();
            }
        }
        private void listecaisseapprov_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        void calculetotalgeneraldepenses()
        {
            //double a, b, c;
            //a = Convert.ToDouble(totbemoi.Text);

            //if (txtdepensesmoi.Text == "")
            //{
            //    txtdepensesmoi.Text = "0";
            //}
            //if (totbemoi.Text == "")
            //{
            //    totbemoi.Text = "0";
            //}
            //b = Convert.ToDouble(txtdepensesmoi.Text);
            //c = a - b;
            //txtsommedep.Text = Convert.ToString(c);
            
            //double y, z;
            //y = Convert.ToDouble(txttotalgenmoi.Text);
            //z = a + y;
            //totgenefonds.Text = Convert.ToString(z);
        }
        private void totalgeneben_TextChanged(object sender, EventArgs e)
        {
            sommegeneralbenefice();
        }
        private void txtsommedep_TextChanged(object sender, EventArgs e)
        {

        }
        void sommefondsplusbenefice()
        {

        }
        private void txttotalgenmoi_TextChanged(object sender, EventArgs e)
        {
            sommefondsplusbenefice();
        }
        private void totalgeneben_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void listedepenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void simpleButton34_Click(object sender, EventArgs e)
        {

        }
        private void dateau_ValueChanged(object sender, EventArgs e)
        {
            sommegeneralbenefice();
        }
        private void label71_Click(object sender, EventArgs e)
        {

        }       
        void sommegeneralentrevente()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select sum (Prix_total) Prix_total FROM [dbo].[Ventes] where Date_vendu between '" + dateTimedu.Value + "' and '" + dateTimeau.Value + "'and Officine='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd.ExecuteReader();
            if (conn.dr2.HasRows)
            {
                if (conn.dr2.Read())
                {

                    totgenecapital.Text = conn.dr2["Prix_total"].ToString();
                }
                conn.dr2.Close();
            }
        }
        private void dateTimeau_ValueChanged(object sender, EventArgs e)
        {
            sommegeneralentrevente();
        }
        private void txtbenjour_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void prod_TextChanged(object sender, EventArgs e)
        {

        }
        private void label50_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.listeproduits.Rows[e.RowIndex];
                prod.Text = row.Cells["NOM_PROD"].Value.ToString();
                txtunitesarticle.Text = row.Cells["UNITES"].Value.ToString();
                cmbcat.Text = row.Cells["CATEGORIE"].Value.ToString();
                lblrecupenomart.Text = row.Cells["NOM_PROD"].Value.ToString();
            }
        }
        private void simpleButton11_Click(object sender, EventArgs e)
        {

        }
        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {
        }
        private void groupBox36_Enter(object sender, EventArgs e)
        {

        }
        private void txttotdepvoit_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtjoutverssement_TextChanged(object sender, EventArgs e)
        {
        }
        private void Listevente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void chart1_Click(object sender, EventArgs e)
        {
        }
        private void totbemoi_TextChanged(object sender, EventArgs e)
        {
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }
        private void txtsommegeneral_TextChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
        }
        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
        }
        private void Listeapprovisionnement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void Rowscolor()
        {
            for (int i = 0; i < Listeapprovisionnement.Rows.Count; i++)
            {
                int val = int.Parse(Listeapprovisionnement.Rows[i].Cells[2].Value.ToString());
                if (val < 3)
                {
                    Listeapprovisionnement.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                }
                else if (val >= 2 && val < 4)
                {
                    Listeapprovisionnement.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                }
                else if (val >= 16 && val < 22)
                {
                    Listeapprovisionnement.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (val > 8 && val < 16)
                {
                    Listeapprovisionnement.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                }
                else
                {
                    Listeapprovisionnement.Rows[i].DefaultCellStyle.BackColor = Color.Wheat;
                }
            }
        }
        void Rowscolorexpirearticle()
        {
            for (int c = 0; c < dataGridpreremption.Rows.Count; c++)
            {
                int vall = int.Parse(dataGridpreremption.Rows[c].Cells[6].Value.ToString());
                if (vall >= 124)
                {
                    dataGridpreremption.Rows[c].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (vall <= 63 && vall > 64 )
                {
                    dataGridpreremption.Rows[c].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (vall < 33 &&  vall > 5)
                {
                    dataGridpreremption.Rows[c].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (vall < 0 && vall < -0)
                {
                    dataGridpreremption.Rows[c].DefaultCellStyle.BackColor = Color.Violet;
                }
                else
                {
                    dataGridpreremption.Rows[c].DefaultCellStyle.BackColor = Color.Wheat;
                }
            }
        }
        private void PAGE_ACCUEIL_TextChanged(object sender, EventArgs e)
        {
            methodedepense();
        }

        private void Listevente_Click(object sender, EventArgs e)
        {

        }
        private void Listevente_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }
        private void Listevente_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void Listeventejour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void text1_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtpa_Click(object sender, EventArgs e)
        {
            txtpa.Clear();
        }
        private void txtpv_Click(object sender, EventArgs e)
        {
        }
        private void txtqtesto_Click(object sender, EventArgs e)
        {
            txtqtesto.Clear();
        }
        private void ajouteqtstokapprov_Click(object sender, EventArgs e)
        {

        }
        private void txtprixv_Click(object sender, EventArgs e)
        {
            //txtprixv.Clear();
        }
        private void txtqteve_Click(object sender, EventArgs e)
        {
            if (txtqteve.Text == "")
            {
                txtqteve.Clear();
                txtqteve.Text = " ";
            }
        }
        private void pa_Click(object sender, EventArgs e)
        {
        }
        private void pv_Click(object sender, EventArgs e)
        {
        }
        private void txtjoutverssement_Click(object sender, EventArgs e)
        {

        }
        private void txtdepensesverssement_Click(object sender, EventArgs e)
        {

        }
        private void qtestoc_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton8_Click_1(object sender, EventArgs e)
        {

        }
        private void txtajout_Click(object sender, EventArgs e)
        {

        }
        // Calcule reste client de dollars en franc
        void calculerresteclientusd()
        {
            double l, m, mupiku;
            if (lbltotalpayeusd.Text == "")
            {
                lbltotalpayeusd.Text = "0";
            }
            if (richTexmontantpercuusd.Text == "")
            {
                richTexmontantpercuusd.Text = "0";
            }
            else
            {
                l = Convert.ToDouble(lbltotalpayeusd.Text);
                m = Convert.ToDouble(richTexmontantpercuusd.Text);
                mupiku = m - l;
                labelretourdollar.Text = Convert.ToString(mupiku);
            }
        }
        void calculerresteclient()
        {
            double l, m, mupiku;
            if (lbltotpayer.Text == "")
            {
                lbltotpayer.Text = "0";
            }
            if (richTexmontantpercu.Text == "")
            {
                richTexmontantpercu.Text = "0";
            }
            else
            {
                l = Convert.ToDouble(lbltotpayer.Text);
                m = Convert.ToDouble(richTexmontantpercu.Text);
                mupiku = l - m;
                labelfrancretour.Text = Convert.ToString(mupiku);
            }
        }
        void methodeajoutpanier()
        {
            if (txtqteve.Text == "0")
            {
                MessageBox.Show("Inserer la quantité de Vente");
                txtqteve.Focus();
            }
            else if (txtprixv.Text == "0")
            {
                MessageBox.Show("Le prix de vente est Vide");
            }
            else if (labelreststock.Text == "0")
            {
                MessageBox.Show("Impossible d'ajouter cet Article dans le panier");
                txtqteve.Focus();
            }
            else
            {
                initialDataGrid();
                Ajoutelistepanier(richnomprod.Text, txtprixv.Text, txtqteve.Text, DateTime.Today.ToString("yyyy-MM-dd"), txttot.Text, txtnomvende.Text, labMoisOperation.Text, DateTime.Today.ToString("HH:mm:ss"), labelrecupnumber.Text, comboclient.Text, lblsiteuser.Text, cmblibelle.Text);
                //                [Nom_prod],        [PV],         [Qte_vendue],      [Date_vendu],                       [Prix_total], [Nom_vendeur],                                                                                      [Patient],        [Sites]           [Libelle]
                SommeVente();
            } 
        }
        private void simpleButton18_Click_1(object sender, EventArgs e)
        {
            vendreprod();
            methodeajoutpanier();
            converssiototalpayer();
            simpleButton10.Enabled = true;
            simpleButton4.Enabled = true;
            //txtqteve.Enabled = false;
            annulervente();
        }
        // Méthode pour enregistrer la vente libre
        void Engesitrerdatagrid()
        {
            conn.communication();
            conn.cmd3 = new System.Data.SqlClient.SqlCommand();
            conn.cmd3.Connection = conn.con;
            conn.cmd3.CommandType = CommandType.Text;
            int nbreligne1 = Paniervente.RowCount;
            for (int j = 0; j < nbreligne1; j++)
            {
                //conn.cmd3.CommandText = "INSERT INTO [GS_ALIMENT].[dbo].[Ventes] values ('" + Paniervente.Rows[j].Cells[0].Value + "','" + Paniervente.Rows[j].Cells[1].Value + "','" + Paniervente.Rows[j].Cells[2].Value + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + Paniervente.Rows[j].Cells[4].Value + "','" + Paniervente.Rows[j].Cells[5].Value + "', '" + labMoisOperation.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + labelrecupnumber.Text + "','" + Paniervente.Rows[j].Cells[9].Value + "','" + Paniervente.Rows[j].Cells[10].Value + "','" + Paniervente.Rows[j].Cells[11].Value + "')";
                conn.cmd3 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[Ventes] values (@Nom_prod,@PV,@Qte_vendue,@Date_vendu,@Prix_total,@Nom_vendeur,@Mois,@Heur,@NumFacture,@Patient,@Sites,@Libelle)", conn.con);                                                                                                                                                                                                                                                                                                                                                                                                                                                                   //[Emploi_2],[Num],[Av],[Quartier],[Commune]
                conn.cmd3.Parameters.AddWithValue("@Nom_prod", Paniervente.Rows[j].Cells[0].Value);
                conn.cmd3.Parameters.AddWithValue("@PV", float.Parse(Paniervente.Rows[j].Cells[1].Value.ToString()));
                conn.cmd3.Parameters.AddWithValue("@Qte_vendue", Paniervente.Rows[j].Cells[2].Value);
                conn.cmd3.Parameters.AddWithValue("@Date_vendu", DateTime.Now.ToString("yyyy-MM-dd"));
                conn.cmd3.Parameters.AddWithValue("@Prix_total", float.Parse(Paniervente.Rows[j].Cells[4].Value.ToString()));
                conn.cmd3.Parameters.AddWithValue("@Nom_vendeur", Paniervente.Rows[j].Cells[5].Value);
                conn.cmd3.Parameters.AddWithValue("@Mois", labMoisOperation.Text);
                conn.cmd3.Parameters.AddWithValue("@Heur", DateTime.Now.ToString("HH:mm:ss"));
                conn.cmd3.Parameters.AddWithValue("@NumFacture", labelrecupnumber.Text);
                conn.cmd3.Parameters.AddWithValue("@Patient", Paniervente.Rows[j].Cells[9].Value);
                conn.cmd3.Parameters.AddWithValue("@Sites", Paniervente.Rows[j].Cells[10].Value);
                conn.cmd3.Parameters.AddWithValue("@Libelle", Paniervente.Rows[j].Cells[11].Value);
                conn.cmd3.ExecuteNonQuery();
            }

            // Méthode pour inserer les données qui setrouve dans le datagride vers Bdd
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            int nbreligne2 = Paniervente.RowCount;
            for (int j = 0; j < nbreligne2; j++)
            {
                //conn.cmd.CommandText = "INSERT INTO [dbo].[Factures] values ('" + Paniervente.Rows[j].Cells[0].Value + "','" + Paniervente.Rows[j].Cells[1].Value + "','" + Paniervente.Rows[j].Cells[2].Value + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + Paniervente.Rows[j].Cells[4].Value + "','" + Paniervente.Rows[j].Cells[5].Value + "','" + lbltotpayer.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + labelrecupnumber.Text + "','" + Paniervente.Rows[j].Cells[9].Value + "','" + Paniervente.Rows[j].Cells[10].Value + "','" + Paniervente.Rows[j].Cells[11].Value + "')";
                conn.cmd = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[Factures] values (@Nom_prod,@PV,@Qte_vendue,@Date_vendu,@Prix_total,@Nom_vendeur,@SommesV,@Heur,@NumFacture,@Patient,@Sites,@Libelle)", conn.con); 
                conn.cmd.Parameters.AddWithValue("@Nom_prod", Paniervente.Rows[j].Cells[0].Value);
                conn.cmd.Parameters.AddWithValue("@PV", float.Parse(Paniervente.Rows[j].Cells[1].Value.ToString()));
                conn.cmd.Parameters.AddWithValue("@Qte_vendue", Paniervente.Rows[j].Cells[2].Value);
                conn.cmd.Parameters.AddWithValue("@Date_vendu", DateTime.Now.ToString("yyyy-MM-dd"));
                conn.cmd.Parameters.AddWithValue("@Prix_total", float.Parse(Paniervente.Rows[j].Cells[4].Value.ToString()));
                conn.cmd.Parameters.AddWithValue("@Nom_vendeur", Paniervente.Rows[j].Cells[5].Value);
                conn.cmd.Parameters.AddWithValue("@SommesV", float.Parse(lbltotpayer.Text));
                conn.cmd.Parameters.AddWithValue("@Heur", DateTime.Now.ToString("HH:mm:ss"));
                conn.cmd.Parameters.AddWithValue("@NumFacture", labelrecupnumber.Text);
                conn.cmd.Parameters.AddWithValue("@Patient", Paniervente.Rows[j].Cells[9].Value);
                conn.cmd.Parameters.AddWithValue("@Sites", Paniervente.Rows[j].Cells[10].Value);
                conn.cmd.Parameters.AddWithValue("@Libelle", Paniervente.Rows[j].Cells[11].Value); 
                conn.cmd.ExecuteNonQuery();
            }
            // Méthode pour inserer les données qui setrouve dans le datagride vers table rapport journalier
            conn.communication();
            conn.cmd3 = new System.Data.SqlClient.SqlCommand();
            conn.cmd3.Connection = conn.con;
            conn.cmd3.CommandType = CommandType.Text;
            int nbreligne3 = Paniervente.RowCount;
            for (int j = 0; j < nbreligne3; j++)
            {
                //conn.cmd3.CommandText = "INSERT INTO [dbo].[Rapportjour] values ('" + Paniervente.Rows[j].Cells[0].Value + "','" + Paniervente.Rows[j].Cells[1].Value + "','" + Paniervente.Rows[j].Cells[2].Value + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + Paniervente.Rows[j].Cells[4].Value + "','" + Paniervente.Rows[j].Cells[5].Value + "','" + lbltotpayer.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + labelrecupnumber.Text + "','" + Paniervente.Rows[j].Cells[9].Value + "', '" + Paniervente.Rows[j].Cells[10].Value + "', '" + Paniervente.Rows[j].Cells[11].Value + "')";
                conn.cmd3 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[Rapportjour] values (@Nom_prod,@PV,@Qte_vendue,@Date_vendu,@Prix_total,@Nom_vendeur,@SommesV,@Heur,@NumFacture,@Patient,@Sites,@Libelle)", conn.con);
                conn.cmd3.Parameters.AddWithValue("@Nom_prod", Paniervente.Rows[j].Cells[0].Value);
                conn.cmd3.Parameters.AddWithValue("@PV", float.Parse(Paniervente.Rows[j].Cells[1].Value.ToString()));
                conn.cmd3.Parameters.AddWithValue("@Qte_vendue", Paniervente.Rows[j].Cells[2].Value);
                conn.cmd3.Parameters.AddWithValue("@Date_vendu", DateTime.Now.ToString("yyyy-MM-dd"));
                conn.cmd3.Parameters.AddWithValue("@Prix_total", float.Parse(Paniervente.Rows[j].Cells[4].Value.ToString()));
                conn.cmd3.Parameters.AddWithValue("@Nom_vendeur", Paniervente.Rows[j].Cells[5].Value);
                conn.cmd3.Parameters.AddWithValue("@SommesV", float.Parse(lbltotpayer.Text));
                conn.cmd3.Parameters.AddWithValue("@Heur", DateTime.Now.ToString("HH:mm:ss"));
                conn.cmd3.Parameters.AddWithValue("@NumFacture", labelrecupnumber.Text);
                conn.cmd3.Parameters.AddWithValue("@Patient", Paniervente.Rows[j].Cells[9].Value);
                conn.cmd3.Parameters.AddWithValue("@Sites", Paniervente.Rows[j].Cells[10].Value);
                conn.cmd3.Parameters.AddWithValue("@Libelle", Paniervente.Rows[j].Cells[11].Value);
                conn.cmd3.ExecuteNonQuery();
            }
            // Méthode pour enregistrer la vente du jour pour bien admistrerla bdd
            conn.communication();
            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
            conn.cmd2.Connection = conn.con;
            conn.cmd2.CommandType = CommandType.Text;
            int nbreligne = Paniervente.RowCount;
            for (int b = 0; b < nbreligne; b++)
            {
                //conn.cmd2.CommandText = "INSERT INTO [dbo].[T_VJour] values  ('" + Paniervente.Rows[i].Cells[0].Value + "','" + Paniervente.Rows[i].Cells[1].Value + "','" + Paniervente.Rows[i].Cells[2].Value + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + Paniervente.Rows[i].Cells[4].Value + "','" + Paniervente.Rows[i].Cells[5].Value + "', '" + labMoisOperation.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + labelrecupnumber.Text + "','" + Paniervente.Rows[i].Cells[9].Value + "','" + Paniervente.Rows[i].Cells[10].Value + "')";
                conn.cmd2 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[T_VJour] values (@Nom_prod,@PV,@Qte_vendue,@Date_vendu,@Prix_total,@Nom_vendeur,@Mois,@Heur,@NumFacture,@Patient,@Sites,@Libelle)", conn.con);              
                conn.cmd2.Parameters.AddWithValue("@Nom_prod", Paniervente.Rows[b].Cells[0].Value);
                conn.cmd2.Parameters.AddWithValue("@PV", float.Parse(Paniervente.Rows[b].Cells[1].Value.ToString()));
                conn.cmd2.Parameters.AddWithValue("@Qte_vendue", Paniervente.Rows[b].Cells[2].Value);
                conn.cmd2.Parameters.AddWithValue("@Date_vendu", DateTime.Now.ToString("yyyy-MM-dd"));
                conn.cmd2.Parameters.AddWithValue("@Prix_total", float.Parse(Paniervente.Rows[b].Cells[4].Value.ToString()));
                conn.cmd2.Parameters.AddWithValue("@Nom_vendeur", Paniervente.Rows[b].Cells[5].Value);
                conn.cmd2.Parameters.AddWithValue("@Mois", labMoisOperation.Text);
                conn.cmd2.Parameters.AddWithValue("@Heur", DateTime.Now.ToString("HH:mm:ss"));
                conn.cmd2.Parameters.AddWithValue("@NumFacture", labelrecupnumber.Text);
                conn.cmd2.Parameters.AddWithValue("@Patient", Paniervente.Rows[b].Cells[9].Value);
                conn.cmd2.Parameters.AddWithValue("@Sites", Paniervente.Rows[b].Cells[10].Value);
                conn.cmd2.Parameters.AddWithValue("@Libelle", Paniervente.Rows[b].Cells[11].Value);  
                conn.cmd2.ExecuteNonQuery();
            }
            // Méthode pour enregistrer la vente du moi pour bien admistrerla bdd
            conn.communication();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            int nbrelign = Paniervente.RowCount;
            for (int z = 0; z < nbrelign; z++)
            {
                //conn.cmd3.CommandText = "INSERT INTO [dbo].[T_VMois] values  ('" + Paniervente.Rows[i].Cells[0].Value + "','" + Paniervente.Rows[i].Cells[1].Value + "','" + Paniervente.Rows[i].Cells[2].Value + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Paniervente.Rows[i].Cells[4].Value + "','" + Paniervente.Rows[i].Cells[5].Value + "', '" + labMoisOperation.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + labelrecupnumber.Text + "','" + Paniervente.Rows[i].Cells[9].Value + "','" + Paniervente.Rows[i].Cells[10].Value + "')";
                conn.cmd1 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[T_VMois] values (@Nom_prod,@PV,@Qte_vendue,@Date_vendu,@Prix_total,@Nom_vendeur,@Mois,@Heur,@NumFacture,@Patient,@Sites,@Libelle)", conn.con);                                                                                                                                                                                                                                                                                                                                                                                                                                                                   //[Emploi_2],[Num],[Av],[Quartier],[Commune]
                conn.cmd1.Parameters.AddWithValue("@Nom_prod", Paniervente.Rows[z].Cells[0].Value);
                conn.cmd1.Parameters.AddWithValue("@PV", float.Parse(Paniervente.Rows[z].Cells[1].Value.ToString()));
                conn.cmd1.Parameters.AddWithValue("@Qte_vendue", Paniervente.Rows[z].Cells[2].Value);
                conn.cmd1.Parameters.AddWithValue("@Date_vendu", DateTime.Now.ToString("yyyy-MM-dd"));
                conn.cmd1.Parameters.AddWithValue("@Prix_total", float.Parse(Paniervente.Rows[z].Cells[4].Value.ToString()));
                conn.cmd1.Parameters.AddWithValue("@Nom_vendeur", Paniervente.Rows[z].Cells[5].Value);
                conn.cmd1.Parameters.AddWithValue("@Mois", labMoisOperation.Text);
                conn.cmd1.Parameters.AddWithValue("@Heur", DateTime.Now.ToString("HH:mm:ss"));
                conn.cmd1.Parameters.AddWithValue("@NumFacture", labelrecupnumber.Text);
                conn.cmd1.Parameters.AddWithValue("@Patient", Paniervente.Rows[z].Cells[9].Value);
                conn.cmd1.Parameters.AddWithValue("@Sites", Paniervente.Rows[z].Cells[10].Value);
                conn.cmd1.Parameters.AddWithValue("@Libelle", Paniervente.Rows[z].Cells[11].Value); 
                conn.cmd1.ExecuteNonQuery();
            }
        }
        void Engesitrerdatagridventecredit()
        {
            try
            {
                conn.communication();
                conn.cmd4 = new System.Data.SqlClient.SqlCommand();
                conn.cmd4.Connection = conn.con;
                conn.cmd4.CommandType = CommandType.Text;
                int nbrelignee = Paniervente.RowCount;
                for (int n = 0; n < nbrelignee; n++)
                {
                    //conn.cmd.CommandText = "INSERT INTO [GS_ALIMENT].[dbo].[Vente_credit] values ('" + Paniervente.Rows[j].Cells[0].Value + "','" + Paniervente.Rows[j].Cells[1].Value + "','" + Paniervente.Rows[j].Cells[2].Value + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Paniervente.Rows[j].Cells[4].Value + "','" + Paniervente.Rows[j].Cells[5].Value + "', '" + labMoisOperation.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + labelrecupnumber.Text + "','" + Paniervente.Rows[j].Cells[9].Value + "','" + Paniervente.Rows[j].Cells[10].Value + "','" + Paniervente.Rows[j].Cells[11].Value + "')";
                    conn.cmd4 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[Vente_credit] values (@Nom_prod,@PV,@Qte_vendue,@Date_vendu,@Prix_total,@Nom_vendeur,@Mois,@Heur,@NumFacture,@Patient,@Sites,@Libelle)", conn.con);                                                                                                                                                                                                                                                                                                                                                                                                                                                                   //[Emploi_2],[Num],[Av],[Quartier],[Commune]
                    conn.cmd4.Parameters.AddWithValue("@Nom_prod", Paniervente.Rows[n].Cells[0].Value);
                    conn.cmd4.Parameters.AddWithValue("@PV", float.Parse(Paniervente.Rows[n].Cells[1].Value.ToString()));
                    conn.cmd4.Parameters.AddWithValue("@Qte_vendue", Paniervente.Rows[n].Cells[2].Value);
                    conn.cmd4.Parameters.AddWithValue("@Date_vendu", DateTime.Now.ToString("yyyy-MM-dd"));
                    conn.cmd4.Parameters.AddWithValue("@Prix_total", float.Parse(Paniervente.Rows[n].Cells[4].Value.ToString()));
                    conn.cmd4.Parameters.AddWithValue("@Nom_vendeur", Paniervente.Rows[n].Cells[5].Value);
                    conn.cmd4.Parameters.AddWithValue("@Mois", labMoisOperation.Text);
                    conn.cmd4.Parameters.AddWithValue("@Heur", DateTime.Now.ToString("HH:mm:ss"));
                    conn.cmd4.Parameters.AddWithValue("@NumFacture", labelrecupnumber.Text);
                    conn.cmd4.Parameters.AddWithValue("@Patient", Paniervente.Rows[n].Cells[9].Value);
                    conn.cmd4.Parameters.AddWithValue("@Sites", Paniervente.Rows[n].Cells[10].Value);
                    conn.cmd4.Parameters.AddWithValue("@Libelle", Paniervente.Rows[n].Cells[11].Value);
                    
                    if (conn.cmd4.ExecuteNonQuery() == 1)
                    {
                        //MessageBox.Show(" Vous venez de faire la vente à credit");
                    }
                    else
                    {
                        MessageBox.Show(" Crédit échoué");
                    }
                }
            }
            catch (Exception rec)
            {
                MessageBox.Show(rec.Message.ToString());
            }

        }
        void initialDataGrid()
        {
            Paniervente.ColumnCount = 12;
            Paniervente.Columns[0].Name = "Nom_prod";
            Paniervente.Columns[1].Name = "PV";
            Paniervente.Columns[2].Name = "Qte_vendue";
            Paniervente.Columns[3].Name = "Date_vendu";
            Paniervente.Columns[4].Name = "Prix_total";
            Paniervente.Columns[5].Name = "Nom_vendeur";
            Paniervente.Columns[6].Name = "Mois";
            Paniervente.Columns[7].Name = "Heur";
            Paniervente.Columns[8].Name = "NumFacture";
            Paniervente.Columns[9].Name = "Patient";
            Paniervente.Columns[10].Name = "Sites";
            Paniervente.Columns[11].Name = "Libelle";
        }
        void SommeVente()
        {
            try
            {
                int i;
                int nbreligne = Paniervente.RowCount;
                double prix = 0;
                for (i = 0; i < nbreligne; i++)
                {
                    prix += Convert.ToDouble(Paniervente.Rows[i].Cells[4].Value);
                }
                lbltotpayer.Text = Convert.ToString(prix);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        void SommeProformat()
        {
            try
            {
                int i;
                int nbreligne = dataGridpanierproforma.RowCount;
                double prix = 0;
                for (i = 0; i < nbreligne; i++)
                {
                    prix += Convert.ToDouble(dataGridpanierproforma.Rows[i].Cells[3].Value);
                }
                lbltotalproforma.Text = Convert.ToString(prix);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        private void Ajoutelistepanier(string a, string b, string c, string dat, string d, string e, string f, string g, string h, string i, string j, string k)
        {
            string[] row = { a, b, c, dat, d, e, f, g, h, i, j, k };
            Paniervente.Rows.Add(row);
        }
        void inserernumordre()
        {
           try
            {
                // Méthode pour inserer le numéro d'ordre dans la base de données
                conn.communication();
                conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                conn.cmd2.Connection = conn.con;
                conn.cmd2.CommandType = CommandType.Text;
                conn.cmd2.CommandText = "INSERT INTO [dbo].[NumOrdre] values ('" + lblsiteuser.Text+ "')";
                conn.cmd2.ExecuteNonQuery();
            }
            catch(Exception reco)
            {
                MessageBox.Show(reco.Message.ToString());
            }
        }
        // inserer le numéro uniqque dans le proforma
        void inserernumordreproforma()
        {
            try
            {
                // Méthode pour inserer le numéro d'ordre dans la base de données
                conn.communication();
                conn.cmd3 = new System.Data.SqlClient.SqlCommand();
                conn.cmd3.Connection = conn.con;
                conn.cmd3.CommandType = CommandType.Text;
                conn.cmd3.CommandText = "INSERT INTO [dbo].[NumProforma] values ('" + lblsiteuser.Text + "')";
                conn.cmd3.ExecuteNonQuery();
            }
            catch (Exception reco)
            {
                MessageBox.Show(reco.Message.ToString());
            }
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void Paniervente_Validated(object sender, EventArgs e)
        {
        }
        private void simpleButton14_Click(object sender, EventArgs e)
        {
            AppelListeProduit apl = new AppelListeProduit();
            apl.label3.Text = label48.Text;
            apl.label4.Text = label49.Text;
            apl.label5.Text = lblsiteuser.Text;
            this.Hide();
            apl.Show();
        }
        private void simpleButton26_Click_1(object sender, EventArgs e)
        {

        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
        private void txtrecupQteEntre_Click(object sender, EventArgs e)
        {
            txtrecupQteEntre.Clear();
        }
        private void simpleButton37_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton38_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton10_Click_1(object sender, EventArgs e)
        {
            inserernumordre();
            Engesitrerdatagrid();
            //Facture_clients fl = new Facture_clients();
            //fl.label5.Text = label48.Text;
            //fl.label6.Text = label49.Text;
            //fl.labelsitefacture.Text = lblsiteuser.Text;
             Factureencours();
            //impressionFacture();
            //vendreprod();
        }
        private void simpleButton37_Click_1(object sender, EventArgs e)
        {
        }
        void somdetouspromoi()
        {
            //  Methode pour afficher(selectionner la sommation de tous les produits vendus par moi souhaité
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select sum(Prix_total)Prix_total from [dbo].[Ventes] WHERE MOIS ='" + comboBox2.Text + "'and Officine='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd.ExecuteReader();
            while (conn.dr2.Read())
            {
                label139.Text = Convert.ToString(conn.dr2["Prix_total"].ToString());
            }
            conn.dr2.Close();

        }
        private void simpleButton39_Click(object sender, EventArgs e)
        {


        }
        private void simpleButton38_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton40_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            somdetouspromoi();
        }

        private void simpleButton34_Click_1(object sender, EventArgs e)
        {

        }

        //Méthode pour imprimer le rapport journalier ou le rapport de la date souhaiter
        void Joursouhaiter()
        {
            if (datecontrolejournalier.Text == "Selectionner date")
            {
                MessageBox.Show("Veuillez selectionnez la date svp");
                datecontrolejournalier.Focus();
            }
            else
            {
                PAGE_ACCUEIL PAE = new PAGE_ACCUEIL();
                CrystaljournalierDetaillee crystal = new CrystaljournalierDetaillee();
                Appeldetailrapportjournalier cal = new Appeldetailrapportjournalier();
                cal.lbluserrapportjour.Text = label48.Text;
                cal.lblrolerapport.Text = label49.Text;
                cal.lblsiterapport.Text = lblsiteuser.Text;
                this.Hide();
                crystal.Load("CrystaljournalierDetaillee.rpt");
                crystal.Refresh();
                crystal.SetParameterValue("Parasyntheses", datecontrolejournalier.Text);
                cal.crystalReportViewer1rapportjournalierdetaillee.ReportSource = crystal;
                cal.Show();
            }
        }
        private void simpleButton41_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton44_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton43_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton42_Click(object sender, EventArgs e)
        {

        }

        private void label116_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton27_Click_2(object sender, EventArgs e)
        {

        }

        private void simpleButton19_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton8_Click_2(object sender, EventArgs e)
        {

        }

        private void typecli_TextChanged(object sender, EventArgs e)
        {

        }
        private void simpleButton29_Click_1(object sender, EventArgs e)
        {

        }

        private void txtnomvende_TextChanged(object sender, EventArgs e)
        {

        }
        private void simpleButton15_Click_1(object sender, EventArgs e)
        {

        }
        private void simpleButton28_Click_2(object sender, EventArgs e)
        {
        }
        private void richrecherche_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataclients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void simpleButton44_Click_1(object sender, EventArgs e)
        {
        }
        private void tnom_TextChanged(object sender, EventArgs e)
        {

        }
        private void tprenom_TextChanged(object sender, EventArgs e)
        {

        }
        void MethodeInformArticleApprovisionner()
        {
            conn.communication();
            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
            conn.cmd2.Connection = conn.con;
            conn.cmd2.CommandType = CommandType.Text;
            conn.cmd2.CommandText = "Select [NOM_PROD],[Unites] FROM [GS_ALIMENT].[dbo].[Liste_produit] where Nom_prod ='" + richprod.Text + "'";
            conn.dr = conn.cmd2.ExecuteReader();
            if (conn.dr.HasRows)
            {
                listproduits.Visible = true;
                if (conn.dr.Read())
                {
                    richprod.Text = conn.dr["NOM_PROD"].ToString();
                    richUnitesventes.Text = conn.dr["Unites"].ToString();
                }
            }
            else
            {
                txtnumlotaprov.Text = "";
                txtpa.Text = "";
                listproduits.Visible = false;
            }
            conn.dr.Close();
        }
       
        void MethodeAfficheListeBoxApprovisionnement()
        {
            try
            {
                conn.communication();
                conn.cmd = new System.Data.SqlClient.SqlCommand();
                conn.cmd.Connection = conn.con;
                conn.cmd.CommandType = CommandType.Text;
                if (richprod.Text.Length != 0)
                {
                    listproduits.Visible = true;
                    conn.cmd.CommandText = "SELECT distinct(Nom_prod) as Prod FROM [dbo].[Liste_produit] where Nom_prod like'" + richprod.Text + "%' order by Nom_prod  ASC";
                    conn.dr = conn.cmd.ExecuteReader();
                    listproduits.Items.Clear();
                    while (conn.dr.Read())
                    {
                        listproduits.Items.Add(conn.dr["Prod"]);
                    }
                    conn.dr.Close();
                }
                else
                {
                    listproduits.Visible = false;
                    listproduits.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textart_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton55_Click(object sender, EventArgs e)
        {
        }
        private void label60_Click(object sender, EventArgs e)
        {

        }
        private void Paniervente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void simpleButton45_Click(object sender, EventArgs e)
        {

        }
        private void textqtcomm_TextChanged(object sender, EventArgs e)
        {

        }
        private void textmatric_TextChanged(object sender, EventArgs e)
        {

        }
        private void simpleButton41_Click_1(object sender, EventArgs e)
        {

        }
        private void simpleButton42_Click_1(object sender, EventArgs e)
        {

        }
        private void textBoxcmd_TextChanged(object sender, EventArgs e)
        {

        }
        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void textBoxmatri_TextChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void simpleButton50_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton43_Click_1(object sender, EventArgs e)
        {

        }
        private void simpleButton45_Click_1(object sender, EventArgs e)
        {

        }
        private void simpleButton49_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton30_Click_1(object sender, EventArgs e)
        {

        }

        private void label151_Click(object sender, EventArgs e)
        {

        }
        private void pvarticle_TextChanged(object sender, EventArgs e)
        {
        }

        private void paniercommande_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void simpleButton46_Click(object sender, EventArgs e)
        {
        }
        private void simpleButton47_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton48_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton45_Click_2(object sender, EventArgs e)
        {
        }
        private void simpleButton51_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton51_Click_1(object sender, EventArgs e)
        {

        }
        private void simpleButton53_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton52_Click(object sender, EventArgs e)
        {
        }
        private void listproduits_SelectedIndexChanged(object sender, EventArgs e)
        {
            richprod.Text = Convert.ToString(listproduits.SelectedItem);
            listproduits.Visible = false;
        }
        private void textapprod_TextChanged(object sender, EventArgs e)
        {
            if (richprod.Text == "")
            {
                richprod.Focus();
                listproduits.Visible = false;
            }
            else
            {
                MethodeInformArticleApprovisionner();
                MethodeAfficheListeBoxApprovisionnement();
            }
        }
        void MethodeAfficheListeBoxqteapprov()
        {
            try
            {
                conn.communication();
                conn.cmd = new System.Data.SqlClient.SqlCommand();
                conn.cmd.Connection = conn.con;
                conn.cmd.CommandType = CommandType.Text;
                if (textnomartapprv.Text.Length != 0)
                {
                    listAddqte.Visible = true;
                    conn.cmd.CommandText = "SELECT distinct(Nom_prod) as Prod FROM [dbo].[Approvisionnements] where Nom_prod like'" + textnomartapprv.Text + "%' and Officine='" + lblsiteuser.Text + "' order by Nom_prod  ASC";
                    conn.dr = conn.cmd.ExecuteReader();
                    listAddqte.Items.Clear();
                    while (conn.dr.Read())
                    {
                        listAddqte.Items.Add(conn.dr["Prod"]);
                    }
                    conn.dr.Close();
                }
                else
                {
                    listAddqte.Visible = false;
                    listAddqte.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Méthode pour chercher la facture vendue enfin de la modifié
        void rechfactnote()
        {
            {
                conn.communication();
                conn.da2 = new SqlDataAdapter("select * FROM [dbo].[Ventes] where NumFacture like '%" + textrechfact.Text + "'and Officine='" + lblsiteuser.Text + "'", conn.con);
                conn.dt = new DataTable();
                conn.da2.Fill(conn.dt);
                dataGridfacture.DataSource = conn.dt;
                conn.con.Close();
            }
        }
        //Méthode pour chercher la facture vendue enfin de la modifié
        void recharticleproformat()
        {
            {
                conn.communication();
                conn.da = new SqlDataAdapter("select [Num_lot],[Nom_prod],[Qte_sotock],[Date_enre],[Famille],[Unites],[PA],[Officine] FROM [dbo].[Approvisionnements] where Nom_prod like '" + txtrecherchearticle.Text + "%'and Officine='" + lblsiteuser.Text + "'", conn.con);
                conn.dt2 = new DataTable();
                conn.da.Fill(conn.dt2);
                dataGridproforma.DataSource = conn.dt2;
                conn.con.Close();
            }
        }
        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void simpleButton8_Click_3(object sender, EventArgs e)
        {
            approvisionnerproduit();
        }
        void totalartapprov()
        {
            conn.communication();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            conn.cmd1.CommandText = "select COUNT (Nom_prod) Nom_prod from [dbo].[Approvisionnements] where Officine='" + lblsiteuser.Text + "' ";
            conn.dr = conn.cmd1.ExecuteReader();
            while (conn.dr.Read())
            {
                lblnombres.Text = conn.dr["Nom_prod"].ToString();
            }
            conn.dr.Close();
        }
        void totalartavendujour()
        {
           // conn.da = new SqlDataAdapter("select Nom_prod, SUM(Qte_vendue) AS Qte, SUM(Prix_total)  AS TOTAL, Date_vendu from [GS_ALIMENT].[dbo].[Ventes] where Date_vendu ='" + DateVentesjourssyntheses.Text + "' GROUP BY Nom_prod, Date_vendu ", conn.con);
            conn.communication();
            conn.cmd4 = new System.Data.SqlClient.SqlCommand();
            conn.cmd4.Connection = conn.con;
            conn.cmd4.CommandType = CommandType.Text;
            conn.cmd4.CommandText = "select COUNT (Nom_prod) AS Nom_prod, COUNT (Qte_vendue) AS Qte_vendue, Date_vendu from [GS_ALIMENT].[dbo].[Ventes] where Date_vendu ='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and Sites='" + lblsiteuser.Text + "' GROUP BY Nom_prod, Date_vendu";
            conn.dr2 = conn.cmd4.ExecuteReader();
            while (conn.dr2.Read())
                if (lblvjour.Text == "")
                {
                    lblvjour.Text = "0";
                }
                else
            {
                lblvjour.Text = conn.dr2["Qte_vendue"].ToString();
            }
            conn.dr2.Close();
        }
        private void simpleButton15_Click_2(object sender, EventArgs e)
        {

        }
        private void totgenefonds_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton35_Click(object sender, EventArgs e)
        {
        }
        private void simpleButton36_Click(object sender, EventArgs e)
        {
            if (richinferieur.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nombre svp");
                richinferieur.Focus();
            }
            else
            {
                PAGE_ACCUEIL PA = new PAGE_ACCUEIL();
                Reportinferieur cry = new Reportinferieur();
                AppelInferieure rin = new AppelInferieure();
                rin.label1.Text = label48.Text;
                rin.label2.Text = label49.Text;
                //laluserinferieure.Text = lblsiteuser.Text;
                this.Hide();
                cry.Load("Reportinferieur.rpt");
                cry.Refresh();
                cry.SetParameterValue("inferieurch", richinferieur.Text);
                rin.crystalReportViewer1.ReportSource = cry;
                rin.Show();
            }
        }

        private void simpleButton13_Click_1(object sender, EventArgs e)
        {
            Joursouhaiter();
        }

        private void simpleButton15_Click_3(object sender, EventArgs e)
        {
            Supprimerrpjpour();
        }

        private void textrechfact_TextChanged(object sender, EventArgs e)
        {
            rechfactnote();
        }
        // Méthode pour retourner la marchandise vendue dans le stock(Approvisionnement)
        void Noteretour()
        {
            if (texartic.Text == "" && textqteretour.Text == "")
            {
                MessageBox.Show("Veuillez d'abord chercher le nom et la quantité de l'article vendue svp!");
            }
            else
            {
                if (texartic.Text.Length != 0 || textqteretour.Text.Length != 0)
                {
                    // déclaration des variables de types réel
                    double quantajout, stockQte, QteAugmentat;
                    stockQte = 0;
                    quantajout = Convert.ToDouble(textqteretour.Text);
                    //connection pour sélectionner la quantité qui se trouve dans la base de donnée

                    conn.communication();
                    conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                    conn.cmd2.Connection = conn.con;
                    conn.cmd2.CommandType = CommandType.Text;
                    conn.cmd2.CommandText = "select Qte_sotock from [dbo].[Approvisionnements] where Nom_prod='" + texartic.Text + "'and Officine='" + lblsiteuser.Text + "'";
                    conn.dr = conn.cmd2.ExecuteReader();
                    while (conn.dr.Read())
                    {
                        stockQte = Convert.ToDouble(conn.dr["Qte_sotock"]);
                    }
                    conn.dr.Close();
                    QteAugmentat = stockQte + quantajout;
                    // modification de quantité qui se trouve dans l'aaprovisionnement
                    conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                    conn.cmd1.Connection = conn.con;
                    conn.cmd1.CommandType = CommandType.Text;
                    echo = MessageBox.Show("Voulez-vous faire la note de retour pour cet article?", "GS-COMMERCIALE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (echo == DialogResult.Yes)
                    {
                        //conn.communication();
                        conn.cmd1.CommandText = "update Approvisionnements set Qte_sotock='" + QteAugmentat + "' where Nom_prod='" + texartic.Text + "'and Officine='" + lblsiteuser.Text + "'";
                        conn.cmd1.ExecuteNonQuery();
                        MessageBox.Show("La note de retour du(de)d' " + texartic.Text + " est effectué");
                        enregistrernoteretour();
                    }
                    conn.dr.Close();
                }
            }
        }
        private void dataGridfacture_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridfacture.Rows[e.RowIndex];
                texartic.Text = row.Cells["Nom_prod"].Value.ToString();
                txtqtear.Text = row.Cells["Qte_vendue"].Value.ToString();
                //textdatevd.Text = row.Cells["Date_vendu"].Value.ToString();
                textnvend.Text = row.Cells["Nom_vendeur"].Value.ToString();
                texttotoretour.Text = row.Cells["Prix_total"].Value.ToString();
                textpvretour.Text = row.Cells["PV"].Value.ToString();
                textheuretour.Text = row.Cells["Heur"].Value.ToString();
                textfactretour.Text = row.Cells["NumFacture"].Value.ToString();
            }
        }
        void enregistrernoteretour()
        {
            // Méthode pour enregistrer la note de crédit dans base de données
            conn.communication();
            conn.cmd4 = new System.Data.SqlClient.SqlCommand();
            conn.cmd4.Connection = conn.con;
            conn.cmd4.CommandType = CommandType.Text;
            //conn.cmd4.CommandText = "insert into NRetour values('" + Regex.Replace(texartic.Text, "'", "''") + "', '" + Regex.Replace(textpvretour.Text, "'", "''") + "' ,'" + Regex.Replace(textqteretour.Text, "'", "''") + "','" + Regex.Replace(DateTime.Now.ToString("yyyy-MM-dd"), "'", "''") + "','" + Regex.Replace(texttotoretour.Text, "'", "''") + "','" + Regex.Replace(textnvend.Text, "'", "''") + "','" + Regex.Replace(textheuretour.Text, "'", "''") + "','" + Regex.Replace(textfactretour.Text, "'", "''") + "')";
            conn.cmd4 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[NRetour] values( @Nom_prod,@PV,@Qte_retour,@Date_retour,@Nom_vendeur,@Heur,@Num_Fac,@Officine)", conn.con);                                                                                                                                                                                                                                                                                                                                                                                                                                                                   //[Emploi_2],[Num],[Av],[Quartier],[Commune]
            conn.cmd4.Parameters.AddWithValue("@Nom_prod", texartic.Text);
            conn.cmd4.Parameters.AddWithValue("@PV", float.Parse(textpvretour.Text));
            conn.cmd4.Parameters.AddWithValue("@Qte_retour", textqteretour.Text);
            conn.cmd4.Parameters.AddWithValue("@Date_retour", DateTime.Now.ToString("yyyy-MM-dd"));
            conn.cmd4.Parameters.AddWithValue("@Nom_vendeur", textnvend.Text);
            conn.cmd4.Parameters.AddWithValue("@Heur", DateTime.Now.ToString("HH:mm:ss"));
            conn.cmd4.Parameters.AddWithValue("@Num_Fac", textfactretour.Text);
            conn.cmd4.Parameters.AddWithValue("@Officine", lblsiteuser.Text);

            conn.cmd4.ExecuteNonQuery();
            MessageBox.Show("Opration valider avec succès");
        }
        void Validerproforma()
        {
            // Méthode pour enregistrer la facture proforma dans le datagrid
            conn.communication();
            conn.cmd4 = new System.Data.SqlClient.SqlCommand();
            conn.cmd4.Connection = conn.con;
            conn.cmd4.CommandType = CommandType.Text;
            int nbreligne4 = dataGridpanierproforma.RowCount;
            for (int n = 0; n < nbreligne4; n++)
            {              
                conn.cmd4 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[Proforma] values (@Nom_prod,@PV,@Qte_vendue,@Prix_total,@Date_enre,@Qte_dispo,@Numprofo,@Officine)", conn.con);                                                                                                                                                                                                                                                                                                                                                                                                                                                                   //[Emploi_2],[Num],[Av],[Quartier],[Commune]
                conn.cmd4.Parameters.AddWithValue("@Nom_prod", dataGridpanierproforma.Rows[n].Cells[0].Value);
                conn.cmd4.Parameters.AddWithValue("@PV", float.Parse(dataGridpanierproforma.Rows[n].Cells[1].Value.ToString()));
                conn.cmd4.Parameters.AddWithValue("@Qte_vendue", dataGridpanierproforma.Rows[n].Cells[2].Value);
                conn.cmd4.Parameters.AddWithValue("@Prix_total", float.Parse(dataGridpanierproforma.Rows[n].Cells[3].Value.ToString()));
                conn.cmd4.Parameters.AddWithValue("@Date_enre", DateTime.Now.ToString("yyyy-MM-dd"));
                conn.cmd4.Parameters.AddWithValue("@Qte_dispo", dataGridpanierproforma.Rows[n].Cells[5].Value);
                conn.cmd4.Parameters.AddWithValue("@Numprofo", dataGridpanierproforma.Rows[n].Cells[6].Value);
                conn.cmd4.Parameters.AddWithValue("@Officine", dataGridpanierproforma.Rows[n].Cells[6].Value);

                conn.cmd4.ExecuteNonQuery(); 
            }
            MessageBox.Show("Proforma bien enregistrer");
        }
        void Validerrequisition()
        {
            // Méthode pour enregistrer la facture la réquisition dans le datagrid
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            int nbreligne5 = dataGridrequisition.RowCount;
            for (int p = 0; p < nbreligne5; p++)
            {
                //conn.cmd.CommandText = "INSERT INTO [dbo].[Requisition] values ('" + dataGridrequisition.Rows[p].Cells[0].Value + "','" + dataGridrequisition.Rows[p].Cells[1].Value + "','" + dataGridrequisition.Rows[p].Cells[2].Value + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + dataGridrequisition.Rows[p].Cells[4].Value + "','" + dataGridrequisition.Rows[p].Cells[5].Value + "','" + dataGridrequisition.Rows[p].Cells[6].Value + "')";                
                conn.cmd4 = new SqlCommand("INSERT [GS_ALIMENT].[dbo].[Requisition] values (@Articles,@Qtedispo,@Qterequisit,@Daterequis,@Site,@Demandeur,@Prix)", conn.con);                                                                                                                                                                                                                                                                                                                                                                                                                                                                   //[Emploi_2],[Num],[Av],[Quartier],[Commune]
                conn.cmd4.Parameters.AddWithValue("@Articles", dataGridrequisition.Rows[p].Cells[0].Value);
                conn.cmd4.Parameters.AddWithValue("@Qtedispo", dataGridrequisition.Rows[p].Cells[1].Value);
                conn.cmd4.Parameters.AddWithValue("@Qterequisit", dataGridrequisition.Rows[p].Cells[2].Value);
                conn.cmd4.Parameters.AddWithValue("@Daterequis", DateTime.Now.ToString("yyyy-MM-dd"));
                conn.cmd4.Parameters.AddWithValue("@Site", dataGridrequisition.Rows[p].Cells[4].Value);
                conn.cmd4.Parameters.AddWithValue("@Demandeur", dataGridrequisition.Rows[p].Cells[5].Value);
                conn.cmd4.Parameters.AddWithValue("@Prix", float.Parse(dataGridrequisition.Rows[p].Cells[6].Value.ToString()));
                conn.cmd4.ExecuteNonQuery();
            }
            MessageBox.Show("Réquisition effectué" + " " + lblsiteuser.Text);
        }
        private void simpleButton19_Click_2(object sender, EventArgs e)
        {
            Noteretour();
        }
        private void simpleButton27_Click_3(object sender, EventArgs e)
        {
        }
        private void txtrecherchearticle_TextChanged(object sender, EventArgs e)
        {
            recharticleproformat();
        }
        private void congifurerlistepanier(string a, string b, string c, string d, string dat, string e, string f)
        {
            string[] row = { a, b, c, d, dat, e, f };
            dataGridpanierproforma.Rows.Add(row);
        }
        // Configuration de la partie requisition
        private void congifurerlistepanierrequition(string a, string b, string c, string dat, string d, string e, string f)
        {
            string[] row = { a, b, c, dat, d, e, f };

            dataGridrequisition.Rows.Add(row);
        }
        private void simpleButton28_Click_3(object sender, EventArgs e)
        {
            //Ajouterpanierproforma();
            Validerproforma();
            inserernumordreproforma();
        }
        public void Ajouterpanierproforma()
        {
            if (txtnumfacpro.Text == "")
            {
                MessageBox.Show("Insérer le numéro de facture proforma");
            }
            else 
            {
                initialDataGridproforma();
                congifurerlistepanier(txtnomartprof.Text, txtcalulemodulo.Text, txtqteprof.Text, txttotoprof.Text, DateTime.Today.ToString("yyyy-MM-dd"), txtqtestockprof.Text, txtnumfacpro.Text);  
            }     
        }
        void initialDataGridproforma()
        {
            dataGridpanierproforma.ColumnCount = 8;

            dataGridpanierproforma.Columns[0].Name = "Nom_prod";
            dataGridpanierproforma.Columns[1].Name = "PV";
            dataGridpanierproforma.Columns[2].Name = "Qte_vendue";
            dataGridpanierproforma.Columns[3].Name = "Prix_total";
            dataGridpanierproforma.Columns[4].Name = "Date_enre";
            dataGridpanierproforma.Columns[5].Name = "Qte_dispo";
            dataGridpanierproforma.Columns[6].Name = "Numprofo";
            dataGridpanierproforma.Columns[7].Name = "Officine";

        }
        // Ajouter au panier de réquisition
        public void Ajouterpanierrequisition()
        {
            initialDataGridrequisition();
            congifurerlistepanierrequition(txtarticless.Text, txtqtedisponi.Text, txtrequisition.Text, DateTime.Today.ToString("yyyy-MM-dd"), lblsiteuser.Text, label48.Text, textprixpa.Text);
        }
        void initialDataGridrequisition()
        {
            dataGridrequisition.ColumnCount = 7;

            dataGridrequisition.Columns[0].Name = "Articles";
            dataGridrequisition.Columns[1].Name = "Qtedispo";
            dataGridrequisition.Columns[2].Name = "Qterequisit";
            dataGridrequisition.Columns[3].Name = "Daterequis";
            dataGridrequisition.Columns[4].Name = "Site";
            dataGridrequisition.Columns[5].Name = "Demandeur";
            dataGridrequisition.Columns[6].Name = "Prix";
        }
        private void dataGridproforma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridproforma.Rows[e.RowIndex];
                txtnomartprof.Text = row.Cells["Nom_prod"].Value.ToString();
                txtqtestockprof.Text = row.Cells["Qte_sotock"].Value.ToString();
                txtpvprof.Text = row.Cells["PA"].Value.ToString();
                Calculmoduloproforma();
            }
        }
        // Méthode pour calculer la quantité de produit
        void additionproforma()
        {
            Calculmoduloproforma();
            try
            {
                if (txtqteprof.Text == "")
                {
                    txtqteprof.Focus();
                }
                else
                {
                    double x, y, z;
                    x = Convert.ToDouble(txtcalulemodulo.Text);
                    y = Convert.ToDouble(txtqteprof.Text);
                    z = x * y;
                    txttotoprof.Text = Convert.ToString(z);
                    //label60.Text = txttot.Text;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Entrer le chiffre" + exc);
            }
        }
        private void txtqteprof_TextChanged(object sender, EventArgs e)
        {
            additionproforma();
        }
        private void simpleButton31_Click_1(object sender, EventArgs e)
        {
            Ajouterpanierproforma();
            SommeProformat();
            btnvalideproforma.Enabled = true;
        }
        private void txtsommeprof_TextChanged(object sender, EventArgs e)
        {

        }
        private void label131_Click(object sender, EventArgs e)
        {
            //CalculTVA();
        }
        private void txttotoprof_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridpanierproforma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void ProformaPrinte()
        {
            if (label61.Text == "")
            {
                MessageBox.Show("Impossible d'imprimer la Facture sans numéro");
            }
            else
            {
                PAGE_ACCUEIL PA = new PAGE_ACCUEIL();
                Proforma cry = new Proforma();
                AppelProforma prof = new AppelProforma();
                prof.proformauser.Text = label48.Text;
                prof.proformastatu.Text = label49.Text;
                prof.Siteproforma.Text = lblsiteuser.Text;
                this.Hide();
                cry.Load("Proforma.rpt");
                cry.Refresh();
                cry.SetParameterValue("Pproforma", textrecheproforma.Text);
                prof.crystalReportViewer1.ReportSource = cry;
                prof.Show();
            }
        }
        private void simpleButton29_Click_2(object sender, EventArgs e)
        {
            ProformaPrinte();
        }
        void NumeroProforma()
        {
            try
            {
                conn.communication();
                conn.cmd4 = new System.Data.SqlClient.SqlCommand();
                conn.cmd4.Connection = conn.con;
                conn.cmd4.CommandType = CommandType.Text;
                conn.cmd4.CommandText = "SELECT [N_Ordre] FROM [dbo].[NumProforma] where Officine='" + lblsiteuser.Text + "'";
                conn.dr = conn.cmd4.ExecuteReader();
                while (conn.dr.Read())
                {
                    txtnumfacpro.Text = conn.dr["N_Ordre"].ToString();
                   
                }
                conn.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void simpleButton30_Click_2(object sender, EventArgs e)
        {
            NumeroProforma();
            btnpanierproforma.Enabled = true;
            btnvalideproforma.Enabled = true;
        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            
        }
        private void datamodifProforma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {
            //texaffitoto.Text = lbltotpayer.Text;
            //CalculTVA();
        }
        private void txttot_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtqteve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void txtnomvende_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.txtnomvende.Text = this.txtnomvende.Text.ToUpper();
            this.txtnomvende.SelectionStart = this.txtnomvende.Text.Length;
        }
        private void simpleButton32_Click_1(object sender, EventArgs e)
        {

        }
        private void label149_Click(object sender, EventArgs e)
        {

        }
        private void label154_Click(object sender, EventArgs e)
        {

        }
        private void label152_Click(object sender, EventArgs e)
        {

        }
        void MethodeAfficheListedrh()
        {
            try
            {
                conn.communication();
                conn.cmd = new System.Data.SqlClient.SqlCommand();
                conn.cmd.Connection = conn.con;
                conn.cmd.CommandType = CommandType.Text;
                if (txtrecherches.Text.Length != 0)
                {
                    listoBoxrequisition.Visible = true;
                    conn.cmd.CommandText = "SELECT * FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod like'%" + txtrecherches.Text + "%' and Officine='" + lblsiteuser.Text + "'";
                    conn.dr = conn.cmd.ExecuteReader();
                    listoBoxrequisition.Items.Clear();
                    while (conn.dr.Read())
                    {
                        listoBoxrequisition.Items.Add(conn.dr["Nom_prod"]);
                    }
                    conn.dr.Close();
                }
                else
                {
                    listoBoxrequisition.Visible = false;
                    listoBoxrequisition.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        public void Recherches()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = " SELECT [Nom_prod],[Qte_sotock],[PA] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + txtrecherches.Text + "'and Officine='" + lblsiteuser.Text + "'";
            conn.dr = conn.cmd.ExecuteReader();
            if (conn.dr.HasRows)
            {
                if (conn.dr.Read())
                {
                    txtarticless.Text = conn.dr["Nom_prod"].ToString();
                    txtqtedisponi.Text = conn.dr["Qte_sotock"].ToString();
                    textprixpa.Text = conn.dr["PA"].ToString();
                }
            }
            else
            {
                conn.con.Close();
                conn.dr.Close();
            }
        }
        private void txtrecherche_TextChanged(object sender, EventArgs e)
        {
            this.txtrecherches.SelectionStart = this.txtrecherches.Text.Length;
            if (txtrecherches.Text == "")
            {
                txtrecherches.Focus();
                listoBoxrequisition.Visible = false;
            }
            else
            {
                Recherches();
                MethodeAfficheListedrh();
            }
            if (txtrecherches.Text == "")
            {

            }
            else
            {
                //methodeListePap();
            }
        }
        private void listoBoxrequisition_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtrecherches.Text = Convert.ToString(listoBoxrequisition.SelectedItem);
            listoBoxrequisition.Visible = false;
        }
        private void btnpanier_Click(object sender, EventArgs e)
        {
            Ajouterpanierrequisition();
            annulerrequisi();
        }

        private void btnvalide_Click(object sender, EventArgs e)
        {
            Validerrequisition();
        }
        private void combositerequi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void Listerequisition()
        {
            conn.communication();
            conn.da1 = new SqlDataAdapter("select [Articles],[Qtedispo],[Qterequisit],[Daterequis],[Site],[Demandeur],[Prix] FROM [dbo].[Requisition ] where Daterequis between '" + daterequisitiondu.Value + "' and '" + daterequisitionau.Value + "'and Site='" + lblsiteuser.Text + "'", conn.con);
            conn.dt = new DataTable();
            conn.da1.Fill(conn.dt);
            dataGriddrh.DataSource = conn.dt;
            conn.con.Close();
        }
        private void dateTimePicker3_ValueChanged_1(object sender, EventArgs e)
        {
            Selectionnedateexpiration();
        }
        // Méthode pour selectionner la sommes de requitision selectionner
        void Selectsummerequisition()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select sum(Prix)Prix from [GS_ALIMENT].[dbo].[Requisition] WHERE Daterequis between '" + daterequisitiondu.Value + "' and '" + daterequisitionau.Value + "'and Site='" + lblsiteuser.Text + "'";
            conn.dr1 = conn.cmd.ExecuteReader();
            while (conn.dr1.Read())
            {
                texttotalpa.Text = Convert.ToString(conn.dr1["Prix"].ToString());
            }
            conn.dr1.Close();
        }
        private void txtrecupQteEntre_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Listerequisition();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }
        private void groupBox33_Enter(object sender, EventArgs e)
        {

        }
        private void cmbcaissesite_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }
        private void cmbventesite_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void dateTimeventesiau_ValueChanged(object sender, EventArgs e)
        {

        }
        private void simpleButton32_Click_2(object sender, EventArgs e)
        {
            ajouprod();
        }
        private void simpleButton41_Click_2(object sender, EventArgs e)
        {
            annulapprov();
        }
        void sommefondApprovisionnemnts()
        {
            //Methode pour afficher la sommation de fond en rapport avec l'approvisionnement
            conn.communication();
            conn.cmd4 = new System.Data.SqlClient.SqlCommand();
            conn.cmd4.Connection = conn.con;
            conn.cmd4.CommandType = CommandType.Text;
            conn.cmd4.CommandText = "select sum(PA)PA from [GS_ALIMENT].[dbo].[Approvisionnements] WHERE Officine='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd4.ExecuteReader();
            while (conn.dr2.Read())
            {
                txtshowfondapprov.Text = Convert.ToString(conn.dr2["PA"].ToString());
            }
            conn.dr2.Close();
        }
        private void simpleButton37_Click_2(object sender, EventArgs e)
        {
            try
            {
                conn.communication();
                conn.cmd1 = new System.Data.SqlClient.SqlCommand();
                conn.cmd1.Connection = conn.con;
                conn.cmd1.CommandType = CommandType.Text;
                conn.cmd1.CommandText = "UPDATE [dbo].[Approvisionnements] SET [Num_lot] = '" + txtnumlotaprov.Text + "',[Nom_prod] ='" + Regex.Replace(richprod.Text, "'", "''") + "',[PA] ='" + txtpa.Text + "',[Famille] = '" + Regex.Replace(cmbformearticle.Text, "'", "''") + "',[Rayon] = '" + txtaproetagere.Text + "',[Date_exp] = '" + dateExpiration.Value + "',[Unites] ='" + Regex.Replace(richUnitesventes.Text, "'", "''") + "' WHERE ID ='" + lblIDaprov .Text+ "' and Officine ='" + Regex.Replace(lblsiteuser.Text, "'", "''") + "'";                                                                                                                                                                                                               
                if (conn.cmd1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("La modification effectué avec succès");
                }
            }
            catch (Exception rect)
            {
                MessageBox.Show(rect.Message.ToString());
            }
         
        }

        private void simpleButton35_Click_1(object sender, EventArgs e)
        {
            afficheapprov();
            Rowscolor();
        }

        private void simpleButton27_Click_4(object sender, EventArgs e)
        {
     
                PAGE_ACCUEIL PA = new PAGE_ACCUEIL();
                RapportApprov cry = new RapportApprov();
                AppelApprovisionnement aplap = new AppelApprovisionnement();
                aplap.label3.Text = label48.Text;
                aplap.label4.Text = label49.Text;
                this.Hide();
                cry.Load(" RapportApprov.rpt");
                cry.Refresh();
                cry.SetParameterValue("Approvbyofficine", lblsiteuser.Text);
                aplap.crystalReportViewer1.ReportSource = cry;
                aplap.Show();
        }

        private void txtrecupQteEntre_TextChanged_1(object sender, EventArgs e)
        {
            // txtrecupQteEntre.Text = txtqtesto.Text;
        }

        private void richprod_TextChanged_1(object sender, EventArgs e)
        {
            recherticleifiexisteapprov();
            if (richprod.Text == "")
            {
                richprod.Focus();
                listproduits.Visible = false;
            }
            else
            {
                MethodeInformArticleApprovisionner();
                MethodeAfficheListeBoxApprovisionnement();
               
            }
        }

        private void listproduits_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            richprod.Text = Convert.ToString(listproduits.SelectedItem);
            listproduits.Visible = false;
        }

        private void btncalculermodulo_Click(object sender, EventArgs e)
        {
         
        }
        private void button3_Click(object sender, EventArgs e)
        {
            totalartrequisit();
        }

        private void listbyforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            richformes.Text = Convert.ToString(listbyforme.SelectedItem);
            listbyforme.Visible = false;
        }

        private void richformes_TextChanged(object sender, EventArgs e)
        {
            if (richformes.Text == "")
            {
                richformes.Focus();
                listbyforme.Visible = false;
            }
            else
            {
                MethodeInformArticleVenteforme();
                MethodeAfficheListeBoxVenteforme();
            }
        }

        private void txtrecherches_Click(object sender, EventArgs e)
        {
            txtrecherches.Clear();
        }
        void annulerrequisi()
        {
            txtarticless.Clear();
            textprixpa.Clear();
            txtqtedisponi.Clear();
        }

        private void txtrequisition_Click(object sender, EventArgs e)
        {
            txtrequisition.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Selectsummerequisition();
        }
        // Méthode pour afficher les articles qui expire dans 
        void Verificationdateexpiration()
        {
                conn.communication();
                conn.da1 = new SqlDataAdapter("select [Num_lot],[Nom_prod],[Qte_sotock],[Date_enre],[Rayon],[Date_exp], DATEDIFF(day, GETDATE(), Date_exp) as nbjours FROM [GS_ALIMENT].[dbo].[Approvisionnements] WHERE DATEDIFF(day, GETDATE(), Date_exp) <=123 and Officine='" + lblsiteuser.Text + "'", conn.con);
                conn.dt1 = new DataTable();
                conn.da1.Fill(conn.dt1);
                dataGridpreremption.DataSource = conn.dt1;
                Rowscolorexpirearticle();
                conn.con.Close();     
        }
        // Selectionner la date d'expiration du produit dans dans un delais souhaité
        void Selectionnedateexpiration()
        {
            conn.communication();
            conn.da1 = new SqlDataAdapter("select * FROM [GS_ALIMENT].[dbo].[Approvisionnements] WHERE Date_exp between '" + daterequisitiondu.Value + "' and '" + daterequisitionau.Value + "' and Officine='" + lblsiteuser.Text + "'", conn.con);
            conn.dt1 = new DataTable();
            conn.da1.Fill(conn.dt1);
            dataGriddrh.DataSource = conn.dt1;
            Rowscolorexpirearticle();
            conn.con.Close(); 
        }
        // Méthode pour compté le nombre total des article commender
        void totalartrequisit()
        {
            conn.communication();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            conn.cmd1.CommandText = "select COUNT (Articles) Articles from [GS_ALIMENT].[dbo].[Requisition] WHERE Daterequis between '" + daterequisitiondu.Value + "' and '" + daterequisitionau.Value + "'and Site='" + lblsiteuser.Text + "' ";
            conn.dr = conn.cmd1.ExecuteReader();
            while (conn.dr.Read())
            {
                textnbrprices.Text = conn.dr["Articles"].ToString();
            }
            conn.dr.Close();
        }
         private void txtqtesto_Click_1(object sender, EventArgs e)
        {
            txtqtesto.Clear();
        }

        private void richprod_Click(object sender, EventArgs e)
        {
            richprod.Clear();
        }
        private void txtqtesto_TextChanged(object sender, EventArgs e)
        {
            txtrecupQteEntre.Text = txtqtesto.Text;
        }
        private void groupBoxajouterqte_Enter(object sender, EventArgs e)
        {

        }
        private void listBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            textnomartapprv.Text = Convert.ToString(listAddqte.SelectedItem);
            listAddqte.Visible = false;
        }
        private void richTexmontantpercu_TextChanged(object sender, EventArgs e)
        {
            calculerresteclient();
        }
        private void richTexmontantpercuusd_TextChanged(object sender, EventArgs e)
        {
            calculerresteclientusd();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (dateTimePrinterequisition.Text == "")
            {
                MessageBox.Show("Veuillez Selectionner la date svp");
            }
            else
            {
                PAGE_ACCUEIL PA = new PAGE_ACCUEIL();
                CrystalRequisition cry = new CrystalRequisition();
                Callcommande rin = new Callcommande();
                this.Hide();
                cry.Load("CrystalRequisition.rpt");
                cry.Refresh();
                cry.SetParameterValue("Paramrequisition", dateTimePrinterequisition.Text);
                rin.crystalReportViewer11.ReportSource = cry;
                rin.Show();
            }
        }
        // Affiché la synthèse de vente au date souhaitée
        void ShowsumVentejournalier()
        {
            conn.communication();
            conn.da = new SqlDataAdapter("select Nom_prod, SUM(Qte_vendue) AS Qte, SUM(Prix_total)  AS TOTAL, Date_vendu from [GS_ALIMENT].[dbo].[Ventes] where Date_vendu ='" + DateVentesjourssyntheses.Text + "' and Officine='" + lblsiteuser.Text + "' GROUP BY Nom_prod, Date_vendu ", conn.con);
            conn.dt1 = new DataTable();
            conn.da.Fill(conn.dt1);
            dataGridSyntesevente.DataSource = conn.dt1;
            conn.con.Close();
        }
        void showclient()
        {
            conn.communication();
            conn.da1 = new SqlDataAdapter("select * FROM [GS_ALIMENT].[dbo].[Clients] WHERE Officine='" + lblsiteuser.Text + "' ", conn.con);
            conn.dt = new DataTable();
            conn.da1.Fill(conn.dt);
            dataclients.DataSource = conn.dt;
            conn.con.Close();
        }
        // Méthode pour enregistrer les clients
        void sauvergarderclient()
        {
            try
            {
                conn.communication();
                conn.cmd2 = new System.Data.SqlClient.SqlCommand();
                conn.cmd2.Connection = conn.con;
                conn.cmd2.CommandType = CommandType.Text;
                conn.cmd2.CommandText = "insert into Clients values('" + Regex.Replace(textnomclient.Text, "'", "''") + "', '" + Regex.Replace(texttelephone.Text, "'", "''") + "','" + Regex.Replace(cmbtypeclient.Text, "'", "''") + "','" + Regex.Replace(DateTime.Now.ToString("yyyy-MM-dd"), "'", "''") + "', '"+lblsiteuser.Text+"')";
                if (conn.cmd2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Client enregistrer avec succès");
                }
                else
                {
                    MessageBox.Show("Opération échouée");
                }
            }
            catch (Exception echp)
            {
                MessageBox.Show(echp.Message.ToString());
            }
        }
        public void SelectClient()
        {
            conn.communication();
            conn.cmd3 = new System.Data.SqlClient.SqlCommand();
            conn.cmd3.CommandText = "SELECT * FROM [GS_ALIMENT].[dbo].[Clients] WHERE Officine='" + lblsiteuser.Text + "'";
            conn.cmd3.Connection = conn.con;
            SqlDataReader myreder;
            try
            {
                myreder = conn.cmd3.ExecuteReader();
                while (myreder.Read())
                {
                    string sname = myreder.GetString(0);
                    comboclient.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Methode pour recuper les client dans vente en credit pour manupuler ses dettes
        public void SelectClientVentecredi()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.CommandText = "SELECT * FROM [GS_ALIMENT].[dbo].[Vente_credit] WHERE Officine='" + lblsiteuser.Text + "'";
            conn.cmd.Connection = conn.con;
            SqlDataReader myreder;
            try
            {
                myreder = conn.cmd.ExecuteReader();
                while (myreder.Read())
                {
                    string sname = myreder.GetString(9);
                    comboclientcredit.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            sauvergarderclient();
            comboclient.Text = "";
            textnomclient.Clear();
            texttelephone.Clear();
        }
        void MethodeInformArticleVenteforme()
        {
            conn.communication();
            conn.cmd1 = new System.Data.SqlClient.SqlCommand();
            conn.cmd1.Connection = conn.con;
            conn.cmd1.CommandType = CommandType.Text;
            conn.cmd1.CommandText = "SELECT [Nom_prod] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + richformes.Text + "'and Officine='" + lblsiteuser.Text + "'";
            conn.dr2 = conn.cmd1.ExecuteReader();
            if (conn.dr2.HasRows)
            {
                listbyforme.Visible = true;
                if (conn.dr2.Read())
                {
                    richformes.Text = conn.dr2["Nom_prod"].ToString();
                }
            }
            else
            {
                richnomprod.Text = "";
                txtprixv.Text = "";
                listbyforme.Visible = false;
            }
            conn.dr2.Close();
        }
        void MethodeAfficheListeBoxVenteforme()
        {
            try
            {
                conn.communication();
                conn.cmd = new System.Data.SqlClient.SqlCommand();
                conn.cmd.Connection = conn.con;
                conn.cmd.CommandType = CommandType.Text;
                if (richformes.Text.Length != 0)
                {
                    listbyforme.Visible = true;
                    //conn.cmd.CommandText = "SELECT distinct(Nom_prod) as Prod FROM [dbo].[Approvisionnements] where Nom_prod like'" + richformes.Text + "%' order by Nom_prod  ASC";
                    conn.cmd.CommandText = "SELECT Nom_prod FROM [dbo].[Approvisionnements] where Famille like'" + richformes.Text + "%' and Officine='" + lblsiteuser.Text + "' order by Famille  ASC";
                    conn.dr = conn.cmd.ExecuteReader();
                    listbyforme.Items.Clear();
                    while (conn.dr.Read())
                    {
                        listbyforme.Items.Add(conn.dr["Nom_prod"]);
                    }
                    conn.dr.Close();
                }
                else
                {
                    listbyforme.Visible = false;
                    listbyforme.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            Engesitrerdatagridventecredit();
        }
        // Affiché le medicament sur le ListBox /////////////////////////
        void MethodeInformArticleVente()
        {
            conn.communication();
            conn.cmd2 = new System.Data.SqlClient.SqlCommand();
            conn.cmd2.Connection = conn.con;
            conn.cmd2.CommandType = CommandType.Text;
            conn.cmd2.CommandText = "SELECT [Qte_sotock]FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + richnomprod.Text + "' and Officine='"+lblsiteuser.Text+"'";
            conn.dr = conn.cmd2.ExecuteReader();
            if (conn.dr.HasRows)
            {
                listBox1vente.Visible = true;
                if (conn.dr.Read())
                {
                    lababaqte.Text = conn.dr["Qte_sotock"].ToString();
                }
            }
            else
            {
                richnomprod.Text = "";
                txtprixv.Text = "";
                listBox1vente.Visible = false;
            }
            conn.dr.Close();
        }
        void MethodeAfficheListeBoxVente()
        {
            try
            {
                conn.communication();
                conn.cmd = new System.Data.SqlClient.SqlCommand();
                conn.cmd.Connection = conn.con;
                conn.cmd.CommandType = CommandType.Text;
                if (richrecherchenomprodby.Text.Length != 0)
                {
                    listBox1vente.Visible = true;
                    conn.cmd.CommandText = "SELECT distinct(Nom_prod) as Prod FROM [dbo].[Approvisionnements] where Nom_prod like'" + richrecherchenomprodby.Text + "%' and Officine='" + lblsiteuser.Text + "' order by Nom_prod  ASC";
                    conn.dr = conn.cmd.ExecuteReader();
                    listBox1vente.Items.Clear();
                    while (conn.dr.Read())
                    {
                        listBox1vente.Items.Add(conn.dr["Prod"]);
                      
                    }
                    conn.dr.Close();
                }
                else
                {
                    listBox1vente.Visible = false;
                    listBox1vente.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }

        // LES LISTEBOX POUR LA PARTIE VERIFICATION DES DANS D'AUTRES SITES DES VENTES
        // SITE DU COIN
        void MethodeInformArticleVentecoin()
        {
            conncoin.communicationcoin();
            conncoin.cmd5 = new System.Data.SqlClient.SqlCommand();
            conncoin.cmd5.Connection = conncoin.concoin;
            conncoin.cmd5.CommandType = CommandType.Text;
            conncoin.cmd5.CommandText = "SELECT [Qte_sotock] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + richBoxarticlecoin.Text + "'and Officine='" + lblsiteuser.Text + "'";
            conncoin.dr5 = conncoin.cmd5.ExecuteReader();
            if (conncoin.dr5.HasRows)
            {
                listBoxcoin.Visible = true;
                if (conncoin.dr5.Read())
                {
                    richboxqtecoin.Text = conncoin.dr5["Qte_sotock"].ToString();
                }
            }
            else
            {
              
                richBoxarticlecoin.Text = "";
                listBoxcoin.Visible = false;
            }
            conncoin.dr5.Close();
        }
        void MethodeAfficheListeBoxVentecoin()
        {
            try
            {
                conncoin.communicationcoin();
                conncoin.cmd5 = new System.Data.SqlClient.SqlCommand();
                conncoin.cmd5.Connection = conncoin.concoin;
                conncoin.cmd5.CommandType = CommandType.Text;
                if (richboxcherchecoin.Text.Length != 0)
                {
                    listBoxcoin.Visible = true;
                    conncoin.cmd5.CommandText = "SELECT distinct(Nom_prod) as Prod FROM [dbo].[Approvisionnements] where Nom_prod like'" + richboxcherchecoin.Text + "%' and Officine='" + lblsiteuser.Text + "' order by Nom_prod  ASC";
                    conncoin.dr5 = conncoin.cmd5.ExecuteReader();
                    listBoxcoin.Items.Clear();
                    while (conncoin.dr5.Read())
                    {
                        listBoxcoin.Items.Add(conncoin.dr5["Prod"]);

                    }
                    conncoin.dr5.Close();
                }
                else
                {
                    listBoxcoin.Visible = false;
                    listBoxcoin.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        // DE LIMETE
        void MethodeInformArticleVentelimete()
        {
            connlimete.communicationlimete();
            connlimete.cmd5 = new System.Data.SqlClient.SqlCommand();
            connlimete.cmd5.Connection = connlimete.conlimete;
            connlimete.cmd5.CommandType = CommandType.Text;
            connlimete.cmd5.CommandText = "SELECT [Qte_sotock] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + richboxarticlelimete.Text + "'";
            connlimete.dr5 = connlimete.cmd5.ExecuteReader();
            if (connlimete.dr5.HasRows)
            {
                listBoxlimete.Visible = true;
                if (connlimete.dr5.Read())
                {
                    richboxqtelimete.Text = connlimete.dr5["Qte_sotock"].ToString();
                }
            }
            else
            {

                richboxarticlelimete.Text = "";
                listBoxlimete.Visible = false;
            }
            connlimete.dr5.Close();
        }
        void MethodeAfficheListeBoxVentelimete()
        {
            try
            {
                connlimete.communicationlimete();
                connlimete.cmd5 = new System.Data.SqlClient.SqlCommand();
                connlimete.cmd5.Connection = connlimete.conlimete;
                connlimete.cmd5.CommandType = CommandType.Text;
                if (richrecherchelimete.Text.Length != 0)
                {
                    listBoxlimete.Visible = true;
                    connlimete.cmd5.CommandText = "SELECT distinct(Nom_prod) as Prod FROM [dbo].[Approvisionnements] where Nom_prod like'" + richrecherchelimete.Text + "%'and Officine='" + lblsiteuser.Text + "' order by Nom_prod  ASC";
                    connlimete.dr5 = connlimete.cmd5.ExecuteReader();
                    listBoxlimete.Items.Clear();
                    while (connlimete.dr5.Read())
                    {
                        listBoxlimete.Items.Add(connlimete.dr5["Prod"]);

                    }
                    connlimete.dr5.Close();
                }
                else
                {
                    listBoxlimete.Visible = false;
                    listBoxlimete.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        // DE BEATRICE
        void MethodeInformArticleVentebeatrice()
        {
            connbeatrice.communicationbeatrice();
            connbeatrice.cmd7 = new System.Data.SqlClient.SqlCommand();
            connbeatrice.cmd7.Connection = connbeatrice.conbeatrice;
            connbeatrice.cmd7.CommandType = CommandType.Text;
            connbeatrice.cmd7.CommandText = "SELECT [Qte_sotock] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + richboxarticlebeatrice.Text + "'";
            connbeatrice.dr7= connbeatrice.cmd7.ExecuteReader();
            if (connbeatrice.dr7.HasRows)
            {
                listBoxbeatrice.Visible = true;
                if (connbeatrice.dr7.Read())
                {
                    richboxqtebeatrice.Text = connbeatrice.dr7["Qte_sotock"].ToString();
                }
            }
            else
            {

                richboxarticlebeatrice.Text = "";
                listBoxbeatrice.Visible = false;
            }
            connbeatrice.dr7.Close();
        }
        void MethodeAfficheListeBoxVentebeatrice()
        {
            try
            {
                connbeatrice.communicationbeatrice();
                connbeatrice.cmd7 = new System.Data.SqlClient.SqlCommand();
                connbeatrice.cmd7.Connection = connbeatrice.conbeatrice;
                connbeatrice.cmd7.CommandType = CommandType.Text;
                if (richboxcherchebeatrice.Text.Length != 0)
                {
                    listBoxbeatrice.Visible = true;
                    connbeatrice.cmd7.CommandText = "SELECT distinct(Nom_prod) as Prod FROM [dbo].[Approvisionnements] where Nom_prod like'" + richboxcherchebeatrice.Text + "%' order by Nom_prod  ASC";
                    connbeatrice.dr7 = connbeatrice.cmd7.ExecuteReader();
                    listBoxbeatrice.Items.Clear();
                    while (connbeatrice.dr7.Read())
                    {
                        listBoxbeatrice.Items.Add(connbeatrice.dr7["Prod"]);

                    }
                    connbeatrice.dr7.Close();
                }
                else
                {
                    listBoxbeatrice.Visible = false;
                    listBoxbeatrice.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        private void richrecherchenomprodby_TextChanged(object sender, EventArgs e)
        {
            if (richrecherchenomprodby.Text == "")
            {
                richrecherchenomprodby.Focus();
                listBox1vente.Visible = false;
            }
            else
            {
                MethodeInformArticleVente();
                MethodeAfficheListeBoxVente();
            }
        }
        // DE NEW
        void MethodeInformArticleVentenew()
        {
            connnew.communicationnew();
            connnew.cmd6 = new System.Data.SqlClient.SqlCommand();
            connnew.cmd6.Connection = connnew.connew;
            connnew.cmd6.CommandType = CommandType.Text;
            connnew.cmd6.CommandText = "SELECT [Qte_sotock] FROM [GS_ALIMENT].[dbo].[Approvisionnements] where Nom_prod ='" + richboxarticlenew.Text + "'";
            connnew.dr6 = connnew.cmd6.ExecuteReader();
            if (connnew.dr6.HasRows)
            {
                listBoxnew.Visible = true;
                if (connnew.dr6.Read())
                {
                    richboxqtenew.Text = connnew.dr6["Qte_sotock"].ToString();
                }
            }
            else
            {

                richboxarticlenew.Text = "";
                listBoxnew.Visible = false;
            }
            connnew.dr6.Close();
        }
        void MethodeAfficheListeBoxVentenew()
        {
            try
            {
                connnew.communicationnew();
                connnew.cmd6 = new System.Data.SqlClient.SqlCommand();
                connnew.cmd6.Connection = connnew.connew;
                connnew.cmd6.CommandType = CommandType.Text;
                if (richboxrecherchenew.Text.Length != 0)
                {
                    listBoxnew.Visible = true;
                    connnew.cmd6.CommandText = "SELECT distinct(Nom_prod) as Prod FROM [dbo].[Approvisionnements] where Nom_prod like'" + richboxrecherchenew.Text + "%' order by Nom_prod  ASC";
                    connnew.dr6 = connnew.cmd6.ExecuteReader();
                    listBoxnew.Items.Clear();
                    while (connnew.dr6.Read())
                    {
                        listBoxnew.Items.Add(connnew.dr6["Prod"]);

                    }
                    connnew.dr6.Close();
                }
                else
                {
                    listBoxnew.Visible = false;
                    listBoxnew.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
        private void listBox1vente_SelectedIndexChanged(object sender, EventArgs e)
        {
            richnomprod.Text = Convert.ToString(listBox1vente.SelectedItem);
            Calculmodulo();
            listBox1vente.Visible = false;
            txtqteve.Focus();
        }
        private void dateExpiration_ValueChanged(object sender, EventArgs e)
        {
        }
        private void Listeapprovisionnement_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        void Selectionnersommeclientcredit()
        {
            conn.communication();
            conn.cmd = new System.Data.SqlClient.SqlCommand();
            conn.cmd.Connection = conn.con;
            conn.cmd.CommandType = CommandType.Text;
            conn.cmd.CommandText = "select sum(Prix_total)Prix_total from [GS_ALIMENT].[dbo].[Vente_credit] WHERE Client='" + comboclientcredit.Text + "'and Officine='" + lblsiteuser.Text + "'";
            conn.dr1 = conn.cmd.ExecuteReader();
            while (conn.dr1.Read())
            {
                lblcreditclientsommes.Text = Convert.ToString(conn.dr1["Prix_total"].ToString());
            }
            conn.dr1.Close();
        }
        private void comboclientcredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selectionnersommeclientcredit();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void DateVentejoursynthese_ValueChanged(object sender, EventArgs e)
        {
            ShowsumVentejournalier();
        }

        private void textnomartapprv_TextChanged(object sender, EventArgs e)
        {
            this.textnomartapprv.SelectionStart = this.textnomartapprv.Text.Length;
            if (textnomartapprv.Text == "")
            {
                textnomartapprv.Focus();
                listAddqte.Visible = false;
            }
            else
            {
                MethodeInformArticleqteaprovis();
                MethodeAfficheListeBoxqteapprov();
            }
        }
        private void txtnomartprof_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtarticless_TextChanged(object sender, EventArgs e)
        {

        }

        private void listboxAdqte_SelectedIndexChanged(object sender, EventArgs e)
        {
            textnomartapprv.Text = Convert.ToString(listAddqte.SelectedItem);
            listAddqte.Visible = false;
        }

        private void textboxrechercheartAdqte_TextChanged(object sender, EventArgs e)
        {
            if (textnomartapprv.Text == "")
            {
                textnomartapprv.Focus();
                listAddqte.Visible = false;
            }
            else
            {
                MethodeInformArticleqteaprovis();
                MethodeAfficheListeBoxqteapprov();
            }
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void daterpjournalier_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleprintevente_Click(object sender, EventArgs e)
        {
           // Joursouhaiter();
            Printesynthesevente();
        }

        private void simpleDeletevente_Click(object sender, EventArgs e)
        {
            Supprimerrpjpour();
        }
        private void Btnprintesynthese_Click(object sender, EventArgs e)
        {
            ExporteSynthesevente();
        }
      
        private void txtqtestockprof_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnsupnoteretour_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnminimised_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textrecheproforma_TextChanged(object sender, EventArgs e)
        {
            conn.communication();
            conn.da = new SqlDataAdapter("select [Nom_prod],[PV],[Qte_vendue],[Prix_total],[Date_enre],[Qte_dispo],[Numprofo] FROM [GS_ALIMENT].[dbo].[Proforma] where Numprofo LIKE '" + textrecheproforma.Text + "%' and Officine='" + lblsiteuser.Text + "'", conn.con);
            conn.dt2 = new DataTable();
            conn.da.Fill(conn.dt2);
            datamodifProforma.DataSource = conn.dt2;
            conn.con.Close();
        }

        private void txtrecupeprintefactute_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnrecover_Click(object sender, EventArgs e)
        {
            Factureencours();
        }

        private void radiocoloried_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radiousdconvertapprov_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radiousdconvertapprov_CheckedChanged_1(object sender, EventArgs e)
        {
            convertssionfondapprovisionnement();
        }

        private void daterapportjournalier_ValueChanged(object sender, EventArgs e)
        {
            conn.communication();
            conn.da = new SqlDataAdapter(" SELECT Nom_prod, SUM(Qte_vendue) AS Qte, SUM(Prix_total)  AS TOTAL, Date_vendu FROM [GS_ALIMENT].[dbo].[Ventes] WHERE Date_vendu between '" + datecontrolejournalier.Value + "' and '" + daterapportjournalier.Value + "' and Officine='" + lblsiteuser.Text + "' GROUP BY Nom_prod, Date_vendu ", conn.con);
            conn.dt = new DataTable();
            conn.da.Fill(conn.dt);
            datavente.DataSource = conn.dt;
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnsuppapprov_Click(object sender, EventArgs e)
        {
            DeleteApprovStatistique();
        }
        private void ExporteSynthesevente()
        {
            if (dataGridSyntesevente.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Synthese_Ventes.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception dav)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Impossible d'enregistrer les données dans Disk" + dav.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable ptable = new PdfPTable(dataGridSyntesevente.Columns.Count);
                            ptable.DefaultCell.Padding = 2;
                            ptable.WidthPercentage = 100;
                            ptable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dataGridSyntesevente.Columns)
                            {
                                PdfPCell pcelle = new PdfPCell(new Phrase(col.HeaderText));
                                ptable.AddCell(pcelle);
                            }
                            foreach (DataGridViewRow viewRow in dataGridSyntesevente.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    ptable.AddCell(dcell.Value.ToString());
                                }
                            }
                            using (FileStream filestream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                document.Open();
                                document.Add(ptable);
                                MessageBox.Show("Exportation terminer", "Synthese_Ventes");
                                document.Close();
                                filestream.Close();
                            }

                        }
                        catch (Exception dav)
                        {
                            MessageBox.Show("Erreur lors de l'exporation des données" + dav.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Le tableau est vide, il y a pas moyen d'exporter le données", "Synthese_Ventes");
            }
        }
        // Exportation des articles en préremption via dataGride
        void exportertopdf()
        {
            if (dataGridpreremption.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Preremption.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception dav)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Impossible d'enregistrer les données dans Disk" + dav.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable ptable = new PdfPTable(dataGridpreremption.Columns.Count);
                            ptable.DefaultCell.Padding = 12;
                            ptable.WidthPercentage = 100;
                            ptable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dataGridpreremption.Columns)
                            {
                                PdfPCell pcelle = new PdfPCell(new Phrase(col.HeaderText));
                                ptable.AddCell(pcelle);
                            }
                            foreach (DataGridViewRow viewRow in dataGridpreremption.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    ptable.AddCell(dcell.Value.ToString());
                                }
                            }
                            using (FileStream filestream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                document.Open();
                                document.Add(ptable);
                                MessageBox.Show("Exportation terminer", "Preremption");
                                document.Close();
                                filestream.Close();
                            }
                        }
                        catch (Exception dav)
                        {
                            MessageBox.Show("Erreur lors de l'exporation des données" + dav.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Le tableau est vide, il y a pas moyen d'exporter le données", "Préremption");
            } 
        }
        private void Nextpage()
        {
            scr_val = scr_val + 25;
            if (scr_val > 90000 )
            {
                scr_val = 0;
                btnnext.Enabled = false;
            }
            conn.ds.Clear();
            conn.da.Fill(conn.ds, scr_val, 25, "Approvisionnements");
            lblnbrofpage.Text = "Page " + (scr_val + 1);
        }
        private void Prevouispage()
        {
            scr_val = scr_val - 25;
            if (scr_val < 0)
            //if (scr_val <=0 int.Parse(lblnbrepage.Text))
            {
                scr_val = 0;
                btnprevouis.Enabled = false;
            }
            conn.ds.Clear();
            conn.da.Fill(conn.ds, scr_val, 25, "Approvisionnements");
            lblnbrofpage.Text = "Page " + (scr_val + 1);
           
        }
        // FICHE DE STOCK
        private void Nextpagefichestock()
        {
            scr_david = scr_david + 25;
            if (scr_david > 90000)
            {
                scr_david = 0;
                btnnextstock.Enabled = false;
            }
            conn.ds1.Clear();
            conn.da1.Fill(conn.ds1, scr_david, 25, "Approvisionnements");
            lbltotalfichstock.Text = "Page " + (scr_david + 1);
        }
        private void Prevouispagefichestock()
        {
            scr_david = scr_david - 25;
            if (scr_david < 0)
            {
                scr_david = 0;
                btnpreviwsstock.Enabled = false;
            }
            conn.ds1.Clear();
            conn.da1.Fill(conn.ds1, scr_david, 25, "Approvisionnements");
            lbltotalfichstock.Text = "Page " + (scr_david + 1);

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            Nextpage();
            Rowscolor();
        }

        private void btnprevouis_Click(object sender, EventArgs e)
        {
            Prevouispage();
            Rowscolor();
        }

        private void txtinputapprov_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnradioexporterpdf_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void txtpa_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if((e.KeyChar=='.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled=true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //exportertopdf();
            PrinteDatagridePreremption();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Rowscolorexpirearticle();
        }

        private void txtqtesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textqteaprovstock_TextChanged(object sender, EventArgs e)
        {

        }

        private void textqteaprovstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtprixventemodif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textqreajout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void richfranc_TextChanged(object sender, EventArgs e)
        {

        }

        private void richfranc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void richdollars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textrechfact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtqteprof_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtrequisition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnleft_Click(object sender, EventArgs e)
        {
        
        }

        private void btnright_Click(object sender, EventArgs e)
        {
        
        }
        void PrinteDatagridePreremption()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " ** LISTE DES ARTICLES EN PREREMPTION ** ";
            printer.SubTitle = string.Format("Date de l'impression :{0}", DateTime.Now.Date.ToString("yyyy/mm/dd"));
            //printer.SubTitleFormatFlag = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = false;
            printer.PageNumbersInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "*PHARMACIE *" + lblsiteuser.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridpreremption);
        }
        void Printesynthesevente()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " ** SYNTHESE DES VENTES ** ";
            printer.SubTitle = string.Format("Date de l'impression :{0}", DateTime.Now.Date.ToString("yyyy/mm/dd"));
            //printer.SubTitleFormatFlag = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = false;
            printer.PageNumbersInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = " * PHARMACIE *"+ lblsiteuser.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(datavente);
            //dataGridpreremption.Size = new Size(200, 20);

        }
        void Printesdepenses()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " ** LISTE DES DEPENSES ** ";
            printer.SubTitle = string.Format("Date de l'impression :{0}", DateTime.Now.Date.ToString("yyyy/mm/dd"));
            printer.PageNumbers = false;
            printer.PageNumbersInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = " * PHARMACIE *" + lblsiteuser.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(listedepenses);
        }
        void Printeruptureenstock()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " ** LISTE DES ARTICLES EN RUPTURE DES STOCKS ** ";
            printer.SubTitle = string.Format("Date de l'impression :{0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            //printer.SubTitleFormatFlag = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = false;
            printer.PageNumbersInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "* PHARMACIE *" + lblsiteuser.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(listeaaprov);
        }
        void PrinterProformatopdf()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " ** FACTURE PROFORMA ** ";
            printer.SubTitle = string.Format("Date de l'impression :{0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.PageNumbers = false;
            printer.PageNumbersInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "* PHARMACIE *" + lblsiteuser.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridpanierproforma);
        }
        void PrinterListeclientpdf()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " ** LISTE DES CLIENT ** ";
            printer.SubTitle = string.Format("Date de l'impression :{0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.PageNumbers = false;
            printer.PageNumbersInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "* PHARMACIE *" + lblsiteuser.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataclients);
        }
        private void datecontrolejournalier_ValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            Printesdepenses();
        }

        private void datedepcontrole_ValueChanged(object sender, EventArgs e)
        {
            // Méthode pour afficher les dépenses automaiquement dans le datagride
            conn.communication();
            conn.da = new SqlDataAdapter("SELECT * FROM [dbo].[Depense_prod] WHERE Datedepense between '" + datedepdebut.Value + "' and '" + datedepcontrole.Value + "'and Officine='" + lblsiteuser.Text + "' ORDER BY Nom_Agent ", conn.con);
            conn.dt = new DataTable();
            conn.da.Fill(conn.dt);
            listedepenses.DataSource = conn.dt;
            conn.con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Printeruptureenstock();
        }

        private void txtmofiproforma_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnexporteproformat_Click(object sender, EventArgs e)
        {
            PrinterProformatopdf();
        } 
        private void button10_Click(object sender, EventArgs e)
        {
            PrinterListeclientpdf();
        }

        private void fichsstocknexte_Click(object sender, EventArgs e)
        {
          
        }

        private void btnnextstock_Click(object sender, EventArgs e)
        {
            Nextpagefichestock();
        }

        private void btnpreviwsstock_Click(object sender, EventArgs e)
        {
            Prevouispagefichestock();
        }

        private void richboxcherchecoin_TextChanged(object sender, EventArgs e)
        {
            if (richboxcherchecoin.Text == "")
            {
                richboxcherchecoin.Focus();
                listBoxcoin.Visible = false;
            }
            else
            {
                MethodeInformArticleVentecoin();
                MethodeAfficheListeBoxVentecoin();
            }
        }

        private void listBoxcoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            richBoxarticlecoin.Text = Convert.ToString(listBoxcoin.SelectedItem);
           // Calculmodulo();
            listBoxcoin.Visible = false;
        }

        private void richBoxarticlecoin_TextChanged(object sender, EventArgs e)
        {
            recustockdispocoin();
        }

        private void richrecherchelimete_TextChanged(object sender, EventArgs e)
        {
            if (richrecherchelimete.Text == "")
            {
                richrecherchelimete.Focus();
                listBoxlimete.Visible = false;
            }
            else
            {
                MethodeInformArticleVentelimete();
                MethodeAfficheListeBoxVentelimete();
              
            }
        }

        private void richboxarticlelimete_TextChanged(object sender, EventArgs e)
        {
            recustockdispolimete();
        }

        private void richboxarticlebeatrice_TextChanged(object sender, EventArgs e)
        {
            recustockdispobeatrice();
        }

        private void richboxarticlenew_TextChanged(object sender, EventArgs e)
        {
            recustockdisponew();
        }

        private void listBoxlimete_SelectedIndexChanged(object sender, EventArgs e)
        {
            richboxarticlelimete.Text = Convert.ToString(listBoxlimete.SelectedItem);
            // Calculmodulo();
            listBoxlimete.Visible = false;
        }

        private void richboxcherchebeatrice_TextChanged(object sender, EventArgs e)
        {
            if (richboxcherchebeatrice.Text == "")
            {
                richboxcherchebeatrice.Focus();
                listBoxbeatrice.Visible = false;
            }
            else
            {
                MethodeInformArticleVentebeatrice();
                MethodeAfficheListeBoxVentebeatrice();

            }
        }

        private void listBoxbeatrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            richboxarticlebeatrice.Text = Convert.ToString(listBoxbeatrice.SelectedItem);
            // Calculmodulo();
            listBoxbeatrice.Visible = false;
        }

        private void listBoxnew_SelectedIndexChanged(object sender, EventArgs e)
        {
            richboxarticlenew.Text = Convert.ToString(listBoxnew.SelectedItem);
            // Calculmodulo();
            listBoxnew.Visible = false;
        }

        private void richboxrecherchenew_TextChanged(object sender, EventArgs e)
        {
            if (richboxrecherchenew.Text == "")
            {
                richboxrecherchenew.Focus();
                listBoxnew.Visible = false;
            }
            else
            {
                MethodeInformArticleVentenew();
                MethodeAfficheListeBoxVentenew();
            }
        }
        void recherticleifiexisteapprov()
        {
            {
                conn.communication();
                conn.da1 = new SqlDataAdapter("select * FROM [dbo].[Approvisionnements] where Nom_prod like '" + txtrecherchearticle.Text + "%' and Officine='" + lblsiteuser.Text + "'", conn.con);
                conn.dt2 = new DataTable();
                conn.da1.Fill(conn.dt2);
                Listeapprovisionnement.DataSource = conn.dt2;
                conn.con.Close();
            }
        }
        private void richarticleifexiste_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
 