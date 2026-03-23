using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordsLib
{
    public class WordDictionary
    {
        private List<string> words;

        public WordDictionary()
        {
            words = new List<string>();
        }

        // Загрузка словаря из файла
        public void LoadFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Файл {filePath} не найден.");
                }

                var loadedWords = File.ReadAllLines(filePath);

                // Обрабатываем каждое слово
                words = loadedWords
                    .Select(w => w.Trim().ToLower())          // Убираем пробелы и приводим к нижнему регистру
                    .Where(w => !string.IsNullOrEmpty(w))      // Убираем пустые строки
                    .Distinct()                               // Убираем дубликаты
                    .OrderBy(w => w)                          // Сортируем по алфавиту
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки словаря: {ex.Message}", ex);
            }
        }

        // 2. Добавление слова
        public bool AddWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            word = word.Trim().ToLower();

            // Проверяем, есть ли уже такое слово
            if (words.Contains(word))
                return false;

            words.Add(word);
            words.Sort();

            return true;
        }

        // 3. Удаление слова
        public bool RemoveWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            word = word.Trim().ToLower();

            // Удаляем слово и возвращаем результат
            return words.Remove(word);
        }

        // 4. Поиск слов (содержащих подстроку)
        public List<string> FindWords(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return new List<string>();

            search = search.Trim().ToLower();

            // Ищем слова, содержащие поисковую строку
            return words
                .Where(w => w.Contains(search))
                .ToList();
        }

        // 5. Расстояние Левенштейна
        private int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            // Создаём матрицу расстояний
            int[,] d = new int[n + 1, m + 1];

            // Если одна из строк пустая
            if (n == 0) return m;
            if (m == 0) return n;

            // Инициализируем первую строку и первый столбец
            for (int i = 0; i <= n; i++)
                d[i, 0] = i;

            for (int j = 0; j <= m; j++)
                d[0, j] = j;

            // Заполняем матрицу
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    // Стоимость замены (0 если символы одинаковые, 1 если разные)
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;

                    // Минимальное из трёх возможных действий
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1,      // Удаление
                                 d[i, j - 1] + 1),     // Вставка
                        d[i - 1, j - 1] + cost);       // Замена
                }
            }

            return d[n, m];
        }

        // 6. Нечёткий поиск (расстояние Левенштейна не более maxDistance)
        public List<string> FuzzySearch(string searchTerm, int maxDistance = 3)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<string>();

            searchTerm = searchTerm.Trim().ToLower();
            var results = new List<string>();

            foreach (var word in words)
            {
                // Вычисляем расстояние Левенштейна
                int distance = LevenshteinDistance(searchTerm, word);

                // Если расстояние не превышает максимальное, добавляем в результаты
                if (distance <= maxDistance)
                {
                    results.Add(word);
                }
            }

            return results;
        }

        // 7. Получить все слова (для отображения)
        public List<string> GetAllWords()
        {
            return words.ToList(); // Возвращаем копию списка
        }

        // 8. Количество слов в словаре
        public int Count
        {
            get { return words.Count; }
        }

        // 9. Проверка существования слова
        public bool Contains(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            return words.Contains(word.Trim().ToLower());
        }

        // 10. Сохранение словаря в файл (опционально)
        public void SaveToFile(string filePath)
        {
            try
            {
                File.WriteAllLines(filePath, words);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сохранения словаря: {ex.Message}", ex);
            }
        }
    }
}