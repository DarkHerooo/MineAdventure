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
    public class Block
    {
        public PictureBox PbBlock; // Картинка блока
        public string NameBlock; // Имя блока
        public int HealthBlock; // Прочность

        public Block(int randomNumber, PictureBox pictureBox) // Случайный блок
        {
            PbBlock = pictureBox;

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
            PbBlock.BackgroundImage = Image.FromFile("../../Images/Blocks/" + NameBlock + ".png");
        }

        public bool FindBlock(Point locationPlayer, KeyEventArgs e)
        {
            int xPlayer = locationPlayer.X;
            int yPlayer = locationPlayer.Y;

            switch (e.KeyValue)
            {
                case (char)Keys.Up: // ВВЕРХ
                    if (PbBlock.Location.X == xPlayer && PbBlock.Location.Y == yPlayer - 50)
                        return true;
                    break;

                case (char)Keys.Down: // ВНИЗ
                    if (PbBlock.Location.X == xPlayer && PbBlock.Location.Y == yPlayer + 50)
                        return true;
                    break;

                case (char)Keys.Left: // ВЛЕВО
                    if (PbBlock.Location.X == xPlayer - 50 && PbBlock.Location.Y == yPlayer)
                        return true;
                    break;

                case (char)Keys.Right: // ВПРАВО
                    if (PbBlock.Location.X == xPlayer + 50 && PbBlock.Location.Y == yPlayer)
                        return true;
                    break;
            }
            return false;
        }

        public bool CrashBlock(Player player)
        {
            bool crashBlock = false;

            if (PbBlock.Visible == true)
            {
                HealthBlock -= player.powerDig;

                if (NameBlock == "Dirt")
                {
                    Random rnd = new Random();
                    int randomNumber = rnd.Next(1, 4);
                    SoundPlayer sound = new SoundPlayer("../../Sounds/Blocks/Dirt/Dirt" + randomNumber + ".wav");
                    sound.Play();
                }
                else
                {
                    Random rnd = new Random();
                    int randomNumber = rnd.Next(1, 4);
                    SoundPlayer sound = new SoundPlayer("../../Sounds/Blocks/Stone/Stone" + randomNumber + ".wav");
                    sound.Play();
                }

                if (HealthBlock == 0)
                {
                    PbBlock.Visible = false;
                }
                else
                {
                    try
                    {
                        PbBlock.Image = Image.FromFile("../../Images/DestroyStages/DestroyStage" + HealthBlock + ".png");
                    }
                    catch { }
                }
            }
            else crashBlock = true;

            return crashBlock;
        }
    }
}
