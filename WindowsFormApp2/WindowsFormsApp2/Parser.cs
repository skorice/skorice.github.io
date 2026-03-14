using System;

namespace WindowsFormsApp2
{
    public class Parser
    {
        private string text;
        private int pos;

        /// <summary>
        /// Вычисляет арифметическое выражение
        /// </summary>
        public double Start(string expr)
        {
            if (string.IsNullOrEmpty(expr)) throw new Exception("Пустое выражение");

            text = expr;
            pos = 0;
            double result = ParsePlusMinus();

            if (pos < text.Length)
                throw new Exception($"Лишний символ '{text[pos]}' в конце");

            return result;
        }

        // Сложение и вычитание
        private double ParsePlusMinus()
        {
            double result = ParseMnojDel();

            while (pos < text.Length)
            {
                char op = text[pos];
                if (op != '+' && op != '-') break;

                pos++;
                if (pos < text.Length && IsOperator(text[pos]))
                    throw new Exception($"Два оператора подряд");

                double term = ParseMnojDel();
                result = op == '+' ? result + term : result - term;
            }
            return result;
        }

        // Умножение и деление
        private double ParseMnojDel()
        {
            double result = ParseSkobki();

            while (pos < text.Length)
            {
                char op = text[pos];
                if (op != '*' && op != '/') break;

                pos++;
                if (pos < text.Length && IsOperator(text[pos]))
                    throw new Exception($"Два оператора подряд");

                double factor = ParseSkobki();

                if (op == '*')
                    result *= factor;
                else
                {
                    if (factor == 0) throw new DivideByZeroException("Деление на ноль");
                    result /= factor;
                }
            }
            return result;
        }

        // Скобки, унарные знаки, числа
        private double ParseSkobki()
        {
            if (pos >= text.Length) throw new Exception("Неожиданный конец");

            char ch = text[pos];

            // Унарный плюс/минус
            if (ch == '+' || ch == '-')
            {
                if (pos > 0 && text[pos - 1] == ')')
                    throw new Exception($"Некорректный унарный оператор");

                pos++;
                double val = ParseSkobki();
                return ch == '+' ? val : -val;
            }

            // Скобки
            if (ch == '(')
            {
                pos++;
                double res = ParsePlusMinus();

                if (pos >= text.Length || text[pos] != ')')
                    throw new Exception("Нет закрывающей скобки");

                pos++;
                return res;
            }

            // Лишняя закрывающая скобка
            if (ch == ')') throw new Exception("Лишняя закрывающая скобка");

            // Число
            return ParseChislo();
        }

        // Чтение числа
        private double ParseChislo()
        {
            int start = pos;
            bool dot = false;

            while (pos < text.Length)
            {
                char ch = text[pos];
                if (char.IsDigit(ch))
                    pos++;
                else if ((ch == '.' || ch == ',') && !dot)
                {
                    dot = true;
                    pos++;
                }
                else break;
            }

            if (start == pos) throw new Exception("Ожидалось число");

            string num = text.Substring(start, pos - start).Replace(',', '.');
            double.TryParse(num, System.Globalization.NumberStyles.Any,
                           System.Globalization.CultureInfo.InvariantCulture, out double res);
            return res;
        }

        // Проверка на оператор
        private bool IsOperator(char c) => c == '+' || c == '-' || c == '*' || c == '/';
    }
}