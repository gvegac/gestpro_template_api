using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class Template
    {
        public TemplateFaseTipoDTO Fase { get; set; }
        public IEnumerable<TemplateTareaFaseDTO> Tareas { get; set; }
    }
}
