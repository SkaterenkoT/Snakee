using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static snake.StartForm;
using static System.Formats.Asn1.AsnWriter;

namespace snake
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();

            int ExtraSize = 99;
            this.Width = GameSettings.width + ExtraSize;
            this.Height = GameSettings.height + ExtraSize;
            Refreshbtn.Visible = false;
            Label labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(GameSettings.width + 1, 10);
            this.Controls.Add(labelScore);

            FruitMechanics fruit = new FruitMechanics(GameSettings.width, GameSettings.height);
            fruit.AddFruit(this);

            List<PictureBox> Snake = new List<PictureBox>();
            SnakeDefinition ssnake = new SnakeDefinition(Snake);
            Snake.Add(ssnake.Head());
            this.Controls.Add(Snake[0]);

            Borders borders = new Borders(GameSettings.width, GameSettings.height);

            Movement Move = new Movement(Snake);

            SelfEating self = new SelfEating(Snake);

            Map map = new Map(GameSettings.width, GameSettings.height);
            map.GenerateMap(this);

            if (GameSettings.possibleMove == true)
            {
                timer.Tick += (sender, e) => borders.ThroughBorder(Snake);
            }
            else
            {
                timer.Tick += (sender, e) =>
                {
                    if (borders.BorderStuck(Snake[0]))
                    {
                        timer.Stop();
                        Refreshbtn.Visible = true;
                    }
                };
            }

            timer.Tick += Move.MoveSnake;

            timer.Tick += (sender, e) => fruit.EatFruit(Snake, this, Move.ReturnDirs());

            timer.Tick += (sender, e) => Score(labelScore, Snake.Count - 1);

            this.KeyDown += Move.Direction;

            timer.Interval = GameSettings.difficulty;
            timer.Start();
            timer.Tick += (sender, e) =>
            {
                if (self.SelfStuck())
                {
                    timer.Stop();
                    Refreshbtn.Visible = true;
                }
            };
        }
        public void Score(Label label, int Lenght)
        {
            label.Text = "Score: " + Lenght.ToString();
        }
        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm form1 = new StartForm();
            form1.Show();
        }
    }
}
