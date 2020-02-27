using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace XPZBackup.Classes
{
    [Serializable]
    public class Configs
    {
        public List<Base> Bases { get; set; }

        public string Servidor { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool AutenticacaoWindows { get; set; }

        public string NomeProgramador { get; set; }
        public string CaminhoLocalBackup { get; set; }
        public int QuantidadeDiasBackup { get; set; }

        public Configs()
        {
            this.Bases = new List<Base>();

            this.Servidor = "";
            this.Usuario = "Producao";
            this.Senha = "1";

            this.NomeProgramador = "";
            this.CaminhoLocalBackup = "";
            this.QuantidadeDiasBackup = 15;
        }
    }

    public class Base
    {
        public string Caminho { get; set; }
        public bool BackupKBInteira { get; set; }
        public string VersaoGeneXus { get; set; }
    }
}
