using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class TemplateFormulario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }

        public ICollection<TemplateFormularioCampo> TemplateFormularioCampos { get; set; }
        public ICollection<TemplateTarea> TemplateTareas { get; set; }

    }

    public class TemplateFormularioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
    }
}
