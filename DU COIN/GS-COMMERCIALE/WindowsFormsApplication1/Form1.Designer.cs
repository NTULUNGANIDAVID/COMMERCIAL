namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.combosite = new System.Windows.Forms.ComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.code = new System.Windows.Forms.TextBox();
            this.statut = new System.Windows.Forms.ComboBox();
            this.nom = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnquitter = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtmodifmodulo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtvalider = new System.Windows.Forms.TextBox();
            this.txtfree = new System.Windows.Forms.TextBox();
            this.txtfour = new System.Windows.Forms.TextBox();
            this.txton = new System.Windows.Forms.TextBox();
            this.txttwo = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(120, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "00";
            this.label7.Visible = false;
            // 
            // combosite
            // 
            this.combosite.BackColor = System.Drawing.Color.White;
            this.combosite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combosite.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combosite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.combosite.FormattingEnabled = true;
            this.combosite.Location = new System.Drawing.Point(19, 109);
            this.combosite.Name = "combosite";
            this.combosite.Size = new System.Drawing.Size(200, 27);
            this.combosite.TabIndex = 4;
            this.combosite.Text = "Selectionnez ici";
            this.combosite.SelectedIndexChanged += new System.EventHandler(this.combosite_SelectedIndexChanged);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Location = new System.Drawing.Point(150, 338);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(200, 1);
            this.panel10.TabIndex = 7;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Location = new System.Drawing.Point(0, 40);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 1);
            this.panel11.TabIndex = 6;
            // 
            // code
            // 
            this.code.BackColor = System.Drawing.Color.White;
            this.code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.code.Cursor = System.Windows.Forms.Cursors.Hand;
            this.code.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.code.Location = new System.Drawing.Point(20, 46);
            this.code.MaxLength = 8;
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(200, 23);
            this.code.TabIndex = 2;
            this.code.Text = "Mot de pass";
            this.code.Click += new System.EventHandler(this.code_Click);
            this.code.TextChanged += new System.EventHandler(this.code_TextChanged);
            // 
            // statut
            // 
            this.statut.BackColor = System.Drawing.Color.White;
            this.statut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statut.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.statut.FormattingEnabled = true;
            this.statut.Items.AddRange(new object[] {
            "PHARMACIEN",
            "ADMIN",
            "SUPPORT"});
            this.statut.Location = new System.Drawing.Point(19, 76);
            this.statut.Name = "statut";
            this.statut.Size = new System.Drawing.Size(200, 27);
            this.statut.TabIndex = 3;
            this.statut.Text = "Selectionnez ici";
            this.statut.Click += new System.EventHandler(this.statut_Click);
            // 
            // nom
            // 
            this.nom.BackColor = System.Drawing.Color.White;
            this.nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nom.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.nom.Location = new System.Drawing.Point(19, 11);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(203, 28);
            this.nom.TabIndex = 1;
            this.nom.Text = "Nom d\'utilisateur";
            this.nom.Click += new System.EventHandler(this.nom_Click);
            this.nom.TextChanged += new System.EventHandler(this.nom_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(5, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "DD-MM-YYY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(64, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "AUTHENTIFICATION ";
            // 
            // btnquitter
            // 
            this.btnquitter.FlatAppearance.BorderSize = 0;
            this.btnquitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnquitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnquitter.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnquitter.ForeColor = System.Drawing.Color.Transparent;
            this.btnquitter.Location = new System.Drawing.Point(383, 2);
            this.btnquitter.Name = "btnquitter";
            this.btnquitter.Size = new System.Drawing.Size(34, 34);
            this.btnquitter.TabIndex = 11;
            this.btnquitter.Text = "X";
            this.btnquitter.UseVisualStyleBackColor = true;
            this.btnquitter.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.BorderColor = System.Drawing.Color.Green;
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseBorderColor = true;
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(14, 103);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(194, 36);
            this.simpleButton3.TabIndex = 2;
            this.simpleButton3.Text = "Créer Compte";
            this.simpleButton3.ToolTip = "uniquement pour l\'administrateur";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseBorderColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(14, 60);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(194, 34);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Annuler ";
            this.simpleButton2.ToolTip = "Annuler l\'opération";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(14, 14);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(194, 33);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Se Connecter";
            this.simpleButton1.ToolTip = "Connecter ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(38, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(373, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Le mot de pass ne doit pas dépassé 8 caractères svp !!!";
            // 
            // txtmodifmodulo
            // 
            this.txtmodifmodulo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmodifmodulo.Location = new System.Drawing.Point(299, 306);
            this.txtmodifmodulo.Name = "txtmodifmodulo";
            this.txtmodifmodulo.Size = new System.Drawing.Size(135, 30);
            this.txtmodifmodulo.TabIndex = 11;
            this.txtmodifmodulo.Visible = false;
            this.txtmodifmodulo.TextChanged += new System.EventHandler(this.txtmodifmodulo_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(438, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(67, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "PHARMACIE DU COIN";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.txtvalider);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtfree);
            this.panel4.Controls.Add(this.txtfour);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.txton);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txttwo);
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtmodifmodulo);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Location = new System.Drawing.Point(653, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(485, 361);
            this.panel4.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnquitter);
            this.panel2.Location = new System.Drawing.Point(66, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 37);
            this.panel2.TabIndex = 18;
            // 
            // txtvalider
            // 
            this.txtvalider.BackColor = System.Drawing.Color.Green;
            this.txtvalider.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtvalider.Location = new System.Drawing.Point(455, 0);
            this.txtvalider.MaxLength = 1;
            this.txtvalider.Name = "txtvalider";
            this.txtvalider.PasswordChar = '*';
            this.txtvalider.Size = new System.Drawing.Size(27, 33);
            this.txtvalider.TabIndex = 5;
            this.txtvalider.Click += new System.EventHandler(this.txtvalider_Click);
            this.txtvalider.TextChanged += new System.EventHandler(this.txtvalider_TextChanged_1);
            // 
            // txtfree
            // 
            this.txtfree.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtfree.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtfree.Location = new System.Drawing.Point(399, 0);
            this.txtfree.MaxLength = 1;
            this.txtfree.Name = "txtfree";
            this.txtfree.PasswordChar = '*';
            this.txtfree.Size = new System.Drawing.Size(27, 33);
            this.txtfree.TabIndex = 3;
            this.txtfree.Click += new System.EventHandler(this.txtfree_Click);
            // 
            // txtfour
            // 
            this.txtfour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtfour.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtfour.Location = new System.Drawing.Point(427, 0);
            this.txtfour.MaxLength = 1;
            this.txtfour.Name = "txtfour";
            this.txtfour.PasswordChar = '*';
            this.txtfour.Size = new System.Drawing.Size(27, 33);
            this.txtfour.TabIndex = 4;
            this.txtfour.Click += new System.EventHandler(this.txtfour_Click);
            this.txtfour.TextChanged += new System.EventHandler(this.txtvalider_TextChanged);
            // 
            // txton
            // 
            this.txton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txton.Location = new System.Drawing.Point(343, 0);
            this.txton.MaxLength = 1;
            this.txton.Name = "txton";
            this.txton.PasswordChar = '*';
            this.txton.Size = new System.Drawing.Size(27, 33);
            this.txton.TabIndex = 1;
            this.txton.Click += new System.EventHandler(this.txton_Click);
            // 
            // txttwo
            // 
            this.txttwo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txttwo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttwo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txttwo.Location = new System.Drawing.Point(371, 0);
            this.txttwo.MaxLength = 1;
            this.txttwo.Name = "txttwo";
            this.txttwo.PasswordChar = '*';
            this.txttwo.Size = new System.Drawing.Size(27, 33);
            this.txttwo.TabIndex = 2;
            this.txttwo.Click += new System.EventHandler(this.txttwo_Click);
            this.txttwo.TextChanged += new System.EventHandler(this.txttwo_TextChanged);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DarkCyan;
            this.panel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel8.BackgroundImage")));
            this.panel8.Location = new System.Drawing.Point(0, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(652, 551);
            this.panel8.TabIndex = 12;
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.nom);
            this.groupBox1.Controls.Add(this.statut);
            this.groupBox1.Controls.Add(this.combosite);
            this.groupBox1.Controls.Add(this.code);
            this.groupBox1.Location = new System.Drawing.Point(669, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 145);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Location = new System.Drawing.Point(19, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 14;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Location = new System.Drawing.Point(0, 40);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(200, 1);
            this.panel12.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Location = new System.Drawing.Point(22, 104);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 1);
            this.panel7.TabIndex = 14;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(0, 40);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 1);
            this.panel9.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel6.Location = new System.Drawing.Point(21, 72);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 1);
            this.panel6.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel5.Location = new System.Drawing.Point(22, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 1);
            this.panel5.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.simpleButton2);
            this.groupBox2.Controls.Add(this.simpleButton1);
            this.groupBox2.Controls.Add(this.simpleButton3);
            this.groupBox2.Location = new System.Drawing.Point(905, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 145);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1138, 550);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel4);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox code;
        public System.Windows.Forms.ComboBox statut;
        private System.Windows.Forms.RichTextBox nom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btnquitter;
        public System.Windows.Forms.ComboBox combosite;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtmodifmodulo;
        private System.Windows.Forms.TextBox txtfree;
        private System.Windows.Forms.TextBox txtfour;
        private System.Windows.Forms.TextBox txton;
        private System.Windows.Forms.TextBox txttwo;
        private System.Windows.Forms.TextBox txtvalider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

