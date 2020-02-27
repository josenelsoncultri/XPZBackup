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
        public static void ExecutarBackup(Base b, string listaObjetos)
        {

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
