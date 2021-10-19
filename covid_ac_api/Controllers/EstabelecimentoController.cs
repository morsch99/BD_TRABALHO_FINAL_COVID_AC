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
    [Route("[controller]")]   //localhost:5001/Estabelecimento
    public class EstabelecimentoController : ControllerBase
    {
        [HttpGet()] //localhost:5001/Estabelecimento
        public ActionResult<List<EstabelecimentoLeito>> getEstabelecimento()
        {
           ConsultaEstabelecimento consultaestabelecimento = new ConsultaEstabelecimento(); //Instanciamento da classe 
            
            return Ok(consultaestabelecimento.getEstabelecimento()); //retorno ok(200) 
        }

    }
}
