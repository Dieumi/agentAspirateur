using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    public class Capteur : Observateur
    {
        public string nom;
        public List<ObjetAbstrait> listobjetcapte = new List<ObjetAbstrait>();
        public Capteur(string name)
        {
            nom = name;

        }

        public void maj(List<ObjetAbstrait> listo)
        {
            listobjetcapte = listo;
        }
    }
}
