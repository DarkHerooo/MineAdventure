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
        Player player = new Player(20, 20); // Создаём игрока.
        PictureBox[] pictureBoxes = new PictureBox[100]; // Массив из объектов PictureBox. Нужен для хранения pbBlock-ов.

        Block[] blocks = new Block[100]; // Массив из блоков
        Mob[] mobs = new Mob[100]; // Массив из мобов

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

        public bool KeyValue(int xPlayer, int yPlayer, int xPictureBox, int yPictureBox, KeyEventArgs e) // Проверка, с какой стороны объект
        {
            bool keyValue = false;

            switch (e.KeyValue)
            {
                case (char)Keys.Up: // ВВЕРХ
                    if (xPictureBox == xPlayer && yPictureBox == yPlayer - 50)
                        keyValue = true;
                    break;

                case (char)Keys.Down: // ВНИЗ
                    if (xPictureBox == xPlayer && yPictureBox == yPlayer + 50)
                        keyValue = true;
                    break;

                case (char)Keys.Left: // ВЛЕВО
                    if (xPictureBox == xPlayer - 50 && yPictureBox == yPlayer)
                        keyValue = true;
                    break;
                case (char)Keys.Right: // ВПРАВО
                    if (xPictureBox == xPlayer + 50 && yPictureBox == yPlayer)
                        keyValue = true;
                    break;
            }

            return keyValue;
        }

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

        public Block FindBlock(int xPlayer, int yPlayer, KeyEventArgs e) // Поиск блока
        {
            Block selectedBlock = null;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == null) break;

                Block block = blocks[i]; // Вытаскиваем блок из массива

                int xBlock = block.PbBlock.Location.X; // Координата блока по оси X
                int yBlock = block.PbBlock.Location.Y; // Координата блока по оси Y

                bool keyValue = KeyValue(xPlayer, yPlayer, xBlock, yBlock, e);  // Проверяем, с какой стороны блок

                if (keyValue)
                {
                    selectedBlock = block;
                    break;
                }
            }
            return selectedBlock;
        }

        public bool CrashBlock(Block selectedBlock) // Добыча блока
        {
            bool crashBlock = false;

            if (selectedBlock != null && selectedBlock.PbBlock.Visible == true)
            {
                PlayerForm playerForm = this.Owner as PlayerForm; // Обращаемся к форме PlayerForm

                selectedBlock.HealthBlock--;

                if (selectedBlock.NameBlock == "Dirt")
                {
                    Random rnd = new Random();
                    int randomNumber = rnd.Next(1, 4);
                    SoundPlayer sound = new SoundPlayer("../../Sounds/Blocks/Dirt/Dirt" + randomNumber + ".wav");
                    sound.Play();
                } // Воспроизводим звук
                else
                {
                    Random rnd = new Random();
                    int randomNumber = rnd.Next(1, 4);
                    SoundPlayer sound = new SoundPlayer("../../Sounds/Blocks/Stone/Stone" + randomNumber + ".wav");
                    sound.Play();
                }

                playerForm.pEnemy.Visible = true; // Включаем видимость pEnemy (панель врага)
                playerForm.pbEnemy.BackgroundImage = selectedBlock.PbBlock.BackgroundImage; // Устанавливаем картинку блока

                for (int i = 0; i < playerForm.healthEnemyArray.Length; i++)
                    playerForm.healthEnemyArray[i].Image = HealthImages(selectedBlock.HealthBlock, i); // Подгружаем картинки прочности блока

                if (selectedBlock.HealthBlock == 0)
                {
                    selectedBlock.PbBlock.Visible = false;
                    playerForm.pEnemy.Visible = false;
                }
                else
                {
                    try
                    {
                        selectedBlock.PbBlock.Image = Image.FromFile("../../Images/DestroyStages/DestroyStage" + selectedBlock.HealthBlock + ".png");
                        playerForm.pbEnemy.Image = selectedBlock.PbBlock.Image;
                    }
                    catch { }
                }
            }
            else crashBlock = true;

            return crashBlock;
        }

        public Mob FindMob(int xPlayer, int yPlayer, KeyEventArgs e) // Поиск моба
        {
            Mob selectedMob = null;
            for (int i = 0; i < mobs.Length; i++)
            {
                if (mobs[i] == null) break;

                Mob mob = mobs[i]; // Вытаскиваем моба из массива

                int xMob = mob.PbMob.Location.X; // Координата моба по оси X
                int yMob = mob.PbMob.Location.Y; // Координата моба по оси Y

                bool keyValue = KeyValue(xPlayer, yPlayer, xMob, yMob, e);  // Проверяем, с какой стороны моб

                if (keyValue)
                {
                    selectedMob = mob;
                    break;
                }
            }
            return selectedMob;
        }

        public bool KillMob(Mob selectedMob) // Атака моба
        {
            bool killMob = false;

            if (selectedMob != null && selectedMob.PbMob.Visible == true)
            {
                PlayerForm playerForm = this.Owner as PlayerForm; // Обращаемся к форме PlayerForm

                player.HealthPlayer -= selectedMob.PowerMob; // Уменьшаем здоровье игрока

                for (int i = 0; i < playerForm.healthPlayerArray.Length; i++) 
                    playerForm.healthPlayerArray[i].Image = HealthImages(player.HealthPlayer, i); // Подгружаем картинки здоровья игрока

                playerForm.pEnemy.Visible = true; // Включаем видимость pEnemy (панель врага)
                playerForm.pbEnemy.BackgroundImage = selectedMob.PbMob.BackgroundImage; // Устанавливаем картинку врага

                selectedMob.HealthMob--; // Уменьшаем здоровье врага

                if (selectedMob.HealthMob > 0) 
                {
                    Random rnd = new Random();
                    int randomNumber = rnd.Next(1, 4);
                    SoundPlayer sound = new SoundPlayer("../../Sounds/Mobs/" + selectedMob.NameMob + "/Hurt" + randomNumber + ".wav");
                    sound.Play();
                } // Воспроизводим звук
                else
                {
                    SoundPlayer sound = new SoundPlayer("../../Sounds/Mobs/" + selectedMob.NameMob + "/Death.wav");
                    sound.Play();
                }

                for (int i = 0; i < playerForm.healthEnemyArray.Length; i++)
                    playerForm.healthEnemyArray[i].Image = HealthImages(selectedMob.HealthMob, i); // Подгружаем картинки здоровья врага

                playerForm.pEnemyPower.Visible = true; // Включаем видимость pEnemyPower (панель силы врага)
                for (int i = 0; i < playerForm.powerEnemyArray.Length; i++)
                    playerForm.powerEnemyArray[i].Image = SwordsImages(selectedMob.PowerMob, i); // Подгружаем картинки силы врага

                if (selectedMob.HealthMob == 0)
                {
                    selectedMob.PbMob.Visible = false;
                    playerForm.pEnemyPower.Visible = false;
                    playerForm.pEnemy.Visible = false;
                }
                else
                {
                    try
                    {
                        selectedMob.PbMob.Image = Image.FromFile("../../Images/DestroyStages/DestroyStage" + selectedMob.HealthMob + ".png");
                        playerForm.pbEnemy.Image = selectedMob.PbMob.Image;
                    }
                    catch { }
                }
            }
            else killMob = true;

            return killMob;
        }

        public CaveForm() // Вызов формы CaveForm
        {
            InitializeComponent();

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i] = this.Controls.Find("pbBlock" + i, true).First() as PictureBox; // Заполнение массива blockArray pbBlock-ами.
            }

            int countBlocks = 0; // Счётчик количества блоков
            int countMobs = 0; // Счётчик количества мобов

            Random rnd = new Random(); // Рандомное число.

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
            int xPlayer = pbPlayer.Location.X; // Координата игрока по оси X.
            int yPlayer = pbPlayer.Location.Y; // Координата игрока по оси Y.

            bool crashBlock = CrashBlock(FindBlock(xPlayer, yPlayer, e)); // Пытаемся сломать блок
            bool killMob = KillMob(FindMob(xPlayer, yPlayer, e)); // Пытаемся убить моба
            if (crashBlock && killMob) MovePlayer(xPlayer, yPlayer, e); // Движение, если блока и моба нет на пути
        }
    }
}
