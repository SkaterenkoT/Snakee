using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class SelfEating
    {
        private List<PictureBox> Snake;
        public SelfEating(List<PictureBox> snake)
        {
            Snake = snake;
        }

        public bool SelfStuck()
        {
            if (Snake.Count > 4)
            {
                for (int i = 1; i <= Snake.Count - 1; i++)
                {
                    if (Snake[0].Location == Snake[i].Location)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}
