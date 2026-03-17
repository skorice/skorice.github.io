using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSUPABASE1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var url = "https://hfirhbncadzydvmyatjy.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImhmaXJoYm5jYWR6eWR2bXlhdGp5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzMzNzg0MjUsImV4cCI6MjA4ODk1NDQyNX0.Np1NgHDKYQR8L2aRIPvfOkztfaRKctcD8R00g9hyD3w";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            var supabase = new Supabase.Client(url, key, options);
            supabase.InitializeAsync();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
