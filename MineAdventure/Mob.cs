using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineAdventure
{
    class Mob
    {
        public string NameMob; // Имя блока
        public string TypeMob; // Тип блока
        public int HealthMob; // Прочность
        public int PowerMob; // Сила
        public string StrSoundMob; // Строка звука

        public Mob(int randomNumber) // Случайный моб
        {
            TypeMob = "Mob";

            // Зомби - 35%
            // Скелет - 25%
            // Паук - 20%
            // Крипер - 15%
            // Эндермен - 5%

            if (randomNumber <= 35)
            {
                NameMob = "Zombie";
                HealthMob = 5;
            }
            else if (randomNumber > 35 && randomNumber <= 60)
            {
                NameMob = "Skeleton";
                HealthMob = 7;
            }
            else if (randomNumber > 60 && randomNumber <= 80)
            {
                NameMob = "Spider";
                HealthMob = 8;
            }
            else if (randomNumber > 80 && randomNumber <= 95)
            {
                NameMob = "Creeper";
                HealthMob = 9;
            }
            else
            {
                NameMob = "Enderman";
                HealthMob = 10;
            }
        }

        public Mob(string nameBlock, int health) // Звуки мобов
        {
            if (health > 0)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 4);
                StrSoundMob = "../../Sounds/Mobs/" + nameBlock + "/Hurt" + randomNumber + ".wav";
            }
            else StrSoundMob = "../../Sounds/Mobs/" + nameBlock + "/Death.wav";
        }

    }
}
