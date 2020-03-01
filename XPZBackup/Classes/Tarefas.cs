using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace XPZBackup.Classes
{
    public class Tarefas
    {
        public static void Executar(Configs configuracoes, bool desligarNoFinal)
        {

            string connectionString = "";
            connectionString += "Server=" + configuracoes.Servidor.Trim() + ";";

            if (!configuracoes.AutenticacaoWindows)
            {
                connectionString += "User Id=" + configuracoes.Usuario.Trim() + ";";
                connectionString += "Password=" + configuracoes.Senha.Trim() + ";";
            }
            else if (configuracoes.AutenticacaoWindows)
            {
                connectionString += "Integrated Security=true;";
            }

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                foreach (Base b in configuracoes.Bases)
                {
                    string listaObjetos = DataBase.ExecutarComandos(ProcessadorXml.ObterNomeBanco(b.Caminho), configuracoes.QuantidadeDiasBackup, cnn);

                    Prompt.ExecutarBackup(b, listaObjetos);
                }
            }
        }
    }
}
