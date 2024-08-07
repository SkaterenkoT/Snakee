using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace snake
{
    public class Movement
    {
        private List<PictureBox> snake;
        private int dx = 1;
        private int dy = 0;
        private int SizeOfSides;
        private Keys ToUp = Keys.W;
        private Keys ToDown = Keys.S;
        private Keys ToLeft = Keys.A;
        private Keys ToRight = Keys.D;

        public Movement(List<PictureBox> snake, int sizeOfSides = 40)
        {
            this.snake = snake;
            SizeOfSides = sizeOfSides;
        }
        public void ChangeMoveSettings(Keys toUp, Keys toDown, Keys toLeft, Keys toRight)
        {
            ToUp = toUp;
            ToDown = toDown;
            ToLeft = toLeft;
            ToRight = toRight;
        }

        public void Direction(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == ToUp && ((snake.Count > 1 && snake[0].Location.Y != snake[1].Location.Y + SizeOfSides) || snake.Count == 1))
            {
                dx = 0;
                dy = -1;
            }
            else if (e.KeyCode == ToDown && ((snake.Count > 1 && snake[0].Location.Y != snake[1].Location.Y - SizeOfSides) || snake.Count == 1))
            {
                dx = 0;
                dy = 1;
            }
            else if (e.KeyCode == ToLeft && ((snake.Count > 1 && snake[0].Location.X != snake[1].Location.X + SizeOfSides) || snake.Count == 1))
            {
                dx = -1;
                dy = 0;
            }
            else if (e.KeyCode == ToRight && ((snake.Count > 1 && snake[0].Location.X != snake[1].Location.X - SizeOfSides) || snake.Count == 1))
            {
                dx = 1;
                dy = 0;
            }
        }

        public void MoveSnake(object sender, EventArgs e)
        {
            for (int i = snake.Count - 1; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point(snake[0].Location.X + dx * SizeOfSides, snake[0].Location.Y + dy * SizeOfSides);
        }
        public int[] ReturnDirs()
        {
            return new int[] { dx, dy };
        }
    }
}
