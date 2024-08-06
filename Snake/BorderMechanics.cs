using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Borders
    {
        private int Height;
        private int Width;
        public Borders(int width, int height)
        {
            Height = height;
            Width = width;
        }
        private int[] CheckBorders(int LocX, int LocY, int startCoordX = 0, int startCoordY = 0)
        {
            if (LocX < startCoordX)
            {
                return new int[] { startCoordX + Width - 40, startCoordY + LocY };
            }
            else if (LocX > startCoordX + Width - 40)
            {
                return new int[] { startCoordX, startCoordY + LocY };
            }
            else if (LocY < startCoordY)
            {
                return new int[] { startCoordX + LocX, startCoordY + Height - 40 };
            }
            else if (LocY > startCoordY + Height - 40)
            {
                return new int[] { startCoordX + LocX, startCoordY };
            }
            else
            {
                return new int[] { };
            }
        }
        public void ThroughBorder(List<PictureBox> model, int startCoordX = 0, int startCoordY = 0)
        {
            foreach (PictureBox segment in model)
            {
                int[] newCoords = CheckBorders(Convert.ToInt32(segment.Location.X), Convert.ToInt32(segment.Location.Y), startCoordX, startCoordY);
                if (!newCoords.SequenceEqual(Array.Empty<int>()))
                {
                    segment.Location = new Point(newCoords[0], newCoords[1]);
                }
            }
        }
    }
}
