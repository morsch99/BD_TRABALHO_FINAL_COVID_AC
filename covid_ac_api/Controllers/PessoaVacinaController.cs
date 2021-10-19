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
    [Route("[controller]")]   //localhost:5001/PessoaVacina
    public class PessoaVacinaController : ControllerBase
    {
        [HttpGet] 
        public ActionResult<List<PessoaVacina>> getPessoaVacinaByCodigo()
        {
           ConsultaPessoaVacina consultaPessoaVacina = new ConsultaPessoaVacina(); //Instanciamento da classe 
            
            return Ok(consultaPessoaVacina.getPessoaVacinaByCodigo()); //retorno ok(200) 
        }

        [HttpGet("CountDosagem")] //localhost:5001/PessoaVacina/CountDosagem
        public ActionResult<List<InfoCountDosagem>> getInfoCountDosagems()
        {
           ConsultaPessoaVacina consultaInfoCountDosagem = new ConsultaPessoaVacina(); //Instanciamento da classe 
            
            return Ok(consultaInfoCountDosagem.getInfoCountDosagems()); //retorno ok(200) 
        }
    }
}
