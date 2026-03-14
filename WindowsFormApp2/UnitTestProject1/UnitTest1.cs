using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp2;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ParserTests
    {
        private Parser parser;
        private double result;

        [TestInitialize]
        public void Setup()
        {
            parser = new Parser();
        }

        // Арифметические операции

        [TestMethod]
        public void Plus() // сложение
        {
            result = parser.Start("2+3");
            Assert.AreEqual(5, result, 0.0001);
        }

        [TestMethod]
        public void Minus() // вычитание
        {
            result = parser.Start("7-4");
            Assert.AreEqual(3, result, 0.0001);
        }

        [TestMethod]
        public void Mnoj() // умножение
        {
            result = parser.Start("6*3");
            Assert.AreEqual(18, result, 0.0001);
        }

        [TestMethod]
        public void Del() // деление
        {
            result = parser.Start("15/3");
            Assert.AreEqual(5, result, 0.0001);
        }

        // Приоритеты операций

        [TestMethod]
        public void MnojPLus() // Умножение перед сложением
        {
            result = parser.Start("2+3*4");
            Assert.AreEqual(14, result, 0.0001); // 2 + 12 = 14, а не 20
        }

        [TestMethod]
        public void DelMin() // Деление перед вычитанием
        {
            result = parser.Start("10-6/2");
            Assert.AreEqual(7, result, 0.0001); // 10 - 3 = 7, а не 2
        }

        // Скобки

        [TestMethod]
        public void Skobki1() // Простые скобки
        {
            result = parser.Start("(2+3)*4");
            Assert.AreEqual(20, result, 0.0001);
        }

        [TestMethod]
        public void Skobki2() // Вложенные скобки
        {
            result = parser.Start("2*(3+4*(5-2))");
            Assert.AreEqual(30, result, 0.0001); // 2*(3+4*3) = 2*(3+12) = 2*15 = 30
        }

        [TestMethod]
        public void Skobki3() // Много скобок
        {
            result = parser.Start("((2+3)*(4-1))/(2+1)");
            Assert.AreEqual(5, result, 0.0001); // (5*3)/3 = 15/3 = 5
        }

        //Унарные операторы

        [TestMethod]
        public void UnarMin() // Унарный минус со скобками
        {
            result = parser.Start("-(5+3)*2");
            Assert.AreEqual(-16, result, 0.0001);
        }

        [TestMethod]
        public void TestDecimalNumbers() // Вещественные числа
        {
            result = parser.Start("2.5*4.2");
            Assert.AreEqual(10.5, result, 0.0001);
        }

        [TestMethod]
        public void BigNum() // Большие числа
        {
            result = parser.Start("1000000*1000000");
            Assert.AreEqual(1000000000000.0, result, 0.0001);
        }

        [TestMethod]
        public void SmallNum() // Маленькие вещественные числа
        {
            result = parser.Start("0.0001*10000");
            Assert.AreEqual(1, result, 0.0001);
        }

        //Исключения

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivisionByZero() // Деление на ноль
        {
            parser.Start("5/0");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MissSkobka() // Отсутствует закрывающая скобка
        {
            parser.Start("(2+3");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InvChar() // Недопустимый символ
        {
            parser.Start("2+abc");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Empty() // Пустое выражение
        {
            parser.Start("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TwoPlus() // Два оператора подряд
        {
            parser.Start("2++3");
        }

        [TestMethod]
        public void Number() // Одно число
        {
            result = parser.Start("42");
            Assert.AreEqual(42, result, 0.0001);
        }

        [TestMethod]
        public void Opearions() // Много операций без скобок
        {
            result = parser.Start("2+3*4-6/2");
            Assert.AreEqual(11, result, 0.0001); // 2+12-3 = 11
        }

        [TestMethod]
        public void LongTask() // длинное выражение
        {
            string longExpr = "1+2-3*4/5+6-7*8/9+10-11*12/13";
            double result = parser.Start(longExpr);
            Assert.IsNotNull(result);
        }
    }


}