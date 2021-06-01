using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineAdventure
{
    public class Item
    {
        public PictureBox pbItem;
        public Label lbCountItem;
        public string nameItem;
        public int countItem = 0;

        public Item(PictureBox pb, Label lb)
        {
            pbItem = pb;
            lbCountItem = lb;
        }

        public void TakeItem()
        {
            countItem++;
            if (countItem > 1)
                lbCountItem.Text = countItem.ToString();
            else
                lbCountItem.Text = null;
        }

        public void NewItem(string name)
        {
            nameItem = name;
            pbItem.Image = Image.FromFile("../../Images/Items/" + name + ".png");
            countItem++;
        }
    }
}
