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
    public partial class PlayerForm : Form
    {
        public PictureBox[] healthPlayerArray = new PictureBox[10]; // Здоровье игрока
        PictureBox[] satietyPlayerArray = new PictureBox[10]; // Сытость игрока

        
        PictureBox[] healthEnemyArray = new PictureBox[10]; // Здоровье врага
        PictureBox[] powerEnemyArray = new PictureBox[10]; // Сила врага

        public PlayerForm()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                healthPlayerArray[i] = this.Controls.Find("pbPlayerHeart" + i, true).First() as PictureBox;
                satietyPlayerArray[i] = this.Controls.Find("pbPlayerKnuckle" + i, true).First() as PictureBox;
                healthEnemyArray[i] = this.Controls.Find("pbEnemyHeart" + i, true).First() as PictureBox;
                powerEnemyArray[i] = this.Controls.Find("pbEnemyPower" + i, true).First() as PictureBox;
            }

            for (int i = 0; i < 10; i++)
            {
                healthPlayerArray[i].Image = Image.FromFile("../../Images/Stats/Hearts/FullHeart.png");
                satietyPlayerArray[i].Image = Image.FromFile("../../Images/Stats/Knuckles/FullKnuckle.png");
                healthEnemyArray[i].Image = Image.FromFile("../../Images/Stats/Hearts/FullHeart.png");
                powerEnemyArray[i].Image = Image.FromFile("../../Images/Stats/Hearts/FullHeart.png");
            }
        }
    }
}
