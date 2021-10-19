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
    [Route("[controller]")]   //localhost:5001/EstabelecimentoLeito
    public class EstabelecimentoLeitoController : ControllerBase
    {
        [HttpGet("codigoCNES")] //localhost:5001/EstabelecimentoLeito/codigoCNES
        public ActionResult<List<EstabelecimentoLeito>> getEstabelecimentoLeitoByCodigoCNES()
        {
           ConsultaLeitoEstabelecimento consultaestabelecimentoLeito = new ConsultaLeitoEstabelecimento(); //Instanciamento da classe 
            
            return Ok(consultaestabelecimentoLeito.getEstabelecimentoLeitoByCodigoCNES()); //retorno ok(200) 
        }

        [HttpGet("codigoCNESGroupByEstabelecimentoNome")] //localhost:5001/EstabelecimentoLeito/codigoCNESGroupByEstabelecimentoNome
        public ActionResult<List<EstabelecimentoLeito>> getEstabelecimentoLeitoByCodigoCNESGroupByEstabelecimentoNome()
        {
           ConsultaLeitoEstabelecimento consultaestabelecimentoLeito = new ConsultaLeitoEstabelecimento(); //Instanciamento da classe 
            
            return Ok(consultaestabelecimentoLeito.getEstabelecimentoLeitoByCodigoCNESGroupByEstabelecimentoNome()); //retorno ok(200) 
        }
    }
}
