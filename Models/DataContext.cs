using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template;
using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        public DbSet<TemplateFase> TemplateFase { get; set; }
        public DbSet<TemplateTareaFase> TemplateTareaFase { get; set; }
        public DbSet<TipoProyecto> TipoProyecto { get; set; }
        public DbSet<TemplateFaseTipo> TemplateFaseTipo { get; set; }
        public DbSet<TemplateFormulario> TemplateFormulario { get; set; }
        public DbSet<TemplateFormularioCampo> TemplateFormularioCampo { get; set; }
        public DbSet<TemplateTarea> TemplateTarea { get; set; }

        //--------------------------------------------------//

        public DbSet<Fase> Fase { get; set; }
        public DbSet<FaseProyecto> FaseProyecto { get; set; }
        public DbSet<Formulario> Formulario { get; set; }
        public DbSet<FormularioCampo> FormularioCampo { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<TareaFase> TareaFase { get; set; }
        public DbSet<TemplateLog> TemplateLog { get; set; }

        //------------------------------------------------------//

        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolModulo> RolModulo { get; set; }
        public DbSet<RolPermiso> RolPermiso { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<ContactoDepartamento> ContactoDepartamento { get; set; }
        public DbSet<ContactoProyecto> ContactoProyecto { get; set; }
        public DbSet<ContactoTarea> ContactoTarea { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<Departamento> Departamento { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemplateFaseTipo>(entity =>
            {
                entity.ToTable("template_fase_tipo");
                entity.Property(e => e.IdTipoProyecto).HasColumnName("id_tipo_proyecto");
                entity.Property(e => e.IdTemplateFase).HasColumnName("id_template_fase");
                entity.HasOne(d => d.TipoProyecto)
                     .WithMany(p => p.Templates)
                     .HasForeignKey(d => d.IdTipoProyecto);
                entity.HasOne(d => d.TemplateFase)
                     .WithMany(p => p.TemplateFaseTipo)
                     .HasForeignKey(d => d.IdTemplateFase);

            });
            modelBuilder.Entity<TemplateFase>(entity =>
            {
                entity.ToTable("template_fase");

            });
            modelBuilder.Entity<TemplateTareaFase>(entity =>
            {
                entity.ToTable("template_tarea_fase");
                entity.Property(e => e.IdTemplateFaseTipo).HasColumnName("id_template_fase_tipo");
                entity.Property(e => e.IdTemplateTarea).HasColumnName("id_template_tarea");
                entity.Property(e => e.NecesitaAprobacion).HasColumnName("necesita_aprobacion");
                entity.Property(e => e.NecesitaArchivo).HasColumnName("necesita_archivo");
                entity.HasOne(d => d.TemplateFaseTipo)
                     .WithMany(p => p.TemplateTareas)
                     .HasForeignKey(d => d.IdTemplateFaseTipo);
                entity.HasOne(d => d.TemplateTarea)
                     .WithMany(p => p.TemplateFaseTareas)
                     .HasForeignKey(d => d.IdTemplateTarea);
            });
            modelBuilder.Entity<TemplateFormulario>(entity =>
            {
                entity.ToTable("template_formulario");
            });
            modelBuilder.Entity<TemplateFormularioCampo>(entity =>
            {
                entity.ToTable("template_formulario_campo");
                entity.Property(e => e.IdTemplateFormulario).HasColumnName("id_template_formulario");
                entity.Property(e => e.IdTipoCampo).HasColumnName("id_tipo_campo");
                entity.HasOne(d => d.TemplateFormulario)
                     .WithMany(p => p.TemplateFormularioCampos)
                     .HasForeignKey(d => d.IdTemplateFormulario);
            });
            modelBuilder.Entity<TemplateTarea>(entity =>
            {
                entity.ToTable("template_tarea");
                entity.Property(e => e.IdTipoTarea).HasColumnName("id_tipo_tarea");
                entity.Property(e => e.IdTemplateFormulario).HasColumnName("id_template_formulario");
                entity.HasOne(d => d.TemplateFormulario)
                     .WithMany(p => p.TemplateTareas)
                     .HasForeignKey(d => d.IdTemplateFormulario);
            });

            //-------------------------------//

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("proyecto");
                entity.Property(e => e.IdTipoProyecto).HasColumnName("id_tipo_proyecto");
                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
                entity.Property(e => e.IdEstado).HasColumnName("id_estado");
                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
                entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
                entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
                entity.Property(e => e.FechaFin).HasColumnName("fecha_fin_estimado");
                entity.HasOne(d => d.TipoProyecto)
                     .WithMany(p => p.Proyectos)
                     .HasForeignKey(d => d.IdTipoProyecto);
                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdEstado);
            });
            modelBuilder.Entity<TipoProyecto>(entity =>
            {
                entity.ToTable("tipo_proyecto");
            });
            modelBuilder.Entity<Fase>(entity =>
            {
                entity.ToTable("fase");

            });
            modelBuilder.Entity<FaseProyecto>(entity =>
            {
                entity.ToTable("fase_proyecto");
                entity.Property(e => e.IdFase).HasColumnName("id_fase");
                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
                entity.Property(e => e.IdEstado).HasColumnName("id_estado");
                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
                entity.Property(e => e.FechaFin).HasColumnName("fecha_fin_estimado");
                entity.HasOne(d => d.Fase)
                     .WithMany(p => p.FaseProyecto)
                     .HasForeignKey(d => d.IdFase);
                entity.HasOne(d => d.Proyecto)
                     .WithMany(p => p.FaseProyectos)
                     .HasForeignKey(d => d.IdProyecto);
                entity.HasOne(d => d.Estado)
                     .WithMany(p => p.Fases)
                     .HasForeignKey(d => d.IdEstado);
            });
            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.ToTable("formulario");
                entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            });
            modelBuilder.Entity<FormularioCampo>(entity =>
            {
                entity.ToTable("formulario_campo");
                entity.Property(e => e.IdFormulario).HasColumnName("id_formulario");
                entity.Property(e => e.IdTipoCampo).HasColumnName("id_tipo_campo");
                entity.HasOne(d => d.Formulario)
                     .WithMany(p => p.FormularioCampo)
                     .HasForeignKey(d => d.IdFormulario);
            });
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("tarea");
                entity.Property(e => e.IdFormulario).HasColumnName("id_formulario");
                entity.Property(e => e.IdTipoTarea).HasColumnName("id_tipo_tarea");
                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
                entity.Property(e => e.FechaFin).HasColumnName("fecha_fin_estimado");
                entity.HasOne(d => d.Formulario)
                     .WithMany(p => p.Tareas)
                     .HasForeignKey(d => d.IdFormulario);
            });
            modelBuilder.Entity<TareaFase>(entity =>
            {
                entity.ToTable("tarea_fase");
                entity.Property(e => e.IdTarea).HasColumnName("id_tarea");
                entity.Property(e => e.IdFaseProyecto).HasColumnName("id_fase_proyecto");
                entity.Property(e => e.IdEstado).HasColumnName("id_estado");
                entity.Property(e => e.NecesitaAprobacion).HasColumnName("necesita_aprobacion");
                entity.Property(e => e.NecesitaArchivo).HasColumnName("necesita_archivo");
                entity.HasOne(d => d.FaseProyecto)
                     .WithMany(p => p.TareasFase)
                     .HasForeignKey(d => d.IdFaseProyecto);
                entity.HasOne(d => d.Tarea)
                     .WithMany(p => p.TareaFases)
                     .HasForeignKey(d => d.IdTarea);
                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdEstado);
            });
            modelBuilder.Entity<TemplateLog>(entity =>
            {
                entity.ToTable("template_log");
                entity.Property(e => e.IdTipoProyecto).HasColumnName("id_tipo_proyecto");
                entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
                entity.HasOne(d => d.TipoProyecto)
                     .WithMany(p => p.Logs)
                     .HasForeignKey(d => d.IdTipoProyecto);
            });

            //-----------------------------------------//

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.IdSociedad).HasColumnName("id_sociedad");
            });
            modelBuilder.Entity<Contacto>(entity => {
                entity.ToTable("contacto");
            });
            modelBuilder.Entity<ContactoDepartamento>(entity => {
                entity.ToTable("departamento_contacto");
                entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
                entity.HasOne(e => e.Contacto)
                    .WithMany(e => e.Departamentos)
                    .HasForeignKey(d => d.IdContacto);
                entity.HasOne(e => e.Departamento)
                    .WithMany(e => e.Contactos)
                    .HasForeignKey(d => d.IdDepartamento);
            });
            modelBuilder.Entity<ContactoProyecto>(entity => {
                entity.ToTable("proyecto_contacto");
                entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
                entity.HasOne(e => e.Proyecto)
                    .WithMany(e => e.Contactos)
                    .HasForeignKey(d => d.IdProyecto);
                entity.HasOne(e => e.Contacto)
                    .WithMany(e => e.ContactosProyecto)
                    .HasForeignKey(d => d.IdContacto);
            });
            modelBuilder.Entity<ContactoTarea>(entity => {
                entity.ToTable("tarea_contacto");
                entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
                entity.Property(e => e.IdTarea).HasColumnName("id_tarea");
                entity.HasOne(e => e.Tarea)
                    .WithMany(e => e.ContactoTarea)
                    .HasForeignKey(d => d.IdTarea);
                entity.HasOne(e => e.Contacto)
                    .WithMany(e => e.Tareas)
                    .HasForeignKey(d => d.IdContacto);
            });
            modelBuilder.Entity<Modulo>(entity => {
                entity.ToTable("modulo");
                
            });
            modelBuilder.Entity<Permiso>(entity => {
                entity.ToTable("permiso");
            });
            modelBuilder.Entity<Rol>(entity => {
                entity.ToTable("Rol");
            });
            modelBuilder.Entity<RolModulo>(entity => {
                entity.ToTable("rol_modulo");
                entity.Property(e => e.IdRol).HasColumnName("id_rol");
                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");
                entity.HasOne(e => e.Modulo)
                    .WithMany(e => e.RolModulo)
                    .HasForeignKey(d => d.IdModulo);
                entity.HasOne(e => e.Rol)
                   .WithMany(e => e.RolModulos)
                   .HasForeignKey(d => d.IdRol);

            });
            modelBuilder.Entity<RolPermiso>(entity => {
                entity.ToTable("rol_permiso");
                entity.Property(e => e.IdRol).HasColumnName("id_rol");
                entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
                entity.HasOne(e => e.Permiso)
                   .WithMany(e => e.RolPermiso)
                   .HasForeignKey(d => d.IdPermiso);
                entity.HasOne(e => e.Rol)
                   .WithMany(e => e.RolPermisos)
                   .HasForeignKey(d => d.IdRol);
            });
            modelBuilder.Entity<RolUsuario>(entity => {
                entity.ToTable("usuario_rol");
                entity.Property(e => e.IdRol).HasColumnName("id_rol");
                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
                entity.HasOne(e => e.Usuario)
                   .WithMany(e => e.Roles)
                   .HasForeignKey(d => d.IdUsuario);
                entity.HasOne(e => e.Rol)
                   .WithMany(e => e.RolUsuarios)
                   .HasForeignKey(d => d.IdRol);
            });
            modelBuilder.Entity<Usuario>(entity => {
                entity.ToTable("usuario");
                entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
                entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
                entity.HasOne(e => e.Contacto)
                   .WithMany(e => e.Usuarios)
                   .HasForeignKey(d => d.IdContacto);
                entity.HasOne(e => e.Departamento)
                   .WithMany(e => e.Usuarios)
                   .HasForeignKey(d => d.IdDepartamento);
            });
        }
    }
}
