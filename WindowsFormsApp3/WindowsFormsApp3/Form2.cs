using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        private Form1 mainForm;
        private int speed;
        private Color color;

        public Form2(Form1 form)
        {
            InitializeComponent();
            mainForm = form;

            speed = mainForm.GetSpeed();
            color= mainForm.GetColor();
            trackBar1.Value = speed;
            button1.BackColor = color;

            UpdSpeed();
        }

        private void UpdSpeed()
        {
            label1.Text = $"Скорость: {trackBar1.Value}";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdSpeed();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = color;
            colorDialog.FullOpen = true;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
                button1.BackColor = color; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.Speed(trackBar1.Value);
            mainForm.SetColor(color);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
