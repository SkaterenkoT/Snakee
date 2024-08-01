using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class SelfEating
    {

        static public bool SelfStuck()
        {
            for (int i = 1; i <= FruitMechanics.score; i++)
            {
                if (SnakeDefinition.snake[0].Location == SnakeDefinition.snake[i].Location)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
