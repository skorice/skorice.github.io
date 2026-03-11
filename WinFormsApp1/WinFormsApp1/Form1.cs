namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        double Epsilon, x;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBox1.Text) > 0 && Convert.ToDouble(textBox1.Text) < 1.0)
                    Epsilon = Convert.ToDouble(textBox1.Text);
                else
                {
                    MessageBox.Show("Ââåäèòå äðóãîå çíà÷åíèå ïîãðåøíîñòè â ãðàíèöàõ 0 < E < 1");
                    return;
                }
                x = Convert.ToDouble(textBox2.Text);
            }
            catch (OverflowException)
            {
                MessageBox.Show("×èñëî ñëèøêîì áîëüøîå èëè ñëèøêîì ìàëåíüêîå. Èñïîëüçîâàíû çíà÷åíèÿ ïî óìîë÷àíèþ.");
                Epsilon = 0.01;
                x = 0.5;
                textBox1.Text = "0,01";
                textBox2.Text = "0,5";
            }
            catch (FormatException)
            {
                MessageBox.Show("Îøèáêà ââîäà! Èñïîëüçîâàíû çíà÷åíèÿ ïî óìîë÷àíèþ: Ïîãðåøíîñòü = 0.01, x = 0.5");
                Epsilon = 0.01;
                x = 0.5;
                textBox1.Text = "0,01";
                textBox2.Text = "0,5";
            }

            double sum = 1.0; // Ïåðâûé ÷ëåí ðÿäà
            double iterator = 1.0; // Òåêóùèé ÷ëåí ðÿäà
            int counter = 0; // Ñ÷åò÷èê ÷ëåíîâ 

            double prev_iter;
            do
            {
                prev_iter = iterator;

                // Âû÷èñëÿåì ñëåäóþùèé ÷ëåí ÷åðåç ïðåäûäóùèé
                // term_n = term_{n-1} * (-x^2) / ((2n)(2n+1))
                counter++;
                iterator = iterator * (-x * x) / ((2 * counter) * (2 * counter + 1));

                sum += iterator;

                
            } 
            while (Math.Abs(iterator - prev_iter) > Epsilon);


            double result = Math.Sin(x) / x;
            // Âûâîä
            if (x != 0)
                label5.Text = $"sin({x})/{x} = {result}";
            else
                label5.Text = "Äåëåíèå íà 0 íåâîçìîæíî";
            label6.Text = $"Ñóììà ðÿäà = {sum}";
            label7.Text = $"Êîëè÷åñòâî ÷ëåíîâ ðÿäà = {counter}\n";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) 
                return;
            if ((e.KeyChar == ',') || (e.KeyChar == '-')) 
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.KeyChar = '\0';  
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) &&
                        !string.IsNullOrWhiteSpace(textBox2.Text);
        }
    }

}
