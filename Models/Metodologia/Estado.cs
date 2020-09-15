using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modulo { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<FaseProyecto> Fases { get; set; }
        public ICollection<TareaFase> Tareas { get; set; }
    }

    public class EstadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modulo { get; set; }
    }
}
