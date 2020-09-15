using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Helpers;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Controllers
{
    [Route("api/template/")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly TemplateHelper template;
        public TemplateController(TemplateHelper _template)
        {
            template = _template;
        }

        [Route("get/{idTipo}/{idProyecto}")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromRoute] int idTipo, int idProyecto)
        {
            
            return await template.Get(idTipo, idProyecto);
        }

        [Route("post")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Template[] _template)
        {
            return await template.Post(_template);
        }
    }
}