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
    public class ContactoDepartamentoHelper
    {
        private readonly DataContext _context;
        public ContactoDepartamentoHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _context.ContactoDepartamento.Select(b =>
                                           new ContactoDepartamentoDTO()
                                           {
                                               Id = b.Id,
                                               Contacto = new ContactoDTO()
                                               {
                                                   Id = b.Contacto.Id,
                                                   Nombres = b.Contacto.Nombres,
                                                   Apellidos = b.Contacto.Apellidos,
                                                   Anexo = b.Contacto.Anexo,
                                                   Departamento = b.Contacto.Departamento,
                                                   Email = b.Contacto.Email,
                                                   Puesto = b.Contacto.Puesto,
                                                   Rut = b.Contacto.Rut,
                                                   Sociedad = b.Contacto.Sociedad,
                                                   Telefono = b.Contacto.Telefono
                                               },
                                               Departamento = new Models.Metodologia.DepartamentoDTO()
                                               {
                                                   Id = b.Departamento.Id,
                                                   Ciudad = b.Departamento.Ciudad,
                                                   Descripcion = b.Departamento.Descripcion,
                                                   Direccion = b.Departamento.Direccion,
                                                   IdSociedad = b.Departamento.IdSociedad,
                                                   Nombre = b.Departamento.Nombre,
                                                   Region = b.Departamento.Region,
                                                   Url = b.Departamento.Url,
                                                   Telefono = b.Departamento.Telefono
                                               },
                                               Habilitado = b.Habilitado
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
        public async Task<IActionResult> Get_one(int id)
        {
            try
            {
                var query = await _context.ContactoDepartamento.Select(b =>
                                           new ContactoDepartamentoDTO()
                                           {
                                               Id = b.Id,
                                               Contacto = new ContactoDTO()
                                               {
                                                   Id = b.Contacto.Id,
                                                   Nombres = b.Contacto.Nombres,
                                                   Apellidos = b.Contacto.Apellidos,
                                                   Anexo = b.Contacto.Anexo,
                                                   Departamento = b.Contacto.Departamento,
                                                   Email = b.Contacto.Email,
                                                   Puesto = b.Contacto.Puesto,
                                                   Rut = b.Contacto.Rut,
                                                   Sociedad = b.Contacto.Sociedad,
                                                   Telefono = b.Contacto.Telefono
                                               },
                                               Departamento = new Models.Metodologia.DepartamentoDTO()
                                               {
                                                   Id = b.Departamento.Id,
                                                   Ciudad = b.Departamento.Ciudad,
                                                   Descripcion = b.Departamento.Descripcion,
                                                   Direccion = b.Departamento.Direccion,
                                                   IdSociedad = b.Departamento.IdSociedad,
                                                   Nombre = b.Departamento.Nombre,
                                                   Region = b.Departamento.Region,
                                                   Url = b.Departamento.Url,
                                                   Telefono = b.Departamento.Telefono
                                               },
                                               Habilitado = b.Habilitado
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

        public async Task<IActionResult> GetFromDepartamento(int idDepartamento)
        {
            try
            {
                var query = await _context.ContactoDepartamento.Select(b =>
                                           new ContactoDepartamentoDTO()
                                           {
                                               Id = b.Id,
                                               Contacto = new ContactoDTO()
                                               {
                                                   Id = b.Contacto.Id,
                                                   Nombres = b.Contacto.Nombres,
                                                   Apellidos = b.Contacto.Apellidos,
                                                   Anexo = b.Contacto.Anexo,
                                                   Departamento = b.Contacto.Departamento,
                                                   Email = b.Contacto.Email,
                                                   Puesto = b.Contacto.Puesto,
                                                   Rut = b.Contacto.Rut,
                                                   Sociedad = b.Contacto.Sociedad,
                                                   Telefono = b.Contacto.Telefono
                                               },
                                               Departamento = new Models.Metodologia.DepartamentoDTO()
                                               {
                                                   Id = b.Departamento.Id,
                                                   Ciudad = b.Departamento.Ciudad,
                                                   Descripcion = b.Departamento.Descripcion,
                                                   Direccion = b.Departamento.Direccion,
                                                   IdSociedad = b.Departamento.IdSociedad,
                                                   Nombre = b.Departamento.Nombre,
                                                   Region = b.Departamento.Region,
                                                   Url = b.Departamento.Url,
                                                   Telefono = b.Departamento.Telefono
                                               },
                                               Habilitado = b.Habilitado
                                           }).Where(r => r.Departamento.Id.Equals(idDepartamento)).ToListAsync();

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

        public async Task<IActionResult> Post(ContactoDepartamento contacto)
        {
            try
            {
                _context.ContactoDepartamento.Add(contacto);
                await _context.SaveChangesAsync();
                return new OkObjectResult(contacto);
            }
            catch (DbUpdateException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }


        public async Task<IActionResult> Put(ContactoDepartamento contact, int id)
        {
            try
            {
                var existing = _context.ContactoDepartamento.Where(s => s.Id == id).FirstOrDefault();
                existing.IdContacto = contact.IdContacto;
                existing.IdDepartamento = contact.IdDepartamento;
                existing.Habilitado = contact.Habilitado;
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
