using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    interface Observateur
    {
        void maj(List<ObjetAbstrait> listo);
    }
}
