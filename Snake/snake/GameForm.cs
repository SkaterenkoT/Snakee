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

        private Label LabelScore;

        public GameForm()
        {
            InitializeComponent();

            this.Width = GameSettings.width;
            this.Height = GameSettings.height + 100;

            BorderMechanics.BorderCleaner();

            FruitMechanics.Fruit = FruitMechanics.FruitCreation();

            Movement.DirX = 1;
            Movement.DirY = 0;

            LabelScore = new Label();
            LabelScore.Text = "Score: " + Convert.ToString(FruitMechanics.score);
            LabelScore.Location = new Point(GameSettings.width - 99, 10);

            FruitMechanics.score = 0;
            SnakeDefinition.snake = SnakeDefinition.SnakeCreation();
            this.Controls.Add(LabelScore);
            this.Controls.Add(SnakeDefinition.snake[0]);

            Refreshbtn.Visible = false;

            Map.GenerateMap(this);
            FruitMechanics.GenerateFruit(this, FruitMechanics.Fruit);

            timer.Tick += new EventHandler(FormUpdate);
            timer.Interval = GameSettings.difficulty;
            timer.Start();

            this.KeyDown += new KeyEventHandler(Movement.HeadMovement);
        }

        private void FormUpdate(object sender, EventArgs e)
        {
            BorderMechanics.CheckBorders();
            FruitMechanics.EatFruit(this, SnakeDefinition.snake, FruitMechanics.score, Movement.DirX, Movement.DirY);
            Movement.TailMovement();
            if (SelfEating.SelfStuck())
            {
                timer.Stop();
                Refreshbtn.BringToFront();
                Refreshbtn.Visible = true;
                Refreshbtn.Enabled = true;
            }
            LabelScore.Text = "Score: " + FruitMechanics.score;
        }

        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm form1 = new StartForm();
            form1.Show();
        }
    }
}
