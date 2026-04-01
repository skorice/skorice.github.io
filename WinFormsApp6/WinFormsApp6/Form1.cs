using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Drawing; 

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private XDocument xmlReader;
        private string xmlFilePath;
        int dificulty = 1;
        int theme = 1;
        int[] user_score = { 0, 0, 0, 0, 0, 0 };

        // Массив для отслеживания прогресса по каждой теме (Тема 1 - индекс 0, Тема 2 - индекс 1)
        private int[] maxUnlockedDifficulty = { 1, 1 };

        private List<QuestionData> ListQuestions = new List<QuestionData>();
        private int qwInd = 0;
        private int[] userAnsw;
        private bool testRunning = false;
        private int correctCount;

        private class QuestionData
        {
            public string Text { get; set; }
            public List<AnswerData> Answers { get; set; } = new List<AnswerData>();
            public string ImagePath { get; set; } // Новое поле для пути к изображению
        }

        private class AnswerData
        {
            public string Text { get; set; }
            public bool IsCorrect { get; set; }
        }
 

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(823, 495);
            xmlFilePath = Path.Combine(Application.StartupPath, "testing.xml");
            LoadXmlFile();
            button2.Click += button2_Click;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            showHead();
            showTheme();
            UpdateDifficultyButtons();
        }
        private void LoadXmlFile()
        {
            try
            {
                if (File.Exists(xmlFilePath))
                    xmlReader = XDocument.Load(xmlFilePath);
                else
                    MessageBox.Show("Файл testing.xml не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки XML: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обновляет кнопки сложности при смене темы 
        private void UpdateDifficultyButtons()
        {
            int currentTheme = radioButton1.Checked ? 1 : 2;
            int themeIndex = currentTheme - 1;

            radioButton4.Enabled = maxUnlockedDifficulty[themeIndex] >= 2;
            radioButton5.Enabled = maxUnlockedDifficulty[themeIndex] >= 3;

            if (dificulty > maxUnlockedDifficulty[themeIndex])
            {
                dificulty = maxUnlockedDifficulty[themeIndex];
                radioButton3.Checked = dificulty == 1;
                radioButton4.Checked = dificulty == 2;
                radioButton5.Checked = dificulty == 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) theme = 1;
            else if (radioButton2.Checked) theme = 2;

            if (radioButton3.Checked) dificulty = 1;
            else if (radioButton4.Checked) dificulty = 2;
            else if (radioButton5.Checked) dificulty = 3;

            int themeIndexForArray = theme - 1;

            if (dificulty > maxUnlockedDifficulty[themeIndexForArray])
            {
                MessageBox.Show("Сначала пройдите предыдущий уровень сложности в этой теме.", "Недоступно", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            this.Size = new Size(823, 930);
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            getQuestion();
        }

        private void showHead()
        {
            using (XmlReader reader = XmlReader.Create(xmlFilePath))
            {
                do { reader.Read(); }
                while (reader.Name != "head");
                reader.Read();
                label2.Text = reader.Value;
                reader.Read();
            }
        }

        private void getQuestion()
        {
            if (radioButton1.Checked)
                theme = 1;
            else
                theme = 2;

            if (radioButton3.Checked)
                dificulty = 1;
            else if (radioButton4.Checked)
                dificulty = 2;
            else
                dificulty = 3;

            if (!LoadQwe())
                return;

            testRunning = true;
            qwInd = 0;
            correctCount = 0;
            userAnsw = new int[ListQuestions.Count];
            for (int i = 0; i < userAnsw.Length; i++) userAnsw[i] = -1;

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            groupBox3.Visible = true;
            button3.Enabled = false; // Кнопка "Далее" активируется только после "Ответить"

            displayQw();
        }

        private bool LoadQwe()
        {
            try
            {
                var themes = xmlReader.Descendants("theme").ToList();
                var themeNode = themes[theme - 1];
                var levels = themeNode.Descendants("level").ToList();
                XElement levelNode = null;
                foreach (var lvl in levels)
                {
                    string difValue = lvl.Attribute("dif")?.Value;
                    if (difValue == dificulty.ToString())
                    {
                        levelNode = lvl;
                        break;
                    }
                }

                if (levelNode == null)
                {
                    MessageBox.Show($"Уровень сложности {dificulty} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var questionElements = levelNode.Descendants("q").ToList();
                Random rnd = new Random();
                var shuffled = questionElements.OrderBy(x => rnd.Next()).ToList();
                int takeCount = Math.Min(5, shuffled.Count);
                var selected = shuffled.Take(takeCount).ToList();

                ListQuestions.Clear();
                foreach (var qElem in selected)
                {
                    QuestionData qd = new QuestionData();
                    qd.Text = qElem.Element("text")?.Value ?? "Вопрос без текста";

                    // Проверяем, есть ли картинка
                    XElement imageElement = qElem.Element("img");
                    if (imageElement != null)
                    {
                        qd.ImagePath = imageElement.Attribute("src")?.Value; // Новый атрибут ImagePath
                    }
                    var answ = qElem.Element("answers");
                    if (answ != null)
                    {
                        var answerElems = answ.Descendants("answer");
                        foreach (var aElem in answerElems)
                        {
                            AnswerData ad = new AnswerData();
                            ad.Text = aElem.Value;
                            ad.IsCorrect = aElem.Attribute("correct")?.Value == "true";
                            qd.Answers.Add(ad);
                        }
                    }
                    ListQuestions.Add(qd);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки вопросов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void displayQw()
        {
            if (qwInd >= ListQuestions.Count)
            {
                FinishTest();
                return;
            }

            var q = ListQuestions[qwInd];
            groupBox3.Text = q.Text; // Выводим текст вопроса

            // Проверяем, есть ли картинка
            if (!string.IsNullOrEmpty(q.ImagePath))
            {
                // Загружаем и показываем изображение
                pictureBox1.ImageLocation = q.ImagePath;
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false; // Скрываем, если картинки нет
            }

            RadioButton[] answerButtons = { radioButton6, radioButton7, radioButton8, radioButton9 };
            foreach (var rb in answerButtons)
            {
                rb.ForeColor = Color.Black;
            }

            button3.Enabled = false; // Кнопка "Далее" заблокирована до выбора ответа

            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < q.Answers.Count)
                {
                    answerButtons[i].Text = q.Answers[i].Text;
                    answerButtons[i].Visible = true;
                    answerButtons[i].Enabled = true;
                    answerButtons[i].Checked = false;
                }
                else
                {
                    answerButtons[i].Visible = false;
                    answerButtons[i].Enabled = false;
                }
            }

            label4.Text = $"{qwInd + 1}/5 вопросов";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!testRunning) return;

            RadioButton[] answerButtons = { radioButton6, radioButton7, radioButton8, radioButton9 };
            int selectedIndex = -1;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (answerButtons[i].Checked)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex != -1)
            {
                userAnsw[qwInd] = selectedIndex;

                if (qwInd + 1 < ListQuestions.Count)
                {
                    qwInd++;
                    displayQw();
                }
                else
                {
                    FinishTest();
                    return;
                }
            }
        }

        private void showTheme()
        {
            using (XmlReader reader = XmlReader.Create(xmlFilePath))
            {
                int themeIndex = 0;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "theme")
                    {
                        string themeName = reader.GetAttribute("name");
                        themeIndex++;
                        switch (themeIndex)
                        {
                            case 1:
                                radioButton1.Text = themeName;
                                break;
                            case 2:
                                radioButton2.Text = themeName;
                                break;
                        }
                    }
                }
            }
        }

        private void FinishTest()
        {
            testRunning = false;

            correctCount = 0;
            for (int i = 0; i < ListQuestions.Count; i++)
            {
                int selected = userAnsw[i];

                // Проверяем, что ответ вообще был дан и он правильный
                if (selected != -1 && selected < ListQuestions[i].Answers.Count &&
                    ListQuestions[i].Answers[selected].IsCorrect)
                {
                    correctCount++;
                }
            }

            int total = ListQuestions.Count;
            int score = correctCount * 20;

            string message = $"Вы ответили правильно на {correctCount} из {total} вопросов.\nВаш результат: {score} баллов.";

            if (score >= 80)
            {
                message += $"\n\nУровень {dificulty} в теме {theme} пройден!";

                // Определяем индекс массива для текущей темы
                int themeIndexForArray = theme - 1;

                if (dificulty == 1 && !radioButton4.Enabled)
                {
                    radioButton4.Enabled = true; // Разблокируем кнопку сложности 2
                    maxUnlockedDifficulty[themeIndexForArray] = 2;
                }
                else if (dificulty == 2 && !radioButton5.Enabled)
                {
                    radioButton5.Enabled = true; // Разблокируем кнопку сложности 3
                    maxUnlockedDifficulty[themeIndexForArray] = 3;
                }
            }

            MessageBox.Show(message, "Результат теста", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnToMainMenu();
        }

        private void ReturnToMainMenu()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button3.Enabled = false;
            testRunning = false;
            ListQuestions.Clear();
            groupBox3.Visible = false;

            RadioButton[] answerButtons = { radioButton6, radioButton7, radioButton8, radioButton9 };
            foreach (var rb in answerButtons)
            {
                rb.Checked = false;
                rb.Visible = false;
                rb.Enabled = false;
            }
            this.Size = new Size(823, 495);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!testRunning) return;

            RadioButton[] answerButtons = { radioButton6, radioButton7, radioButton8, radioButton9 };
            int selectedIndex = -1;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (answerButtons[i].Checked)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите вариант ответа.", "Внимание");
                return;
            }

            userAnsw[qwInd] = selectedIndex;

            var currentQuestion = ListQuestions[qwInd];

            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < currentQuestion.Answers.Count)
                {
                    if (currentQuestion.Answers[i].IsCorrect)
                    {
                        answerButtons[i].ForeColor = Color.Green;
                    }

                    if (selectedIndex == i && !currentQuestion.Answers[i].IsCorrect)
                    {
                        answerButtons[i].ForeColor = Color.Red;
                    }
                }
            }

            button3.Enabled = true; // Активируем кнопку "Далее"
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDifficultyButtons();
        }
        int open = 1;
        private void button4_Click(object sender, EventArgs e)
        {
            switch (open)
            {
                case 1:
                    // Скрываем игровую панель
                    label1.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    groupBox3.Visible = false;

                    // Показываем админ-панель
                    this.Size = new Size(1350, 495);
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    comboBox1.Visible = true;
                    comboBox2.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    radioButton10.Visible = true;
                    radioButton11.Visible = true;
                    radioButton13.Visible = true;
                    radioButton14.Visible = true;
                    button5.Visible = true;
                    button6.Visible = true;
                    checkBox1.Visible = true;

                    LoadThemesAndLevels();

                    open = 2;
                    break;

                case 2:
                    label1.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    groupBox3.Visible = true;

                    // Прячем админ-панель
                    this.Size = new Size(823, 495);
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    button6.Visible = false;
                    radioButton10.Visible = false;
                    radioButton11.Visible = false;
                    radioButton13.Visible = false;
                    radioButton14.Visible = false;
                    checkBox1.Visible = false;
                    open = 1;
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите текст вопроса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тему и сложность!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int correctAnswerIndex = -1;
            if (radioButton10.Checked) correctAnswerIndex = 0;
            else if (radioButton11.Checked) correctAnswerIndex = 1;
            else if (radioButton13.Checked) correctAnswerIndex = 2;
            else if (radioButton14.Checked) correctAnswerIndex = 3;

            if (correctAnswerIndex == -1)
            {
                MessageBox.Show("Выберите правильный ответ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Формируем XML-структуру нового вопроса
            XElement newQuestion = new XElement("q",
                new XElement("text", textBox1.Text),
                new XElement("answers",
                    new XElement("answer", new XAttribute("correct", correctAnswerIndex == 0), textBox2.Text),
                    new XElement("answer", new XAttribute("correct", correctAnswerIndex == 1), textBox3.Text),
                    new XElement("answer", new XAttribute("correct", correctAnswerIndex == 2), textBox4.Text),
                    new XElement("answer", new XAttribute("correct", correctAnswerIndex == 3), textBox5.Text)
                )
            );

            // Находим нужную тему и сложность в XML-документе
            var themes = xmlReader.Descendants("theme");
            var selectedTheme = themes.FirstOrDefault(t => t.Attribute("name")?.Value == comboBox1.SelectedItem.ToString());

            if (selectedTheme == null)
            {
                MessageBox.Show("Тема не найдена в XML!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Находим нужный уровень сложности
            var selectedLevel = selectedTheme.Elements("level")
                                            .FirstOrDefault(l => l.Attribute("dif")?.Value == comboBox2.SelectedItem.ToString());

            if (selectedLevel == null)
            {
                MessageBox.Show("Уровень сложности не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Находим контейнер <qw> и добавляем туда новый вопрос
            var questionsContainer = selectedLevel.Element("qw");
            if (questionsContainer == null)
            {
                questionsContainer = new XElement("qw");
                selectedLevel.Add(questionsContainer);
            }

            // Добавляем новый вопрос в XML
            questionsContainer.Add(newQuestion);

            if (checkBox1.Checked && !string.IsNullOrEmpty(textBox6.Text))
            {
                // Добавляем элемент img с путём к файлу
                newQuestion.Add(new XElement("img", new XAttribute("src", textBox6.Text)));
            }

            // Сохраняем изменения в файл
            try
            {
                xmlReader.Save(xmlFilePath);
                MessageBox.Show("Вопрос успешно добавлен!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем поля для следующего вопроса
                ClearAdminPanelFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThemesAndLevels()
        {
            // Загружаем темы в комбобокс
            comboBox1.Items.Clear();
            var themes = xmlReader.Descendants("theme");
            foreach (var theme in themes)
            {
                string themeName = theme.Attribute("name")?.Value;
                if (!string.IsNullOrEmpty(themeName))
                {
                    comboBox1.Items.Add(themeName);
                }
            }
            comboBox1.SelectedIndex = 0; // Выбираем первую тему по умолчанию

            // Загружаем уровни сложности в комбобокс
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new object[] { "1", "2", "3" });
            comboBox2.SelectedIndex = 0; 
        }

        private void ClearAdminPanelFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png"; // Только картинки
            dialog.Title = "Выберите изображение для вопроса";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Сохраняем путь к файлу в скрытом текстовом боксе
                textBox6.Text = dialog.FileName;
                MessageBox.Show("Изображение выбрано!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}

