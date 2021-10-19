using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using covid_ac_api.Models;
namespace covid_ac_api.DataBase

{
    public class ConsultaPessoaVacinaPossuiEstabelecimento //Criando a classe
    {
        public ConsultaPessoaVacinaPossuiEstabelecimento() //Construtor
        {

        }
        public List<PessoaVacinaPossuiEstabelecimento> getPessoaVacinaPossuiEstabelecimento() //Criacao de metodo 
        {
            string connStr = "server=localhost;port=3306;database=covid_ac;uid=root;password=;SslMode=none"; //String de conexao
            MySqlConnection conn = new MySqlConnection(connStr); //configurando mySQLConnection com a string de conexao
            List<PessoaVacinaPossuiEstabelecimento> pessoasVacinasPossuiEstabelecimentos = new List<PessoaVacinaPossuiEstabelecimento>(); //instancia 
            try
            {
                conn.Open(); //abrindo conexao

                string sql = "select pessoa.ID, pessoa.Idade, vacina.Nome, possui.fk_Estabelecimento__Codigo_CNES, estabelecimento_.Nome_Fantasia_do_Estabelecimento FROM pessoa join vacina on pessoa.fk_Vacina_Codigo = vacina.Codigo join possui on possui.fk_Vacina_Codigo = vacina.Codigo join estabelecimento_ on estabelecimento_.Codigo_CNES = possui.fk_Estabelecimento__Codigo_CNES WHERE pessoa.Idade < 18 ORDER BY `pessoa`.`ID` ASC;"; //select
                MySqlCommand cmd = new MySqlCommand(sql, conn); //configurando mySQLCommand com a string de conexao e o comando SQL
                MySqlDataReader rdr = cmd.ExecuteReader(); //Executando o comando

                while (rdr.Read()) //Incluindo o retorno da select na lista.
                {
                    PessoaVacinaPossuiEstabelecimento pessoaVacinaPossuiEstabelecimento = new PessoaVacinaPossuiEstabelecimento();
                    pessoaVacinaPossuiEstabelecimento.idPessoa = rdr[0].ToString();
                    pessoaVacinaPossuiEstabelecimento.idadePessoa = Convert.ToInt32(rdr[1].ToString());
                    pessoaVacinaPossuiEstabelecimento.vacinaNome = rdr[2].ToString();
                    pessoaVacinaPossuiEstabelecimento.possuiEstabelecimentoCodigoCNES = rdr[3].ToString();
                    pessoaVacinaPossuiEstabelecimento.EstabelecimentoNome = rdr[4].ToString();
                    
                      
                    pessoasVacinasPossuiEstabelecimentos.Add(pessoaVacinaPossuiEstabelecimento);                 
                } 
                rdr.Close(); //terminando a execucao
            }
            catch (Exception ex) //caso de algum erro
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); //fechando conexao
            return pessoasVacinasPossuiEstabelecimentos;
        }
    }
}
        