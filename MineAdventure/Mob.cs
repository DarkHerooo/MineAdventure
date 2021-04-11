using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineAdventure
{
    class Mob
    {
        public string NameMob;
        public int HealthMob;
        public string StrImageMob;
        public int powerMob;

        public Mob(int randomNumber)
        {
            // Зомби - 35%
            // Скелет - 25%
            // Паук - 20%
            // Крипер - 15%
            // Эндермен - 5%

            if (randomNumber <= 35)
            {
                NameMob = "Zombie";
                HealthMob = 5;
                StrImageMob = "../../Images/Mobs/Zombie.png";
            }
            else if (randomNumber > 35 && randomNumber <= 60)
            {
                NameMob = "Skeleton";
                HealthMob = 7;
                StrImageMob = "../../Images/Mobs/Skeleton.png";
            }
            else if (randomNumber > 60 && randomNumber <= 80)
            {
                NameMob = "Spider";
                HealthMob = 8;
                StrImageMob = "../../Images/Mobs/Spider.png";
            }
            else if (randomNumber > 80 && randomNumber <= 95)
            {
                NameMob = "Creeper";
                HealthMob = 9;
                StrImageMob = "../../Images/Mobs/Creeper.png";
            }
            else
            {
                NameMob = "Enderman";
                HealthMob = 10;
                StrImageMob = "../../Images/Mobs/Enderman.png";
            }
        }

        public Mob(string nameMob)
        {
            switch (nameMob)
            {
                case "Zombie": powerMob = 2; break;
                case "Skeleton": powerMob = 2; break;
                case "Spider": powerMob = 2; break;
                case "Creeper": powerMob = 3; break;
                case "Enderman": powerMob = 4; break;
                default: powerMob = 0; break;
            }
        }
    }
}
