using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using covid_ac_api.Models;
namespace covid_ac_api.DataBase

{
    public class ConsultaLeitoEstabelecimento //Criando a classe
    {
        public ConsultaLeitoEstabelecimento() //Construtor
        {

        }
        public List<EstabelecimentoLeito> getEstabelecimentoLeitoByCodigoCNES() //Criacao de metodo 
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
            List<EstabelecimentoLeito> estabelecimentosLeitos = new List<EstabelecimentoLeito>(); //instancia 
            try
            {
                conn.Open(); //abrindo conexao

                string sql = "select estabelecimento_.Nome_Fantasia_do_Estabelecimento, leito.ID from estabelecimento_ INNER JOIN leito ON estabelecimento_.Codigo_CNES = leito.Codigo_CNES;"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando

                while (rdr.Read()) //Incluindo o retorno da select na lista.
                {
                    EstabelecimentoLeito estabelecimentoLeito = new EstabelecimentoLeito();
                    estabelecimentoLeito.nomeEstabelecimento = rdr[0].ToString();
                    estabelecimentoLeito.LeitoId = rdr[1].ToString();
                      
                    estabelecimentosLeitos.Add(estabelecimentoLeito);                 
                } 
                rdr.Close(); //terminando a execucao
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return estabelecimentosLeitos;
        }

        public List<EstabelecimentoLeito> getEstabelecimentoLeitoByCodigoCNESGroupByEstabelecimentoNome() //Criacao de metodo que consulta pessoas que se vacinaram com o codigo 87
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
            List<EstabelecimentoLeito> estabelecimentosLeitos = new List<EstabelecimentoLeito>(); //instancia 
            try
            {
                conn.Open(); //abrindo conexao

                string sql = "select estabelecimento_.Nome_Fantasia_do_Estabelecimento, leito.ID from estabelecimento_ join possui on possui.fk_Estabelecimento__Codigo_CNES = estabelecimento_.Codigo_CNES join leito on leito.Codigo_CNES = estabelecimento_.Codigo_CNES group by estabelecimento_.Nome_Fantasia_do_Estabelecimento;"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando

                while (rdr.Read()) //Incluindo o retorno da select na lista.
                {
                    EstabelecimentoLeito estabelecimentoLeito = new EstabelecimentoLeito();
                    estabelecimentoLeito.nomeEstabelecimento = rdr[0].ToString();
                    estabelecimentoLeito.LeitoId = rdr[1].ToString();
                      
                    estabelecimentosLeitos.Add(estabelecimentoLeito);                 
                } 
                rdr.Close(); //terminando a execucao
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return estabelecimentosLeitos;
        }
    }
}