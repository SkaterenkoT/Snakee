namespace snake
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            switch (DimensionsBox.Text)
            {
                case "1000x1100":
                    GameSettings.height = 1000;
                    GameSettings.width = 1100;
                    break;
                case "800x900":
                    GameSettings.height = 800;
                    GameSettings.width = 900;
                    break;
                case "600x700":
                    GameSettings.height = 600;
                    GameSettings.width = 700;
                    break;
                case "400x500":
                    GameSettings.height = 400;
                    GameSettings.width = 500;
                    break;
                default:
                    break;
            }
            switch (DiffBox.Text)
            {
                case "Easy":
                    GameSettings.difficulty = 250;
                    break;
                case "Normal":
                    GameSettings.difficulty = 100;
                    break;
                case "Hard":
                    GameSettings.difficulty = 60;
                    break;
                default:
                    break;
            }
            this.Hide();
            GameForm form2 = new GameForm();
            form2.Show();
        }
        private void Quitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
