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
        public PictureBox pbBlock; // Картинка блока
        public string nameBlock; // Имя блока
        public int healthBlock; // Прочность

        public Block(int randomNumber, PictureBox pb) // Случайный блок
        {
            pbBlock = pb;

            // Земля - 30%
            // Камень - 25%
            // Уголь - 19%
            // Железо - 14%
            // Золото - 9%
            // Алмаз - 3%

            if (randomNumber <= 30)
            {
                nameBlock = "Dirt";
                healthBlock = 3;
            }
            else if (randomNumber > 30 && randomNumber <= 55)
            {
                nameBlock = "Stone";
                healthBlock = 5;
            }
            else if (randomNumber > 55 && randomNumber <= 74)
            {
                nameBlock = "CoalOre";
                healthBlock = 7;
            }
            else if (randomNumber > 74 && randomNumber <= 88)
            {
                nameBlock = "IronOre";
                healthBlock = 8;
            }
            else if (randomNumber > 88 && randomNumber <= 97)
            {
                nameBlock = "GoldOre";
                healthBlock = 9;
            }
            else
            {
                nameBlock = "DiamondOre";
                healthBlock = 10;
            }
            pbBlock.BackgroundImage = Image.FromFile("../../Images/Blocks/" + nameBlock + ".png");
        }

        public bool FindBlock(Point locationPlayer, KeyEventArgs e)
        {
            int xPlayer = locationPlayer.X;
            int yPlayer = locationPlayer.Y;

            switch (e.KeyValue)
            {
                case (char)Keys.Up: // ВВЕРХ
                    if (pbBlock.Location.X == xPlayer && pbBlock.Location.Y == yPlayer - 50)
                        return true;
                    break;

                case (char)Keys.Down: // ВНИЗ
                    if (pbBlock.Location.X == xPlayer && pbBlock.Location.Y == yPlayer + 50)
                        return true;
                    break;

                case (char)Keys.Left: // ВЛЕВО
                    if (pbBlock.Location.X == xPlayer - 50 && pbBlock.Location.Y == yPlayer)
                        return true;
                    break;

                case (char)Keys.Right: // ВПРАВО
                    if (pbBlock.Location.X == xPlayer + 50 && pbBlock.Location.Y == yPlayer)
                        return true;
                    break;
            }
            return false;
        }

        public bool CrashBlock(Player player, PlayerForm playerForm)
        {
            bool crashBlock = false;

            if (healthBlock > 0)
            {
                healthBlock -= player.powerDig; // Уменьшаем прочность блока

                Sound sound = new Sound(nameBlock, healthBlock); // Звук
                sound.PlayBlockSound(); // Проигрываем звук

                if (healthBlock <= 0)
                {
                    pbBlock.Visible = false;
                    playerForm.DropSomeItems(nameBlock);
                }
                else
                    pbBlock.Image = Image.FromFile("../../Images/DestroyStages/DestroyStage" +
                        healthBlock / player.powerDig + ".png");
            }
            else crashBlock = true;

            return crashBlock;
        }
    }
}
