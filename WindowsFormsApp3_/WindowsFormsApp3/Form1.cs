using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private int x=0;
        private int y=0;
        bool moving = true;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 50;
            CenterLabel();
            x = 2;
            y = 2;
        }
        private void CenterLabel()
        {
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label2.Top = (this.ClientSize.Height - label2.Height) / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!moving) return;

            label2.Left += x;
            label2.Top += y;
            bool border = false;

            if (label2.Left <= 0 && label2.Top <= 0) //лево верх
            {
                x = -x;
                y = -y;
                label2.BackColor = RandomColor();
            }
            else if (label2.Right >= this.ClientSize.Width && label2.Bottom >= this.ClientSize.Height) // право низ
            {
                x = -x;
                y = -y;
                label2.BackColor = RandomColor();
            }
        

            if(border)
            {
                label2.BackColor = RandomColor();
            }
        }
        private Color RandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moving = !moving;
            if(moving)
            {
                button1.Text = "Стоп";
                timer1.Start();
            }
            else
            {
                button1.Text = "Пуск";
                timer1.Stop();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Exit();
        }
        public void Speed(int speed)
        {
            timer1.Interval = speed;
        }
        public void SetColor(Color color)
        {
            label2.BackColor = color;
        }

        public int GetSpeed()
        {
            return timer1.Interval;
        }

        public Color GetColor()
        {
            return label2.BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 settingsForm = new Form2(this);
            settingsForm.ShowDialog();
        }
    }
}
