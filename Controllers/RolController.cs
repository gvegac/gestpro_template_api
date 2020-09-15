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
    [Route("api/rol/")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolHelper rol;
        public RolController(RolHelper _rol)
        {
            rol = _rol;
        }

        [Route("get")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return await rol.GetAll();
        }

        [Route("get/{id}")]
        [HttpGet()]
        public async Task<IActionResult> GetCuenta([FromRoute] int id)
        {
            return await rol.Get_id(id);
        }

        [Route("post")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Rol _rol)
        {
            return await rol.Post(_rol);
        }

        [Route("put/{id}")]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Rol _rol, int id)
        {
            return await rol.Put(_rol, id);
        }

    }
}