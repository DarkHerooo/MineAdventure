using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineAdventure
{
    public class Player
    {
        private int _healthPlayer;
        private int _satietyPlayer;

        public PictureBox pbPlayer;
        public int healthPlayer
        {
            get { return _healthPlayer; }
            set 
            {
                if (value >= 0) _healthPlayer = value;
                else _healthPlayer = 0;
            }
        }
        public int satietyPlayer
        {
            get { return _satietyPlayer; }
            set
            {
                if (value >= 0) _satietyPlayer = value;
                else _satietyPlayer = 0;
            } 
        }
        public int powerDig = 1;
        public int powerHit = 1;

        public Player(PictureBox pb, int health, int satiety)
        {
            pbPlayer = pb;
            healthPlayer = health;
            satietyPlayer = satiety;
        }
        public void MovePlayer(Form form, KeyEventArgs e)
        {
            int xPlayer = pbPlayer.Location.X;
            int yPlayer = pbPlayer.Location.Y;
            switch (e.KeyValue) // Движение игрока
            {
                case (char)Keys.Up: // ВВЕРХ
                    if (yPlayer > 50)
                        yPlayer -= 50;
                    break;
                case (char)Keys.Down: // ВНИЗ
                    if (yPlayer < form.Size.Height - 100)
                        yPlayer += 50;
                    break;
                case (char)Keys.Left: // ВЛЕВО
                    if (xPlayer > 50)
                        xPlayer -= 50;
                    break;
                case (char)Keys.Right: // ВПРАВО
                    if (xPlayer < form.Width - 100)
                        xPlayer += 50;
                    break;
            }
            pbPlayer.Location = new Point(xPlayer, yPlayer);
        }
    }
}
