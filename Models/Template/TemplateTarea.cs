using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class TemplateTarea
    {
        public int Id { get; set; }

        public int IdTemplateFormulario { get; set; }
        public int IdTipoTarea { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }

        public TemplateFormulario TemplateFormulario { get; set; }
        public ICollection<TemplateTareaFase> TemplateFaseTareas { get; set; }
    }

    public class TemplateTareaDTO
    {
        public int Id { get; set; }
        public TemplateFormularioDTO TemplateFormulario { get; set; }
        public int IdTipoTarea { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }

        public List<ListaTemplateFormularioCampo> FormularioCampo { get; set; }
    }
}
