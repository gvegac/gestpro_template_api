using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class RolUsuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public Usuario Usuario { get; set; }
        public bool Habilitado { get; set; }
        public Rol Rol { get; set; }
    }

    public class RolUsuarioDTO
    {
        public int Id { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public RolDTO Rol { get; set; }
        public bool Habilitado { get; set; }

    }
}
