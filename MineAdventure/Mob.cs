using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineAdventure
{
    public class Mob
    {
        public PictureBox pbMob; // Картинка моба
        public string nameMob; // Имя моба
        public int healthMob; // Здоровье
        public int powerMob; // Сила

        public Mob(int randomNumber, PictureBox pictureBox) // Случайный моб
        {
            pbMob = pictureBox;
            // Зомби - 35%
            // Скелет - 25%
            // Паук - 20%
            // Крипер - 15%
            // Эндермен - 5%

            if (randomNumber <= 35)
            {
                nameMob = "Zombie";
                healthMob = 5;
                powerMob = 1;
            }
            else if (randomNumber > 35 && randomNumber <= 60)
            {
                nameMob = "Skeleton";
                healthMob = 7;
                powerMob = 2;
            }
            else if (randomNumber > 60 && randomNumber <= 80)
            {
                nameMob = "Spider";
                healthMob = 8;
                powerMob = 3;
            }
            else if (randomNumber > 80 && randomNumber <= 95)
            {
                nameMob = "Creeper";
                healthMob = 9;
                powerMob = 4;
            }
            else
            {
                nameMob = "Enderman";
                healthMob = 10;
                powerMob = 5;
            }
            pbMob.BackgroundImage = Image.FromFile("../../Images/Mobs/" + nameMob + ".png");

        }

        public bool FindMob(Point locationPlayer, KeyEventArgs e)
        {
            int xPlayer = locationPlayer.X;
            int yPlayer = locationPlayer.Y;

            switch (e.KeyValue)
            {
                case (char)Keys.Up: // ВВЕРХ
                    if (pbMob.Location.X == xPlayer && pbMob.Location.Y == yPlayer - 50)
                        return true;
                    break;

                case (char)Keys.Down: // ВНИЗ
                    if (pbMob.Location.X == xPlayer && pbMob.Location.Y == yPlayer + 50)
                        return true;
                    break;

                case (char)Keys.Left: // ВЛЕВО
                    if (pbMob.Location.X == xPlayer - 50 && pbMob.Location.Y == yPlayer)
                        return true;
                    break;

                case (char)Keys.Right: // ВПРАВО
                    if (pbMob.Location.X == xPlayer + 50 && pbMob.Location.Y == yPlayer)
                        return true;
                    break;
            }
            return false;
        }

        public bool KillMob(Player player) // Атака моба
        {
            bool killMob = false;

            if (healthMob > 0)
            {
                player.healthPlayer -= powerMob; // Уменьшаем здоровье игрока
                healthMob -= player.powerHit; // Уменьшаем здоровье врага

                Sound sound = new Sound(nameMob, healthMob); // Звук
                sound.PlayMobSound(); // Проигрываем звук
                
                if (healthMob <= 0)
                    pbMob.Visible = false;
                else
                    pbMob.Image = Image.FromFile("../../Images/DestroyStages/DestroyStage" +
                        healthMob / player.powerHit + ".png");
            }
            else killMob = true;

            return killMob;
        }
    }
}
