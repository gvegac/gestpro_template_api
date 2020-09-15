using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class FaseProyecto
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public int IdFase { get; set; }
        public int IdEstado { get; set; }

        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public Proyecto Proyecto { get; set; }
        public Fase Fase { get; set; }
        public Estado Estado { get; set; }

        public ICollection<TareaFase> TareasFase { get; set; }
    }

    public class FaseProyectoDTO
    {
        public int Id { get; set; }
        public ProyectoDTO Proyecto { get; set; }
        public FaseDTO Fase { get; set; }
        public EstadoDTO Estado { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaInicio { get; set; }
    }
}
