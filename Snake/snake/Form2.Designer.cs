namespace snake
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer = new System.Windows.Forms.Timer(components);
            Refreshbtn = new Button();
            SuspendLayout();
            // 
            // Refreshbtn
            // 
            Refreshbtn.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Refreshbtn.Location = new Point(302, 180);
            Refreshbtn.Name = "Refreshbtn";
            Refreshbtn.Size = new Size(121, 65);
            Refreshbtn.TabIndex = 0;
            Refreshbtn.Text = "Restart";
            Refreshbtn.UseVisualStyleBackColor = true;
            Refreshbtn.Click += Refreshbtn_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Refreshbtn);
            KeyPreview = true;
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private Button Refreshbtn;
    }
}