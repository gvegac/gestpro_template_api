using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class ListaTemplateFormularioCampo
    {
        public TemplateFormularioDTO Formulario { get; set; }
        public IEnumerable<TemplateFormularioCampoDTO> Campos { get; set; }
    }
}
