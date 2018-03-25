using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeWillSurvive
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            List<Enemy> enemyTypeList = new List<Enemy>();
            List<Enemy> enemyList = new List<Enemy>();

            foreach (string line in File.ReadLines(@"C:\Users\ataha\Documents\Visual Studio 2017\Projects\WeWillSurvive\WeWillSurvive\SampleInput1.txt"))
            {
                if(line.StartsWith("Resource"))
                {
                    string[] lineElements = line.Split(' ');
                    hero.DistanceToResources = Convert.ToInt32(lineElements[2]);
                }

                if (line.StartsWith("Hero has"))
                {
                    string[] lineElements = line.Split(' ');
                    hero.HealthPoint = Convert.ToInt32(lineElements[2]);
                }

                if (line.StartsWith("Hero attack"))
                {
                    string[] lineElements = line.Split(' ');
                    hero.AttackDamagePoint = Convert.ToInt32(lineElements[3]);
                }

                if (line.Contains("is Enemy"))
                {
                    Enemy enemyTypeInstance = new Enemy();                    
                    string[] lineElements = line.Split(' ');
                    enemyTypeInstance.Name = lineElements[0];
                    enemyTypeInstance.IsEnemy = true;
                    enemyTypeList.Add(enemyTypeInstance);
                }
                
                for(int i=0;i<enemyTypeList.Count;i++)
                {
                    if(line.Contains(enemyTypeList[i].Name + " has "))
                    {                        
                        string[] lineElements = line.Split(' ');
                        enemyTypeList[i].HealthPoint = Convert.ToInt32(lineElements[2]);
                    }

                    if (line.Contains(enemyTypeList[i].Name + " attack "))
                    {
                        string[] lineElements = line.Split(' ');
                        enemyTypeList[i].AttackDamagePoint = Convert.ToInt32(lineElements[3]);
                    }
                }

                for (int i = 0; i < enemyTypeList.Count; i++)
                {
                    if (line.Contains(enemyTypeList[i].Name + " at position "))
                    {
                        string[] lineElements = line.Split(' ');
                        Enemy newEnemy = new Enemy();
                        newEnemy.Name = enemyTypeList[i].Name;
                        newEnemy.HealthPoint = enemyTypeList[i].HealthPoint;
                        newEnemy.AttackDamagePoint = enemyTypeList[i].AttackDamagePoint;
                        newEnemy.Position = Convert.ToInt32(lineElements[6]);
                        enemyList.Add(newEnemy);
                    }
                }
            }
            
            int[] walkMap = hero.WalkMapToResources(hero.DistanceToResources);
            Enemy.SetEnemyLocations(enemyList, walkMap);
            BattleWithEnemies(hero,enemyList,walkMap);
        }

        

        private static void BattleWithEnemies(Hero h, List<Enemy> listOfEnemies,int[] walkMap)
        {
            int currentPosition = 0;
            Console.WriteLine("Hero started journey with " + "{0} " + "HP!", h.HealthPoint);

            for(int i= currentPosition;i<h.DistanceToResources;i++)
            {
                if(walkMap[i] == 1)
                {
                    h.Attack(h, Enemy.GetEnemyProfileFromLocation(i,listOfEnemies));
                    if (h.HealthPoint < 0)
                    {
                        break;
                    }
                }
            }

            if (h.HealthPoint > 0)
            {
                Console.WriteLine("Hero Survived!");
            }         

        }

       
    }
}
