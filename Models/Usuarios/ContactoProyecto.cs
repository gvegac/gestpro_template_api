using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class ContactoProyecto
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public int IdContacto { get; set; }

        public bool Habilitado { get; set; }
        public Proyecto Proyecto { get; set; }
        public Contacto Contacto { get; set; }
    }

    public class ContactoProyectoDTO
    {
        public int Id { get; set; }
        public ProyectoDTO Proyecto { get; set; }
        public ContactoDTO Contacto { get; set; }
        public bool Habilitado { get; set; }
    }
}
