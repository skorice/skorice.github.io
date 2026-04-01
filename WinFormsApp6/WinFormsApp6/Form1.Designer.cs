namespace WinFormsApp6
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox2 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            label3 = new Label();
            groupBox3 = new GroupBox();
            pictureBox1 = new PictureBox();
            radioButton12 = new RadioButton();
            radioButton9 = new RadioButton();
            radioButton8 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton6 = new RadioButton();
            button2 = new Button();
            label4 = new Label();
            button3 = new Button();
            button4 = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            radioButton10 = new RadioButton();
            radioButton11 = new RadioButton();
            radioButton13 = new RadioButton();
            radioButton14 = new RadioButton();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button5 = new Button();
            checkBox1 = new CheckBox();
            button6 = new Button();
            textBox6 = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(311, 378);
            button1.Name = "button1";
            button1.Size = new Size(195, 51);
            button1.TabIndex = 0;
            button1.Text = "Начать тест";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 510);
            label1.Name = "label1";
            label1.Size = new Size(100, 21);
            label1.TabIndex = 1;
            label1.Text = "Инструкция:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 39);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 2;
            label2.Text = "Тестирование ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(188, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(437, 150);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выберите тему:";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(27, 95);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(119, 25);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(27, 47);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(119, 25);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton5);
            groupBox2.Controls.Add(radioButton4);
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Location = new Point(189, 239);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(437, 116);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Выберите уровень для прохождения:";
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Enabled = false;
            radioButton5.Location = new Point(305, 56);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(96, 25);
            radioButton5.TabIndex = 2;
            radioButton5.Text = "Сложный";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Enabled = false;
            radioButton4.Location = new Point(172, 56);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(91, 25);
            radioButton4.TabIndex = 1;
            radioButton4.Text = "Средний";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Location = new Point(49, 56);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(79, 25);
            radioButton3.TabIndex = 0;
            radioButton3.TabStop = true;
            radioButton3.Text = "Легкий";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 531);
            label3.Name = "label3";
            label3.Size = new Size(701, 42);
            label3.TabIndex = 6;
            label3.Text = "Программа предложит 5 вопросов каждый с 4 вариантами ответов. Только один ответ верный. \r\nЧтобы открыть следующий уровень, вам нужно набрать 80 баллов из 100.\r\n";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pictureBox1);
            groupBox3.Controls.Add(radioButton12);
            groupBox3.Controls.Add(radioButton9);
            groupBox3.Controls.Add(radioButton8);
            groupBox3.Controls.Add(radioButton7);
            groupBox3.Controls.Add(radioButton6);
            groupBox3.Location = new Point(69, 612);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(672, 202);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Вопрос:";
            groupBox3.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(376, 25);
            pictureBox1.MaximumSize = new Size(290, 171);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 171);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // radioButton12
            // 
            radioButton12.AutoSize = true;
            radioButton12.Location = new Point(429, -23);
            radioButton12.Name = "radioButton12";
            radioButton12.Size = new Size(128, 25);
            radioButton12.TabIndex = 24;
            radioButton12.TabStop = true;
            radioButton12.Text = "radioButton12";
            radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            radioButton9.AutoSize = true;
            radioButton9.Location = new Point(25, 152);
            radioButton9.Name = "radioButton9";
            radioButton9.Size = new Size(119, 25);
            radioButton9.TabIndex = 3;
            radioButton9.TabStop = true;
            radioButton9.Text = "radioButton9";
            radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new Point(25, 121);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(119, 25);
            radioButton8.TabIndex = 2;
            radioButton8.TabStop = true;
            radioButton8.Text = "radioButton8";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(25, 90);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(119, 25);
            radioButton7.TabIndex = 1;
            radioButton7.TabStop = true;
            radioButton7.Text = "radioButton7";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(25, 59);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(119, 25);
            radioButton6.TabIndex = 0;
            radioButton6.TabStop = true;
            radioButton6.Text = "radioButton6";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(153, 820);
            button2.Name = "button2";
            button2.Size = new Size(234, 46);
            button2.TabIndex = 8;
            button2.Text = "Ответить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(635, 588);
            label4.Name = "label4";
            label4.Size = new Size(106, 21);
            label4.TabIndex = 4;
            label4.Text = "1/5 вопросов";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(425, 820);
            button3.Name = "button3";
            button3.Size = new Size(234, 46);
            button3.TabIndex = 9;
            button3.Text = "Далее";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ButtonHighlight;
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(668, 12);
            button4.Name = "button4";
            button4.Size = new Size(136, 58);
            button4.TabIndex = 10;
            button4.Text = "Не нажимать!";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(970, 31);
            label5.Name = "label5";
            label5.Size = new Size(112, 21);
            label5.TabIndex = 11;
            label5.Text = "Админ панель";
            label5.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(801, 87);
            label6.Name = "label6";
            label6.Size = new Size(121, 21);
            label6.TabIndex = 12;
            label6.Text = "Выберите тему:";
            label6.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(801, 121);
            label7.Name = "label7";
            label7.Size = new Size(163, 21);
            label7.TabIndex = 13;
            label7.Text = "Выберите сложность:";
            label7.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(928, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(322, 29);
            comboBox1.TabIndex = 14;
            comboBox1.Visible = false;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Легкий", "Средний", "Сложный" });
            comboBox2.Location = new Point(970, 121);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(280, 29);
            comboBox2.TabIndex = 15;
            comboBox2.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(801, 156);
            label8.Name = "label8";
            label8.Size = new Size(142, 21);
            label8.TabIndex = 16;
            label8.Text = "Напишите вопрос:";
            label8.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(800, 191);
            label9.Name = "label9";
            label9.Size = new Size(66, 21);
            label9.TabIndex = 19;
            label9.Text = "Ответы:";
            label9.Visible = false;
            // 
            // radioButton10
            // 
            radioButton10.AutoSize = true;
            radioButton10.Location = new Point(1260, 206);
            radioButton10.Name = "radioButton10";
            radioButton10.Size = new Size(14, 13);
            radioButton10.TabIndex = 22;
            radioButton10.TabStop = true;
            radioButton10.UseVisualStyleBackColor = true;
            radioButton10.Visible = false;
            // 
            // radioButton11
            // 
            radioButton11.AutoSize = true;
            radioButton11.Location = new Point(1260, 240);
            radioButton11.Name = "radioButton11";
            radioButton11.Size = new Size(14, 13);
            radioButton11.TabIndex = 23;
            radioButton11.TabStop = true;
            radioButton11.UseVisualStyleBackColor = true;
            radioButton11.Visible = false;
            // 
            // radioButton13
            // 
            radioButton13.AutoSize = true;
            radioButton13.Location = new Point(1260, 275);
            radioButton13.Name = "radioButton13";
            radioButton13.Size = new Size(14, 13);
            radioButton13.TabIndex = 25;
            radioButton13.TabStop = true;
            radioButton13.UseVisualStyleBackColor = true;
            radioButton13.Visible = false;
            // 
            // radioButton14
            // 
            radioButton14.AutoSize = true;
            radioButton14.Location = new Point(1260, 310);
            radioButton14.Name = "radioButton14";
            radioButton14.Size = new Size(14, 13);
            radioButton14.TabIndex = 27;
            radioButton14.TabStop = true;
            radioButton14.UseVisualStyleBackColor = true;
            radioButton14.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(970, 157);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 29);
            textBox1.TabIndex = 28;
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(970, 199);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(280, 29);
            textBox2.TabIndex = 29;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(970, 233);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(280, 29);
            textBox3.TabIndex = 30;
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(970, 268);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(280, 29);
            textBox4.TabIndex = 31;
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(970, 303);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(280, 29);
            textBox5.TabIndex = 32;
            textBox5.Visible = false;
            // 
            // button5
            // 
            button5.Location = new Point(917, 350);
            button5.Name = "button5";
            button5.Size = new Size(225, 44);
            button5.TabIndex = 33;
            button5.Text = "Сохранить вопрос";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(949, 231);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 34;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            // 
            // button6
            // 
            button6.Location = new Point(800, 221);
            button6.Name = "button6";
            button6.Size = new Size(143, 32);
            button6.TabIndex = 35;
            button6.Text = "Изображение";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.Click += button6_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(799, 262);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(162, 29);
            textBox6.TabIndex = 36;
            textBox6.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 982);
            Controls.Add(textBox6);
            Controls.Add(button6);
            Controls.Add(checkBox1);
            Controls.Add(button5);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(radioButton14);
            Controls.Add(radioButton13);
            Controls.Add(radioButton11);
            Controls.Add(radioButton10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(groupBox3);
            Controls.Add(label3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Тестирование";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox2;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private Label label3;
        private GroupBox groupBox3;
        private RadioButton radioButton9;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private Button button2;
        private Label label4;
        private Button button3;
        private Button button4;
        private Label label5;
        private RadioButton radioButton12;
        private Label label6;
        private Label label7;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label8;
        private Label label9;
        private RadioButton radioButton10;
        private RadioButton radioButton11;
        private RadioButton radioButton13;
        private RadioButton radioButton14;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button5;
        private CheckBox checkBox1;
        private Button button6;
        private TextBox textBox6;
        private PictureBox pictureBox1;
    }
}
