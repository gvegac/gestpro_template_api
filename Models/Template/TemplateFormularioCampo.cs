using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Template
{
    public class TemplateFormularioCampo
    {
        public int Id { get; set; }
        public int IdTemplateFormulario { get; set; }
        public int IdTipoCampo { get; set; }
        public string Label { get; set; }
        public int Orden { set; get; }
        public string Grupo { get; set; }
        public bool Habilitado { get; set; }

        public TemplateFormulario TemplateFormulario { get; set; }
    }
    public class TemplateFormularioCampoDTO
    {
        public int Id { get; set; }
        public TemplateFormularioDTO TemplateFormulario { get; set; }
        public int IdTipoCampo { get; set; }
        public string Label { get; set; }
        public int Orden { set; get; }
        public string Grupo { get; set; }
        public bool Habilitado { get; set; }

    }
}