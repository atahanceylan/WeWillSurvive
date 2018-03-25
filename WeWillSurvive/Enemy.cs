using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeWillSurvive
{
    public class Enemy : Creature
    {
        public static int[] SetEnemyLocations(List<Enemy> listOfEnemies, int[] walkMap)
        {
            List<Enemy> positionSortedEnemies = listOfEnemies.OrderBy(o => o.Position).ToList();

            for (int i = 0; i < positionSortedEnemies.Count; i++)
            {
                walkMap[positionSortedEnemies[i].Position] = 1;
            }

            return walkMap;

        }

        public static Enemy GetEnemyProfileFromLocation(int location, List<Enemy> listOfEnemies)
        {
            Enemy e = new Enemy();

            for (int i = 0; i < listOfEnemies.Count; i++)
            {
                if (listOfEnemies[i].Position == location)
                {
                    e = listOfEnemies[i];
                    break;
                }
            }

            return e;
        }

    }
}
