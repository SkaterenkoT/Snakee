using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Movement);
        }

        private void Movement(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    cube.Location = new Point(cube.Location.X + 20, cube.Location.Y); 
                    break;
                case "Left":
                    cube.Location = new Point(cube.Location.X - 20, cube.Location.Y);
                    break;
                case "Up":
                    cube.Location = new Point(cube.Location.X, cube.Location.Y - 20);
                    break;
                case "Down":
                    cube.Location = new Point(cube.Location.X, cube.Location.Y + 20);
                    break;
            }
        }
    }
}
