using System;

namespace WindowsFormsApp2
{
    public class Parser
    {
        private string text;
        private int pos;
        /// <summary>
        /// Метод для начала вычисления выражения
        /// </summary>
        /// <param name="expr">/Строка с выражением, которое ввел пользователь</param>
        /// <returns>Возвращает результат вычисления выражения</returns>
        public double Start(string expr)
        {
            text = expr;
            pos = 0;
            double result = ParsePlusMinus();  
            return result;
        }

        /// <summary>
        /// Метод для сложения и вычитания
        /// </summary>
        /// <returns>Возвращает результат вычисления с операциями + и -</returns>
        private double ParsePlusMinus()
        {
            double result = ParseMnojDel();  // сначала умножаем/делим

            while (pos < text.Length)
            {
                char op = text[pos];
                if (op == '+' || op == '-')
                {
                    pos++;
                    double term = ParseMnojDel();
                    result = op == '+' ? result + term : result - term; //+ или -
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Метод для умножения и делениия
        /// </summary>
        /// <returns>Возвращает результат вычисления с операциями * и /</returns>
        /// <exception cref="DivideByZeroException">Деление на 0</exception>
        private double ParseMnojDel()
        {
            double result = ParseSkobki();  // сначала скобки и числа

            while (pos < text.Length)
            {
                char op = text[pos];
                if (op == '*' || op == '/')
                {
                    pos++;
                    double factor = ParseSkobki();

                    if (op == '*')
                        result *= factor;
                    else
                    {
                        if (Math.Abs(factor) < double.Epsilon)
                            throw new DivideByZeroException("Деление на ноль");
                        result /= factor;
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Метод для обработки скобок, знаков и чисел
        /// </summary>
        /// <returns>Возвращает значение выражение в скобках или число</returns>
        /// <exception cref="Exception">Отстутствует закрывающая скобка или неожиданный символ</exception>
        private double ParseSkobki()
        {
            if (pos >= text.Length)
                throw new Exception("Неожиданный конец выражения");

            char ch = text[pos];

            // Плюс или минус (например, -5 или +3)
            if (ch == '+' || ch == '-')
            {
                pos++;
                double value = ParseSkobki();
                return ch == '+' ? value : -value;
            }

            // Скобки
            if (ch == '(')
            {
                pos++;
                double result = ParsePlusMinus();  // внутри скобок снова + и -

                if (pos >= text.Length || text[pos] != ')')
                    throw new Exception("Отсутствует закрывающая скобка");

                pos++;
                return result;
            }

            // Число
            if (char.IsDigit(ch) || ch == '.')
            {
                return ParseChislo();
            }

            throw new Exception($"Неожиданный символ '{ch}' в позиции {pos + 1}");
        }

        /// <summary>
        /// Метод для чтения чисел из строки
        /// </summary>
        /// <returns>Возвращает число</returns>
        /// <exception cref="Exception">Число отсутствует</exception>
        private double ParseChislo()
        {
            int startPos = pos;
            bool point = false;

            while (pos < text.Length)
            {
                char ch = text[pos];

                if (char.IsDigit(ch))
                {
                    pos++;
                }
                else if (ch == '.' && !point)
                {
                    point = true;
                    pos++;
                }
                else
                {
                    break;
                }
            }

            if (startPos == pos)
                throw new Exception($"Ожидалось число в позиции {pos + 1}");

            string numberStr = text.Substring(startPos, pos - startPos);

            double.TryParse(numberStr, out double result); //преобразование
            return result;
        }
    }
}