using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp4
{
    internal class cars
    {
        private string carName;
        private int carPower;
        private int carEngine;

        public cars(string name, int power, int engine)
        {
            carName = name;
            carPower = power;
            carEngine = engine;
        }

        //доступ к названию
        public string Name
        {
            get { return carName; }
            set { carName = value; }
        }

        //доступ к мощности
        public int Power
        {
            get { return carPower; }
            set
            {
                if (value >= 0)
                    carPower = value;
            }
        }

        //доступ к расходу двигателя
        public int Engine
        {
            get { return carEngine; }
            set
            {
                if (value >= 0)
                    carEngine = value;
            }
        }

        // форматирование строки для сохранения в файл
        public string ToFileString()
        {
            return string.Format("{0};{1};{2}",
                carName, carPower, carEngine);
        }

        // Статический метод для создания объекта из строки файла
        public static cars FromFileString(string data)
        {
            string[] parts = data.Split(';');
            if (parts.Length == 3)
            {
                return new cars(
                    parts[0],
                    int.Parse(parts[1]),
                    int.Parse(parts[2])
                );
            }
            return null;
        }
    }
}
