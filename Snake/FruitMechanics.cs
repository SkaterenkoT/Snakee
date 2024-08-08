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

        private PictureBox Fruit = new PictureBox();
        private int Height;
        private int Width;
        private int RandI;
        private int RandJ;
        public FruitMechanics(int height, int width)
        {
            Height = height;
            Width = width;
        }

        private void FruitLocation(int startCoordX = 0, int startCoordY = 0, int SizeOfSides = 40)
        {
            Random random = new Random();
            RandI = random.Next(startCoordX, startCoordX + Height - SizeOfSides);
            int tempI = RandI % SizeOfSides;
            RandI -= tempI;
            RandJ = random.Next(startCoordY, startCoordY + Width - SizeOfSides);
            int tempJ = RandJ % SizeOfSides;
            RandJ -= tempJ;
        }
        public void AddFruit(Form formName, int startCoordX = 0, int startCoordY = 0, int SizeOfSides = 40)
        {
            Fruit.BackColor = Color.LightYellow;
            Fruit.Size = new Size(SizeOfSides, SizeOfSides);
            FruitLocation(startCoordX, startCoordY, SizeOfSides);
            Fruit.Location = new Point(RandI, RandJ);
            formName.Controls.Add(Fruit);
        }
        public void EatFruit(List<PictureBox> snake, Form formName, int startCoordX = 0, int startCoordY = 0, int SizeOfSides = 40)
        {
            if (snake[0].Location.X == RandI && snake[0].Location.Y == RandJ)
            {
                PictureBox segment = new PictureBox();
                segment.Location = new Point(snake[snake.Count - 1].Location.X, snake[snake.Count - 1].Location.Y);
                segment.Size = new Size(SizeOfSides - 1, SizeOfSides - 1);
                segment.BackColor = Color.Green;
                snake.Add(segment);
                formName.Controls.Add(segment);
                AddFruit(formName, startCoordX, startCoordY, SizeOfSides);
            }

        }

    }
}
