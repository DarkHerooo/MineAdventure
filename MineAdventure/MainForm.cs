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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            PlayerForm playerForm = new PlayerForm();
            playerForm.Enabled = false;
            playerForm.TopLevel = false;

            CaveForm caveForm = new CaveForm();
            caveForm.Owner = playerForm; // Устанавливаем родителя, чтобы обращаться к форме playerForm.
            caveForm.TopLevel = false;
            this.Controls.Add(caveForm); // Добавление формы в форму
            caveForm.Show();

            playerForm.Location = new Point(caveForm.Size.Width, 0);
            this.Controls.Add(playerForm);
            playerForm.Show();

            this.Height = caveForm.Size.Height + 40;
            this.Width = caveForm.Size.Width + playerForm.Size.Width + 15;
        }

        /*int healthPlayer = int.Parse(caveForm.pbPlayer.Tag.ToString());
            for (int i = 0; i<playerForm.healthPlayerArray.Length; i++)
            {
                if (i >= healthPlayer)
                {
                    playerForm.healthPlayerArray[i].Image = Image.FromFile("../../Images/Stats/Hearts/NullHeart.png");
                }*/
    }
}
