using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Helpers;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Controllers
{
    [Route("api/rolusuario/")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly RolUsuarioHelper rolusu;
        public RolUsuarioController(RolUsuarioHelper _rolusu)
        {
            rolusu = _rolusu;
        }
        [Route("get")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return await rolusu.GetAll();
        }

        [Route("get/cuenta/{cuenta}")]
        [HttpGet()]
        public async Task<IActionResult> GetCuenta([FromRoute] string cuenta)
        {
            return await rolusu.Get_cuenta(cuenta);
        }

        [Route("post")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] RolUsuario _rol)
        {
            return await rolusu.Post(_rol);
        }

        [Route("put/{id}")]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] RolUsuario _rol, int id)
        {
            return await rolusu.Put(_rol, id);
        }
    }
}