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
    public class UsuarioHelper
    {
        private readonly DataContext _context;
        public UsuarioHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Get_cuenta(string cuenta)
        {
            try
            {
                var query = await _context.Usuario.Select(b => new UsuarioDTO()
                {
                    Id = b.Id,
                    Cuenta = b.Cuenta,
                    Contacto = new ContactoDTO()
                    {
                        Id = b.Contacto.Id,
                        Anexo = b.Contacto.Anexo,
                        Apellidos = b.Contacto.Apellidos,
                        Departamento = b.Contacto.Departamento,
                        Email = b.Contacto.Email,
                        Nombres = b.Contacto.Nombres,
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
                        Telefono = b.Departamento.Telefono,
                        Url = b.Departamento.Url
                    },
                    FechaCreacion = b.FechaCreacion,
                    Habilitado = b.Habilitado
                }).Where(c => c.Cuenta == cuenta).ToListAsync();

                if(query is null)
                {
                    return new BadRequestResult();
                } else
                {
                    return new OkObjectResult(query);
                }
            } catch(Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }
        public async Task<IActionResult> Get_id(int id)
        {
            try
            {
                var query = await _context.Usuario.Select(b => new UsuarioDTO()
                {
                    Id = b.Id,
                    Cuenta = b.Cuenta,
                    Contacto = new ContactoDTO()
                    {
                        Id = b.Contacto.Id,
                        Anexo = b.Contacto.Anexo,
                        Apellidos = b.Contacto.Apellidos,
                        Departamento = b.Contacto.Departamento,
                        Email = b.Contacto.Email,
                        Nombres = b.Contacto.Nombres,
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
                        Telefono = b.Departamento.Telefono,
                        Url = b.Departamento.Url
                    },
                    FechaCreacion = b.FechaCreacion,
                    Habilitado = b.Habilitado
                }).Where(c => c.Id == id).ToListAsync();

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
                var query = await _context.Usuario.Select(b => new UsuarioDTO()
                {
                    Id = b.Id,
                    Cuenta = b.Cuenta,
                    Contacto = new ContactoDTO()
                    {
                        Id = b.Contacto.Id,
                        Anexo = b.Contacto.Anexo,
                        Apellidos = b.Contacto.Apellidos,
                        Departamento = b.Contacto.Departamento,
                        Email = b.Contacto.Email,
                        Nombres = b.Contacto.Nombres,
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
                        Telefono = b.Departamento.Telefono,
                        Url = b.Departamento.Url
                    },
                    FechaCreacion = b.FechaCreacion,
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

        public async Task <IActionResult> Post(Usuario usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return new OkObjectResult(usuario);
            }
            catch (DbUpdateException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }


        public async Task<IActionResult> Put(Usuario usuario, int idUsuario)
        {
            try
            {
                var existing = _context.Usuario.Where(s => s.Id == idUsuario).FirstOrDefault();
                existing.Cuenta = usuario.Cuenta;
                existing.IdContacto = usuario.IdContacto;
                existing.IdDepartamento = usuario.IdDepartamento;
                existing.Habilitado = usuario.Habilitado;
                existing.FechaCreacion = usuario.FechaCreacion;
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
