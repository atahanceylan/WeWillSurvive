using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeWillSurvive
{
    public class Hero : Creature
    {
        public int DistanceToResources { get; set; }
        public Hero Attack(Hero h,Enemy e)
        {
            int lastHealthPoint = h.HealthPoint;
               
            if (h.HealthPoint > 0)
            {
                double howManyPunchFloat = ((double)e.HealthPoint / (double)h.AttackDamagePoint);
                int howManyPunch = (int)Math.Ceiling(howManyPunchFloat);                
                h.HealthPoint -= howManyPunch * e.AttackDamagePoint;
            }
           
            if(h.HealthPoint <=0)
            { 
                double howManyPunchFloat = ((double)lastHealthPoint / (double)e.AttackDamagePoint);
                int howManyPunch = (int)Math.Ceiling(howManyPunchFloat);
                e.HealthPoint -= howManyPunch * h.AttackDamagePoint;
            }

            if (h.HealthPoint > 0)
            {
                Console.WriteLine("Hero defeated {0} with " + "{1} " + "HP remaining", e.Name, h.HealthPoint);
            }
            else
            {
                Console.WriteLine("{0} defeated Hero with " + "{1} " + "HP remaining", e.Name,e.HealthPoint);
                Console.WriteLine("Hero is dead!! Last seen at position {0}", e.Position);                
            }

            return h;
        }

        public int[] WalkMapToResources(int distance)
        {
            int[] walkMap = new int[distance];
            for(int i =0;i< distance; i++)
            {
                walkMap[i] = 0;
            }

            return walkMap;
        }

    }
}
