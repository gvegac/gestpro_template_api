using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class ContactoTarea
    {
        public int Id { get; set; }
        public int IdTarea { get; set; }
        public int IdContacto { get; set; }
        public bool Habilitado { get; set; }

        public Contacto Contacto { get; set; }
        public TareaFase Tarea { get; set; }
    }

    public class ContactoTareaDTO
    {
        public int Id { get; set; }
        public TareaFaseDTO TareaFase { get; set; }
        public ContactoDTO Contacto { get; set; }
        public bool Habilitado { get; set; }
    }
}
