using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        private List<cars> allCars;
        // файл основной
        private string my_file = @"H:\Медведева Юлия\УП 01 01\Задачи\4\WindowsFormsApp4\cars.txt";
        //файл для пользователя
        private string pols_file;


        public Form1()
        {
            InitializeComponent();
            allCars = new List<cars>();
            pols_file = my_file; // По умолчанию используем основной файл
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing; // Добавляем сохранение при закрытии
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            if (dataGridView1 == null) return;
            dataGridView1.Rows.Clear();
            foreach (cars car in allCars)
            {
                dataGridView1.Rows.Add(car.Name, car.Power, car.Engine);
            }
        }

        // функция для сохранения всех даных в файл
        private void SaveToFile(string filePath)
        {
            try
            {

                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    foreach (cars car in allCars)
                    {
                        writer.WriteLine(car.ToFileString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в файл: {ex.Message}");
            }
        }

        private void LoadFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath)) //существует ли файл
                {
                    List<cars> loaded_car_list = new List<cars>(); // временный список

                    using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8)) //открытие файла для чтения
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) //чтение каждой строки, пока они не закончатся
                        {
                            if (!string.IsNullOrWhiteSpace(line)) //пропуск пустых строк в документе
                            {
                                cars car = cars.FromFileString(line);
                                if (car != null)
                                {
                                    loaded_car_list.Add(car);
                                }
                            }
                        }
                    }

                    //обновляем основной список, если не было ошибок
                    if (loaded_car_list.Count > 0)
                    {
                        allCars = loaded_car_list;
                        //новые данные для comboBox1
                        comboBox1.Items.Clear();
                        foreach (cars car in allCars)
                        {
                            if (!comboBox1.Items.Contains(car.Name))
                            {
                                comboBox1.Items.Add(car.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке из файла: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine($"Загрузка из файла: {my_file}"); // Для отладки
            LoadFromFile(my_file);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile(my_file);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;
            // удаление
            if (e.KeyChar == (char)Keys.Back)
                return; 
            e.KeyChar = '\0';   // остальные символы запрещены (игнорировать)
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                return;
            // удаление
            if (e.KeyChar == (char)Keys.Back)
                return;
            // пробел
            if (e.KeyChar == ' ')
                return;
            e.KeyChar = '\0';   // остальные символы запрещены (игнорировать)
        }
        private string GetCarName()
        {
            string carName = comboBox1.Text.Trim();
            if (string.IsNullOrEmpty(carName))
            {
                MessageBox.Show("Введите название модели!");
                return null; // возвращаем null, если название не введено
            }
            return carName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string carName = GetCarName();
                if (carName == null) return; // если название не введено, выходим

                int carPower = Convert.ToInt32(textBox1.Text);
                int carEngine = Convert.ToInt32(textBox2.Text);

                //создаем машину и добавляем в список
                cars new_car = new cars(carName, carPower, carEngine);
                allCars.Add(new_car);

                // добавляем название в comboBox, если его там еще нет
                if (!comboBox1.Items.Contains(carName))
                {
                    comboBox1.Items.Add(carName);
                }

                SaveToFile(my_file);
                UpdateDataGridView();
                MessageBox.Show($"Машина \"{carName}\" успешно добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении машины: {ex.Message}");
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2) // вкладка с таблицей
            {
                UpdateDataGridView();
            }
            else if (tabControl1.SelectedTab == tabPage3) // вкладка с диаграммой
            {
                UpdateChart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())//чтобы поток автоматически закрывался
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // загружаем данные из выбранного файла
                        LoadFromFile(openFileDialog.FileName);
                        UpdateDataGridView();
                        MessageBox.Show($"Данные успешно загружены из файла:\n{openFileDialog.FileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = "football_teams.txt"; //название файла по умолчанию

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // сохраняем данные в путь пользователя
                        SaveToFile(saveFileDialog.FileName);

                        MessageBox.Show($"Данные успешно сохранены в файл:\n{saveFileDialog.FileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
            }

        }

        private void UpdateChart()
        {
            if (chart1 == null) return;
            var series = chart1.Series["Мощность"];
            series.Points.Clear();
            foreach (cars car in allCars)
            {
                series.Points.AddXY(car.Name, car.Power);
            }
        }

    }
}

