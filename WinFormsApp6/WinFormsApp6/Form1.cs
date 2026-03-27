using System.Xml;
using System.Xml.Linq;

namespace WinFormsApp6
{

    public partial class Form1 : Form
    {
        private XDocument xmlReader;
        private string xmlFilePath;
        int dificulty = 1;
        int theme = 1;
        int[] user_score = { 0, 0, 0, 0, 0, 0 };

        private List<QuestionData> ListQuestions = new List<QuestionData>(); // текущие вопросы
        private int qwInd = 0;          // индекс текущего вопроса
        private int[] userAnsw;                   // выбранные индексы ответов (0-3) или -1
        private bool testRunning = false;             // идет ли тест
        private int correctCount;
        private class QuestionData
        {
            public string Text { get; set; }
            public List<AnswerData> Answers { get; set; } = new List<AnswerData>();
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

            showHead();
            showTheme();
        }
        private void LoadXmlFile()
        {
            try
            {
                if (File.Exists(xmlFilePath))
                    xmlReader = XDocument.Load(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки XML: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(823, 837);
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            getQuestion();
        }

        private void ShowHead()
        {
            if (xmlReader?.Root == null) return;

            // Ищем элемент head
            var headElement = xmlReader.Root.Element("head");

            if (headElement != null)
            {
                string text = headElement.Value.Trim();
                this.Text = string.IsNullOrEmpty(text) ? "Тестирование" : text;
            }
            else
            {
                // Если head не найден на первом уровне, ищем глубже
                headElement = xmlReader.Descendants("head").FirstOrDefault();
                if (headElement != null)
                {
                    this.Text = headElement.Value.Trim();
                }
            }
        }

        private void showHead()// метод выводит название теста
        {
            using (XmlReader reader = XmlReader.Create(xmlFilePath))
            {
                // ищем узел <head>
                do { reader.Read(); }
                while (reader.Name != "head");
                // считываем заголовок
                reader.Read();
                // вывести название теста в заголовок окна
                label2.Text = reader.Value;
                // выходим из узла <head>
                reader.Read();
            }
        }
        private void getQuestion()
        {
            //тема
            if (radioButton1.Checked)
                theme = 1;
            else
                theme = 2;
            //сложность
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

            // Отключаем элементы выбора
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            // Включаем отображение вопросов
            groupBox3.Visible = true;          // <-- добавить
            button3.Enabled = true;            // <-- кнопка "Далее" становится активной

            // Показываем вопрос
            displayQw();
        }

        private bool LoadQwe()
        {
            try
            {
                // Находим все темы
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

                // Получаем все вопросы (тег <q> внутри <qw>)
                var questionElements = levelNode.Descendants("q").ToList();

                // Перемешиваем вопросы и берём первые 5 (или сколько есть)
                Random rnd = new Random();
                var shuffled = questionElements.OrderBy(x => rnd.Next()).ToList();
                int takeCount = Math.Min(5, shuffled.Count);
                var selected = shuffled.Take(takeCount).ToList();

                ListQuestions.Clear();
                foreach (var qElem in selected)
                {
                    QuestionData qd = new QuestionData();
                    qd.Text = qElem.Element("text")?.Value ?? "Вопрос без текста";

                    // Получаем ответы
                    var answ = qElem.Element("answers");
                    if (answ != null)
                    {
                        var answerElems = answ.Descendants("answ");
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

            // Выводим текст вопроса в заголовок группы
            groupBox3.Text = q.Text;

            RadioButton[] answerButtons = { radioButton6, radioButton7, radioButton8, radioButton9 };
            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < q.Answers.Count)
                {
                    answerButtons[i].Text = q.Answers[i].Text;
                    answerButtons[i].Visible = true;
                    answerButtons[i].Enabled = true;   // <-- убеждаемся, что радио-кнопки активны
                    answerButtons[i].Checked = false;
                }
                else
                {
                    answerButtons[i].Visible = false;
                    answerButtons[i].Enabled = false;
                }
            }

            // Если на этот вопрос уже был дан ответ, восстанавливаем выбор
            if (userAnsw[qwInd] >= 0)
            {
                int idx = userAnsw[qwInd];
                if (idx < answerButtons.Length && answerButtons[idx].Visible)
                    answerButtons[idx].Checked = true;
            }

            // Счётчик вопросов
            label4.Text = $"{qwInd + 1}/5 вопросов";
        }

        // Обработчик для кнопки "Далее" (добавить в конструктор формы или через дизайнер)
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

            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите вариант ответа!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            userAnsw[qwInd] = selectedIndex;

            qwInd++;
            if (qwInd < ListQuestions.Count)
            {
                displayQw();
            }
            else
            {
                FinishTest();
            }
        }


        private void showTheme()// метод выводит название тем
        {
            using (XmlReader reader = XmlReader.Create(xmlFilePath))
            {
                int themeIndex = 0;

                while (reader.Read())
                {
                    // Ищем элемент <theme>
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "theme")
                    {
                        string themeName = reader.GetAttribute("name");

                        themeIndex++;

                        switch (themeIndex)
                        {
                            case 1:
                                label2.Text = themeName;
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

            // Подсчитываем правильные ответы
            correctCount = 0;
            for (int i = 0; i < ListQuestions.Count; i++)
            {
                int selected = userAnsw[i];
                if (selected >= 0 && selected < ListQuestions[i].Answers.Count &&
                    ListQuestions[i].Answers[selected].IsCorrect)
                {
                    correctCount++;
                }
            }

            int total = ListQuestions.Count;
            int score = correctCount * 20; // баллы 

            // Сохраняем результат в user_score (например, для текущего уровня)
            user_score[dificulty - 1] = score; // здесь можете настроить сохранение

            string message = $"Вы ответили правильно на {correctCount} из {total} вопросов.\nВаш результат: {score} баллов.\n";
            if (score >= 80 && dificulty < 3)
            {
                message += "Поздравляем! Вы набрали 80+ баллов. Хотите перейти на следующий уровень?";
                DialogResult result = MessageBox.Show(message, "Результат теста", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dificulty++;
                    // Загружаем следующий уровень
                    if (LoadQwe())
                    {
                        qwInd = 0;
                        correctCount = 0;
                        userAnsw = new int[ListQuestions.Count];
                        for (int i = 0; i < userAnsw.Length; i++) userAnsw[i] = -1;
                        displayQw();
                        return;
                    }
                }
            }
            else
            {
                message += score >= 80 ? "Вы прошли все уровни! Поздравляем!" : "Вы не набрали 80 баллов. Для перехода на следующий уровень нужно набрать 80 баллов.";
                MessageBox.Show(message, "Результат теста", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Возврат в главное меню
            ReturnToMainMenu();
        }
        private void ReturnToMainMenu()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button3.Enabled = false;          // <-- кнопка "Далее" становится неактивной
            testRunning = false;
            ListQuestions.Clear();
            groupBox3.Visible = false;         // <-- скрываем группу вопросов

            // Сбрасываем радио‑кнопки, чтобы не оставался выбранный ответ
            RadioButton[] answerButtons = { radioButton6, radioButton7, radioButton8, radioButton9 };
            foreach (var rb in answerButtons)
            {
                rb.Checked = false;
                rb.Visible = false;
                rb.Enabled = false;
            }

            this.Size = new Size(823, 495);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
