using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class BorderMechanics
    {

        static public int border1 = 0;
        static public int border2 = 0;
        static public int border3 = 0;
        static public int border4 = 0;

        static public void BorderCleaner()
        {

            border1 = 0;
            border2 = 0;
            border3 = 0;
            border4 = 0;
        
        }

        static public void CheckBorders()
        {
            if (SnakeDefinition.snake[border1].Location.X < 0 && border1 - 1 <= FruitMechanics.score)
            {
                SnakeDefinition.snake[border1].Location = new Point(GameSettings.width - 140, SnakeDefinition.snake[0].Location.Y);
                if (border1 == SnakeDefinition.snake.Length)
                {
                    border1 += 1;
                }
            }
            else { border1 = 0; }
            if (SnakeDefinition.snake[border2].Location.X > GameSettings.width - 140 && border2 - 1 <= FruitMechanics.score)
            {
                SnakeDefinition.snake[border2].Location = new Point(0, SnakeDefinition.snake[0].Location.Y);
                if (border2 == SnakeDefinition.snake.Length)
                {
                    border2 += 1;
                }
            }
            else { border2 = 0; }
            if (SnakeDefinition.snake[border3].Location.Y < 0 && border3 - 1 <= FruitMechanics.score)
            {
                SnakeDefinition.snake[border3].Location = new Point(SnakeDefinition.snake[0].Location.X, GameSettings.height);
                if (border3 == SnakeDefinition.snake.Length)
                {
                    border3 += 1;
                }
            }
            else { border3 = 0; }
            if (SnakeDefinition.snake[border4].Location.Y > GameSettings.height && border4 - 1 <= FruitMechanics.score)
            {
                SnakeDefinition.snake[border4].Location = new Point(SnakeDefinition.snake[0].Location.X, 0);
                if (border4 == SnakeDefinition.snake.Length)
                {
                    border4 += 1;
                }
            }
            else { border4 = 0; }
        }

    }
}
