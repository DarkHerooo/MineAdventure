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
        public PictureBox PbMob; // Картинка моба
        public string NameMob; // Имя моба
        public int HealthMob; // Здоровье
        public int PowerMob; // Сила

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

        public bool FindMob(Point locationPlayer, KeyEventArgs e)
        {
            int xPlayer = locationPlayer.X;
            int yPlayer = locationPlayer.Y;

            switch (e.KeyValue)
            {
                case (char)Keys.Up: // ВВЕРХ
                    if (PbMob.Location.X == xPlayer && PbMob.Location.Y == yPlayer - 50)
                        return true;
                    break;

                case (char)Keys.Down: // ВНИЗ
                    if (PbMob.Location.X == xPlayer && PbMob.Location.Y == yPlayer + 50)
                        return true;
                    break;

                case (char)Keys.Left: // ВЛЕВО
                    if (PbMob.Location.X == xPlayer - 50 && PbMob.Location.Y == yPlayer)
                        return true;
                    break;

                case (char)Keys.Right: // ВПРАВО
                    if (PbMob.Location.X == xPlayer + 50 && PbMob.Location.Y == yPlayer)
                        return true;
                    break;
            }
            return false;
        }

        public bool KillMob(Player player) // Атака моба
        {
            bool killMob = false;

            if (PbMob.Visible == true)
            {
                player.healthPlayer -= PowerMob; // Уменьшаем здоровье игрока
                HealthMob -= player.powerHit; // Уменьшаем здоровье врага

                if (HealthMob > 0)
                {
                    Random rnd = new Random();
                    int randomNumber = rnd.Next(1, 4);
                    SoundPlayer sound = new SoundPlayer("../../Sounds/Mobs/" + NameMob + "/Hurt" + randomNumber + ".wav");
                    sound.Play();
                } // Воспроизводим звук
                else
                {
                    SoundPlayer sound = new SoundPlayer("../../Sounds/Mobs/" + NameMob + "/Death.wav");
                    sound.Play();
                }

                if (HealthMob == 0)
                    PbMob.Visible = false;
                else
                {
                    try
                    {
                        PbMob.Image = Image.FromFile("../../Images/DestroyStages/DestroyStage" + HealthMob + ".png");
                    }
                    catch { }
                }
            }
            else killMob = true;

            return killMob;
        }
    }
}
