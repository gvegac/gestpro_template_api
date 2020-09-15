using ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public int IdContacto { get; set; }
        public string Cuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Habilitado { get; set; }
        public Departamento Departamento { get; set; }
        public Contacto Contacto { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<RolUsuario> Roles { get; set; }
    }

    public class UsuarioDTO
    {
        public int Id { get; set; }
        public DepartamentoDTO Departamento { get; set; }
        public ContactoDTO Contacto { get; set; }
        public string Cuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Habilitado { get; set; }
    }
}
