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
    public class ContactoTareaHelper
    {
        private readonly DataContext _context;
        public ContactoTareaHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _context.ContactoTarea.Select(b =>
                                           new ContactoTareaDTO()
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
                                               TareaFase = new Models.Metodologia.TareaFaseDTO()
                                               {
                                                   Id = b.Tarea.Id,
                                                   NecesitaAprobacion = b.Tarea.NecesitaAprobacion,
                                                   NecesitaArchivo = b.Tarea.NecesitaArchivo,
                                                   Estado = new Models.Metodologia.EstadoDTO()
                                                   {
                                                       Id = b.Tarea.Estado.Id,
                                                       Nombre = b.Tarea.Estado.Nombre
                                                   },
                                                   Tarea = new Models.Metodologia.TareaDTO()
                                                   {
                                                       Id = b.Tarea.Tarea.Id
                                                   },
                                                   FaseProyecto = new Models.Metodologia.FaseProyectoDTO()
                                                   {
                                                       Id = b.Tarea.FaseProyecto.Id,
                                                       Proyecto = new Models.Metodologia.ProyectoDTO()
                                                       {
                                                           Id =  b.Tarea.FaseProyecto.Proyecto.Id
                                                       }
                                                   }
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
                var query = await _context.ContactoTarea.Select(b =>
                                           new ContactoTareaDTO()
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
                                               TareaFase = new Models.Metodologia.TareaFaseDTO()
                                               {
                                                   Id = b.Tarea.Id,
                                                   NecesitaAprobacion = b.Tarea.NecesitaAprobacion,
                                                   NecesitaArchivo = b.Tarea.NecesitaArchivo,
                                                   Estado = new Models.Metodologia.EstadoDTO()
                                                   {
                                                       Id = b.Tarea.Estado.Id,
                                                       Nombre = b.Tarea.Estado.Nombre
                                                   },
                                                   Tarea = new Models.Metodologia.TareaDTO()
                                                   {
                                                       Id = b.Tarea.Tarea.Id
                                                   },
                                                   FaseProyecto = new Models.Metodologia.FaseProyectoDTO()
                                                   {
                                                       Id = b.Tarea.FaseProyecto.Id,
                                                       Proyecto = new Models.Metodologia.ProyectoDTO()
                                                       {
                                                           Id = b.Tarea.FaseProyecto.Proyecto.Id
                                                       }
                                                   }
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

        public async Task<IActionResult> Get_From_idTareaFase(int idTareaFase)
        {
            try
            {
                var query = await _context.ContactoTarea.Select(b =>
                                            new ContactoTareaDTO()
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
                                                TareaFase = new Models.Metodologia.TareaFaseDTO()
                                                {
                                                    Id = b.Tarea.Id,
                                                    NecesitaAprobacion = b.Tarea.NecesitaAprobacion,
                                                    NecesitaArchivo = b.Tarea.NecesitaArchivo,
                                                    Estado = new Models.Metodologia.EstadoDTO()
                                                    {
                                                        Id = b.Tarea.Estado.Id,
                                                        Nombre = b.Tarea.Estado.Nombre
                                                    },
                                                    Tarea = new Models.Metodologia.TareaDTO()
                                                    {
                                                        Id = b.Tarea.Tarea.Id
                                                    },
                                                    FaseProyecto = new Models.Metodologia.FaseProyectoDTO()
                                                    {
                                                        Id = b.Tarea.FaseProyecto.Id,
                                                        Proyecto = new Models.Metodologia.ProyectoDTO()
                                                        {
                                                            Id = b.Tarea.FaseProyecto.Proyecto.Id
                                                        }
                                                    }
                                                },
                                                Habilitado = b.Habilitado
                                            }).Where(r => r.TareaFase.Id.Equals(idTareaFase)).ToListAsync();

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

        public async Task<IActionResult> Post(ContactoTarea contacto)
        {
            try
            {
                _context.ContactoTarea.Add(contacto);
                await _context.SaveChangesAsync();
                return new OkObjectResult(contacto);
            }
            catch (DbUpdateException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }


        public async Task<IActionResult> Put(ContactoTarea contact, int id)
        {
            try
            {
                var existing = _context.ContactoTarea.Where(s => s.Id == id).FirstOrDefault();
                existing.IdContacto = contact.IdContacto;
                existing.IdTarea = contact.IdTarea;
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
