using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Helpers
{
    public class RolUsuarioHelper
    {
        private readonly DataContext _context;
        public RolUsuarioHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Get_cuenta(string cuenta)
        {
            try
            {
                var query = await _context.RolUsuario.Select(b => new RolUsuarioDTO()
                {
                    Id = b.Id,
                    Rol = new RolDTO()
                    {
                        Id = b.Rol.Id,
                        Nombre = b.Rol.Nombre,
                        Descripcion = b.Rol.Descripcion,
                        Habilitado = b.Rol.Habilitado
                    },
                    Usuario = new UsuarioDTO()
                    {
                        Id = b.Usuario.Id,
                        Contacto = new ContactoDTO()
                        {
                            Id = b.Usuario.Contacto.Id,
                            Nombres = b.Usuario.Contacto.Nombres,
                            Apellidos = b.Usuario.Contacto.Apellidos,
                            Anexo = b.Usuario.Contacto.Anexo,
                            Departamento = b.Usuario.Contacto.Departamento,
                            Email = b.Usuario.Contacto.Email,
                            Puesto = b.Usuario.Contacto.Puesto,
                            Rut = b.Usuario.Contacto.Rut,
                            Sociedad = b.Usuario.Contacto.Sociedad,
                            Telefono = b.Usuario.Contacto.Telefono
                        },
                        Cuenta = b.Usuario.Cuenta,
                        Habilitado = b.Usuario.Habilitado
                    },
                    Habilitado = b.Habilitado
                }).Where(c => c.Usuario.Cuenta == cuenta).ToListAsync();

                if (query is null)
                {
                    return new BadRequestResult();
                }
                else
                {
                    return new OkObjectResult(query);
                }
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = await _context.RolUsuario.Select(b => new RolUsuarioDTO()
                {
                    Id = b.Id,
                    Rol = new RolDTO()
                    {
                        Id = b.Rol.Id,
                        Nombre = b.Rol.Nombre,
                        Descripcion = b.Rol.Descripcion,
                        Habilitado = b.Rol.Habilitado
                    },
                    Usuario = new UsuarioDTO()
                    {
                        Id = b.Usuario.Id,
                        Contacto = new ContactoDTO()
                        {
                            Id = b.Usuario.Contacto.Id,
                            Nombres = b.Usuario.Contacto.Nombres,
                            Apellidos = b.Usuario.Contacto.Apellidos,
                            Anexo = b.Usuario.Contacto.Anexo,
                            Departamento = b.Usuario.Contacto.Departamento,
                            Email = b.Usuario.Contacto.Email,
                            Puesto = b.Usuario.Contacto.Puesto,
                            Rut = b.Usuario.Contacto.Rut,
                            Sociedad = b.Usuario.Contacto.Sociedad,
                            Telefono = b.Usuario.Contacto.Telefono
                        },
                        Cuenta = b.Usuario.Cuenta,
                        Habilitado = b.Usuario.Habilitado
                    },
                    Habilitado = b.Habilitado
                }).ToListAsync();

                if (query is null)
                {
                    return new BadRequestResult();
                }
                else
                {
                    return new OkObjectResult(query);
                }
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        public async Task<IActionResult> Post(RolUsuario rol)
        {
            try
            {
                _context.RolUsuario.Add(rol);
                await _context.SaveChangesAsync();
                return new OkObjectResult(rol);
            }
            catch (DbUpdateException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }


        public async Task<IActionResult> Put(RolUsuario rol, int idRolUsuario)
        {
            try
            {
                var existing = _context.RolUsuario.Where(s => s.Id == idRolUsuario).FirstOrDefault();
                existing.IdRol = rol.IdRol;
                existing.IdUsuario = rol.IdUsuario;
                existing.Habilitado = rol.Habilitado;
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
