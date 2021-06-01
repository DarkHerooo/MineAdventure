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

        //public Item weaponPlayer; // Оружие игрока
        //public Item instrumentPlayer; // Инструмент игрока
        //public Item foodPlayer; // Еда игрока
        public Item[] items = new Item[27]; // Инвентарь

        public void PlayerStats(int health, int satiety)
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
        } // Характеристики игрока

        public void EnemyStats(PictureBox enemy, int health, int power)
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
        } // Характеристики врага
        
        private void DropItem(string name)
        {
            bool findItem = false;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].nameItem == name)
                {
                    findItem = true;
                    items[i].TakeItem();
                    break;
                }
            }

            if (!findItem)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].nameItem == null)
                    {
                        items[i].NewItem(name);
                        break;
                    }
                }
            }
        } // Выпадение предмета и попадание в инвентарь

        public void DropSomeItems(string name) // Проверка имени на несколько предметов
        {
            switch (name)
            {
                case "Dirt": DropItem(name); break;
                case "Stone": DropItem("Cobblestone"); break;
                case "CoalOre": DropItem("Coal"); break;
                case "IronOre": DropItem(name); break;
                case "GoldOre": DropItem(name); break;
                case "DiamondOre": DropItem("Diamond"); break;
                case "Zombie":
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(1, 100);
                        if (randomNumber <= 50) DropItem("RottenFlesh");
                    }; break;
                case "Skeleton":
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(1, 100);
                        if (randomNumber <= 50) DropItem("Bone");

                        randomNumber = rnd.Next(1, 100);
                        if (randomNumber <= 25) DropItem("Arrow");

                    }; break;
                case "Spider":
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(1, 100);
                        if (randomNumber <= 50) DropItem("Thread");

                        randomNumber = rnd.Next(1, 100);
                        if (randomNumber <= 25) DropItem("SpiderEye");
                    } break;
                case "Creeper":
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(1, 100);
                        if (randomNumber <= 25) DropItem("Gunowder");
                    } break;
                case "Enderman":
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(1, 100);
                        if (randomNumber <= 25) DropItem("EnderPearl");
                    } break;
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
            for (int i = 0; i < items.Length; i++)
            {
                PictureBox pb = this.Controls.Find("pbItem" + i, true).First() as PictureBox;
                Label lb = new Label();
                lb.Location = new Point(pb.Location.X + pb.Size.Width - 10, pb.Location.Y + pb.Size.Height - 10);
                lb.BackColor = Color.White;
                lb.AutoSize = true;
                this.Controls.Add(lb);
                lb.BringToFront();
                items[i] = new Item(pb, lb);
            }
        }
    }
}
