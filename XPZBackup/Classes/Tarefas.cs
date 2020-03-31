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
        public static List<string> Executar(Configs configuracoes, bool desligarNoFinal)
        {
            List<string> retorno = new List<string>();

            if (configuracoes.Bases.Count <= 0) { retorno.Add("Selecione ao menos uma base para realizar o backup!"); }

            if (configuracoes.Servidor.Trim() == "") { retorno.Add("Informe o servidor do SQL Server (sua máquina local)!"); }
            if (!configuracoes.AutenticacaoWindows)
            {
                if (configuracoes.Usuario.Trim() == "") { retorno.Add("Informe o usuário para conexão ao SQL Server!"); }
                if (configuracoes.Senha.Trim() == "") { retorno.Add("Informe a senha para conexão ao SQL Server!"); }
            }

            if (configuracoes.CaminhoLocalBackup.Trim() == "") { retorno.Add("Informe o caminho local para salvar o XPZ!"); }
            if (configuracoes.QuantidadeDiasBackup <= 0) { retorno.Add("Deve ser feito o backup contando pelo menos 1 dia para trás!"); }

            if (retorno.Count <= 0)
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

                        if (listaObjetos.Trim() != "")
                        {
                            Prompt.ExecutarBackup(configuracoes, b, listaObjetos);
                        }
                    }
                }

                if (desligarNoFinal)
                {
                    Prompt.DesligarMaquina();
                }
            }

            return retorno;
        }
    }
}
