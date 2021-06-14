using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace XPZBackup.Classes
{
    public class ProcessadorXml
    {
        public static void Salvar(Configs configuracoes)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configs));

            using (StreamWriter sw = new StreamWriter(Common.CaminhoArquivo, false))
            {
                xmlSerializer.Serialize(sw, configuracoes);
            }
        }

        public static Configs Ler()
        {
            Configs configuracoes = new Configs();

            if (File.Exists(Common.CaminhoArquivo))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configs));
                using (StreamReader sr = new StreamReader(Common.CaminhoArquivo))
                {
                    configuracoes = ((Configs)xmlSerializer.Deserialize(sr));
                }
            }

            if (configuracoes.Bases == null)
            {
                configuracoes.Bases = new List<Base>();
            }

            if (configuracoes.InstalacoesGeneXus == null)
            {
                configuracoes.InstalacoesGeneXus = new List<InstalacaoGeneXus>();
            }

            return configuracoes;
        }

        public static string ObterNomeBanco(string Caminho)
        {
            string retorno = "";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Caminho + "knowledgebase.connection");

            retorno = xmlDoc.DocumentElement.GetElementsByTagName("DBName")[0].InnerText.Trim();

            return retorno;
        }
    }
}
