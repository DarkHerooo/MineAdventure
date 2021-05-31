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
        public PictureBox[] heartsPlayer = new PictureBox[10]; // Здоровье игрока
        public PictureBox[] satietyPlayer = new PictureBox[10]; // Сытость игрока

        public PictureBox[] heartsEnemy = new PictureBox[10]; // Здоровье врага
        public PictureBox[] powerEnemy = new PictureBox[10]; // Сила врага

        public void playerStats(int health, int satiety)
        {
            for (int i = 0; i < heartsPlayer.Length; i++)
            {
                if (i < health / 2)
                    heartsPlayer[i].Image = Image.FromFile("../../Images/Stats/Hearts/FullHeart.png");
                else if (i == health / 2 && health % 2 == 1)
                    heartsPlayer[i].Image = Image.FromFile("../../Images/Stats/Hearts/HalfHeart.png");
                else
                    heartsPlayer[i].Image = Image.FromFile("../../Images/Stats/Hearts/NullHeart.png");
            }
            for (int i = 0; i < satietyPlayer.Length; i++)
            {
                if (i < satiety / 2)
                    satietyPlayer[i].Image = Image.FromFile("../../Images/Stats/Knuckles/FullKnuckle.png");
                else if (i == satiety / 2 && satiety % 2 == 1)
                    satietyPlayer[i].Image = Image.FromFile("../../Images/Stats/Knuckles/HalfKnuckle.png");
                else
                    satietyPlayer[i].Image = Image.FromFile("../../Images/Stats/Knuckles/NullKnuckle.png");
            }
        }

        public void enemyStats(PictureBox enemy, int health, int power)
        {
            pbEnemy.BackgroundImage = enemy.BackgroundImage;
            pbEnemy.Image = enemy.Image;
            for (int i = 0; i < heartsEnemy.Length; i++)
            {
                if (i < health / 2)
                    heartsEnemy[i].Image = Image.FromFile("../../Images/Stats/Hearts/FullHeart.png");
                else if (i == health / 2 && health % 2 == 1)
                    heartsEnemy[i].Image = Image.FromFile("../../Images/Stats/Hearts/HalfHeart.png");
                else
                    heartsEnemy[i].Image = Image.FromFile("../../Images/Stats/Hearts/NullHeart.png");
            }
            for (int i = 0; i < powerEnemy.Length; i++)
            {
                if (i < power / 2)
                    powerEnemy[i].Image = Image.FromFile("../../Images/Stats/Swords/FullSword.png");
                else if (i == power / 2 && power % 2 == 1)
                    powerEnemy[i].Image = Image.FromFile("../../Images/Stats/Swords/HalfSword.png");
                else 
                    powerEnemy[i].Image = Image.FromFile("../../Images/Stats/Swords/NullSword.png");
            }
            if (health > 0)
            {
                pEnemy.Visible = true;
                pEnemyPower.Visible = true;
            }
            else
            {
                pEnemy.Visible = false;
                pEnemyPower.Visible = false;
            }
        }

        public PlayerForm()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                heartsPlayer[i] = this.Controls.Find("pbPlayerHeart" + i, true).First() as PictureBox;
                satietyPlayer[i] = this.Controls.Find("pbPlayerKnuckle" + i, true).First() as PictureBox;
                heartsEnemy[i] = this.Controls.Find("pbEnemyHeart" + i, true).First() as PictureBox;
                powerEnemy[i] = this.Controls.Find("pbEnemyPower" + i, true).First() as PictureBox;
            }
            
        }
    }
}
