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
        CaveForm caveForm = new CaveForm();
        PlayerForm playerForm = new PlayerForm();
        public MainForm()
        {
            InitializeComponent();

            caveForm.TopLevel = false;
            this.Controls.Add(caveForm); // Добавление формы в форму
            caveForm.Show();

            playerForm.Enabled = false;
            playerForm.TopLevel = false;
            playerForm.Location = new Point(caveForm.Size.Width, 0);
            this.Controls.Add(playerForm);
            playerForm.Show();

            this.Height = caveForm.Size.Height + 40;
            this.Width = caveForm.Size.Width + playerForm.Size.Width + 15;
        }

        public void MainForm_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
