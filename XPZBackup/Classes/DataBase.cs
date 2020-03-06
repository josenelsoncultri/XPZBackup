using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace XPZBackup.Classes
{
    public class DataBase
    {
        /*private const string NOME_PROCEDURE = "SP_LISTA_OBJETOS";

        public static void CriarProcedure(string server, string database, string userid, string password, bool AutenticacaoWindows)
        {
            string connectionString = "";
            connectionString += "Server=" + server + ";";
            connectionString += "Database=" + database + ";";

            if (!AutenticacaoWindows)
            {
                connectionString += "User Id=" + userid + ";";
                connectionString += "Password=" + password + ";";
            }
            else if (AutenticacaoWindows)
            {
                connectionString += "Integrated Security=true;";
            }

            string filePath = Common.CaminhoProcedure;
            string comandos = "";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    comandos += sr.ReadLine() + Environment.NewLine;
                }
            }

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                bool droparProcedure = false;
                using (SqlCommand cmm = new SqlCommand("SELECT * FROM sys.objects WHERE type_desc = 'SQL_STORED_PROCEDURE' AND name = '" + NOME_PROCEDURE + "'", cnn))
                {
                    cmm.CommandType = CommandType.Text;
                    using (SqlDataReader sdr = cmm.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            if (sdr.Read())
                            {
                                droparProcedure = true;
                            }
                        }
                    }
                }

                if (droparProcedure)
                {
                    using (SqlCommand cmmDrop = new SqlCommand("DROP PROCEDURE " + NOME_PROCEDURE, cnn))
                    {
                        cmmDrop.CommandType = CommandType.Text;

                        cmmDrop.ExecuteNonQuery();
                    }
                }

                using (SqlCommand cmmCreate = new SqlCommand(comandos, cnn))
                {
                    cmmCreate.CommandType = CommandType.Text;
                    cmmCreate.ExecuteNonQuery();
                }
            }
        }*/

        //public static string ExecutarProcedure(string server, string database, string userid, string password, bool AutenticacaoWindows)
        public static string ExecutarComandos(string nomeBanco, int quantidadeDiasBackup, SqlConnection cnn)
        {
            string retorno = "";

            /*string connectionString = "";
            connectionString += "Server=" + server + ";";
            connectionString += "Database=" + database + ";";

            if (!AutenticacaoWindows)
            {
                connectionString += "User Id=" + userid + ";";
                connectionString += "Password=" + password + ";";
            }
            else if (AutenticacaoWindows)
            {
                connectionString += "Integrated Security=true;";
            }

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();*/

            string filePath = Common.CaminhoComandos;
            string comandos = "";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    comandos += sr.ReadLine() + Environment.NewLine;
                }
            }

            comandos = comandos.Replace("<BANCO_DADOS>", nomeBanco);
            comandos = comandos.Replace("<QUANTIDADE_DIAS_BACKUP>", quantidadeDiasBackup.ToString().Trim());

            using (SqlCommand cmm = new SqlCommand(comandos, cnn))
            {
                cmm.CommandType = CommandType.Text;
                cmm.CommandTimeout = 100000;

                using (SqlDataReader sdr = cmm.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        if (sdr.Read())
                        {
                            retorno = sdr[0].ToString();
                            if (retorno.Trim() != "")
                            {
                                if (retorno.Substring(retorno.Length - 1, 1) == ";")
                                {
                                    retorno = retorno.Substring(0, retorno.Length - 1);
                                }

                                retorno = retorno.Replace("; ", ";");
                            }
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
