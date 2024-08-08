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
        private int[] CheckBorders(int LocX, int LocY, int startCoordX = 0, int startCoordY = 0, int SizeOfSides = 40)
        {
            if (LocX < startCoordX)
            {
                return new int[] { startCoordX + Width - SizeOfSides, startCoordY + LocY };
            }
            else if (LocX > startCoordX + Width - SizeOfSides)
            {
                return new int[] { startCoordX, startCoordY + LocY };
            }
            else if (LocY < startCoordY)
            {
                return new int[] { startCoordX + LocX, startCoordY + Height - SizeOfSides };
            }
            else if (LocY > startCoordY + Height - SizeOfSides)
            {
                return new int[] { startCoordX + LocX, startCoordY };
            }
            else
            {
                return new int[] { };
            }
        }
        public void ThroughBorder(List<PictureBox> model, int startCoordX = 0, int startCoordY = 0, int SizeOfSides = 40)
        {
            foreach (PictureBox segment in model)
            {
                int[] newCoords = CheckBorders(Convert.ToInt32(segment.Location.X), Convert.ToInt32(segment.Location.Y), startCoordX, startCoordY, SizeOfSides);
                if (!newCoords.SequenceEqual(Array.Empty<int>()))
                {
                    segment.Location = new Point(newCoords[0], newCoords[1]);
                }
            }
        }
        public bool BorderStuck(PictureBox head, int startCoordX = 0, int startCoordY = 0, int SizeOfSides = 40)
        {
            int[] newCoords = CheckBorders(Convert.ToInt32(head.Location.X), Convert.ToInt32(head.Location.Y), startCoordX, startCoordY, SizeOfSides);
            if (!newCoords.SequenceEqual(Array.Empty<int>()))
            {
                return true;
            }
            return false;
        }
    }
}
