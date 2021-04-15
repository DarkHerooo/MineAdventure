using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineAdventure
{
    public class Mob
    {
        public PictureBox PbMob;
        public string NameMob; // Имя блока
        public int HealthMob; // Прочность
        public int PowerMob; // Сила
        public string StrSoundMob; // Строка звука

        public Mob(int randomNumber, PictureBox pictureBox) // Случайный моб
        {
            PbMob = pictureBox;
            // Зомби - 35%
            // Скелет - 25%
            // Паук - 20%
            // Крипер - 15%
            // Эндермен - 5%

            if (randomNumber <= 35)
            {
                NameMob = "Zombie";
                HealthMob = 5;
                PowerMob = 1;
            }
            else if (randomNumber > 35 && randomNumber <= 60)
            {
                NameMob = "Skeleton";
                HealthMob = 7;
                PowerMob = 2;
            }
            else if (randomNumber > 60 && randomNumber <= 80)
            {
                NameMob = "Spider";
                HealthMob = 8;
                PowerMob = 3;
            }
            else if (randomNumber > 80 && randomNumber <= 95)
            {
                NameMob = "Creeper";
                HealthMob = 9;
                PowerMob = 4;
            }
            else
            {
                NameMob = "Enderman";
                HealthMob = 10;
                PowerMob = 5;
            }
            PbMob.BackgroundImage = Image.FromFile("../../Images/Mobs/" + NameMob + ".png");

        }
        public Mob(string nameMob, int health) // Звуки мобов
        {
            if (health > 0)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 4);
                StrSoundMob = "../../Sounds/Mobs/" + nameMob + "/Hurt" + randomNumber + ".wav";
            }
            else StrSoundMob = "../../Sounds/Mobs/" + nameMob + "/Death.wav";
        }

    }
}
