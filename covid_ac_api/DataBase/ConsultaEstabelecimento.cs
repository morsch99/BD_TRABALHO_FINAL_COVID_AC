using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using covid_ac_api.Models;
namespace covid_ac_api.DataBase

{
    public class ConsultaEstabelecimento //Criando a classe
    {
        public ConsultaEstabelecimento() //Construtor
        {

        }
        public List<EstabelecimentoLeito> getEstabelecimento() //Criacao de metodo 
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
            List<EstabelecimentoLeito> EstabelecimentoLeitos = new List<EstabelecimentoLeito>(); //instancia 
            try
            {
                conn.Open(); //abrindo conexao

                string sql = "select estabelecimento_.Nome_Fantasia_do_Estabelecimento, estabelecimento_.Codigo_CNES from estabelecimento_ where not exists (select leito.Codigo_CNES from leito where leito.Codigo_CNES = estabelecimento_.Codigo_CNES);"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando

                while (rdr.Read()) //Incluindo o retorno da select na lista.
                {
                    EstabelecimentoLeito EstabelecimentoLeito = new EstabelecimentoLeito();
                    EstabelecimentoLeito.nomeEstabelecimento = rdr[0].ToString();
                    EstabelecimentoLeito.estabelecimentoCodigoCNES = rdr[1].ToString();
                      
                    EstabelecimentoLeitos.Add(EstabelecimentoLeito);                 
                } 
                rdr.Close(); //terminando a execucao
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return EstabelecimentoLeitos;
        }
    }
}