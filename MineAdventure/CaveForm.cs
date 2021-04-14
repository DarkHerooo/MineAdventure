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

        PictureBox[] blockArray = new PictureBox[100]; // Массив из объектов PictureBox. Нужен для хранения pbBlock-ов.
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

        public bool CrashBlock(PictureBox selectedBlock) // Добыча блока
        {
            bool crashBlock = false;

            if (selectedBlock != null && selectedBlock.Visible == true)
            {
                int healthBlock = int.Parse(selectedBlock.Tag.ToString()); // Прочность блока

                healthBlock--; // Уменьшаем прочность блока
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
                    SoundPlayer sound = new SoundPlayer(mob.StrSoundMob);
                    sound.Play();

                    player.HealthPlayer -= mob.PowerMob; // Уменьшаем здоровье игрока
                    PlayerForm playerForm = this.Owner as PlayerForm;

                    if (player.HealthPlayer >= 0)
                    {
                        for (int i = player.HealthPlayer / 2; i < playerForm.healthPlayerArray.Length; i++)
                        {
                            if (i == player.HealthPlayer / 2 && player.HealthPlayer % 2 == 1)
                            {
                                playerForm.healthPlayerArray[i].Image = Image.FromFile("../../Images/Stats/Hearts/HalfHeart.png");
                                continue;
                            }
                            playerForm.healthPlayerArray[i].Image = Image.FromFile("../../Images/Stats/Hearts/NullHeart.png");
                        }
                    }
                }

                try
                {
                    selectedBlock.Image = Image.FromFile("../../Images/DestroyStages/DestroyStage" + healthBlock + ".png");
                }
                catch { }

                if (healthBlock <= 0)
                {
                    selectedBlock.Visible = false;
                    pbPlayer.BringToFront();
                }
            }
            else crashBlock = true;

            return crashBlock;
        }

        public CaveForm() // Вызов формы CaveForm
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++) // Заполнение массивов
            {
                blockArray[i] = this.Controls.Find("pbBlock" + i, true).First() as PictureBox; // Заполнение массива blockArray pbBlock-ами.
            }

            Random rnd = new Random();
            for (int i = 0; i < 100; i++) // Рандомизация Image в pbBlock-ах.
            {
                int randomNumber = rnd.Next(1, 100);

                if (randomNumber <= 95)
                {
                    randomNumber = rnd.Next(1, 100);
                    Block block = new Block(randomNumber);
                    blockArray[i].BackgroundImage = Image.FromFile("../../Images/Blocks/"+ block.NameBlock +".png");
                    blockArray[i].AccessibleName = block.NameBlock;
                    blockArray[i].AccessibleDescription = block.TypeBlock;
                    blockArray[i].Tag = block.HealthBlock;
                }
                else
                {
                    randomNumber = rnd.Next(1, 100);
                    Mob mob = new Mob(randomNumber);
                    blockArray[i].BackgroundImage = Image.FromFile("../../Images/Mobs/" + mob.NameMob + ".png");
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
