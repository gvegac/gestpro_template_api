using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class Fase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Porcentaje { get; set; }
        public bool Habilitado { get; set; }
        public ICollection<FaseProyecto> FaseProyecto { get; set; }
    }
    public class FaseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int Porcentaje { get; set; }
    }


}
