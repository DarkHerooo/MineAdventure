using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineAdventure
{
    public partial class CaveForm : Form
    {
        Player player; // Игрок

        static int countObjects = 100;
        PictureBox[] pictureBoxes = new PictureBox[countObjects]; // Массив из объектов PictureBox. Нужен для хранения pbBlock-ов.

        Block[] blocks = new Block[100]; // Массив из блоков
        Mob[] mobs = new Mob[100]; // Массив из мобов

        public Image HealthImages(int health, int i)
        {
            if (i < health / 2)
            {
                return Image.FromFile("../../Images/Stats/Hearts/FullHeart.png");
            }
            if (i == health / 2 && health % 2 == 1)
            {
                return Image.FromFile("../../Images/Stats/Hearts/HalfHeart.png");
            }
            return Image.FromFile("../../Images/Stats/Hearts/NullHeart.png");
        } // Подгрузка картинок здоровья

        public Image SwordsImages(int power, int i)
        {
            if (i < power / 2)
            {
                return Image.FromFile("../../Images/Stats/Swords/FullSword.png");
            }
            if (i == power / 2 && power % 2 == 1)
            {
                return Image.FromFile("../../Images/Stats/Swords/HalfSword.png");
            }
            return Image.FromFile("../../Images/Stats/Swords/NullSword.png");
        } // Подгрузка картинок силы

        public CaveForm() // Вызов формы CaveForm
        {
            InitializeComponent();

            player = new Player(pbPlayer, 20, 20);

            for (int i = 0; i < pictureBoxes.Length; i++)
                pictureBoxes[i] = this.Controls.Find("pbBlock" + i, true).First() as PictureBox; // Заполнение массива blockArray pbBlock-ами.

            int countBlocks = 0; // Счётчик количества блоков
            int countMobs = 0; // Счётчик количества мобов

            Random rnd = new Random(); // Рандомное число

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                int randomNumber = rnd.Next(1, 101);

                if (randomNumber <= 95)
                {
                    randomNumber = rnd.Next(1, 101);
                    blocks[countBlocks] = new Block(randomNumber, pictureBoxes[i]);
                    countBlocks++;
                }
                else
                {
                    randomNumber = rnd.Next(1, 101);
                    mobs[countMobs] = new Mob(randomNumber, pictureBoxes[i]);
                    countMobs++;
                }
            }
        }

        private void CaveForm_KeyUp(object sender, KeyEventArgs e)
        {
            bool crashBlock = true;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == null) break;

                bool findBlock = blocks[i].FindBlock(pbPlayer.Location, e);
                if (findBlock)
                {
                    crashBlock = blocks[i].CrashBlock(player);
                    break;
                }
            }

            bool killMob = true;
            for (int i = 0; i < mobs.Length; i++)
            {
                if (mobs[i] == null) break;

                bool findMob = mobs[i].FindMob(pbPlayer.Location, e);
                if (findMob)
                {
                    killMob = mobs[i].KillMob(player);
                    break;
                }
            }

            if (crashBlock && killMob) player.MovePlayer(this, e);
        }
    }
}
