using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class GameSettings
    {

        static public int height { get; set; } = 800;

        static public int width { get; set; } = 800;

        static public int difficulty { get; set; } = 100;

        static public bool possibleMove { get; set; } = true;

    }
}
