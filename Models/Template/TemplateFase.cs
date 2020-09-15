using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class TemplateFase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Porcentaje { get; set; }
        public bool Habilitado { get; set; }

        public ICollection<TemplateFaseTipo> TemplateFaseTipo { get; set; }
    }

    public class TemplateFaseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Porcentaje { get; set; }
        public bool Habilitado { get; set; }
    }
}
