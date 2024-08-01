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
        static public int DirX;
        static public int DirY;

        static public void TailMovement()
        {
            for (int i = FruitMechanics.score; i >= 1; i--)
            {
                SnakeDefinition.snake[i].Location = SnakeDefinition.snake[i - 1].Location;
            }
            SnakeDefinition.snake[0].Location = new Point(SnakeDefinition.snake[0].Location.X + DirX * Map.SizeOfSides, SnakeDefinition.snake[0].Location.Y + DirY * Map.SizeOfSides);

        }

        static public void HeadMovement(object sender, KeyEventArgs e) 

        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                case "D":
                    if (FruitMechanics.score > 0 && SnakeDefinition.snake[1].Location.X == SnakeDefinition.snake[0].Location.X + 40)
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
                    if (FruitMechanics.score > 0 && SnakeDefinition.snake[1].Location.X == SnakeDefinition.snake[0].Location.X - 40)
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
                    if (FruitMechanics.score > 0 && SnakeDefinition.snake[1].Location.Y == SnakeDefinition.snake[0].Location.Y - 40)
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
                    if (FruitMechanics.score > 0 && SnakeDefinition.snake[1].Location.Y == SnakeDefinition.snake[0].Location.Y + 40)
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
