namespace snake
{
    partial class StartForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Startbtn = new Button();
            label1 = new Label();
            label2 = new Label();
            Quitbtn = new Button();
            pictureBox1 = new PictureBox();
            DimensionsBox = new ComboBox();
            DiffBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Startbtn
            // 
            Startbtn.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Startbtn.Location = new Point(76, 226);
            Startbtn.Name = "Startbtn";
            Startbtn.Size = new Size(156, 61);
            Startbtn.TabIndex = 0;
            Startbtn.Text = "Start game";
            Startbtn.UseVisualStyleBackColor = true;
            Startbtn.Click += Startbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(238, 239);
            label1.Name = "label1";
            label1.Size = new Size(146, 20);
            label1.TabIndex = 1;
            label1.Text = "Set field dimensions:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 293);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 4;
            label2.Text = "Set difficulty:";
            // 
            // Quitbtn
            // 
            Quitbtn.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Quitbtn.Location = new Point(76, 293);
            Quitbtn.Name = "Quitbtn";
            Quitbtn.Size = new Size(156, 66);
            Quitbtn.TabIndex = 6;
            Quitbtn.Text = "Quit";
            Quitbtn.UseVisualStyleBackColor = true;
            Quitbtn.Click += Quitbtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Snake_free_icons_designed_by_Freepik;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(513, 498);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // DimensionsBox
            // 
            DimensionsBox.FormattingEnabled = true;
            DimensionsBox.Items.AddRange(new object[] { "960x960", "800x800", "520x520", "440x440" });
            DimensionsBox.Location = new Point(261, 262);
            DimensionsBox.Name = "DimensionsBox";
            DimensionsBox.Size = new Size(151, 28);
            DimensionsBox.TabIndex = 8;
            // 
            // DiffBox
            // 
            DiffBox.FormattingEnabled = true;
            DiffBox.Items.AddRange(new object[] { "Easy", "Normal", "Hard" });
            DiffBox.Location = new Point(261, 316);
            DiffBox.Name = "DiffBox";
            DiffBox.Size = new Size(151, 28);
            DiffBox.TabIndex = 9;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 498);
            Controls.Add(DiffBox);
            Controls.Add(DimensionsBox);
            Controls.Add(Quitbtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Startbtn);
            Controls.Add(pictureBox1);
            Name = "StartForm";
            Text = "SnakeGame";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Startbtn;
        private Label label1;
        private Label label2;
        private Button Quitbtn;
        private PictureBox pictureBox1;
        private ComboBox DimensionsBox;
        private ComboBox DiffBox;
    }
}
