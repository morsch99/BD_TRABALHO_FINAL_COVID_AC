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
    [Route("[controller]")]   //localhost:5001/PessoaVacinaPossuiEstabelecimento
    public class PessoaVacinaPossuiEstabelecimentoController : ControllerBase
    {
        [HttpGet] 
        public ActionResult<List<PessoaVacinaPossuiEstabelecimento>> getPessoaVacinaPossuiEstabelecimento()
        {
           ConsultaPessoaVacinaPossuiEstabelecimento consultaPessoaVacinaPossuiEstabelecimento = new ConsultaPessoaVacinaPossuiEstabelecimento(); //Instanciamento da classe 
            
            return Ok(consultaPessoaVacinaPossuiEstabelecimento.getPessoaVacinaPossuiEstabelecimento()); //retorno ok(200) 
        }
    }
}
