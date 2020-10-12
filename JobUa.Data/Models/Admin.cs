using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobUa.Data.Models
{
    public class Admin
    {
        public Guid AdminID { get; private set; }
        public string AdminName { get; set; }
        public string Obligations { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationData { get; set; }

        public bool IsValPassword(string inputPassword)
        {
            int minLen = 8;
            int maxLen = 30;
            return inputPassword.Length > minLen && inputPassword.Length < maxLen;
        }

        public bool IsCorrectPassword(string InputPassword) => InputPassword == Password;
    }
}
