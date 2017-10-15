using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
   public class Poussiere : ObjetAbstrait
    {
        public Poussiere(string nom, CoordonneesAbstrait position)
        {
            this.Nom = nom;
            this.Position = position;
        }
    }
}
