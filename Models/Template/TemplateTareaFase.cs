using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class TemplateTareaFase
    {
        public int Id { get; set; }
        public int IdTemplateFaseTipo { get; set; }
        public int IdTemplateTarea { get; set; }
        public bool NecesitaAprobacion { get; set; }
        public bool NecesitaArchivo { get; set; }
        public bool Habilitado { get; set; }


        public TemplateFaseTipo TemplateFaseTipo { get; set; }
        public TemplateTarea TemplateTarea { get; set; }
    }

    public class TemplateTareaFaseDTO
    {
        public int Id { get; set; }
        public int IdTemplateFaseTipo { get; set; }
        public TemplateTareaDTO TemplateTarea { get; set; }
        public bool NecesitaAprobacion { get; set; }
        public bool NecesitaArchivo { get; set; }
        public bool Habilitado { get; set; }
    }
}
