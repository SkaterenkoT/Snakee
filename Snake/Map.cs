using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Map
    {
        private int Width;
        private int Height;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public void GenerateMap(Form formName, int startCoordX = 0, int startCoordY = 0, int SizeOfSides = 40)
        {
            for (int i = 0; i <= Width / SizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(startCoordX, startCoordY + SizeOfSides * i);
                pic.Size = new Size(Height, 1);
                formName.Controls.Add(pic);
            }
            for (int i = 0; i <= Height / SizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(startCoordX + SizeOfSides * i, startCoordY);
                pic.Size = new Size(1, Width);
                formName.Controls.Add(pic);
            }

        }

    }
}
