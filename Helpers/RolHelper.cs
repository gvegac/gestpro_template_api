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
    public class RolHelper
    {
        private readonly DataContext _context;
        public RolHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Get_id(int id)
        {
            try
            {
                var query = await _context.Rol.Select(b => new RolDTO()
                {
                    Id = b.Id,
                   Nombre = b.Nombre,
                   Descripcion = b.Descripcion,
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
                var query = await _context.Rol.Select(b => new RolDTO()
                {
                    Id = b.Id,
                    Nombre = b.Nombre,
                    Descripcion = b.Descripcion,
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

        public async Task<IActionResult> Post(Rol rol)
        {
            try
            {
                _context.Rol.Add(rol);
                await _context.SaveChangesAsync();
                return new OkObjectResult(rol);
            }
            catch (DbUpdateException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }


        public async Task<IActionResult> Put(Rol rol, int id)
        {
            try
            {
                var existing = _context.Rol.Where(s => s.Id == id).FirstOrDefault();
                existing.Nombre = rol.Nombre;
                existing.Descripcion = rol.Descripcion;
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
