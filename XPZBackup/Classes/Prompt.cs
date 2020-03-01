using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace XPZBackup.Classes
{
    public class Prompt
    {
        public static void ExecutarBackup(Configs configuracoes, Base b, string listaObjetos)
        {
            string caminhoXPZ = "";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Common.CaminhoMSBUILD;
            psi.Arguments = "/p:CaminhoXPZ=\"" + "" + "\";CaminhoKB=\"" + b.Caminho.Trim() + "\";ExportarTudo=\"" + b.BackupKBInteira.ToString().Trim() + "\";ListaObjetos=\"" + listaObjetos.Trim() + "\"";
            Process.Start(psi).WaitForExit();
        }

        public static void DesligarMaquina()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "shutdown.exe";
            psi.Arguments = "-s -t 3600";
            Process.Start(psi);
        }
    }
}
