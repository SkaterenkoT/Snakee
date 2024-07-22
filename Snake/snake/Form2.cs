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
        private int SizeOfSides = 40;
        private int DirX, DirY;
        public Form2()
        {
            InitializeComponent();
            this.Width = FieldDimensions.width;
            this.Height = FieldDimensions.height;
            DirX = 1;
            DirY = 0;
            GenerateMap();
            timer.Tick += new EventHandler(Update);
            timer.Interval = 500;
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
        private void Update(object sender, EventArgs e)
        {
            cube.Location = new Point(cube.Location.X + DirX * SizeOfSides, cube.Location.Y + DirY * SizeOfSides);
        }

        private void Movement(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    DirX = 1;
                    DirY = 0;
                    break;
                case "Left":
                    DirX = -1;
                    DirY = 0;
                    break;
                case "Up":
                    DirY = -1;
                    DirX = 0;
                    break;
                case "Down":
                    DirY = 1;
                    DirX = 0;
                    break;
            }
        }
    }
}
