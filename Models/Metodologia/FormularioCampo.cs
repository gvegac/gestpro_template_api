using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class FormularioCampo
    {
        public int Id { get; set; }
        public int IdFormulario { get; set; }
        public int IdTipoCampo { get; set; }
        public string Label { get; set; }
        public string Grupo { get; set; }
        public int Orden { get; set; }
        public bool Habilitado { get; set; }

        public Formulario Formulario { get; set; }
    }

    public class FormularioCampoDTO
    {
        public int Id { get; set; }
        public FormularioDTO Formulario { get; set; }
        public int IdTipoCampo { get; set; }
        public string Label { get; set; }
        public int Orden { set; get; }
        public string Grupo { get; set; }
        public bool Habilitado { get; set; }

    }
}
