using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Puesto { get; set; }
        public string Sociedad { get; set; }
        public string Departamento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Anexo { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<ContactoProyecto> ContactosProyecto { get; set; }
        public ICollection<ContactoDepartamento> Departamentos { get; set; }
        public ICollection<ContactoTarea> Tareas { get; set; }

    }

    public class ContactoDTO
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Puesto { get; set; }
        public string Sociedad { get; set; }
        public string Departamento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Anexo { get; set; }
    }
}
