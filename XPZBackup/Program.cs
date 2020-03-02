using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using XPZBackup.Classes;

namespace XPZBackup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmXPZBackup());
            }
            else
            {
                if (args.Contains<string>("/seminterface"))
                {
                    bool desligarNoFinal = args.Contains<string>("/desligar");

                    Configs configuracoes = ProcessadorXml.Ler();
                    List<string> retorno = Tarefas.Executar(configuracoes, desligarNoFinal);
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
                else if (args.Contains<string>("/ajuda"))
                {
                    string mensagem = "";
                    mensagem += "---------------------------------------------------------------------" + Environment.NewLine;
                    mensagem += "Parâmetros do XPZBackup:" + Environment.NewLine;
                    mensagem += "/seminterface: Inicializa o programa sem a interface, utilizando as configurações feitas pela interface" + Environment.NewLine;
                    mensagem += "/desligar: Usado junto com o parâmetro /seminterface, desliga a máquina no final do processo" + Environment.NewLine;
                    mensagem += "/ajuda: Exibe essa mensagem de ajuda" + Environment.NewLine;
                    mensagem += "---------------------------------------------------------------------" + Environment.NewLine;

                    Common.MensagemInfo(mensagem);
                }
                else
                {
                    Common.MensagemErro("Parâmetros inválidos, verifique os parâmetros informados!");
                }
            }
        }
    }
}
