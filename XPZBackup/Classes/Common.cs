using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace XPZBackup.Classes
{
    public class Common
    {
        public static string CaminhoRede 
        { 
            get 
            {
                return @"\\sqlserver\Desenvolvimento\BKPGX\";
            } 
        }

        public static string CaminhoComandos
        {
            get
            {
                return Application.StartupPath + (Application.StartupPath.EndsWith(@"\") ? "" : @"\") + "Comandos.sql";
            }
        }

        public static string CaminhoArquivo
        {
            get
            {
                return Application.StartupPath + (Application.StartupPath.EndsWith(@"\") ? "" : @"\") + "Configs.xml";
            }
        }

        public static void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Pergunta(string mensagem, bool IncluirBotaoCancelar = false)
        {
            MessageBoxButtons buttons = (!IncluirBotaoCancelar ? MessageBoxButtons.YesNo : MessageBoxButtons.YesNoCancel);
            return MessageBox.Show(mensagem, "Confirmar", buttons, MessageBoxIcon.Question);
        }
    }
}
