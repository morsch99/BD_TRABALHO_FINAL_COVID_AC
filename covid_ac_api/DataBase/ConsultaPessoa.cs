using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using covid_ac_api.Models;
namespace covid_ac_api.DataBase

{
    public class ConsultaPessoa //Criando a classe
    {
        public ConsultaPessoa() //Construtor
        {

        }
        public List<Pessoa> getPessoasByCodVacina() //Criacao de metodo 
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
            List<Pessoa> pessoas = new List<Pessoa>(); //instancia 
            try
            {
                conn.Open(); //abrindo conexao

                string sql = "SELECT ID,Idade,Sexo,Raca,Data_de_Nascimento,fk_Vacina_Codigo from pessoa"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando

                while (rdr.Read()) //Incluindo o retorno da select na lista.
                {
                    Pessoa pessoa = new Pessoa();
                    pessoa.id = rdr[0].ToString();
                    pessoa.idade = Convert.ToInt32(rdr[1].ToString());
                    pessoa.sexo = rdr[2].ToString();
                    pessoa.raca = rdr[3].ToString();
                    pessoa.dataNascimento = Convert.ToDateTime(rdr[4].ToString()).ToShortDateString();  
                    pessoa.fk_Vacina_Codigo = Convert.ToInt32(rdr[5].ToString()); 
                    pessoas.Add(pessoa);                 
                } 
                rdr.Close(); //terminando a execucao
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return pessoas;
        }
    }
}