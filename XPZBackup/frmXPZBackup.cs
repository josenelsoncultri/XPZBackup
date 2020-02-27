﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using XPZBackup.Classes;

namespace XPZBackup
{
    public partial class frmXPZBackup : Form
    {
        private Configs configuracoes = new Configs();

        public frmXPZBackup()
        {
            InitializeComponent();
            CarregarConfiguracoes();
            CarregarGrid();
        }

        private void btnTrocarVersao_Click(object sender, EventArgs e)
        {
            frmVersao frm = new frmVersao();
            frm.ShowDialog();

            if (frmVersao.Versao.Trim() != "")
            {
                foreach (Base b in configuracoes.Bases)
                {
                    string texto = b.Caminho;
                    texto = Regex.Replace(texto, @"-[0-9]{8}\\", "-" + frmVersao.Versao.Trim() + @"\");
                    b.Caminho = texto;
                }

                CarregarGrid();
            }

            SalvarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            configuracoes = ProcessadorXml.Ler();

            txtServidor.Text = configuracoes.Servidor.Trim();
            txtUsuario.Text = configuracoes.Usuario.Trim();
            txtSenha.Text = configuracoes.Senha.Trim();
            chkAutenticacaoWindows.Checked = configuracoes.AutenticacaoWindows;
            txtUsuario.Enabled = txtSenha.Enabled = !configuracoes.AutenticacaoWindows;

            txtNomeProgramador.Text = configuracoes.NomeProgramador.Trim();
            txtCaminhoBackup.Text = configuracoes.CaminhoLocalBackup.Trim();
            txtDiasParaBackup.Text = configuracoes.QuantidadeDiasBackup.ToString().Trim();

        }

        private void CarregarGrid()
        {
            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add("Caminho", typeof(string));
                dt.Columns.Add("BackupKBInteira", typeof(bool));
                dt.Columns.Add("VersaoGeneXus", typeof(string));

                foreach (Base b in configuracoes.Bases)
                {
                    dt.Rows.Add(b.Caminho, b.BackupKBInteira, b.VersaoGeneXus);
                }

                dgvBases.DataSource = dt;
                dgvBases.Columns["Caminho"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBases.Columns["Caminho"].HeaderText = "Caminho da KB";
                dgvBases.Columns["BackupKBInteira"].Width = 180;
                dgvBases.Columns["BackupKBInteira"].HeaderText = "Backup da KB inteira";
                dgvBases.Columns["VersaoGeneXus"].Width = 180;
                dgvBases.Columns["VersaoGeneXus"].HeaderText = "Versão do GeneXus";
            }
        }

        private void SalvarConfiguracoes()
        {
            configuracoes.Servidor = txtServidor.Text.Trim();
            configuracoes.Usuario = txtUsuario.Text.Trim();
            configuracoes.Senha = txtSenha.Text.Trim();
            configuracoes.AutenticacaoWindows = chkAutenticacaoWindows.Checked;

            configuracoes.NomeProgramador = txtNomeProgramador.Text.Trim();
            configuracoes.CaminhoLocalBackup = txtCaminhoBackup.Text.Trim();
            configuracoes.QuantidadeDiasBackup = Convert.ToInt32(txtDiasParaBackup.Text.Trim());

            ProcessadorXml.Salvar(configuracoes);
        }

        private void txtDiasParaBackup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdicionarBase_Click(object sender, EventArgs e)
        {
            if (ValidarBase())
            {
                Base b = new Base();
                b.Caminho = txtBaseParaAdicionar.Text.Trim();
                b.BackupKBInteira = chkBackupKBInteira.Checked;
                b.VersaoGeneXus = cmbVersaoGeneXus.Text.Trim();

                configuracoes.Bases.Add(b);

                CarregarGrid();
                SalvarConfiguracoes();
            }
        }

        private bool ValidarBase()
        {
            bool retorno = true;
            string mensagem = "";

            if (txtBaseParaAdicionar.Text.Trim() == "")
            {
                mensagem += "Informe uma base!" + Environment.NewLine;
                retorno = false;
            }
            else
            {
                string caminhoBase = txtBaseParaAdicionar.Text.Trim() + (txtBaseParaAdicionar.Text.Trim().EndsWith(@"\") ? "" : @"\");

                if (!File.Exists(caminhoBase + "knowledgebase.connection"))
                {
                    mensagem += "Informe o caminho de uma base do GeneXus válida!" + Environment.NewLine;
                    retorno = false;
                }
                else
                {
                    if (configuracoes.Bases.Where(b => b.Caminho == caminhoBase).Count<Base>() > 0)
                    {
                        mensagem += "Base já adicionada!" + Environment.NewLine;
                        retorno = false;
                    }
                }
            }

            if (cmbVersaoGeneXus.Text == "")
            {
                mensagem += "Selecione a versão do GeneXus para essa base!" + Environment.NewLine;
                retorno = false;
            }

            if (!retorno)
            {
                Common.MensagemErro(mensagem);   
            }

            return retorno;
        }

        private void dgvBases_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Common.Pergunta("Deseja remover a base selecionada?") == DialogResult.Yes)
            {
                string _base = dgvBases.Rows[e.RowIndex].Cells["Caminho"].Value.ToString().Trim();
                Base b = configuracoes.Bases.Where(_b => _b.Caminho == _base).First<Base>();
                configuracoes.Bases.Remove(b);
                CarregarGrid();
                SalvarConfiguracoes();
            }
        }
    }
}