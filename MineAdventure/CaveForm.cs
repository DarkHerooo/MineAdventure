using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Земля - 30%
// Камень - 25%
// Уголь - 19%
// Железо - 14%
// Золото - 9%
// Алмаз - 3%

namespace MineAdventure
{
    public partial class CaveForm : Form
    {
        PictureBox[] block = new PictureBox[100]; // Массив из объектов PictureBox. Нужен для хранения pbBlock-ов.
        public CaveForm()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++) // Заполнение массива block pbBlock-ами.
            {
                block[i] = this.Controls.Find("pbBlock" + i, true).First() as PictureBox;
            }

            Random rnd = new Random();
            for (int i = 0; i < 100; i++) // Рандомизация Image в pbBlock-ах.
            {
                int value = rnd.Next(1, 100);
                if (value <= 30) block[i].Image = Image.FromFile("../../Images/Blocks/Dirt.png");
                else if (value > 30 && value <= 55) block[i].Image = Image.FromFile("../../Images/Blocks/Stone.png");
                else if (value > 55 && value <= 74) block[i].Image = Image.FromFile("../../Images/Blocks/Coal.png");
                else if (value > 74 && value <= 88) block[i].Image = Image.FromFile("../../Images/Blocks/Iron.png");
                else if (value > 88 && value <= 97) block[i].Image = Image.FromFile("../../Images/Blocks/Gold.png");
                else block[i].Image = Image.FromFile("../../Images/Blocks/Diamond.png");
            }
        }

        private void CaveForm_KeyDown(object sender, KeyEventArgs e)
        {
            int xPlayer = pbPlayer.Location.X; // Координата игрока по оси X.
            int yPlayer = pbPlayer.Location.Y; // Координата игрока по оси Y.
            switch (e.KeyValue) // Движение игрока
            {
                case (char)Keys.Up: // ВВЕРХ
                    if (yPlayer > 50)
                        yPlayer -= 50;
                    break;

                case (char)Keys.Down: // ВНИЗ
                    if (yPlayer < this.Size.Height - 100)
                        yPlayer += 50;
                    break;

                case (char)Keys.Left: // ВЛЕВО
                    if (xPlayer > 50)
                        xPlayer -= 50;
                    break;
                case (char)Keys.Right: // ВПРАВО
                    if (xPlayer < this.Size.Width - 100)
                        xPlayer += 50;
                    break;
            }
            pbPlayer.Location = new Point(xPlayer, yPlayer); // Новые координаты игрока.
        }
    }
}
