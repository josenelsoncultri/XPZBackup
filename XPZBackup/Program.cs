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
                    Tarefas.Executar(configuracoes, desligarNoFinal);
                }
                else if (args.Contains<string>("/ajuda"))
                {
                    
                }
            }
        }
    }
}
