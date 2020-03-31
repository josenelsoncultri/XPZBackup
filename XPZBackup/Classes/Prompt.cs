using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;

namespace XPZBackup.Classes
{
    public class Prompt
    {
        public static void ExecutarBackup(Configs configuracoes, Base b, string listaObjetos)
        {
            string caminhoXPZ = "";
            caminhoXPZ += configuracoes.CaminhoLocalBackup + (configuracoes.CaminhoLocalBackup.EndsWith(@"\") ? "" : @"\");
            //caminhoXPZ += Common.NomeXPZ(configuracoes.NomeProgramador, ProcessadorXml.ObterNomeBanco(b.Caminho));
            caminhoXPZ += Common.NomeXPZ(ProcessadorXml.ObterNomeBanco(b.Caminho));

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = Common.CaminhoMSBUILD,
                Arguments = "\"" + Common.CaminhoScriptMSBUILD(b.VersaoGeneXus) + "\"" + " /p:CaminhoXPZ=" + caminhoXPZ.Trim() + ";CaminhoKB=" + b.Caminho.Trim() + ";ExportarTudo=" + b.BackupKBInteira.ToString().Trim() + (listaObjetos.Trim() != "" ? ";ListaObjetos=\"" + listaObjetos.Trim() + "\"" : "")
            };
            Process.Start(psi).WaitForExit();

            if (File.Exists(caminhoXPZ) && configuracoes.CaminhoSalvarXPZ.Trim() != "")
            {
                Arquivos.MoverArquivo(caminhoXPZ, configuracoes);
            }
        }

        public static void DesligarMaquina()
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "shutdown.exe",
                Arguments = "-s -t 15"
            };
            Process.Start(psi);
        }
    }
}
