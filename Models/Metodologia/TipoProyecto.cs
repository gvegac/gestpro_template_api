using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class TipoProyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<TemplateFaseTipo> Templates { get; set; }
        public ICollection<TemplateLog> Logs { get; set; }
    }

    public class TipoProyectoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
