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
        public static void MoverArquivo(string caminhoLocalXPZ, Configs configuracoes)
        {
            string caminhoDestino = configuracoes.CaminhoSalvarXPZ + (configuracoes.CaminhoSalvarXPZ.EndsWith(@"\") ? "" : @"\") + Path.GetFileName(caminhoLocalXPZ);

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
