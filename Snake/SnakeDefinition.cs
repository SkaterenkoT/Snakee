using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class SnakeDefinition // only snake
    {

        private List<PictureBox> Snake;
        public SnakeDefinition(List<PictureBox> snake)
        {
            Snake = snake;
        }
        public PictureBox Head(int startCoordX = 200, int startCoordY = 200, int SizeOfSides = 40)
        {

            PictureBox snake = new PictureBox();
            snake = new PictureBox();
            snake.Location = new Point(startCoordX, startCoordY);
            snake.Size = new Size(SizeOfSides, SizeOfSides);
            snake.BackColor = Color.Red;
            return snake;

        }

    }
}
