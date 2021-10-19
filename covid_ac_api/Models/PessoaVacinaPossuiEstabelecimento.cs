namespace covid_ac_api.Models
{
    public class PessoaVacinaPossuiEstabelecimento
    {
        public string idPessoa{get;set;}
        public int idadePessoa{get;set;}
        public string vacinaNome{get;set;}
        public string possuiEstabelecimentoCodigoCNES{get;set;}
        public string EstabelecimentoNome{get;set;}
    }
}