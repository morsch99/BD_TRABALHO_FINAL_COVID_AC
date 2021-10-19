using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using covid_ac_api.Models;
namespace covid_ac_api.DataBase

{
    public class ConsultaPessoaVacina //Criando a classe
    {
        public ConsultaPessoaVacina() //Construtor
        {

        }
        public List<PessoaVacina> getPessoaVacinaByCodigo() //Criacao de metodo 
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
            List<PessoaVacina> pessoasVacinas = new List<PessoaVacina>(); //instancia 
            try
            {
                conn.Open(); //abrindo conexao

                string sql = "SELECT pessoa.Idade, vacina.Nome from pessoa RIGHT JOIN vacina ON vacina.Codigo = pessoa.fk_Vacina_Codigo;"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando

                while (rdr.Read()) //Incluindo o retorno da select na lista.
                {
                    PessoaVacina pessoaVacina = new PessoaVacina();
                    pessoaVacina.idadePessoa = Convert.ToInt32(rdr[0].ToString());
                    pessoaVacina.nomeVacina = rdr[1].ToString();
                      
                    pessoasVacinas.Add(pessoaVacina);                 
                } 
                rdr.Close(); //terminando a execucao
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return pessoasVacinas;
        }
        public List<InfoCountDosagem> getInfoCountDosagems() //Criacao de metodo 
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
            List<InfoCountDosagem> InfoCountDosagems = new List<InfoCountDosagem>(); //instancia 
            try
            {
                conn.Open(); //abrindo conexao

                string sql = "SELECT pessoa.Descricao_da_Dose, COUNT(pessoa.Descricao_da_Dose) FROM pessoa GROUP BY pessoa.Descricao_da_Dose;"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando

                while (rdr.Read()) //Incluindo o retorno da select na lista.
                {
                    InfoCountDosagem InfoCountDosagem = new InfoCountDosagem();
                    
                    InfoCountDosagem.DescricaoDaDose = rdr[0].ToString();
                    InfoCountDosagem.CountDose = Convert.ToInt32(rdr[1].ToString());
                      
                    InfoCountDosagems.Add(InfoCountDosagem);                 
                } 
                rdr.Close(); //terminando a execucao
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return InfoCountDosagems;
        }
    }
}