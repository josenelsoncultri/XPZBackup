namespace XPZBackup
{
    partial class frmXPZBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXPZBackup));
            this.tabConfiguracoes = new System.Windows.Forms.TabControl();
            this.tabBases = new System.Windows.Forms.TabPage();
            this.btnTrocarVersao = new System.Windows.Forms.Button();
            this.cmbVersaoGeneXus = new System.Windows.Forms.ComboBox();
            this.chkBackupKBInteira = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBaseParaAdicionar = new System.Windows.Forms.TextBox();
            this.btnAdicionarBase = new System.Windows.Forms.Button();
            this.dgvBases = new System.Windows.Forms.DataGridView();
            this.tabSQLServer = new System.Windows.Forms.TabPage();
            this.chkAutenticacaoWindows = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.tabOutrosParametros = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiasParaBackup = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCaminhoBackup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCaminhoSalvarXPZ = new System.Windows.Forms.TextBox();
            this.btnExecutarBackup = new System.Windows.Forms.Button();
            this.tabConfiguracoes.SuspendLayout();
            this.tabBases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBases)).BeginInit();
            this.tabSQLServer.SuspendLayout();
            this.tabOutrosParametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConfiguracoes
            // 
            this.tabConfiguracoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabConfiguracoes.Controls.Add(this.tabBases);
            this.tabConfiguracoes.Controls.Add(this.tabSQLServer);
            this.tabConfiguracoes.Controls.Add(this.tabOutrosParametros);
            this.tabConfiguracoes.Location = new System.Drawing.Point(12, 12);
            this.tabConfiguracoes.Name = "tabConfiguracoes";
            this.tabConfiguracoes.SelectedIndex = 0;
            this.tabConfiguracoes.Size = new System.Drawing.Size(917, 463);
            this.tabConfiguracoes.TabIndex = 0;
            // 
            // tabBases
            // 
            this.tabBases.Controls.Add(this.btnTrocarVersao);
            this.tabBases.Controls.Add(this.cmbVersaoGeneXus);
            this.tabBases.Controls.Add(this.chkBackupKBInteira);
            this.tabBases.Controls.Add(this.label4);
            this.tabBases.Controls.Add(this.txtBaseParaAdicionar);
            this.tabBases.Controls.Add(this.btnAdicionarBase);
            this.tabBases.Controls.Add(this.dgvBases);
            this.tabBases.Location = new System.Drawing.Point(4, 22);
            this.tabBases.Name = "tabBases";
            this.tabBases.Padding = new System.Windows.Forms.Padding(3);
            this.tabBases.Size = new System.Drawing.Size(909, 437);
            this.tabBases.TabIndex = 0;
            this.tabBases.Text = "Configurações das bases";
            this.tabBases.UseVisualStyleBackColor = true;
            // 
            // btnTrocarVersao
            // 
            this.btnTrocarVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrocarVersao.Location = new System.Drawing.Point(740, 392);
            this.btnTrocarVersao.Name = "btnTrocarVersao";
            this.btnTrocarVersao.Size = new System.Drawing.Size(163, 27);
            this.btnTrocarVersao.TabIndex = 5;
            this.btnTrocarVersao.Text = "Trocar versão das bases";
            this.btnTrocarVersao.UseVisualStyleBackColor = true;
            this.btnTrocarVersao.Click += new System.EventHandler(this.btnTrocarVersao_Click);
            // 
            // cmbVersaoGeneXus
            // 
            this.cmbVersaoGeneXus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbVersaoGeneXus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersaoGeneXus.FormattingEnabled = true;
            this.cmbVersaoGeneXus.Items.AddRange(new object[] {
            "GeneXus 15",
            "GeneXus 16"});
            this.cmbVersaoGeneXus.Location = new System.Drawing.Point(142, 367);
            this.cmbVersaoGeneXus.Name = "cmbVersaoGeneXus";
            this.cmbVersaoGeneXus.Size = new System.Drawing.Size(121, 21);
            this.cmbVersaoGeneXus.TabIndex = 4;
            // 
            // chkBackupKBInteira
            // 
            this.chkBackupKBInteira.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBackupKBInteira.AutoSize = true;
            this.chkBackupKBInteira.Location = new System.Drawing.Point(9, 369);
            this.chkBackupKBInteira.Name = "chkBackupKBInteira";
            this.chkBackupKBInteira.Size = new System.Drawing.Size(127, 17);
            this.chkBackupKBInteira.TabIndex = 2;
            this.chkBackupKBInteira.Text = "Backup da KB Inteira";
            this.chkBackupKBInteira.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Base para adicionar:";
            // 
            // txtBaseParaAdicionar
            // 
            this.txtBaseParaAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseParaAdicionar.Location = new System.Drawing.Point(6, 343);
            this.txtBaseParaAdicionar.Name = "txtBaseParaAdicionar";
            this.txtBaseParaAdicionar.Size = new System.Drawing.Size(897, 20);
            this.txtBaseParaAdicionar.TabIndex = 1;
            // 
            // btnAdicionarBase
            // 
            this.btnAdicionarBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdicionarBase.Location = new System.Drawing.Point(6, 392);
            this.btnAdicionarBase.Name = "btnAdicionarBase";
            this.btnAdicionarBase.Size = new System.Drawing.Size(98, 27);
            this.btnAdicionarBase.TabIndex = 3;
            this.btnAdicionarBase.Text = "Adicionar Base";
            this.btnAdicionarBase.UseVisualStyleBackColor = true;
            this.btnAdicionarBase.Click += new System.EventHandler(this.btnAdicionarBase_Click);
            // 
            // dgvBases
            // 
            this.dgvBases.AllowUserToAddRows = false;
            this.dgvBases.AllowUserToDeleteRows = false;
            this.dgvBases.AllowUserToOrderColumns = true;
            this.dgvBases.AllowUserToResizeColumns = false;
            this.dgvBases.AllowUserToResizeRows = false;
            this.dgvBases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBases.Location = new System.Drawing.Point(6, 6);
            this.dgvBases.Name = "dgvBases";
            this.dgvBases.ReadOnly = true;
            this.dgvBases.Size = new System.Drawing.Size(897, 303);
            this.dgvBases.TabIndex = 0;
            this.dgvBases.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBases_RowHeaderMouseDoubleClick);
            // 
            // tabSQLServer
            // 
            this.tabSQLServer.Controls.Add(this.chkAutenticacaoWindows);
            this.tabSQLServer.Controls.Add(this.label3);
            this.tabSQLServer.Controls.Add(this.txtSenha);
            this.tabSQLServer.Controls.Add(this.label2);
            this.tabSQLServer.Controls.Add(this.txtUsuario);
            this.tabSQLServer.Controls.Add(this.label1);
            this.tabSQLServer.Controls.Add(this.txtServidor);
            this.tabSQLServer.Location = new System.Drawing.Point(4, 22);
            this.tabSQLServer.Name = "tabSQLServer";
            this.tabSQLServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQLServer.Size = new System.Drawing.Size(909, 437);
            this.tabSQLServer.TabIndex = 1;
            this.tabSQLServer.Text = "Configurações do SQL Server";
            this.tabSQLServer.UseVisualStyleBackColor = true;
            // 
            // chkAutenticacaoWindows
            // 
            this.chkAutenticacaoWindows.AutoSize = true;
            this.chkAutenticacaoWindows.Location = new System.Drawing.Point(10, 127);
            this.chkAutenticacaoWindows.Name = "chkAutenticacaoWindows";
            this.chkAutenticacaoWindows.Size = new System.Drawing.Size(151, 17);
            this.chkAutenticacaoWindows.TabIndex = 3;
            this.chkAutenticacaoWindows.Text = "Autenticação do Windows";
            this.chkAutenticacaoWindows.UseVisualStyleBackColor = true;
            this.chkAutenticacaoWindows.CheckedChanged += new System.EventHandler(this.chkAutenticacaoWindows_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Senha:";
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSenha.Location = new System.Drawing.Point(6, 101);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(897, 20);
            this.txtSenha.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Location = new System.Drawing.Point(6, 62);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(897, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor:";
            // 
            // txtServidor
            // 
            this.txtServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServidor.Location = new System.Drawing.Point(6, 23);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(897, 20);
            this.txtServidor.TabIndex = 0;
            // 
            // tabOutrosParametros
            // 
            this.tabOutrosParametros.Controls.Add(this.label7);
            this.tabOutrosParametros.Controls.Add(this.txtDiasParaBackup);
            this.tabOutrosParametros.Controls.Add(this.label6);
            this.tabOutrosParametros.Controls.Add(this.txtCaminhoBackup);
            this.tabOutrosParametros.Controls.Add(this.label5);
            this.tabOutrosParametros.Controls.Add(this.txtCaminhoSalvarXPZ);
            this.tabOutrosParametros.Location = new System.Drawing.Point(4, 22);
            this.tabOutrosParametros.Name = "tabOutrosParametros";
            this.tabOutrosParametros.Size = new System.Drawing.Size(909, 437);
            this.tabOutrosParametros.TabIndex = 2;
            this.tabOutrosParametros.Text = "Outros parâmetros";
            this.tabOutrosParametros.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Quantidade de dias para trás pra backup:";
            // 
            // txtDiasParaBackup
            // 
            this.txtDiasParaBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiasParaBackup.Location = new System.Drawing.Point(3, 128);
            this.txtDiasParaBackup.MaxLength = 3;
            this.txtDiasParaBackup.Name = "txtDiasParaBackup";
            this.txtDiasParaBackup.Size = new System.Drawing.Size(903, 20);
            this.txtDiasParaBackup.TabIndex = 4;
            this.txtDiasParaBackup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasParaBackup_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Caminho para backup local do XPZ:";
            // 
            // txtCaminhoBackup
            // 
            this.txtCaminhoBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaminhoBackup.Location = new System.Drawing.Point(3, 79);
            this.txtCaminhoBackup.Name = "txtCaminhoBackup";
            this.txtCaminhoBackup.Size = new System.Drawing.Size(903, 20);
            this.txtCaminhoBackup.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Caminho para salvar o XPZ:";
            // 
            // txtCaminhoSalvarXPZ
            // 
            this.txtCaminhoSalvarXPZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaminhoSalvarXPZ.Location = new System.Drawing.Point(3, 30);
            this.txtCaminhoSalvarXPZ.Name = "txtCaminhoSalvarXPZ";
            this.txtCaminhoSalvarXPZ.Size = new System.Drawing.Size(903, 20);
            this.txtCaminhoSalvarXPZ.TabIndex = 0;
            // 
            // btnExecutarBackup
            // 
            this.btnExecutarBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecutarBackup.Location = new System.Drawing.Point(12, 481);
            this.btnExecutarBackup.Name = "btnExecutarBackup";
            this.btnExecutarBackup.Size = new System.Drawing.Size(917, 43);
            this.btnExecutarBackup.TabIndex = 1;
            this.btnExecutarBackup.Text = "Executar Backup";
            this.btnExecutarBackup.UseVisualStyleBackColor = true;
            this.btnExecutarBackup.Click += new System.EventHandler(this.btnExecutarBackup_Click);
            // 
            // frmXPZBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 536);
            this.Controls.Add(this.btnExecutarBackup);
            this.Controls.Add(this.tabConfiguracoes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(957, 574);
            this.Name = "frmXPZBackup";
            this.Text = "Backup XPZ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmXPZBackup_FormClosing);
            this.tabConfiguracoes.ResumeLayout(false);
            this.tabBases.ResumeLayout(false);
            this.tabBases.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBases)).EndInit();
            this.tabSQLServer.ResumeLayout(false);
            this.tabSQLServer.PerformLayout();
            this.tabOutrosParametros.ResumeLayout(false);
            this.tabOutrosParametros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConfiguracoes;
        private System.Windows.Forms.TabPage tabBases;
        private System.Windows.Forms.TabPage tabSQLServer;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.CheckBox chkAutenticacaoWindows;
        private System.Windows.Forms.DataGridView dgvBases;
        private System.Windows.Forms.Button btnAdicionarBase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBaseParaAdicionar;
        private System.Windows.Forms.CheckBox chkBackupKBInteira;
        private System.Windows.Forms.Button btnExecutarBackup;
        private System.Windows.Forms.TabPage tabOutrosParametros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCaminhoSalvarXPZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCaminhoBackup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiasParaBackup;
        private System.Windows.Forms.ComboBox cmbVersaoGeneXus;
        private System.Windows.Forms.Button btnTrocarVersao;
    }
}

