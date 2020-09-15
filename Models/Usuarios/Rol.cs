using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public ICollection<RolUsuario> RolUsuarios { get; set; }
        public ICollection<RolModulo> RolModulos { get; set; }
        public ICollection<RolPermiso> RolPermisos { get; set; }

    }

    public class RolDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}
