using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    interface Sujet
    {
        void add(Capteur c);
        void remove(Capteur c);
        void notify();
    }
}
