﻿using System;
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

            CaveForm caveForm = new CaveForm();
            this.Height = caveForm.Size.Height + 40;
            caveForm.TopLevel = false;
            this.Controls.Add(caveForm); // Добавление формы в форму
            caveForm.Show(); //
        }
    }
}
