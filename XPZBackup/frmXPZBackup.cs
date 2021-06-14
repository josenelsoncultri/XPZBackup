using System;
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
            ChecarInstalacoesGeneXus();
            CarregarGrid();
        }

        private void ChecarInstalacoesGeneXus()
        {
            List<InstalacaoGeneXus> InstalacoesAtuais = Common.IdentificarInstalacoesGeneXus();
            List<InstalacaoGeneXus> InstalacoesSalvasNoXml = configuracoes.InstalacoesGeneXus;

            if (!Common.InstalacoesIguais(InstalacoesAtuais, InstalacoesSalvasNoXml))
            {
                Common.MensagemInfo("Foi identificado que houve uma mudança nas instalações do GeneXus! Devido a isso, será necessário atualizar as propriedades das KBs configuradas!");

                //Chamar formulário para reconfigurar as KBs
                frmAtualizarBases frm = new frmAtualizarBases();
                frm.ShowDialog();

                CarregarConfiguracoes();
            }

            cmbInstalacaoGeneXus.Items.Clear();

            foreach (InstalacaoGeneXus i in InstalacoesAtuais)
            {
                cmbInstalacaoGeneXus.Items.Add(i.NomePasta);
            }
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

            txtCaminhoSalvarXPZ.Text = configuracoes.CaminhoSalvarXPZ.Trim();
            txtCaminhoBackup.Text = configuracoes.CaminhoLocalBackup.Trim();
            txtDiasParaBackup.Text = configuracoes.QuantidadeDiasBackup.ToString().Trim();
            chkDesabilitarDesligamento.Checked = configuracoes.DesabilitarDesligamento;

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

            configuracoes.CaminhoSalvarXPZ = txtCaminhoSalvarXPZ.Text.Trim();
            configuracoes.CaminhoLocalBackup = txtCaminhoBackup.Text.Trim();
            configuracoes.QuantidadeDiasBackup = Convert.ToInt32(txtDiasParaBackup.Text.Trim());
            configuracoes.DesabilitarDesligamento = chkDesabilitarDesligamento.Checked;

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
                Base b = new Base
                {
                    Caminho = txtBaseParaAdicionar.Text.Trim() + (txtBaseParaAdicionar.Text.Trim().EndsWith(@"\") ? "" : @"\"),
                    BackupKBInteira = chkBackupKBInteira.Checked,
                    VersaoGeneXus = cmbInstalacaoGeneXus.Text.Trim()
                };

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

            if (cmbInstalacaoGeneXus.Text == "")
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

        private void chkAutenticacaoWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtUsuario.Enabled = txtSenha.Enabled = !chkAutenticacaoWindows.Checked;
        }

        private void btnExecutarBackup_Click(object sender, EventArgs e)
        {
            DialogResult res = (chkDesabilitarDesligamento.Checked ? Common.Pergunta("Deseja executar o backup?", false) : Common.Pergunta("O backup será iniciado, deseja desligar a máquina no final? (Clique em Cancelar para cancelar o backup)", true));

            if ((res != DialogResult.Cancel && !chkDesabilitarDesligamento.Checked) || (chkDesabilitarDesligamento.Checked && res == DialogResult.Yes))
            {
                SalvarConfiguracoes();
                List<string> retorno = Tarefas.Executar(configuracoes, res == DialogResult.Yes);
                if (retorno.Count > 0)
                {
                    string mensagensRetorno = "";

                    foreach (string s in retorno)
                    {
                        mensagensRetorno += s + Environment.NewLine;
                    }

                    Common.MensagemErro(mensagensRetorno);
                }
            }
        }

        private void frmXPZBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvarConfiguracoes();
        }
    }
}
