using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        public static string CaminhoScriptMSBUILD
        {
            get
            {
                return "ExportaObjetos.msbuild";
            }
        }

        /*public static string CaminhoRede 
        { 
            get 
            {
                return @"\\sqlserver\Desenvolvimento\BKPGX\";
            } 
        }*/

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

        public static void MensagemInfo(string mensagem)
        {
            MessageBox.Show(mensagem, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Pergunta(string mensagem, bool IncluirBotaoCancelar = false)
        {
            MessageBoxButtons buttons = (!IncluirBotaoCancelar ? MessageBoxButtons.YesNo : MessageBoxButtons.YesNoCancel);
            return MessageBox.Show(mensagem, "Confirmar", buttons, MessageBoxIcon.Question);
        }

        //public static string NomeXPZ(string NomeProgramador, string NomeBase)
        public static string NomeXPZ(string NomeBase)
        {
            string retorno = "";

            //retorno += NomeProgramador.Trim() + "_";
            retorno += NomeBase.Trim() + "_";
            retorno += DateTime.Now.Year.ToString().PadLeft(4, '0');
            retorno += DateTime.Now.Month.ToString().PadLeft(2, '0');
            retorno += DateTime.Now.Day.ToString().PadLeft(2, '0');
            retorno += DateTime.Now.Hour.ToString().PadLeft(2, '0');
            retorno += DateTime.Now.Minute.ToString().PadLeft(2, '0');
            retorno += ".xpz";

            return retorno;
        }

        public static List<InstalacaoGeneXus> IdentificarInstalacoesGeneXus()
        {
            List<InstalacaoGeneXus> retorno = new List<InstalacaoGeneXus>();

            string caminhoRaizGeneXus = @"C:\Program Files (x86)\GeneXus\";

            foreach (string d in Directory.GetDirectories(caminhoRaizGeneXus))
            {
                InstalacaoGeneXus instalacao = new InstalacaoGeneXus();
                instalacao.Caminho = d;
                instalacao.NomePasta = new DirectoryInfo(d).Name;

                retorno.Add(instalacao);
            }

            return retorno;
        }

        public static bool InstalacoesIguais(List<InstalacaoGeneXus> lista1, List<InstalacaoGeneXus> lista2)
        {
            bool retorno = true;

            bool encontrou = false;
            foreach (InstalacaoGeneXus i1 in lista1)
            {
                encontrou = false;
                foreach (InstalacaoGeneXus i2 in lista2)
                {
                    if (i2.Caminho == i1.Caminho && i2.NomePasta == i1.NomePasta)
                    {
                        encontrou = true;
                        break;
                    }
                }

                if (!encontrou)
                {
                    retorno = false;
                    break;
                }
            }

            if (retorno)
            {
                foreach (InstalacaoGeneXus i1 in lista2)
                {
                    encontrou = false;
                    foreach (InstalacaoGeneXus i2 in lista1)
                    {
                        if (i2.Caminho == i1.Caminho && i2.NomePasta == i1.NomePasta)
                        {
                            encontrou = true;
                            break;
                        }
                    }

                    if (!encontrou)
                    {
                        retorno = false;
                        break;
                    }
                }
            }

            return retorno;
        }
    }
}
