using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    public class Bijoux : ObjetAbstrait
    {
        public Bijoux(string nom, CoordonneesAbstrait position)
        {
            this.Nom = nom;
            this.Position = position;
        }
    }
}
