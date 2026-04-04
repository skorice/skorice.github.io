using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Переменные игры
        private string currentWord;
        private char[] guessedLetters;
        private List<char> wrongLetters;
        private int errors;
        private int maxErrors;
        private List<string> dictionary;

        // Переменные игрока и настроек
        private string currentPlayer = "Гость";
        private bool isAuthorized = false;
        private DifficultyLevel currentDifficulty = DifficultyLevel.Medium;
        private List<GameResult> allResults = new List<GameResult>();
        private string resultsFile = "game_results.dat";

        // Статистика текущей игры
        private DateTime gameStartTime;
        private int hintsUsed = 0;
        private int maxHints;

        private int timeRemaining;         
        private bool isTimeLimited = false;
        private int selectedTimeSeconds = 60; 

        private int houseStage = 0;  // 0 - пустой участок, 1-6 - этапы строительства
        private Bitmap houseBitmap;   // для хранения рисунка дома

        [Serializable]
        public class GameResult
        {
            public string PlayerName { get; set; }
            public DateTime GameDate { get; set; }
            public string Word { get; set; }
            public bool IsWin { get; set; }
            public int ErrorsCount { get; set; }
            public int HintsUsed { get; set; }
            public string Difficulty { get; set; }
            public int GameDurationSeconds { get; set; }
        }

        public enum DifficultyLevel
        {
            Easy,    // слова 3-4 буквы, 5 попыток, 2 подсказки
            Medium,  // слова 5-6 букв, 6 попыток, 2 подсказки
            Hard     // слова 7-8 букв, 8 попыток, 1 подсказка
        }
        public Form1()
        {
            InitializeComponent();
            LoadAllResults();
            SetupTableLayout();
            LoadDictionary();
            StartNewGame();
        }
        private void DrawHouse()
        {
            if (pictureBox1 == null) return;

            houseBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(houseBitmap))
            {
                g.Clear(Color.SkyBlue);
                g.FillRectangle(Brushes.Green, 0, pictureBox1.Height - 30, pictureBox1.Width, 30);

                Pen blackPen = new Pen(Color.Black, 2);

                // В зависимости от сложности рисуем разное количество деталей
                switch (currentDifficulty)
                {
                    case DifficultyLevel.Easy:  // 5 ошибок = 5 деталей
                        DrawEasyHouse(g, blackPen);
                        break;
                    case DifficultyLevel.Medium: // 6 ошибок = 6 деталей
                        DrawMediumHouse(g, blackPen);
                        break;
                    case DifficultyLevel.Hard:   // 8 ошибок = 8 деталей
                        DrawHardHouse(g, blackPen);
                        break;
                }

                // Подпись этапа строительства
                string stageText = $"Этап строительства: {errors}/{maxErrors}";
                g.DrawString(stageText, new Font("Arial", 9), Brushes.DarkBlue, 10, 10);
            }
            pictureBox1.Image = houseBitmap;
            pictureBox1.Refresh();
        }

        private void DrawEasyHouse(Graphics g, Pen blackPen)
        {
            // Лёгкий уровень: 5 деталей 

            if (errors >= 1) // Фундамент
            {
                g.DrawRectangle(blackPen, 50, 200, 100, 20);
                g.FillRectangle(Brushes.DarkGray, 50, 200, 100, 20);
            }

            if (errors >= 2) // Стены
            {
                g.DrawRectangle(blackPen, 50, 120, 100, 80);
                g.FillRectangle(Brushes.Wheat, 50, 120, 100, 80);
            }

            if (errors >= 3) // Крыша
            {
                Point[] roof = { new Point(40, 120), new Point(100, 60), new Point(160, 120) };
                g.DrawPolygon(blackPen, roof);
                g.FillPolygon(Brushes.Firebrick, roof);
            }

            if (errors >= 4) // Дверь
            {
                g.DrawRectangle(blackPen, 75, 160, 30, 40);
                g.FillRectangle(Brushes.SaddleBrown, 75, 160, 30, 40);
                g.FillEllipse(Brushes.Gold, 98, 175, 5, 5);
            }

            if (errors >= 5) // Окно
            {
                g.DrawRectangle(blackPen, 85, 135, 20, 20);
                g.FillRectangle(Brushes.LightBlue, 85, 135, 20, 20);
                g.DrawLine(blackPen, 95, 135, 95, 155);
                g.DrawLine(blackPen, 85, 145, 105, 145);
            }
        }

        private void DrawMediumHouse(Graphics g, Pen blackPen)
        {
            // Средний уровень: 6 деталей 

            DrawEasyHouse(g, blackPen); // Рисуем первые 5 деталей

            if (errors >= 6) // Труба
            {
                g.DrawRectangle(blackPen, 120, 70, 15, 50);
                g.FillRectangle(Brushes.Gray, 120, 70, 15, 50);
                g.DrawEllipse(new Pen(Color.LightGray, 1), 125, 55, 10, 10);
                g.DrawEllipse(new Pen(Color.LightGray, 1), 130, 45, 12, 12);
            }
        }

        private void DrawHardHouse(Graphics g, Pen blackPen)
        {
            // Сложный уровень: 8 деталей 

            DrawMediumHouse(g, blackPen); // Рисуем первые 6 деталей

            if (errors >= 7) // Забор и цветы
            {
                // Забор слева
                for (int i = 0; i < 4; i++)
                {
                    g.DrawLine(blackPen, 30 + i * 8, 200, 30 + i * 8, 220);
                }
                g.DrawLine(blackPen, 30, 215, 55, 215);

                // Забор справа
                for (int i = 0; i < 4; i++)
                {
                    g.DrawLine(blackPen, 145 + i * 8, 200, 145 + i * 8, 220);
                }
                g.DrawLine(blackPen, 145, 215, 170, 215);

                // Цветы
                g.FillEllipse(Brushes.Red, 35, 205, 6, 6);
                g.FillEllipse(Brushes.Yellow, 48, 208, 5, 5);
                g.FillEllipse(Brushes.Pink, 155, 205, 6, 6);
                g.FillEllipse(Brushes.Orange, 165, 208, 5, 5);
            }

            if (errors >= 8) // Второе окно (чердачное)
            {
                // Круглое окно на чердаке
                g.DrawEllipse(blackPen, 90, 95, 20, 20);
                g.FillEllipse(Brushes.LightBlue, 90, 95, 20, 20);
                g.DrawLine(blackPen, 100, 95, 100, 115);
                g.DrawLine(blackPen, 90, 105, 110, 105);
            }
        }

        private void ClearHouseDrawing()
        {
            if (pictureBox1 != null)
            {
                houseBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(houseBitmap))
                {
                    g.Clear(Color.SkyBlue);
                    g.FillRectangle(Brushes.Green, 0, pictureBox1.Height - 30, pictureBox1.Width, 30);

                    string detailsCount = currentDifficulty switch
                    {
                        DifficultyLevel.Easy => "5 деталей",
                        DifficultyLevel.Medium => "6 деталей",
                        DifficultyLevel.Hard => "8 деталей",
                        _ => "6 деталей"
                    };

                }
                pictureBox1.Image = houseBitmap;
                pictureBox1.Refresh();
            }
        }
        private void InitializeTimer()
        {
            timer1.Interval = 1000;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeRemaining > 0)
            {
                timeRemaining--;
                UpdateTimeDisplay();

                if (timeRemaining == 10)
                {
                    label1.Text = "⚠️ Осталось всего 10 секунд! ⚠️";
                    label1.ForeColor = Color.Orange;
                }

                if (timeRemaining <= 0)
                {
                    TimeOut();
                }
            }
        }

        private void UpdateTimeDisplay()
        {
            if (label7 != null)
            {
                if (isTimeLimited)
                {
                    label7.Text = $"⏱️ Время: {timeRemaining / 60}:{(timeRemaining % 60).ToString("00")}";
                    label7.ForeColor = timeRemaining <= 10 ? Color.Red : Color.Black;
                }
                else
                {
                    label7.Text = "⏱️ Время: не ограничено";
                    label7.ForeColor = Color.Gray;
                }
            }
        }

        private void TimeOut()
        {
            if (timer1 != null) timer1.Stop();
            label1.Text = "⏰ ВРЕМЯ ВЫШЛО! Строитель достроил дом! ⏰";
            label1.ForeColor = Color.OrangeRed;
            textBox1.Enabled = false;
            button1.Enabled = false;

            int duration = (int)(DateTime.Now - gameStartTime).TotalSeconds;
            SaveGameResult(false, duration);

            MessageBox.Show($"Время вышло!\nЗагаданное слово: {currentWord}", "Поражение!");

            for (int i = 0; i < currentWord.Length; i++)
            {
                guessedLetters[i] = currentWord[i];
            }
            UpdateWordDisplay();
        }

        private void SetTimeLimit(int seconds)
        {
            if (seconds <= 0)
            {
                isTimeLimited = false;
                if (timer1 != null && timer1.Enabled)
                    timer1.Stop();
            }
            else
            {
                isTimeLimited = true;
                selectedTimeSeconds = seconds;
            }
            UpdateTimeDisplay();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите букву!", "Внимание");
                return;
            }

            char letter = char.ToUpper(textBox1.Text[0]);
            textBox1.Clear();

            if (!char.IsLetter(letter))
            {
                MessageBox.Show("Введите русскую букву!", "Ошибка");
                return;
            }

            bool alreadyGuessed = false;

            foreach (char c in guessedLetters)
            {
                if (c == letter)
                {
                    alreadyGuessed = true;
                    break;
                }
            }

            if (!alreadyGuessed && wrongLetters.Contains(letter))
            {
                alreadyGuessed = true;
            }

            if (alreadyGuessed)
            {
                MessageBox.Show("Вы уже вводили эту букву!", "Внимание");
                return;
            }

            bool isCorrect = false;
            
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == letter)
                {
                    guessedLetters[i] = letter;
                    isCorrect = true;
                }
            }

            if (isCorrect)
            {
                UpdateWordDisplay();
                CheckWin();
            }
            else
            {
                wrongLetters.Add(letter);
                errors++;
                UpdateStatus();
                DrawHouse(); 
                CheckLose();
            }
        }

        private void игрокToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void LoadDictionary()
        {
            dictionary = new List<string>();
            string filePath = "dictionary.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    dictionary = File.ReadAllLines(filePath)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(line => line.Trim().ToUpper())
                        .ToList();
                }
                else
                {
                    // Если словарь не подгрузился
                    var words = new[]
                    {
                        "ДОМ", "КОТ", "СТОЛ", "МЫШЬ", "ФИЛОСОФ", "СТРОИТЕЛЬ",
                        "МУДРОСТЬ", "КАМЕНЬ", "ДЕРЕВО", "ОКНО", "ДВЕРЬ", "КНИГА",
                        "УЧИТЕЛЬ", "УЧЕНИК", "ПАРТА", "ШКОЛА", "УНИВЕРСИТЕТ",
                        "БИБЛИОТЕКА", "АРХИТЕКТОР", "ФИЛОСОФИЯ", "СТРОЙКА"
                    };
                    File.WriteAllLines(filePath, words);
                    dictionary = words.Select(w => w.ToUpper()).ToList();
                    toolStripStatusLabel2.Text = "Словарь: стандартный";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки словаря: {ex.Message}");
                dictionary = new List<string> { "ДОМ", "КОТ", "СТОЛ" };
            }
        }
        private void StartNewGame()
        {
            if (dictionary.Count == 0)
            {
                MessageBox.Show("Словарь пуст!");
                return;
            }

            var filteredWords = GetWordsByDifficulty();
            if (filteredWords.Count == 0)
                filteredWords = dictionary;

            Random rand = new Random();
            currentWord = filteredWords[rand.Next(filteredWords.Count)];
            guessedLetters = new char[currentWord.Length];
            wrongLetters = new List<char>();
            errors = 0;
            ClearHouseDrawing();  // Очищаем рисунок дома
            hintsUsed = 0;
            gameStartTime = DateTime.Now;

            SetDifficultyParameters();

            for (int i = 0; i < currentWord.Length; i++)
            {
                guessedLetters[i] = '_';
            }

            // НАСТРОЙКА ТАЙМЕРА
            if (timer1 == null)
                InitializeTimer();
            else if (timer1.Enabled)
                timer1.Stop();

            if (isTimeLimited)
            {
                timeRemaining = selectedTimeSeconds;
                timer1.Start();
            }

            UpdateTimeDisplay();
            UpdateWordDisplay();
            UpdateStatus();
            textBox1.Clear();
            textBox1.Enabled = true;
            button1.Enabled = true;
            label1.Text = $"Игра началась! Слово из {currentWord.Length} букв" +
                          (isTimeLimited ? $" | Время: {selectedTimeSeconds} сек" : "");
            label1.ForeColor = Color.Black;

            UpdateStatusStrip();
        }
        private List<string> GetWordsByDifficulty()
        {
            switch (currentDifficulty)
            {
                case DifficultyLevel.Easy:
                    return dictionary.Where(w => w.Length >= 3 && w.Length <= 4).ToList();
                case DifficultyLevel.Medium:
                    return dictionary.Where(w => w.Length >= 5 && w.Length <= 6).ToList();
                case DifficultyLevel.Hard:
                    return dictionary.Where(w => w.Length >= 7 && w.Length <= 8).ToList();
                default:
                    return dictionary;
            }
        }
        private void SetDifficultyParameters()
        {
            switch (currentDifficulty)
            {
                case DifficultyLevel.Easy:
                    maxErrors = 5;
                    maxHints = 2;
                    break;
                case DifficultyLevel.Medium:
                    maxErrors = 6;
                    maxHints = 2;
                    break;
                case DifficultyLevel.Hard:
                    maxErrors = 8;
                    maxHints = 1;
                    break;
            }
        }
        private void UpdateWordDisplay()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = currentWord.Length;
            tableLayoutPanel1.RowCount = 1;

            
            for (int i = 0; i < currentWord.Length; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            }

            tableLayoutPanel1.Width = currentWord.Length * 50;

            for (int i = 0; i < currentWord.Length; i++)
            {
                Label letterLabel = new Label();
                letterLabel.Text = guessedLetters[i].ToString();
                letterLabel.Font = new Font("Arial", 20, FontStyle.Bold);
                letterLabel.TextAlign = ContentAlignment.MiddleCenter;
                letterLabel.Dock = DockStyle.Fill;
                letterLabel.BackColor = Color.White;
                letterLabel.BorderStyle = BorderStyle.FixedSingle;
                tableLayoutPanel1.Controls.Add(letterLabel, i, 0);
            }
        }
        private void UpdateStatus()
        {
            label5.Text = $"Осталось попыток: {maxErrors - errors} | Подсказок: {maxHints - hintsUsed}";

            string wrongText = "Уже использованные буквы: ";
            if (wrongLetters.Count > 0)
            {
                wrongText += string.Join(", ", wrongLetters);
            }
            else
            {
                wrongText += "нет";
            }
            label3.Text = wrongText;
        }
        private void UpdateStatusStrip()
        {
            toolStripStatusLabel1.Text = $"Игрок: {currentPlayer}";
            toolStripStatusLabel2.Text = $"Сложность: {currentDifficulty} | " +
                                          $"Время: {(isTimeLimited ? $"{selectedTimeSeconds} сек" : "без лимита")}";
        }
        private void CheckWin()
        {
            if (new string(guessedLetters) == currentWord)
            {
                if (timer1 != null && timer1.Enabled)
                    timer1.Stop();

                int duration = (int)(DateTime.Now - gameStartTime).TotalSeconds;
                label1.Text = "🎉 ПОБЕДА! Философ угадал слово! 🎉";
                label1.ForeColor = Color.Green;
                textBox1.Enabled = false;
                button1.Enabled = false;

                SaveGameResult(true, duration);

                MessageBox.Show($"Поздравляем! Вы угадали слово: {currentWord}\n" +
                    $"Ошибок: {errors}\nПодсказок использовано: {hintsUsed}\nВремя: {duration} сек.",
                    "Победа!");
            }
        }
        private void CheckLose()
        {
            if (errors >= maxErrors)
            {
                if (timer1 != null && timer1.Enabled)
                    timer1.Stop();

                int duration = (int)(DateTime.Now - gameStartTime).TotalSeconds;
                label1.Text = "💀 ПОРАЖЕНИЕ! Дом построен! Слово не угадано 💀";
                label1.ForeColor = Color.Red;
                textBox1.Enabled = false;
                button1.Enabled = false;

                SaveGameResult(false, duration);

                MessageBox.Show($"Строитель построил дом!\nЗагаданное слово: {currentWord}\n" +
                    $"Ошибок: {errors}\nВремя: {duration} сек.", "Поражение!");

                for (int i = 0; i < currentWord.Length; i++)
                {
                    guessedLetters[i] = currentWord[i];
                }
                UpdateWordDisplay();
            }
        }
        private void SaveGameResult(bool isWin, int duration)
        {
            var result = new GameResult
            {
                PlayerName = currentPlayer,
                GameDate = DateTime.Now,
                Word = currentWord,
                IsWin = isWin,
                ErrorsCount = errors,
                HintsUsed = hintsUsed,
                Difficulty = currentDifficulty.ToString(),
                GameDurationSeconds = duration
            };

            allResults.Add(result);
            SaveAllResults();
        }
#pragma warning disable SYSLIB0011
        private void SaveAllResults()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(resultsFile, FileMode.Create))
                {
                    formatter.Serialize(fs, allResults);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения результатов: {ex.Message}");
            }
        }
        private void LoadAllResults()
        {
            try
            {
                if (File.Exists(resultsFile))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(resultsFile, FileMode.Open))
                    {
                        allResults = (List<GameResult>)formatter.Deserialize(fs);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки результатов: {ex.Message}");
                allResults = new List<GameResult>();
            }
        }
#pragma warning restore SYSLIB0011
        private void ShowPlayerResults()
        {
            var playerResults = allResults.Where(r => r.PlayerName == currentPlayer).ToList();

            if (playerResults.Count == 0)
            {
                MessageBox.Show($"У игрока {currentPlayer} нет сохранённых игр", "Статистика");
                return;
            }
            string stats = $"Результаты игрока {currentPlayer}:\n\n";
            stats += $"Всего игр: {playerResults.Count}\n";
            stats += $"Побед: {playerResults.Count(r => r.IsWin)}\n";
            stats += $"Поражений: {playerResults.Count(r => !r.IsWin)}\n";
            stats += $"Процент побед: {(double)playerResults.Count(r => r.IsWin) / playerResults.Count * 100:F1}%\n\n";
            stats += "Последние 5 игр:\n";

            foreach (var result in playerResults.OrderByDescending(r => r.GameDate).Take(5))
            {
                stats += $"{result.GameDate:dd.MM HH:mm} - {result.Word} - {(result.IsWin ? "Победа" : "Поражение")} - {result.Difficulty}\n";
            }

            MessageBox.Show(stats, "Моя статистика");
        }
        private void ShowAllPlayersStats()
        {
            if (allResults.Count == 0)
            {
                MessageBox.Show("Нет сохранённых результатов", "Статистика");
                return;
            }

            var playersStats = allResults.GroupBy(r => r.PlayerName)
                .Select(g => new
                {
                    Player = g.Key,
                    Games = g.Count(),
                    Wins = g.Count(r => r.IsWin),
                    AvgTime = g.Average(r => r.GameDurationSeconds)
                }).ToList();

            string stats = "Статистика всех игроков:\n\n";
            foreach (var p in playersStats)
            {
                stats += $"{p.Player}:\n";
                stats += $"  Игр: {p.Games}, Побед: {p.Wins} ({(double)p.Wins / p.Games * 100:F1}%)\n";
                stats += $"  Среднее время: {p.AvgTime:F0} сек.\n\n";
            }

            MessageBox.Show(stats, "Общая статистика");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDictionary();
            StartNewGame();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // ========== ВЫБОР СЛОЖНОСТИ ==========
        private void лёгкаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentDifficulty = DifficultyLevel.Easy;
            UpdateStatusStrip();
            StartNewGame();
        }
        private void средняяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            currentDifficulty = DifficultyLevel.Medium;
            UpdateStatusStrip();
            StartNewGame();
        }
        private void сложнаяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            currentDifficulty = DifficultyLevel.Hard;
            UpdateStatusStrip();
            StartNewGame();
        }
        // ========== О ПРОГРАММЕ ==========
        private void оПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Игра «Строитель и философ»\nВерсия 1.0\n\n" +
            "Правила:\n" +
            "- Угадайте слово по буквам\n" +
            "- За каждую ошибку строится часть дома\n" +
            "- Используйте подсказки с умом\n" +
            "- Успевайте до того, как дом построят или выйдет время\n\n" +
            "О программе");
        }
        // ========== СТАТИСТИКА ==========
        private void показатьМоиРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPlayerResults();
        }
        private void показатьОбщиеРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllPlayersStats();
        }
        // ========== АВТОРИЗАЦИЯ ==========
        private void авторизацияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string playerName = Microsoft.VisualBasic.Interaction.InputBox(
            "Введите имя игрока:",
            "Авторизация",
            currentPlayer != "Гость" ? currentPlayer : "");

            if (!string.IsNullOrWhiteSpace(playerName))
            {
                currentPlayer = playerName.Trim();
                isAuthorized = true;
                UpdateStatusStrip();
                StartNewGame();
                MessageBox.Show($"Добро пожаловать, {currentPlayer}!", "Авторизация");
            }
        }
        private void сменитьИгрокаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            currentPlayer = "Гость";
            isAuthorized = false;
            UpdateStatusStrip();
            StartNewGame();
            MessageBox.Show("Вы вошли как гость", "Смена игрока");
        }
        // ========== НАСТРОЙКИ ВРЕМЕНИ ==========
        private void времяСеансаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeLimit(0);
            UpdateStatusStrip();
            StartNewGame();
        }
        private void ptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeLimit(30);
            UpdateStatusStrip();
            StartNewGame();
        }
        private void секToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeLimit(60);
            UpdateStatusStrip();
            StartNewGame();
        }
        private void секToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetTimeLimit(120);
            UpdateStatusStrip();
            StartNewGame();
        }
        private void секToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetTimeLimit(180);
            UpdateStatusStrip();
            StartNewGame();
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            StartNewGame();
        }
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (guessedLetters == null || currentWord == null)
            {
                MessageBox.Show("Игра ещё не начата!", "Ошибка");
                return;
            }
            if (hintsUsed >= maxHints)
            {
                MessageBox.Show($"Подсказки закончились! Доступно только {maxHints} подсказок на игру", "Ошибка");
                return;
            }
            int firstEmptyIndex = -1;
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                if (guessedLetters[i] == '_')
                {
                    firstEmptyIndex = i;
                    break;
                }
            }
            if (firstEmptyIndex == -1)
            {
                MessageBox.Show("Все буквы уже открыты!", "Подсказка");
                return;
            }
            char hintLetter = currentWord[firstEmptyIndex];
            int openedCount = 0;
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == hintLetter && guessedLetters[i] == '_')
                {
                    guessedLetters[i] = hintLetter;
                    openedCount++;
                }
            }
            hintsUsed++;
            UpdateWordDisplay();
            UpdateStatus();

            MessageBox.Show($"Подсказка: буква '{hintLetter}' открыта на {openedCount} позиции(ях)\n" +
                $"Осталось подсказок: {maxHints - hintsUsed}", "Подсказка");

            CheckWin();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            SetupTableLayout();
        }
        private void SetupTableLayout()
        {
            tableLayoutPanel1.Anchor = AnchorStyles.Top;
            tableLayoutPanel1.AutoSize = false;
            int formWidth = this.ClientSize.Width;
            int centerX = formWidth / 2;
            label4.Left = centerX - label4.Width / 2;
            label1.Left = centerX - label1.Width / 2;
            label2.Left = centerX - label2.Width / 2;

            textBox1.Left = centerX - textBox1.Width / 2;
            button1.Left = centerX - button1.Width/2;
        }

    }

}
