using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    public class Agent : ObjetAbstrait
    {
        public Effecteur effecteur { get; set; }
        public Capteur capteur { get; set; }
        public string etat { get; set; }
        public int nbElectricite { get; set; } = 100;
        public Belief belief { get; set; }
        public Desire desire { get; set; }
        public List<Action> lista { get; set; } = new List<Action>();
        public ObjetAbstrait target;
        public Heuristique h;
        public Agent(string nom, CoordonneesAbstrait position)
        {
            this.Nom = nom;
            this.Position = position;
            effecteur = new Effecteur();
            etat = "alive";
            capteur = new Capteur("capteur");
            h = new Heuristique();
        }
        public List<ObjetAbstrait> aspire(List<ObjetAbstrait> list ,CoordonneesAbstrait p)
        {
            List<ObjetAbstrait> newlist = new List<ObjetAbstrait>();
            foreach (ObjetAbstrait o in list)
            {
                if (o.Position.X != p.X && o.Position.Y !=p.Y)
                {
                    newlist.Add(o);
                }
                else
                {
                    Console.WriteLine("l'agent " + this.Nom + " aspire " + this.target.Nom);
                }
            }
            return newlist;
        }
        public List<ObjetAbstrait> ramasse(List<ObjetAbstrait> list, CoordonneesAbstrait p)
        {
            List<ObjetAbstrait> newlist = new List<ObjetAbstrait>();
            foreach (ObjetAbstrait o in list)
            {
                if (o.Position.X != p.X && o.Position.Y != p.Y)
                {
                   
                    newlist.Add(o);
                }
                else
                {
                    if (o.GetType().Equals(typeof(Poussiere)))
                    {
                        newlist.Add(o);
                    }
                    Console.WriteLine("l'agent " + this.Nom + " ramasse " + this.target.Nom);
                }
            }
            return newlist;
        }
        public void exploration()
        {
            lista = new List<Action>();
            target = h.closest(this, capteur.listobjetcapte);
            Agent p = new Agent("agenttest",new Coordonnees(this.Position.X,this.Position.Y));
            p.target = target;
            if (target != null)
            {
                while (p.Position.X != target.Position.X || p.Position.Y != target.Position.Y)
                {
                    p = Deplacement(20, 20, p);
                }
                if (target.GetType().Equals(typeof(Poussiere)))
                {
                    lista.Add(new Action("aspire"));
                }
                else
                {
                    lista.Add(new Action("ramasse"));
                }
            }
          
        }
        public void ResetAction()
        {
           
        }
        public Agent Deplacement(int dimX, int dimY, Agent unPerso)
        {

            if (unPerso.target.Position.X != unPerso.Position.X)
            {
                if (unPerso.target.Position.X > unPerso.Position.X)
                {
                    unPerso.Position.X += 1;
                    lista.Add(new Action("droite"));
                }
                else
                {
                    unPerso.Position.X -= 1;
                    lista.Add(new Action("gauche"));
                }
            }

            if (unPerso.target.Position.Y != unPerso.Position.Y)
            {
                if (unPerso.target.Position.Y > unPerso.Position.Y)
                {
                    unPerso.Position.Y += 1;
                    lista.Add(new Action("bas"));
                }
                else
                {
                    unPerso.Position.Y -= 1;
                    lista.Add(new Action("haut"));
                }
            }
           
            return unPerso;
            
        }
    }
}
