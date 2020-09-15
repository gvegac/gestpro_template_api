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
    [Route("api/contactotarea/")]
    [ApiController]
    public class ContactoTareaController : ControllerBase
    {
        private readonly ContactoTareaHelper contact;
        public ContactoTareaController(ContactoTareaHelper _contact)
        {
            contact = _contact;
        }
        [Route("get")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return await contact.Get();
        }

        [Route("get/{id}")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return await contact.Get_one(id);
        }


        [Route("get/fasetarea/{id}")]
        [HttpGet()]
        public async Task<IActionResult> GetFase([FromRoute] int id)
        {
            return await contact.Get_From_idTareaFase(id);
        }

        [Route("post")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ContactoTarea _contact)
        {
            return await contact.Post(_contact);
        }

        [Route("put/{id}")]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ContactoTarea _contact, int id)
        {
            return await contact.Put(_contact, id);
        }
    }
}