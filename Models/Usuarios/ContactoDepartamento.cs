using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class ContactoDepartamento
    {
        public int Id { get; set; }
        public int IdContacto { get; set; }
        public int IdDepartamento { get; set; }

        public bool Habilitado { get; set; }
        public Contacto Contacto { get; set; }
        public Departamento Departamento { get; set; }
    }

    public class ContactoDepartamentoDTO
    {
        public int Id { get; set; }
        public ContactoDTO Contacto { get; set; }
        public DepartamentoDTO Departamento { get; set; }

        public bool Habilitado { get; set; }
    }
}
