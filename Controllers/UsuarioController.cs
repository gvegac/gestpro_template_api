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
    [Route("api/usuario/")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioHelper usuario;
        public UsuariosController(UsuarioHelper _usuario)
        {
            usuario = _usuario;
        }
        [Route("get")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return await usuario.GetAll();
        }

        [Route("get/{id}")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return await usuario.Get_id(id);
        }

        [Route("get/cuenta/{cuenta}")]
        [HttpGet()]
        public async Task<IActionResult> GetCuenta([FromRoute] string cuenta)
        {
            return await usuario.Get_cuenta(cuenta);
        }

        [Route("post")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Usuario _usuario)
        {
            return await usuario.Post(_usuario);
        }

        [Route("put/{id}")]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Usuario _usuario, int id)
        {
            return await usuario.Put(_usuario, id);
        }
    }
}