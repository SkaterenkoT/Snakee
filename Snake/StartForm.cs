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
                case "960x960":
                    GameSettings.height = 960;
                    GameSettings.width = 960;
                    break;
                case "800x800":
                    GameSettings.height = 800;
                    GameSettings.width = 800;
                    break;
                case "520x520":
                    GameSettings.height = 520;
                    GameSettings.width = 520;
                    break;
                case "440x440":
                    GameSettings.height = 440;
                    GameSettings.width = 440;
                    break;
                default:
                    break;
            }
            switch (DiffBox.Text)
            {
                case "Slow":
                    GameSettings.speed = 200;
                    break;
                case "Normal":
                    GameSettings.speed = 100;
                    break;
                case "Fast":
                    GameSettings.speed = 60;
                    break;
                default:
                    break;
            }
            switch (BorderBox.Text)
            {
                case "Move through":
                    GameSettings.possibleMove = true;
                    break;
                case "Unable to move through":
                    GameSettings.possibleMove = false;
                    break;
            }
            switch (SizeBox.Text)
            {
                case "40 px":
                    GameSettings.sizeOfSides = 40;
                    break;
                case "20 px":
                    GameSettings.sizeOfSides = 20;
                    break;
                case "10 px":
                    GameSettings.sizeOfSides = 10; 
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
