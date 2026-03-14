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
        private int x;
        private int y;
        bool moving = true;
        public Form1()
        {
            InitializeComponent();
            CenterLabel();
        }
        private void CenterLabel()
        {
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label2.Top = (this.ClientSize.Height - label2.Height) / 2;
        }
    }
}
