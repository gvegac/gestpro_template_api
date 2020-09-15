using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Usuarios
{
    public class RolModulo
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdModulo { get; set; }
        public bool Habilitado { get; set; }
        public Rol Rol { get; set; }
        public Modulo Modulo { get; set; }
    }

    public class RolModuloDTO
    {
        public int Id { get; set; }
        public RolDTO Rol { get; set; }
        public ModuloDTO Modulo { get; set; }
        public bool Habilitado { get; set; }

    }
}
