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
        public static string CaminhoMSBUILD
        {
            get
            {
                return @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe";
            }
        }

        public static string CaminhoScriptMSBUILD(string VersaoGeneXus)
        {
            string retorno = "";

            retorno += Application.StartupPath + (Application.StartupPath.EndsWith(@"\") ? "" : @"\");
            switch (VersaoGeneXus)
            {
                case "GeneXus 16":
                    retorno += "ExportaObjetosGX16.msbuild";

                    break;
                case "GeneXus 15":
                default:
                    retorno += "ExportaObjetosGX15.msbuild";

                    break;
            }

            return retorno;
        }

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

        public static string NomeXPZ(string NomeProgramador, string NomeBase)
        {
            string retorno = "";

            retorno += NomeProgramador.Trim() + "_";
            retorno += NomeBase.Trim() + "_";
            retorno += DateTime.Now.Year.ToString().PadLeft(4, '0');
            retorno += DateTime.Now.Month.ToString().PadLeft(2, '0');
            retorno += DateTime.Now.Day.ToString().PadLeft(2, '0');
            retorno += DateTime.Now.Hour.ToString().PadLeft(2, '0');
            retorno += DateTime.Now.Minute.ToString().PadLeft(2, '0');
            retorno += ".xpz";

            return retorno;
        }
    }
}
