using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Helpers
{
    public class TemplateHelper
    {
        private readonly DataContext _context;
        public TemplateHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Get(int idTipoProyecto, int idProyecto)
        {
            try
            {
                var faseTipos = await _context.TemplateFaseTipo.Select(b => new TemplateFaseTipoDTO()
                                {
                                    Id = b.Id,
                                    TemplateFase = new TemplateFaseDTO()
                                    {
                                        Id = b.TemplateFase.Id,
                                        Nombre = b.TemplateFase.Nombre,
                                        Habilitado = b.TemplateFase.Habilitado,
                                        Porcentaje = b.TemplateFase.Porcentaje
                                    },
                                    IdTipoProyecto = b.IdTipoProyecto,
                                    Habilitado = b.Habilitado
                                }).Where(b=> b.IdTipoProyecto.Equals(idTipoProyecto)).ToListAsync();

                var tareasFase = await _context.TemplateTareaFase.Select(b => new TemplateTareaFaseDTO()
                                {
                                    Id = b.Id,
                                    IdTemplateFaseTipo = b.IdTemplateFaseTipo,
                                    TemplateTarea = new TemplateTareaDTO()
                                    {
                                        Id = b.TemplateTarea.Id,
                                        TemplateFormulario = new TemplateFormularioDTO() {
                                            Id = b.TemplateTarea.TemplateFormulario.Id,
                                            Nombre = b.TemplateTarea.TemplateFormulario.Nombre,
                                            Habilitado = b.TemplateTarea.TemplateFormulario.Habilitado
                                        },
                                        IdTipoTarea = b.TemplateTarea.IdTipoTarea,
                                        Nombre = b.TemplateTarea.Nombre,
                                        Habilitado = b.TemplateTarea.Habilitado
                                    },
                                    Habilitado = b.Habilitado,
                                    NecesitaAprobacion = b.NecesitaAprobacion,
                                    NecesitaArchivo = b.NecesitaArchivo
                }).ToListAsync();
                var camposFormularios = await _context.TemplateFormularioCampo.Select(b =>
                                          new TemplateFormularioCampoDTO()
                                         {
                                              Id = b.Id,
                                              TemplateFormulario = new TemplateFormularioDTO()
                                              {
                                                  Id = b.TemplateFormulario.Id,
                                                  Nombre = b.TemplateFormulario.Nombre,
                                                  Habilitado = b.TemplateFormulario.Habilitado
                                              },
                                              Grupo = b.Grupo,
                                              Habilitado = b.Habilitado,
                                              IdTipoCampo = b.IdTipoCampo,
                                              Label = b.Label,
                                              Orden = b.Orden
                                         }).ToListAsync();

                var query = faseTipos.GroupJoin(tareasFase, c => c.Id, d => d.IdTemplateFaseTipo, (c, result) => new Template(){ Fase = c, Tareas = result }).ToList();
                foreach (var x in query)
                {
                    foreach (var y in x.Tareas)
                    {
                        y.TemplateTarea.FormularioCampo = x.Tareas.GroupJoin(camposFormularios, c => c.TemplateTarea.TemplateFormulario.Id, d => d.TemplateFormulario.Id, (c, result) => new ListaTemplateFormularioCampo() { Formulario = c.TemplateTarea.TemplateFormulario, Campos = result }).Where(a => a.Formulario.Id == y.TemplateTarea.TemplateFormulario.Id).ToList();
                    } 
                }

                if (query is null)
                {
                    return new NotFoundResult();
                }
                else
                {
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        int contFase = 0;
                        int contTareas = 0;
                        FaseProyecto FaseProyecto;
                        Fase Fase;
                        TareaFase Tarea_Fase;
                        Tarea Tarea;
                        Formulario Formulario;
                        FormularioCampo Campo;
                        try
                        {
                            foreach (var x in query)
                            {
                                Fase = new Fase
                                {
                                    Nombre = x.Fase.TemplateFase.Nombre,
                                    Descripcion = "Fase de " + x.Fase.TemplateFase.Nombre,
                                    Habilitado = true,
                                    Porcentaje = x.Fase.TemplateFase.Porcentaje
                                };
                                _context.Fase.Add(Fase);
                                await _context.SaveChangesAsync();
                                foreach (var y in x.Tareas)
                                {
                                    contTareas = +1;
                                    Formulario = new Formulario
                                    {
                                        Nombre = y.TemplateTarea.TemplateFormulario.Nombre,
                                        Descripcion = y.TemplateTarea.TemplateFormulario.Nombre,
                                        FechaCreacion = DateTime.Now,
                                        Habilitado = true
                                    };
                                    _context.Formulario.Add(Formulario);
                                    await _context.SaveChangesAsync();
                                    foreach (var z in y.TemplateTarea.FormularioCampo[0].Campos)
                                    {
                                        Campo = new FormularioCampo
                                        {
                                            IdFormulario = Formulario.Id,
                                            IdTipoCampo = z.IdTipoCampo,
                                            Label = z.Label,
                                            Orden = z.Orden,
                                            Grupo = z.Grupo,
                                            Habilitado = z.Habilitado
                                        };
                                        _context.FormularioCampo.Add(Campo);
                                        await _context.SaveChangesAsync();
                                    }
                                    Tarea = new Tarea
                                    {
                                        Nombre = y.TemplateTarea.Nombre,
                                        Descripcion = y.TemplateTarea.Nombre,
                                        FechaFin = DateTime.Now.AddDays(7),
                                        FechaInicio = DateTime.Now,
                                        IdFormulario = Formulario.Id,
                                        IdTipoTarea = y.TemplateTarea.IdTipoTarea,
                                        Habilitado = true
                                    };
                                    _context.Tarea.Add(Tarea);
                                    await _context.SaveChangesAsync();
                                    if(contFase > 0)
                                    {
                                        FaseProyecto = new FaseProyecto
                                        {
                                            IdEstado = 8,
                                            IdFase = Fase.Id,
                                            IdProyecto = idProyecto,
                                            FechaInicio = DateTime.Now.AddMonths(contFase),
                                            FechaFin = DateTime.Now.AddMonths(contFase + 1)
                                        };
                                    } else
                                    {
                                        FaseProyecto = new FaseProyecto
                                        {
                                            IdEstado = 7,
                                            IdFase = Fase.Id,
                                            IdProyecto = idProyecto,
                                            FechaInicio = DateTime.Now.AddMonths(contFase),
                                            FechaFin = DateTime.Now.AddMonths(contFase+1)
                                        };
                                    }
                                    _context.FaseProyecto.Add(FaseProyecto);
                                    contFase += 1;
                                    await _context.SaveChangesAsync();
                                    Tarea_Fase = new TareaFase
                                    {
                                        IdEstado = 10,
                                        IdFaseProyecto = FaseProyecto.Id,
                                        IdTarea = Tarea.Id,
                                        NecesitaAprobacion = y.NecesitaAprobacion,
                                        NecesitaArchivo = y.NecesitaArchivo
                                    };
                                    _context.TareaFase.Add(Tarea_Fase);
                                }
                                if (contTareas == 0)
                                {
                                    if (contFase > 0)
                                    {
                                        FaseProyecto = new FaseProyecto
                                        {
                                            IdEstado = 8,
                                            IdFase = Fase.Id,
                                            IdProyecto = idProyecto,
                                            FechaInicio = DateTime.Now.AddMonths(contFase),
                                            FechaFin = DateTime.Now.AddMonths(contFase + 1)
                                        };
                                    }
                                    else
                                    {
                                        FaseProyecto = new FaseProyecto
                                        {
                                            IdEstado = 7,
                                            IdFase = Fase.Id,
                                            IdProyecto = idProyecto,
                                            FechaInicio = DateTime.Now.AddMonths(contFase),
                                            FechaFin = DateTime.Now.AddMonths(contFase + 1)
                                        };
                                    }
                                    _context.FaseProyecto.Add(FaseProyecto);
                                    contFase += 1;
                                    await _context.SaveChangesAsync();
                                }
                                contTareas = 0;
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return new BadRequestObjectResult(ex.InnerException.Message);
                        }

                    }
                    return new OkResult();
                }
            }
            catch (DbException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }
        public async Task<IActionResult> Post(Template[] template)
        {
            try
            {
                TemplateLog templateLog = new TemplateLog();
                templateLog.FechaCreacion = DateTime.Now;
                templateLog.IdTipoProyecto = template[0].Fase.IdTipoProyecto;
                templateLog.Version = "v1";
                templateLog.Json = JsonConvert.SerializeObject(template, Formatting.Indented);
                _context.TemplateLog.Add(templateLog);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch (DbUpdateException ex)
            {
                return new BadRequestObjectResult(ex.InnerException.Message);
            }
        }

    }
}
