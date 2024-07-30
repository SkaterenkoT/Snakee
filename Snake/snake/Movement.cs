using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace snake
{
    internal class Movement
    {

        public static PictureBox[] snake;

        static public int DirX;
        static public int DirY;

        static public int border1 = 0;
        static public int border2 = 0;
        static public int border3 = 0;
        static public int border4 = 0;

        static public PictureBox[] SnakeCreation()
        {

            PictureBox[] snake = new PictureBox[400];
            snake[0] = new PictureBox();
            snake[0].Location = new Point(200, 200);
            snake[0].Size = new Size(Map.SizeOfSides, Map.SizeOfSides);
            snake[0].BackColor = Color.Red;
            return snake;

        }
        static public bool SelfStuck()
        {
            for (int i = 1; i <= FruitMechanics.score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    return true;
                }
            }
            return false;
        }
        static public void ThroughTheBorderMovement()
        {
            if (snake[border1].Location.X < 0 && border1 - 1 <= FruitMechanics.score)
            {
                snake[border1].Location = new Point(GameSettings.width - 140, snake[0].Location.Y);
                if (border1 == snake.Length)
                {
                    border1 += 1;
                }
            }
            else { border1 = 0; }
            if (snake[border2].Location.X > GameSettings.width - 140 && border2 - 1 <= FruitMechanics.score)
            {
                snake[border2].Location = new Point(0, snake[0].Location.Y);
                if (border2 == snake.Length)
                {
                    border2 += 1;
                }
            }
            else { border2 = 0; }
            if (snake[border3].Location.Y < 0 && border3 - 1 <= FruitMechanics.score)
            {
                snake[border3].Location = new Point(snake[0].Location.X, GameSettings.height);
                if (border3 == snake.Length)
                {
                    border3 += 1;
                }
            }
            else { border3 = 0; }
            if (snake[border4].Location.Y > GameSettings.height && border4 - 1 <= FruitMechanics.score)
            {
                snake[border4].Location = new Point(snake[0].Location.X, 0);
                if (border4 == snake.Length)
                {
                    border4 += 1;
                }
            }
            else { border4 = 0; }
        }

        static public void TailMovement()
        {
            for (int i = FruitMechanics.score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point(snake[0].Location.X + DirX * Map.SizeOfSides, snake[0].Location.Y + DirY * Map.SizeOfSides);

        }

        static public void HeadMovement(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                case "D":
                    if (FruitMechanics.score > 0 && Movement.snake[1].Location.X == Movement.snake[0].Location.X + 40)
                    {
                    }
                    else
                    {
                        Movement.DirX = 1;
                        Movement.DirY = 0;
                    }
                    break;
                case "Left":
                case "A":
                    if (FruitMechanics.score > 0 && Movement.snake[1].Location.X == Movement.snake[0].Location.X - 40)
                    {
                    }
                    else
                    {
                        Movement.DirX = -1;
                        Movement.DirY = 0;
                    }
                    break;
                case "Up":
                case "W":
                    if (FruitMechanics.score > 0 && Movement.snake[1].Location.Y == Movement.snake[0].Location.Y - 40)
                    {
                    }
                    else
                    {
                        Movement.DirY = -1;
                        Movement.DirX = 0;
                    }
                    break;
                case "Down":
                case "S":
                    if (FruitMechanics.score > 0 && Movement.snake[1].Location.Y == Movement.snake[0].Location.Y + 40)
                    {
                    }
                    else
                    {
                        Movement.DirY = 1;
                        Movement.DirX = 0;
                    }
                    break;
            }
        }
    }
}
