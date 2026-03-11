namespace WinFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(87, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(636, 104);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(151, 148);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(189, 21);
            label2.TabIndex = 1;
            label2.Text = "Введите точность 0<e<1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(524, 148);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 21);
            label3.TabIndex = 2;
            label3.Text = "Введите x";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(473, 173);
            textBox2.Margin = new Padding(4);
            textBox2.MaxLength = 12;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(178, 29);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.KeyPress += textBox1_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 173);
            textBox1.Margin = new Padding(4);
            textBox1.MaxLength = 12;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(178, 29);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox2_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(301, 236);
            button1.Name = "button1";
            button1.Size = new Size(194, 66);
            button1.TabIndex = 6;
            button1.Text = "Вычислить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point(129, 320);
            label4.Name = "label4";
            label4.Size = new Size(90, 21);
            label4.TabIndex = 7;
            label4.Text = "Результат:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(129, 358);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 8;
            label5.Text = "sin(x)/x=";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(129, 390);
            label6.Name = "label6";
            label6.Size = new Size(96, 21);
            label6.TabIndex = 9;
            label6.Text = "Сумма ряда";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(129, 420);
            label7.Name = "label7";
            label7.Size = new Size(186, 21);
            label7.TabIndex = 10;
            label7.Text = "Количество членов ряда";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 480);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Вычисление функции с помощью разложения ряда";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
