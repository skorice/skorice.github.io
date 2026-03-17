using Supabase;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsAppSUPABASE1.User;

namespace WindowsFormsAppSUPABASE1
{
    public partial class Form1 : Form
    {
        private Client supabase;

        public Form1()
        {
            InitializeComponent();
            InitializeSupabase();
        }

        private async void InitializeSupabase()
        {
            try
            {
                var options = new SupabaseOptions
                {
                    AutoConnectRealtime = true,
                    AutoRefreshToken = true
                };

                supabase = new Client(
                    "https://hfirhbncadzydvmyatjy.supabase.co",
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImhmaXJoYm5jYWR6eWR2bXlhdGp5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzMzNzg0MjUsImV4cCI6MjA4ODk1NDQyNX0.Np1NgHDKYQR8L2aRIPvfOkztfaRKctcD8R00g9hyD3w",
                    options
                );

                await supabase.InitializeAsync();

                // Тест подключения
                await TestConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации Supabase: {ex.Message}", "Ошибка");
            }
        }

        private async Task TestConnection()
        {
            try
            {
                var response = await supabase
                    .From<UserModel>()
                    .Get();

                Console.WriteLine($"Статус: Подключено. Записей: {response.Models.Count}"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Статус: Ошибка подключения");
                MessageBox.Show($"Ошибка тестового подключения: {ex.Message}", "Ошибка");
            }
        }

        // Регистрация
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text.Trim();
                string password = textBox2.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка");
                    return;
                }

                // Проверяем, существует ли пользователь
                var existingUsers = await supabase
                    .From<UserModel>()
                    .Where(x => x.Name == username)
                    .Get();

                if (existingUsers.Models.Any())
                {
                    MessageBox.Show("Пользователь с таким именем уже существует!", "Ошибка");
                    return;
                }

                // Создаем нового пользователя
                var newUser = new UserModel
                {
                    Name = username,
                    Password = password 
                };

                var response = await supabase
                    .From<UserModel>()
                    .Insert(newUser);

                if (response.Models.Any())
                {
                    MessageBox.Show($"Регистрация успешна! Пользователь: {username}", "Успех");
                    textBox1.Text = "";
                    textBox2.Text = "";

                    await TestConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Ошибка");
            }
        }

        // Вход
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text.Trim();
                string password = textBox2.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Введите имя и пароль!", "Ошибка");
                    return;
                }

                // Ищем пользователя
                var response = await supabase
                    .From<UserModel>()
                    .Where(x => x.Name == username && x.Password == password)
                    .Get();

                if (response.Models.Any())
                {
                    var user = response.Models[0];
                    MessageBox.Show($"Добро пожаловать, {user.Name}!", "Успешный вход");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка входа");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка входа: {ex.Message}");
            }
        }

    }
}