using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static snake.Form1;

namespace snake
{
    public partial class Form2 : Form
    {
        private PictureBox Fruit;
        private PictureBox[] snake = new PictureBox[400];
        private Label LabelScore;
        private int RandI, RandJ;
        private int SizeOfSides = 40;
        private int DirX, DirY;
        private int score = 0;
        public Form2()
        {
            InitializeComponent();
            this.Text = "Snake";
            this.Width = FieldDimensions.width;
            this.Height = FieldDimensions.height + 100;
            DirX = 1;
            DirY = 0;
            LabelScore = new Label();
            LabelScore.Text = "Score: 0";
            LabelScore.Location = new Point(FieldDimensions.width - 99, 10);
            this.Controls.Add(LabelScore);
            snake[0] = new PictureBox();
            snake[0].Location = new Point(200, 200);
            snake[0].Size = new Size(SizeOfSides, SizeOfSides);
            snake[0].BackColor = Color.Red;
            this.Controls.Add(snake[0]);
            Fruit = new PictureBox();
            Fruit.BackColor = Color.Yellow;
            Fruit.Size = new Size(SizeOfSides, SizeOfSides);
            Refreshbtn.Visible = false;
            GenerateMap();
            GenerateFruit();
            timer.Tick += new EventHandler(Update);
            timer.Interval = 100;
            timer.Start();
            this.KeyDown += new KeyEventHandler(Movement);
        }
        private void GenerateMap()
        {
            for (int i = 0; i <= FieldDimensions.width / SizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, SizeOfSides * i);
                pic.Size = new Size(FieldDimensions.width - 100, 1);
                this.Controls.Add(pic);
            }
            for (int i = 0; i <= FieldDimensions.height / SizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(SizeOfSides * i, 0);
                pic.Size = new Size(1, FieldDimensions.width);
                this.Controls.Add(pic);
            }
        }
        private void GenerateFruit()
        {
            Random random = new Random();
            RandI = random.Next(0, FieldDimensions.height - SizeOfSides);
            int tempI = RandI % SizeOfSides;
            RandI -= tempI;
            RandJ = random.Next(0, FieldDimensions.height - SizeOfSides);
            int tempJ = RandJ % SizeOfSides;
            RandJ -= tempJ;
            Fruit.Location = new Point(RandI, RandJ);
            this.Controls.Add(Fruit);
        }
        private void EatFruit()
        {
            if (snake[0].Location.X == RandI && snake[0].Location.Y == RandJ)
            {
                LabelScore.Text = "Score: " + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + 40 * DirX, snake[score - 1].Location.Y - 40 * DirY);
                snake[score].Size = new Size(SizeOfSides - 1, SizeOfSides - 1);
                snake[score].BackColor = Color.Green;
                this.Controls.Add(snake[score]);
                GenerateFruit();
            }
        }
        private void SelfEating()
        {
            for (int i = 1; i < score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    timer.Stop();
                    Refreshbtn.BringToFront();
                    Refreshbtn.Visible = true;
                    Refreshbtn.Enabled = true;
                }
            }
        }
        private void CheckBorders()
        {
            if (snake[0].Location.X < 0)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(FieldDimensions.width - 100, snake[0].Location.Y);
                }
            }
            if (snake[0].Location.X > FieldDimensions.width - 100)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(0, snake[0].Location.Y);
                }
            }
            if (snake[0].Location.Y < 0)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(snake[0].Location.X, FieldDimensions.height);
                }
            }
            if (snake[0].Location.Y > FieldDimensions.height)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(snake[0].Location.X, 0);
                }
            }
        }
        private void Update(object sender, EventArgs e)
        {
            CheckBorders();
            EatFruit();
            TailMovement();
        }

        private void Movement(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                case "D":
                    DirX = 1;
                    DirY = 0;
                    break;
                case "Left":
                case "A":
                    DirX = -1;
                    DirY = 0;
                    break;
                case "Up":
                case "W":
                    DirY = -1;
                    DirX = 0;
                    break;
                case "Down":
                case "S":
                    DirY = 1;
                    DirX = 0;
                    break;
            }
        }
        private void TailMovement()
        {
            for (int i = score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point(snake[0].Location.X + DirX * SizeOfSides, snake[0].Location.Y + DirY * SizeOfSides);
            SelfEating();
        }

        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
