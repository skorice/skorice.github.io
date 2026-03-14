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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if ((e.KeyChar == '+') || (e.KeyChar == '-') || (e.KeyChar == '*') || (e.KeyChar == '/'))
                return;
            if ((e.KeyChar == '(') || (e.KeyChar == ')'))
                return;
            if (e.KeyChar == '.')
                return;
            if (e.KeyChar == ',')
            {
                e.KeyChar = '.'; // автоматически заменяем точку на запятую
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.KeyChar = '\0';

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Parser parser = new Parser();
                string text = textBox1.Text.Trim();

                double result = parser.Start(text);

                label2.Text = $"Результат = {result}";
            }
            catch (DivideByZeroException)
            {
                label2.Text = "Ошибка: Деление на ноль!";
            }
            catch (Exception ex)
            {
                label2.Text = "Ошибка: " + ex.Message;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }
    }
}
