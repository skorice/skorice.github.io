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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label6 = new Label();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            играToolStripMenuItem = new ToolStripMenuItem();
            новаяИграToolStripMenuItem = new ToolStripMenuItem();
            сложностьToolStripMenuItem = new ToolStripMenuItem();
            лёгкаяToolStripMenuItem = new ToolStripMenuItem();
            средняяToolStripMenuItem = new ToolStripMenuItem();
            сложнаяToolStripMenuItem = new ToolStripMenuItem();
            игрокToolStripMenuItem = new ToolStripMenuItem();
            авторизацияToolStripMenuItem = new ToolStripMenuItem();
            сменитьИгрокаToolStripMenuItem = new ToolStripMenuItem();
            статистикаToolStripMenuItem = new ToolStripMenuItem();
            показатьМоиРезультатыToolStripMenuItem = new ToolStripMenuItem();
            показатьОбщиеРезультатыToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            времяСеансаToolStripMenuItem = new ToolStripMenuItem();
            ptToolStripMenuItem = new ToolStripMenuItem();
            секToolStripMenuItem = new ToolStripMenuItem();
            секToolStripMenuItem1 = new ToolStripMenuItem();
            секToolStripMenuItem2 = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(348, 521);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(264, 29);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(348, 569);
            button1.Name = "button1";
            button1.Size = new Size(264, 48);
            button1.TabIndex = 1;
            button1.Text = "Проверить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(429, 620);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 2;
            label1.Text = "Игра началась";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(349, 493);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 3;
            label2.Text = "Введите букву:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(250, 92);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(485, 103);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 309);
            label3.Name = "label3";
            label3.Size = new Size(213, 21);
            label3.TabIndex = 6;
            label3.Text = "Уже использованные буквы:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(321, 49);
            label4.Name = "label4";
            label4.Size = new Size(166, 21);
            label4.TabIndex = 7;
            label4.Text = "Строитель и философ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 330);
            label5.Name = "label5";
            label5.Size = new Size(166, 21);
            label5.TabIndex = 8;
            label5.Text = "Оставшиеся попытки:";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 655);
            label6.Name = "label6";
            label6.Size = new Size(170, 21);
            label6.TabIndex = 10;
            label6.Text = "Словарь: стандартный";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { играToolStripMenuItem, игрокToolStripMenuItem, статистикаToolStripMenuItem, настройкиToolStripMenuItem, оПрограммеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            играToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новаяИграToolStripMenuItem, сложностьToolStripMenuItem });
            играToolStripMenuItem.Name = "играToolStripMenuItem";
            играToolStripMenuItem.Size = new Size(46, 20);
            играToolStripMenuItem.Text = "Игра";
            // 
            // новаяИграToolStripMenuItem
            // 
            новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            новаяИграToolStripMenuItem.Size = new Size(180, 22);
            новаяИграToolStripMenuItem.Text = "Новая игра";
            // 
            // сложностьToolStripMenuItem
            // 
            сложностьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { лёгкаяToolStripMenuItem, средняяToolStripMenuItem, сложнаяToolStripMenuItem });
            сложностьToolStripMenuItem.Name = "сложностьToolStripMenuItem";
            сложностьToolStripMenuItem.Size = new Size(180, 22);
            сложностьToolStripMenuItem.Text = "Сложность";
            // 
            // лёгкаяToolStripMenuItem
            // 
            лёгкаяToolStripMenuItem.Name = "лёгкаяToolStripMenuItem";
            лёгкаяToolStripMenuItem.Size = new Size(124, 22);
            лёгкаяToolStripMenuItem.Text = "Лёгкая";
            лёгкаяToolStripMenuItem.Click += лёгкаяToolStripMenuItem_Click;
            // 
            // средняяToolStripMenuItem
            // 
            средняяToolStripMenuItem.Name = "средняяToolStripMenuItem";
            средняяToolStripMenuItem.Size = new Size(124, 22);
            средняяToolStripMenuItem.Text = "Средняя";
            средняяToolStripMenuItem.Click += средняяToolStripMenuItem_Click_1;
            // 
            // сложнаяToolStripMenuItem
            // 
            сложнаяToolStripMenuItem.Name = "сложнаяToolStripMenuItem";
            сложнаяToolStripMenuItem.Size = new Size(124, 22);
            сложнаяToolStripMenuItem.Text = "Сложная";
            сложнаяToolStripMenuItem.Click += сложнаяToolStripMenuItem_Click_1;
            // 
            // игрокToolStripMenuItem
            // 
            игрокToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { авторизацияToolStripMenuItem, сменитьИгрокаToolStripMenuItem });
            игрокToolStripMenuItem.Name = "игрокToolStripMenuItem";
            игрокToolStripMenuItem.Size = new Size(53, 20);
            игрокToolStripMenuItem.Text = "Игрок";
            игрокToolStripMenuItem.Click += игрокToolStripMenuItem_Click;
            // 
            // авторизацияToolStripMenuItem
            // 
            авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            авторизацияToolStripMenuItem.Size = new Size(180, 22);
            авторизацияToolStripMenuItem.Text = "Авторизация";
            авторизацияToolStripMenuItem.Click += авторизацияToolStripMenuItem_Click_1;
            // 
            // сменитьИгрокаToolStripMenuItem
            // 
            сменитьИгрокаToolStripMenuItem.Name = "сменитьИгрокаToolStripMenuItem";
            сменитьИгрокаToolStripMenuItem.Size = new Size(180, 22);
            сменитьИгрокаToolStripMenuItem.Text = "Сменить игрока";
            сменитьИгрокаToolStripMenuItem.Click += сменитьИгрокаToolStripMenuItem_Click_1;
            // 
            // статистикаToolStripMenuItem
            // 
            статистикаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { показатьМоиРезультатыToolStripMenuItem, показатьОбщиеРезультатыToolStripMenuItem });
            статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            статистикаToolStripMenuItem.Size = new Size(80, 20);
            статистикаToolStripMenuItem.Text = "Статистика";
            // 
            // показатьМоиРезультатыToolStripMenuItem
            // 
            показатьМоиРезультатыToolStripMenuItem.Name = "показатьМоиРезультатыToolStripMenuItem";
            показатьМоиРезультатыToolStripMenuItem.Size = new Size(230, 22);
            показатьМоиРезультатыToolStripMenuItem.Text = "Показать мои результаты";
            показатьМоиРезультатыToolStripMenuItem.Click += показатьМоиРезультатыToolStripMenuItem_Click;
            // 
            // показатьОбщиеРезультатыToolStripMenuItem
            // 
            показатьОбщиеРезультатыToolStripMenuItem.Name = "показатьОбщиеРезультатыToolStripMenuItem";
            показатьОбщиеРезультатыToolStripMenuItem.Size = new Size(230, 22);
            показатьОбщиеРезультатыToolStripMenuItem.Text = "Показать общие результаты";
            показатьОбщиеРезультатыToolStripMenuItem.Click += показатьОбщиеРезультатыToolStripMenuItem_Click;
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { времяСеансаToolStripMenuItem, ptToolStripMenuItem, секToolStripMenuItem, секToolStripMenuItem1, секToolStripMenuItem2 });
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(130, 20);
            настройкиToolStripMenuItem.Text = "Настройки времени";
            // 
            // времяСеансаToolStripMenuItem
            // 
            времяСеансаToolStripMenuItem.Name = "времяСеансаToolStripMenuItem";
            времяСеансаToolStripMenuItem.Size = new Size(167, 22);
            времяСеансаToolStripMenuItem.Text = "Без ограничения";
            времяСеансаToolStripMenuItem.Click += времяСеансаToolStripMenuItem_Click;
            // 
            // ptToolStripMenuItem
            // 
            ptToolStripMenuItem.Name = "ptToolStripMenuItem";
            ptToolStripMenuItem.Size = new Size(167, 22);
            ptToolStripMenuItem.Text = "30 сек";
            ptToolStripMenuItem.Click += ptToolStripMenuItem_Click;
            // 
            // секToolStripMenuItem
            // 
            секToolStripMenuItem.Name = "секToolStripMenuItem";
            секToolStripMenuItem.Size = new Size(167, 22);
            секToolStripMenuItem.Text = "60 сек";
            секToolStripMenuItem.Click += секToolStripMenuItem_Click;
            // 
            // секToolStripMenuItem1
            // 
            секToolStripMenuItem1.Name = "секToolStripMenuItem1";
            секToolStripMenuItem1.Size = new Size(167, 22);
            секToolStripMenuItem1.Text = "120 сек";
            секToolStripMenuItem1.Click += секToolStripMenuItem1_Click;
            // 
            // секToolStripMenuItem2
            // 
            секToolStripMenuItem2.Name = "секToolStripMenuItem2";
            секToolStripMenuItem2.Size = new Size(167, 22);
            секToolStripMenuItem2.Text = "180 сек";
            секToolStripMenuItem2.Click += секToolStripMenuItem2_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(94, 20);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click_1;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(900, 25);
            toolStrip1.TabIndex = 12;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "Новая игра";
            toolStripButton1.Click += toolStripButton1_Click_1;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "Подсказка";
            toolStripButton2.Click += toolStripButton2_Click_1;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 676);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(900, 22);
            statusStrip1.TabIndex = 13;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(118, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(504, 221);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(351, 238);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 59);
            label7.Name = "label7";
            label7.Size = new Size(52, 21);
            label7.TabIndex = 15;
            label7.Text = "label7";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 698);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(label6);
            Controls.Add(menuStrip1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Игра: Философ и строитель";
            Load += Form1_Load;
            Resize += Form1_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label4;
        private Label label5;
        private System.Windows.Forms.Timer timer1;
        private Label label6;
        private OpenFileDialog openFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem играToolStripMenuItem;
        private ToolStripMenuItem новаяИграToolStripMenuItem;
        private ToolStripMenuItem сложностьToolStripMenuItem;
        private ToolStripMenuItem лёгкаяToolStripMenuItem;
        private ToolStripMenuItem средняяToolStripMenuItem;
        private ToolStripMenuItem сложнаяToolStripMenuItem;
        private ToolStripMenuItem игрокToolStripMenuItem;
        private ToolStripMenuItem авторизацияToolStripMenuItem;
        private ToolStripMenuItem сменитьИгрокаToolStripMenuItem;
        private ToolStripMenuItem статистикаToolStripMenuItem;
        private ToolStripMenuItem показатьМоиРезультатыToolStripMenuItem;
        private ToolStripMenuItem показатьОбщиеРезультатыToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem времяСеансаToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem ptToolStripMenuItem;
        private ToolStripMenuItem секToolStripMenuItem;
        private ToolStripMenuItem секToolStripMenuItem1;
        private ToolStripMenuItem секToolStripMenuItem2;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label label7;
    }
}
