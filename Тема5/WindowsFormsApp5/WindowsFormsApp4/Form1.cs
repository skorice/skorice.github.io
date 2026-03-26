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
        private string usingDict = "big_words.txt";
        private List<string> search;

        public Form1()
        {
            InitializeComponent();
            dict = new WordDictionary();
            LoadDictionary("big_words.txt");
            search = new List<string>();
        }

        private void LoadDictionary(string filePath)
        {
            try
            {
                dict.LoadFromFile(filePath);
                usingDict = filePath;

                listBox1.DataSource = null;
                listBox1.DataSource = dict.GetAllWords();

                string dictType = (filePath == "big_words.txt" || filePath == "small_words.txt") ? "ОСНОВНОЙ" : "ПОЛЬЗОВАТЕЛЬСКИЙ";
                toolStripStatusLabel1.Text = $"Слов в словаре: {dict.Count} | Текущий словарь: {dictType}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки словаря: {ex.Message}");
            }
        }

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

        // Нечёткий поиск
        private void button3_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Введите слово для поиска.");
                return;
            }

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

        // Большая база
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Загрузить большую базу слов?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoadDictionary("big_words.txt");
            }
        }

        // Маленькая база
        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Загрузить маленькую базу слов?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoadDictionary("small_words.txt");
            }
        }

        // Загрузить свой словарь
        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                openFileDialog.Title = "Выберите файл словаря";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDictionary(openFileDialog.FileName);
                }
            }
        }

        // Сортировка
        private void button7_Click(object sender, EventArgs e)
        {
            string start = textBox2.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(start))
            {
                MessageBox.Show("Введите букву или сочетание букв.");
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
                toolStripStatusLabel1.Text = $"Показано слов: {result.Count} (начинаются с '{start}')";
            }
        }

        // Сохранить словарь
        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить словарь?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                    saveFileDialog.Title = "Сохранить словарь";
                    saveFileDialog.FileName = "user_dictionary.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dict.SaveToFile(saveFileDialog.FileName);
                        MessageBox.Show("Словарь сохранён!");
                    }
                }
            }
        }

        // Создать пустой словарь
        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Создать пустой словарь?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dict = new WordDictionary();
                usingDict = "user_dictionary.txt";
                RefreshWordList();
                toolStripStatusLabel1.Text = $"Слов в словаре: 0 | Пустой словарь";
            }
        }

        // Удалить пользовательский словарь
        private void button10_Click(object sender, EventArgs e)
        {
            if (usingDict == "big_words.txt" || usingDict == "small_words.txt")
            {
                MessageBox.Show("Нельзя удалить основной словарь!");
                return;
            }

            if (MessageBox.Show("Удалить пользовательский словарь?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (usingDict != "big_words.txt" && usingDict != "small_words.txt")
                    {
                        System.IO.File.Delete(usingDict);
                    }
                    LoadDictionary("big_words.txt");
                    MessageBox.Show("Пользовательский словарь удалён.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        // Получить файл результатов (слова на букву с максимальной длиной)
        private void button11_Click(object sender, EventArgs e)
        {
            string start = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите букву для поиска слов с максимальной длиной:",
                "Поиск слов",
                "а");

            if (string.IsNullOrEmpty(start))
                return;

            start = start.Trim().ToLower();

            if (start.Length != 1)
            {
                MessageBox.Show("Введите одну букву!");
                return;
            }

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
                saveFileDialog.FileName = $"words_{start}_maxlength.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string content = $"Слова на букву '{start}' с максимальной длиной {maxLength}:\n\n";
                    foreach (string word in longestWords)
                    {
                        content += $"{word}\n";
                    }

                    System.IO.File.WriteAllText(saveFileDialog.FileName, content);
                    MessageBox.Show($"Сохранено {longestWords.Count} слов!");

                    listBox1.DataSource = longestWords;
                    toolStripStatusLabel1.Text = $"Слова на букву '{start}' (макс. длина {maxLength}): {longestWords.Count}";
                }
            }
        }

        private void RefreshWordList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = dict.GetAllWords();
            string dictType = (usingDict == "big_words.txt" || usingDict == "small_words.txt") ? "ОСНОВНОЙ" : "ПОЛЬЗОВАТЕЛЬСКИЙ";
            toolStripStatusLabel1.Text = $"Слов в словаре: {dict.Count} | {dictType}";
        }
    }
}