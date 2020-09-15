using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Helpers
{
    public class ContactoHelper
    {
        private readonly DataContext _context;
        public ContactoHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetContactos()
        {
            try
            {
                var query = await _context.Contacto.Select(b =>
                                           new ContactoDTO()
                                           {
                                               Id = b.Id,
                                               Nombres = b.Nombres,
                                               Apellidos = b.Apellidos,
                                               Anexo = b.Anexo,
                                               Departamento = b.Departamento,
                                               Email = b.Email,
                                               Puesto = b.Puesto,
                                               Rut = b.Rut,
                                               Sociedad = b.Sociedad,
                                               Telefono = b.Telefono
                                           }).ToListAsync();

                if (query is null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    return new OkObjectResult(query);
                }
            }
            catch (DbException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }

        }
        public async Task<IActionResult> Get_oneContacto(int id)
        {
            try
            {
                var query = await _context.Contacto.Select(b =>
                                           new ContactoDTO()
                                           {
                                               Id = b.Id,
                                               Nombres = b.Nombres,
                                               Apellidos = b.Apellidos,
                                               Anexo = b.Anexo,
                                               Departamento = b.Departamento,
                                               Email = b.Email,
                                               Puesto = b.Puesto,
                                               Rut = b.Rut,
                                               Sociedad = b.Sociedad,
                                               Telefono = b.Telefono
                                           }).Where(r => r.Id.Equals(id)).ToListAsync();

                if (query == null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    return new OkObjectResult(query);
                }
            }
            catch (DbException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }

        public async Task<IActionResult> Get_Contacto_From_Cuenta(string cuenta)
        {
            try
            {
                var query = await _context.Contacto.Select(b =>
                                           new ContactoDTO()
                                           {
                                               Id = b.Id,
                                               Nombres = b.Nombres,
                                               Apellidos = b.Apellidos,
                                               Anexo = b.Anexo,
                                               Departamento = b.Departamento,
                                               Email = b.Email,
                                               Puesto = b.Puesto,
                                               Rut = b.Rut,
                                               Sociedad = b.Sociedad,
                                               Telefono = b.Telefono
                                           }).Where(r => r.Email.Equals(cuenta)).ToListAsync();

                if (query == null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    return new OkObjectResult(query);
                }
            }
            catch (DbException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }

        public async Task<IActionResult> Post(Contacto contacto)
        {
            try
            {
                _context.Contacto.Add(contacto);
                await _context.SaveChangesAsync();
                return new OkObjectResult(contacto);
            }
            catch (DbUpdateException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }


        public async Task<IActionResult> Put(Contacto contact, int idUsuario)
        {
            try
            {
                var existing = _context.Contacto.Where(s => s.Id == idUsuario).FirstOrDefault();
                existing.Anexo = contact.Anexo;
                existing.Apellidos = contact.Apellidos;
                existing.Departamento = contact.Departamento;
                existing.Email = contact.Email;
                existing.Nombres = contact.Nombres;
                existing.Puesto = contact.Puesto;
                existing.Rut = contact.Rut;
                existing.Telefono = contact.Telefono;
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }
    }
}
