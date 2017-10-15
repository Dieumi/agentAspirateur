using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    public class Belief
    {
        public string croyance { get; set; }
        public Belief(string cr)
        {
            croyance = cr;
        }
    }
}
