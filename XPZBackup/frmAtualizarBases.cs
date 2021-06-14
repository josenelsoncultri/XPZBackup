using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using XPZBackup.Classes;

namespace XPZBackup
{
    public partial class frmAtualizarBases : Form
    {
        private Configs configuracoes = new Configs();
        private List<InstalacaoGeneXus> Instalacoes = Common.IdentificarInstalacoesGeneXus();
        private const string TEXTO_PADRAO_COMBO_VERSAO = "<selecione a versão>";

        public frmAtualizarBases()
        {
            InitializeComponent();
            configuracoes = ProcessadorXml.Ler();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            using (DataTable dt = new DataTable())
            {
                DataGridViewComboBoxColumn colVersaoGeneXus = new DataGridViewComboBoxColumn()
                {
                    Name = "VersaoGeneXus",
                    Width = 400,
                    HeaderText = "Versão do GeneXus",
                };


                dt.Columns.Add("Caminho", typeof(string));
                dt.Columns.Add("BackupKBInteira", typeof(bool));
                dt.Columns.Add("VersaoGeneXus", typeof(string));

                colVersaoGeneXus.Items.Clear();
                colVersaoGeneXus.Items.Add(TEXTO_PADRAO_COMBO_VERSAO);
                foreach (InstalacaoGeneXus i in this.Instalacoes)
                {
                    colVersaoGeneXus.Items.Add(i.NomePasta);
                }

                dgvBases.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Caminho", ReadOnly = true });
                dgvBases.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "BackupKBInteira", ReadOnly = true });
                dgvBases.Columns.Add(colVersaoGeneXus);

                foreach (Base b in configuracoes.Bases)
                {
                    string versao = b.VersaoGeneXus;
                    if (!(Instalacoes.Where(i => i.NomePasta == b.VersaoGeneXus).Count() > 0))
                    {
                        versao = TEXTO_PADRAO_COMBO_VERSAO;
                    }
                    dgvBases.Rows.Add(b.Caminho, b.BackupKBInteira, versao);
                }

                dgvBases.Columns["Caminho"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBases.Columns["Caminho"].HeaderText = "Caminho da KB";
                dgvBases.Columns["BackupKBInteira"].Width = 180;
                dgvBases.Columns["BackupKBInteira"].HeaderText = "Backup da KB inteira";
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            bool ConfiguracoesOK = true;
            foreach (DataGridViewRow linha in dgvBases.Rows)
            {
                if (linha.Cells["VersaoGeneXus"].Value.ToString() == TEXTO_PADRAO_COMBO_VERSAO)
                {
                    ConfiguracoesOK = false;
                    Common.MensagemErro(string.Format("A base {0} está sem a versão do GeneXus para backup selecionada!", linha.Cells["VersaoGeneXus"].Value.ToString()));
                    break;
                }
            }

            if (ConfiguracoesOK)
            {
                configuracoes.InstalacoesGeneXus = Instalacoes;

                foreach (DataGridViewRow linha in dgvBases.Rows)
                {
                    configuracoes.Bases.Where(b => b.Caminho == linha.Cells["Caminho"].Value.ToString()).First().VersaoGeneXus = linha.Cells["VersaoGeneXus"].Value.ToString();
                }

                ProcessadorXml.Salvar(configuracoes);
                this.Close();
            }
        }
    }
}