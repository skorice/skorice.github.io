using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppSUPABASE1
{
    internal class SupabaseService
    {
        public static async Task InitializeAsync()
        {

            var url = "https://hfirhbncadzydvmyatjy.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImhmaXJoYm5jYWR6eWR2bXlhdGp5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzMzNzg0MjUsImV4cCI6MjA4ODk1NDQyNX0.Np1NgHDKYQR8L2aRIPvfOkztfaRKctcD8R00g9hyD3w";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };
            var supabase = new Supabase.Client(url, key, options);
            var res= await supabase.InitializeAsync();
        }
    }
}

