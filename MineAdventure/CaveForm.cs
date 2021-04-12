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
        PictureBox[] blockArray = new PictureBox[100]; // Массив из объектов PictureBox. Нужен для хранения pbBlock-ов.
        PictureBox[] crashArray = new PictureBox[100]; // Массив из объектов PictureBox. Нужен для хранения crash-ей блоков.

        public void MovePlayer(int xPlayer, int yPlayer, KeyEventArgs e) // Движение игрока
        {
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
            pbPlayer.Location = new Point(xPlayer, yPlayer);
        }

        public PictureBox FindBlock(int xPlayer, int yPlayer, KeyEventArgs e) // Поиск блока
        {
            PictureBox selectedBlock = null;

            for (int i = 0; i < blockArray.Length; i++)
            {
                int xBlock = blockArray[i].Location.X;
                int yBlock = blockArray[i].Location.Y;

                switch (e.KeyValue)
                {
                    case (char)Keys.Up: // ВВЕРХ
                        if (xBlock == xPlayer && yBlock == yPlayer - 50)
                            selectedBlock = blockArray[i];
                        break;

                    case (char)Keys.Down: // ВНИЗ
                        if (xBlock == xPlayer && yBlock == yPlayer + 50)
                            selectedBlock = blockArray[i];
                        break;

                    case (char)Keys.Left: // ВЛЕВО
                        if (xBlock == xPlayer - 50 && yBlock == yPlayer)
                            selectedBlock = blockArray[i];
                        break;
                    case (char)Keys.Right: // ВПРАВО
                        if (xBlock == xPlayer + 50 && yBlock == yPlayer)
                            selectedBlock = blockArray[i];
                        break;
                }
            }
            return selectedBlock;
        }

        public PictureBox FindCrash(PictureBox selectedBlock) // Поиск трещины
        {
            PictureBox selectedCrash = null;
            for (int i = 0; i < crashArray.Length; i++)
            {
                if (selectedBlock.Location == crashArray[i].Location)
                {
                    selectedCrash = crashArray[i];
                    selectedCrash.BackgroundImage = selectedBlock.Image;
                    selectedCrash.Visible = true;
                    selectedCrash.BringToFront();
                    break;
                }
            }
            return selectedCrash;
        }

        public bool CrashBlock(PictureBox selectedBlock) // Добыча блока
        {
            bool crashBlock = false;

            if (selectedBlock != null && selectedBlock.Visible == true)
            {

                int healthBlock = int.Parse(selectedBlock.Tag.ToString()); // Уменьшаем прочность блока
                healthBlock--;
                selectedBlock.Tag = healthBlock;

                if (selectedBlock.AccessibleDescription == "Block") // Проверяем, блок или моб
                {
                    Block block = new Block(selectedBlock.AccessibleName);
                    SoundPlayer sound = new SoundPlayer(block.StrSoundBlock);
                    sound.Play();
                }
                else // иначе моб
                {
                    Mob mob = new Mob(selectedBlock.AccessibleName, healthBlock);
                    int healthPlayer = int.Parse(pbPlayer.Tag.ToString()); // Уменьшаем здоровье игрока
                    healthPlayer -= mob.PowerMob;
                    pbPlayer.Tag = healthPlayer;
                    SoundPlayer sound = new SoundPlayer(mob.StrSoundMob);
                    sound.Play();
                }

                PictureBox selectedCrash = FindCrash(selectedBlock);

                try
                {
                    selectedCrash.Image = Image.FromFile("../../Images/DestroyStages/DestroyStage" + healthBlock + ".png");
                }
                catch { }



                if (healthBlock <= 0)
                {
                    selectedBlock.Visible = false;
                    selectedCrash.Visible = false;
                    pbPlayer.BringToFront();
                }
            }
            else crashBlock = true;

            return crashBlock;
        }

        public PictureBox CreateCrashes(PictureBox blockArray) // Создание трещин поверх всех блоков.
        {
            PictureBox crash = new PictureBox();
            crash.Location = new Point(blockArray.Location.X, blockArray.Location.Y);
            crash.Visible = false;
            crash.Height = 50;
            crash.Width = 50;
            this.Controls.Add(crash);
            return crash;
        }

        public CaveForm() // Вызов формы CaveForm
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++) // Заполнение массивов
            {
                blockArray[i] = this.Controls.Find("pbBlock" + i, true).First() as PictureBox; // Заполнение массива blockArray pbBlock-ами.
                crashArray[i] = CreateCrashes(blockArray[i]); // Заполнение массива crashArray созданными PictureBox в методе CreateCrashes.
            }

            Random rnd = new Random();
            for (int i = 0; i < 100; i++) // Рандомизация Image в pbBlock-ах.
            {
                int randomNumber = rnd.Next(1, 100);

                if (randomNumber <= 95)
                {
                    randomNumber = rnd.Next(1, 100);
                    Block block = new Block(randomNumber);
                    blockArray[i].Image = Image.FromFile("../../Images/Blocks/"+ block.NameBlock +".png");
                    blockArray[i].AccessibleName = block.NameBlock;
                    blockArray[i].AccessibleDescription = block.TypeBlock;
                    blockArray[i].Tag = block.HealthBlock;
                }
                else
                {
                    randomNumber = rnd.Next(1, 100);
                    Mob mob = new Mob(randomNumber);
                    blockArray[i].Image = Image.FromFile("../../Images/Mobs/" + mob.NameMob + ".png");
                    blockArray[i].AccessibleName = mob.NameMob;
                    blockArray[i].AccessibleDescription = mob.TypeMob;
                    blockArray[i].Tag = mob.HealthMob;
                }
            }
        } 

        private void CaveForm_KeyUp(object sender, KeyEventArgs e)
        {
            int xPlayer = pbPlayer.Location.X; // Координата игрока по оси X.
            int yPlayer = pbPlayer.Location.Y; // Координата игрока по оси Y.

            bool crashBlock = CrashBlock(FindBlock(xPlayer, yPlayer, e)); // Пытаемся сломать блок
            if (crashBlock) MovePlayer(xPlayer, yPlayer, e); // Движение, если блока нет на пути
        }
    }
}
