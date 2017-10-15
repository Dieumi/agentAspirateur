using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    public class Heuristique
    {
        private  double Pow2(double x)
        {
            return x * x;
        }

        private  double Distance2(Agent a1, ObjetAbstrait o)
        {
            return Pow2(o.Position.X - a1.Position.X) + Pow2(o.Position.Y - a1.Position.Y);
        }
       
        public  ObjetAbstrait closest(Agent a1, List<ObjetAbstrait> listn)
        {
            ObjetAbstrait closest = null;
            double minDist2 = double.MaxValue;
            foreach (ObjetAbstrait n in listn)
            {
                double dist2 = Distance2(a1, n);
                if (dist2 < minDist2)
                {
                    minDist2 = dist2;
                    closest = n;
                }
            }
            return closest;
        }
    }
}
