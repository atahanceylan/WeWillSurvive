using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeWillSurvive
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int AttackDamagePoint { get; set; }
        public int Position { get; set; }
        public bool IsEnemy { get; set; }       
                       
    }
}
