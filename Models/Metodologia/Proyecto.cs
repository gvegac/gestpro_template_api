using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class Proyecto
    {
        public int Id { get; set; }
        public int IdTipoProyecto { get; set; }
        public int IdDepartamento { get; set; }
        public int IdEstado { get; set; }
        public int IdContacto { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Prioridad { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
        public TipoProyecto TipoProyecto { get; set; }
        public Estado Estado { get; set; }
        public ICollection<FaseProyecto> FaseProyectos { get; set; }
        public ICollection<ContactoProyecto> Contactos { get; set; }
    }

    public class ProyectoDTO
    {
        public int Id { get; set; }
        public TipoProyectoDTO TipoProyecto { get; set; }
        public int IdDepartamento { get; set; }
        public EstadoDTO Estado { get; set; }
        public int IdContacto { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Prioridad { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
    }

}
