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
        public int PowerBlock; // Сила
        public string StrImageBlock; // Строка картинки
        public string StrSoundBlock; // Строка звука

        private void RandomBlock(int randomNumber) // Случайный блок
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
                StrImageBlock = "../../Images/Blocks/Dirt.png";
            }
            else if (randomNumber > 30 && randomNumber <= 55)
            {
                NameBlock = "Stone";
                HealthBlock = 5;
                StrImageBlock = "../../Images/Blocks/Stone.png";
            }
            else if (randomNumber > 55 && randomNumber <= 74)
            {
                NameBlock = "Coal";
                HealthBlock = 7;
                StrImageBlock = "../../Images/Blocks/Coal.png";
            }
            else if (randomNumber > 74 && randomNumber <= 88)
            {
                NameBlock = "Iron";
                HealthBlock = 8;
                StrImageBlock = "../../Images/Blocks/Iron.png";
            }
            else if (randomNumber > 88 && randomNumber <= 97)
            {
                NameBlock = "Gold";
                HealthBlock = 9;
                StrImageBlock = "../../Images/Blocks/Gold.png";
            }
            else
            {
                NameBlock = "Diamond";
                HealthBlock = 10;
                StrImageBlock = "../../Images/Blocks/Diamond.png";
            }
        }
        
        private void RandomMob(int randomNumber) // Случайный моб
        {
            TypeBlock = "Mob";

            // Зомби - 35%
            // Скелет - 25%
            // Паук - 20%
            // Крипер - 15%
            // Эндермен - 5%

            if (randomNumber <= 35)
            {
                NameBlock = "Zombie";
                HealthBlock = 5;
                StrImageBlock = "../../Images/Mobs/Zombie.png";
            }
            else if (randomNumber > 35 && randomNumber <= 60)
            {
                NameBlock = "Skeleton";
                HealthBlock = 7;
                StrImageBlock = "../../Images/Mobs/Skeleton.png";
            }
            else if (randomNumber > 60 && randomNumber <= 80)
            {
                NameBlock = "Spider";
                HealthBlock = 8;
                StrImageBlock = "../../Images/Mobs/Spider.png";
            }
            else if (randomNumber > 80 && randomNumber <= 95)
            {
                NameBlock = "Creeper";
                HealthBlock = 9;
                StrImageBlock = "../../Images/Mobs/Creeper.png";
            }
            else
            {
                NameBlock = "Enderman";
                HealthBlock = 10;
                StrImageBlock = "../../Images/Mobs/Enderman.png";
            }
        }
        
        private void PowerAndSoundBlock(string nameBlock)
        {
            PowerBlock = 0;

            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 4);
            if (nameBlock == "Dirt") StrSoundBlock = "../../Sounds/Blocks/Dirt/Dirt" + randomNumber + ".mp3";
            else StrSoundBlock = "../../Sounds/Blocks/Stone/Stone" + randomNumber + ".mp3";
        }
        private void PowerAndSoundMob(string nameBlock, int health)
        {
            if (health > 0)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 4);
                StrSoundBlock = "../../Sounds/Mobs/" + nameBlock + "/Hurt" + randomNumber + ".mp3";
            }
            else StrSoundBlock = "../../Sounds/Mobs/" + nameBlock + "/Death.mp3";
        }

        public Block(int randomNumber)
        {
            Random rnd = new Random();
            int randomBlockOrMob = rnd.Next(1, 100);

            // Блок - 95%
            // Моб - 5%

            if (randomBlockOrMob <= 95) RandomBlock(randomNumber);
            else RandomMob(randomNumber);
        }

        public Block(string typeBlock, string nameBlock, int health)
        {
            switch (typeBlock)
            {
                case "Block": PowerAndSoundBlock(nameBlock); break;
                case "Mob": PowerAndSoundMob(nameBlock, health); break;
            }

            
        }
    }
}
