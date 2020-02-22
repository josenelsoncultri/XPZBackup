using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace XPZBackup.Classes
{
    public class Arquivos
    {
        public static void MoverParaRede(string caminhoLocalXPZ, string programador)
        {
            string caminhoDestino = Common.CaminhoRede + programador.Trim() + @"\" + Path.GetFileName(caminhoLocalXPZ);

            if (File.Exists(caminhoDestino))
            {
                File.Delete(caminhoDestino);
            }

            if (File.Exists(caminhoLocalXPZ))
            {
                File.Move(caminhoLocalXPZ, caminhoDestino);
            }
        }
    }
}
