using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class SnakeDefinition
    {

        public static PictureBox[] snake; //

        static public PictureBox[] SnakeCreation()
        {

            PictureBox[] snake = new PictureBox[400];
            snake[0] = new PictureBox();
            snake[0].Location = new Point(200, 200);
            snake[0].Size = new Size(Map.SizeOfSides, Map.SizeOfSides);
            snake[0].BackColor = Color.Red;
            return snake;

        }

    }
}
