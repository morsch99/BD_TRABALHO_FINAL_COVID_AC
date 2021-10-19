using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using covid_ac_api.DataBase;
using covid_ac_api.Models;


namespace covid_ac_api.Controllers
{
    [ApiController]
    [Route("[controller]")]   //localhost:5001/Pessoa
    public class PessoaController : ControllerBase
    {
        [HttpGet] 
        public ActionResult<List<Pessoa>> getPessoaByCodVacina() 
        {
            ConsultaPessoa consulta = new ConsultaPessoa(); //Instanciamento da classe
            
            return Ok(consulta.getPessoasByCodVacina()); //retorno ok(200) 
        }
    }
}
