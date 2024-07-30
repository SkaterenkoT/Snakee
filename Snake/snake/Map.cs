using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    static class Map
    {

        static public int SizeOfSides = 40;

        static public void GenerateMap(Form formName)
        {

            for (int i = 0; i <= GameSettings.width / SizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, SizeOfSides * i);
                pic.Size = new Size(GameSettings.width - 100, 1);
                formName.Controls.Add(pic);
            }
            for (int i = 0; i <= GameSettings.height / SizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(SizeOfSides * i, 0);
                pic.Size = new Size(1, GameSettings.width);
                formName.Controls.Add(pic);
            }

        }

    }
}
