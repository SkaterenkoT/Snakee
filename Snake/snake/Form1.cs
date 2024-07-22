namespace snake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            switch (DimensionsBox.Text)
            {
                case "1000x1100":
                    FieldDimensions.height = 1000;
                    FieldDimensions.width = 1100;
                    break;
                case "800x900":
                    FieldDimensions.height = 800;
                    FieldDimensions.width = 900;
                    break;
                case "600x700":
                    FieldDimensions.height = 600;
                    FieldDimensions.width = 700;
                    break;
                case "400x500":
                    FieldDimensions.height = 400;
                    FieldDimensions.width = 500;
                    break;
            }
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
        static public class FieldDimensions
        {
            static public int height = 800;
            static public int width = 900;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
