using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XPZBackup
{
    public partial class frmVersao : Form
    {
        public static string Versao { get; set; }
        public frmVersao()
        {
            InitializeComponent();
        }

        private void txtVersao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtVersao.Text.Trim() == "")
                {
                    MessageBox.Show("Informe a versão!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = false;
                }
                else
                {
                    frmVersao.Versao = txtVersao.Text;
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                frmVersao.Versao = "";
                this.Close();
            }
        }

        private void txtVersao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
