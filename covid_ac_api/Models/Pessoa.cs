using System;

namespace covid_ac_api.Models
{
    public class Pessoa //Entidade referente a pessoa
    {
        public string id{get;set;}
        public int idade{get;set;}
        public string sexo{get;set;}
        public string raca{get;set;}
        public string dataNascimento{get;set;}

    }
}