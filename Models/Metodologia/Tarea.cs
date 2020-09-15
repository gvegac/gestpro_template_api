using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class Tarea
    {
        public int Id { get; set; }
        public int IdTipoTarea { get; set; }
        public int IdFormulario { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public Formulario Formulario { get; set; }
        public ICollection<TareaFase> TareaFases { get; set; }
    }

    public class TareaDTO
    {
        public int Id { get; set; }
        public FormularioDTO Formulario { get; set; }
        public int IdTipoTarea { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}
