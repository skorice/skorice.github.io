using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WordsLib;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private WordDictionary dict;
        private string usingDict = "big_words.txt"; // Путь к текущему словарю
        private List<string> search; // Храним последние результаты поиска

        public Form1()
        {
            InitializeComponent();
            dict = new WordDictionary();
            LoadDictionary("big_words.txt"); // Загружаем словарь по умолчанию
            search = new List<string>();
        }

        // Загрузка словаря из файла
        private void LoadDictionary(string filePath)
        {
            try
            {
                dict.LoadFromFile(filePath);
                usingDict = filePath;

                // Отображаем все слова в listBox1
                listBox1.DataSource = null;
                listBox1.DataSource = dict.GetAllWords();

                toolStripStatusLabel1.Text = $"Слов в словаре: {dict.Count} | Текущий словарь: ПОЛЬЗОВАТЕЛЬСКИЙ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки словаря: {ex.Message}");
            }
        }

        // ========== КНОПКИ ПЕРВОЙ ВКЛАДКИ ==========

        // Добавление слова
        private void button1_Click(object sender, EventArgs e)
        {
            string newWord = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(newWord))
            {
                MessageBox.Show("Введите слово для добавления.");
                return;
            }

            if (dict.AddWord(newWord))
            {
                RefreshWordList();
                textBox1.Clear();
                MessageBox.Show("Слово успешно добавлено!");
            }
            else
            {
                MessageBox.Show("Такое слово уже есть в словаре!");
            }
        }

        // Удаление слова
        private void button2_Click(object sender, EventArgs e)
        {
            string wordRemove = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(wordRemove))
            {
                MessageBox.Show("Введите слово для удаления.");
                return;
            }

            if (dict.RemoveWord(wordRemove))
            {
                RefreshWordList();
                textBox1.Clear();
                MessageBox.Show("Слово успешно удалено!");
            }
            else
            {
                MessageBox.Show("Слово не найдено в словаре!");
            }
        }

        // Нечёткий поиск слов (расстояние Левенштейна не более 3)
        private void button3_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Введите слово для поиска.");
                return;
            }

            // поиск
            var results = dict.FuzzySearch(searchTerm, 3);
            search = results.ToList();

            if (results.Count == 0)
            {
                MessageBox.Show("Слова не найдены.");
                listBox1.DataSource = null;
                toolStripStatusLabel1.Text = $"Слов в словаре: {dict.Count} | Найдено: 0";
            }
            else
            {
                listBox1.DataSource = results;
                toolStripStatusLabel1.Text = $"Найдено слов: {results.Count} (всего в словаре: {dict.Count})";
            }
        }

        // ========== КНОПКИ ВТОРОЙ ВКЛАДКИ ==========

        // Выбор большой базы слов
        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Загрузить большую базу слов? Текущий словарь будет заменён.");

            if (result == DialogResult.Yes)
            {
                LoadDictionary("big_words.txt");
            }
        }

        // Выбор маленькой базы слов
        private void button5_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Загрузить маленькую базу слов? Текущий словарь будет заменён.");

            if (result == DialogResult.Yes)
            {
                LoadDictionary("small_words.txt");
            }
        }

        // Загрузить свой словарь
        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите файл словаря";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadDictionary(openFileDialog.FileName);
                        MessageBox.Show("Словарь успешно загружен!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки словаря: {ex.Message}");
                    }
                }
            }
        }

        // Сортировка слов, начиная с заданной буквы или сочетания
        private void button7_Click(object sender, EventArgs e)
        {
            string start = textBox2.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(start))
            {
                MessageBox.Show("Введите букву или сочетание букв для сортировки.");
                return;
            }

            var allWords = dict.GetAllWords();
            var result = allWords.Where(w => w.StartsWith(start)).ToList();

            if (result.Count == 0)
            {
                MessageBox.Show($"Слова, начинающиеся с '{start}', не найдены.");
                listBox1.DataSource = null;
            }
            else
            {
                listBox1.DataSource = result;
                toolStripStatusLabel1.Text = $"Показано слов: {result.Count} (начинаются с '{start}') | Всего: {dict.Count}";
            }
        }

        // Сохранение словаря
        private void button8_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Сохранить изменения в словаре? Основной словарь не будет изменён.");

            if (result == DialogResult.Yes)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                    saveFileDialog.Title = "Сохранить словарь";
                    saveFileDialog.FileName = "dict.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            dict.SaveToFile(saveFileDialog.FileName);
                            MessageBox.Show($"Словарь сохранён в файл: {saveFileDialog.FileName}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                        }
                    }
                }
            }
        }

        // Создание пустого словаря
        private void button9_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Создать пустой словарь? Все несохранённые изменения будут потеряны.");

            if (result == DialogResult.Yes)
            {
                dict = new WordDictionary();
                usingDict = "dict.txt";
                RefreshWordList();
                toolStripStatusLabel1.Text = $"Слов в словаре: 0 | Новый словарь";
            }
        }

        // Удаление пользовательского словаря
        private void button10_Click(object sender, EventArgs e)
        {
            if (usingDict == "big_words.txt" || usingDict == "big_words.txt" || usingDict == "small_words.txt")
            {
                MessageBox.Show("Нельзя удалить основной словарь!");
                return;
            }

            var result = MessageBox.Show($"Удалить пользовательский словарь '{usingDict}'?");

            if (result == DialogResult.Yes)
            {
                try
                {
                    System.IO.File.Delete(usingDict);
                    LoadDictionary("big_words.txt"); // по умолчанию
                    MessageBox.Show("Пользовательский словарь удалён. Загружен словарь по умолчанию.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        // Получение файла результатов (поиск слов, начинающихся на заданную букву с максимальной длиной)
        private void button11_Click(object sender, EventArgs e)
        {
            string start = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите букву для поиска слов с максимальной длиной:",
                "Поиск слов максимальной длины",
                "а",
                -1, -1);

            if (string.IsNullOrEmpty(start))
                return;

            start = start.Trim().ToLower();

            if (start.Length != 1)
            {
                MessageBox.Show("Пожалуйста, введите одну букву.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Находим все слова, начинающиеся на заданную букву
            var allWords = dict.GetAllWords();
            var wordsStartingWith = allWords.Where(w => w.StartsWith(start)).ToList();

            if (wordsStartingWith.Count == 0)
            {
                MessageBox.Show($"Слова на букву '{start}' не найдены.");
                return;
            }

            int maxLength = wordsStartingWith.Max(w => w.Length);

            var longestWords = wordsStartingWith.Where(w => w.Length == maxLength).ToList();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveFileDialog.Title = "Сохранить результаты поиска";
                saveFileDialog.FileName = $"resultsWith_{start}.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = $"Поиск слов на букву '{start}' с максимальной длиной\n";
                        content += $"Максимальная длина: {maxLength}\n";
                        content += $"Количество найденных слов: {longestWords.Count}\n";

                        foreach (string word in longestWords)
                        {
                            content += $"{word} (длина: {word.Length})\n";
                        }

                        MessageBox.Show($"Результаты сохранены в файл:\n{saveFileDialog.FileName}");

                        listBox1.DataSource = longestWords;
                        toolStripStatusLabel1.Text = $"Слова максимальной длины ({maxLength}) на букву '{start}': {longestWords.Count}";
                        search = longestWords;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                    }
                }
            }
        }
        // метод для обновления списка слов
        private void RefreshWordList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = dict.GetAllWords();
            toolStripStatusLabel1.Text = $"Слов в словаре: {dict.Count}";
        }
    }
}