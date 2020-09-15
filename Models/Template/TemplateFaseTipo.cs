using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class TemplateFaseTipo
    {
        public int Id { get; set; }
        public int IdTipoProyecto { get; set; }
        public int IdTemplateFase { get; set; }
        public bool Habilitado { get; set; }

        public TipoProyecto TipoProyecto { get; set; }
        public TemplateFase TemplateFase { get; set; }
        public ICollection<TemplateTareaFase> TemplateTareas { get; set; }
    }

    public class TemplateFaseTipoDTO
    {
        public int Id { get; set; }
        public int IdTipoProyecto { get; set; }
        public TemplateFaseDTO TemplateFase { get; set; }
        public bool Habilitado { get; set; }
    }
}
