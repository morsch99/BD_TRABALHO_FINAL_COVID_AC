using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using covid_ac_api.Models;
namespace covid_ac_api.DataBase

{
    public class ConsultaVacina //Criando a classe
    {
        public ConsultaVacina() //Construtor
        {

        }
        public List<Vacina> getCountVacinaCodigo() //Criacao de metodo 
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
            List<Vacina> vacinas = new List<Vacina>(); //instancia 
            
            try
            {
                conn.Open(); //abrindo conexao
                string sql = "SELECT COUNT(vacina.Codigo), vacina.Codigo FROM vacina JOIN pessoa WHERE vacina.Codigo = 85 AND vacina.Codigo = pessoa.fk_Vacina_Codigo UNION SELECT COUNT(vacina.Codigo), vacina.Codigo FROM vacina JOIN pessoa WHERE vacina.Codigo = 86 AND vacina.Codigo = pessoa.fk_Vacina_Codigo UNION SELECT COUNT(vacina.Codigo), vacina.Codigo FROM vacina JOIN pessoa WHERE vacina.Codigo = 87 AND vacina.Codigo = pessoa.fk_Vacina_Codigo UNION SELECT COUNT(vacina.Codigo), vacina.Codigo FROM vacina JOIN pessoa WHERE vacina.Codigo = 89 AND vacina.Codigo = pessoa.fk_Vacina_Codigo"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando
            while (rdr.Read()) //Incluindo o retorno da select na lista.
               {
                Vacina vacina = new Vacina();
                vacina.countVacinaCodigo = Convert.ToInt32(rdr[0].ToString());
                vacina.vacinaCodigo = Convert.ToInt32(rdr[1].ToString());
                vacinas.Add(vacina);
               }
                rdr.Close(); //terminando a execucao
            
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return vacinas;
        }

        public List<DataAplicacaoTotalSomaTotal> getDataAplicacaoTotalSomaTotal() //Criacao de metodo 
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
             List<DataAplicacaoTotalSomaTotal> dataAplicacaoTotalSomaTotals = new List<DataAplicacaoTotalSomaTotal>(); //instancia 
            
            try
            {
                conn.Open(); //abrindo conexao

                string sql = "Select Data_Aplicacao, COUNT(vacina.Codigo) AS Total, SUM(COUNT(vacina.Codigo)) OVER(ORDER BY pessoa.Data_Aplicacao ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS Soma_Total FROM vacina JOIN pessoa WHERE vacina.Codigo = pessoa.fk_Vacina_Codigo AND vacina.Codigo = pessoa.fk_Vacina_Codigo GROUP BY pessoa.Data_Aplicacao ORDER BY pessoa.Data_Aplicacao;"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando
            while (rdr.Read()) //Incluindo o retorno da select na lista.
                {
                    DataAplicacaoTotalSomaTotal dataAplicacaoTotalSomaTotal = new DataAplicacaoTotalSomaTotal();
                    dataAplicacaoTotalSomaTotal.DataAplicacao = Convert.ToDateTime(rdr[0].ToString()).ToShortDateString();
                    dataAplicacaoTotalSomaTotal.Total = Convert.ToInt32(rdr[1].ToString());
                    dataAplicacaoTotalSomaTotal.SomaTotal = Convert.ToInt32(rdr[2].ToString());
                    
                    dataAplicacaoTotalSomaTotals.Add(dataAplicacaoTotalSomaTotal);                 
                } 
                rdr.Close(); //terminando a execucao
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return  dataAplicacaoTotalSomaTotals;
        }
    }
}