﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Земля - 30%
// Камень - 25%
// Уголь - 19%
// Железо - 14%
// Золото - 9%
// Алмаз - 3%

namespace MineAdventure
{
    public partial class CaveForm : Form
    {
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
            pbPlayer.Location = new Point(xPlayer, yPlayer); // Новые координаты игрока.
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
                int healthBlock = int.Parse(selectedBlock.Tag.ToString());

                healthBlock--;
                selectedBlock.Tag = healthBlock;
                if (healthBlock <= 0)
                {
                    crashBlock = true;
                    selectedBlock.Visible = false;
                }
            }
            else crashBlock = true;

            return crashBlock;
        }

        public CaveForm()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++) // Заполнение массива block pbBlock-ами.
            {
                blockArray[i] = this.Controls.Find("pbBlock" + i, true).First() as PictureBox;
                blockArray[i].Tag = 3;
            }

            Random rnd = new Random();
            for (int i = 0; i < 100; i++) // Рандомизация Image в pbBlock-ах.
            {
                int randomNumber = rnd.Next(1, 100);
                Block block = new Block(randomNumber);
                blockArray[i].Image = Image.FromFile(block.StrImageBlock);
                blockArray[i].AccessibleDescription = block.NameBlock;
                blockArray[i].Tag = block.HealthBlock;
            }
        }

        private void CaveForm_KeyDown(object sender, KeyEventArgs e)
        {
            int xPlayer = pbPlayer.Location.X; // Координата игрока по оси X.
            int yPlayer = pbPlayer.Location.Y; // Координата игрока по оси Y.

            bool crashBlock = CrashBlock(FindBlock(xPlayer, yPlayer, e)); // Пытаемся сломать блок
            if (crashBlock == true) MovePlayer(xPlayer, yPlayer, e); // Движение, если блока нет на пути
        }
    }
}
