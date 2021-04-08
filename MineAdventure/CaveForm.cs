using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineAdventure
{
    public partial class CaveForm : Form
    {
        public CaveForm()
        {
            InitializeComponent();
        }

        private void CaveForm_KeyDown(object sender, KeyEventArgs e)
        {
            int xPlayer = pbPlayer.Location.X;
            int yPlayer = pbPlayer.Location.Y;
            switch (e.KeyValue)
            {
                case (char)Keys.Up:
                    if (yPlayer > 50)
                        yPlayer -= 50;
                    break;

                case (char)Keys.Down:
                    if (yPlayer < this.Size.Height - 100)
                        yPlayer += 50;
                    break;

                case (char)Keys.Left:
                    if (xPlayer > 50)
                        xPlayer -= 50;
                    break;
                case (char)Keys.Right:
                    if (xPlayer < this.Size.Width - 100)
                        xPlayer += 50;
                    break;
            }
            pbPlayer.Location = new Point(xPlayer, yPlayer);
        }
    }
}
