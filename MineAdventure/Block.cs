using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineAdventure
{
    class Block
    {
        public string NameBlock; // Имя блока
        public string TypeBlock; // Тип блока
        public int HealthBlock; // Прочность
        public string StrSoundBlock; // Строка звука

        public Block(int randomNumber) // Случайный блок
        {
            TypeBlock = "Block";
            // Земля - 30%
            // Камень - 25%
            // Уголь - 19%
            // Железо - 14%
            // Золото - 9%
            // Алмаз - 3%

            if (randomNumber <= 30)
            {
                NameBlock = "Dirt";
                HealthBlock = 3;
            }
            else if (randomNumber > 30 && randomNumber <= 55)
            {
                NameBlock = "Stone";
                HealthBlock = 5;
            }
            else if (randomNumber > 55 && randomNumber <= 74)
            {
                NameBlock = "Coal";
                HealthBlock = 7;
            }
            else if (randomNumber > 74 && randomNumber <= 88)
            {
                NameBlock = "Iron";
                HealthBlock = 8;
            }
            else if (randomNumber > 88 && randomNumber <= 97)
            {
                NameBlock = "Gold";
                HealthBlock = 9;
            }
            else
            {
                NameBlock = "Diamond";
                HealthBlock = 10;
            }
        }

        public Block(string nameBlock)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 4);
            if (nameBlock == "Dirt") StrSoundBlock = "../../Sounds/Blocks/Dirt/Dirt" + randomNumber + ".wav";
            else StrSoundBlock = "../../Sounds/Blocks/Stone/Stone" + randomNumber + ".wav";
        }
    }
}
