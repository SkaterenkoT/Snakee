using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace snake
{
    internal class FruitMechanics
    {

        static private int RandI, RandJ; //

        static public PictureBox Fruit = new PictureBox(); //

        public static int score; //

        static public PictureBox FruitCreation()
        {

            PictureBox Fruit = new PictureBox();
            Fruit.BackColor = Color.Yellow;
            Fruit.Size = new Size(Map.SizeOfSides, Map.SizeOfSides);

            return Fruit;

        }

        static public void GenerateFruit(Form formName, PictureBox Fruit)
        {
            Random random = new Random();
            RandI = random.Next(0, GameSettings.height - Map.SizeOfSides);
            int tempI = RandI % Map.SizeOfSides;
            RandI -= tempI;
            RandJ = random.Next(0, GameSettings.height - Map.SizeOfSides);
            int tempJ = RandJ % Map.SizeOfSides;
            RandJ -= tempJ;
            Fruit.Location = new Point(RandI, RandJ);
            formName.Controls.Add(Fruit);
        }

        static public void EatFruit(Form formName)
        {
            if (SnakeDefinition.snake[0].Location.X == RandI && SnakeDefinition.snake[0].Location.Y == RandJ)
            {
                FruitMechanics.score += 1;
                SnakeDefinition.snake[FruitMechanics.score] = new PictureBox();
                SnakeDefinition.snake[FruitMechanics.score].Location = new Point(SnakeDefinition.snake[FruitMechanics.score - 1].Location.X + 40 * Movement.DirX, SnakeDefinition.snake[FruitMechanics.score - 1].Location.Y - 40 * Movement.DirY);
                SnakeDefinition.snake[FruitMechanics.score].Size = new Size(Map.SizeOfSides - 1, Map.SizeOfSides - 1);
                SnakeDefinition.snake[FruitMechanics.score].BackColor = Color.Green;
                formName.Controls.Add(SnakeDefinition.snake[FruitMechanics.score]);
                GenerateFruit(formName, FruitMechanics.Fruit);
            }
        }

    }
}
