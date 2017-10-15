using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    public abstract class ObjetAbstrait
    {
     
        public string Nom
        {
            get;
            set;
        }


        public CoordonneesAbstrait Position
        {
            get; set;
        }
        



    }
}
