using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class TemplateLog
    {
        public int Id { get; set; }
        public int IdTipoProyecto { get; set; }
        public string Json { get; set; }
        public string Version { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Habilitado { get; set; }

        public TipoProyecto TipoProyecto { get; set; }
    }
}
