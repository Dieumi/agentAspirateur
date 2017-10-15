using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgentAspirateur
{
    public class Env : Sujet
    {
        public static Random Hazard = new Random();
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int vitesse = 500;
        public Agent agent;
        public List<Capteur> listc = new List<Capteur>();
        public List<ObjetAbstrait> list = new List<ObjetAbstrait>();
        public Env(int _dimensionX, int _dimensionY)
        {
            
            this.DimensionX = _dimensionX;
            this.DimensionY = _dimensionY;
            Thread t1 = new Thread(createAgent);
            t1.Start();
            
        }
        public void createAgent()
        {
            
            Agent a1 = new Agent("aspiro",new Coordonnees(10,10));
            this.agent = a1;
            add(this.agent.capteur);
           
        }
        public void TourSuivant()
        {
            
            if (Hazard.Next(1, 11) >=5)
            {
                AjoutePoussiere();
            }
            if (Hazard.Next(1, 11) == 1)
            {
                AjouteBijoux();
            }
           



        }
        public  void AjoutePoussiere()
        {
            CoordonneesAbstrait position = new Coordonnees(Hazard.Next(1, DimensionX), Hazard.Next(1, DimensionY));
            ObjetAbstrait p= new Poussiere(String.Format("Poussiere {0}", list.Count), position);
            list.Add(p);
          

        }
        public void AjouteBijoux()
        {
            CoordonneesAbstrait position = new Coordonnees(Hazard.Next(1, DimensionX), Hazard.Next(1, DimensionY));
            ObjetAbstrait p = new Bijoux(String.Format("Bijoux {0}", list.Count), position);
            list.Add(p);
            


        }
        public  void Avance()
        {
            while (true)
            {
                Thread.Sleep(vitesse);
                TourSuivant();
                start();
            }
         

        }
        public void start()
        {
            while (amIalive())
            {
                ObserveEnvironmentWithAllMySensors();
                UpdateMyState();
                ChooseAnAction();
                justDoIt();
            }
        }
        public void ObserveEnvironmentWithAllMySensors()
        {
            notify();
        }
        public void UpdateMyState()
        {
            if (this.agent.desire == null || this.agent.capteur.listobjetcapte.Count > 0)
            {
                this.agent.desire = new Desire("nettoyer");
                this.agent.etat = "alive";
            }else if (this.agent.capteur.listobjetcapte.Count==0) {
                this.agent.desire = new Desire("arret");
                this.agent.etat = "notAlive";
            }
            this.agent.belief = new Belief( "propre");
            foreach(ObjetAbstrait o in this.agent.capteur.listobjetcapte)
            {
                if (this.agent.Position == o.Position)
                {
                    if (o.GetType().Equals(typeof(Poussiere)))
                    {
                        this.agent.belief =new Belief( "sale");
                    }
                    if (o.GetType().Equals(typeof(Bijoux)))
                    {
                        this.agent.belief = new Belief("bijoux");
                        break;
                    }

                }
                
            }
        }
        public void ChooseAnAction()
        {
            if (this.agent.belief.croyance == "propre")
            {
                this.agent.exploration();

            }
            if (this.agent.belief.croyance == "sale")
            {
                this.agent.lista.Add(new Action("aspire"));
                
            }
            if (this.agent.belief.croyance == "bijoux")
            {
                this.agent.lista.Add(new Action("ramasse"));

            }
           
        }
        public void justDoIt()
        {
            foreach(Action a in this.agent.lista)
            {
                if (a.action == "aspire")
                {
                    list=this.agent.aspire(list,this.agent.Position);
                }
                if (a.action == "droite")
                {
                   this.agent.Position.X+=1;
                }
                if (a.action == "haut")
                {
                    this.agent.Position.Y -= 1;
                }
                if (a.action == "bas")
                {
                    this.agent.Position.Y += 1;
                }
                if (a.action == "gauche")
                {
                    this.agent.Position.X -= 1;
                }
                if (a.action == "ramasse")
                {
                    list = this.agent.ramasse(list, this.agent.Position);
                }
            }
        }
      
        public bool amIalive()
        {
            if (this.agent.etat == "alive" || this.agent.capteur.listobjetcapte.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void add(Capteur c)
        {
            listc.Add(c);
        }

        public void remove(Capteur c)
        {
            listc.Remove(c);
        }

        public void notify()
        {
            foreach(Capteur c in listc)
            {
                c.maj(list);
            }
        }
    }
}
