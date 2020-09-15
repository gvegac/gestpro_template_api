using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class RolPermiso
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }
        public bool Habilitado { get; set; }
        public Rol Rol { get; set; }
        public Permiso Permiso { get; set; }
    }

    public class RolPermisoDTO
    {
        public int Id { get; set; }
        public RolDTO Rol { get; set; }
        public PermisoDTO Permiso { get; set; }
        public bool Habilitado { get; set; }

    }
}
