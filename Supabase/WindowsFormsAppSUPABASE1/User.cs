using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace WindowsFormsAppSUPABASE1
{
    internal class User
    {
        [Table("users")]
        public class UserModel : BaseModel
        {
            [PrimaryKey("username")]
            [Column("username")]
            public string Name { get; set; }

            [Column("password")]
            public string Password { get; set; }
        }
    }
}