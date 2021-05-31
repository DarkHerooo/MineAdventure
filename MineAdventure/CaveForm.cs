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
        PlayerForm playerForm;

        static int countObjects = 100;
        PictureBox[] pictureBoxes = new PictureBox[countObjects]; // Массив из объектов PictureBox

        Block[] blocks = new Block[100]; // Массив из блоков
        Mob[] mobs = new Mob[100]; // Массив из мобов

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
            bool crashBlock = true; // Сломан ли блок?
            bool killMob = true; // Убит ли моб?
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

            if (crashBlock)
            for (int i = 0; i < mobs.Length; i++)
            {
                if (mobs[i] == null) break;

                bool findMob = mobs[i].FindMob(pbPlayer.Location, e);
                if (findMob)
                {
                    killMob = mobs[i].KillMob(player);
                    playerForm.enemyStats(mobs[i].pbMob, mobs[i].healthMob, mobs[i].powerMob);
                    break;
                }
            }
            if (crashBlock && killMob) player.MovePlayer(this, e);
            playerForm.playerStats(player.healthPlayer, player.satietyPlayer);
        }

        private void CaveForm_Load(object sender, EventArgs e)
        {
            playerForm = this.Owner as PlayerForm;
            playerForm.playerStats(player.healthPlayer, player.satietyPlayer);
        }
    }
}
