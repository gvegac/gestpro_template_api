using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class TareaFase
    {
        public int Id { get; set; }
        public int IdTarea { get; set; }
        public int IdFaseProyecto { get; set; }
        public int IdEstado { get; set; }
        public bool NecesitaAprobacion { get; set; }
        public bool NecesitaArchivo { get; set; }

        public Tarea Tarea { get; set; }
        public FaseProyecto FaseProyecto { get; set; }
        public Estado Estado { get; set; }

        public ICollection<ContactoTarea> ContactoTarea { get; set; }

    }

    public class TareaFaseDTO
    {
        public int Id { get; set; }
        public FaseProyectoDTO FaseProyecto { get; set; }
        public TareaDTO Tarea { get; set; }
        public EstadoDTO Estado { get; set; }
        public bool NecesitaAprobacion { get; set; }
        public bool NecesitaArchivo { get; set; }
    }
}
