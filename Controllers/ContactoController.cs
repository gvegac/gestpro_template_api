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
    [Route("api/contacto/")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly ContactoHelper contact;
        public ContactoController(ContactoHelper _contact)
        {
            contact = _contact;
        }
        [Route("get")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return await contact.GetContactos();
        }

        [Route("get/{id}")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return await contact.Get_oneContacto(id);
        }


        [Route("get/cuenta/{cuenta}")]
        [HttpGet()]
        public async Task<IActionResult> Get_cuenta([FromRoute] string cuenta)
        {
            return await contact.Get_Contacto_From_Cuenta(cuenta);
        }

        [Route("post")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Contacto _contact)
        {
            return await contact.Post(_contact);
        }

        [Route("put/{id}")]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Contacto _contact, int id)
        {
            return await contact.Put(_contact, id);
        }
    }
}