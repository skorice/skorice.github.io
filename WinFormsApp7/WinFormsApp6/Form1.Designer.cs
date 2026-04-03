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
            panel1 = new Panel();
            buttonDrawArrow = new Button();
            buttonRedo = new Button();
            buttonUndo = new Button();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem1 = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            отменитьToolStripMenuItem = new ToolStripMenuItem();
            повторитьToolStripMenuItem = new ToolStripMenuItem();
            colorDialog1 = new ColorDialog();
            buttonStrokeColor = new Button();
            numericUpDown1 = new NumericUpDown();
            btnCopy = new Button();
            btnPaste = new Button();
            btnCut = new Button();
            dtnColor = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(29, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(858, 453);
            panel1.TabIndex = 0;
            panel1.Click += panel1_Click;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // buttonDrawArrow
            // 
            buttonDrawArrow.Location = new Point(29, 69);
            buttonDrawArrow.Name = "buttonDrawArrow";
            buttonDrawArrow.Size = new Size(94, 31);
            buttonDrawArrow.TabIndex = 1;
            buttonDrawArrow.Text = "Рисовать";
            buttonDrawArrow.UseVisualStyleBackColor = true;
            buttonDrawArrow.Click += buttonDrawArrow_Click;
            // 
            // buttonRedo
            // 
            buttonRedo.Location = new Point(129, 69);
            buttonRedo.Name = "buttonRedo";
            buttonRedo.Size = new Size(94, 31);
            buttonRedo.TabIndex = 2;
            buttonRedo.Text = "Повтор";
            buttonRedo.UseVisualStyleBackColor = true;
            buttonRedo.Click += buttonRedo_Click;
            // 
            // buttonUndo
            // 
            buttonUndo.Location = new Point(229, 69);
            buttonUndo.Name = "buttonUndo";
            buttonUndo.Size = new Size(95, 31);
            buttonUndo.TabIndex = 4;
            buttonUndo.Text = "Отмена";
            buttonUndo.UseVisualStyleBackColor = true;
            buttonUndo.Click += buttonUndo_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(924, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem1, открытьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem1
            // 
            сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
            сохранитьToolStripMenuItem1.Size = new Size(133, 22);
            сохранитьToolStripMenuItem1.Text = "Сохранить";
            сохранитьToolStripMenuItem1.Click += сохранитьToolStripMenuItem1_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(133, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { отменитьToolStripMenuItem, повторитьToolStripMenuItem });
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(59, 20);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // отменитьToolStripMenuItem
            // 
            отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            отменитьToolStripMenuItem.Size = new Size(133, 22);
            отменитьToolStripMenuItem.Text = "Отменить";
            отменитьToolStripMenuItem.Click += отменитьToolStripMenuItem_Click;
            // 
            // повторитьToolStripMenuItem
            // 
            повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            повторитьToolStripMenuItem.Size = new Size(133, 22);
            повторитьToolStripMenuItem.Text = "Повторить";
            повторитьToolStripMenuItem.Click += повторитьToolStripMenuItem_Click;
            // 
            // buttonStrokeColor
            // 
            buttonStrokeColor.Location = new Point(330, 69);
            buttonStrokeColor.Name = "buttonStrokeColor";
            buttonStrokeColor.Size = new Size(95, 31);
            buttonStrokeColor.TabIndex = 6;
            buttonStrokeColor.Text = "Граница";
            buttonStrokeColor.UseVisualStyleBackColor = true;
            buttonStrokeColor.Click += buttonStrokeColor_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(431, 69);
            numericUpDown1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(81, 29);
            numericUpDown1.TabIndex = 7;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(518, 69);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(69, 31);
            btnCopy.TabIndex = 8;
            btnCopy.Text = "Копия";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnPaste
            // 
            btnPaste.Location = new Point(593, 69);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new Size(69, 31);
            btnPaste.TabIndex = 9;
            btnPaste.Text = "Вставка";
            btnPaste.UseVisualStyleBackColor = true;
            btnPaste.Click += btnPaste_Click;
            // 
            // btnCut
            // 
            btnCut.Location = new Point(668, 69);
            btnCut.Name = "btnCut";
            btnCut.Size = new Size(69, 31);
            btnCut.TabIndex = 10;
            btnCut.Text = "Вырез";
            btnCut.UseVisualStyleBackColor = true;
            btnCut.Click += btnCut_Click;
            // 
            // dtnColor
            // 
            dtnColor.Location = new Point(743, 69);
            dtnColor.Name = "dtnColor";
            dtnColor.Size = new Size(69, 31);
            dtnColor.TabIndex = 11;
            dtnColor.Text = "Цвет";
            dtnColor.UseVisualStyleBackColor = true;
            dtnColor.Click += dtnColor_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 582);
            Controls.Add(dtnColor);
            Controls.Add(btnCut);
            Controls.Add(btnPaste);
            Controls.Add(btnCopy);
            Controls.Add(numericUpDown1);
            Controls.Add(buttonStrokeColor);
            Controls.Add(buttonUndo);
            Controls.Add(buttonRedo);
            Controls.Add(buttonDrawArrow);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Тестирование";
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button buttonDrawArrow;
        private Button buttonRedo;
        private Button buttonUndo;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem1;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private ToolStripMenuItem отменитьToolStripMenuItem;
        private ToolStripMenuItem повторитьToolStripMenuItem;
        private ColorDialog colorDialog1;
        private Button buttonStrokeColor;
        private NumericUpDown numericUpDown1;
        private Button btnCopy;
        private Button btnPaste;
        private Button btnCut;
        private Button dtnColor;
    }
}
