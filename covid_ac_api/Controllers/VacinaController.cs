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
    [Route("[controller]")]   //localhost:5001/Vacina
    public class VacinaController : ControllerBase
    {
        [HttpGet] 
        public ActionResult<int> getCountVacinaCodigo() 
        {
            ConsultaVacina consultaVacina = new ConsultaVacina(); //Instanciamento da classe 
            
            return Ok(consultaVacina.getCountVacinaCodigo()); //retorno ok(200) 
        }

        [HttpGet("DataAplicacaoTotalSomaTotal")] //localhost:5001/Vacina/DataAplicacaoTotalSomaTotal
        public ActionResult<List<DataAplicacaoTotalSomaTotal>> getDataAplicacaoTotalSomaTotal() 
        {
             ConsultaVacina consultaVacina = new ConsultaVacina(); //Instanciamento da classe 
            
            return Ok(consultaVacina.getDataAplicacaoTotalSomaTotal()); //retorno ok(200) 
        }
    }
}
