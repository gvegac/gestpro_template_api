using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSK_GESTPRO_SERVICE_TEMPLATE_V2X.Models.Metodologia
{
    public class Metodologia
    {
       public FaseProyectoDTO FasesProyecto { get; set; }
       public IEnumerable<TareaFaseDTO> TareasFase { get; set; }
    }
}
