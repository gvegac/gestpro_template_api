using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSociedad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<ContactoDepartamento> Contactos { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }

    public class DepartamentoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSociedad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
    }
}
