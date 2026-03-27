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
            radioButton9 = new RadioButton();
            radioButton8 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton6 = new RadioButton();
            button2 = new Button();
            label4 = new Label();
            button3 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 982);
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
    }
}
